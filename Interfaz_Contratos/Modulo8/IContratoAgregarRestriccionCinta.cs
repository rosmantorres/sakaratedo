using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Threading.Tasks;
using System.Web.UI.WebControls;
//using DominioSKD.Entidades.Modulo5;

namespace Interfaz_Contratos.Modulo8
{
    public interface IContratoAgregarRestriccionCinta
    {
        String id_rest_cinta { get; set; }
        String descripcion_rest_cinta { get; set; }
        String tiempo_Min { get; set; }
        String tiempo_Max { get; set; }
        String horas_docen { get; set; }
        String puntaje_min { get; set; }
        DropDownList comboRestCinta { get; }
        //List<Cinta> cintasRelacionadas { get; set; }
    }
}
