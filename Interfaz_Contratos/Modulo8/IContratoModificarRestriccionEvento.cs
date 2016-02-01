using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Threading.Tasks;
using System.Web.UI.WebControls;

namespace Interfaz_Contratos.Modulo8
{
    public interface IContratoModificarRestriccionEvento
    {
        DropDownList rangoMinimo { get; set; }
        DropDownList rangoMaximo { get; set; }
        DropDownList edadMinima { get; set; }
        DropDownList edadMaxima { get; set; }
        DropDownList sexo { get; set; }
        string evento { get; set; }
        string alertaClase { set; }
        string alertaRol { set; }
        string alerta { set; }
        Label myLabel { get;  set; }
    }
}
