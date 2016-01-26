using System;
using System.Collections.Generic;
using System.Linq;
using System.Text; 
using System.Threading.Tasks;
using System.Web.UI.WebControls;

namespace Interfaz_Contratos.Modulo4
{
    public interface IContratoModificarDojo
    {
        /// <summary>
        /// Firma de Métodos que deben ser implementados en el 
        /// presentador del ModificarDojo 
        /// </summary>
        int idDojo { get; set; }
        string imglogo { set; }
        string logo { get; set; }
        string rif { get; set; }
        string nombre { get; set; }
        string telefono { get; set; }
        string email { get; set; }
        string estado { get; set; }
        string ciudad { get; set; }
        string direccion { get; set; }
        bool statusAct { get; set; }
        bool statusIn { get; set; }
    }
}
