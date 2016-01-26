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
        string fecha { get; }
        string modalidad { get; }
        string monto { get; }
        int persona { get; }
    }
}
