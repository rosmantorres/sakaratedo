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
        string obtenerNombreOrg { get; set; }
        string obtenerEmail { get; set; }
        string obtenerTelefono { get; set; }
        string obtenerDireccion { get; set; }
        string obtenerEstado { get; set; }
        string obtenerTecnica { get; set; }
        void alertaModificarFallidoEstiloOrg(ExcepcionesSKD.Modulo3.EstiloInexistenteException ex);
        void Respuesta();
        void alertaExpresiones();
        void alertaModificarFallido(Exception ex);
    }
}
