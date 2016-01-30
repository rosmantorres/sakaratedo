using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;

namespace Interfaz_Contratos.Modulo11
{
    public interface IContratoDetalleResultadoCompetencia
    {
        TextBox FechaEvento { get;  set; }

        TextBox NombreEvento { get; set; }

        TextBox EspecialidadEvento { get; set; }

        TextBox CategoriaEvento { get; set; }

        Literal TablaAscenso { get; set; }

        Literal TablaKata { get; set; }

        Literal TablaKumite { get; set; }

        bool LEspecialidad { get; set; }
    }
}
