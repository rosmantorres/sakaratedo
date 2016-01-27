using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfaz_Contratos.Modulo3
{
    public interface IContratoAgregarOrganizacion
    {
        string obtenerNombreOrg { get; }
        string obtenerEmail { get; }
        string obtenerTelefono { get; }
        string obtenerDireccion { get; }
        string obtenerEstado { get; }
        string obtenerTecnica { get; }
        void alertaCamposVacios();
        void alertaAgregarFallidoNombreOrg(ExcepcionesSKD.Modulo3.OrganizacionExistenteException ex);
        void alertaAgregarFallidoEstiloOrg(ExcepcionesSKD.Modulo3.EstiloInexistenteException ex);
        void Respuesta();

    }
}
