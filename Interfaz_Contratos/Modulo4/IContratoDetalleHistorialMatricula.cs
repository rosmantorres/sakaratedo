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
        string fecha { set; }
        string modalidad { set; }
        string monto { set; }
        int idHM { get; }
    }
}
