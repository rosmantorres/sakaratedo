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
using LogicaNegociosSKD.Comandos.Modulo16;
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
        public void consultarProductos()
        {
            try
            {
                Comando<List<Entidad>> comandoListarProductos = FabricaComandos.CrearComandoConsultarTodosProductos();

                List<Entidad> laLista = comandoListarProductos.Ejecutar();

                //Obtenemos cada producto para ponerlos en la tabla
                foreach (Entidad aux in laLista)
                {
                    //Casteamos la entidad como un implemento
                    Implemento item = (Implemento)aux;

                    //Creamos la nueva fila que ira en la tabla
                    TableRow fila = new TableRow();

                    //Nueva celda que tendra el id del Producto
                    TableCell celda = new TableCell();
                    //celda.Text = item.Id_Implemento.ToString();

                    //Agrego la Celda a la fila
                   // fila.Cells.Add(celda);

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

                    //Nueva celda que tendra el nombre del dojo donde se encuentra disponible
                    celda = new TableCell();
                    celda.Text = item.Dojo_Implemento.Nombre_dojo.ToString();

                    //Agrego la celda a la fila
                    fila.Cells.Add(celda);

                    //Nueva celda que tendra el ComboBox para poner la cantidad del productos a escoger

                    celda = new TableCell();
                    DropDownList ddl = new DropDownList();
                    ddl.Items.Add(new ListItem("1","1"));
                    celda.Controls.Add(ddl);
                    ddl.Items.Add(new ListItem("2", "2"));
                    celda.Controls.Add(ddl);
                    ddl.Items.Add(new ListItem("3", "3"));
                    celda.Controls.Add(ddl);
                    ddl.Items.Add(new ListItem("4", "4"));
                    celda.Controls.Add(ddl);
                    ddl.Items.Add(new ListItem("5", "5"));
                    celda.Controls.Add(ddl);
                    ddl.Items.Add(new ListItem("6", "6"));
                    celda.Controls.Add(ddl);
                    ddl.Items.Add(new ListItem("7", "7"));
                    celda.Controls.Add(ddl);
                    ddl.Items.Add(new ListItem("8", "8"));
                    celda.Controls.Add(ddl);
                    ddl.Items.Add(new ListItem("9", "9"));
                    celda.Controls.Add(ddl);
                    ddl.Items.Add(new ListItem("10", "10"));
                    celda.Controls.Add(ddl);

                    //Agrego la celda a la fila
                    fila.Cells.Add(celda);

                    //Celda que tendra los botones de Detallar y Agregar a Carrito
                    celda = new TableCell();
                    Button boton = new Button();
                    boton.ID = "Producto-" + item.Id_Implemento.ToString();
                    boton.Command +=  DetalleProducto_Prod;
                    boton.CssClass = "btn btn-primary glyphicon glyphicon-info-sign";
                    boton.CommandName = item.Id_Implemento.ToString();                
                    celda.Controls.Add(boton);

                    //Boton de Agregar a Carrito
                    //boton = new Button();
                    //boton.ID = "Agregar-" + item.Id_Implemento.ToString();
                    //boton.Click += AgregarCarrito;
                    //boton.CssClass = "btn btn-success glyphicon glyphicon-shopping-cart";                    
                    //celda.Controls.Add(boton);                   

                    //Agrego la celda a la fila
                    fila.Cells.Add(celda);

                    //Agrego la fila a la tabla
                    vista.tablaProductos.Rows.Add(fila);

                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region Metodos para el detalle del evento
        /// <summary>
        /// Metodo del presentador que pinta el detalle en el modal
        /// </summary>
        /// <param name="producto">El Producto que se ha de mostrar en detalle</param>
        public void DetalleProducto_Prod(object sender, CommandEventArgs e)
        {

            string id = e.CommandName;
            Implemento implemento = new Implemento();
            implemento.Id_Implemento = int.Parse(id);

            Implemento resultados = DetalleImplemento(implemento);

            // Variables para imprimir en el modal
            vista.LiteralDetallesProductos.Text = "</br>" + "<h3>Imagen del Producto</h3>" + "<label id='aux1' >" + resultados.Imagen_implemento + "</label>" +
                                                              "<h3>Nombre</h3>" + "<label id='aux2' >" + resultados.Nombre_Implemento + "</label>" +
                                                              "<h3>Tipo</h3>" + "<label id='aux3' >" + resultados.Tipo_Implemento + "</label>" +
                                                              "<h3>Marca</h3>" + "<label id='aux4' >" + resultados.Marca_Implemento + "</label>" +
                                                              "<h3>Color</h3>" + "<label id='aux5' >" + resultados.Color_Implemento + "</label>" +
                                                              "<h3>Talla</h3>" + "<label id='aux6' >" + resultados.Talla_Implemento + "</label>" +
                                                              "<h3>Estatus</h3>" + "<label id='aux7' >" + resultados.Estatus_Implemento + "</label>" +
                                                              "<h3>Precio</h3>" + "<label id='aux8' >" + resultados.Precio_Implemento + "</label>" +
                                                              "<h3>Descripcion</h3>" + "<label id='aux9' >" + resultados.Descripcion_Implemento + "</label>";
                                                              
            vista.ejecutarScript();    
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
       /* public void AgregarCarrito(object sender, EventArgs ec)
        {
            try
            {
                //Escribo en el logger la entrada a este metodo
                Logger.EscribirInfo(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name,
                    M16_Recursointerfaz.MENSAJE_ENTRADA_LOGGER,
                    System.Reflection.MethodBase.GetCurrentMethod().Name);

                //Persona que eventualmente la buscaremos por el session
                Entidad persona = (Persona)FabricaEntidades.ObtenerPersona();
                persona.Id= int.Parse(HttpContext.Current.Session[RecursosInterfazMaster.sessionUsuarioID].ToString());

                //Transformo el boton y obtengo la informacion de que item quiero agregar y su ID
                Button aux = (Button)sender;
                String[] datos = aux.ID.Split('-');

                //Creo la fabrica y el evento asignandole su ID
                FabricaEntidades fabrica = new FabricaEntidades();
                Evento evento = (Evento)fabrica.ObtenerEvento();
                evento.Id_evento = int.Parse(datos[1]);

                //Respuesta de la accion de agregar y la cantidad que se desea de ese item
                bool respuesta = false;
                int cantidad = 0;

                //Recorro cada fila para saber a cual me refiero y obtener la cantidad a modificar
                foreach (TableRow aux2 in this.vista.tablaEventos.Rows)
                {
                    //Si la fila no es de tipo Header puedo comenzar a buscar
                    if ((aux2 is TableHeaderRow) != true)
                    {
                        //En la celda 4 siempre estaran los botones, casteo el boton
                        Button aux3 = aux2.Cells[4].Controls[1] as Button;

                        //Si el ID del boton en la fila actual corresponde con el ID del boton que realizo la accion
                        //Obtenemos el numero del textbox que el usuario desea
                        if (aux3.ID == aux.ID)
                        {
                            //En la celda 3 siempre estara el combobox, lo obtengo y agarro la cantidad que el usuario desea
                            DropDownList lacantidad = aux2.Cells[3].Controls[0] as DropDownList;
                            cantidad = int.Parse(lacantidad.SelectedValue);
                            break;
                        }
                    }
                }

                //Obtengo el comando que Agregara el Item y ejecuto la accion correspondiente
                Comando<bool> comando = FabricaComandos.CrearComandoAgregarItem(persona, evento, 2, cantidad);
                respuesta = comando.Ejecutar();

                 //Escribo en el logger la salida a este metodo
                Logger.EscribirInfo(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name,
                    M16_Recursointerfaz.MENSAJE_ENTRADA_LOGGER, System.Reflection.MethodBase.GetCurrentMethod().Name);
                
                //Obtenemos la respuesta y redireccionamos para mostrar el exito o fallo
                if (respuesta)
                    HttpContext.Current.Response.Redirect("M16_VerCarrito.aspx?accion=3&exito=1",false);
                else
                    HttpContext.Current.Response.Redirect("M16_VerCarrito.aspx?accion=3&exito=0",false);
                
            }            
            catch (LoggerException e)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, e);
               
            }
            catch (ItemInvalidoException e)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, e);
               
            }
            catch (PersonaNoValidaException e)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, e);
                
            }
            catch (OpcionItemErroneoException e)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, e);
                
            }
            catch (ParseoVacioException e)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, e);
                
            }
            catch (ParseoFormatoInvalidoException e)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, e);
              
            }
            catch (ParseoEnSobrecargaException e)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, e);
           
            }
            catch (ParametroInvalidoException e)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, e);
               
            }
            catch (ExceptionSKDConexionBD e)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, e);
              
            }
            catch (ExceptionSKD e)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, e);
            
            }
            catch (Exception e)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, e);                
            }
        } */
        #endregion

    }
}
