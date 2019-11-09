using restaurant.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using restaurant.Conexion;
using System.Data.SqlClient;


namespace restaurant.Negocios
{
    public class Cliente_Negocios
    {
        public static Cliente_Modelo LoguearClientes(string cliente_correo, string cliente_contrasena)
        {
            string Query = "EXECUTE loguearse_cliente '" + cliente_correo + "','" + cliente_contrasena + "';";
            var ResultSet = Db_Conexion.ReaderDatabase(Query);

            Cliente_Modelo InfClientesLgn = new Cliente_Modelo();
           InfClientesLgn.cliente_nombres      = ResultSet.Rows[1]["cliente_nombres"].ToString();
            InfClientesLgn.cliente_correo       = ResultSet.Rows[0]["cliente_correo"].ToString();
            InfClientesLgn.cliente_contrasena = ResultSet.Rows[0]["cliente_contrasena"].ToString();


            return InfClientesLgn;
        }
        public static bool Registrar(Cliente_Modelo c)
        {
            try
            {
             string Query = "EXECUTE registrarse_cliente '" + c.cliente_id + "','" + c.cliente_nombres + "','" + c.cliente_apellidos + "','" + c.cliente_correo + "','" + c.cliente_contrasena + "';" + c.cliente_telefono + "','";
                var ResultSet = Db_Conexion.ReaderDatabase(Query);
            }
            catch (Exception e)
            {
                e.Message.ToString();
            }
            return true;
        }





        public static List<Cliente_Modelo> Listaregistro()
        {

            var C = Db_Conexion.ConexionSQL();
            C.Open();
            var querito = new SqlCommand("execute registro;", C);
            SqlDataReader ResultSet = querito.ExecuteReader();
            List<Cliente_Modelo> rcliente = new List<Cliente_Modelo>();
            while (ResultSet.Read())
            {
                Cliente_Modelo m = new Cliente_Modelo();
                m.cliente_id = int.Parse(ResultSet["cliente_id"].ToString());
                m.cliente_nombres = ResultSet["cliente_nombres"].ToString();
                m.cliente_apellidos = ResultSet["cliente_apellidos"].ToString();
                m.cliente_correo = ResultSet["cliente_correo"].ToString();
                m.cliente_contrasena = ResultSet["cliente_contrasena"].ToString();
                m.cliente_telefono = int.Parse(ResultSet["cliente_telefono"].ToString());
                rcliente.Add(m);
            }
            C.Close();
            return rcliente;
        }

    }
}
