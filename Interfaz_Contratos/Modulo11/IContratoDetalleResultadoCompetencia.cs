using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;

namespace Interfaz_Contratos.Modulo11
{
    public interface IContratoDetalleResultadoCompetencia
    {
        TextBox fechaEvento { set; }

        TextBox nombreEvento { set; }

        TextBox especialidadEvento { set; }

        TextBox categoriaEvento { set; }

        Literal dataTable { set; }

        Literal dataTable2 { set; }

        Literal dataTable3 { set; }


    }
}
