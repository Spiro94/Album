using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;

namespace Album
{
    public class Global : HttpApplication
    {
        protected void Application_Start(object sender, EventArgs e)
        {
        }

        //protected void FormsAuthentication_OnAuthenticate(Object sender, FormsAuthenticationEventArgs e)
        //{
        //    if (FormsAuthentication.CookiesSupported == true)
        //    {
        //        if (Request.Cookies[FormsAuthentication.FormsCookieName] != null)
        //        {
        //            try
        //            {
        //                string usuario = FormsAuthentication.Decrypt(Request.Cookies[FormsAuthentication.FormsCookieName].Value).Name;

        //                //FormsAuthentication.RedirectFromLoginPage(usuario, true);
        //            }
        //            catch (Exception ex)
        //            {
        //                string msg = ex.Message;
        //                //somehting went wrong
        //            }
        //        }
        //        else
        //        {
        //            e.User = null;
        //            Response.Redirect("~/Login.aspx");

        //        }
        //    }
        //}


    }
}