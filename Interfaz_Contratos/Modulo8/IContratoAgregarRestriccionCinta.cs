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
        
        
        string tiempo_Min { get; set; }
        string tiempo_Max { get; set; }
        string horas_docen { get; set; }
        string puntaje_min { get; set; }
        DropDownList comboRestCinta { get; }
        /*void alertaCamposVacios();
        void alertaAgregarFallidoOrden(ExcepcionesSKD.Modulo8.RestriccionRepetidaException ex);
        void alertaAgregarFallidoRepetida(ExcepcionesSKD.Modulo8.RestriccionExistenteException ex);*/
        void Respuesta();
        string alertaClase { set; }
        string alertaRol { set; }
        string alerta { set; }
        //List<Cinta> cintasRelacionadas { get; set; }
    }
}
