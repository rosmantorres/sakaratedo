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
        #endregion

        protected void btnModificarOrganizaciones(object sender, EventArgs e)
        {
            this.presentador.modificarValoresOrganizacion(); 
        }
 


    }


}