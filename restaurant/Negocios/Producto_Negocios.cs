using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using restaurant.Conexion;
using restaurant.Modelos;

namespace restaurant.Negocios
{
    public class Producto_Negocios
    {

        public static Producto_Modelo GetProdCategories(string tipo)
        {
            string Query = "EXECUTE obtener_producto_tipo '" + tipo + "';";
            var ResulSet = Db_Conexion.ReaderDatabase(Query);
            Producto_Modelo infProCateg = new Producto_Modelo();
          infProCateg.producto_nombre = ResulSet.Rows[0]["producto_nombre"].ToString();
            infProCateg.producto_Descripcion = ResulSet.Rows[0]["producto_Descripcion"].ToString();
            infProCateg.producto_precio = float.Parse(ResulSet.Rows[0]["producto_precio"].ToString());
            infProCateg.producto_idmenu = int.Parse(ResulSet.Rows[0]["producto_idmenu"].ToString());
            return infProCateg;
        }



        public static List<Producto_Modelo> Listaproductos()
        {

            var C = Db_Conexion.ConexionSQL();
            C.Open();
            var querito = new SqlCommand("execute productos;", C);
            SqlDataReader ResultSet = querito.ExecuteReader();
            List<Producto_Modelo> rproducts = new List<Producto_Modelo>();
            while (ResultSet.Read())
            {
                Producto_Modelo p = new Producto_Modelo();
                p.producto_id = int.Parse(ResultSet["producto_id"].ToString());
                p.producto_idmenu = int.Parse(ResultSet["producto_idmenu"].ToString());
                p.producto_nombre = ResultSet["producto_nombre"].ToString();
                p.producto_Descripcion = ResultSet["producto_Descripcion"].ToString();
                p.producto_precio = float.Parse(ResultSet["producto_precio"].ToString());
                rproducts.Add(p);
            }
            C.Close();
            return rproducts;

        }

    }
}
