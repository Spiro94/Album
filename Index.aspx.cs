using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Album
{
    public partial class Index : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Page.User.Identity.IsAuthenticated)
            {
                Response.Redirect("Menu.aspx", true);
            }
        }

        protected void Login(object sender, EventArgs e)
        {
            string usuario = Request["user"];
            string contraseña = Request["pass"];
            bool recordar = Request["persistent"] == "on" ? true : false;

            if (string.IsNullOrEmpty(usuario) && string.IsNullOrEmpty(contraseña))
            {
                msjError.InnerText = "Usuario y contraseña requeridos";
            }
            else
            {
                string mensajeError = Procedimientos.ValidarUsuario(usuario, contraseña, out string idUsuario);

                if (mensajeError == "ok")
                {
                    FormsAuthentication.RedirectFromLoginPage(idUsuario, recordar);
                }
                else
                {
                    msjError.InnerText = mensajeError;
                }
                
            }
        }
    }
}