using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfaz_Contratos.Modulo9
{
    public interface IContratoDetalleEvento
    {
        string iNombreEvento { set; }
        string iTipoEvento { set; }
        string iCostoEvento { set; }
        string iFechaInicio { set; }
        string iFechaFin { set; }
        string iHoraInicio { set; }
        string iHoraFin { set; }
        string iDescripcionEvento { set; }
        string iStatusEvento { set; }
        string alertaClase { set; }
        string alertaRol { set; }
        string alerta { set; }
    }
}
