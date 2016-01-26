using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfaz_Contratos.Modulo7
{
    /// <summary>
    /// Contrato para detallar competencia
    /// </summary>
    public interface IContratoDetallarCompetencia
    {
        string nombre_evento { get; set; }
        string costo_evento { get; set; }
        string tipo_evento { get; set; }
        string fechaInicio_evento { get; set; }
        string fechaFin_evento { get; set; }
        string ciudad_evento { get; set; }
        string estadoUbicacion_evento { get; set; }
        string direccion_evento { get; set; }
    }
}
