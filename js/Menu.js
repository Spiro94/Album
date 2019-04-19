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


function SeleccionarSticker(_id) {
    console.log(_id);
    let objeto = $("td#" + _id);
    let texto = objeto[0].innerText;
    console.log(texto);

    if (objeto.hasClass("seleccionado")) {
        objeto.removeClass("seleccionado");
    }
    else {
        objeto.addClass("seleccionado")
    }
}

function GuardarCambios() {
    let objetos = $("td.seleccionado");
    let cadena = "";
    objetos.each(function (i, e) {
        if (i == (objetos.length - 1)) {
            cadena += e.id;
        }
        else {
            cadena += e.id + ",";
        }
        console.log(e.id);

    });

    $.ajax({
        url: 'Formularios/GuardarAlbum.aspx',
        dataType: 'json',
        data: {
            stickers: cadena
        },
        method: 'POST',
        success: function (respuesta) {
            alert(respuesta.Mensaje);
        },
        error: function (e) {
            console.log(e);
        }
    });
}
