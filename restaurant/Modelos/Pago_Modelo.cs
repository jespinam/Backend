using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace restaurant.Modelos
{
    public class Pago_Modelo
    {
        public int pago_id              {get; set;}
        public string pago_modo         {get; set;}
        public float pago_total         {get; set;}
        public int pago_idpedido { get; set; }
    }
}
