using DominioSKD;
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
    public partial class M14_ModificarPlanillaCreada : System.Web.UI.Page, IContratoM14ModificarPlanillaCreada
    {
         private PresentadorM14ModificadorPlanillaCreada presentador;

         public M14_ModificarPlanillaCreada()
            {
               presentador = new PresentadorM14ModificadorPlanillaCreada(this);
            }
        protected void Page_Load(object sender, EventArgs e)
        {

            ((SKD)Page.Master).IdModulo = "14";

                if (!IsPostBack)
                {
                    presentador.PageLoadModificarPlanilla();
                }
            
        }

        #region contratos

        public String planillaId
        {
            get
            {
                return this.id_planilla.Value;
            }
            set
            {
                this.id_planilla.Value = value;
            }
        }
        public DropDownList tipoPlanillaCombo
        {
            get
            {
                return this.comboTipoPlanilla;
            }
            set
            {
                this.comboTipoPlanilla = value;
            }
        }
        public String nombreTipo
        {
            get
            {
                return this.id_nombretipo.Value;
            }
            set
            {
                this.id_nombretipo.Value = value;
            }
        }
        public String nombrePlanilla
        {
            get
            {
                return this.id_nombrePlanilla.Value;
            }
            set
            {
                this.id_nombrePlanilla.Value = value;
            }
        }
        public ListBox datosPlanilla1
        {
            get
            {
                return this.ListBox1;
            }
            set
            {
                this.ListBox1 = value;
            }
        }
        public ListBox datosPlanilla2
        {
            get
            {
                return this.ListBox2;
            }
            set
            {
                this.ListBox2 = value;
            }
        }
        public String alertLocalRol
        {
            set
            {
                this.alertlocal.Attributes["role"] = value;
            }
        }
        public String alertLocalClase
        {
            set
            {
                this.alertlocal.Attributes["class"] = value;
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
                this.alertlocal.Visible = value;
            }
        }
        public bool id_otroTipo
        {
            set
            {
                this.id_otro.Visible = value;
            }
        }
        public int IDPlanillaModificar
        {
            get
            {
                return Int32.Parse(Request.QueryString[RecursoInterfazModulo14.idPlan]);
            }
        }
        public bool IDPlanillaModificarVisible
        {
            set
            {
                this.id_planilla.Visible = value;
            }
        }
       

        #endregion
        public void Alerta(string msj)
        {
            presentador.Alerta(msj);
        }
  
        protected void comboTipoPlanilla_SelectedIndexChanged(object sender, EventArgs e)
        {
            presentador.NombreTipoPVisible();
        }

        protected void btneditar_Click(object sender, EventArgs e)
        {

            if (presentador.EditarPlanilla() == true)
            {
                Response.Redirect("../Modulo14/M14_ConsultarPlanillas.aspx?success=true");
            }
        }

        protected void AgregarDato_Click(object sender, EventArgs e)
        {
            presentador.AgregarDato();
        }

        protected void QuitarDato_Click(object sender, EventArgs e)
        {
            presentador.QuitarDatos();
        }
    
    }

}