using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Interfaz_Contratos.Modulo12;

namespace Interfaz_Presentadores.Modulo12
{
    public class PresentadorListarCompetencias
    {
        private IContratoListarCompetencias vista;

        public PresentadorListarCompetencias(IContratoListarCompetencias laVista)
        {
            this.vista = laVista;
        }
    }
}
