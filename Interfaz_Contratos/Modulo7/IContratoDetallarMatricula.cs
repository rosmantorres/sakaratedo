using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfaz_Contratos.Modulo7
{
    /// <summary>
    /// Contrato para detallar Matricula
    /// </summary>
    public interface IContratoDetallarMatricula
    {
        string identificadorMatricula { get; set; }
        string fechaCreacionMatricula { get; set; }
        string fechaPagoMatricula { get; set; }
        string estadoMatricula { get; set; }
    }
}
