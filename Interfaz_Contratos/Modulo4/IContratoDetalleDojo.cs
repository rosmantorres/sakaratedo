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
        string Logo { set; }
        string Rif { set; }
        string Nombre { set; }
        string Telefono { set; }
        string Email { set; }
        string StatusAct { set; }
        string StatusIn { set; }
        string NombreOrg { set; }
        string Estilo { set; }
        string AlertaClase { set; }
        string AlertaRol { set; }
        string Alerta { set; }
    }
}
