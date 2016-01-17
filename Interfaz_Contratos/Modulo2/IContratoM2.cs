using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfaz_Contratos.Modulo2
{
    public interface IContratoM2
    {
        String ImagenEtqSRC { get; set; }

        String RolSelectEqt { get; }

        String NombreApellidoEtq { set; }

        String NombreUsuaurioEtq { set; }

        String RolesUsuario { get; set; }
    }
}
