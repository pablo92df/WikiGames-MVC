// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
const Generos = new Array();

$(document).ready(function () {
    console.log("document");
    if ($("#generos").length > 0)
    {
        //  generateArrayJuehos();
    }
});


$("#btnAgregar").click(function () {

    let listConsolas = $("#tBody");
    let consola = $("#consolaName option:selected").text();
    let consolaId = $("#consolaName option:selected").val();
    let cantidad = $("#ventas").val();
    let fecha = $("#fechaLanzamiento").val();
   
    let juegoConsola =
        "<tr><td>" + consola
        + "</td style='visibility:hidden'><td>" + consolaId
        + "</td><td>" + fecha
        + "</td><td>" + cantidad
        +"</tr >";

    listConsolas.append(juegoConsola);
    resetFieldJuegoConsola();

});

function quitarGenero(idGenero) {
    for (let i in Generos) {
        if (Generos[i] === idGenero) {
            Generos.splice(i)
        }
    }
    var divElement = document.getElementById("generosSeleccionados");
    var divDelete = document.getElementById("idGenero");
    divElement.removeChild(divDelete);
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
        debugger;
        var $divConGenero = $('<div id=' + generoId + '><label >' + generoName + '</><label class="btnSacarGenero" onClick='+quitarGenero(generoId)+'>X</label></div>')
        divGeneros.append($divConGenero);
    }
 
});


function resetFieldJuegoConsola()
{
    $("#consolaName option:selected").text();
    $("#ventas").val('');
    $("#fechaLanzamiento").val('');
}

$("#crearJuego").click(function () {
    let juegoDTO = {};
    juegoDTO.JuegoName = $("#juegoName").val();
    console.log($("#juegoName").val());
    juegoDTO.Descripcion = $("#descripcion").val();
    juegoDTO.Generos = Generos;
    juegoDTO.FechaLanzamientoOficial = $("#fechaOficial").text();

  
    let JuegosConsolaDTO = new Array();
    $("#tableConsolas").find("tr:gt(0)").each(function () {
        var juegoConsola = {};

        juegoConsola.ConsolaName = $(this).find("td:eq(0)").text();
        juegoConsola.ConsolaId = $(this).find("td:eq(1)").text();
        juegoConsola.FechaLanzamiento = $(this).find("td:eq(2)").text();
        juegoConsola.CopiasVendidas = $(this).find("td:eq(3)").text();
 
        JuegosConsolaDTO.push(juegoConsola);
        juegoDTO.JuegosConsolaDTO = JuegosConsolaDTO;
    });

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