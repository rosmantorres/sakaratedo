using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DominioSKD;
using Interfaz_Presentadores.Modulo3;
using Interfaz_Contratos.Modulo3;

namespace templateApp.GUI.Modulo3
{
    public partial class M3_ModificarOrganizacion : System.Web.UI.Page, IContratoModificarOrganizacion
    {
        private PresentadorModificarOrganizacion presentador;

        protected void Page_Load(object sender, EventArgs e)
        {
            String idOrg = Request.QueryString["idOrg"];

            ((SKD)Page.Master).IdModulo = "3";
            this.presentador = new PresentadorModificarOrganizacion(this);
            this.presentador.llenarModificar();
        }

        #region Contrato
        public int obtenerIdOrg
        {
            get { return Int32.Parse(Request.QueryString["idOrg"]); }
        }
        public string obtenerNombreOrg
        {
            get { return this.nombre.Value; }
            set { this.nombre.Value = value;}
        }
        public string obtenerEmail
        {
            get { return this.email.Value; }
            set { this.email.Value = value; }
        }
        public string obtenerTelefono
        {
            get { return this.telefono.Value; }
            set { this.telefono.Value = value; }
        }
        public string obtenerDireccion
        {
            get { return this.direccion.Value; }
            set { this.direccion.Value = value; }
        }
        public string obtenerEstado
        {
            get { return this.ListEstados.SelectedValue; }
            set { this.ListEstados.Items.FindByValue(value).Selected = true; }
        }
        public string obtenerTecnica
        {
            get { return this.ListTecnica.SelectedValue; }
            set { this.ListTecnica.Items.FindByValue(value).Selected = true; }
        }
        public void alertaModificarFallidoEstiloOrg(ExcepcionesSKD.Modulo3.EstiloInexistenteException ex)
        {
            this.alert.Attributes[M3_RecursoInterfaz.alertClase] = M3_RecursoInterfaz.alertaError;
            this.alert.Attributes[M3_RecursoInterfaz.alertRole] = M3_RecursoInterfaz.tipoAlerta;
            this.alert.InnerHtml = M3_RecursoInterfaz.alertaHtml + ex.Message + M3_RecursoInterfaz.alertaHtmlFinal;
            this.alert.Visible = true;
        }
        public void Respuesta()
        {
            this.Response.Redirect(M3_RecursoInterfaz.agregarExito);
        }
        public void alertaExpresiones()
        {
            this.alert.Attributes[M3_RecursoInterfaz.alertClase] = M3_RecursoInterfaz.alertaError;
            this.alert.Attributes[M3_RecursoInterfaz.alertRole] = M3_RecursoInterfaz.tipoAlerta;
            this.alert.InnerHtml = M3_RecursoInterfaz.alertaHtml + M3_RecursoInterfaz.expresionesRegulares + M3_RecursoInterfaz.alertaHtmlFinal;
            this.alert.Visible = true;
        }
        public void alertaModificarFallido(Exception ex)
        {
            this.alert.Attributes[M3_RecursoInterfaz.alertClase] = M3_RecursoInterfaz.alertaError;
            this.alert.Attributes[M3_RecursoInterfaz.alertRole] = M3_RecursoInterfaz.tipoAlerta;
            this.alert.InnerHtml = M3_RecursoInterfaz.alertaHtml + ex.Message + M3_RecursoInterfaz.alertaHtmlFinal;
            this.alert.Visible = true;
        }
        #endregion

        protected void btnModificarOrganizaciones(object sender, EventArgs e)
        {
            this.presentador.modificarValoresOrganizacion(); 
        }
 


    }


}