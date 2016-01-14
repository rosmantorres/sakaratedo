using Interfaz_Contratos.Modulo7;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfaz_Presentadores.Modulo7
{
    public class PresentadorListarCintasObtenidas
    {
        private IContratoListarCintasObtenidas vista;
        /// <summary>
        /// Constructor del presentador
        /// </summary>
        /// <param name="laVista">instancia de la vista</param>
        public PresentadorListarCintasObtenidas(IContratoListarCintasObtenidas laVista)
        {
            vista = laVista;
        }
    }
}
