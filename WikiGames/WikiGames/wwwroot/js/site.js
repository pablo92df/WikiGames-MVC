// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

//const { Alert } = require("../lib/bootstrap/dist/js/bootstrap.bundle");

// Write your JavaScript code.
const Generos = new Array();
const consolaGame = new Array();
const ModosDeJuego = new Array();


///////////////////////////////AGREGAR EVENTOS ADDEVENTLISTENER/////////
body.addEventListener('keyup', () => {
    if (event.target.id == "ventas") {
        let campo = document.getElementById("ventas");
        if (campo.value == '' || campo.value < 0) {
            campo.style.borderColor = "red";
        }
        else {
            campo.style.borderColor = "green";
        }
    }
    if (event.target.id == "juegoName") {
        let campo = document.getElementById("juegoName");
        if (validarString(campo.value)) {
            campo.style.borderColor = "red";
        }
        else {
            campo.style.borderColor = "green";
        }
    }

});

//CARGAR JUEGOS NUEVOS
//AGREGAR LANZAMIENTO POR CONSOLA

$("#btnAgregar").click(function () {

    let publicadoConsola = {};
    let listConsolas = $("#tBody");
    let consola = $("#consolaName option:selected").text();
    let consolaId = $("#consolaName option:selected").val();
    let cantidad = $("#ventas").val();
    let fecha = $("#fechaLanzamiento").val();

    // validacionConsola(consola, cantidad, fecha);
    if (consolaGame.length > 0) {

        for (let i in consolaGame) {

            if (consolaGame[i].ConsolaId === consolaId) {
                alert("Consola ya cargada");
                return;
            }
        }
    }

    if (validacionConsola()) {

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
    }


});


function validacionConsola() {

    var ventas = document.getElementById("ventas");

    let flag = true;
    //if (validarString(consola)) {
    //    // alert("Cargar Un nombre consola");


    //    flag = false;
    //}
    if (ventas.value == '') {
        ventas.style.borderColor = "red";
        flag = false;
    }
    //if (ValidarFecha($("#fechaOficial").val())) {
    //   // alert("Fecha Incorrecta");
    //    console.log("Cantidad fecha");
    //    flag = false;
    //}
    return flag;
}
function quitarConsola(idConsola) {

    for (let i in consolaGame) {
        if (consolaGame[i].ConsolaId === idConsola) {
            consolaGame.splice(i, 1);
        }
    }
}
//-------------------------AGREGAR GENEROS A LOS JUEGOS--------------------------//
$("#GeneroId").change(function () {
 
    let divGeneros = $("#generosSeleccionados");
    let generoId = $("#GeneroId option:selected").val();
    let generoName = $("#GeneroId option:selected").text();
    let flag = false;

    if (generoId === "") {
        return;
    }
    for (let i in Generos) {
        if (Generos[i] === generoId) {
            return;
        }
    }

    Generos.push(generoId);

    var $divConGenero = $('<div ><label  class="form-label" >' + generoName + '</label><button  value=' + generoId + ' id=' + generoName + ' class="btnQuickGenero btn btn-danger  btn-sm" type="button"/>x</button></div>')
    divGeneros.append($divConGenero);

    var buttonQuick = document.querySelectorAll("button.btnQuickGenero")

    buttonQuick.forEach(function (btn) {
        btn.addEventListener('click', function (e) {
            quitarGenero($(this).val());
            $(this).parent().remove();
        });
    });

});

function quitarGenero(idGenero) {

    for (let i in Generos) {
        if (Generos[i] === idGenero) {
            Generos.splice(i, 1);
        }
    }
}
//---------------------------AGREGAR DESARROLLADORA-------------------------//
$("#ModoDeJuegoId").change(function () {

    let divModosDeJuego = $("#ModoDeJuegoSeleccionados");
    let ModoDeJuegoId = $("#ModoDeJuegoId option:selected").val();
    let ModoDeJuegoName = $("#ModoDeJuegoId option:selected").text();
    let flag = false;


    for (let i in ModosDeJuego) {
        if (ModosDeJuego[i] === ModoDeJuegoId) {
            flag = true;
        }
    }
    if (!flag) {
        ModosDeJuego.push(ModoDeJuegoId);

        var $divConModos = $('<div ><label  >' + ModoDeJuegoName + '</label><button  value=' + ModoDeJuegoId + ' id=' + ModoDeJuegoName + ' class="btnQuickGenero"/>X</button></div>')
        divModosDeJuego.append($divConModos);

        var buttonQuick = document.querySelectorAll("button.btnQuickGenero")

        buttonQuick.forEach(function (btn) {
            btn.addEventListener('click', function (e) {
                quitarGenero($(this).val());
                $(this).parent().remove();
            });
        });
    }
});
//------------------------
function resetFieldJuegoConsola() {
    $("#consolaName option:selected").text();
    $("#ventas").val('');
    $("#fechaLanzamiento").val('');
}

$("#crearJuego").click(function () {



    if (validarGeneros(Generos)) {

    }
    if (validarString($("#juegoName").val())) {
        alert("Cargar Un nombre");
        return false;
    }
    if (validarString($("#descripcion").val())) {
        alert("Cargar descripcion");
        return false;
    }
    if (ValidarFecha($("#fechaOficial").val())) {
        alert("Fecha Incorrecta");
        return false;
    }

    let juegoViewModel = {};
    juegoViewModel.JuegoName = $("#juegoName").val();
    juegoViewModel.JuegoDescription = $("#descripcion").val();
    juegoViewModel.Generos = Generos;
    juegoViewModel.FechaLanzamientoOficial = $("#fechaOficial").val();
    juegoViewModel.DesarrolladoraId = $("#DesarrolladoraId option:selected").val();
    juegoViewModel.PublicadoraId = $("#PublicadoraId option:selected").val();
    juegoViewModel.JuegosConsolaDTO = consolaGame;
    juegoViewModel.Argumento = $("#argumento").val();
    juegoViewModel.ModosDeJuegos = ModosDeJuego;

    $.ajax({
        async: true,
        type: 'POST',
        dataType: "application/json; charset=UTF-8",
        data: juegoViewModel,
        url: "https://localhost:7033/Juego/CreateJuego",
        success: function (data) {

        },
        error: function (jqXHR, textStatus, errorThrown) {
            console.log(errorThrown);
        }
    })


});

function validarGeneros(Generos) {
    for (let i in Generos) {
        if (Generos[i] < 1) {
            return false;
        }
    }
    return true;
}
function validarString(text) {
    if (text == null || text.length == 0 || /^\s+$/.test(text)) {

        return true;
    }
    return false;
}

function ValidarFecha(fecha) {

    if (fecha) {
        return false;
    }
    return true;
}
//-----------------------------FIN DE CARGAR JUEGOS NUEVOS
////////////////////////////////

