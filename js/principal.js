$(document).ready(function () {
    let boton = $('#enviar');
    $(document).keypress(function (e) {
        if (e.which == 13) {
            console.log(e);
            boton.trigger("click");
        }
    });
});