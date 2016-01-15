using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;

namespace Interfaz_Contratos.Modulo14
{
    public interface IContratoM14SolicitudPlanilla
    {
        String planillaId { get; }
        String fechaRetiro { get; }
        String fechaReincorporacion { get; }
        DropDownList eventoCombo { get; set; }
        DropDownList competenciaCombo { get; set; }
        String motivo { get; }

    }
}
