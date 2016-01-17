using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;

namespace Interfaz_Contratos.Modulo14
{
    public interface IContratoM14RegistrarPlanilla
    {
        DropDownList tipoPlanillaCombo { get; set; }
        String tipoNombre { get;  }
        String planillaNombre { get; }
        ListBox datosPlanilla1 { get; set; }
        ListBox datosPlanilla2 { get; set; }
        String alertLocalRol { set; }
        String alertLocalClase { set; }
        String alertLocal { set; }
        bool alerta { set;  }
        bool id_otroTipo { set; }

    }
}
