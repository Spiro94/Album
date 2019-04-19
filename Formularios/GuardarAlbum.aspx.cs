using Newtonsoft.Json;
using System;
using System.Web;
using System.Web.Security;

namespace Album.Formularios
{
    public partial class GuardarAlbum : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Respuesta respuesta = new Respuesta();

            try
            {
                string mensajeError = "";
                string stickers = Request["stickers"];

                string method = HttpContext.Current.Request.HttpMethod;

                string requestedWith = HttpContext.Current.Request.Headers["X-Requested-With"];

                if (method == "POST" && requestedWith == "XMLHttpRequest")
                {
                    string idUsuario = FormsAuthentication.Decrypt(Request.Cookies[FormsAuthentication.FormsCookieName].Value).Name;

                    mensajeError = Procedimientos.GuardarAlbum(int.Parse(idUsuario), stickers);

                    if (mensajeError == "ok")
                    {
                        respuesta.Codigo = "0";
                        respuesta.Mensaje = "Cambios guardados exitosamente";
                    }
                    else
                    {
                        respuesta.Codigo = "-1";
                        respuesta.Mensaje = "Error guardando los cambios: " + mensajeError;
                    }
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