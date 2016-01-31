using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfaz_Contratos.Modulo4
{
    public interface IContratoAgregarHistorialM
    {
        /// <summary>
        /// Firma de Métodos que deben ser implementados en el 
        /// presentador del AgregarHistorialMatricula 
        /// </summary>
        string Fecha { get; }
        string Modalidad { get; }
        string Monto { get; }
        int Persona { get; }
    }
}
