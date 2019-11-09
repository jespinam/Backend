using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace restaurant.Modelos
{


    public class Cliente_Modelo
    {
        
        public int      cliente_id              {get; set;}
        public string   cliente_nombres         {get; set;}
        public string   cliente_apellidos       {get; set;}
        public string   cliente_correo          {get; set;}
        public string   cliente_contrasena      {get; set;}
        public int cliente_telefono          { get; set; }
    }
}
