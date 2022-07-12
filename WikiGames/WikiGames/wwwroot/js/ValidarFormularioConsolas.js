
function ValidarFormulario()
{

        document.getElementById("formulario").addEventListener('submit', validarFormulario);
        document.getElementById('descripcion').addEventListener('change', checkDescripcion);
        document.getElementById('unidadesVendidas').addEventListener('change', checkUnidades);
        document.getElementById('descontinuacion').addEventListener('change', checkFechaDescontinuacion);
        document.getElementById('MarcaId').addEventListener('change', marcaValue);
        document.getElementById('fechaLanzamiento').addEventListener('change', checkFechaLanzamiento);
        document.getElementById('consolaName').addEventListener('change', checkName);



    function validarFormulario(evento) {
        evento.preventDefault();
        let flag = true;

        if (!checkDescripcion()) {
            flag = false;
        }
        if (!checkFechaDescontinuacion()) {

            flag = false;
        }
        if (!checkFechaLanzamiento()) {
            flag = false;
        }
        if (!checkName()) {
            flag = false;
        }
        if (!marcaValue()) {
            flag = false;
        }
        if (!checkUnidades()) {
            flag = false;
        }
        if (flag) {
            this.submit();
        }

        return;
    }



    function checkUnidades() {

        let unidades = document.getElementById('unidadesVendidas').value;

        let num = parseInt(unidades);
        if (unidades >= 0 && Number.isInteger(num)) {
            document.getElementById('spanUnidadesVendidas').innerHTML = "";
            return true;
        }
        document.getElementById('spanUnidadesVendidas').innerHTML = "unidad debe ser un numero positivo o 0";
        return false;
    }
    function checkDescripcion() {
        let descrip = document.getElementById('descripcion').value;

        if (descrip.length == 0) {
            document.getElementById('spanDescripcion').innerHTML = "Cargue descripcion";
            return false;
        }
        document.getElementById('spanDescripcion').innerHTML = "";
        return true;
    }

    function checkFechaDescontinuacion() {

        let fechaLanza = document.getElementById('fechaLanzamiento').value;
        let descont = document.getElementById('descontinuacion').value;

        if (fechaLanza == "") {
            document.getElementById('spanFechaLanzamiento').innerHTML = "Complete fecha lanzamiento";
        }
        else if (descont == "" || descont > fechaLanza) {
            document.getElementById('spanDescontinuacion').innerHTML = "";

            return true;
        } else {
            document.getElementById('spanDescontinuacion').innerHTML = "Descontinuacion tiene que ser mayor a fecha lanzamiento";

            return false;

        }
    };

    function marcaValue() {
        let marca = document.getElementById('MarcaId').value;
        if (marca > 0) {

            return true;
        }
        let text = "Seleccione marca";
        document.getElementById('spanMarcas').innerHTML = text;
        return false;
    }

    function checkFechaLanzamiento() {

        let fecha = $("#fechaLanzamiento").val();
        checkFechaDescontinuacion();
        if (fecha) {
            document.getElementById('spanFechaLanzamiento').innerHTML = "";
            return true;
        }
        else
            document.getElementById('spanFechaLanzamiento').innerHTML = "Complete fecha lanzamiento";
        return false;
    }

    function checkName() {

        let name = document.getElementById('consolaName').value;

        if (name.length >= 3) {

            document.getElementById('spanName').innerHTML = "";
            return true;
        }
        document.getElementById('spanName').innerHTML = "Es necesario completar el campo nombre";
        return false;
    }


}

