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

        public Table tablaDetalleProductos
        {
            get { return this.tablaDetallesProductos; }
        }

        public Table tablaDetalleEventos
        {
            get { return this.tablaDetallesEventos; }
        }

        public Table tablaDetalleMatriculas
        {
            get { return this.tablaDetallesMatriculas; }
        }

        public Table tablaDetalleDatos
        {
            get { return this.tablaDetallesDatos; }
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
            //Carga la Barra lateral del modulo indicado
            ((SKD)Page.Master).IdModulo = "16";

            //Inicio el presentador
            this.IniciarPresentador();

            //Obtengo la matricula de la Persona pasandole el ID del session sino hubo ningun error previo
            if (Request.QueryString[M16_RecursoInterfaz.VARIABLE_MENSAJE] == null)
                presentador.consultarFacturas(int.Parse(Session[RecursosInterfazMaster.sessionUsuarioID].ToString()), Server);

            //Nos indica si se pudo listar
            String accion = Request.QueryString[M16_RecursoInterfaz.VARIABLE_ACCION];

            //Revisamos si es alguno de los casos a continuacion
            switch (accion)
            {
                //Si se sucita algun error obtendremos la alerta correspondiente
                case "4":
                    //Obtenemos el tipo de error sucitado
                    String error = Request.QueryString[M16_RecursoInterfaz.VARIABLE_MENSAJE];

                    switch (error)
                    {
                        case "1":
                            //Si ocurrio algun error no contemplado de ninguna manera se mostrara este mensaje
                            alert.Attributes[M16_RecursoInterfaz.VARIABLE_CLASS] = M16_RecursoInterfaz.ALERT_DANGER;
                            alert.Attributes[M16_RecursoInterfaz.VARIABLE_ROL] = M16_RecursoInterfaz.VALOR_ALERT;
                            alert.InnerHtml = M16_RecursoInterfaz.EXCEPTION_MENSAJE;
                            break;

                        case "2":
                            //Si ocurrio algun error inesperado que fue manejado se mostrara este mensaje
                            alert.Attributes[M16_RecursoInterfaz.VARIABLE_CLASS] = M16_RecursoInterfaz.ALERT_DANGER;
                            alert.Attributes[M16_RecursoInterfaz.VARIABLE_ROL] = M16_RecursoInterfaz.VALOR_ALERT;
                            alert.InnerHtml = M16_RecursoInterfaz.EXCEPTIONSKD_MENSAJE;
                            break;

                        case "3":
                            //Si hubo un error al ejecutar una operacion en la Base de Datos se mostrara esta alerta
                            alert.Attributes[M16_RecursoInterfaz.VARIABLE_CLASS] = M16_RecursoInterfaz.ALERT_DANGER;
                            alert.Attributes[M16_RecursoInterfaz.VARIABLE_ROL] = M16_RecursoInterfaz.VALOR_ALERT;
                            alert.InnerHtml = M16_RecursoInterfaz.EXCEPTIONSKD_CONEXIONBD_MENSAJE;
                            break;

                        case "4":
                            //Si hubo un error en un parametro hacia un stored procedure se mostrara esta alerta
                            alert.Attributes[M16_RecursoInterfaz.VARIABLE_CLASS] = M16_RecursoInterfaz.ALERT_DANGER;
                            alert.Attributes[M16_RecursoInterfaz.VARIABLE_ROL] = M16_RecursoInterfaz.VALOR_ALERT;
                            alert.InnerHtml = M16_RecursoInterfaz.EXCEPTION_PARAMETRO_MENSAJE;
                            break;

                        case "5":
                            //Si hubo un error al parsear un atributo con sobrecarga de informacion
                            alert.Attributes[M16_RecursoInterfaz.VARIABLE_CLASS] = M16_RecursoInterfaz.ALERT_DANGER;
                            alert.Attributes[M16_RecursoInterfaz.VARIABLE_ROL] = M16_RecursoInterfaz.VALOR_ALERT;
                            alert.InnerHtml = M16_RecursoInterfaz.EXCEPTION_SOBRECARGA_MENSAJE;
                            break;

                        case "6":
                            //Si hubo un error al parsear un atributo con un formato no valido (no es int)
                            alert.Attributes[M16_RecursoInterfaz.VARIABLE_CLASS] = M16_RecursoInterfaz.ALERT_DANGER;
                            alert.Attributes[M16_RecursoInterfaz.VARIABLE_ROL] = M16_RecursoInterfaz.VALOR_ALERT;
                            alert.InnerHtml = M16_RecursoInterfaz.EXCEPTION_FORMATO_MENSAJE;
                            break;

                        case "7":
                            //Si hubo un error al parsear un atributo que es vacio (NULL)
                            alert.Attributes[M16_RecursoInterfaz.VARIABLE_CLASS] = M16_RecursoInterfaz.ALERT_DANGER;
                            alert.Attributes[M16_RecursoInterfaz.VARIABLE_ROL] = M16_RecursoInterfaz.VALOR_ALERT;
                            alert.InnerHtml = M16_RecursoInterfaz.EXCEPTION_VACIO_MENSAJE;
                            break;

                        case "8":
                            //Si hubo un error con el logger
                            alert.Attributes[M16_RecursoInterfaz.VARIABLE_CLASS] = M16_RecursoInterfaz.ALERT_DANGER;
                            alert.Attributes[M16_RecursoInterfaz.VARIABLE_ROL] = M16_RecursoInterfaz.VALOR_ALERT;
                            alert.InnerHtml = M16_RecursoInterfaz.EXCEPTION_LOGGER_MENSAJE;
                            break;

                        case "9":
                            //Si hubo error al pasar una persona no valida
                            alert.Attributes[M16_RecursoInterfaz.VARIABLE_CLASS] = M16_RecursoInterfaz.ALERT_DANGER;
                            alert.Attributes[M16_RecursoInterfaz.VARIABLE_ROL] = M16_RecursoInterfaz.VALOR_ALERT;
                            alert.InnerHtml = M16_RecursoInterfaz.EXCEPTION_PERSONA_MENSAJE;
                            break;

                        case "10":
                            //Si hubo error al pasar un item que no es el que se indica
                            alert.Attributes[M16_RecursoInterfaz.VARIABLE_CLASS] = M16_RecursoInterfaz.ALERT_DANGER;
                            alert.Attributes[M16_RecursoInterfaz.VARIABLE_ROL] = M16_RecursoInterfaz.VALOR_ALERT;
                            alert.InnerHtml = M16_RecursoInterfaz.EXCEPTION_ITEM_INVALIDO_MENSAJE;
                            break;

                        case "11":
                            //Si hubo error al indicar un tipo de item que no existe
                            alert.Attributes[M16_RecursoInterfaz.VARIABLE_CLASS] = M16_RecursoInterfaz.ALERT_DANGER;
                            alert.Attributes[M16_RecursoInterfaz.VARIABLE_ROL] = M16_RecursoInterfaz.VALOR_ALERT;
                            alert.InnerHtml = M16_RecursoInterfaz.EXCEPTION_ITEM_INEXISTENTE_MENSAJE;
                            break;

                        case "12":
                            //Si hubo error al seleccionar un tipo de pago no admitido para las compras
                            alert.Attributes[M16_RecursoInterfaz.VARIABLE_CLASS] = M16_RecursoInterfaz.ALERT_DANGER;
                            alert.Attributes[M16_RecursoInterfaz.VARIABLE_ROL] = M16_RecursoInterfaz.VALOR_ALERT;
                            alert.InnerHtml = M16_RecursoInterfaz.EXCEPTION_PAGOINVALIDO_MENSAJE;
                            break;

                        case "13":
                            //Si hubo error al introducir una cantidad deseada no valida
                            alert.Attributes[M16_RecursoInterfaz.VARIABLE_CLASS] = M16_RecursoInterfaz.ALERT_DANGER;
                            alert.Attributes[M16_RecursoInterfaz.VARIABLE_ROL] = M16_RecursoInterfaz.VALOR_ALERT;
                            alert.InnerHtml = M16_RecursoInterfaz.EXCEPTION_CANTIDAD_INVALIDA_MENSAJE;
                            break;
                    }
                    break;
            }
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