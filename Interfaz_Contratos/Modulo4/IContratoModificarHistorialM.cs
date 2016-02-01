using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfaz_Contratos.Modulo4
{
    public interface IContratoModificarHistorialM
    {
        /// <summary>
        /// Firma de Métodos que deben ser implementados en el 
        /// presentador del ModificarHistorialMatricula 
        /// </summary>
        string Fecha { get; set; }
        string Modalidad { get; set; }
        string Monto { get; set; }
        int Persona { get; }
        int IdHistM { get; set; }
        string AlertaClase { set; }
        string AlertaRol { set; }
        string Alerta { set; }
    }
}
