using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfaz_Contratos.Modulo4
{
    public interface IContratoModificarDojo
    {
        /// <summary>
        /// Firma de Métodos que deben ser implementados en el 
        /// presentador del ModificarDojo 
        /// </summary>
        int IdDojo { get; set; }
        string Imglogo { set; }
        string Logo { get; set; }
        string Rif { get; set; }
        string Nombre { get; set; }
        string Telefono { get; set; }
        string Email { get; set; }
        string Estado { get; set; }
        string Ciudad { get; set; }
        string Direccion { get; set; }
        bool StatusAct { get; set; }
        bool StatusIn { get; set; }
    }
}
