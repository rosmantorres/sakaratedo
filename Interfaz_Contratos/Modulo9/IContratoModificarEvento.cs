using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;

namespace Interfaz_Contratos.Modulo9
{
    public interface IContratoModificarEvento
    {
        DropDownList iComboTipoEvento { get; set; }
        string iNombreEvento { get; set; }
        string iCostoEvento { get; set; }
        string iFechaInicio { get; set; }
        string iFechaFin { get; set; }
        string iHoraInicio { get; set; }
        string iHoraFin { get; set; }
        string iDescripcionEvento { get; set; }
        bool iStatusActivoBool { get; set; }
        bool iStatusInactivoBool { get; set; }
        string alertaClase { set; }
        string alertaRol { set; }
        string alerta { set; }
    }
}
