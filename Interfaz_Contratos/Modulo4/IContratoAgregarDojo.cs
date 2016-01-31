using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfaz_Contratos.Modulo4
{
    public interface IContratoAgregarDojo
    {
        /// <summary>
        /// Firma de Métodos que deben ser implementados en el 
        /// presentador del AgregarDojo 
        /// </summary>
        string Logo { get; }
        string Rif { get; }
        string Nombre { get; }
        string Telefono { get; }
        string Email { get; }
        string Estado { get; }
        string Ciudad { get; }
        string Direccion { get; }
        bool StatusAct { get; }
        bool StatusIn { get; }
        int Persona { get; }
        string AlertaClase { set; }
        string AlertaRol { set; }
        string Alerta { set; }
    }
}
