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
    public partial class M16_ConsultarMensualidad : System.Web.UI.Page, Interfaz_Contratos.Modulo16.IContratoListarMensualidad
    {
        #region Atributos
        private PresentadorListarMensualidad presentador;
        #endregion

        #region Constructores
        public void IniciarPresentador()
        {
            presentador = new PresentadorListarMensualidad(this);
        }
        #endregion

        #region Propiedades de la Interfaz

        /// <summary>
        /// Propiedad de la tablaMensualidades
        /// </summary>
        public Table tablaMensualidades
        {
            get { return this.tablitaMensualidades; }
        }

        /// <summary>
        /// Propiedad de la tablaDetalleMensualidades
        /// </summary>
        public Literal tablaDetalleMensualidades
        {
            get { return this.detalleMensualidadLiteral; }
        }

        /// <summary>
        /// Propiedad de la TablaListaMensualidades
        /// </summary>
        public Table TablaListaMensualidades
        {
            get { return this.tablitaMensualidades; }
        }

        /// <summary>
        /// Propiedad de la LiteralDetallesMensualidades
        /// </summary>
        public Literal LiteralDetallesMensualidades
        {
            get { return this.detalleMensualidadLiteral; }
        }

        #endregion

        #region Metodos

        /// <summary>
        /// Metodo para iniciar las llamadas 
        /// </summary>
        protected void Page_Load(object sender, EventArgs e)
        {
            //Carga la Barra lateral del modulo indicado
            ((SKD)Page.Master).IdModulo = "16";

            //Obtengo el id de la Persona pasandole el ID del session
            this.IniciarPresentador();
            presentador.consultarMensualidades(int.Parse(Session[RecursosInterfazMaster.sessionUsuarioID].ToString()));
         
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