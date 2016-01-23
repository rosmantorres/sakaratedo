using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfaz_Contratos.Modulo9
{
    interface IContratoListarEvento
    {
        string laTabla { set; }
        string alertaClase { set; }
        string alertaRol { set; }
        string alerta { set; }
    }
}
