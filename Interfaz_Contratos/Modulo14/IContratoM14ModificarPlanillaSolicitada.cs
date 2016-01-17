using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;

namespace Interfaz_Contratos.Modulo14
{
   public interface IContratoM14ModificarPlanillaSolicitada
    {
       int IDInscripcion { get; set; }
       String solicitudId { get; set; }
       String FechaRetiro { get; set; }
       String FechaReincorporacion { get; set; }
       DropDownList EventoCombo { get; set; }
       DropDownList CompetenciaCombo { get; set; }
       String Motivo { get; set; }
       String alertLocalRol { set; }
       String alertLocalClase { set; }
       String alertLocal { set; }
       bool alerta { set; }
       int IDUsuario { get; set; }
       bool ComboEventoVisible { get; set; }
       bool ComboCompetenciaVisible { get; set; }
       int IDSolicitud { get; set; }
       bool IDSolicitudVisible { get; set; }
       bool fechaRetiroVisible { get; set; }
       bool fechaReincorporacionVisible { get; set; }
       bool divComboEventoVisible { get; set; }
       bool labelEventoVisible { get; set; }
       bool divComboCompetenciaVisible { get; set; }
       bool labelCompetenciaVisible { get; set; }
       bool divMotivoVisible { get; set; }
    }
}
