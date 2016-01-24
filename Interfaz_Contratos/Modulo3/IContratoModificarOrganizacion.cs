using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfaz_Contratos.Modulo3
{
    public interface IContratoModificarOrganizacion
    {
        int obtenerIdOrg();
        string obtenerNombreOrg();
        string obtenerEmail();
        string obtenerTelefono();
        string obtenerDireccion();
        string obtenerEstado();
        string obtenerTecnica();
        void alertaModificarFallido(ExcepcionesSKD.ExceptionSKD ex);
        void Respuesta();
    }
}
