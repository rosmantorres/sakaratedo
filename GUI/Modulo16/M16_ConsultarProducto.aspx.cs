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
    public partial class M16_ConsultarProducto : System.Web.UI.Page, Interfaz_Contratos.Modulo16.IContratoListarProducto
    {
        #region Atributos
        private PresentadorListarProducto presentador;
        #endregion

        #region Constructores
        public void IniciarPresentador()
        {
            presentador = new PresentadorListarProducto(this);
        }
        #endregion

        #region Propiedades de la Interfaz

        /// <summary>
        /// Propiedad de la tablaProductos
        /// </summary>
        public Table tablaProductos
        {
            get { return this.tablitaProductos; }
        }

        /// <summary>
        /// Propiedad de la tablaDetalleProductos
        /// </summary>
        public Literal tablaDetalleProductos
        {
            get { return this.detalleProductoLiteral; }
        }

        /// <summary>
        /// Propiedad de la TablaListaProductos
        /// </summary>
        public Table TablaListaProductos
        {
            get { return this.tablitaProductos; }
        }

        /// <summary>
        /// Propiedad de la LiteralDetallesProductos
        /// </summary>
        public Literal LiteralDetallesProductos
        {
            get { return this.detalleProductoLiteral; }
        }

        #endregion

        #region Metodos

        /// <summary>
        /// Metodo para iniciar las llamadas 
        /// </summary>
        protected void Page_Load(object sender, EventArgs e)
        {

            this.IniciarPresentador();
            presentador.consultarProductos();

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