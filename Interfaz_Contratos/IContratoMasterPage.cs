using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Interfaz_Contratos
{
    public interface IContratoMasterPage
    {
        String MenuSuperiorList { get; set; }

        String DES { get; set; }

        String MenuLateralList { get; set; }

        String IdModulo { get; set; }

        String RolEnUso { get; set; }

        String[] RolesUsuario { get; set; }

        String RolesList { get; set; }

        String SessionImagen { get; set; }

        String SessionUsuarioNombre { get; }

        String SessionNombreCompleto { get; }
    }
}
