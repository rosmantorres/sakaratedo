using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfaz_Contratos.Modulo12
{
    public interface IContratoDetalleCompetencia
    {
        string nombreComp { get; set; }
        string tipoComp { get; set; }
        string orgComp { get; set; }
        string statusComp { get; set; }
        string costoComp { get; set; }
        string inicioComp { get; set; }
        string finComp { get; set; }
        string latitudComp { get; set; }
        string longitudComp { get; set; }
        string categIniComp { get; set; }
        string categFinComp { get; set; }
        string edadIniComp { get; set; }
        string edadFinComp { get; set; }
        string categSexoComp { get; set; }
        string alertaClase { set; }
        string alertaRol { set; }
        string alerta { set; }

    }
}
