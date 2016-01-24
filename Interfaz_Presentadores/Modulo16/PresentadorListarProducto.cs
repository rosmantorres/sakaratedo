using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Interfaz_Contratos.Modulo16;
using DominioSKD.Entidades.Modulo15;
using DominioSKD.Entidades.Modulo16;
using DominioSKD.Fabrica;
using DominioSKD;
using LogicaNegociosSKD.Fabrica;
using LogicaNegociosSKD;
using LogicaNegociosSKD.Comandos.Modulo15;
using System.Web;
using System.Web.UI.WebControls;
using System.Web.UI;
using ExcepcionesSKD;
using ExcepcionesSKD.Modulo16;
using Interfaz_Presentadores.Master;
using DominioSKD.Entidades.Modulo1;

namespace Interfaz_Presentadores.Modulo16
{
    public class PresentadorListarProducto
    {
        #region Atributos
        private IContratoListarProducto vista;
        #endregion

        #region Constructores
        /// <summary>
        /// Constructor del presentador
        /// </summary>
        /// <param name="laVista">instancia de la vista</param>
        public PresentadorListarProducto(IContratoListarProducto laVista)
        {
            vista = laVista;
            
        }
        #endregion

        #region Metodo para el consultar de la lista de productos
        /// <summary>
        /// metodo para consultar la lista de los productos
        /// </summary>
        public void consultarProductos(int persona)
        {
            try
            {
                //Escribo en el logger la entrada a este metodo
                Logger.EscribirInfo(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name,
                    M16_Recursointerfaz.MENSAJE_ENTRADA_LOGGER,
                    System.Reflection.MethodBase.GetCurrentMethod().Name);

                //Instancio el comando para listar el evento
                Comando<Entidad> comandoListarProductos = FabricaComandos.CrearComandoConsultarTodosProductos();

                // Casteamos el parametro
                PersonaM1 param = new PersonaM1();
                param._Id = persona;
                comandoListarProductos.LaEntidad = param;

                // Invocamos el comando
                ListaImplemento com = (ListaImplemento)comandoListarProductos.Ejecutar();

                //Obtenemos cada producto para ponerlos en la tabla
                foreach (Entidad aux in com.ListaImplementos)
                {
                    //Casteamos la entidad como un implemento
                    Implemento item = (Implemento)aux;

                    //Creamos la nueva fila que ira en la tabla
                    TableRow fila = new TableRow();

                    //Nueva celda que tendra el id del Producto
                    TableCell celda = new TableCell();
                    celda.Text = item.Id_Implemento.ToString();

                    //Agrego la Celda a la fila
                    fila.Cells.Add(celda);

                    //Nueva celda que tendra el nombre del producto
                    celda = new TableCell();
                    celda.Text = item.Nombre_Implemento.ToString();

                    //Agrego la celda a la fila
                    fila.Cells.Add(celda);

                    //Nueva celda que tendra el tipo del producto
                    celda = new TableCell();
                    celda.Text = item.Tipo_Implemento.ToString();

                    //Agrego la celda a la fila
                    fila.Cells.Add(celda);

                    //Nueva celda que tendra la marca del producto
                    celda = new TableCell();
                    celda.Text = item.Marca_Implemento.ToString();

                    //Agrego la celda a la fila
                    fila.Cells.Add(celda);

                    //Nueva celda que tendra el precio del implemento
                    celda = new TableCell();
                    celda.Text = item.Precio_Implemento.ToString();

                    //Agrego la celda a la fila
                    fila.Cells.Add(celda);

                    //Nueva celda que tendra la cantidad total del producto en inventario
                    celda = new TableCell();
                    celda.Text = item.Cantida_implemento.ToString();

                    //Agrego la celda a la fila
                    fila.Cells.Add(celda);

                    //Nueva celda que tendra el nombre del dojo al que pertenece
                    celda = new TableCell();
                    celda.Text = item.Dojo_Implemento.Nombre_dojo.ToString();

                    //Agrego la celda a la fila
                    fila.Cells.Add(celda);

                    //Nueva celda que tendra el ComboBox para poner la cantidad del productos a escoger

                    celda = new TableCell();
                    DropDownList ddl = new DropDownList();
                    ddl.Items.Add(new ListItem(M16_Recursointerfaz.Uno, M16_Recursointerfaz.Uno));
                    celda.Controls.Add(ddl);
                    ddl.Items.Add(new ListItem(M16_Recursointerfaz.Dos, M16_Recursointerfaz.Dos));
                    celda.Controls.Add(ddl);
                    ddl.Items.Add(new ListItem(M16_Recursointerfaz.Tres, M16_Recursointerfaz.Tres));
                    celda.Controls.Add(ddl);
                    ddl.Items.Add(new ListItem(M16_Recursointerfaz.Cuatro, M16_Recursointerfaz.Cuatro));
                    celda.Controls.Add(ddl);
                    ddl.Items.Add(new ListItem(M16_Recursointerfaz.Cinco, M16_Recursointerfaz.Cinco));
                    celda.Controls.Add(ddl);
                    ddl.Items.Add(new ListItem(M16_Recursointerfaz.Seis, M16_Recursointerfaz.Seis));
                    celda.Controls.Add(ddl);
                    ddl.Items.Add(new ListItem(M16_Recursointerfaz.Siete, M16_Recursointerfaz.Siete));
                    celda.Controls.Add(ddl);
                    ddl.Items.Add(new ListItem(M16_Recursointerfaz.Ocho, M16_Recursointerfaz.Ocho));
                    celda.Controls.Add(ddl);
                    ddl.Items.Add(new ListItem(M16_Recursointerfaz.Nueve, M16_Recursointerfaz.Nueve));
                    celda.Controls.Add(ddl);
                    ddl.Items.Add(new ListItem(M16_Recursointerfaz.Diez, M16_Recursointerfaz.Diez));
                    celda.Controls.Add(ddl);

                    //Agrego la celda a la fila
                    fila.Cells.Add(celda);

                    //Celda que tendra los botones de Detallar y Agregar a Carrito
                    celda = new TableCell();
                    Button boton = new Button();
                    boton.ID = M16_Recursointerfaz.REFERENCIA_PRODUCTO + item.Id_Implemento.ToString();
                    boton.Command +=  DetalleProducto_Prod;
                    boton.CssClass = "btn btn-primary glyphicon glyphicon-info-sign";
                    boton.CommandName = item.Id_Implemento.ToString();                
                    celda.Controls.Add(boton);

                    //Boton de Agregar a Carrito
                    boton = new Button();
                    boton.ID = M16_Recursointerfaz.REFERENCIA_AGREGAR + item.Id_Implemento.ToString();
                    boton.Click += AgregarCarrito;
                    boton.CssClass = "btn btn-success glyphicon glyphicon-shopping-cart";                    
                    celda.Controls.Add(boton);                   

                    //Agrego la celda a la fila
                    fila.Cells.Add(celda);

                    //Agrego la fila a la tabla
                    vista.tablaProductos.Rows.Add(fila);

                    //Escribo en el logger la salida a este metodo
                    Logger.EscribirInfo(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name,
                    M16_Recursointerfaz.MENSAJE_SALIDA_LOGGER, System.Reflection.MethodBase.GetCurrentMethod().Name);

                }

            }
            #region Catches

            catch (PersonaNoValidaException ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                HttpContext.Current.Response.Redirect(M16_Recursointerfaz.EXCEPTION_PERSONA_INVALIDA_LINK_PRODUCTO, false);
            }
            catch (LoggerException ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                HttpContext.Current.Response.Redirect(M16_Recursointerfaz.EXCEPTION_LOGGER_LINK_PRODUCTO, false);

            }
            catch (ArgumentNullException ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                HttpContext.Current.Response.Redirect(M16_Recursointerfaz.EXCEPTION_PARSEO_VACIO_LINK_PRODUCTO, false);
            }
            catch (FormatException ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                HttpContext.Current.Response.Redirect(M16_Recursointerfaz.EXCEPTION_FORMATO_LINK_PRODUCTO, false);

            }
            catch (OverflowException ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                HttpContext.Current.Response.Redirect(M16_Recursointerfaz.EXCEPTION_SOBRECARGA_LINK_PRODUCTO, false);

            }
            catch (ParametroInvalidoException ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                HttpContext.Current.Response.Redirect(M16_Recursointerfaz.EXCEPTION_PARAMETRO_INVALIDO_LINK_PRODUCTO, false);
            }
            catch (ExceptionSKDConexionBD ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                HttpContext.Current.Response.Redirect(M16_Recursointerfaz.EXCEPTION_CONEXIONBD_LINK_PRODUCTO, false);

            }
            catch (ExceptionSKD ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                HttpContext.Current.Response.Redirect(M16_Recursointerfaz.EXCEPTIONSKD_LINK_PRODUCTO, false);

            }
            catch (Exception ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                HttpContext.Current.Response.Redirect(M16_Recursointerfaz.EXCEPTION_LINK_PRODUCTO, false);
            }

            #endregion
        }
        #endregion

