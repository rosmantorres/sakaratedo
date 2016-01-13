using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Interfaz_Contratos.Modulo16;
using Interfaz_Presentadores.Modulo16;
using templateApp.GUI.Master;


namespace templateApp.GUI.Modulo16
{
    public partial class M16_ListarFacturas : System.Web.UI.Page, Interfaz_Contratos.Modulo16.IContratoListarFactura
    {
        #region Atributos
        private PresentadorListarFactura presentador;
        #endregion

        #region Constructores
        public void IniciarPresentador()
        {
            presentador = new PresentadorListarFactura(this);
        }
        #endregion

        #region Propiedades de la Interfaz

        /// <summary>
        /// Propiedad de la tablaFacturas
        /// </summary>
        public Table tablaFacturas
        {
            get { return this.tablitaFacturas; }
        }

        /// <summary>
        /// Propiedad de la TablaListaMensualidades
        /// </summary>
        public Table TablaListaFacturas
        {
            get { return this.tablitaFacturas; }
        }

        /// <summary>
        /// Propiedad de la LiteralDetallesFacturas
        /// </summary>
        public Literal LiteralDetallesFacturas
        {
            get { return this.detalleFacturaLiteral; }
        }

        #endregion

        #region Metodos

        /// <summary>
        /// Metodo para iniciar las llamadas 
        /// </summary>
        protected void Page_Load(object sender, EventArgs e)
        {

            this.IniciarPresentador();
            presentador.consultarFacturas(int.Parse(Session[RecursosInterfazMaster.sessionUsuarioID].ToString()));

            /* this.Master.ID = "16";
             this.Master.presentador.CargarMenuLateral();
             presentador.ObtenerVariablesURL();*/
        }


        /// <summary>
        /// Metodo que ejecuta el script en el cliente, desde el servidor
        /// </summary>
        public void ejecutarScript()
        {
            ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "Test()", "<script type='text/javascript'>$('#modal-info1').modal('toggle');</script>   ", false);
        }
        #endregion
    }
}