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
            if (this.Page.User.Identity.IsAuthenticated)
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
                Response.Redirect("Login.aspx", true);
            }
            else
            {
                FormsAuthentication.RedirectFromLoginPage(usuario, recordar);
            }
        }
    }
}