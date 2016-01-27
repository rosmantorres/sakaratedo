using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfaz_Contratos.Modulo5
{
    public interface IContratoModificarCinta
    {
        void agregarOrganizacionCombo(string id, string nombre);
        int obtenerIdOrganizacion { get; }
        string obtenerNombreOrganizacion { get; }
        string obtenerColorCinta { get; }
        string obtenerRango { get; }
        string obtenerCategoria { get; }
        string obtenerSignificado { get; }
        int obtenerOrden { get; }
        int obtenerIdCInta { get; }
        void alertaModificarFallidoOrden(ExcepcionesSKD.Modulo5.OrdenCintaRepetidoException ex);
        void Respuesta();

    }
}
