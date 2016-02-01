using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;

namespace Interfaz_Contratos.Modulo8
{
    public interface IContratoConsultarRestriccionCompetencia
    {
        string restriccionCompetencia { get; set; }
        string alertaClase { set; }
        string alertaRol { set; }
        string alerta { set; }

    }
}
