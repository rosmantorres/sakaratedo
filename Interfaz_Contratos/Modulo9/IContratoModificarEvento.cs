using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;

namespace Interfaz_Contratos.Modulo9
{
    interface IContratoModificarEvento
    {
        string nombreEvento { get; set; }
        DropDownList comboTipoEvento { get; set; }
        string otroEvento { get; set; }
        int costoEvento { get; set; }
        string fechaInicio { get; set; }
        string fechaFin { get; set; }
        string horaInicio { get; set; }
        string horaFin { get; set; }
        string descripcionEvento { get; set; }
        string statusActivo { get; set; }
        bool statusActivoBool { get; set; }
        string statusInactivo { get; set; }
        bool statusInactivoBool { get; set; }
        string alertaClase { set; }
        string alertaRol { set; }
        string alerta { set; }
    }
}
