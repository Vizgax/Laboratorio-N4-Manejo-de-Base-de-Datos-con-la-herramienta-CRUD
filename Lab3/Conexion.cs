using Microsoft.Data.SqlClient;

namespace Lab3
{
    public class Conexion
    {
        // Cambia únicamente esta cadena si tu instancia de SQL Server es diferente.
        // Ejemplos:
        // Server=.\SQLEXPRESS;Database=productosdb;Trusted_Connection=True;TrustServerCertificate=True;
        // Server=(localdb)\MSSQLLocalDB;Database=productosdb;Trusted_Connection=True;TrustServerCertificate=True;
        public const string CadenaConexion =
            @"Server=.\SQLEXPRESS;Database=productosdb;Trusted_Connection=True;TrustServerCertificate=True;";

        // Variables que serán utilizadas por el formulario.
        public SqlConnection ConexionBD { get; private set; }

        public Conexion()
        {
            ConexionBD = new SqlConnection(CadenaConexion);
        }

        public void Abrir()
        {
            if (ConexionBD.State == System.Data.ConnectionState.Closed)
                ConexionBD.Open();
        }

        public void Cerrar()
        {
            if (ConexionBD.State != System.Data.ConnectionState.Closed)
                ConexionBD.Close();
        }
    }
}
