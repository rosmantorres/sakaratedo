using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;

namespace Interfaz_Contratos.Modulo14
{
   public interface IContratoM14ModificarPlanillaCreada
    {
       String planillaId { get; set; }
       DropDownList tipoPlanillaCombo { get; set; }
       String nombreTipo { get; set; }
       String nombrePlanilla { get; set; }
       ListBox datosPlanilla1 { get; set; }
       ListBox datosPlanilla2 { get; set; }
       String alertLocalRol { set; }
       String alertLocalClase { set; }
       String alertLocal { set; }
       bool alerta { set; }
       bool id_otroTipo { set; }
       int IDPlanillaModificar { get;}
       bool IDPlanillaModificarVisible { set; }





    }
}
