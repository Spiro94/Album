using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using Newtonsoft.Json;

namespace Album
{
    public partial class ObtenerGrilla : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Respuesta respuesta = new Respuesta();
            StringBuilder sb = new StringBuilder();

            try
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

                        sb.Append("<table class='grillaPrincipal'>");
                        sb.Append("<caption>Album</caption>");

                        int bandera = 0;
                        int inicio = 1;

                        for (int i = 1; i <= 250; i++)
                        {
                            if (bandera == 1)
                            {
                                sb.Append("</tr>");
                                sb.Append("<tr>");
                                bandera = 0;
                            }

                            if (inicio == 1)
                            {
                                sb.Append("<tr>");
                                inicio = 0;
                            }

                            sb.Append("<td>");
                            sb.Append("<div>");
                            sb.Append(i.ToString().PadLeft(2, '0'));
                            sb.Append("</div>");                            
                            sb.Append("</td>");

                            if (i % 10 == 0 && i != 250)
                            {
                                bandera = 1;
                            }

                            if (i == 250)
                            {
                                sb.Append("</tr>");
                            }
                        }

                        sb.Append("</table>");

                        respuesta.Datos = sb.ToString();

                    }
                }
                else
                {

                }
            }
            catch (Exception ex)
            {

            }
            finally
            {
                Response.Write(JsonConvert.SerializeObject(respuesta));
            }




        }
    }
}