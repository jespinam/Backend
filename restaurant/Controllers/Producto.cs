using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using restaurant.Modelos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using restaurant.Negocios;
namespace restaurant.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class Producto: Controller
    {
        [HttpGet("ProductsCateg")]
        public JsonResult getProdCat(string tipo)
        {
            Producto_Modelo InfProdcat = new Producto_Modelo();
            InfProdcat = Producto_Negocios.GetProdCategories(tipo);
            return Json(InfProdcat);
        }
        [HttpGet("productos")]
        public JsonResult Productos()
        {
            List<Producto_Modelo> p = new List<Producto_Modelo>();
            p = Producto_Negocios.Listaproductos();
            return Json(p);
        }




    }
}
