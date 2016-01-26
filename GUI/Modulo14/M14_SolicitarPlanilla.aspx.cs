using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ExcepcionesSKD;
using Interfaz_Contratos.Modulo14;
using Interfaz_Presentadores.Modulo14;

namespace templateApp.GUI.Modulo14
{
    public partial class M14_SolicitarPlanilla : System.Web.UI.Page, IContratoM14SolicitarPlanilla
    {
       private PresentadorM14SolicitarPlanilla presentador;

        public M14_SolicitarPlanilla()
        {
            presentador = new PresentadorM14SolicitarPlanilla(this);
        }
        #region contratos
        public String tablaSolicitarP
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
        protected void Page_Load(object sender, EventArgs e)
        {
            ((SKD)Page.Master).IdModulo = "14.1";
            if (!IsPostBack)
            {
                presentador.PageLoadSolicitarPlanilla();
            }
        }

        public void Alerta(string msj)
        {
            presentador.Alerta(msj);
        }
    }
    
       
}