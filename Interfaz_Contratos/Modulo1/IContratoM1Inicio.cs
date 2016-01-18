using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfaz_Contratos.Modulo1
{
    public interface IContratoM1Inicio
    {
        String UserNameEtq { get; set; }

        String PasswordEtq { get; set; }

        Boolean ErrorLogin { get; set; }

        Boolean WarningLog { get; set; }

        Boolean InfoLog { get; set; }

        Boolean SuccessLog { get; set; }

        String ErrorLoginText { get; set; }

        String WarningLogText { get; set; }

        String InfoLogText { get; set; }

        String SuccessLogText { get; set; }

        String RestablecerCorreoEtq { get; set; }

    }
}
