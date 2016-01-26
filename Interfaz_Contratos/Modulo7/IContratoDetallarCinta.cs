using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfaz_Contratos.Modulo7
{
    /// <summary>
    /// Contrato para detallar cinta
    /// </summary>
    public interface IContratoDetallarCinta
    {
        string colorCinta { get; set; }
        string rangoCinta { get; set; }
        string clasificacionCinta { get; set; }
        string significadoCinta { get; set; }
        string ordenCinta { get; set; }
        string fechaObtencionCinta { get; set; }
    }
}
