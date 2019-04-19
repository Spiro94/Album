using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Security;
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
                string mensajeError = "";
                string stickers = Request["stickers"];

                string method = HttpContext.Current.Request.HttpMethod;

                string requestedWith = HttpContext.Current.Request.Headers["X-Requested-With"];

                if (method == "POST" && requestedWith == "XMLHttpRequest")
                {
                    string usuario = FormsAuthentication.Decrypt(Request.Cookies[FormsAuthentication.FormsCookieName].Value).Name;

                    using (SqlConnection conexion = new SqlConnection(ConfigurationManager.ConnectionStrings["ConexionAlbum"].ConnectionString))
                    {
                        conexion.Open();

                        SqlCommand cmd = new SqlCommand
                        {
                            Connection = conexion
                        };

                        cmd.Parameters.Add("@in_id_usuario", SqlDbType.Int).Value = 1;
                        cmd.Parameters.Add("@in_stickers", SqlDbType.VarChar).Value = stickers;

                        cmd.Parameters.Add("@out_mensaje", SqlDbType.VarChar, 500).Direction = ParameterDirection.Output;

                        cmd.CommandText = "dbo.SP_GUARDAR_STICKERS";
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.ExecuteNonQuery();

                        mensajeError = cmd.Parameters["@out_mensaje"].Value.ToString();
                    }

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