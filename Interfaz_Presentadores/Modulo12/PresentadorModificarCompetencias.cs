using Interfaz_Contratos.Modulo12;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfaz_Presentadores.Modulo12
{
    /// <summary>
    /// Presentador para la ventana Modificar Competencias
    /// </summary>
    public class PresentadorModificarCompetencias
    {
        private IContratoModificarCompetencias vista;

        /// <summary>
        /// Constructor del presentador
        /// </summary>
        /// <param name="laVista">instancia de la ventana</param>
        public PresentadorModificarCompetencias(IContratoModificarCompetencias laVista)
        {
            this.vista = laVista;
        }
    }
}
