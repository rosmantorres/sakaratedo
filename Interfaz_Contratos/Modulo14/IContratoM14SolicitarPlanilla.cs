using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;

namespace Interfaz_Contratos.Modulo14
{
    public interface IContratoM14SolicitarPlanilla
    {
        String tablaSolicitarP { get; set; }
        String alertLocalRol { set; }
        String alertLocalClase { set; }
        String alertLocal { set; }
        bool alerta { set; }
    }
}
