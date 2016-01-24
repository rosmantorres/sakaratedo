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
        int obtenerIdOrganizacion();
        string obtenerNombreOrganizacion();
        string obtenerColorCinta();
        string obtenerRango();
        string obtenerCategoria();
        string obtenerSignificado();
        int obtenerOrden();
        int obtenerIdCInta();
        void alertaModificarFallidoOrden(ExcepcionesSKD.Modulo5.OrdenCintaRepetidoException ex);
        void Respuesta();

    }
}
