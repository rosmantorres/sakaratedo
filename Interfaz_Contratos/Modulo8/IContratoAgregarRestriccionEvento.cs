using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Threading.Tasks;
using System.Web.UI.WebControls;

namespace Interfaz_Contratos.Modulo8
{
    public interface IContratoAgregarRestriccionEvento
    {
        DropDownList rangoMinimo { get; set; }
        DropDownList rangoMaximo { get; set; }
        DropDownList edadMinima { get; set; }
        DropDownList edadMaxima { get; set; }
        DropDownList sexo { get; set; }
        DropDownList eventos { get; set; }
    }
}
