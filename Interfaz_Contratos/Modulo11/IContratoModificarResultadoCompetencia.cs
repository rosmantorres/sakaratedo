using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;

namespace Interfaz_Contratos.Modulo11
{
    public interface IContratoModificarResultadoCompetencia
    {
        TextBox fechaEvento { set; }

        TextBox nombreEvento { set; }

        DropDownList comboEspecialidad { get; set; }

        DropDownList comboCategoria { get; set; }

        Literal dataTable { get; set; }

        Literal dataTable1 { get; set; }

        Literal dataTable2 { get; set; }

    }
}
