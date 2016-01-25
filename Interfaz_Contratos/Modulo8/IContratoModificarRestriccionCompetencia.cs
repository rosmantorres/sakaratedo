using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Threading.Tasks;
using DominioSKD.Entidades.Modulo12;
using System.Web.UI.WebControls;

namespace Interfaz_Contratos.Modulo8
{
    public interface IContratoModificarRestriccionCompetencia
    {

        String id { get; set; }
        String descripcion { get; set; }
        //ListBox competenciasRelacionadas { get; set; }
        //ListBox competeciasNoRelacionadas { get; set; }
        DropDownList rangoMinimo { get; set; }
        DropDownList rangoMaximo { get; set; }
        DropDownList edadMinima { get; set; }
        DropDownList edadMaxima { get; set; }
        DropDownList sexo { get; set; }
        DropDownList modalidad { get; set; }
        //String alert { set; }
        //String alertClase { set; }
        //String alertRol { set; }

        //List<Competencia> competenciasRelacionadas { get; set; }
        //List<Competencia> competenciasNoRelacionadas { get; set; }
        //String rangoMinimo { get; set; }
        //String rangoMaximo { get; set; }
        //String edadMinima { get; set; }
        //String edadMaxima { get; set; }
        //String sexo { get; set; }
        //String modalidad { get; set; }

    }
}
