using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using restaurant.Modelos;
using restaurant.Negocios;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;


namespace restaurant.Controllers
{


    [Route("api/[controller]")]
    [ApiController]
    public class Cliente :Controller
    {
        [HttpGet("ClienteLogin")]
        public JsonResult LoguearClientes(string cliente_correo, string cliente_contrasena)
        {
            Cliente_Modelo InfClientesLgn = new Cliente_Modelo();
            InfClientesLgn = Cliente_Negocios.LoguearClientes(cliente_correo, cliente_contrasena);
            return Json(InfClientesLgn);
        }
      




        [HttpPost("Registrar")]
        public JsonResult RegistrarCliente(Cliente_Modelo regisCliente)
        {
            Cliente_Negocios.Registrar(regisCliente);
            return Json(regisCliente);
        }


        [HttpGet("registro")]
        public JsonResult Registro()
        {
            List<Cliente_Modelo> m = new List<Cliente_Modelo>();
            m = Cliente_Negocios.Listaregistro();
            return Json(m);
        }




    }
}
