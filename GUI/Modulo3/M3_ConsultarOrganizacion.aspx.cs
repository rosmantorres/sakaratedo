using DominioSKD;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Interfaz_Contratos.Modulo3;
using Interfaz_Presentadores.Modulo3;


namespace templateApp.GUI.Modulo3
{
    public partial class M3_ConsultarOrganizacion : System.Web.UI.Page, IContratoConsultarOrganizacion
    {
        private PresentadorLlenarOrganizacion presentador;

        protected void Page_Load(object sender, EventArgs e)
        {
            ((SKD)Page.Master).IdModulo = "3";
            
              if (!IsPostBack)
            {

                this.presentador = new PresentadorLlenarOrganizacion(this);
                this.presentador.LlenarInformacion();
            }
            
        }

        #region IContratos
        public void llenarIdOrg(string id)
        {
            this.tabla.Text += M3_RecursoInterfaz.AbrirTR;
            this.tabla.Text += M3_RecursoInterfaz.AbrirTD + id + M3_RecursoInterfaz.CerrarTD;
        }
        public void llenarNombreOrg(string nombre)
        {
            this.tabla.Text += M3_RecursoInterfaz.AbrirTD + nombre + M3_RecursoInterfaz.CerrarTD;
        }
        public void llenarEmailOrg(string email)
        {
            this.tabla.Text += M3_RecursoInterfaz.AbrirTD + email + M3_RecursoInterfaz.CerrarTD;
        }
        public void llenarTelefonoOrg(string telefono)
        {
            this.tabla.Text += M3_RecursoInterfaz.AbrirTD + telefono + M3_RecursoInterfaz.CerrarTD;
        }
        public void llenarEstiloOrg(string estilo)
        {
            this.tabla.Text += M3_RecursoInterfaz.AbrirTD + estilo + M3_RecursoInterfaz.CerrarTD;
        }
        public void llenarDireccionOrg(string direccion)
        {
            this.tabla.Text += M3_RecursoInterfaz.AbrirTD + direccion + M3_RecursoInterfaz.CerrarTD;
        }
        public void llenarEstadoOrg(string estado)
        {
            this.tabla.Text += M3_RecursoInterfaz.AbrirTD + estado + M3_RecursoInterfaz.CerrarTD;
        }
        public void llenarBotones(int id)
        {
            this.tabla.Text += M3_RecursoInterfaz.AbrirTD;
            this.tabla.Text += M3_RecursoInterfaz.BotonModificar + id + M3_RecursoInterfaz.BotonCerrar;
        }

        public void llenarStatusActivo(int id)
        {
            this.tabla.Text += M3_RecursoInterfaz.BotonActivarOrg + id + M3_RecursoInterfaz.BotonCerrar;
            this.tabla.Text += M3_RecursoInterfaz.CerrarTD;
            this.tabla.Text += M3_RecursoInterfaz.CerrarTR;
        }

        public void llenarStatusInactivo(int id)
        {
            this.tabla.Text += M3_RecursoInterfaz.BotonDesactivarOrg + id + M3_RecursoInterfaz.BotonCerrar;
            this.tabla.Text += M3_RecursoInterfaz.CerrarTD;
            this.tabla.Text += M3_RecursoInterfaz.CerrarTR;
        }
        #endregion

        protected void CambioDeStatus_Click(object sender, EventArgs e)
        {

        }

        }
    
}