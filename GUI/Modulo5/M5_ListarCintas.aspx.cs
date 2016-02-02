using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using DominioSKD;
using Interfaz_Contratos.Modulo5;
using Interfaz_Presentadores.Modulo5;

namespace templateApp.GUI.Modulo5
{
    public partial class M5_ListarCintas : System.Web.UI.Page, IContratoListarCintas
    {


        private PresentadorLlenarCintas presentador;

        protected void Page_Load(object sender, EventArgs e)
        {
            ((SKD)Page.Master).IdModulo = "5";

            this.presentador = new PresentadorLlenarCintas(this);
            if (!IsPostBack)
            {
                this.presentador.llenarComboOrganizacion();            
               //this.presentador.LlenarInformacion();
            }
           
        } 

       #region IContratos
        public void llenarId(string id)
        {
            this.tabla.Text += RecursoInterfazMod5.AbrirTR;
            this.tabla.Text += RecursoInterfazMod5.AbrirTD + id + RecursoInterfazMod5.CerrarTD;
        }

        public void llenarColorNombre(string colorNombre)
        {
            this.tabla.Text += RecursoInterfazMod5.AbrirTD + colorNombre + RecursoInterfazMod5.CerrarTD;
        }

        public void llenarRango(string rango)
        {
            this.tabla.Text += RecursoInterfazMod5.AbrirTD + rango + RecursoInterfazMod5.CerrarTD;
        }
        public void llenarClasificacion(string clasificacion)
        {
            this.tabla.Text += RecursoInterfazMod5.AbrirTD + clasificacion + RecursoInterfazMod5.CerrarTD;
        }
        public void llenarSignificado(string significado)
        {
            this.tabla.Text += RecursoInterfazMod5.AbrirTD + significado + RecursoInterfazMod5.CerrarTD;
        }
        public void llenarOrden(int orden)
        {
            this.tabla.Text += RecursoInterfazMod5.AbrirTD + orden + RecursoInterfazMod5.CerrarTD;
        }
        public void llenarOrganizacion(string organizacion)
        {
            this.tabla.Text += RecursoInterfazMod5.AbrirTD + organizacion + RecursoInterfazMod5.CerrarTD;
        }

        public void llenarBotones(int id)
        {
            this.tabla.Text += RecursoInterfazMod5.AbrirTD;
            this.tabla.Text += RecursoInterfazMod5.BotonModificar + id + RecursoInterfazMod5.BotonCerrar;
        }

        public void llenarStatusActivo(int id)
        {
            this.tabla.Text += RecursoInterfazMod5.BotonActivarCin + id + RecursoInterfazMod5.BotonCerrar;
            this.tabla.Text += RecursoInterfazMod5.CerrarTD;
            this.tabla.Text += RecursoInterfazMod5.CerrarTR;
        }

        public void llenarStatusInactivo(int id)
        {
            this.tabla.Text += RecursoInterfazMod5.BotonDesactivarCin + id + RecursoInterfazMod5.BotonCerrar;
            this.tabla.Text += RecursoInterfazMod5.CerrarTD;
            this.tabla.Text += RecursoInterfazMod5.CerrarTR;
        }
        public int obtenerIdCinta
        {
            get { return Int32.Parse(this.cintaIdStatus.Value); }
        }
        public int obtenerStatusCinta
        {
            get { return Int32.Parse(this.estatusActual.Value); }
        }
        public string obtenerNombreOrg
        {
            get { return this.nombreOrg.Value; }
        }
        public void agregarOrganizacionCombo(string id, string nombre)
        {
            this.listaOrg.Items.Add(new ListItem(nombre, id));
        }
        public string obtenerIdOrg
        {
            get { return this.listaOrg.SelectedValue; }
        }
        #endregion

        protected void organizacionSeleccionada(object sender, EventArgs e)
        {
            this.presentador.LlenarInformacion();    
        }

        protected void cambiarStatus(object sender, EventArgs e)
        {
            this.presentador.cambiarStatus();
            this.Response.Redirect(Request.RawUrl);
        }


    }
}