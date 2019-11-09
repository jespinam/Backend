using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace restaurant.Conexion
{
    public class Db_Conexion
    {
        public static SqlConnection ConexionSQL()
        {
            SqlConnection ConnectionStrings = new SqlConnection(
                "Server=tcp:dwproyecto.database.windows.net,1433;Initial Catalog=Proyecto_DwRestaurante;Persist Security Info=False;User ID=jmespina;Password=Test12345.;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;"
                );

            return ConnectionStrings;
        }


        public static DataTable ReaderDatabase(string Query)
        {
            var ResultSet = new DataTable();

            var Connect = ConexionSQL();
            Connect.Open();

            var QueryCommand = new SqlCommand(Query, Connect);

            var Adapter = new SqlDataAdapter(QueryCommand);

            Adapter.Fill(ResultSet);

            Connect.Close();

            return ResultSet;

        }
    }

}
