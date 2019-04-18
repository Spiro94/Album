using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Album
{
    public partial class ObtenerGrilla : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {           

            string method = HttpContext.Current.Request.HttpMethod;

            string requestedWith = HttpContext.Current.Request.Headers["X-Requested-With"];

            if (method == "POST" && requestedWith == "XMLHttpRequest")
            {
                if (!this.Page.User.Identity.IsAuthenticated)
                {
                    FormsAuthentication.RedirectToLoginPage();
                }
                else
                {
                    string usuario = FormsAuthentication.Decrypt(Request.Cookies[FormsAuthentication.FormsCookieName].Value).Name;



                }
            }
            else
            {

            }


        }
    }
}