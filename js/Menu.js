$(document).ready(CargarGrilla);

function CerrarSesion() {
    $.ajax({
        url: 'CerrarSesion.aspx',
        dataType: 'json',
        method: 'POST',
        success: function (respuesta) {
            if (respuesta.Codigo === '0') {
                window.location.href = respuesta.Mensaje;
            }
            else {
                alert(respuesta.Mensaje);
            }
        },
        error: function (e) {
            console.log(e);
        }
    });
}


function CargarGrilla() {
    $.ajax({
        url: 'Formularios/ObtenerGrilla.aspx',
        dataType: 'json',
        method: 'POST',
        success: function (respuesta) {
            $("#grilla").html(respuesta.Datos)
        },
        error: function (e) {
            console.log(e);
        }
    });
}