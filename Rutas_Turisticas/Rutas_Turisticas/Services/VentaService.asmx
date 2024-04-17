using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Services;
using Rutas_Turisticas.BusinessLogic;

namespace Rutas_Turisticas.Services
{
 /// <summary>
    /// Summary description for VentaService
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line.
    // [System.Web.Script.Services.ScriptService]
    public class VentaService : System.Web.Services.WebService
    {
        [WebMethod]
        public void RegistrarVenta(int idCliente, string rutaTuristica, int cantidadPersonas, decimal importeTotal)
        {
            // Aquí puedes llamar a la capa de lógica de negocio para registrar la venta
            VentaManager ventaManager = new VentaManager();
            ventaManager.RegistrarVenta(idCliente, rutaTuristica, cantidadPersonas, importeTotal);
        }

        [WebMethod]
        public string ConsultarClientes()
        {
            // Aquí puedes llamar a la capa de lógica de negocio para consultar clientes
            // Por ahora, simplemente devolveremos un mensaje de ejemplo
            return "Lista de clientes consultada correctamente.";
        }
    }
}
