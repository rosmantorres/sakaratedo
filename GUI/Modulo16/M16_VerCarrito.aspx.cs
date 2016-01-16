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

            String prueba = Request.QueryString["mensaje"];
            //Obtengo el Carrito de la Persona pasandole el ID del session
            //if (Request.QueryString["mensaje"] != null || Request.QueryString["mensaje"] != "")
                this.elPresentador.LlenarTabla(Session[RecursosInterfazMaster.sessionUsuarioID].ToString());

            //Nos indica si hubo alguna accion de agregar, modificar o eliminar
            String accion = Request.QueryString["accion"];

            //Revisamos si es alguno de los casos a continuacion
            switch (accion)
            {
                //Si se viene de un modificar obtenemos esta alerta
                case "1":
                    //Obtenemos el exito o fallo del proceso
                    String exito = Request.QueryString["exito"];

                    if (exito.Equals("1"))
                    {
                        //Si el modificar fue exitoso mostramos esta alerta
                        alert.Attributes["class"] = "alert alert-success alert-dismissible";
                        alert.Attributes["role"] = "alert";
                        alert.InnerHtml = "<div><button type=\"button\" class=\"close\" data-dismiss=\"alert\"" +
                            " aria-la" + "bel=\"Close\"><span aria-hidden=\"true\">&times;</span></button>" +
                            "Cantidad modificada exitosamente</div>";
                    }
                    else
                    {
                        //Si el modificar fue fallido mostramos esta alerta
                        alert.Attributes["class"] = "alert alert-danger alert-dismissible";
                        alert.Attributes["role"] = "alert";
                        alert.InnerHtml = "<div><button type=\"button\" class=\"close\" data-dismiss=\"alert\"" +
                            " aria-label=\"Close\"><span aria-hidden=\"true\">&times;</span></button>" +
                            "No existe tal cantidad en el inventario</div>";
                    }
                    break;

                //Si se viene de un RegistrarPago obtenemos esta alerta
                case "2":
                    //Obtenemos el exito o fallo del proceso
                    String exito2 = Request.QueryString["exito"];

                    if (exito2.Equals("1"))
                    {
                        //Si el RegistrarPago fue exitoso mostramos esta alerta
                        alert.Attributes["class"] = "alert alert-success alert-dismissible";
                        alert.Attributes["role"] = "alert";
                        alert.InnerHtml = "<div><button type=\"button\" class=\"close\" data-dismiss=\"alert\"" +
                            " aria-la" + "bel=\"Close\"><span aria-hidden=\"true\">&times;</span></button>" +
                            "Se ha procesado el pago exitosamente, ¡Que disfrute sus productos!</div>";
                    }
                    else
                    {
                        //Si el RegistarPago fue fallido mostramos esta alerta
                        alert.Attributes["class"] = "alert alert-danger alert-dismissible";
                        alert.Attributes["role"] = "alert";
                        alert.InnerHtml = "<div><button type=\"button\" class=\"close\" data-dismiss=\"alert\"" +
                            " aria-la" + "bel=\"Close\"><span aria-hidden=\"true\">&times;</span></button>" +
                            "Su compra no ha podido ser procesada, no existe esa cantidad de implementos" +
                            "Disponibles </div>";
                    }
                    break;

                //Si venimos de un AgregarItem obtenemos esta alerta
                case "3":
                    //Obtenemos el exito o fallo del proceso
                    String exito3 = Request.QueryString["exito"];

                    if (exito3.Equals("1"))
                    {
                        //Si el RegistrarPago fue exitoso mostramos esta alerta
                        alert.Attributes["class"] = "alert alert-success alert-dismissible";
                        alert.Attributes["role"] = "alert";
                        alert.InnerHtml = "<div><button type=\"button\" class=\"close\" data-dismiss=\"alert\"" +
                            " aria-la" + "bel=\"Close\"><span aria-hidden=\"true\">&times;</span></button>" +
                            "El producto se ha agregado exitosamente</div>";
                    }
                    else
                    {
                        //Si el RegistarPago fue fallido mostramos esta alerta
                        alert.Attributes["class"] = "alert alert-danger alert-dismissible";
                        alert.Attributes["role"] = "alert";
                        alert.InnerHtml = "<div><button type=\"button\" class=\"close\" data-dismiss=\"alert\"" +
                            " aria-la" + "bel=\"Close\"><span aria-hidden=\"true\">&times;</span></button>" +
                            " Su producto no ha podido ser agregado, si ha querido agregar implementos" + 
                            " la cantidad deseada no existe en el inventario actualmente</div>";
                    }
                    break;                              
                
                //Si se sucita algun error obtendremos la alerta correspondiente
                case "4":
                    //Obtenemos el exito o fallo del proceso
                    String error = Request.QueryString["mensaje"];

                    switch (error)
                    {
                        case "1":
                            //Si ocurrio algun error no contemplado de ninguna manera se mostrara este mensaje
                            alert.Attributes["class"] = "alert alert-danger alert-dismissible";
                            alert.Attributes["role"] = "alert";
                            alert.InnerHtml = "<div><button type=\"button\" class=\"close\" data-dismiss=\"alert\"" +
                                " aria-la" + "bel=\"Close\"><span aria-hidden=\"true\">&times;</span></button>" +
                                " Se ha producido un error inesperado en el sistema, trate de ejecutar su operacion" +
                                " mas tarde y si el problema persiste comuniquese con nosotros</div>";
                            break;

                        case "2":
                            //Si ocurrio algun error inesperado que fue manejado se mostrara este mensaje
                            alert.Attributes["class"] = "alert alert-danger alert-dismissible";
                            alert.Attributes["role"] = "alert";
                            alert.InnerHtml = "<div><button type=\"button\" class=\"close\" data-dismiss=\"alert\"" +
                                " aria-la" + "bel=\"Close\"><span aria-hidden=\"true\">&times;</span></button>" +
                                " Se ha producido un conflicto en su operacion, trate de ejecutarla" +
                                " mas tarde y si el problema persiste comuniquese con nosotros</div>";
                            break;

                        case "3":
                            //Si hubo un error al ejecutar una operacion en la Base de Datos se mostrara esta alerta
                            alert.Attributes["class"] = "alert alert-danger alert-dismissible";
                            alert.Attributes["role"] = "alert";
                            alert.InnerHtml = "<div><button type=\"button\" class=\"close\" data-dismiss=\"alert\"" +
                                " aria-la" + "bel=\"Close\"><span aria-hidden=\"true\">&times;</span></button>" +
                                " Se ha producido un error en la Base de Datos, intente ejecutar la accion que desea" +
                                " mas tarde</div>";
                            break;

                        case "4":
                            //Si hubo un error en un parametro hacia un stored procedure se mostrara esta alerta
                            alert.Attributes["class"] = "alert alert-danger alert-dismissible";
                            alert.Attributes["role"] = "alert";
                            alert.InnerHtml = "<div><button type=\"button\" class=\"close\" data-dismiss=\"alert\"" +
                                " aria-la" + "bel=\"Close\"><span aria-hidden=\"true\">&times;</span></button>" +
                                " Se ha producido un error al enviar informacion a la Base de Datos, intente" +
                                " ejecutar la accion que desea mas tarde</div>";
                            break;

                        case "5":
                            //Si hubo un error al parsear un atributo con sobrecarga de informacion
                            alert.Attributes["class"] = "alert alert-danger alert-dismissible";
                            alert.Attributes["role"] = "alert";
                            alert.InnerHtml = "<div><button type=\"button\" class=\"close\" data-dismiss=\"alert\"" +
                                " aria-la" + "bel=\"Close\"><span aria-hidden=\"true\">&times;</span></button>" +
                                " Se ha producido un error al manipular datos con mucha informacion, intente" +
                                " ejecutar la accion que desea mas tarde</div>";
                            break;

                        case "6":
                            //Si hubo un error al parsear un atributo con un formato no valido (no es int)
                            alert.Attributes["class"] = "alert alert-danger alert-dismissible";
                            alert.Attributes["role"] = "alert";
                            alert.InnerHtml = "<div><button type=\"button\" class=\"close\" data-dismiss=\"alert\"" +
                                " aria-la" + "bel=\"Close\"><span aria-hidden=\"true\">&times;</span></button>" +
                                " Se ha producido un error al manipular datos que no tienen formatos numericos," +
                                " intente ejecutar la accion que desea mas tarde</div>";
                            break;

                        case "7":
                            //Si hubo un error al parsear un atributo que es vacio (NULL)
                            alert.Attributes["class"] = "alert alert-danger alert-dismissible";
                            alert.Attributes["role"] = "alert";
                            alert.InnerHtml = "<div><button type=\"button\" class=\"close\" data-dismiss=\"alert\"" +
                                " aria-la" + "bel=\"Close\"><span aria-hidden=\"true\">&times;</span></button>" +
                                " Se ha producido un error al manipular datos que son inexistentes o no contienen" +
                                " informacion, intente ejecutar la accion que desea mas tarde</div>";
                            break;

                        case "8":
                            //Si hubo un error con el logger
                            alert.Attributes["class"] = "alert alert-danger alert-dismissible";
                            alert.Attributes["role"] = "alert";
                            alert.InnerHtml = "<div><button type=\"button\" class=\"close\" data-dismiss=\"alert\"" +
                                " aria-la" + "bel=\"Close\"><span aria-hidden=\"true\">&times;</span></button>" +
                                " Se ha producido un error interno al mantener el seguimiento de las operaciones," +
                                " si su operacion no fue ejecutada, intente realizarla mas tarde</div>";
                            break;                        

                        case "9":
                            //Si hubo error al pasar una persona no valida
                            alert.Attributes["class"] = "alert alert-danger alert-dismissible";
                            alert.Attributes["role"] = "alert";
                            alert.InnerHtml = "<div><button type=\"button\" class=\"close\" data-dismiss=\"alert\"" +
                                " aria-la" + "bel=\"Close\"><span aria-hidden=\"true\">&times;</span></button>" +
                                " Se ha producido un error al intentar obtener sus datos de usuario," +
                                " Se recomienda volver a ingresar al sistema</div>";
                            break;

                        case "10":
                            //Si hubo error al pasar un item que no es el que se indica
                            alert.Attributes["class"] = "alert alert-danger alert-dismissible";
                            alert.Attributes["role"] = "alert";
                            alert.InnerHtml = "<div><button type=\"button\" class=\"close\" data-dismiss=\"alert\"" +
                                " aria-la" + "bel=\"Close\"><span aria-hidden=\"true\">&times;</span></button>" +
                                " Se ha producido un error al intentar procesar un item no valido para esta ventana," +
                                " intente su operacion de nuevo mas tarde</div>";
                            break;

                        case "11":
                            //Si hubo error al indicar un tipo de item que no existe
                            alert.Attributes["class"] = "alert alert-danger alert-dismissible";
                            alert.Attributes["role"] = "alert";
                            alert.InnerHtml = "<div><button type=\"button\" class=\"close\" data-dismiss=\"alert\"" +
                                " aria-la" + "bel=\"Close\"><span aria-hidden=\"true\">&times;</span></button>" +
                                " Se ha producido un error al intentar procesar un item no existente," +
                                " intente su operacion mas tarde</div>";
                            break;
                    }
                    break;

                //Si venimos de un EliminarItem obtenemos esta alerta
                case "5":
                    //Obtenemos el exito o fallo del proceso
                    String exito4 = Request.QueryString["exito"];

                    if (exito4.Equals("1"))
                    {
                        //Si el EliminarItem fue exitoso mostramos esta alerta
                        alert.Attributes["class"] = "alert alert-success alert-dismissible";
                        alert.Attributes["role"] = "alert";
                        alert.InnerHtml = "<div><button type=\"button\" class=\"close\" data-dismiss=\"alert\"" +
                            " aria-la" + "bel=\"Close\"><span aria-hidden=\"true\">&times;</span></button>" +
                            "El producto se ha eliminado exitosamente</div>";
                    }
                    else
                    {
                        //Si el EliminarItem fue fallido mostramos esta alerta
                        alert.Attributes["class"] = "alert alert-danger alert-dismissible";
                        alert.Attributes["role"] = "alert";
                        alert.InnerHtml = "<div><button type=\"button\" class=\"close\" data-dismiss=\"alert\"" +
                            " aria-la" + "bel=\"Close\"><span aria-hidden=\"true\">&times;</span></button>" +
                            " El producto no ha podido ser eliminado, por favor intente nuevamente" +
                            " Revise la conexion</div>";
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
                        pagofinal = "Tarjeta";
                        break;

                    case "2":
                        pagofinal = "Deposito";
                        break;

                    case "3":
                        pagofinal = "Transferencia";
                        break;                    
                }

                //Ejecuto la operacion siempre y cuando el tipo de pago sea uno valido
                if (pagofinal != null)
                    respuesta = this.elPresentador.RegistrarPago(
                    Session[RecursosInterfazMaster.sessionUsuarioID].ToString(), pago);                

                //Obtenemos la respuesta y redireccionamos para mostrar el exito o fallo
                if (respuesta)
                    HttpContext.Current.Response.Redirect("M16_VerCarrito.aspx?accion=2&exito=1");
                else
                    HttpContext.Current.Response.Redirect("M16_VerCarrito.aspx?accion=2&exito=0");
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