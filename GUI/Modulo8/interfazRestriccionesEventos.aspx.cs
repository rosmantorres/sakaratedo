using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using LogicaNegociosSKD.Comandos.Modulo14;
using ExcepcionesSKD;
using Interfaz_Contratos.Modulo8;
using Interfaz_Presentadores.Modulo8;
using DominioSKD;

namespace templateApp.GUI.Modulo8
{


    public partial class interfazRestriccionesEventos : System.Web.UI.Page, IContratoConsultarRestriccionCompetencia
    {

        private PresentadorConsultarTodosRestriccionCompetencia _presentador;

        #region contratos
        public string restriccionCompetencia
        {
            get
            {
                return this.tabla.Text;
            }
            set
            {
                this.tabla.Text = value;
            }
        }

        public Label labelReporte
        {

            get
            {
                return this.labelReporte;
            }

        }

        public string alertaClase
        {
            set
            {
                this.alert.Attributes["class"] = value;
            }
        }
        public string alertaRol
        {
            set
            {
                this.alert.Attributes["role"] = value;
            }
        }
        public string alerta
        {
            set
            {
                this.alert.InnerHtml = value;
            }
        }
        #endregion

        #region constructor
        public interfazRestriccionesEventos()
        {
            _presentador = new PresentadorConsultarTodosRestriccionCompetencia(this);
        }
        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            String success = Request.QueryString[RecursoInterfazModulo8.IdPlan];
            String stat = Request.QueryString[RecursoInterfazModulo8.statrec];
            ((SKD)Page.Master).IdModulo = RecursoInterfazModulo8.interfazRE;

            
            if (success != null)
            {
                if (stat != null)
                {
                    int id = Convert.ToInt32(success);
                    int sta = Convert.ToInt32(stat);
                    _presentador.CambiarStatus(id, sta);
                }
                else
                {
                    _presentador.MostrarModificado(success);
                }                
            }
            if (success == null)
            {
                if (stat != null)
                {
                    _presentador.MostrarAgregado(stat);
                }
            }

            if (!IsPostBack)
            {
                List<Entidad> listaRestricciones = _presentador.LlenarTabla();
                _presentador.cargarInformacion(listaRestricciones);
            }

        }
    }
}