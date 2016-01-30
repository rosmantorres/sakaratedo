using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;

namespace Interfaz_Contratos.Modulo11
{
    public interface IContratoModificarResultadoCompetencia
    {
        TextBox Fecha { get;  set; }

        TextBox Nombre { get;  set; }

        DropDownList ComboEspecialidad { get; set; }

        DropDownList ComboCategoria { get; set; }

        Literal TablaAscenso { get; set; }

        Literal TablaKata { get; set; }

        Literal TablaKumite { get; set; }

        bool LEspecialidad { get; set; }

        LinkButton Boton { get; set; }

        LinkButton BotonKata { get; set; }

        LinkButton BotonKumite { get; set; }

        LinkButton BotonAmbos { get; set; }

        HiddenField Resultado1 { get; set; }

        HiddenField Resultado2 { get; set; }
    }
}
