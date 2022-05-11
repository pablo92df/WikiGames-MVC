// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

//const { Alert } = require("../lib/bootstrap/dist/js/bootstrap.bundle");

// Write your JavaScript code.
const Generos = new Array();
const consolaGame = new Array();


//CARGAR JUEGOS NUEVOS
//AGREGAR LANZAMIENTO POR CONSOLA
$("#btnAgregar").click(function () {

    let publicadoConsola = {};
    let listConsolas = $("#tBody");
    let consola = $("#consolaName option:selected").text();
    let consolaId = $("#consolaName option:selected").val();
    let cantidad = $("#ventas").val();
    let fecha = $("#fechaLanzamiento").val();


    validacionConsola(consola, cantidad, fecha);
        publicadoConsola.ConsolaName = consola;
        publicadoConsola.ConsolaId = consolaId;
        publicadoConsola.FechaLanzamiento = fecha;
        publicadoConsola.CopiasVendidas = cantidad;
        consolaGame.push(publicadoConsola);

        let juegoConsola =
            "<tr><td>" + consola
            + "</td><td>" + fecha
            + "</td><td>" + cantidad
            + "</td><td><button class='btnQuickConsola' id=" + consolaId + ">Borrar</button></td></tr >";

        listConsolas.append(juegoConsola);
        let buttonQuickConsola = document.querySelectorAll("button.btnQuickConsola")

        buttonQuickConsola.forEach(function (btn) {
            btn.addEventListener('click', function (e) {


                console.log(e.target.id);
                quitarConsola(e.target.id);
                $(this).closest('tr').remove();
            });
        });
        resetFieldJuegoConsola();
});
function validacionConsola(consola, cantidad, fecha)
{
    let flag = true;
    if (validarString(consola)) {
       // alert("Cargar Un nombre consola");
      
        flag = false;
    }
    if (isNaN(cantidad) || cantidad < 0) {
       // alert("Cantidad incorrecta");
        console.log("Cantidad incorrecta");
        flag = false;

    }
    if (ValidarFecha($("#fechaOficial").val())) {
       // alert("Fecha Incorrecta");
        console.log("Cantidad fecha");
        flag = false;
    }
    return flag;
}
function quitarConsola(idConsola) {

    for (let i in consolaGame) {
        if (consolaGame[i].ConsolaId === idConsola) {
            consolaGame.splice(i, 1);
        }
    }
}

$("#generos").change(function () {
 
    let divGeneros = $("#generosSeleccionados");
    let generoId = $("#generos option:selected").val();
    let generoName = $("#generos option:selected").text();
    let flag = false;


    for (let i in Generos)
    {
        if (Generos[i] === generoId)
        {
            flag = true;
        }
    }
    if (!flag)
    {
        Generos.push(generoId);
 
        var $divConGenero = $('<div ><label  >' + generoName + '</label><button  value=' + generoId + ' id=' + generoName +' class="btnQuickGenero"/>X</button></div>')
        divGeneros.append($divConGenero);

        var buttonQuick = document.querySelectorAll("button.btnQuickGenero")

        buttonQuick.forEach(function (btn) {
            btn.addEventListener('click', function (e) {
                quitarGenero($(this).val());
                $(this).parent().remove();
            });
        });  
    }
});

function quitarGenero(idGenero) {
    
    for (let i in Generos) {
        if (Generos[i] === idGenero) {
            Generos.splice(i, 1);
        }
    }
}

function resetFieldJuegoConsola()
{
    $("#consolaName option:selected").text();
    $("#ventas").val('');
    $("#fechaLanzamiento").val('');
}

$("#crearJuego").click(function () {



    if (validarGeneros(Generos))
    {

    }
    if (validarString($("#juegoName").val()))
    {
        alert("Cargar Un nombre");
        return false;
    }
    if (validarString($("#descripcion").val()))
    {
        alert("Cargar descripcion");
        return false;
    }
    if (ValidarFecha($("#fechaOficial").val()))
    {
        alert("Fecha Incorrecta");
        return false;
    }

        let juegoDTO = {};
        juegoDTO.JuegoName = $("#juegoName").val();
        console.log($("#juegoName").val());
        juegoDTO.Descripcion = $("#descripcion").val();
        juegoDTO.Generos = Generos;
        juegoDTO.FechaLanzamientoOficial = $("#fechaOficial").text();

        juegoDTO.JuegosConsolaDTO = consolaGame;

        $.ajax({
            async: true,
            type: 'POST',
            dataType: "application/json; charset=UTF-8",
            data: juegoDTO,
            url: "https://localhost:7033/Juego/Create",
            success: function (data) {

            },
            error: function (jqXHR, textStatus, errorThrown) {
                console.log(errorThrown);
            }
        })
    
    
});

function validarGeneros(Generos)
{
    for (let i in Generos)
    {
        if (Generos[i] < 1)
        {
            return false;
        }
    }
    return true;
}
function validarString(text)
{
    if (text.length == 0) {
       
        return true;
    }
    return false;
}

function ValidarFecha(fecha) {
    console.log(fecha);
    if (fecha)
    {
        return false;
    }
    return true;
    //const day = parseInt(fecha.split('-')[2])
    //console.log(day);
    //const month = parseInt(fecha.split('-')[1])
    //console.log(month);
    //const year = parseInt(fecha.split('-')[0])
    //console.log(year);
    
    //if (year > 1900 && (month >= 1 && month <= 12) && (day >= 1 && day <= 31))
    //{
    //    if (month == 1 || month == 3 || month == 5 || month == 7 || month == 8 || month == 10 || month == 12) {
    //        if (day >= 1 && day <= 31) {
    //            return true;
    //        }
    //    }
    //    if (month == 4 || month == 6 || month == 9 || month == 11)
    //    {
    //        if (day >= 1 && day <= 30) {
    //            return true;
    //        }
    //    }
    //    if (month == 2) {
    //        if (day >= 1 && day <= 28) {
    //            return true;
    //        }
    //        if ((!(year % 4) && year % 100) || !(year % 400) && day == 29) {
    //            return true;
    //        }
    //    }
    //    else
    //    {
    //        return false;
    //    }
    //}

    //return false;

}
//FIN DE CARGAR JUEGOS NUEVOS 
////////////////////////////////