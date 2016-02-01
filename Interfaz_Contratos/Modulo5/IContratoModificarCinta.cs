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
        int obtenerIdOrganizacion { get; set; }
        string obtenerNombreOrganizacion { get; }
        string obtenerColorCinta { get; set; }
        string obtenerRango { get; set; }
        string obtenerCategoria { get; set; }
        string obtenerSignificado { get; set; }
        string obtenerOrden { get; set; }
        int obtenerIdCInta { get; }
        void alertaModificarFallidoOrden(ExcepcionesSKD.Modulo5.OrdenCintaRepetidoException ex);
        void Respuesta();
        void alertaExpresiones();
        void alertaModificarFallido(Exception ex);
    }
}
