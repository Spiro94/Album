<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="Album.Index" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1" />
    <title>Album Web</title>
    <script src="js/jquery-3.3.1.js" ></script>
    <script src="js/bootstrap.js" ></script>
    <link rel="stylesheet" type="text/css" href="css/bootstrap.css" />
    <link rel="stylesheet" type="text/css" href="css/bootstrap-theme.css" />

    <link rel="stylesheet" type="text/css" href="css/principal.css" />
    <script src="js/principal.js"></script>
    
</head>
<body>
    <form id="formulario" runat="server">
        Usuario:
        <br />
        <input type="text" id="user" name="user" required="required"/>
        <br />
        Contraseña:
        <br />
        <input type="password" id="pass" name="pass" required="required"/>
        <br />
        Recordarme?
        <br />
        <input type="checkbox" id="persistent" name="persistent"/>
        <br />
        <br />
        <input type="button" id="enviar" runat="server" onserverclick="Login" value="Iniciar sesión" />
    </form>
</body>
</html>
