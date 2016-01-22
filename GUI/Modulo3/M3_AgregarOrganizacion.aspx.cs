using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DominioSKD;
using LogicaNegociosSKD.Modulo3;
using Interfaz_Presentadores.Modulo3;
using Interfaz_Contratos.Modulo3;


namespace templateApp.GUI.Modulo3
{
    public partial class M3_AgregarOrganizacion : System.Web.UI.Page, IContratoAgregarOrganizacion
    {
        private PresentadorAgregarOrganizacion presentador;

        protected void Page_Load(object sender, EventArgs e)
        {
            ((SKD)Page.Master).IdModulo = "3";
            this.presentador = new PresentadorAgregarOrganizacion(this);
        }

        #region Contrato
        public string obtenerNombreOrg()
        {
            return this.nombre.Value;
        }
        public string obtenerEmail()
        {
            return this.email.Value;
        }
        public string obtenerTelefono()
        {
            return this.telefono.Value;
        }
        public string obtenerDireccion()
        {
            return this.direccion.Value;
        }
        public string obtenerEstado()
        {
            return this.ListEstados.SelectedValue;
        }
        public string obtenerTecnica()
        {
            return this.ListTecnica.SelectedValue;
        }
        public void alertaCamposVacios()
        {
            this.alert.Attributes[M3_RecursoInterfaz.alertClase] = M3_RecursoInterfaz.alertaError;
            this.alert.Attributes[M3_RecursoInterfaz.alertRole] = M3_RecursoInterfaz.tipoAlerta;
            this.alert.InnerHtml = M3_RecursoInterfaz.alertaHtml + M3_RecursoInterfaz.camposVacios + M3_RecursoInterfaz.alertaHtmlFinal;
            this.alert.Visible = true;
        }
        public void alertaAgregarFallido(ExcepcionesSKD.ExceptionSKD ex)
        {
            this.alert.Attributes[M3_RecursoInterfaz.alertClase] = M3_RecursoInterfaz.alertaError;
            this.alert.Attributes[M3_RecursoInterfaz.alertRole] = M3_RecursoInterfaz.tipoAlerta;
            this.alert.InnerHtml = M3_RecursoInterfaz.alertaHtml + ex.Mensaje + M3_RecursoInterfaz.alertaHtmlFinal;
            this.alert.Visible = true;
        }
        public void Respuesta()
        {
            this.Response.Redirect(M3_RecursoInterfaz.agregarExito);
        }
        #endregion

        protected void btnAgregarOrganizaciones(object sender, EventArgs e)
        {
           
            this.presentador.agregarValoresOrganizacion(); 

        }
 
    }
}