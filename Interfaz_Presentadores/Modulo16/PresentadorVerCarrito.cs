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
        #endregion

        #region Constructores
        /// <summary>
        /// Constructor de la clase que recibe la interfaz
        /// </summary>
        /// <param name="laVista">Interfaz que es la vista a la que se manipulara</param>
        public PresentadorVerCarrito(IcontratoVerCarrito laVista)
        {
            this.laVista = laVista;            
        }
        #endregion

        #region Metodos
        
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
                Entidad persona = (Persona)FabricaEntidades.ObtenerPersona();
                persona.Id = int.Parse(idpersona);

                //Instancio el comando para ver el carrito, obtengo el carrito de la persona y casteo                
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
                }                

                //Colocamos el precio en el modal
                laVista.PrecioFinal.Text = M16_Recursointerfaz.SALTO_LINEA + M16_Recursointerfaz.TITULO_PRECIO_FINAL +
                    M16_Recursointerfaz.ABRE_LABEL_PRECIO_FINAL + ObtenerMonto(elCarrito)
                    + M16_Recursointerfaz.CIERRE_LABEL;

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
                        Evento objeto = (Evento)FabricaEntidades.ObtenerEvento();
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
                Entidad persona = (Persona)FabricaEntidades.ObtenerPersona();
                persona.Id = int.Parse(idpersona);

                //Pago que sera insertado en la Base De Datos y la respuesta
                String pagofinal = null;
                bool respuesta = false;

                //Monto que el usuario inserta
                float montoPago = 0;

                //Verifico si el monto ingresado no tiene puntos
                if (!laVista.MontoPago.Value.Contains('.'))
                {
                    //Obtengo el monto con el que pago la transaccion
                    montoPago = float.Parse(laVista.MontoPago.Value);                    
                }
                else
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

                //Si los datos del tipo de pago seleccionado son numeros
                if (Validaciones.ValidarExpresionRegular(datosPago, expresionRegular))
                {
                    //Obtengo el Carrito para ver si esta vacio
                    Comando<Entidad> VerCarrito = FabricaComandos.CrearComandoVerCarrito(persona);
                    Carrito elCarrito = (Carrito)VerCarrito.Ejecutar();                    

                    /*Si el carrito esta completamente vacio se lanzara una excepcion porque no se puede pagar, sino
                     registramos el pago normalmente*/
                    if (elCarrito.Listaevento.Count != 0 
                        || elCarrito.ListaImplemento.Count != 0 
                        || elCarrito.Listamatricula.Count != 0)
                    {
                        //Obtenemos el total adeudado para hacer las comparaciones
                        float montoCarrito = ObtenerMonto(elCarrito);

                        /*Si lo que voy a pagar es mayor a mi deuda, menor a 0 o si mi deuda es mayor a cero 
                          pero el monto a pagar es 0 lanzo esta excepcion*/
                        if (montoPago > montoCarrito || montoPago < 0 || (montoPago == 0 && montoCarrito > 0))
                            throw new MontoInvalidoException(M16_Recursointerfaz.CODIGO_EXCEPCION_MONTO_INVALIDO,
                                M16_Recursointerfaz.MENSAJE_EXCEPCION_MONTO_INVALIDO,
                                new MontoInvalidoException());                        

                        //Instancio la entidad pago y asigno sus datos
                        Entidad pagoCompra = FabricaEntidades.ObtenerPago(montoPago, pagofinal, datosPago);

                        //Instancio el comando para Registrar un Pago y obtengo el exito o fallo del proceso            
                        Comando<bool> registrarPago = FabricaComandos.CrearComandoRegistrarPago(persona, pagoCompra);
                        respuesta = registrarPago.Ejecutar();  
                    }
                    else
                        throw new CarritoVacioException(M16_Recursointerfaz.CODIGO_EXCEPCION_CARRITO_VACIO, 
                            M16_Recursointerfaz.MENSAJE_EXCEPCION_CARRITO_VACIO, 
                            new CarritoVacioException());                    
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
            catch (CarritoVacioException e)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, e);
                throw e;
            }
            catch (CantidadInvalidaException e)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, e);
                throw e;
            }
            catch (ItemInvalidoException e)
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
                    Entidad objeto = (Evento)FabricaEntidades.ObtenerEvento();
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

        #region ObtenerMonto
        /// <summary>
        /// Metodo del Presentador que obtiene la cantidad de Deuda total del carrito
        /// </summary>
        /// <param name="carrito">El carrito al que se le vera el monto</param>
        /// <returns>La deuda restante del carrito</returns>
        public float ObtenerMonto(Entidad carrito)
        {
            //Casteamos el carrito obtenido
            Carrito ElCarrito = carrito as Carrito;

            //Monto a devolver
            float precioFinal = 0;

            //Recorremos todos los implementos y obtenemos los valores
            foreach (KeyValuePair<Entidad, int> aux in ElCarrito.ListaImplemento)
            {
                //Casteamos la entidad como un implemento
                Implemento item = aux.Key as Implemento;

                //Anexo al precio total
                precioFinal += (float)item.Precio_Implemento * aux.Value;
            }

            //Obtenemos cada evento para ponerlos en la tabla
            foreach (KeyValuePair<Entidad, int> aux in ElCarrito.Listaevento)
            {
                //Casteamos la entidad como un evento
                Evento item = aux.Key as Evento;

                //Anexo al precio final
                precioFinal += item.Costo * aux.Value;
            }

            //Obtenemos cada matricula para ponerlas en la tabla            
            foreach (KeyValuePair<Entidad, int> aux in ElCarrito.Listamatricula)
            {
                //Casteamos la entidad como una matricula
                Matricula item = aux.Key as Matricula;

                //Anexo al precio final
                precioFinal += item.Costo * aux.Value;
            }

            //Descontamos del total los pagos que ya haya hecho
            precioFinal -= ElCarrito.montoPagado;

            return precioFinal;

        }
        #endregion

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
                laVista.LiteralDetallesProductos.Text = M16_Recursointerfaz.SALTO_LINEA + M16_Recursointerfaz.TITULO_IMAGEN + M16_Recursointerfaz.INICIO_TAG_IMAGEN + resultados.Imagen_implemento + M16_Recursointerfaz.FIN_TAG_IMAGEN +
                                                                      M16_Recursointerfaz.TITULO_NOMBRE + M16_Recursointerfaz.ABRE_LABEL_AUX2 + resultados.Nombre_Implemento + M16_Recursointerfaz.CIERRE_LABEL +
                                                                      M16_Recursointerfaz.TITULO_TIPO + M16_Recursointerfaz.ABRE_LABEL_AUX3 + resultados.Tipo_Implemento + M16_Recursointerfaz.CIERRE_LABEL +
                                                                      M16_Recursointerfaz.TITULO_MARCA + M16_Recursointerfaz.ABRE_LABEL_AUX4 + resultados.Marca_Implemento + M16_Recursointerfaz.CIERRE_LABEL +
                                                                      M16_Recursointerfaz.TITULO_COLOR + M16_Recursointerfaz.ABRE_LABEL_AUX5 + resultados.Color_Implemento + M16_Recursointerfaz.CIERRE_LABEL +
                                                                      M16_Recursointerfaz.TITULO_TALLA + M16_Recursointerfaz.ABRE_LABEL_AUX6 + resultados.Talla_Implemento + M16_Recursointerfaz.CIERRE_LABEL +
                                                                      M16_Recursointerfaz.TITULO_STATUS + M16_Recursointerfaz.ABRE_LABEL_AUX7 + resultados.Estatus_Implemento + M16_Recursointerfaz.CIERRE_LABEL +
                                                                      M16_Recursointerfaz.TITULO_PRECIO + M16_Recursointerfaz.ABRE_LABEL_AUX8 + resultados.Precio_Implemento + M16_Recursointerfaz.CIERRE_LABEL +
                                                                      M16_Recursointerfaz.TITULO_DESCRIPCIONES + M16_Recursointerfaz.ABRE_LABEL_AUX9 + resultados.Descripcion_Implemento + M16_Recursointerfaz.CIERRE_LABEL;
                
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
            try
            {
                //Escribo en el logger la entrada a este metodo
                Logger.EscribirInfo(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name,
                    M16_Recursointerfaz.MENSAJE_ENTRADA_LOGGER,
                    System.Reflection.MethodBase.GetCurrentMethod().Name);

                //Casteamos
                Comando<Entidad> DetalleProducto = FabricaComandos.CrearComandoDetallarProducto(implemento);
                Implemento elImplemento = (Implemento)DetalleProducto.Ejecutar();

                //Escribo en el logger la salida a este metodo
                Logger.EscribirInfo(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name,
                    M16_Recursointerfaz.MENSAJE_SALIDA_LOGGER, System.Reflection.MethodBase.GetCurrentMethod().Name);

                // Retornamos el Implemento
                return elImplemento;
            }

            #region Catches
            catch (PersonaNoValidaException ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                throw ex;
            }
            catch (LoggerException ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                throw ex;

            }
            catch (ArgumentNullException ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                throw ex;
            }
            catch (FormatException ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                throw ex;

            }
            catch (OverflowException ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                throw ex;

            }
            catch (ParametroInvalidoException ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                throw ex;
            }
            catch (ExceptionSKDConexionBD ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                throw ex;

            }
            catch (ExceptionSKD ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                throw ex;

            }
            catch (Exception ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                throw ex;
            }

            #endregion
        }

        #endregion
        
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
                laVista.LiteralDetallesEventos.Text =   M16_Recursointerfaz.SALTO_LINEA + M16_Recursointerfaz.TITULO_NOMBRE + M16_Recursointerfaz.ABRE_LABEL_AUX1 + resultados.Nombre + M16_Recursointerfaz.CIERRE_LABEL +
                                                        M16_Recursointerfaz.TITULO_DESCRIPCION + M16_Recursointerfaz.ABRE_LABEL_AUX2 + resultados.Descripcion + M16_Recursointerfaz.CIERRE_LABEL +
                                                        M16_Recursointerfaz.TITULO_COSTO + M16_Recursointerfaz.ABRE_LABEL_AUX3 + resultados.Costo + M16_Recursointerfaz.CIERRE_LABEL;

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
            try
            {
                //Escribo en el logger la entrada a este metodo
                Logger.EscribirInfo(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name,
                    M16_Recursointerfaz.MENSAJE_ENTRADA_LOGGER,
                    System.Reflection.MethodBase.GetCurrentMethod().Name);

                //Casteamos
                Comando<Entidad> DetalleEvento = FabricaComandos.CrearComandoDetallarEvento(evento);
                Evento elEvento = (Evento)DetalleEvento.Ejecutar();

                //Escribo en el logger la salida a este metodo
                Logger.EscribirInfo(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name,
                    M16_Recursointerfaz.MENSAJE_SALIDA_LOGGER, System.Reflection.MethodBase.GetCurrentMethod().Name);

                // Retornamos el Evento
                return elEvento;
            }

            #region Catches
            catch (PersonaNoValidaException ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                throw ex;
            }
            catch (LoggerException ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                throw ex;

            }
            catch (ArgumentNullException ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                throw ex;
            }
            catch (FormatException ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                throw ex;

            }
            catch (OverflowException ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                throw ex;

            }
            catch (ParametroInvalidoException ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                throw ex;
            }
            catch (ExceptionSKDConexionBD ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                throw ex;

            }
            catch (ExceptionSKD ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                throw ex;

            }
            catch (Exception ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                throw ex;
            }

            #endregion
        }

        #endregion
        
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
                laVista.LiteralDetallesMensualidades.Text = M16_Recursointerfaz.SALTO_LINEA + M16_Recursointerfaz.TITULO_ID_MATRICULA + M16_Recursointerfaz.ABRE_LABEL_AUX1 + resultados.Id + M16_Recursointerfaz.CIERRE_LABEL +
                                                                      M16_Recursointerfaz.TITULO_IDENTIFICADOR + M16_Recursointerfaz.ABRE_LABEL_AUX2 + resultados.Identificador + M16_Recursointerfaz.CIERRE_LABEL +
                                                                      M16_Recursointerfaz.TITULO_COSTO + M16_Recursointerfaz.ABRE_LABEL_AUX3 + resultados.Costo + M16_Recursointerfaz.CIERRE_LABEL +
                                                                      M16_Recursointerfaz.TITULO_FECHA_PAGO + M16_Recursointerfaz.ABRE_LABEL_AUX4 + resultados.UltimaFechaPago + M16_Recursointerfaz.CIERRE_LABEL +
                                                                      M16_Recursointerfaz.TITULO_DOJO_PERTENECE + M16_Recursointerfaz.ABRE_LABEL_AUX5 + resultados.Dojo_Matricula.Nombre_dojo + M16_Recursointerfaz.CIERRE_LABEL;

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
            try
            {
                //Escribo en el logger la entrada a este metodo
                Logger.EscribirInfo(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name,
                    M16_Recursointerfaz.MENSAJE_ENTRADA_LOGGER,
                    System.Reflection.MethodBase.GetCurrentMethod().Name);

                //Casteamos
                Comando<Entidad> DetalleMatricula = FabricaComandos.CrearComandoDetallarMatricula(matricula);
                Matricula laMatricula = (Matricula)DetalleMatricula.Ejecutar();

                //Escribo en el logger la salida a este metodo
                Logger.EscribirInfo(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name,
                    M16_Recursointerfaz.MENSAJE_SALIDA_LOGGER, System.Reflection.MethodBase.GetCurrentMethod().Name);

                // Retornamos la Matricula
                return laMatricula;
            }

            #region Catches
            catch (PersonaNoValidaException ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                throw ex;
            }
            catch (LoggerException ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                throw ex;

            }
            catch (ArgumentNullException ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                throw ex;
            }
            catch (FormatException ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                throw ex;

            }
            catch (OverflowException ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                throw ex;

            }
            catch (ParametroInvalidoException ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                throw ex;
            }
            catch (ExceptionSKDConexionBD ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                throw ex;

            }
            catch (ExceptionSKD ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                throw ex;

            }
            catch (Exception ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                throw ex;
            }

            #endregion
        }

        #endregion

        #endregion

    }
}
