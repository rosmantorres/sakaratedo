using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfaz_Contratos.Modulo9
{
    interface IContratoDetalleEvento
    {
        string nombreEvento { set; }
        string tipoEvento { set; }
        string costoEvento { set; }
        string fechaInicio { set; }
        string fechaFin { set; }
        string inicioComp { set; }
        string horaInicio { set; }
        string horaFin { set; }
        string descripcionEvento { set; }
        string statusEvento { set; }
        string alertaClase { set; }
        string alertaRol { set; }
        string alerta { set; }
    }
}
