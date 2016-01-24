using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Interfaz_Presentadores.Modulo16;
using ExcepcionesSKD.Modulo16;
using ExcepcionesSKD;
using templateApp.GUI.Master;
using System.Web.UI.HtmlControls;

namespace templateApp.GUI.Modulo16
{
    /// <summary>
    /// Clase parcial que Representa CodeBehind de la interfaz de VerCarrito
    /// </summary>
    public partial class M16_VerCarrito : System.Web.UI.Page, Interfaz_Contratos.Modulo16.IcontratoVerCarrito
    {
        #region Atributos
        //Presentador pertinente que manipulara la vista
        private PresentadorVerCarrito elPresentador;
        #endregion

        #region Propiedades
        /// <summary>
        /// Propiedad de la TablaImplemento
        /// </summary>
        public Table tablaImplemento
        {
            get { return this.TablaImplemento; }
        }

        /// <summary>
        /// Propiedad de la tabla TablaEvento
        /// </summary>
        public Table tablaEvento
        {
            get { return this.TablaEvento; }
        }

        /// <summary>
        /// Propiedad de la tabla TablaMatricula 
        /// </summary>
        public Table tablaMatricula
        {
            get { return this.TablaMatricula; }
        }

        /// <summary>
        /// Propiedad de la LiteralDetallesEventos
        /// </summary>
        public Literal LiteralDetallesEventos
        {
            get { return this.detalleEventoLiteral; }
        }

        /// <summary>
        /// Propiedad de la LiteralDetallesEventos
        /// </summary>
        public Literal LiteralDetallesMensualidades
        {
            get { return this.detalleMensualidadLiteral; }
        }

        /// <summary>
        /// Propiedad de la LiteralDetallesEventos
        /// </summary>
        public Literal LiteralDetallesProductos
        {
            get { return this.detalleProductoLiteral; }
        }

        /// <summary>
        /// Propiedad del Literal del PrecioFinal
        /// </summary>
        public Literal PrecioFinal
        {
            get
            {
                return this.precioFinal;
            }

            set
            {
                this.precioFinal = value;
            }
        }

        /// <summary>
        /// Propiedad del input HTML DatoPago
        /// </summary>
        public HtmlInputText Datospago
        {
            get
            {
                return this.DatoPago;
            }

            set
            {
                this.DatoPago = value;
            }

        }

        /// <summary>
        /// Propiedad del input HTML Monto
        /// </summary>
        public HtmlInputText MontoPago
        {
            get
            {
                return this.Monto;
            }

            set
            {
                this.Monto = value;
            }
        }
        #endregion

        #region Constructores
        /// <summary>
        /// Constructor de la vista de VerCarrito que instancia su presentador;
        /// </summary>
        public M16_VerCarrito()
        {
            this.elPresentador = new PresentadorVerCarrito(this);
        }
        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            //Carga la Barra lateral del modulo indicado
            ((SKD)Page.Master).IdModulo = "16";
           
            //Obtengo el Carrito de la Persona pasandole el ID del session sino hubo ningun error previo
            if (Request.QueryString[M16_RecursoInterfaz.VARIABLE_MENSAJE] == null)
                this.elPresentador.LlenarTabla(Session[RecursosInterfazMaster.sessionUsuarioID].ToString());

            //Nos indica si hubo alguna accion de agregar, modificar o eliminar
            String accion = Request.QueryString[M16_RecursoInterfaz.VARIABLE_ACCION];

