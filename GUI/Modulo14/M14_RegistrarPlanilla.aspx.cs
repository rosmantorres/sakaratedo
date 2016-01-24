using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using LogicaNegociosSKD;
using DominioSKD;
using ExcepcionesSKD;
using Interfaz_Contratos.Modulo14;
using Interfaz_Presentadores.Modulo14;
namespace templateApp.GUI.Modulo14
{
    public partial class M14_RegistrarPlanilla : System.Web.UI.Page, IContratoM14RegistrarPlanilla
    {
        private PresentadorM14RegistrarPlanilla presentador;

        public M14_RegistrarPlanilla()
        {
            presentador = new PresentadorM14RegistrarPlanilla(this);
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ((SKD)Page.Master).IdModulo = "14";

                presentador.PageLoadRegistrarPlanilla();
            }
        }

        #region contratos

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
        public String tipoNombre
        {
            get
            {
                return this.id_nombretipo.Value;
            }
        }
        public String planillaNombre
        {
            get
            {
                return this.id_nombrePlanilla.Value;
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



        #endregion
        public void Alerta(string msj)
        {
            presentador.Alerta(msj);
        }
    
        protected void llenarComboTipoPlanilla()
        {
            presentador.LlenarComboTipoPlanilla();
        }


        protected void comboTipoPlanilla_SelectedIndexChanged(object sender, EventArgs e)
        {
            presentador.NombreTipoPlanillaVisible();
        }

        protected void btnaceptar_Click(object sender, EventArgs e)
        {
            if (presentador.AgregarPlanilla() == true)
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
            presentador.QuitarDato();
        }

    }
}