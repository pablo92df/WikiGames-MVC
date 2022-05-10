// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

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

    publicadoConsola.ConsolaName = consola;
    publicadoConsola.ConsolaId = consolaId;
    publicadoConsola.FechaLanzamiento = fecha;
    publicadoConsola.CopiasVendidas = cantidad;
    consolaGame.push(publicadoConsola);

    let juegoConsola =
        "<tr><td>" + consola
        + "</td><td>" + fecha
        + "</td><td>" + cantidad
        + "</td><td><button>Borrar</button></td></tr >";

    listConsolas.append(juegoConsola);
    resetFieldJuegoConsola();

});



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
 
        var $divConGenero = $('<div ><label type="button" >' + generoName + '</label><button id=' + generoId + ' class="btnQuickGenero">X</button></div>')
        divGeneros.append($divConGenero);

        var buttonQuick = document.querySelectorAll("button.btnQuickGenero")

        buttonQuick.forEach(function (btn) {
            btn.addEventListener('click', function (e) {
                quitarGenero(e.target.id);
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
    for (var i in Generos)
    {
        console.log(Generos[i]);
    }
    debugger;
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
//FIN DE CARGAR JUEGOS NUEVOS 
////////////////////////////////