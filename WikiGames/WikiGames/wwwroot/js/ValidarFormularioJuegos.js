function ValidarJuego() {
    const consolaGame = new Array();
    const Generos = new Array();
    const ModosDeJuego = new Array();

    document.getElementById('juegoName').addEventListener('change', checkJuegoName);
    document.getElementById('descripcion').addEventListener('change', checkDescripcion);
    document.getElementById('argumento').addEventListener('change', checkArgumento);
    document.getElementById('fechaOficial').addEventListener('change', checkFechaLanzamiento);


    document.getElementById('unidadesVendidas').addEventListener('change', function () {

        let unidades = document.getElementById('unidadesVendidas');
        if (!checkUnidades(unidades)) {
            document.getElementById('spanUnidadesVendidas').innerHTML = "Unidades debe se 0 o mayor";
            return;
        }
        document.getElementById('spanUnidadesVendidas').innerHTML = "";
        return;
    });


    document.getElementById('PublicadoraId').addEventListener('change', function () {
        let publicadora = document.getElementById('PublicadoraId');

        if (!checkSelects(publicadora)) {
            document.getElementById('spanPublicadora').innerHTML = "Seleccione Publicadora";
            return;
        }
        document.getElementById('spanPublicadora').innerHTML = "";
    });

    document.getElementById('DesarrolladoraId').addEventListener('change', function () {
        let desarrolladora = document.getElementById('DesarrolladoraId');

        if (!checkSelects(desarrolladora)) {
            document.getElementById('spanDesarrolladora').innerHTML = "Seleccione Desarrolladora";
            return;
        }
        document.getElementById('spanDesarrolladora').innerHTML = "";
    });

    function checkFechaLanzamiento() {

        let fecha = $("#fechaOficial").val();
        checkLanzamientoEnConsola();
        if (fecha) {
            document.getElementById('spanFechaLanzamiento').innerHTML = "";
            return true;

        }
        else
            document.getElementById('spanFechaLanzamiento').innerHTML = "Complete fecha lanzamiento";

        return false;
    }
    function checkUnidades(cantidad) {

        let num = parseInt(cantidad.value);
        if (num >= 0 && Number.isInteger(num)) {
            cantidad.style.borderColor = "green";
            return true;
        }
        cantidad.style.borderColor = "red";
        return false;
    }

    function checkSelects(valueSelect) {

        if (valueSelect.value !== "") {
            valueSelect.style.borderColor = "green";
            return true;
        }
        valueSelect.style.borderColor = "red";
        return false;
    }

    function checkDescripcion() {
        let descripValue = document.getElementById('descripcion').value;
        let descrip = document.getElementById('descripcion');

        if (descripValue.length >= 3) {

            document.getElementById('spanDescripcion').innerHTML = "";
            descrip.style.borderColor = "green";

            return true;
        }
        document.getElementById('spanDescripcion').innerHTML = "Cargue Descripcion";

        descrip.style.borderColor = "red";

        return false;
    }

    function checkJuegoName() {
        let nameValue = document.getElementById('juegoName').value;
        let name = document.getElementById('juegoName');

        if (nameValue.length >= 1) {
            document.getElementById('spanName').innerHTML = "";
            name.style.borderColor = "green";

            return true;
        }
        document.getElementById('spanName').innerHTML = "Cargue Nombre";
        name.style.borderColor = "red";

        return false;
    }

    function checkArgumento() {
        let argumenValue = document.getElementById('argumento').value;
        let argumen = document.getElementById('argumento');

        if (argumenValue.length == 0) {
            document.getElementById('spanArgumento').innerHTML = "Cargue argumento";
            argumen.style.borderColor = "red";

            return false;
        }
        document.getElementById('spanArgumento').innerHTML = "";
        argumen.style.borderColor = "green";

        return true;
    }

    function checkLanzamientoEnConsola() {
        let fechaEnConsola = document.getElementById('fechaLanzamientoEnConsola').value;
        let fechaOficial = document.getElementById('fechaOficial').value;

        if ((fechaEnConsola == "" || fechaEnConsola >= fechaOficial) && fechaOficial != "") {
            document.getElementById('spanLanzamientoEnConsola').innerHTML = "";

            return true;
        }

        document.getElementById('spanLanzamientoEnConsola').innerHTML = "Lanzamiento de consola tiene que ser mayor a fecha lanzamiento oficial";
        return false;

    }



    $("#btnAgregar").click(function () {

        let consolaPublicada = {};
        let tBodyConsolas = $("#tBody");
        let consolaName = $("#ConsolaId option:selected").text();
        let consola = document.getElementById('ConsolaId');
        let cantidad = document.getElementById('unidadesEnConsola');
        let fecha = document.getElementById('fechaLanzamientoEnConsola').value;

        let flag = true;

        if (consolaGame.length > 0) {

            for (let i in consolaGame) {
                if (consolaGame[i].ConsolaId === consola.value) {
                    alert("Consola ya cargada");
                    return;
                }
            }
        }

        if (!checkSelects(consola)) {
            document.getElementById('spanConsola').innerHTML = "Seleccione consola";
            flag = false;
        }
        else {
            document.getElementById('spanConsola').innerHTML = "";
        }
        if (!checkUnidades(cantidad)) {
            flag = false;
        }
        if (!checkLanzamientoEnConsola()) {
            flag = false;
        }

        if (flag) {

            consolaPublicada.ConsolaName = consolaName;
            consolaPublicada.ConsolaId = consola.value;
            consolaPublicada.FechaLanzamiento = fecha;
            consolaPublicada.CopiasVendidas = cantidad.value;
            consolaGame.push(consolaPublicada);

            document.getElementById('')
            let juegoConsola =
                "<tr><td>" + consolaName
                + "</td><td>" + fecha
                + "</td><td>" + cantidad.value
                + "</td><td><button class='btnQuickConsola' id=" + consola.value + ">Borrar</button></td></tr >";

            tBodyConsolas.append(juegoConsola);
            let buttonQuickConsola = document.querySelectorAll("button.btnQuickConsola")

            buttonQuickConsola.forEach(function (btn) {
                btn.addEventListener('click', function (e) {

                    quitarConsola(e.target.id);
                    $(this).closest('tr').remove();
                });
            });
            resetFieldJuegoConsola();
        }


    });

    function quitarConsola(idConsola) {

        for (let i in consolaGame) {
            if (consolaGame[i].ConsolaId === idConsola) {
                consolaGame.splice(i, 1);
            }
        }
    }

    function resetFieldJuegoConsola() {
        document.getElementById('spanConsola').innerHTML = "";
        document.getElementById('ConsolaId').style.borderColor = "#ced4da";
        document.getElementById('unidadesEnConsola').style.borderColor = "#ced4da";
        document.getElementById('spanLanzamientoEnConsola').innerHTML = "";
        $("#consolaName option:selected").text();
        $("#ventas").val('');
        $("#fechaLanzamiento").val('');
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
    ////---------------------------AGREGAR Modos de juego-------------------------//
    $("#ModoDeJuegoId").change(function () {

        let divModosDeJuego = $("#ModoDeJuegoSeleccionados");
        let ModoDeJuegoId = $("#ModoDeJuegoId option:selected").val();
        let ModoDeJuegoName = $("#ModoDeJuegoId option:selected").text().replace(/ /g, "");
      
       
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
    let fileData = new FormData();
    let fileImg = document.getElementById('file');
    fileImg.addEventListener('change', function () {
        debugger;
        var fileUpload = $("#file").get(0);
        var files = fileUpload.files;

        fileData.append(files[0].name, files[0]);
        console.log(fileData.append.name);


    })

    $("#btnCrearConsola").click(function () {
        /*debugger;
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

        let JuegoCreacionViewModel = {};
        JuegoCreacionViewModel.JuegoName = $("#juegoName").val();
        JuegoCreacionViewModel.JuegoDescription = $("#descripcion").val();
        JuegoCreacionViewModel.Generos = Generos;
        JuegoCreacionViewModel.FechaLanzamientoOficial = $("#fechaOficial").val();
        JuegoCreacionViewModel.DesarrolladoraId = $("#DesarrolladoraId option:selected").val();
        JuegoCreacionViewModel.PublicadoraId = $("#PublicadoraId option:selected").val();
        JuegoCreacionViewModel.JuegosConsolaDTO = consolaGame;
        JuegoCreacionViewModel.Argumento = $("#argumento").val();
        JuegoCreacionViewModel.ModosDeJuegos = ModosDeJuego;

        $.ajax({
            async: true,
            type: 'POST',
            dataType: "application/json; charset=UTF-8",
            data: JuegoCreacionViewModel,
            url: "https://localhost:7033/Juego/CreateJuego",
            success: function (data) {

            },
            error: function (jqXHR, textStatus, errorThrown) {
                console.log(errorThrown);
            }
        })*/
        $.ajax({
            url: 'https://localhost:7033/Juego/CreateJuego', //URL to upload files 
            type: "POST", //as we will be posting files and other method POST is used
            processData: false, //remember to set processData and ContentType to false, otherwise you may get an error
            contentType: false,
            data: fileData,
            success: function (result) {
                alert(result);
            },
            error: function (err) {
                alert(err.statusText);
            }
        });


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
}