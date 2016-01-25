using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfaz_Contratos.Modulo8
{
    public interface IContratoConsultarRestriccionEvento
    {
        string RestriccionesCreadas { get; set; }
        string alertaClase { set; }
        string alertaRol { set; }
        string alert { set; }
    }
}
