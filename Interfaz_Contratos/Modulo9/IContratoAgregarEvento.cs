using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;

namespace Interfaz_Contratos.Modulo9
{
    public interface IContratoAgregarEvento
    {
        string nombreEvento { get; }
        DropDownList comboTipoEvento { get; set; }
        string otroEvento { get; }
        string costoEvento { get; }
        string fechaInicio { get; }
        string fechaFin { get; }
        string horaInicio { get; }
        string horaFin { get; }
        string descripcionEvento { get; }
        string statusActivo { get; }
        bool statusActivoBool { get; }
        string statusInactivo { get; }
        bool statusInactivoBool { get; }
        string alertaClase { set; }
        string alertaRol { set; }
        string alerta { set; }
    }
}
