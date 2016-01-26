using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfaz_Contratos.Modulo7
{
    /// <summary>
    /// Contrato para detallar horario practica
    /// </summary>
    public interface IContratoDetallarHorarioPractica
    {
        string nombre_evento { get; set; }
        string descripcion_evento { get; set; }
        string estado_evento { get; set; }
        string horaInicio_evento { get; set; }
        string horaFin_evento { get; set; }
        string direccionEvento_evento { get; set; }
    }
}
