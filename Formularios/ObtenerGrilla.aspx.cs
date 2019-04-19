using System;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Security;
using Newtonsoft.Json;

namespace Album.Formularios
{
    public partial class ObtenerGrilla : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Respuesta respuesta = new Respuesta();
            StringBuilder sb = new StringBuilder();
            string stickers = "";
            string seleccionado = "";

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
                        string idUsuario = FormsAuthentication.Decrypt(Request.Cookies[FormsAuthentication.FormsCookieName].Value).Name;
                        
                        stickers = Procedimientos.ObtenerStickers(int.Parse(idUsuario), out string mensajeError);

                        respuesta.Codigo = "0";
                        respuesta.Mensaje = "";

                        if (mensajeError != "ok")
                        {
                            respuesta.Mensaje = "Error obteniendo stickers";
                        }

                        sb.Append("<table class='grillaPrincipal'>");

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

                            string id = "td_" + i;

                            if (!string.IsNullOrEmpty(stickers) && mensajeError == "ok")
                            {
                                string[] lista = stickers.Split(',');
                                seleccionado = lista.Contains(id) ? "class='seleccionado'" : string.Empty;
                            }

                            sb.Append("<td " + seleccionado + " id='" + id + "' onclick=\"SeleccionarSticker('" + id + "')\">");
                            sb.Append(i.ToString().PadLeft(2, '0'));
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
                respuesta.Codigo = "-1";
                respuesta.Mensaje = "Error inesperado: " + ex.Message;
            }
            finally
            {
                Response.Write(JsonConvert.SerializeObject(respuesta));
            }




        }
    }
}