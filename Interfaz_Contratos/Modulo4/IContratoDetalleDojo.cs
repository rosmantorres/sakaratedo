using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfaz_Contratos.Modulo4
{
    public interface IContratoDetalleDojo
    {
        /// <summary>
        /// Firma de Métodos que deben ser implementados en el 
        /// presentador del DetallarDojo 
        /// </summary>
        string logo { set; }
        string rif { set; }
        string nombre { set; }
        string telefono { set; }
        string email { set; }
        string statusAct { set; }
        string statusIn { set; }
        string nombreOrg { set; }
        string estilo { set; }
    }
}