        #region Metodos para el detalle del Producto
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

                    // casteamos
                    Implemento resultados = DetalleImplemento(implemento);

                    // Variables para imprimir en el modal
                    vista.LiteralDetallesProductos.Text = "</br>" + "<h3>Imagen del Producto</h3>" + "<img width='150' height='150' src='" + resultados.Imagen_implemento + "' />" +
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
                    vista.ejecutarScript();  
                }
            #region Catches
            catch (PersonaNoValidaException ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);

            }
            catch (LoggerException ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);

            }
            catch (ArgumentNullException ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);

            }
            catch (FormatException ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);

            }
            catch (OverflowException ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);

            }
            catch (ParametroInvalidoException ex)
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

        #region Metodo para Agregar el Producto al Carrito
        /// <summary>
        /// Metodo del presentador que agrega un/unos producto/s al carrito del usuario
        /// </summary>
        /// <param name="sender">El objeto que ejecuta la accion</param>
        /// <param name="e">El arreglo de Eventos</param>
       public void AgregarCarrito(object sender, EventArgs ec)
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

                //Creo el implemento asignandole su ID                
                Implemento implemento = (Implemento)FabricaEntidades.ObtenerImplemento();
                implemento.Id = int.Parse(datos[1]);

                //Respuesta de la accion de agregar y la cantidad que se desea de ese item
                bool respuesta = false;
                int cantidad = 0;

                //Recorro cada fila para saber a cual me refiero y obtener la cantidad a agregar
                foreach (TableRow aux2 in this.vista.tablaProductos.Rows)
                {
                    //Si la fila no es de tipo Header puedo comenzar a buscar
                    if ((aux2 is TableHeaderRow) != true)
                    {
                        //En la celda 8 siempre estaran los botones, casteo el boton
                        Button aux3 = aux2.Cells[8].Controls[1] as Button;

                        //Si el ID del boton en la fila actual corresponde con el ID del boton que realizo la accion
                        //Obtenemos el numero del textbox que el usuario desea
                        if (aux3.ID == aux.ID)
                        {
                            /*En la celda 7 siempre estara el combobox,
                            lo obtengo y agarro la cantidad que el usuario desea*/
                            DropDownList lacantidad = aux2.Cells[7].Controls[0] as DropDownList;
                            cantidad = int.Parse(lacantidad.SelectedValue);

                            //Agrego el precio del implemento
                            implemento.Precio_Implemento = int.Parse(aux2.Cells[4].Text);
                            break;
                        }
                    }
                }

                //Obtengo el comando que Agregara el Item y ejecuto la accion correspondiente
                Comando<bool> comando = FabricaComandos.CrearComandoAgregarItem(persona, implemento, 1, cantidad);
                respuesta = comando.Ejecutar();

                //Escribo en el logger la salida a este metodo
                Logger.EscribirInfo(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name,
                    M16_Recursointerfaz.MENSAJE_ENTRADA_LOGGER, System.Reflection.MethodBase.GetCurrentMethod().Name);

                //Obtenemos la respuesta y redireccionamos para mostrar el exito o fallo
                if (respuesta)
                    HttpContext.Current.Response.Redirect(M16_Recursointerfaz.AGREGAR_LINK_EXITO, false);
                else
                    HttpContext.Current.Response.Redirect(M16_Recursointerfaz.AGREGAR_LINK_FALLO, false);

            }
            catch (LoggerException e)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, e);
                HttpContext.Current.Response.Redirect(M16_Recursointerfaz.EXCEPTION_LOGGER_LINK, false);
            }
            catch (ItemInvalidoException e)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, e);
                HttpContext.Current.Response.Redirect(M16_Recursointerfaz.EXCEPTION_ITEM_INVALIDO_LINK, false);
            }
            catch (CarritoConPagoException ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                HttpContext.Current.Response.Redirect(M16_Recursointerfaz.EXCEPCION_CARRITO_PAGO_LINK, false);
            }
            catch (PersonaNoValidaException e)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, e);
                HttpContext.Current.Response.Redirect(M16_Recursointerfaz.EXCEPTION_PERSONA_INVALIDA_LINK, false);
            }
            catch (OpcionItemErroneoException e)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, e);
                HttpContext.Current.Response.Redirect(M16_Recursointerfaz.EXCEPTION_OPCION_LINK, false);
            }
            catch (ParseoVacioException e)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, e);
                HttpContext.Current.Response.Redirect(M16_Recursointerfaz.EXCEPTION_PARSEO_VACIO_LINK, false);
            }
            catch (ParseoFormatoInvalidoException e)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, e);
                HttpContext.Current.Response.Redirect(M16_Recursointerfaz.EXCEPTION_FORMATO_LINK, false);
            }
            catch (ParseoEnSobrecargaException e)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, e);
                HttpContext.Current.Response.Redirect(M16_Recursointerfaz.EXCEPTION_SOBRECARGA_LINK, false);
            }
            catch (ParametroInvalidoException e)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, e);
                HttpContext.Current.Response.Redirect(M16_Recursointerfaz.EXCEPTION_PARAMETRO_INVALIDO_LINK, false);
            }
            catch (ExceptionSKDConexionBD e)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, e);
                HttpContext.Current.Response.Redirect(M16_Recursointerfaz.EXCEPTION_CONEXIONBD_LINK, false);
            }
            catch (ExceptionSKD e)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, e);
                HttpContext.Current.Response.Redirect(M16_Recursointerfaz.EXCEPTIONSKD_LINK, false);
            }
            catch (Exception e)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, e);
                HttpContext.Current.Response.Redirect(M16_Recursointerfaz.EXCEPTION_LINK, false);
            }
        }
        #endregion

    }
}
