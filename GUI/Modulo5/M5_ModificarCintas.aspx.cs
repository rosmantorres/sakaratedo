using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DominioSKD;
using Interfaz_Presentadores.Modulo5;
using Interfaz_Contratos.Modulo5;

namespace templateApp.GUI.Modulo5
{
    public partial class M5_ModificarCintas : System.Web.UI.Page, IContratoModificarCinta
    {
        private PresentadorModificarCinta presentador;
        private Dictionary<string, string> options = new Dictionary<string, string>();

        protected void Page_Load(object sender, EventArgs e)
        {
         //  String idCinta = Request.QueryString["idCinta"];


            ((SKD)Page.Master).IdModulo = "5";
            this.presentador = new PresentadorModificarCinta(this);
            if (!IsPostBack)
            {
               
                this.presentador.llenarCombo();
                this.ListOrg.DataSource = options;
                this.ListOrg.DataTextField = "value";
                this.ListOrg.DataValueField = "key";
                this.ListOrg.DataBind();

                this.presentador.llenarModificar();
            }
        }


        #region Contrato
        public void agregarOrganizacionCombo(string id, string nombre)
        {
            this.options.Add(id, nombre);
        }

        public int obtenerIdOrganizacion
        {
            get { return Int32.Parse(this.ListOrg.SelectedValue); }
            set { this.ListOrg.SelectedValue = value.ToString(); }
        }

        public string obtenerNombreOrganizacion
        {
            get { return this.ListOrg.SelectedItem.Text; }            
        }

        public string obtenerColorCinta
        {
            get { return this.color.Value; }
            set { this.color.Value = value; }
        }

        public string obtenerRango
        {
            get { return this.ran.Value; }
            set { this.ran.Value = value; }
        }

        public string obtenerCategoria
        {
            get { return this.cate.Value; }
            set { this.cate.Value = value; }
        }

        public string obtenerSignificado
        {
            get { return this.signi.Value; }
            set { this.signi.Value = value; }
        }

        public string obtenerOrden
        {
            get { return this.ord.Value; }
            set { this.ord.Value = value; }
        }
        public int obtenerIdCInta
        {
            get {  return Int32.Parse(Request.QueryString["idCinta"]); }
        }
        public void alertaModificarFallidoOrden(ExcepcionesSKD.Modulo5.OrdenCintaRepetidoException ex)
        {
            this.alert.Attributes[RecursoInterfazMod5.alertClase] = RecursoInterfazMod5.alertaError;
            this.alert.Attributes[RecursoInterfazMod5.alertRole] = RecursoInterfazMod5.tipoAlerta;
            this.alert.InnerHtml = RecursoInterfazMod5.alertaHtml + ex.Message + RecursoInterfazMod5.alertaHtmlFinal;
            this.alert.Visible = true;
        }
        public void Respuesta()
        {
            this.Response.Redirect(RecursoInterfazMod5.agregarExito);
        }
        public void alertaExpresiones()
        {
            this.alert.Attributes[RecursoInterfazMod5.alertClase] = RecursoInterfazMod5.alertaError;
            this.alert.Attributes[RecursoInterfazMod5.alertRole] = RecursoInterfazMod5.tipoAlerta;
            this.alert.InnerHtml = RecursoInterfazMod5.alertaHtml + RecursoInterfazMod5.expresionesRegulares + RecursoInterfazMod5.alertaHtmlFinal;
            this.alert.Visible = true;
        }
        public void alertaModificarFallido(Exception ex)
        {
            this.alert.Attributes[RecursoInterfazMod5.alertClase] = RecursoInterfazMod5.alertaError;
            this.alert.Attributes[RecursoInterfazMod5.alertRole] = RecursoInterfazMod5.tipoAlerta;
            this.alert.InnerHtml = RecursoInterfazMod5.alertaHtml + ex.Message + RecursoInterfazMod5.alertaHtmlFinal;
            this.alert.Visible = true;
        }
        #endregion



        protected void btnModificarCinta(object sender, EventArgs e)
        {

            this.presentador.ModificarValoresCinta();

        }

    }
}