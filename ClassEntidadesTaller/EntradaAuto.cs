using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassEntidadesTaller
{
    public class EntradaAuto
    {
        public int IdEntrada { get; set; }
        public int fkCliente { get; set; }
        public int fkAuto { get; set; }
        public DateTime fecha { get; set; }
        public string extra {  get; set; }
        public string falla { get; set; }  
    }
}
