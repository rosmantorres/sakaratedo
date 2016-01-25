using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;
using Interfaz_Contratos.Modulo8;

namespace Interfaz_Presentadores.Modulo8
{
    public class PresentadorModificarRestriccionCompetencia
    {
        private IContratoModificarRestriccionCompetencia vista;

        public PresentadorModificarRestriccionCompetencia(IContratoModificarRestriccionCompetencia laVista)
        {
          
            this.vista = laVista;
            
        }





    }
}
