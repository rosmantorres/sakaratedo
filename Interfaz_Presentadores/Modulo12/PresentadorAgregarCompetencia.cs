using DominioSKD;
using Interfaz_Contratos.Modulo12;
using LogicaNegociosSKD;
using LogicaNegociosSKD.Fabrica;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Interfaz_Presentadores.Modulo12
{
    public class PresentadorAgregarCompetencia
    {
        private IContratoAgregarCompetencias vista;

        public PresentadorAgregarCompetencia(IContratoAgregarCompetencias laVista)
        {
            this.vista = laVista;
        }

        public void ObtenerVariablesURL()
        { 
            String errorMalicioso = HttpContext.Current.Request.QueryString[M12_RecursoInterfazPresentador.errorGet];

            if (errorMalicioso != null)
            {
                if (errorMalicioso.Equals(M12_RecursoInterfazPresentador.strErrorMalicioso))
                {
                    vista.alertaClase = M12_RecursoInterfazPresentador.alertaError;
                    vista.alertaRol = M12_RecursoInterfazPresentador.tipoAlerta;
                    vista.alerta = M12_RecursoInterfazPresentador.alertaHtml + 
                        M12_RecursoInterfazPresentador.inputMalicioso + 
                        M12_RecursoInterfazPresentador.alertaHtmlFinal;
                }
            }
        }

        public void LlenarCombos()
        {
            try
            {
                FabricaComandos laFabrica = new FabricaComandos();
                Comando<List<Entidad>> comandoListarOrganizacion =
                    laFabrica.ObtenerComandoConsultarOrgazaniciones();

                Comando<List<Entidad>> comandoListarCintas =
                    laFabrica.ObtenerComandoConsultarCintas();

                Dictionary<string, string> options = new Dictionary<string, string>();
                options.Add("-1", M12_RecursoInterfazPresentador.selectOrganizacion);

                List<Entidad> listaOrg = comandoListarOrganizacion.Ejecutar();


                foreach (Organizacion o in listaOrg)
                {
                    options.Add(o.Id.ToString(), o.Nombre);
                }
                vista.organizacionComp.DataSource = options;
                vista.organizacionComp.DataTextField = M12_RecursoInterfazPresentador.valueCombo;
                vista.organizacionComp.DataValueField = M12_RecursoInterfazPresentador.keyCombo;
                vista.organizacionComp.DataBind();

                Dictionary<int, string> optionsCin1 = new Dictionary<int, string>();
                optionsCin1.Add(-1, M12_RecursoInterfazPresentador.selectCinta);
                List<Entidad> listaCintaDesde = comandoListarCintas.Ejecutar();
                List<Entidad> listaCintaHasta = comandoListarCintas.Ejecutar();

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

            }
            catch (ExcepcionesSKD.ExceptionSKD ex)
            {
                vista.alertaClase = M12_RecursoInterfazPresentador.alertaError;
                vista.alertaRol = M12_RecursoInterfazPresentador.tipoAlerta;
                vista.alerta = M12_RecursoInterfazPresentador.alertaHtml 
                    + ex.Mensaje + M12_RecursoInterfazPresentador.alertaHtmlFinal;
            }
        
        }
    }
}
