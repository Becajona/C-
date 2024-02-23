using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1
{
    public class Perro
    {
        public string Apodo { get; set; }
        public string Raza { get; set; }

        public string Corretea(string Animal)
        {
            string dato;
            dato = "atrapado" + Animal;
            return dato;
        }
    }
}