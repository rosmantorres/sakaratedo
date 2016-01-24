using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;

namespace Interfaz_Contratos.Modulo11
{
    public interface IContratoListarResultadoCompetencia
    {
        Literal dataTable { set; }

        string alertaClase { set; }

        string alertaRol { set; }

        string alert { set; }
    }
}
