using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;

namespace Interfaz_Contratos.Modulo11
{
    public interface IContratoAgregarResultadoCompetencia
    {
        Calendar Fecha { get; set; }

        DropDownList ComboEvento { get; set; }

        DropDownList ComboEspecialidad { get; set; }

        DropDownList ComboCategoria { get; set; }

        Literal TablaAscenso { get; set; }

        Literal TablaKata { get; set; }

        Literal TablaKumite { get; set; }

        ListBox Posiciones { get; set; }

        string alertaClase { set; }

        string alertaRol { set; }

        string alerta { set; }

        LinkButton Boton { get; set; }

        LinkButton BotonKata { get; set; }

        LinkButton BotonKumite { get; set; }

        LinkButton BotonAmbos { get; set; }

        LinkButton BotonSiguiente { get; set; }

        LinkButton BotonSiguienteAmbos { get; set; }

        bool LEspecialidad { get; set; }

        bool LPosicion { get; set; }
    }
}
