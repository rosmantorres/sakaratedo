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
                FabricaEntidades laFabricaEntidades = new FabricaEntidades();

                foreach (Entidad row in listaTipoEvento)
                {
                    DominioSKD.Entidades.Modulo9.TipoEvento tipoEvento = (DominioSKD.Entidades.Modulo9.TipoEvento)row; 
                    
                    options.Add(tipoEvento.Id.ToString(), tipoEvento.Nombre);
                }/*
                vista.organizacionComp.DataSource = options;
                vista.organizacionComp.DataTextField = M12_RecursoInterfazPresentador.valueCombo;
                vista.organizacionComp.DataValueField = M12_RecursoInterfazPresentador.keyCombo;
                vista.organizacionComp.DataBind();

                Dictionary<int, string> optionsCin1 = new Dictionary<int, string>();
                optionsCin1.Add(-1, M12_RecursoInterfazPresentador.selectCinta);
                List<Entidad> listaCintaDesde = comandoListarCintas.Ejecutar();
                List<Entidad> listaCintaHasta = comandoListarCintas.Ejecutar();
                int

                foreach (Cinta c in listaCintaDesde)
                {
                    optionsCin1.Add(c.Orden, c.Color_nombre);
                }
                vista.categIniComp.DataSource = optionsCin1;
                vista.categIniComp.DataTextField = M12_RecursoInterfazPresentador.valueCombo;
                vista.categIniComp.DataValueField = M12_RecursoInterfazPresentador.keyCombo;
                vista.categIniComp.DataBind();

                Dictionary<int, string> optionsCin2 = new Dictionary<int, string>();
                optionsCin2.Add(-1, M12_RecursoInterfazPresentador.selectCinta);
                vista.categFinComp.DataSource = optionsCin2;
                vista.categFinComp.DataTextField = M12_RecursoInterfazPresentador.valueCombo;
                vista.categFinComp.DataValueField = M12_RecursoInterfazPresentador.keyCombo;
                vista.categFinComp.DataBind();

                foreach (Cinta c in listaCintaHasta)
                {
                    optionsCin2.Add(c.Orden, c.Color_nombre);
                }
                vista.categFinComp.DataSource = optionsCin2;
                vista.categFinComp.DataTextField = M12_RecursoInterfazPresentador.valueCombo;
                vista.categFinComp.DataValueField = M12_RecursoInterfazPresentador.keyCombo;
                vista.categFinComp.DataBind();
*/
            }
            catch (ExcepcionesSKD.ExceptionSKD ex)
            { /*
                vista.alertaClase = M12_RecursoInterfazPresentador.alertaError;
                vista.alertaRol = M12_RecursoInterfazPresentador.tipoAlerta;
                vista.alerta = M12_RecursoInterfazPresentador.alertaHtml
                    + ex.Mensaje + M12_RecursoInterfazPresentador.alertaHtmlFinal; */
            }

        } 


    }
}
