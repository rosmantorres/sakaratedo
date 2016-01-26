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
        DropDownList iComboTipoEvento { get; set; }
        string iNombreEvento { get; }
        string iCostoEvento { get; }
        string iFechaInicio { get; }
        string iFechaFin { get; }
        string iHoraInicio { get; }
        string iHoraFin { get; }
        string iDescripcionEvento { get; }
        string iStatusActivo { get; }
        bool iStatusActivoBool { get; }
        string iStatusInactivo { get; }
        bool iStatusInactivoBool { get; }
        string alertaClase { set; }
        string alertaRol { set; }
        string alerta { set; }
    }
}
