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

        /// <summary>
        /// Metodo que ejecuta el evento de Registrar el Pago de un Carrito en la base de Datos
        /// </summary>
        /// <param name="sender">El objeto que ejecuta el evento</param>
        /// <param name="ev">El tipo de evento que se esta ejecutando</param>        
        protected void RegistrarPago(object sender, EventArgs ev)
        {
            try
            {
                //Valor que esta seleccionado en el combobox del tipo de pago
                String pago = DropDownList1.Value;

                //Pago que finalmente se enviara a Base de Datos y respuesta de ella
                String pagofinal = null;
                bool respuesta = false;

                //Obtengo el Valor del combobox y le añado su correspondiente tipo de pago
                switch (pago)
                {
                    case "1":
                        pagofinal = M16_RecursoInterfaz.TIPO_PAGO_TARJETA;
                        break;

                    case "2":
                        pagofinal = M16_RecursoInterfaz.TIPO_PAGO_DEPOSITO;
                        break;

                    case "3":
                        pagofinal = M16_RecursoInterfaz.TIPO_PAGO_TRANSFERENCIA;
                        break;                    
                }

                //Ejecuto la operacion siempre y cuando el tipo de pago sea uno valido
                if (pagofinal != null)
                    respuesta = this.elPresentador.RegistrarPago(
                    Session[RecursosInterfazMaster.sessionUsuarioID].ToString(), pago);                

                //Obtenemos la respuesta y redireccionamos para mostrar el exito o fallo
                if (respuesta)
                    HttpContext.Current.Response.Redirect(M16_RecursoInterfaz.REGISTRAR_PAGO_EXITOSO);
                else
                    HttpContext.Current.Response.Redirect(M16_RecursoInterfaz.REGISTRAR_PAGO_FALLIDO);
            }            
            catch (LoggerException e)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, e);               
                HttpContext.Current.Response.Redirect("M16_VerCarrito.aspx?accion=4&mensaje=8", false);
            }
            catch (ParseoVacioException e)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, e);                
                HttpContext.Current.Response.Redirect("M16_VerCarrito.aspx?accion=4&mensaje=7", false);
            }
            catch (PersonaNoValidaException e)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, e);                
                HttpContext.Current.Response.Redirect("M16_VerCarrito.aspx?accion=4&mensaje=9", false);
            }
            catch (ParseoFormatoInvalidoException e)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, e);                
                HttpContext.Current.Response.Redirect("M16_VerCarrito.aspx?accion=4&mensaje=6", false);
            }
            catch (ParseoEnSobrecargaException e)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, e);               
                HttpContext.Current.Response.Redirect("M16_VerCarrito.aspx?accion=4&mensaje=5", false);
            }
            catch (ParametroInvalidoException e)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, e);               
                HttpContext.Current.Response.Redirect("M16_VerCarrito.aspx?accion=4&mensaje=4", false);
            }
            catch (ExceptionSKDConexionBD e)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, e);               
                HttpContext.Current.Response.Redirect("M16_VerCarrito.aspx?accion=4&mensaje=3", false);
            }
            catch (ExceptionSKD e)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, e);               
                HttpContext.Current.Response.Redirect("M16_VerCarrito.aspx?accion=4&mensaje=2", false);
            }
            catch (Exception e)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, e);                
                HttpContext.Current.Response.Redirect("M16_VerCarrito.aspx?accion=4&mensaje=1", false);
            }
        }

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