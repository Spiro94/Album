using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Album
{
    public static class Procedimientos
    {
        public static string GuardarAlbum(int idUsuario, string stickers)
        {
            string salida = "";

            try
            {
                using (SqlConnection conexion = new SqlConnection(ConfigurationManager.ConnectionStrings["ConexionAlbum"].ConnectionString))
                {
                    conexion.Open();

                    SqlCommand cmd = new SqlCommand
                    {
                        Connection = conexion
                    };

                    cmd.Parameters.Add("@in_id_usuario", SqlDbType.Int).Value = idUsuario;
                    cmd.Parameters.Add("@in_stickers", SqlDbType.VarChar).Value = stickers;

                    cmd.Parameters.Add("@out_mensaje", SqlDbType.VarChar, 500).Direction = ParameterDirection.Output;

                    cmd.CommandText = "dbo.SP_GUARDAR_STICKERS";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.ExecuteNonQuery();

                    salida = cmd.Parameters["@out_mensaje"].Value.ToString();
                }
            }
            catch (Exception ex)
            {
                salida = "Error inesperado: " + ex.Message;
            }

            return salida;
        }


        public static string ObtenerStickers(int idUsuario, out string mensajeError)
        {
            string salida = "";
            mensajeError = "ok";

            try
            {
                using (SqlConnection conexion = new SqlConnection(ConfigurationManager.ConnectionStrings["ConexionAlbum"].ConnectionString))
                {
                    conexion.Open();

                    SqlCommand cmd = new SqlCommand
                    {
                        Connection = conexion
                    };

                    cmd.Parameters.Add("@in_id_usuario", SqlDbType.Int).Value = idUsuario;

                    cmd.Parameters.Add("@out_stickers", SqlDbType.VarChar, 500).Direction = ParameterDirection.Output;

                    cmd.CommandText = "dbo.SP_OBTENER_STICKERS";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.ExecuteNonQuery();

                    salida = cmd.Parameters["@out_stickers"].Value.ToString();
                }
            }
            catch (Exception ex)
            {
                mensajeError = "Error inesperado: " + ex.Message;
            }

            return salida;
        }


        public static string ValidarUsuario(string usuario, string clave, out string idUsuario)
        {
            string salida = "";
            idUsuario = "";

            try
            {
                using (SqlConnection conexion = new SqlConnection(ConfigurationManager.ConnectionStrings["ConexionAlbum"].ConnectionString))
                {
                    conexion.Open();

                    SqlCommand cmd = new SqlCommand
                    {
                        Connection = conexion
                    };

                    cmd.Parameters.Add("@in_nombre_usuario", SqlDbType.VarChar).Value = usuario;
                    cmd.Parameters.Add("@in_clave_usuario", SqlDbType.VarChar).Value = clave;

                    cmd.Parameters.Add("@out_id_usuario", SqlDbType.Int, 500).Direction = ParameterDirection.Output;

                    cmd.CommandText = "dbo.SP_OBTENER_USUARIO";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.ExecuteNonQuery();

                    string usu = cmd.Parameters["@out_id_usuario"].Value.ToString();

                    if (string.IsNullOrEmpty(usu))
                    {
                        salida = "Usuario o contraseña erróneos";
                    }
                    else
                    {
                        salida = "ok";
                        idUsuario = usu;
                    }
                }
            }
            catch (Exception ex)
            {
                salida = "Error inesperado: " + ex.Message;
            }

            return salida;
        }
    }
}