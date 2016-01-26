using System;
using System.Collections.Generic;
using System.Linq;
using System.Text; 
using System.Threading.Tasks;
using System.Web.UI.WebControls;

namespace Interfaz_Contratos.Modulo4
{
    public interface IContratoAgregarDojo
    {
        /// <summary>
        /// Firma de Métodos que deben ser implementados en el 
        /// presentador del AgregarDojo 
        /// </summary>
        string logo { get; }
        string rif { get; }
        string nombre { get; }
        string telefono { get; }
        string email { get; }
        string estado { get; }
        string ciudad { get; }
        string direccion { get; }
        bool statusAct { get; }
        bool statusIn { get; }
        int persona { get; }
    }
}
