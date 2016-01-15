using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfaz_Contratos.Modulo3
{
    public interface IContratoConsultarOrganizacion
    {
        void llenarIdOrg(string id);
        void llenarNombreOrg(string nombre);
        void llenarEmailOrg(string email);
        void llenarTelefonoOrg(string telefono);
        void llenarEstiloOrg(string estilo);
        void llenarDireccionOrg(string direccion);
        void llenarEstadoOrg(string estado);
        void llenarBotones(int id);
        void llenarStatusActivo(int id);
        void llenarStatusInactivo(int id);

    }
}
