using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;

namespace Interfaz_Contratos.Modulo10
{
    public interface IContratoAgregarAsistencia
    {
        Calendar calendario { get; set; }

        DropDownList comboEvento { get; set; }

        ListBox inscritos { get; set; }

        ListBox asistentes { get; set; }

        Literal ausentesPlanilla { get;  set; }
    }
}
