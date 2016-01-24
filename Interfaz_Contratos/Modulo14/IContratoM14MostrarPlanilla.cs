using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;

namespace Interfaz_Contratos.Modulo14
{
    public interface IContratoM14MostrarPlanilla
    {
        Label NombrePanilla { set; }
        Label informacion { get; set; }
        string alertaClase { set; }
        string alertaRol { set; }
        string alert { set; }
    }
}
