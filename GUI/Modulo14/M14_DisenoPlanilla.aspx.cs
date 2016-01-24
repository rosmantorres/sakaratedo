using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using LogicaNegociosSKD.Modulo14;
using ExcepcionesSKD;
using Interfaz_Contratos.Modulo14;
using Interfaz_Presentadores.Modulo14;
using CKEditor;
using CKEditor.NET;

namespace templateApp.GUI.Modulo14
{
    public partial class M14_DisenoPlanilla : System.Web.UI.Page, IContratoM14DisenoPlanilla
    {
        
        private PresentadorM14DisenoPlanilla presentador;

        #region contratos
        public Label tipoPlanilla 
        {
            get
            {
                return this.tipoPlanilla1;
            }
            set
            {
                this.tipoPlanilla1 = value;
            }
        }

        public Label planilla
        {
            get 
            {
                return this.Planilla1;
            }
            set
            {
                this.Planilla1 = value;
            }
        }
        public CKEditorControl CKEditor1
        {
            get
            {
                return this.CKEditor;
            }
            set
            {
                this.CKEditor = value;
            }
        }
        public DropDownList comboDatos
        {
            get
            {
                return this.comboDatos1;
            }
            set
            {
                this.comboDatos1 = value;
            }
        }
        public Label campos
        {
            get
            {
                return this.campos1;
            }
            set
            {
                this.campos1 = value;
            }
        }
        public Label camposStatic
        {
            get
            {
                return this.camposStatic1;
            }
            set
            {
                this.camposStatic1 = value;
            }
        }
        public string alertaClase
        {
            set
            {
                this.alerta.Attributes["class"] = value;
            }
        }
        public string alertaRol
        {
            set
            {
                this.alerta.Attributes["role"] = value;
            }
        }
        public string alert
        {
            set
            {
                this.alerta.InnerHtml = value;
            }
        }
        #endregion

        public M14_DisenoPlanilla()
        {
            presentador = new PresentadorM14DisenoPlanilla(this);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Page_Load(object sender, EventArgs e)
        {
            ((SKD)Page.Master).IdModulo = RecursoInterfazModulo14.NumeroModulo;
            presentador.PageLoad(Request, IsPostBack,Server);
        }


        protected void btnguardar_Click(object sender, EventArgs e)
        {
            presentador.btnguardar();
        }

 
        protected void comboDatos_SelectedIndexChanged(object sender, EventArgs e)
        {
            presentador.llenarCombo();
        }
    }
}