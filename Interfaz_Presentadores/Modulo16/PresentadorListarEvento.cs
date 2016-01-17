using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Interfaz_Contratos.Modulo16;
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
using DominioSKD;


namespace Interfaz_Presentadores.Modulo16
{
    public class PresentadorListarEvento
    {
        #region Atributos
        private IContratoListarEvento vista;
        #endregion

        #region Constructores
        /// <summary>
        /// Constructor del presentador
        /// </summary>
        /// <param name="laVista">instancia de la vista</param>
        public PresentadorListarEvento(IContratoListarEvento laVista)
        {
            vista = laVista;
            
        }
        #endregion

        #region Metodo para el consultar de la lista de eventos
        /// <summary>
        /// metodo para consultar la lista de los Eventos
        /// </summary>
        public void consultarEventos()
        {
            try
            {
                //Escribo en el logger la entrada a este metodo
                Logger.EscribirInfo(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name,
                    M16_Recursointerfaz.MENSAJE_ENTRADA_LOGGER,
                    System.Reflection.MethodBase.GetCurrentMethod().Name);

                //Instancio el comando para listar el evento
                Comando<List<Entidad>> comandoListarEventos = FabricaComandos.CrearComandoConsultarTodosEventos();

                //Casteamos
                List<Entidad> laLista = comandoListarEventos.Ejecutar();

                //Obtenemos cada evento para ponerlos en la tabla
                foreach (Entidad aux in laLista)
                {
                    //Casteamos la entidad como un evento
                    Evento item = (Evento)aux;

                    //Creamos la nueva fila que ira en la tabla
                    TableRow fila = new TableRow();

                    //Nueva celda que tendra el nombre del evento
                    TableCell celda = new TableCell();
                    celda.Text = item.Nombre.ToString();

                    //Agrego la Celda a la fila
                    fila.Cells.Add(celda);

                    //Nueva celda que tendra la descripcion del evento
                    celda = new TableCell();
                    celda.Text = item.Descripcion.ToString();

                    //Agrego la celda a la fila
                    fila.Cells.Add(celda);

                    //Nueva celda que tendra el costo del evento
                    celda = new TableCell();
                    celda.Text = item.Costo.ToString();

                    //Agrego la celda a la fila
                    fila.Cells.Add(celda);

                    //Nueva celda que tendra el ComboBox para poner la cantidad del evento a escoger

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
                    boton.ID = "Evento-" + item.Id_evento.ToString();
                    boton.Command +=  DetalleEvento_Event;
                    boton.CssClass = "btn btn-primary glyphicon glyphicon-info-sign";
                    boton.CommandName = item.Id_evento.ToString();                 
                    celda.Controls.Add(boton);

                    //Boton de Agregar a Carrito
                    boton = new Button();
                    boton.ID = "Agregar-" + item.Id_evento.ToString();
                    boton.Click += AgregarCarrito;
                    boton.CssClass = "btn btn-success glyphicon glyphicon-shopping-cart";                    
                    celda.Controls.Add(boton);                   

                    //Agrego la celda a la fila
                    fila.Cells.Add(celda);

                    //Agrego la fila a la tabla
                    vista.tablaEventos.Rows.Add(fila);

                    //Escribo en el logger la salida a este metodo
                    Logger.EscribirInfo(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name,
                        M16_Recursointerfaz.MENSAJE_SALIDA_LOGGER, System.Reflection.MethodBase.GetCurrentMethod().Name);

                }

            }
            #region Catches
            catch (PersonaNoValidaException e)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, e);

            }
            catch (LoggerException e)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, e);

            }
            catch (ArgumentNullException e)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, e);

            }
            catch (FormatException e)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, e);

            }
            catch (OverflowException e)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, e);

            }
            catch (ParametroInvalidoException e)
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
            try
            {
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
                vista.LiteralDetallesEventos.Text = "</br>" + "<h3>Nombre</h3>" + "<label id='aux1' >" + resultados.Nombre + "</label>" +
                                                            "<h3>Descripcion</h3>" + "<label id='aux2' >" + resultados.Descripcion + "</label>" +
                                                            "<h3>Costo</h3>" + "<label id='aux3' >" + resultados.Costo + "</label>";

                //Escribo en el logger la salida a este metodo
                Logger.EscribirInfo(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name,
                    M16_Recursointerfaz.MENSAJE_SALIDA_LOGGER, System.Reflection.MethodBase.GetCurrentMethod().Name);

                // Ejecutamos el Script
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

        #region Metodo para Agregar el Evento al Carrito
        /// <summary>
        /// Metodo del presentador que agrega un evento al carrito del usuario
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
        }
        #endregion

    }
}
