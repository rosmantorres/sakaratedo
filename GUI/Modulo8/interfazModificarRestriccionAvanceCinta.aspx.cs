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

        public string id_restriccion
        {
            get
            {
                return Request.QueryString[RecursoInterfazModulo8.IdPlan];
            }
            set
            {
                this.tiempo_minimo.Value = Request.QueryString[RecursoInterfazModulo8.IdPlan]; 
            }
        }
        
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
        
        #region Constructor
        public interfazModificarRestriccionAvanceCinta()
		{
            _presentador = new PresentadorModificarRestriccionCinta(this);
		}
        #endregion
        
        protected void Page_Load(object sender, EventArgs e)
        {   
            String idEvento = Request.QueryString[RecursoInterfazModulo8.IdPlan];
            if (!IsPostBack)
            {
                ((SKD)Page.Master).IdModulo = RecursoInterfazModulo8.Mod8;
                
            }
        }


        protected void btnaceptar_Click(object sender, EventArgs e)
        {
            if (_presentador.ModificarRest() == true)
            {
                Response.Redirect(RecursoInterfazModulo8.ReturnRestCinta);
            }

        }
        
    }
}

