using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;

namespace Interfaz_Contratos.Modulo11
{
    public interface IContratoAgregarResultadoCompetencia
    {
        Calendar fecha { get; set; }

        DropDownList comboEvento { get; set; }

        DropDownList comboEspecialidad { get; set; }

        DropDownList comboCategoria { get; set; }

        Literal dataTable { get; set; }

        Literal dataTable2 { get; set; }

        Literal dataTable3 { get; set; }

        ListBox posiciones { set; }
        string alertaClase { set; }

        string alertaRol { set; }

        string alert { set; }
    }
}
