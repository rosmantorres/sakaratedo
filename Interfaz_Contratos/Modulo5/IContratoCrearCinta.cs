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
        int obtenerIdOrganizacion();
        string obtenerNombreOrganizacion();
        string obtenerColorCinta();
        string obtenerRango();
        string obtenerCategoria();
        string obtenerSignificado();
        int obtenerOrden();
        void alertaCamposVacios();
        void alertaAgregarFallidoOrden(ExcepcionesSKD.Modulo5.OrdenCintaRepetidoException ex);
        void alertaAgregarFallidoRepetida(ExcepcionesSKD.Modulo5.CintaRepetidaException ex);
        void Respuesta();


    }
}
