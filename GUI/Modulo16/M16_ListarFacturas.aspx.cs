using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Interfaz_Contratos.Modulo16;
using Interfaz_Presentadores.Modulo16;


namespace templateApp.GUI.Modulo16
{
    public partial class M16_ListarFacturas : System.Web.UI.Page, Interfaz_Contratos.Modulo16.IContratoListarFactura
    {
        private PresentadorListarFactura presentador;

        public void IniciarPresentador()
        {
            presentador = new PresentadorListarFactura(this);
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            /* this.Master.ID = "16";
             this.Master.presentador.CargarMenuLateral();
             presentador.ObtenerVariablesURL();*/
            if (!IsPostBack)
            {
                this.IniciarPresentador();
                presentador.consultarFacturas(1);
            }
        }

        public Literal tablaFacturas
        {

            get
            {
                return this.tlTablaFacturas;
            }
        }
    }
}