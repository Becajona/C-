using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassEntidadesTaller
{
    public class Cliente
    {
        public int IdCliente { get; set; }
        public string Nombre { get; set; }
        public string App { get; set;}
        public string Apm { get; set;}
        public string Celular { get; set;}
        public string TelOficina { get; set;}
        public string CorreoPer { get; set; }
        public string CorreoCorp { get; set;}

        public override string ToString()=>
            $" {Nombre,-20} {App,-22} {Apm,-22} {Celular,-15} {TelOficina,-15} {CorreoPer,-30} {CorreoCorp,-30}";
      
    }
}
