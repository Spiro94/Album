using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Album.Formularios
{
    public partial class GuardarAlbum : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Respuesta respuesta = new Respuesta();

            try
            {
                string stickers = Request["stickers"];

                string method = HttpContext.Current.Request.HttpMethod;

                string requestedWith = HttpContext.Current.Request.Headers["X-Requested-With"];

                if (method == "POST" && requestedWith == "XMLHttpRequest")
                {

                    if (!string.IsNullOrEmpty(stickers))
                    {
                        SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConexionAlbum"].ConnectionString);
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