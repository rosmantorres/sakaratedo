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


namespace Interfaz_Presentadores.Modulo9
{
    class PresentadorAgregarEvento
    {
        private IContratoAgregarEvento vista;

        public PresentadorAgregarEvento(IContratoAgregarEvento laVista)
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
        public void LlenarCombos()
        {
            try
            {

                LogicaNegociosSKD.Comandos.Modulo9.ComandoConsultarListaTipoEventos comandoListarTipoEvento = (LogicaNegociosSKD.Comandos.Modulo9.ComandoConsultarListaTipoEventos)FabricaComandos.ObtenerComandoConsultarTipoEventos();

                Dictionary<string, string> options = new Dictionary<string, string>();
                options.Add("-1", M9_RecursoInterfazPresentador.selecccionarEvento);

                List<Entidad> listaTipoEvento = comandoListarTipoEvento.Ejecutar();
                foreach (Entidad row in listaTipoEvento)
                {
                    DominioSKD.Entidades.Modulo9.TipoEvento tipoEvento = (DominioSKD.Entidades.Modulo9.TipoEvento)row; 
                    
                    options.Add(tipoEvento.Id.ToString(), tipoEvento.Nombre);

                }
                vista.comboTipoEvento.DataSource = options;
                vista.comboTipoEvento.DataTextField = M9_RecursoInterfazPresentador.valueCombo;
                vista.comboTipoEvento.DataValueField = M9_RecursoInterfazPresentador.keyCombo;
                vista.comboTipoEvento.DataBind();
            }
            catch (ExcepcionesSKD.ExceptionSKD ex)
            {
                vista.alertaClase = M9_RecursoInterfazPresentador.alertaError;
                vista.alertaRol = M9_RecursoInterfazPresentador.tipoAlerta;
                vista.alerta = M9_RecursoInterfazPresentador.alertaHtml
                    + ex.Mensaje + M9_RecursoInterfazPresentador.alertaHtmlFinal; 
            }

        } 


    }
}
