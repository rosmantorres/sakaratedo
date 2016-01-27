using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfaz_Contratos.Modulo3
{
    public interface IContratoModificarOrganizacion
    {
        int obtenerIdOrg { get; }
        string obtenerNombreOrg { get; }
        string obtenerEmail { get; }
        string obtenerTelefono { get; }
        string obtenerDireccion { get; }
        string obtenerEstado { get; }
        string obtenerTecnica { get; }
        void alertaModificarFallidoEstiloOrg(ExcepcionesSKD.Modulo3.EstiloInexistenteException ex);
        void Respuesta();
    }
}
