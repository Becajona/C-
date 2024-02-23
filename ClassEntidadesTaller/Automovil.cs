using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassEntidadesTaller
{
    public class Automovil
    {
        public int IdAuto {  get; set; }
        public string modelo { get; set; }
        public int fkmarca { get; set; }
        public int año { get; set; }
        public string color { get; set; }
        public string placas { get; set; }
        public string estado { get; set; }
    }
}
