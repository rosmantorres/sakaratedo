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
        #endregion

        protected void btnAgregarOrganizaciones(object sender, EventArgs e)
        {
           
            this.presentador.agregarValoresOrganizacion(); 

        }
 
    }
}