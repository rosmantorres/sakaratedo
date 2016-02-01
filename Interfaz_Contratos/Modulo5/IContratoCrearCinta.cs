using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;
using ExcepcionesSKD;

namespace Interfaz_Contratos.Modulo5
{
    public interface IContratoCrearCinta
    { 
        
        void agregarOrganizacionCombo(string id, string nombre);
        int obtenerIdOrganizacion { get; }
        string obtenerNombreOrganizacion { get; }
        string obtenerColorCinta { get; }
        string obtenerRango { get; }
        string obtenerCategoria { get; }
        string obtenerSignificado { get; }
        string obtenerOrden { get; }
        void alertaCamposVacios();
        void alertaAgregarFallidoOrden(ExcepcionesSKD.Modulo5.OrdenCintaRepetidoException ex);
        void alertaAgregarFallidoRepetida(ExcepcionesSKD.Modulo5.CintaRepetidaException ex);
        void Respuesta();
        void alertaExpresiones();
        void alertaAgregarFallido(Exception ex);

    }
}
