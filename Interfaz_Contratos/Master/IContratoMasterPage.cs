using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using DominioSKD;

namespace Interfaz_Contratos.Master
{
    public interface IContratoMasterPage
    {
        String MenuSuperiorEtq { get; set; }

        String MenuLateralEtq { get; set; }

        String ImagenUsuarioEtq { get; set; }

        String ImagenTagEtq { get; set; }

        String RolesEtq { get; set; }

        String NombreEtq { get; set; }

        String NombreTagEtq { get; set; }

        String IdModulo { get; set; }

        String LogoutEtq { get; set; }

        String[] RolesUsuario { get; set; }

        Cuenta UserLogin { get; set; }

    }
}