            //Revisamos si es alguno de los casos a continuacion
            switch (accion)
            {
                //Si se viene de un modificar obtenemos esta alerta
                case "1":
                    //Obtenemos el exito o fallo del proceso
                    String exito = Request.QueryString[M16_RecursoInterfaz.VARIABLE_EXITO];

                    if (exito.Equals(M16_RecursoInterfaz.VALOR_EXITO))
                    {
                        //Si el modificar fue exitoso mostramos esta alerta
                        alert.Attributes[M16_RecursoInterfaz.VARIABLE_CLASS] = M16_RecursoInterfaz.ALERT_SUCESS;
                        alert.Attributes[M16_RecursoInterfaz.VARIABLE_ROL] = M16_RecursoInterfaz.VALOR_ALERT;
                        alert.InnerHtml = M16_RecursoInterfaz.MODIFICAR_EXITO;
                    }
                    else
                    {
                        //Si el modificar fue fallido mostramos esta alerta
                        alert.Attributes[M16_RecursoInterfaz.VARIABLE_CLASS] = M16_RecursoInterfaz.ALERT_DANGER;
                        alert.Attributes[M16_RecursoInterfaz.VARIABLE_ROL] = M16_RecursoInterfaz.VALOR_ALERT;
                        alert.InnerHtml = M16_RecursoInterfaz.MODIFICAR_FALLO;
                    }
                    break;

                //Si se viene de un RegistrarPago obtenemos esta alerta
                case "2":
                    //Obtenemos el exito o fallo del proceso
                    String exito2 = Request.QueryString[M16_RecursoInterfaz.VARIABLE_EXITO];

                    if (exito2.Equals(M16_RecursoInterfaz.VALOR_EXITO))
                    {
                        //Si el RegistrarPago fue exitoso mostramos esta alerta
                        alert.Attributes[M16_RecursoInterfaz.VARIABLE_CLASS] = M16_RecursoInterfaz.ALERT_SUCESS;
                        alert.Attributes[M16_RecursoInterfaz.VARIABLE_ROL] = M16_RecursoInterfaz.VALOR_ALERT;
                        alert.InnerHtml = M16_RecursoInterfaz.REGISTRAR_PAGO_EXITO;
                    }
                    else
                    {
                        //Si el RegistarPago fue fallido mostramos esta alerta
                        alert.Attributes[M16_RecursoInterfaz.VARIABLE_CLASS] = M16_RecursoInterfaz.ALERT_DANGER;
                        alert.Attributes[M16_RecursoInterfaz.VARIABLE_ROL] = M16_RecursoInterfaz.VALOR_ALERT;
                        alert.InnerHtml = M16_RecursoInterfaz.REGISTRAR_PAGO_FALLO;
                    }
                    break;

                //Si venimos de un AgregarItem obtenemos esta alerta
                case "3":
                    //Obtenemos el exito o fallo del proceso
                    String exito3 = Request.QueryString[M16_RecursoInterfaz.VARIABLE_EXITO];

                    if (exito3.Equals(M16_RecursoInterfaz.VALOR_EXITO))
                    {
                        //Si el RegistrarPago fue exitoso mostramos esta alerta
                        alert.Attributes[M16_RecursoInterfaz.VARIABLE_CLASS] = M16_RecursoInterfaz.ALERT_SUCESS; ;
                        alert.Attributes[M16_RecursoInterfaz.VARIABLE_ROL] = M16_RecursoInterfaz.VALOR_ALERT;
                        alert.InnerHtml = M16_RecursoInterfaz.AGREGAR_ITEM_EXITO;
                    }
                    else
                    {
                        //Si el RegistarPago fue fallido mostramos esta alerta
                        alert.Attributes[M16_RecursoInterfaz.VARIABLE_CLASS] = M16_RecursoInterfaz.ALERT_DANGER;
                        alert.Attributes[M16_RecursoInterfaz.VARIABLE_ROL] = M16_RecursoInterfaz.VALOR_ALERT;
                        alert.InnerHtml = M16_RecursoInterfaz.AGREGAR_ITEM_FALLO;
                    }
                    break;                              
                
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
                            //Si hubo error al modificar de alguna forma un carrito con un pago ya hecho
                            alert.Attributes[M16_RecursoInterfaz.VARIABLE_CLASS] = M16_RecursoInterfaz.ALERT_DANGER;
                            alert.Attributes[M16_RecursoInterfaz.VARIABLE_ROL] = M16_RecursoInterfaz.VALOR_ALERT;
                            alert.InnerHtml = M16_RecursoInterfaz.EXCEPTION_CARRITO_PAGO_MENSAJE;
                            break;

                    }
                    break;

                //Si venimos de un EliminarItem obtenemos esta alerta
                case "5":
                    //Obtenemos el exito o fallo del proceso
                    String exito4 = Request.QueryString[M16_RecursoInterfaz.VARIABLE_EXITO];

