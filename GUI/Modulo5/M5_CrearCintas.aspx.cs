using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DominioSKD;
using LogicaNegociosSKD.Modulo5;
using LogicaNegociosSKD.Modulo3;
using Interfaz_Presentadores.Modulo5;
using Interfaz_Contratos.Modulo5;
using System.Globalization;

namespace templateApp.GUI.Modulo5
{
    public partial class M5_CrearCintas : System.Web.UI.Page, IContratoCrearCinta
    {

        private PresentadorCrearCintas presentador;
        private Dictionary<string, string> options = new Dictionary<string, string>();

        protected void Page_Load(object sender, EventArgs e)
        {
            ((SKD)Page.Master).IdModulo = "5";

            // Controlador
            this.presentador = new PresentadorCrearCintas(this);
            if (!IsPostBack)
            {
                // la vista herda de la interfaz contrato 
                //el presentador al final recive un tipo de dato IContratoCrearCinta
                // la vista ES UN IContratoCrearCinta 
              
                this.presentador.llenarCombo();
                this.ListOrg.DataSource = options;
                this.ListOrg.DataTextField = "value";
                this.ListOrg.DataValueField = "key";
                this.ListOrg.DataBind();
              
            }
            
        }

        #region Contrato
        public void agregarOrganizacionCombo(string id, string nombre) 
        {
            this.options.Add(id, nombre);
        }

        public int obtenerIdOrganizacion()
        {
            return Int32.Parse(this.ListOrg.SelectedValue); 
        }

        public string obtenerNombreOrganizacion()
        {
            return this.ListOrg.SelectedItem.Text;
        }

        public string obtenerColorCinta()
        {
            return this.color.Value;
        }

        public string obtenerRango()
        {
            return this.ran.Value;
        }

        public string obtenerCategoria()
        {
            return this.cate.Value;
        }

        public string obtenerSignificado()
        {
            return this.signi.Value;
        }

        public int obtenerOrden()
        {
            return Int32.Parse(this.ord.Value);
        }
        public void alertaCamposVacios()
        {
                this.alert.Attributes[RecursoInterfazMod5.alertClase] = RecursoInterfazMod5.alertaError;
                this.alert.Attributes[RecursoInterfazMod5.alertRole] = RecursoInterfazMod5.tipoAlerta;
                this.alert.InnerHtml = RecursoInterfazMod5.alertaHtml + RecursoInterfazMod5.camposVacios + RecursoInterfazMod5.alertaHtmlFinal;
                this.alert.Visible = true;
        }
        public void alertaAgregarFallido(ExcepcionesSKD.ExceptionSKD ex)
        {
            this.alert.Attributes[RecursoInterfazMod5.alertClase] = RecursoInterfazMod5.alertaError;
            this.alert.Attributes[RecursoInterfazMod5.alertRole] = RecursoInterfazMod5.tipoAlerta;
            this.alert.InnerHtml = RecursoInterfazMod5.alertaHtml + ex.Mensaje + RecursoInterfazMod5.alertaHtmlFinal;
            this.alert.Visible = true;
        }
        public void Respuesta()
        {
            this.Response.Redirect(RecursoInterfazMod5.agregarExito);
        }
        #endregion


        protected void btnCrearCinta(object sender, EventArgs e){

            this.presentador.agregarValoresCinta(); 
        }

    }

}