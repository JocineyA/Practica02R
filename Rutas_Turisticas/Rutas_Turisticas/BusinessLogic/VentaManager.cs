using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rutas_Turisticas.BusinessLogic
{
   public class VentaManager
    {
        public void RegistrarVenta(int idCliente, string rutaTuristica, int cantidadPersonas, decimal importeTotal)
        {
        }


        public decimal CalcularDescuentoPorCantidad(int cantidadPersonas)
        {
            decimal descuento = 0;

            if (cantidadPersonas >= 1 && cantidadPersonas <= 7)
            {
                descuento = 0;
            }
            else if (cantidadPersonas >= 8 && cantidadPersonas <= 16)
            {
                descuento = 0.08m; // 8%
            }
            else if (cantidadPersonas >= 17)
            {
                descuento = 0.15m; // 15%
            }

            return descuento;
        }

        public decimal CalcularDescuentoPorTipoCliente(string tipoCliente)
        {
            decimal descuento = 0;
            switch (tipoCliente)
            {
                case "Promoción de colegios":
                    descuento = 0.07m; // 7%
                    break;
                case "Adultos mayores de 60 años":
                    descuento = 0.05m; // 5%
                    break;
                default:
                    descuento = 0;
                    break;
            }

            return descuento;
        }
    }
}
