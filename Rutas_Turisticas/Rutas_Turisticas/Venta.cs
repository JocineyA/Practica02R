using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rutas_Turisticas
{
    public class Venta
    {
        public int ID { get; set; }
        public int ID_Cliente { get; set; }
        public string RutaTuristica { get; set; }
        public int CantidadPersonas { get; set; }
        public decimal ImporteTotal { get; set; }
    }

}
