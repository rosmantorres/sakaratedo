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
        string tiempo_Min { get; set; }
        string horas_docen { get; set; }
        string puntaje_min { get; set; }
        String alertLocalRol { set; }
        String alertLocalClase { set; }
        String alertLocal { set; }
        bool alerta { set; }
    }
}
