using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfaz_Contratos.Modulo4
{
    /// <summary>
    /// Firma de Métodos que deben ser implementados en el 
    /// presentador del LitarHistorialMatricula
    /// </summary>
    public interface IContratoListarHistorialM
    {
        string Success { get; set; }
        string EliminarString { get; set; }
        string Cabecera { get; set; }
        string LaTabla { get; set; }
        string AlertaClase { set; }
        string AlertaRol { set; }
        string Alerta { set; }
    }
}
