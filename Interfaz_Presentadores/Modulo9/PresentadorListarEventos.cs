using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Interfaz_Contratos.Modulo9;
using System.Web;
using LogicaNegociosSKD.Fabrica;
using LogicaNegociosSKD;
using DominioSKD;
using DominioSKD.Fabrica;
using LogicaNegociosSKD.Fabrica;



namespace Interfaz_Presentadores.Modulo9
{
   public class PresentadorListarEventos
    {

        private IContratoListarEventos vista;
        /// <summary>
        /// Constructor del presentador
        /// </summary>
        /// <param name="laVista">instancia de la ventana</param>
        public PresentadorListarEventos(IContratoListarEventos laVista)
        {
            this.vista = laVista;
        }
        public void ObtenerVariablesURL()
        {
            String errorMalicioso = HttpContext.Current.Request.QueryString[M9_RecursoInterfazPresentador.errorGet];

            if (errorMalicioso != null)
            {
                if (errorMalicioso.Equals(M9_RecursoInterfazPresentador.strErrorMalicioso))
                {
                    vista.alertaClase = M9_RecursoInterfazPresentador.alertaError;
                    vista.alertaRol = M9_RecursoInterfazPresentador.tipoAlerta;
                    vista.alerta = M9_RecursoInterfazPresentador.alertaHtml +
                    M9_RecursoInterfazPresentador.inputMalicioso +
                    M9_RecursoInterfazPresentador.alertaHtmlFinal;
                }
            }
        }
        public void ListarEventos(String idPersona)
        { 
            FabricaEntidades fabricaEntidades = new FabricaEntidades();
            DominioSKD.Entidades.Modulo9.Evento a = (DominioSKD.Entidades.Modulo9.Evento)fabricaEntidades.ObtenerEvento();
            a.Id = int.Parse(idPersona);
            LogicaNegociosSKD.Comandos.Modulo9.ComandoConsultarListaEventos comandoListarEventos = (LogicaNegociosSKD.Comandos.Modulo9.ComandoConsultarListaEventos)FabricaComandos.ObtenerComandoConsultarListaEventos(a);
        
        
        }
    
    }
}
