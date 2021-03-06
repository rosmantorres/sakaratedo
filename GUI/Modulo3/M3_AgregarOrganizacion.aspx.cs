﻿using System;
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
    public partial class M3_AgregarOrganizacion : System.Web.UI.Page, IContratoAgregarOrganizacion
    {
        private PresentadorAgregarOrganizacion presentador;

        protected void Page_Load(object sender, EventArgs e)
        {
            ((SKD)Page.Master).IdModulo = "3";
            this.presentador = new PresentadorAgregarOrganizacion(this);
        }

        #region Contrato
        public string obtenerNombreOrg
        {
            get { return this.nombre.Value; }
        }
        public string obtenerEmail
        {
            get { return this.email.Value; }
        }
        public string obtenerTelefono
        {
            get {return this.telefono.Value;}
        }
        public string obtenerDireccion
        {
            get { return this.direccion.Value; }
        }
        public string obtenerEstado
        {
            get { return this.ListEstados.SelectedValue; }
        }
        public string obtenerTecnica
        {
            get { return this.ListTecnica.SelectedValue; }
        }
        public void alertaCamposVacios()
        {
            this.alert.Attributes[M3_RecursoInterfaz.alertClase] = M3_RecursoInterfaz.alertaError;
            this.alert.Attributes[M3_RecursoInterfaz.alertRole] = M3_RecursoInterfaz.tipoAlerta;
            this.alert.InnerHtml = M3_RecursoInterfaz.alertaHtml + M3_RecursoInterfaz.camposVacios + M3_RecursoInterfaz.alertaHtmlFinal;
            this.alert.Visible = true;
        }
        public void alertaAgregarFallidoNombreOrg(ExcepcionesSKD.Modulo3.OrganizacionExistenteException ex)
        {
            this.alert.Attributes[M3_RecursoInterfaz.alertClase] = M3_RecursoInterfaz.alertaError;
            this.alert.Attributes[M3_RecursoInterfaz.alertRole] = M3_RecursoInterfaz.tipoAlerta;
            this.alert.InnerHtml = M3_RecursoInterfaz.alertaHtml + ex.Message + M3_RecursoInterfaz.alertaHtmlFinal;
            this.alert.Visible = true;
        }
        public void alertaAgregarFallidoEstiloOrg(ExcepcionesSKD.Modulo3.EstiloInexistenteException ex)
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
        public void alertaAgregarFallido(Exception ex)
        {
            this.alert.Attributes[M3_RecursoInterfaz.alertClase] = M3_RecursoInterfaz.alertaError;
            this.alert.Attributes[M3_RecursoInterfaz.alertRole] = M3_RecursoInterfaz.tipoAlerta;
            this.alert.InnerHtml = M3_RecursoInterfaz.alertaHtml + ex.Message + M3_RecursoInterfaz.alertaHtmlFinal;
            this.alert.Visible = true;
        }
        #endregion

        protected void btnAgregarOrganizaciones(object sender, EventArgs e)
        {
           
            this.presentador.agregarValoresOrganizacion(); 

        }
 
    }
}