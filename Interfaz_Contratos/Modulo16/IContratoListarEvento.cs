using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;

namespace Interfaz_Contratos.Modulo16
{
    public interface IContratoListarEvento
    {
        //void agregarTabla(string laTabla);

        Literal tablaEventos { get; }

    }
}
