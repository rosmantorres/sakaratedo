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
            //Carga la Barra lateral del modulo indicado
            ((SKD)Page.Master).IdModulo = "16";

            //Incio el Presentador 
            this.IniciarPresentador();

            //Obtengo la matricula de la Persona pasandole el ID del session sino hubo ningun error previo
            if (Request.QueryString[M16_RecursoInterfaz.VARIABLE_MENSAJE] == null)
                presentador.consultarProductos(int.Parse(Session[RecursosInterfazMaster.sessionUsuarioID].ToString()));

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

                        case "14":
                            //Si la lista retorna vacia no muestra elementos en el listar
                            alert.Attributes[M16_RecursoInterfaz.VARIABLE_CLASS] = M16_RecursoInterfaz.ALERT_DANGER;
                            alert.Attributes[M16_RecursoInterfaz.VARIABLE_ROL] = M16_RecursoInterfaz.VALOR_ALERT;
                            alert.InnerHtml = M16_RecursoInterfaz.EXCEPCION_LISTA_VACIA_PROD_MENSAJE;
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
            // Llamada para llenar el modal
            ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), M16_RecursoInterfaz.Test, M16_RecursoInterfaz.Script, false);
        }
        #endregion

    }
}