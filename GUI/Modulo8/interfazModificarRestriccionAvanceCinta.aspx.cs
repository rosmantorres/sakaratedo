using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using LogicaNegociosSKD.Modulo8;
using ExcepcionesSKD;
using Interfaz_Contratos.Modulo8;
using Interfaz_Presentadores.Modulo8;
using DominioSKD;



namespace templateApp.GUI.Modulo8
{
    public partial class interfazModificarRestriccionAvanceCinta : System.Web.UI.Page, IContratoModificarRestriccionCinta
    {
        private PresentadorModificarRestriccionCinta _presentador;

        #region Implementacion de Contrato
        
        public string tiempo_Min
        {
            get
            {
                return this.tiempo_minimo.Value;
            }
            set
            {
                this.tiempo_minimo.Value = value;
            }
        }
        
        public string puntaje_min
        {
            get
            {
                return this.puntaje_minimo.Value;
            }
            set
            {
                this.puntaje_minimo.Value = value;
            }
        }

        public string horas_docen
        {
            get
            {
                return this.horas_docentes.Value;
            }
            set
            {
                this.horas_docentes.Value = value;
            }
        }

       public String alertLocalRol
        {
            set
            {
                this.alertlocal.InnerText = value;
            }
        }

        public String alertLocalClase
        {
            set
            {
                this.alert.InnerText = value;
            }
        }

        public String alertLocal
        {
            set
            {
                this.alertlocal.InnerHtml = value;
            }
        }

        public bool alerta
        {
            set
            {
                this.alert.Visible = value;
            }
        }
        #endregion
        
        #region Constructor
        public interfazModificarRestriccionAvanceCinta()
		{
            _presentador = new PresentadorModificarRestriccionCinta(this);
		}
        #endregion
        
        protected void Page_Load(object sender, EventArgs e)
        {   
            String idEvento = Request.QueryString["idPlan"];
            if (!IsPostBack)
            {
                ((SKD)Page.Master).IdModulo = "8";
                
            }
        }
        
    }
}

