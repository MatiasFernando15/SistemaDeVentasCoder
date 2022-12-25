using SistemaDeVentasCoder.Models;
using System.Data;
using System.Data.SqlClient;

namespace SistemaDeVentasCoder.ADO.NET
{
    public class LoginHandler
    {
        private SqlConnection conexion;
        private string CadenaConexion = "Server=sql.bsite.net\\MSSQL2016;" +
            "Database=matiasfernando15_SistemaDeVentasCoder;" +
            "User Id=matiasfernando15_SistemaDeVentasCoder;" +
            "Password=mustang66;";

        public LoginHandler()
        {
            try
            {
                conexion = new SqlConnection(CadenaConexion);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool LoginUsuario (Usuario usuario) 
        {
            if (conexion == null)
            {
                throw new Exception("Conexión no realizada");
            }
            try
            {
                using (SqlCommand cmd = new SqlCommand("SELECT * FROM usuario WHERE NombreUsuario = @NombreUsuario AND Contraseña = @Contraseña", conexion))
                {
                    conexion.Open();
                    cmd.Parameters.Add(new SqlParameter("NombreUsuario", SqlDbType.VarChar) { Value = usuario.NombreUsuario });
                    cmd.Parameters.Add(new SqlParameter("Contraseña", SqlDbType.VarChar) { Value = usuario.Contraseña });
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        return reader.HasRows;
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                conexion.Close();
            }
        }
    }
}
