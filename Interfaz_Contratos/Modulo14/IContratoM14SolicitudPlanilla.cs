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
        String planillaId { get; set; }
        String fechaRetiroI { get; }
        String FechaReincorporacion { get; }
        DropDownList eventoCombo { get; set; }
        DropDownList competenciaCombo { get; set; }
        String Motivo { get; }
        String alertLocalRol { set; }
        String alertLocalClase { set; }
        String alertLocal { set; }
        bool alerta { set; }
        int IDUsuario { get; set; }
        bool ComboEventoVisible { get; set; }
        bool ComboCompetenciaVisible { get; set; }
        int IDPlanilla { get; set; }
        bool IDPlanillaVisible { get; set; }
        bool fechaRetiroVisible { get; set; }
        bool fechaReincorporacionVisible { get; set; }
        bool divComboEventoVisible { get; set; }
        bool labelEventoVisible { get; set; }
        bool divComboCompetenciaVisible { get; set; }
        bool labelCompetenciaVisible { get; set; }
        bool divMotivoVisible { get; set; }


    }
}
