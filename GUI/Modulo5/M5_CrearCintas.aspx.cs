﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DominioSKD;
using Interfaz_Presentadores.Modulo5;
using Interfaz_Contratos.Modulo5;
using System.Globalization;
using ExcepcionesSKD;

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

        public int obtenerIdOrganizacion
        {
            get { return Int32.Parse(this.ListOrg.SelectedValue); }
        }

        public string obtenerNombreOrganizacion
        {
            get {return this.ListOrg.SelectedItem.Text;}
        }

        public string obtenerColorCinta
        {
           get { return this.color.Value;}
        }

        public string obtenerRango
        {
            get { return this.ran.Value; }
        }

        public string obtenerCategoria
        {
            get { return this.cate.Value; }
        }

        public string obtenerSignificado
        {
            get { return this.signi.Value; }
        }

        public string obtenerOrden
        {
            get { return this.ord.Value; }
        }
        public void alertaCamposVacios()
        {
                this.alert.Attributes[RecursoInterfazMod5.alertClase] = RecursoInterfazMod5.alertaError;
                this.alert.Attributes[RecursoInterfazMod5.alertRole] = RecursoInterfazMod5.tipoAlerta;
                this.alert.InnerHtml = RecursoInterfazMod5.alertaHtml + RecursoInterfazMod5.camposVacios + RecursoInterfazMod5.alertaHtmlFinal;
                this.alert.Visible = true;
        }
        public void alertaAgregarFallidoOrden(ExcepcionesSKD.Modulo5.OrdenCintaRepetidoException ex)
        {
            this.alert.Attributes[RecursoInterfazMod5.alertClase] = RecursoInterfazMod5.alertaError;
            this.alert.Attributes[RecursoInterfazMod5.alertRole] = RecursoInterfazMod5.tipoAlerta;
            this.alert.InnerHtml = RecursoInterfazMod5.alertaHtml + ex.Message + RecursoInterfazMod5.alertaHtmlFinal;
            this.alert.Visible = true;
        }
        public void alertaAgregarFallidoRepetida(ExcepcionesSKD.Modulo5.CintaRepetidaException ex)
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
        public void alertaAgregarFallido(Exception ex)
        {
            this.alert.Attributes[RecursoInterfazMod5.alertClase] = RecursoInterfazMod5.alertaError;
            this.alert.Attributes[RecursoInterfazMod5.alertRole] = RecursoInterfazMod5.tipoAlerta;
            this.alert.InnerHtml = RecursoInterfazMod5.alertaHtml + ex.Message + RecursoInterfazMod5.alertaHtmlFinal;
            this.alert.Visible = true;
        }
        #endregion


        protected void btnCrearCinta(object sender, EventArgs e){

            this.presentador.agregarValoresCinta();
        }

    }

}