using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Interfaz_Contratos.Modulo16;
using LogicaNegociosSKD;
using LogicaNegociosSKD.Comandos;
using LogicaNegociosSKD.Fabrica;
using DominioSKD;
using DominioSKD.Entidades.Modulo16;
using DominioSKD.Entidades.Modulo15;
using DominioSKD.Entidades.Modulo6;
using System.Web.UI.WebControls;
using DominioSKD.Fabrica;
using System.Web;
using Interfaz_Presentadores.Master;
using ExcepcionesSKD;
using ExcepcionesSKD.Modulo16;
using System.Text.RegularExpressions;

namespace Interfaz_Presentadores.Modulo16
{
    public class PresentadorVerCarrito
    {
        #region Atributos
        //Interfaz a usar de su vista
        IcontratoVerCarrito laVista;
        private float precioFinal;
        #endregion

        #region Constructores
        /// <summary>
        /// Constructor de la clase que recibe la interfaz
        /// </summary>
        /// <param name="laVista">Interfaz que es la vista a la que se manipulara</param>
        public PresentadorVerCarrito(IcontratoVerCarrito laVista)
        {
            this.laVista = laVista;
            this.precioFinal = 0;
        }
        #endregion

        #region Metodos
        //LISTO
        #region VerCarrito
        /// <summary>
        /// Metodo del presentador que obtiene el carrito de una persona
        /// </summary>
        /// <param name="persona">el ID de la persona a la que se desea ver su carrito</param>
        public void LlenarTabla(String idpersona)
        {
            try
            {
                //Escribo en el logger la entrada a este metodo
                Logger.EscribirInfo(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name,
                    M16_Recursointerfaz.MENSAJE_ENTRADA_LOGGER,
                    System.Reflection.MethodBase.GetCurrentMethod().Name);

                //Creo la fabrica y persona y le pongo su ID
                FabricaEntidades fabrica = new FabricaEntidades();
                Entidad persona = (Persona)FabricaEntidades.ObtenerPersona();
                persona.Id = int.Parse(idpersona);

                //Instancio el comando para ver el carrito, obtengo el carrito de la persona y casteo
                FabricaComandos fabricaComando = new FabricaComandos();
                Comando<Entidad> VerCarrito = FabricaComandos.CrearComandoVerCarrito(persona);
                Carrito elCarrito = (Carrito)VerCarrito.Ejecutar();

                //Obtenemos cada implemento para ponerlos en la tabla
                foreach (KeyValuePair<Entidad, int> aux in elCarrito.ListaImplemento)
                {
                    //Casteamos la entidad como un implemento
                    Implemento item = aux.Key as Implemento;

                    //Creamos la nueva fila que ira en la tabla
                    TableRow fila = new TableRow();

                    //Nueva celda que tendra el nombre del implemento
                    TableCell celda = new TableCell();
                    celda.Text = item.Nombre_Implemento;

                    //Agrego la Celda a la fila
                    fila.Cells.Add(celda);

                    //Nueva celda que tendra el costo del implemento
                    celda = new TableCell();
                    celda.Text = item.Precio_Implemento.ToString();

                    //Agrego la celda a la fila
                    fila.Cells.Add(celda);

                    //Nueva celda que tendra el textbox para poner la cantidad del implemento
                    celda = new TableCell();
                    TextBox texto = new TextBox();
                    texto.Text = aux.Value.ToString();
                    celda.Controls.Add(texto);

                    //Agrego la celda a la fila
                    fila.Cells.Add(celda);

                    //Celda que tendra los botones de Detallar, Modificar y Eliminar
                    celda = new TableCell();

                    //Boton Modificar
                    Button boton = new Button();
                    boton.Click += Modificar_Carrito;
                    //boton.Click += new EventHandler(laVista.Modificar_Carrito);
                    boton.CssClass = M16_Recursointerfaz.BOTON_CLASE_COMPRA;
                    boton.ID = M16_Recursointerfaz.IMPLEMENTO_ID + item.Id.ToString();
                    celda.Controls.Add(boton);

                /*    //Se modifica para que el boton no haga postback
                    boton.OnClientClick = M16_Recursointerfaz.NO_POSTBACK;
                    boton.UseSubmitBehavior = false;
                    celda.Controls.Add(boton);*/

                    //Boton informacion
                    boton = new Button();
                    boton.ID = M16_Recursointerfaz.PRODUCTO_INFORMACION + item.Id.ToString();
                    boton.Command += DetalleProducto_Prod;
                    boton.CssClass = M16_Recursointerfaz.BOTON_CLASE_INFORMACION;
                    boton.CommandName = item.Id.ToString();
                    celda.Controls.Add(boton);

                    //Boton Eliminar
                    boton = new Button();
                    boton.Click += Eliminar_Item;
                    boton.CssClass = M16_Recursointerfaz.BOTON_CLASE_ELIMINAR;
                    boton.ID = M16_Recursointerfaz.IMPLEMENTO_ELIMINAR + item.Id.ToString();
                    celda.Controls.Add(boton);

                    //Agrego la celda a la fila
                    fila.Cells.Add(celda);

                    //Agrego la fila a la tabla
                    this.laVista.tablaImplemento.Rows.Add(fila);

                    //Anexo al precio total
                    precioFinal += (float)item.Precio_Implemento*aux.Value;
                }

                //Obtenemos cada evento para ponerlos en la tabla
                foreach (KeyValuePair<Entidad, int> aux in elCarrito.Listaevento)
                {
                    //Casteamos la entidad como un evento
                    Evento item = aux.Key as Evento;

                    //Creamos la nueva fila que ira en la tabla
                    TableRow fila = new TableRow();

                    //Nueva celda que tendra el nombre del evento
                    TableCell celda = new TableCell();
                    celda.Text = item.Nombre;

                    //Agrego la Celda a la fila
                    fila.Cells.Add(celda);

                    //Nueva celda que tendra el costo del evento
                    celda = new TableCell();
                    celda.Text = item.Costo.ToString();

                    //Agrego la celda a la fila
                    fila.Cells.Add(celda);

                    //Nueva celda que tendra el textbox para poner la cantidad del evento
                    celda = new TableCell();
                    TextBox texto = new TextBox();
                    texto.Text = aux.Value.ToString();
                    celda.Controls.Add(texto);

                    //Agrego la celda a la fila
                    fila.Cells.Add(celda);

                    //Celda que tendra los botones de Detallar, Modificar y Eliminar
                    celda = new TableCell();

                    //Boton Modificar
                    Button boton = new Button();
                    boton.Click += Modificar_Carrito;
                    boton.CssClass = M16_Recursointerfaz.BOTON_CLASE_COMPRA;
                    boton.ID = M16_Recursointerfaz.EVENTO_ID + item.Id.ToString();
                    celda.Controls.Add(boton);

                  /*  //Se modifica para que el boton no haga postback
                    boton.OnClientClick = M16_Recursointerfaz.NO_POSTBACK;
                    boton.UseSubmitBehavior = false;
                    celda.Controls.Add(boton);*/

                    //Boton informacion
                    boton = new Button();
                    boton.ID = M16_Recursointerfaz.EVENTO_INFORMACION + item.Id.ToString();
                    boton.Command += DetalleEvento_Event;
                    boton.CssClass = M16_Recursointerfaz.BOTON_CLASE_INFORMACION;
                    boton.CommandName = item.Id.ToString();
                    celda.Controls.Add(boton);

                    //Boton Eliminar
                    boton = new Button();
                    boton.Click += Eliminar_Item;
                    boton.CssClass = M16_Recursointerfaz.BOTON_CLASE_ELIMINAR;
                    boton.ID = M16_Recursointerfaz.EVENTO_ELIMINAR + item.Id.ToString();
                    celda.Controls.Add(boton);

                    //Agrego la celda a la fila
                    fila.Cells.Add(celda);

                    //Agrego la fila a la tabla
                    this.laVista.tablaEvento.Rows.Add(fila);

                    //Anexo al precio final
                    precioFinal += item.Costo * aux.Value;
                }

                //Obtenemos cada matricula para ponerlas en la tabla            
                foreach (KeyValuePair<Entidad, int> aux in elCarrito.Listamatricula)
                {
                    //Casteamos la entidad como una matricula
                    Matricula item = aux.Key as Matricula;

                    //Creamos la nueva fila que ira en la tabla
                    TableRow fila = new TableRow();

                    //Nueva celda que tendra el nombre de la matricula
                    TableCell celda = new TableCell();
                    celda.Text = item.Identificador;

                    //Agrego la Celda a la fila
                    fila.Cells.Add(celda);

                    //Nueva celda que tendra el costo de la matricula
                    celda = new TableCell();
                    celda.Text = item.Costo.ToString();

                    //Agrego la celda a la fila
                    fila.Cells.Add(celda);

                    //Agrego celda para poner la cantidad de la matricula
                    celda = new TableCell();               
                    celda.Text = aux.Value.ToString();                

                    //Agrego la celda a la fila
                    fila.Cells.Add(celda);

                    //Celda que tendra el boton de Eliminar y la Informacion
                    celda = new TableCell();

                    //Boton Eliminar               
                    Button boton = new Button();
                    boton.Click += Eliminar_Item;
                    boton.CssClass = M16_Recursointerfaz.BOTON_CLASE_ELIMINAR;
                    boton.ID = M16_Recursointerfaz.MATRICULA_ELIMINAR + item.Id.ToString();
                    celda.Controls.Add(boton);

                    //Boton informacion
                    boton = new Button();
                    boton.ID = M16_Recursointerfaz.MATRICULA_INFORMACION + item.Id.ToString();
                    boton.Command += DetalleMatricula_Mat;
                    boton.CssClass = M16_Recursointerfaz.BOTON_CLASE_INFORMACION;
                    boton.CommandName = item.Id.ToString();
                    celda.Controls.Add(boton);

                    //Agrego la celda a la fila
                    fila.Cells.Add(celda);

                    //Agrego la fila a la tabla
                    this.laVista.tablaMatricula.Rows.Add(fila);

                    //Anexo al precio final
                    precioFinal += item.Costo * aux.Value;
                }

                //Descontamos del total los pagos que ya haya hecho
                precioFinal -= elCarrito.montoPagado;

                //Colocamos el precio en el modal
                laVista.PrecioFinal.Text =  "</br>" + "<h3>Precio final: </h3>" + "<label id='labelprecio' >" + precioFinal.ToString() + "</label>";

                //Escribo en el logger la salida a este metodo
                Logger.EscribirInfo(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name,
                   M16_Recursointerfaz.MENSAJE_SALIDA_LOGGER, System.Reflection.MethodBase.GetCurrentMethod().Name);

            }
            catch (PersonaNoValidaException e)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, e);
                throw e;
            }
            catch (LoggerException e)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, e);
                throw e;                
            }
            catch (ParseoVacioException e)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, e);
                throw e;
            }
            catch (ParseoFormatoInvalidoException e)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, e);
                throw e;
            }
            catch (ParseoEnSobrecargaException e)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, e);
                throw e;                
            }
            catch (ParametroInvalidoException e)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, e);
                throw e;
            }
            catch (ExceptionSKDConexionBD e)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, e);
                throw e;                
            }
            catch (ExceptionSKD e)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, e);
                throw e;                
            }
            catch (Exception e)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, e);
                throw e;
            }
        }
        #endregion        
        //LISTO
        #region ModificarCarrito
        /// <summary>
        /// Metodo del presentador que modifica la cantidad de un item determinado en el carrito de una persona
        /// </summary>
        /// <param name="sender">El boton que manda la accion</param>
        /// <param name="e">El evento</param>
        public void Modificar_Carrito(object sender, EventArgs e)
        {
            try
            {
                //Escribo en el logger la entrada a este metodo
                Logger.EscribirInfo(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name,
                    M16_Recursointerfaz.MENSAJE_ENTRADA_LOGGER,
                    System.Reflection.MethodBase.GetCurrentMethod().Name);

                //Persona que eventualmente la buscaremos por el session
                FabricaEntidades fabrica = new FabricaEntidades();
                Entidad persona = (Persona)FabricaEntidades.ObtenerPersona();
                persona.Id= int.Parse(HttpContext.Current.Session[RecursosInterfazMaster.sessionUsuarioID].ToString());

                //Transformo el boton y obtengo la informacion de que item quiero agregar y su ID
                Button aux = (Button)sender;
                String[] datos = aux.ID.Split('-');

                //Expresion regular y lista que contendra los datos a ser validados por el mismo            
                Regex expresionRegular = new Regex("^[1-9]+[0-9]*$");
                List<String> datosValidar = new List<String>();

                //Cantidad deseada nueva por el usuario y en string
                int cantidad = 0;
                String cantidadNueva = "";

                //Respuesta a obtener del comando, tipo de objeto
                bool respuesta = false;
                int TipoObjeto = 0;

                //Si se trata de un implemento, me voy a la tabla correspondiente
                if (datos[0] == M16_Recursointerfaz.IMPLEMENTO)
                {
                    //Recorro cada fila para saber a cual me refiero y obtener la cantidad a modificar
                    foreach (TableRow aux2 in this.laVista.tablaImplemento.Rows)
                    {
                        //Si la fila no es de tipo Header puedo comenzar a buscar
                        if ((aux2 is TableHeaderRow) != true)
                        {
                            //En la celda 3 siempre estaran los botones, casteo el boton
                            Button aux3 = aux2.Cells[3].Controls[0] as Button;

                            //Si el ID del boton en la fila actual corresponde con el ID del boton que realizo
                            // la accionObtenemos el numero del textbox que el usuario desea
                            if (aux3.ID == aux.ID)
                            {
                                /*En la celda 2 siempre estara el textbox, lo obtengo y agarro la cantidad que el
                                /usuario desea*/
                                TextBox eltexto = aux2.Cells[2].Controls[0] as TextBox;                                
                                cantidadNueva = eltexto.Text;
                                break;
                            }
                        }
                    }

                    //Agrego el input del usuario a la variable para validar los datos en la clase Validaciones
                    datosValidar.Add(cantidadNueva);

                    //Verifico que sea un numero entero diferente de cero o negativo
                    if (Validaciones.ValidarExpresionRegular(datosValidar, expresionRegular))
                    {
                        //Decimos que se trata de un implemento y convertimos la cantidad deseada
                        TipoObjeto = 1;
                        cantidad = int.Parse(cantidadNueva);

                        //Pasamos el ID que vino del boton                    
                        Entidad objeto = (Implemento)FabricaEntidades.ObtenerImplemento();
                        objeto.Id = int.Parse(datos[1]);

                        //Instancio el comando para Registrar un Pago y obtengo el exito o fallo del proceso                        
                        Comando<bool> ModificarCarrito = FabricaComandos.CrearComandoModificarCarrito
                            (persona, objeto, TipoObjeto, cantidad);
                        respuesta = ModificarCarrito.Ejecutar();
                    }
                    else
                        throw new CantidadInvalidaException
                            (M16_Recursointerfaz.CODIGO_EXCEPCION_CANTIDAD_INVALIDA, 
                            M16_Recursointerfaz.MENSAJE_EXCEPCION_CANTIDAD_INVALIDA, 
                            new CantidadInvalidaException());                    
                    
                }
                //Si es un Evento, me voy a la tabla correspondiente
                else if (datos[0] == M16_Recursointerfaz.EVENTO)
                {
                    //Recorro cada fila para saber a cual me refiero y obtener la cantidad a modificar
                    foreach (TableRow aux2 in this.laVista.tablaEvento.Rows)
                    {
                        //Si la fila no es de tipo Header puedo comenzar a buscar
                        if ((aux2 is TableHeaderRow) != true)
                        {
                            //En la celda 3 siempre estaran los botones, casteo el boton
                            Button aux3 = aux2.Cells[3].Controls[0] as Button;

                            //Si el ID del boton en la fila actual corresponde con el ID del boton que realizo la
                            //accion btenemos el numero del textbox que el usuario desea
                            if (aux3.ID == aux.ID)
                            {
                                //En la celda 2 siempre estara el textbox, lo obtengo y agarro la cantidad que el
                                //usuario desea
                                TextBox eltexto = aux2.Cells[2].Controls[0] as TextBox;
                                cantidadNueva = eltexto.Text;
                                break;
                            }
                        }
                    }

                    //Agrego el input del usuario a la variable para validar los datos en la clase Validaciones
                    datosValidar.Add(cantidadNueva);

                    //Verifico que sea un numero entero diferente de cero o negativo
                    if (Validaciones.ValidarExpresionRegular(datosValidar, expresionRegular))
                    {
                        //Decimos que se trata de un evento
                        TipoObjeto = 2;
                        cantidad = int.Parse(cantidadNueva);

                        //Pasamos el ID que vino del boton                    
                        Evento objeto = (Evento)fabrica.ObtenerEvento();
                        objeto.Id = int.Parse(datos[1]);

                        //Instancio el comando para Registrar un Pago y obtengo el exito o fallo del proceso                      
                        Comando<bool> ModificarCarrito = FabricaComandos.CrearComandoModificarCarrito
                            (persona, objeto, TipoObjeto, cantidad);
                        respuesta = ModificarCarrito.Ejecutar();
                    }
                    else
                        throw new CantidadInvalidaException
                            (M16_Recursointerfaz.CODIGO_EXCEPCION_CANTIDAD_INVALIDA,
                            M16_Recursointerfaz.MENSAJE_EXCEPCION_CANTIDAD_INVALIDA,
                            new CantidadInvalidaException()); 
                }

                //Escribo en el logger la salida a este metodo
                Logger.EscribirInfo(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name,
                   M16_Recursointerfaz.MENSAJE_SALIDA_LOGGER, System.Reflection.MethodBase.GetCurrentMethod().Name);

                //Obtenemos la respuesta y redireccionamos para mostrar el exito o fallo
                if (respuesta)
                    HttpContext.Current.Response.Redirect(M16_Recursointerfaz.MODIFICAR_LINK_EXITO, false);
                else
                    HttpContext.Current.Response.Redirect(M16_Recursointerfaz.MODIFICAR_LINK_FALLO, false);
            }
            catch (ArgumentNullException ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                HttpContext.Current.Response.Redirect(M16_Recursointerfaz.EXCEPTION_PARSEO_VACIO_LINK, false);
            }
            catch (CarritoConPagoException ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                HttpContext.Current.Response.Redirect(M16_Recursointerfaz.EXCEPCION_CARRITO_PAGO_LINK, false);
            }
            catch (CantidadInvalidaException ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                HttpContext.Current.Response.Redirect(M16_Recursointerfaz.EXCEPCION_CANTIDAD_INVALIDA_LINK, false);
            }
            catch (FormatException ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                HttpContext.Current.Response.Redirect(M16_Recursointerfaz.EXCEPTION_FORMATO_LINK, false);

            }
            catch (OverflowException ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                HttpContext.Current.Response.Redirect(M16_Recursointerfaz.EXCEPTION_SOBRECARGA_LINK, false);

            }
            catch (OpcionItemErroneoException ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                HttpContext.Current.Response.Redirect(M16_Recursointerfaz.EXCEPTION_OPCION_LINK, false);
            }
            catch (ItemInvalidoException ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                HttpContext.Current.Response.Redirect(M16_Recursointerfaz.EXCEPTION_ITEM_INVALIDO_LINK, false);
            }
            catch (PersonaNoValidaException ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                HttpContext.Current.Response.Redirect(M16_Recursointerfaz.EXCEPTION_PERSONA_INVALIDA_LINK, false);
            }
            catch (LoggerException ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                HttpContext.Current.Response.Redirect(M16_Recursointerfaz.EXCEPTION_LOGGER_LINK, false);
            }
            catch (ParseoVacioException ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                HttpContext.Current.Response.Redirect(M16_Recursointerfaz.EXCEPTION_PARSEO_VACIO_LINK, false);
            }
            catch (ParseoFormatoInvalidoException ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                HttpContext.Current.Response.Redirect(M16_Recursointerfaz.EXCEPTION_FORMATO_LINK, false);
            }
            catch (ParseoEnSobrecargaException ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                HttpContext.Current.Response.Redirect(M16_Recursointerfaz.EXCEPTION_SOBRECARGA_LINK, false);
            }
            catch (ParametroInvalidoException ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                HttpContext.Current.Response.Redirect(M16_Recursointerfaz.EXCEPTION_PARAMETRO_INVALIDO_LINK, false);
            }
            catch (ExceptionSKDConexionBD ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                HttpContext.Current.Response.Redirect(M16_Recursointerfaz.EXCEPTION_CONEXIONBD_LINK, false);
            }
            catch (ExceptionSKD ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                HttpContext.Current.Response.Redirect(M16_Recursointerfaz.EXCEPTIONSKD_LINK, false);
            }
            catch (Exception ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                HttpContext.Current.Response.Redirect(M16_Recursointerfaz.EXCEPTION_LINK, false);
            }
        }
        #endregion
        //LISTO
        #region RegistrarPago
        /// <summary>
        /// Metodo del presentador que registra el pago de los productos que hay en el carrito de una persona
        /// </summary>
        /// <param name="idpersona">La persona que desea comprar los productos</param>        
        /// <param name="tipoPago">El tipo de pago con el cual realizo la transaccion</param>        
        /// <returns>El exito o fallo del proceso siempre y cuando no exista un error</returns>
        public bool RegistrarPago(String idpersona, String tipoPago)
        {             
            try
            {
                //Escribo en el logger la entrada a este metodo
                Logger.EscribirInfo(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name,
                    M16_Recursointerfaz.MENSAJE_ENTRADA_LOGGER,
                    System.Reflection.MethodBase.GetCurrentMethod().Name);

                //Expresion regular que validara los datos del tipo de pago 
                Regex expresionRegular = new Regex("^[0-9]+[0-9]*$");                

                //Instancio la fabrica, obtengo la entidad persona y asigno su ID
                FabricaEntidades fabrica = new FabricaEntidades();
                Entidad persona = (Persona)FabricaEntidades.ObtenerPersona();
                persona.Id = int.Parse(idpersona);

                //Pago que sera insertado en la Base De Datos y la respuesta
                String pagofinal = null;
                bool respuesta = false;

                //Obtengo el monto con el que pago la transaccion
                float montoPago = float.Parse(laVista.MontoPago.Value);

                //Disparo una excepcion si el pago insertado es a/o es 0
                if (montoPago <= 0)
                    throw new MontoInvalidoException(
                        M16_Recursointerfaz.CODIGO_EXCEPCION_MONTO_INVALIDO,
                        M16_Recursointerfaz.MENSAJE_EXCEPCION_MONTO_INVALIDO,
                        new MontoInvalidoException());

                //Obtengo el Valor del combobox y le añado su correspondiente tipo de pago
                switch (tipoPago)
                {
                    case "1":
                        pagofinal = M16_Recursointerfaz.TIPO_PAGO_TARJETA;
                        break;

                    case "2":
                        pagofinal = M16_Recursointerfaz.TIPO_PAGO_DEPOSITO;
                        break;

                    case "3":
                        pagofinal = M16_Recursointerfaz.TIPO_PAGO_TRANSFERENCIA;
                        break;

                    default:
                        throw new OpcionPagoNoValidoException
                            (M16_Recursointerfaz.CODIGO_EXCEPCION_OPCION_PAGO_INVALIDO,
                            M16_Recursointerfaz.MENSAJE_EXCEPCION_OPCION_PAGO_INVALIDO,
                            new OpcionPagoNoValidoException());
                }

                //Datos del pago seleccionado y anexo
                List<String> datosPago = new List<String>();
                datosPago.Add(laVista.Datospago.Value);

                //Si es un tipo de pago valido
                if (Validaciones.ValidarExpresionRegular(datosPago, expresionRegular))
                {                    
                    //Instancio la entidad pago y asigno sus datos
                    Entidad pagoCompra = FabricaEntidades.ObtenerPago(montoPago, pagofinal, datosPago);

                    //Instancio el comando para Registrar un Pago y obtengo el exito o fallo del proceso            
                    Comando<bool> registrarPago = FabricaComandos.CrearComandoRegistrarPago(persona, pagoCompra);
                    respuesta = registrarPago.Ejecutar();  
                }
                else
                    throw new CantidadInvalidaException(
                        M16_Recursointerfaz.CODIGO_EXCEPCION_DATO_PAGO, 
                        M16_Recursointerfaz.MENSAJE_EXCEPCION_DATO_PAGO, 
                        new CantidadInvalidaException());

                //Escribo en el logger la salida a este metodo
                Logger.EscribirInfo(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name,
                   M16_Recursointerfaz.MENSAJE_SALIDA_LOGGER, System.Reflection.MethodBase.GetCurrentMethod().Name);

                //retorno la respuesta
                return respuesta;
            }
            catch (ArgumentNullException e)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, e);                
                throw new ParseoVacioException(M16_Recursointerfaz.CODIGO_EXCEPCION_ARGUMENTO_NULO,
                    M16_Recursointerfaz.MENSAJE_EXCEPCION_ARGUMENTO_NULO, e);
            }
            catch (CantidadInvalidaException e)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, e);
                throw e;
            }
            catch (MontoInvalidoException e)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, e);
                throw e;
            }
            catch (FormatException e)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, e);
                throw new ParseoFormatoInvalidoException(M16_Recursointerfaz.CODIGO_EXCEPCION_FORMATO_INVALIDO ,
                    M16_Recursointerfaz.MENSAJE_EXCEPCION_FORMATO_INVALIDO, e);
            }
            catch (OverflowException e)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, e);
                throw new ParseoEnSobrecargaException(M16_Recursointerfaz.CODIGO_EXCEPCION_SOBRECARGA, 
                    M16_Recursointerfaz.MENSAJE_EXCEPCION_SOBRECARGA, e);
            }
            catch (OpcionPagoNoValidoException e)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, e);
                throw e;
            }
            catch (LoggerException e)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, e);              
                throw e;
            }
            catch (ParseoVacioException e)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, e);              
                throw e;
            }
            catch (PersonaNoValidaException e)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, e);               
                throw e;
            }
            catch (ParseoFormatoInvalidoException e)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, e);               
                throw e;
            }
            catch (ParseoEnSobrecargaException e)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, e);              
                throw e;
            }
            catch (ParametroInvalidoException e)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, e);                
                throw e;
            }
            catch (ExceptionSKDConexionBD e)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, e);
                throw e;
            }
            catch (ExceptionSKD e)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, e);               
                throw e;
            }
            catch (Exception e)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, e);               
                throw new ExceptionSKDConexionBD(M16_Recursointerfaz.CODIGO_EXCEPCION_GENERICO, 
                    M16_Recursointerfaz.MENSAJE_EXCEPCION_GENERICO, e);
            }            
        }
        #endregion
        //LISTO
        #region EliminarItem
        /// <summary>
        /// Metodo del presentador que elimina un item del carrito del usuario
        /// </summary>
        /// <param name="sender">El objeto que dispara la accion</param>
        /// <param name="e">El evento que es ejecutado</param>
        public void Eliminar_Item(object sender, EventArgs e)
        {            
            try
            {   //Escribo en el logger la entrada a este metodo
                Logger.EscribirInfo(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name,
                M16_Recursointerfaz.MENSAJE_ENTRADA_LOGGER,
                System.Reflection.MethodBase.GetCurrentMethod().Name);
                
                //Persona que eventualmente la buscaremos por el session                
                Entidad persona = (Persona)FabricaEntidades.ObtenerPersona();
                persona.Id =int.Parse(HttpContext.Current.Session[RecursosInterfazMaster.sessionUsuarioID].ToString());

                //Transformo el boton y obtengo la informacion de que item quiero agregar y su ID
                Button aux = (Button)sender;
                String[] datos = aux.ID.Split('-');

                //Respuesta a obtener del comando, tipo de objeto
                bool respuesta = false;
                int TipoObjeto = 0;

                //Si se trata de un implemento, me voy a la tabla correspondiente
                if (datos[0] == M16_Recursointerfaz.IMPLEMENTO_ELIMINAR2)
                {
                    //Decimos que se trata de un implemento
                    TipoObjeto = 1;

                    //Pasamos el ID que vino del boton
                    Entidad objeto = (Implemento)FabricaEntidades.ObtenerImplemento();
				
                    objeto.Id = int.Parse(datos[1]);
                
                    //Instancio el comando para eliminar item y obtengo el exito o fallo del proceso
                    Comando<bool> EliminarCarrito = FabricaComandos.CrearComandoeliminarItem(TipoObjeto, objeto, persona);

                    //Escribo en el logger la salida a este metodo
                    Logger.EscribirInfo(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name,
                    M16_Recursointerfaz.MENSAJE_SALIDA_LOGGER, System.Reflection.MethodBase.GetCurrentMethod().Name);
                    //Ejecuto el método eliminar carrito en el Comandoeliminartem
                    respuesta = EliminarCarrito.Ejecutar();
                }

                //Si es un Evento, me voy a la tabla correspondiente
                else if (datos[0] == M16_Recursointerfaz.EVENTO_ELIMINAR2)
                {
                    //Decimos que se trata de un evento
                    TipoObjeto = 3;
                    FabricaEntidades fabrica = new FabricaEntidades();
                    //Pasamos el ID que vino del boton                
                    Entidad objeto = (Evento)fabrica.ObtenerEvento();
                    objeto.Id = int.Parse(datos[1]);
                
                    //Instancio el comando para eliminar el evento del carrito y obtengo el exito o fallo del proceso
                    Comando<bool> EliminarCarrito = FabricaComandos.CrearComandoeliminarItem(TipoObjeto, objeto, persona);
                    //Escribo en el logger la salida a este metodo
                    Logger.EscribirInfo(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name,
                    M16_Recursointerfaz.MENSAJE_SALIDA_LOGGER, System.Reflection.MethodBase.GetCurrentMethod().Name);
                    //Ejecuto el método eliminar carrito en el Comandoeliminartem
                    respuesta = EliminarCarrito.Ejecutar();
                }

                //Si se trata de una matricula, me voy a la tabla correspondiente
                else if (datos[0] == M16_Recursointerfaz.MATRICULA_ELIMINAR2)
                {
                    //Decimos que se trata de una matricula
                    TipoObjeto = 2;

                    //Pasamos el ID que vino del boton                
                    Entidad objeto = (Matricula)FabricaEntidades.ObtenerMatricula();
                    objeto.Id = int.Parse(datos[1]);
                
                    //Instancio el comando para eliminar item y obtengo el exito o fallo del proceso
                    Comando<bool> EliminarCarrito = FabricaComandos.CrearComandoeliminarItem(TipoObjeto, objeto, persona);

                    //Escribo en el logger la salida a este metodo
                    Logger.EscribirInfo(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name,
                    M16_Recursointerfaz.MENSAJE_SALIDA_LOGGER, System.Reflection.MethodBase.GetCurrentMethod().Name);
                    //Ejecuto el método eliminar carrito en el Comandoeliminartem
                    respuesta = EliminarCarrito.Ejecutar();
                }

                //Obtenemos la respuesta y redireccionamos para mostrar el exito o fallo
                if (respuesta)
                    HttpContext.Current.Response.Redirect(M16_Recursointerfaz.ELIMINAR_LINK_EXITO, false);
                else
                    HttpContext.Current.Response.Redirect(M16_Recursointerfaz.ELIMINAR_LINK_FALLO, false);
            }
            catch (ArgumentNullException ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                HttpContext.Current.Response.Redirect(M16_Recursointerfaz.CODIGO_EXCEPCION_ARGUMENTO_NULO, false);
                                 
            }
            catch (CarritoConPagoException ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                HttpContext.Current.Response.Redirect(M16_Recursointerfaz.EXCEPCION_CARRITO_PAGO_LINK, false);
            }
            catch (FormatException ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                HttpContext.Current.Response.Redirect(M16_Recursointerfaz.CODIGO_EXCEPCION_FORMATO_INVALIDO, false);
                                 
            }
            catch (OverflowException ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                HttpContext.Current.Response.Redirect(M16_Recursointerfaz.CODIGO_EXCEPCION_SOBRECARGA, false);
                  
            }
            catch (LoggerException ex)
            {

                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                HttpContext.Current.Response.Redirect(M16_Recursointerfaz.EXCEPTION_LOGGER_LINK, false);
                
            }
            catch (ParseoVacioException ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                HttpContext.Current.Response.Redirect(M16_Recursointerfaz.EXCEPTION_SOBRECARGA_LINK, false);
           }
            catch (PersonaNoValidaException ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                HttpContext.Current.Response.Redirect(M16_Recursointerfaz.EXCEPTION_PERSONA_INVALIDA_LINK, false);
            }
            catch (ParseoFormatoInvalidoException ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                throw ex;
            }
            catch (ParseoEnSobrecargaException ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                throw ex;
            }
            catch (ParametroInvalidoException ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                HttpContext.Current.Response.Redirect(M16_Recursointerfaz.EXCEPTION_PARAMETRO_INVALIDO_LINK, false);
            }
            catch (ExceptionSKDConexionBD ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                HttpContext.Current.Response.Redirect(M16_Recursointerfaz.EXCEPTION_CONEXIONBD_LINK, false);
            }
            catch (ExceptionSKD ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                HttpContext.Current.Response.Redirect(M16_Recursointerfaz.EXCEPTIONSKD_LINK, false);
            }
            catch (Exception ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                HttpContext.Current.Response.Redirect(M16_Recursointerfaz.EXCEPTION_LINK, false);
            }
           
             
        }
        #endregion
        // listo ver lo que se coloca en los recursos
        #region Metodos para el detalle del Implemento
        /// <summary>
        /// Metodo del presentador que pinta el detalle en el modal
        /// </summary>
        /// <param name="producto">El Producto que se ha de mostrar en detalle</param>
        public void DetalleProducto_Prod(object sender, CommandEventArgs e)
        {
            try {
                //Escribo en el logger la entrada a este metodo
                Logger.EscribirInfo(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name,
                    M16_Recursointerfaz.MENSAJE_ENTRADA_LOGGER, System.Reflection.MethodBase.GetCurrentMethod().Name);

                string id = e.CommandName;
                Implemento implemento = new Implemento();
                implemento.Id_Implemento = int.Parse(id);

                // Casteamos
                Implemento resultados = DetalleImplemento(implemento);

                // Variables para imprimir en el modal
                laVista.LiteralDetallesProductos.Text = "</br>" + "<h3>Imagen del Producto</h3>" + "<label id='aux1' >" + resultados.Imagen_implemento + "</label>" +
                                                                  "<h3>Nombre</h3>" + "<label id='aux2' >" + resultados.Nombre_Implemento + "</label>" +
                                                                  "<h3>Tipo</h3>" + "<label id='aux3' >" + resultados.Tipo_Implemento + "</label>" +
                                                                  "<h3>Marca</h3>" + "<label id='aux4' >" + resultados.Marca_Implemento + "</label>" +
                                                                  "<h3>Color</h3>" + "<label id='aux5' >" + resultados.Color_Implemento + "</label>" +
                                                                  "<h3>Talla</h3>" + "<label id='aux6' >" + resultados.Talla_Implemento + "</label>" +
                                                                  "<h3>Estatus</h3>" + "<label id='aux7' >" + resultados.Estatus_Implemento + "</label>" +
                                                                  "<h3>Precio</h3>" + "<label id='aux8' >" + resultados.Precio_Implemento + "</label>" +
                                                                  "<h3>Descripcion</h3>" + "<label id='aux9' >" + resultados.Descripcion_Implemento + "</label>";
                
                //Escribo en el logger la salida a este metodo
                Logger.EscribirInfo(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name,
                    M16_Recursointerfaz.MENSAJE_SALIDA_LOGGER, System.Reflection.MethodBase.GetCurrentMethod().Name);

                // Ejecutamos el script 
                laVista.ejecutarScriptImplemento();
                }

            #region Catches
            catch (PersonaNoValidaException ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                HttpContext.Current.Response.Redirect(M16_Recursointerfaz.EXCEPTION_PERSONA_INVALIDA_LINK, false);
            }
            catch (LoggerException ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                HttpContext.Current.Response.Redirect(M16_Recursointerfaz.EXCEPTION_LOGGER_LINK, false);

            }
            catch (ArgumentNullException ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                HttpContext.Current.Response.Redirect(M16_Recursointerfaz.EXCEPTION_PARSEO_VACIO_LINK, false);
            }
            catch (FormatException ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                HttpContext.Current.Response.Redirect(M16_Recursointerfaz.EXCEPTION_FORMATO_LINK, false);

            }
            catch (OverflowException ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                HttpContext.Current.Response.Redirect(M16_Recursointerfaz.EXCEPTION_SOBRECARGA_LINK, false);

            }
            catch (ParametroInvalidoException ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                HttpContext.Current.Response.Redirect(M16_Recursointerfaz.EXCEPTION_PARAMETRO_INVALIDO_LINK, false);
            }
            catch (ExceptionSKDConexionBD ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                HttpContext.Current.Response.Redirect(M16_Recursointerfaz.EXCEPTION_CONEXIONBD_LINK, false);

            }
            catch (ExceptionSKD ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                HttpContext.Current.Response.Redirect(M16_Recursointerfaz.EXCEPTIONSKD_LINK, false);

            }
            catch (Exception ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                HttpContext.Current.Response.Redirect(M16_Recursointerfaz.EXCEPTION_LINK, false);
            }

            #endregion
        }

        /// <summary>
        /// Metodo del presentador que detalla el producto dado un id especifico
        /// </summary>
        /// <param name="implemento">El producto que se ha de mostrar en detalle</param>
        public Implemento DetalleImplemento(Entidad implemento)
        {
            Comando<Entidad> DetalleProducto = FabricaComandos.CrearComandoDetallarProducto(implemento);
            Implemento elImplemento = (Implemento)DetalleProducto.Ejecutar();
            return elImplemento;
        }

        #endregion
        // listo ver lo que se coloca en los recursos
        #region Metodos para el detalle del evento
        /// <summary>
        /// Metodo del presentador que pinta el detalle en el modal
        /// </summary>
        /// <param name="evento">El evento que se ha mostrar en detalle</param>
        public void DetalleEvento_Event(object sender, CommandEventArgs e)
        {
            try { 
                //Escribo en el logger la entrada a este metodo
                Logger.EscribirInfo(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name,
                    M16_Recursointerfaz.MENSAJE_ENTRADA_LOGGER,
                    System.Reflection.MethodBase.GetCurrentMethod().Name);

                string id = e.CommandName;
                Evento evento = new Evento();
                evento.Id = int.Parse(id);

                //Casteamos
                Evento resultados = DetalleEvento(evento);

                // Variables para imprimir en el modal
                laVista.LiteralDetallesEventos.Text = "</br>" + "<h3>Nombre</h3>" + "<label id='aux1' >" + resultados.Nombre + "</label>" +
                                                            "<h3>Descripcion</h3>" + "<label id='aux2' >" + resultados.Descripcion + "</label>" +
                                                            "<h3>Costo</h3>" + "<label id='aux3' >" + resultados.Costo + "</label>";

                //Escribo en el logger la salida a este metodo
                Logger.EscribirInfo(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name,
                    M16_Recursointerfaz.MENSAJE_SALIDA_LOGGER, System.Reflection.MethodBase.GetCurrentMethod().Name);

                // Ejecutamos el Script
                laVista.ejecutarScriptEvento();
                }

            #region Catches
            catch (PersonaNoValidaException ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                HttpContext.Current.Response.Redirect(M16_Recursointerfaz.EXCEPTION_PERSONA_INVALIDA_LINK, false);
            }
            catch (LoggerException ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                HttpContext.Current.Response.Redirect(M16_Recursointerfaz.EXCEPTION_LOGGER_LINK, false);

            }
            catch (ArgumentNullException ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                HttpContext.Current.Response.Redirect(M16_Recursointerfaz.EXCEPTION_PARSEO_VACIO_LINK, false);
            }
            catch (FormatException ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                HttpContext.Current.Response.Redirect(M16_Recursointerfaz.EXCEPTION_FORMATO_LINK, false);

            }
            catch (OverflowException ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                HttpContext.Current.Response.Redirect(M16_Recursointerfaz.EXCEPTION_SOBRECARGA_LINK, false);

            }
            catch (ParametroInvalidoException ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                HttpContext.Current.Response.Redirect(M16_Recursointerfaz.EXCEPTION_PARAMETRO_INVALIDO_LINK, false);
            }
            catch (ExceptionSKDConexionBD ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                HttpContext.Current.Response.Redirect(M16_Recursointerfaz.EXCEPTION_CONEXIONBD_LINK, false);

            }
            catch (ExceptionSKD ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                HttpContext.Current.Response.Redirect(M16_Recursointerfaz.EXCEPTIONSKD_LINK, false);

            }
            catch (Exception ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                HttpContext.Current.Response.Redirect(M16_Recursointerfaz.EXCEPTION_LINK, false);
            }

            #endregion
        }

        /// <summary>
        /// Metodo del presentador que detalla el evento dado un id especifico
        /// </summary>
        /// <param name="evento">El evento que se ha mostrar en detalle</param>
        public Evento DetalleEvento(Entidad evento)
        {
            Comando<Entidad> DetalleEvento = FabricaComandos.CrearComandoDetallarEvento(evento);
            Evento elEvento = (Evento)DetalleEvento.Ejecutar();
            return elEvento;
        }

        #endregion
        // listo ver lo que se coloca en los recursos
        #region Metodos para el detalle de la Mensualidad
        /// <summary>
        /// Metodo del presentador que pinta el detalle en el modal
        /// </summary>
        /// <param name="evento">La Mensualidad que se ha de mostrar en detalle</param>
        public void DetalleMatricula_Mat(object sender, CommandEventArgs e)
        {
            try { 
                //Escribo en el logger la entrada a este metodo
                    Logger.EscribirInfo(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name,
                    M16_Recursointerfaz.MENSAJE_ENTRADA_LOGGER, System.Reflection.MethodBase.GetCurrentMethod().Name);

                string id = e.CommandName;
                Matricula matricula = new Matricula();
                matricula.Id = int.Parse(id);

                //Casteamos
                Matricula resultados = DetalleMatricula(matricula);

                // Variables para imprimir en el modal
                laVista.LiteralDetallesMensualidades.Text = "</br>" + "<h3>Id Matricula</h3>" + "<label id='aux1' >" + resultados.Id + "</label>" +
                                                                  "<h3>Identificador</h3>" + "<label id='aux2' >" + resultados.Identificador + "</label>" +
                                                                  "<h3>Costo</h3>" + "<label id='aux3' >" + resultados.Costo + "</label>" +
                                                                  "<h3>Ultima Fecha de Pago</h3>" + "<label id='aux4' >" + resultados.UltimaFechaPago + "</label>" +
                                                                  "<h3>Nombre del Dojo al que pertenece</h3>" + "<label id='aux4' >" + resultados.Dojo_Matricula.Nombre_dojo + "</label>";

                //Escribo en el logger la salida a este metodo
                    Logger.EscribirInfo(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name,
                        M16_Recursointerfaz.MENSAJE_SALIDA_LOGGER, System.Reflection.MethodBase.GetCurrentMethod().Name);

                // Ejecutamos el Script
                laVista.ejecutarScriptMensualidad();
                }

            #region Catches
            catch (PersonaNoValidaException ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                HttpContext.Current.Response.Redirect(M16_Recursointerfaz.EXCEPTION_PERSONA_INVALIDA_LINK, false);
            }
            catch (LoggerException ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                HttpContext.Current.Response.Redirect(M16_Recursointerfaz.EXCEPTION_LOGGER_LINK, false);

            }
            catch (ArgumentNullException ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                HttpContext.Current.Response.Redirect(M16_Recursointerfaz.EXCEPTION_PARSEO_VACIO_LINK, false);
            }
            catch (FormatException ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                HttpContext.Current.Response.Redirect(M16_Recursointerfaz.EXCEPTION_FORMATO_LINK, false);

            }
            catch (OverflowException ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                HttpContext.Current.Response.Redirect(M16_Recursointerfaz.EXCEPTION_SOBRECARGA_LINK, false);

            }
            catch (ParametroInvalidoException ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                HttpContext.Current.Response.Redirect(M16_Recursointerfaz.EXCEPTION_PARAMETRO_INVALIDO_LINK, false);
            }
            catch (ExceptionSKDConexionBD ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                HttpContext.Current.Response.Redirect(M16_Recursointerfaz.EXCEPTION_CONEXIONBD_LINK, false);

            }
            catch (ExceptionSKD ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                HttpContext.Current.Response.Redirect(M16_Recursointerfaz.EXCEPTIONSKD_LINK, false);

            }
            catch (Exception ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                HttpContext.Current.Response.Redirect(M16_Recursointerfaz.EXCEPTION_LINK, false);
            }

            #endregion
        }

        /// <summary>
        /// Metodo del presentador que detalla la Mensualidad dado el id especifico
        /// </summary>
        /// <param name="matricula">La mensualidad que se ha de mostrar en detalle</param>
        public Matricula DetalleMatricula(Entidad matricula)
        {
            Comando<Entidad> DetalleMatricula = FabricaComandos.CrearComandoDetallarMatricula(matricula);
            Matricula laMatricula = (Matricula)DetalleMatricula.Ejecutar();
            return laMatricula;
        }

        #endregion

        #endregion

    }
}
