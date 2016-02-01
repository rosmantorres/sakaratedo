using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
//using LogicaNegociosSKD..Modulo14;
using ExcepcionesSKD;
using Interfaz_Contratos.Modulo8;
using Interfaz_Presentadores.Modulo8;
using DominioSKD;


namespace templateApp.GUI.Modulo8
{
    public partial class interfazRestriccionesAvanceCinta : System.Web.UI.Page, IContratoConsultarResticcionCinta
    {
        private PresentadorConsultarRestriccionesCinta _presentador;

        #region Contratos
        
        public string RestriccionesCreadas
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

        public interfazRestriccionesAvanceCinta()
        {
            _presentador = new PresentadorConsultarRestriccionesCinta(this);
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            String success = Request.QueryString[RecursoInterfazModulo8.IdPlan];
            String stat = Request.QueryString[RecursoInterfazModulo8.statrec];

            ((SKD)Page.Master).IdModulo = RecursoInterfazModulo8.interfazRCi;
            _presentador.ObtenerVariablesURL();
            if (success != null)
            {
                int id = Convert.ToInt32(success);
                int sta = Convert.ToInt32(stat);
                _presentador.CambiarStatus(id, sta);
            }

            if (!IsPostBack)
            {
                
                _presentador.LlenarInformacion();
            }

        }
    }
}