                    if (exito4.Equals(M16_RecursoInterfaz.VALOR_EXITO))
                    {
                        //Si el EliminarItem fue exitoso mostramos esta alerta
                        alert.Attributes[M16_RecursoInterfaz.VARIABLE_CLASS] = M16_RecursoInterfaz.ALERT_SUCESS;
                        alert.Attributes[M16_RecursoInterfaz.VARIABLE_ROL] = M16_RecursoInterfaz.VALOR_ALERT;
                        alert.InnerHtml = M16_RecursoInterfaz.ELIMINAR_EXITO;
                    }
                    else
                    {
                        //Si el EliminarItem fue fallido mostramos esta alerta
                        alert.Attributes[M16_RecursoInterfaz.VARIABLE_CLASS] = M16_RecursoInterfaz.ALERT_DANGER;
                        alert.Attributes[M16_RecursoInterfaz.VARIABLE_ROL] = M16_RecursoInterfaz.VALOR_ALERT;
                        alert.InnerHtml = M16_RecursoInterfaz.ELIMINAR_FALLO;
                    }
                    break;
            }
                
        }

        #region EventHandlers
        #region RegistrarPago
        /// <summary>
        /// Metodo que ejecuta el evento de Registrar el Pago de un Carrito en la base de Datos
        /// </summary>
        /// <param name="sender">El objeto que ejecuta el evento</param>
        /// <param name="ev">El tipo de evento que se esta ejecutando</param>        
        protected void RegistrarPago(object sender, EventArgs ev)
        {
            try
            {
                //Ejecuto la operacion para registrar un pago y obtengo la respuesta
                bool respuesta = this.elPresentador.RegistrarPago
                    (Session[RecursosInterfazMaster.sessionUsuarioID].ToString(),
                    Monto.Value, DropDownList1.Value);

                //Obtenemos la respuesta y redireccionamos para mostrar el exito o fallo
                if (respuesta)
                    HttpContext.Current.Response.Redirect(M16_RecursoInterfaz.REGISTRAR_PAGO_EXITOSO, false);
                else
                    HttpContext.Current.Response.Redirect(M16_RecursoInterfaz.REGISTRAR_PAGO_FALLIDO, false);
            }            
            catch (LoggerException e)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, e);               
                HttpContext.Current.Response.Redirect(M16_RecursoInterfaz.EXCEPTION_LOGGER_LINK, false);
            }
            catch(OpcionPagoNoValidoException e)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, e);
                HttpContext.Current.Response.Redirect(M16_RecursoInterfaz.EXCEPTION_LOGGER_LINK, false);
            }
            catch (ParseoVacioException e)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, e);                
                HttpContext.Current.Response.Redirect(M16_RecursoInterfaz.EXCEPTION_PARSEO_VACIO_LINK, false);
            }
            catch (PersonaNoValidaException e)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, e);                
                HttpContext.Current.Response.Redirect(M16_RecursoInterfaz.EXCEPTION_PERSONA_INVALIDA_LINK, false);
            }
            catch (ParseoFormatoInvalidoException e)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, e);                
                HttpContext.Current.Response.Redirect(M16_RecursoInterfaz.EXCEPTION_FORMATO_LINK, false);
            }
            catch (ParseoEnSobrecargaException e)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, e);               
                HttpContext.Current.Response.Redirect(M16_RecursoInterfaz.EXCEPTION_SOBRECARGA_LINK, false);
            }
            catch (ParametroInvalidoException e)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, e);               
                HttpContext.Current.Response.Redirect(M16_RecursoInterfaz.EXCEPTION_PARAMETRO_INVALIDO_LINK, false);
            }
            catch (ExceptionSKDConexionBD e)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, e);               
                HttpContext.Current.Response.Redirect(M16_RecursoInterfaz.EXCEPTION_CONEXIONBD_LINK, false);
            }
            catch (ExceptionSKD e)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, e);               
                HttpContext.Current.Response.Redirect(M16_RecursoInterfaz.EXCEPTIONSKD_LINK, false);
            }
            catch (Exception e)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, e);                
                HttpContext.Current.Response.Redirect(M16_RecursoInterfaz.EXCEPTION_LINK, false);
            }
        }
        #endregion           
        #endregion

        /// <summary>
        /// Metodo que ejecuta el script en el cliente, desde el servidor
        /// </summary>
        public void ejecutarScriptImplemento()
        {
            ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "Test()", "<script type='text/javascript'>$('#modal-info1').modal('toggle');</script>   ", false);
        }

        /// <summary>
        /// Metodo que ejecuta el script en el cliente, desde el servidor
        /// </summary>
        public void ejecutarScriptEvento()
        {
            ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "Test()", "<script type='text/javascript'>$('#modal-info2').modal('toggle');</script>   ", false);
        }

        /// <summary>
        /// Metodo que ejecuta el script en el cliente, desde el servidor
        /// </summary>
        public void ejecutarScriptMensualidad()
        {
            ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "Test()", "<script type='text/javascript'>$('#modal-info3').modal('toggle');</script>   ", false);
        }
    }
}