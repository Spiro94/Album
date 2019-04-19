<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Menu.aspx.cs" Inherits="Album.Menu" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1" />
    <title>Página principal</title>
    <script src="js/jquery-3.3.1.js"></script>
    <script src="js/bootstrap.js"></script>
    <link rel="stylesheet" type="text/css" href="css/bootstrap.css" />
    <link rel="stylesheet" type="text/css" href="css/bootstrap-theme.css" />

    <link rel="stylesheet" type="text/css" href="css/principal.css" />
    <script src="js/Menu.js"></script>
</head>
<body>
    <div class="contenedorPrincipal">
        <div class="barraSuperior">
            <div>Titulo</div>
            <div>
                <button id="cerrarSesion" onclick="CerrarSesion()" value="Cerrar Sesion" >Cerrar Sesion</button>
            </div>
        </div>
        <div class="barraLateral">
            <div>
                <a>Enlace 1</a>
                <a>Enlace 2</a>
            </div>
        </div>
        <div class="contenidoCentral">
            <div>
                Grilla con album
            </div>
            <div id="grilla">
                Grilla
            </div>
        </div>
    </div>

</body>
</html>
