﻿using System;
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
    public partial class M3_ModificarOrganizacion : System.Web.UI.Page, IContratoModificarOrganizacion
    {
        private PresentadorModificarOrganizacion presentador;

        protected void Page_Load(object sender, EventArgs e)
        {
            String idOrg = Request.QueryString["idOrg"];

            ((SKD)Page.Master).IdModulo = "3";
            this.presentador = new PresentadorModificarOrganizacion(this);
        }

        #region Contrato
        public int obtenerIdOrg()
        {
            return Int32.Parse(Request.QueryString["idOrg"]);
        }
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
        #endregion

        protected void btnModificarOrganizaciones(object sender, EventArgs e)
        {
            this.presentador.modificarValoresOrganizacion(); 
        }
 


    }


}