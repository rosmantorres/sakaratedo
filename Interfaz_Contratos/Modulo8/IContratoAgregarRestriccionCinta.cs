using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Threading.Tasks;
//using System.Web.UI.WebControls;
//using DominioSKD.Entidades.Modulo5;

namespace Interfaz_Contratos.Modulo8
{
    public interface IContratoAgregarRestriccionCinta
    {
        String id { get; set; }
        String descripcion { get; set; }
        String tiempoMinimo { get; set; }
        String tiempoMaximo { get; set; }
        String tiempoDocente { get; set; }
        String puntosMinimos { get; set; }
        //List<Cinta> cintasRelacionadas { get; set; }
    }
}
