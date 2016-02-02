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
    public interface IContratoModificarRestriccionCinta
    {
        string id_restriccion { get; set; }
        string tiempo_Min { get; set; }
        string horas_docen { get; set; }
        string puntaje_min { get; set; }
        string alertaClase { set; }
        string alertaRol { set; }
        string alerta { set; }
    }
}
