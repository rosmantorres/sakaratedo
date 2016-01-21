using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;

namespace Interfaz_Contratos.Modulo10
{
   public interface IContratoListarAsistencia
    {

       Literal tabla { set; }
       string alertaClase { set; }
       string alertaRol { set; }
       string alert { set; }
    }
}
