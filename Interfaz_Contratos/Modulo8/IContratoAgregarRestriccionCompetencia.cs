using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Threading.Tasks;
//using System.Web.UI.WebControls;
using DominioSKD.Entidades.Modulo12;

namespace Interfaz_Contratos.Modulo8
{
    public interface IContratoAgregarRestriccionCompetencia
    {
        String id { get; set; }
        String descripcion { get; set; }
        List<Competencia> competenciasRelacionadas { get; set; }
        List<Competencia> competenciasNoRelacionadas { get; set; }
        String rangoMinimo { get; set; }
        String rangoMaximo { get; set; }
        String edadMinima { get; set; }
        String edadMaxima { get; set; }
        String sexo { get; set; }
        String modalidad { get; set; }
    }
}