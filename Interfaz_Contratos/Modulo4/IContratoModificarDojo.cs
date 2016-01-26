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
        string imglogo { set; }
        string fecha { get; set; }
        string modalidad { get; set; }
        string monto { get; set; }
        int idHM { get; set; }
    }
}
