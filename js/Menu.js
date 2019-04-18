$(document).ready(function () {
    $.ajax({
        url: 'Formularios/ObtenerGrilla.aspx',
        dataType: 'json',
        data: {
            usuario: 'user'
        },
        success: function (respuesta) {
            console.log(respuesta);
        },
        error: function () {
            console.log("No se ha podido obtener la información");
        }
    });
});