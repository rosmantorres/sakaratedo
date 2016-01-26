using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Interfaz_Contratos.Modulo16;
using Interfaz_Presentadores.Modulo16;
using templateApp.GUI.Master;
using ExcepcionesSKD.Modulo16;
using ExcepcionesSKD;

namespace templateApp.GUI.Modulo16
{
    public partial class M16_ConsultarEvento : System.Web.UI.Page, Interfaz_Contratos.Modulo16.IContratoListarEvento
    {
        #region Atributos
        private PresentadorListarEvento presentador;
        #endregion

        #region Constructores
        public void IniciarPresentador()
        {
            presentador = new PresentadorListarEvento(this);
        }
        #endregion

        #region Propiedades de la Interfaz

        /// <summary>
        /// Propiedad de la tablaEventos
        /// </summary>
        public Table tablaEventos
        {
            get { return this.tablitaEventos;}
        }

        /// <summary>
        /// Propiedad de la tablaDetalleEventos
        /// </summary>
        public Literal tablaDetalleEventos
        {
            get { return this.detalleEventoLiteral; }
        }

        /// <summary>
        /// Propiedad de la TablaListaEventos
        /// </summary>
        public Table TablaListaEventos
        {
            get { return this.tablitaEventos; }
        }

        /// <summary>
        /// Propiedad de la LiteralDetallesEventos
        /// </summary>
        public Literal LiteralDetallesEventos
        {
            get { return this.detalleEventoLiteral; }
        }

        #endregion

        #region Metodos

        /// <summary>
        /// Metodo para iniciar las llamadas 
        /// </summary>
        protected void Page_Load(object sender, EventArgs e)
        {
            //Carga la Barra lateral del modulo indicado
            ((SKD)Page.Master).IdModulo = M16_RecursoInterfaz.Modulo16;

            try
            {
                //inicio el presentador
                this.IniciarPresentador();

                //Obtengo el evento de la Persona pasandole el ID del session sino hubo ningun error previo
                if (Request.QueryString[M16_RecursoInterfaz.VARIABLE_MENSAJE] == null)
                    presentador.consultarEventos(int.Parse(Session[RecursosInterfazMaster.sessionUsuarioID].ToString()));

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
                                alert.InnerHtml = M16_RecursoInterfaz.EXCEPCION_LISTA_VACIA_MENSAJE;
                                break;
                        }
                        break;
                }
            }
            catch (PersonaNoValidaException ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                HttpContext.Current.Response.Redirect(M16_RecursoInterfaz.EXCEPTION_PERSONA_INVALIDA_LINK);
            }
            catch (LoggerException ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                HttpContext.Current.Response.Redirect(M16_RecursoInterfaz.EXCEPTION_LOGGER_LINK);

            }
            catch (ParseoVacioException ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                HttpContext.Current.Response.Redirect(M16_RecursoInterfaz.EXCEPTION_PARSEO_VACIO_LINK);
            }
            catch (ParseoFormatoInvalidoException ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                HttpContext.Current.Response.Redirect(M16_RecursoInterfaz.EXCEPTION_FORMATO_LINK);

            }
            catch (ParseoEnSobrecargaException ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                HttpContext.Current.Response.Redirect(M16_RecursoInterfaz.EXCEPTION_SOBRECARGA_LINK);

            }
            catch (ParametroInvalidoException ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                HttpContext.Current.Response.Redirect(M16_RecursoInterfaz.EXCEPTION_PARAMETRO_INVALIDO_LINK);
            }
            catch (ExceptionSKDConexionBD ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                HttpContext.Current.Response.Redirect(M16_RecursoInterfaz.EXCEPTION_CONEXIONBD_LINK);

            }
            catch (ExceptionSKD ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                HttpContext.Current.Response.Redirect(M16_RecursoInterfaz.EXCEPTIONSKD_LINK);

            }
            catch (Exception ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                HttpContext.Current.Response.Redirect(M16_RecursoInterfaz.EXCEPTION_LINK);
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