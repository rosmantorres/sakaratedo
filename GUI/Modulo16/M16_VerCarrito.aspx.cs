using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Interfaz_Presentadores.Modulo16;
using ExcepcionesSKD.Modulo16;
using ExcepcionesSKD;

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
            ((SKD)Page.Master).IdModulo = "16";

            //Obtengo el Carrito de la Persona
            //this.elPresentador.LlenarTabla();

            //Verificamos si estamos ingresando a la pagina web sin ser redireccionamiento a ella misma
           // if (!IsPostBack)

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

                //Si se viene de un Registrar Pago obtenemos esta alerta
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
                        alert.Attributes["class"] = "alert alert-success alert-dismissible";
                        alert.Attributes["role"] = "alert";
                        alert.InnerHtml = "<div><button type=\"button\" class=\"close\" data-dismiss=\"alert\"" +
                            " aria-la" + "bel=\"Close\"><span aria-hidden=\"true\">&times;</span></button>" +
                            "Su compra no ha podido ser procesada, no existe esa cantidad de implementos" +
                            "Disponibles </div>";
                    }
                    break;
            }
                
        }

        /// <summary>
        /// Metodo que ejecuta el evento de Registrar el Pago de un Carrito en la base de Datos
        /// </summary>
        /// <param name="sender">El objeto que ejecuta el evento</param>
        /// <param name="e">El tipo de evento que se esta ejecutando</param>        
        protected void RegistrarPago(object sender, EventArgs e)
        {
            try
            {
                //Valor que esta seleccionado en el combobox del tipo de pago
                String pago = DropDownList1.Value;

                //Obtengo el Valor del combobox y le añado su correspondiente tipo de pago
                switch (pago)
                {
                    case "1":
                        pago = "Tarjeta";
                        break;

                    case "2":
                        pago = "Deposito";
                        break;

                    case "3":
                        pago = "Transferencia";
                        break;

                    //Lanzo una excepcion sino es ninguna de las opciones anteriores, REVISAR LOS PARAMETROS
                    default: throw new OpcionPagoNoValidoException(
                        M16_RecursoInterfaz.CODIGO_EXCEPCION_OPCION_PAGO_INVALIDO,
                        M16_RecursoInterfaz.MENSAJE_EXCEPCION_OPCION_PAGO_INVALIDO,
                        new OpcionPagoNoValidoException());
                }

                //Obtengo el exito o fallo del proceso
                /*bool respuesta = this.elPresentador.RegistrarPago(persona, pago);
                bool respuesta = this.elPresentador.RegistrarPago(null, pago);

                //Obtenemos la respuesta y redireccionamos para mostrar el exito o fallo
                if (respuesta)
                    HttpContext.Current.Response.Redirect("M16_VerCarrito.aspx?accion=2&exito=1");
                else
                    HttpContext.Current.Response.Redirect("M16_VerCarrito.aspx?accion=2&exito=0");*/
            }
            catch (OpcionPagoNoValidoException ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
            }
            catch (LoggerException ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);

            }
            catch (ParseoVacioException ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);

            }
            catch (PersonaNoValidaException ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);

            }
            catch (ParseoFormatoInvalidoException ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);

            }
            catch (ParseoEnSobrecargaException ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);

            }
            catch (ParametroInvalidoException ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);

            }
            catch (ExceptionSKDConexionBD ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);

            }
            catch (ExceptionSKD ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);

            }
            catch (Exception ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);

            }
        }
    }
}