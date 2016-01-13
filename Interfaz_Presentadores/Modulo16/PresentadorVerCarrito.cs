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
using DominioSKD.Entidades.Modulo9;
using DominioSKD.Entidades.Modulo6;
using System.Web.UI.WebControls;
using DominioSKD.Fabrica;
using DominioSKD.Entidades.Modulo1;
using System.Web;
using Interfaz_Presentadores.Master;
using ExcepcionesSKD;
using ExcepcionesSKD.Modulo16;

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
                //Creo la persona y le pongo su ID
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
                    boton.CssClass = "btn btn-success glyphicon glyphicon-shopping-cart";
                    boton.ID = "Implemento-" + item.Id_Implemento.ToString();
                    celda.Controls.Add(boton);

                    //Se modifica para que el boton no haga postback
                    boton.OnClientClick = "return false;";
                    boton.UseSubmitBehavior = false;
                    celda.Controls.Add(boton);

                    //Boton informacion
                    boton = new Button();
                    boton.ID = "elProducto-" + item.Id_Implemento.ToString();
                    boton.Command += DetalleProducto_Prod;
                    boton.CssClass = "btn btn-primary glyphicon glyphicon-info-sign";
                    boton.CommandName = item.Id_Implemento.ToString();
                    celda.Controls.Add(boton);

                    //Boton Eliminar
                    boton = new Button();
                    boton.Click += Eliminar_Item;
                    boton.CssClass = "btn btn-danger glyphicon glyphicon-remove-sign";
                    boton.ID = "EImplemento-" + item.Id_Implemento.ToString();
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
                    boton.CssClass = "btn btn-success glyphicon glyphicon-shopping-cart";
                    boton.ID = "Evento-" + item.Id_evento.ToString();
                    celda.Controls.Add(boton);

                    //Se modifica para que el boton no haga postback
                    boton.OnClientClick = "return false;";
                    boton.UseSubmitBehavior = false;
                    celda.Controls.Add(boton);

                    //Boton informacion
                    boton = new Button();
                    boton.ID = "elEvento-" + item.Id_evento.ToString();
                    boton.Command += DetalleEvento_Event;
                    boton.CssClass = "btn btn-primary glyphicon glyphicon-info-sign";
                    boton.CommandName = item.Id_evento.ToString();
                    celda.Controls.Add(boton);

                    //Boton Eliminar
                    boton = new Button();
                    boton.Click += Eliminar_Item;
                    boton.CssClass = "btn btn-danger glyphicon glyphicon-remove-sign";
                    boton.ID = "EEvento-" + item.Id_evento.ToString();
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
                    boton.CssClass = "btn btn-danger glyphicon glyphicon-remove-sign";
                    boton.ID = "EMatricula-" + item.Id.ToString();
                    celda.Controls.Add(boton);

                    //Boton informacion
                    boton = new Button();
                    boton.ID = "laMatricula-" + item.Id.ToString();
                    boton.Command += DetalleMatricula_Mat;
                    boton.CssClass = "btn btn-primary glyphicon glyphicon-info-sign";
                    boton.CommandName = item.Id.ToString();
                    celda.Controls.Add(boton);

                    //Agrego la celda a la fila
                    fila.Cells.Add(celda);

                    //Agrego la fila a la tabla
                    this.laVista.tablaMatricula.Rows.Add(fila);
                }            
            }
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
            catch (ExceptionSKDConexionBD e)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, e);
                HttpContext.Current.Response.Redirect("M16_VerCarrito.aspx?accion=4&exito=1", false);
                
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

        #region ModificarCarrito
        /// <summary>
        /// Metodo del presentador que modifica la cantidad de un item determinado en el carrito de una persona
        /// </summary>
        /// <param name="sender">El boton que manda la accion</param>
        /// <param name="e">El evento</param>
        public void Modificar_Carrito(object sender, EventArgs e)
        {
            //Persona que eventualmente la buscaremos por el session
            Entidad persona = (Persona)FabricaEntidades.ObtenerPersona();
            persona.Id = int.Parse(HttpContext.Current.Session[RecursosInterfazMaster.sessionUsuarioID].ToString());

            //Transformo el boton y obtengo la informacion de que item quiero agregar y su ID
            Button aux = (Button)sender;
            String[] datos = aux.ID.Split('-');

            //Cantidad Deseada nueva por el usuario
            int cantidad = 0;

            //Respuesta a obtener del comando, tipo de objeto
            bool respuesta = false;
            int TipoObjeto = 0;            

            //Si se trata de un implemento, me voy a la tabla correspondiente
            if (datos[0] == "Implemento")
            {
                //Recorro cada fila para saber a cual me refiero y obtener la cantidad a modificar
                foreach (TableRow aux2 in this.laVista.tablaImplemento.Rows)
                {
                    //Si la fila no es de tipo Header puedo comenzar a buscar
                    if ((aux2 is TableHeaderRow) != true)
                    {
                        //En la celda 3 siempre estaran los botones, casteo el boton
                        Button aux3 = aux2.Cells[3].Controls[0] as Button;

                        //Si el ID del boton en la fila actual corresponde con el ID del boton que realizo la accion
                        //Obtenemos el numero del textbox que el usuario desea
                        if (aux3.ID == aux.ID)
                        {
                            //En la celda 2 siempre estara el textbox, lo obtengo y agarro la cantidad que el usuario desea
                            TextBox eltexto = aux2.Cells[2].Controls[0] as TextBox;
                            cantidad = int.Parse(eltexto.Text);
                            break;
                        }
                    }
                }

                //Decimos que se trata de un implemento
                TipoObjeto = 1;

                //Pasamos el ID que vino del boton
                FabricaEntidades fabrica = new FabricaEntidades();
                Entidad objeto = (Implemento)fabrica.ObtenerImplemento();
                objeto.Id = int.Parse(datos[1]);

                //Instancio el comando para Registrar un Pago y obtengo el exito o fallo del proceso
                Comando<bool> ModificarCarrito = FabricaComandos.CrearComandoModificarCarrito(persona, objeto, TipoObjeto, cantidad);
                respuesta = ModificarCarrito.Ejecutar();
            }
            //Si es un Evento, me voy a la tabla correspondiente
            else if (datos[0] == "Evento")
            {
                //Recorro cada fila para saber a cual me refiero y obtener la cantidad a modificar
                foreach (TableRow aux2 in this.laVista.tablaEvento.Rows)
                {
                    //Si la fila no es de tipo Header puedo comenzar a buscar
                    if ((aux2 is TableHeaderRow) != true)
                    {
                        //En la celda 3 siempre estaran los botones, casteo el boton
                        Button aux3 = aux2.Cells[3].Controls[0] as Button;

                        //Si el ID del boton en la fila actual corresponde con el ID del boton que realizo la accion
                        //Obtenemos el numero del textbox que el usuario desea
                        if (aux3.ID == aux.ID)
                        {
                            //En la celda 2 siempre estara el textbox, lo obtengo y agarro la cantidad que el usuario desea
                            TextBox eltexto = aux2.Cells[2].Controls[0] as TextBox;
                            cantidad = int.Parse(eltexto.Text);
                            break;
                        }
                    }
                }

                //Decimos que se trata de un evento
                TipoObjeto = 2;

                //Pasamos el ID que vino del boton
                FabricaEntidades fabrica = new FabricaEntidades();
                Evento objeto = (Evento)fabrica.ObtenerEvento();
                objeto.Id_evento = int.Parse(datos[1]);

                //Instancio el comando para Registrar un Pago y obtengo el exito o fallo del proceso
                Comando<bool> ModificarCarrito = FabricaComandos.CrearComandoModificarCarrito
                    (persona, objeto, TipoObjeto, cantidad);
                respuesta = ModificarCarrito.Ejecutar();
            }            

            //Obtenemos la respuesta y redireccionamos para mostrar el exito o fallo
            if (respuesta)
                HttpContext.Current.Response.Redirect("M16_VerCarrito.aspx?accion=1&exito=1");
            else
                HttpContext.Current.Response.Redirect("M16_VerCarrito.aspx?accion=1&exito=0");
        }
        #endregion

        #region RegistrarPago
        /// <summary>
        /// Metodo del presentador que registra el pago de los productos que hay en el carrito de una persona
        /// </summary>
        /// <param name="idpersona">La persona que desea comprar los productos</param>
        /// <param name="pago">El tipo de pago con el cual realizo la transaccion</param>
        /// <returns>El exito o fallo del proceso</returns>
        public bool RegistrarPago(string idpersona, string pago)
        {
            //Instancio la fabrica, obtengo la entidad persona y asigno su ID
            FabricaEntidades fabrica = new FabricaEntidades();
            Entidad persona = (Persona)FabricaEntidades.ObtenerPersona();
            persona.Id = int.Parse(idpersona);

            //Instancio el comando para Registrar un Pago y obtengo el exito o fallo del proceso
            Comando<bool> registrarPago = FabricaComandos.CrearComandoRegistrarPago(persona, pago);
            bool respuesta = registrarPago.Ejecutar();

            //Retorno la respuesta
            return respuesta;
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
            //Persona que eventualmente la buscaremos por el session
            Entidad persona = (Persona)FabricaEntidades.ObtenerPersona();
            persona.Id = int.Parse(HttpContext.Current.Session[RecursosInterfazMaster.sessionUsuarioID].ToString());

            //Transformo el boton y obtengo la informacion de que item quiero agregar y su ID
            Button aux = (Button)sender;
            String[] datos = aux.ID.Split('-');
            //Respuesta a obtener del comando, tipo de objeto
            bool respuesta = false;
            int TipoObjeto = 0;

            //Si se trata de un implemento, me voy a la tabla correspondiente
            if (datos[0] == "EImplemento")
            {
                //Decimos que se trata de un implemento
                TipoObjeto = 1;

                //Pasamos el ID que vino del boton
                FabricaEntidades fabrica = new FabricaEntidades();
                Entidad objeto = (Implemento)fabrica.ObtenerImplemento();
                objeto.Id = int.Parse(datos[1]);

                //Instancio el comando para eliminar item y obtengo el exito o fallo del proceso
                Comando<bool> EliminarCarrito = FabricaComandos.CrearComandoeliminarItem(TipoObjeto,objeto.Id,persona.Id);
                respuesta = EliminarCarrito.Ejecutar();
            }
            //Si es un Evento, me voy a la tabla correspondiente
            else if (datos[0] == "EEvento")
            {
                //Decimos que se trata de un evento
                TipoObjeto = 3;

                //Pasamos el ID que vino del boton
                FabricaEntidades fabrica = new FabricaEntidades();
                Evento objeto = (Evento)fabrica.ObtenerEvento();
                objeto.Id = int.Parse(datos[1]);

                //Instancio el comando para eliminar el evento del carrito y obtengo el exito o fallo del proceso
                Comando<bool> EliminarCarrito = FabricaComandos.CrearComandoeliminarItem(TipoObjeto, objeto.Id, persona.Id);
                respuesta = EliminarCarrito.Ejecutar();
            }

            //Si se trata de una matricula, me voy a la tabla correspondiente
            else if (datos[0] == "EMatricula")
            {
                //Decimos que se trata de un implemento
                TipoObjeto = 2;

                //Pasamos el ID que vino del boton
                FabricaEntidades fabrica = new FabricaEntidades();
                Entidad objeto = (Matricula)fabrica.ObtenerMatricula();
                objeto.Id = int.Parse(datos[1]);

                //Instancio el comando para eliminar item y obtengo el exito o fallo del proceso
                Comando<bool> EliminarCarrito = FabricaComandos.CrearComandoeliminarItem(TipoObjeto, objeto.Id, persona.Id);
                respuesta = EliminarCarrito.Ejecutar();
            }

            //Obtenemos la respuesta y redireccionamos para mostrar el exito o fallo
            if (respuesta)
                HttpContext.Current.Response.Redirect("M16_VerCarrito.aspx?accion=5&exito=1");
            else
                HttpContext.Current.Response.Redirect("M16_VerCarrito.aspx?accion=5&exito=0");


             
        }
        #endregion

        #region Metodos para el detalle del Implemento
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
            laVista.LiteralDetallesProductos.Text = "</br>" + "<h3>Imagen del Producto</h3>" + "<label id='aux1' >" + resultados.Imagen_implemento + "</label>" +
                                                              "<h3>Nombre</h3>" + "<label id='aux2' >" + resultados.Nombre_Implemento + "</label>" +
                                                              "<h3>Tipo</h3>" + "<label id='aux3' >" + resultados.Tipo_Implemento + "</label>" +
                                                              "<h3>Marca</h3>" + "<label id='aux4' >" + resultados.Marca_Implemento + "</label>" +
                                                              "<h3>Color</h3>" + "<label id='aux5' >" + resultados.Color_Implemento + "</label>" +
                                                              "<h3>Talla</h3>" + "<label id='aux6' >" + resultados.Talla_Implemento + "</label>" +
                                                              "<h3>Estatus</h3>" + "<label id='aux7' >" + resultados.Estatus_Implemento + "</label>" +
                                                              "<h3>Precio</h3>" + "<label id='aux8' >" + resultados.Precio_Implemento + "</label>" +
                                                              "<h3>Descripcion</h3>" + "<label id='aux9' >" + resultados.Descripcion_Implemento + "</label>";

            laVista.ejecutarScriptImplemento();
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

        #region Metodos para el detalle del evento
        /// <summary>
        /// Metodo del presentador que pinta el detalle en el modal
        /// </summary>
        /// <param name="evento">El evento que se ha mostrar en detalle</param>
        public void DetalleEvento_Event(object sender, CommandEventArgs e)
        {

            string id = e.CommandName;
            Evento evento = new Evento();
            evento.Id = int.Parse(id);

            Evento resultados = DetalleEvento(evento);

            // Variables para imprimir en el modal
            laVista.LiteralDetallesEventos.Text = "</br>" + "<h3>Nombre</h3>" + "<label id='aux1' >" + resultados.Nombre + "</label>" +
                                                        "<h3>Descripcion</h3>" + "<label id='aux2' >" + resultados.Descripcion + "</label>" +
                                                        "<h3>Costo</h3>" + "<label id='aux3' >" + resultados.Costo + "</label>";
            laVista.ejecutarScriptEvento();
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

        #region Metodos para el detalle de la Mensualidad
        /// <summary>
        /// Metodo del presentador que pinta el detalle en el modal
        /// </summary>
        /// <param name="evento">La Mensualidad que se ha de mostrar en detalle</param>
        public void DetalleMatricula_Mat(object sender, CommandEventArgs e)
        {

            string id = e.CommandName;
            Matricula matricula = new Matricula();
            matricula.Id = int.Parse(id);

            Matricula resultados = DetalleMatricula(matricula);

            // Variables para imprimir en el modal
            laVista.LiteralDetallesMensualidades.Text = "</br>" + "<h3>Id Matricula</h3>" + "<label id='aux1' >" + resultados.Id + "</label>" +
                                                              "<h3>Identificador</h3>" + "<label id='aux2' >" + resultados.Identificador + "</label>" +
                                                              "<h3>Costo</h3>" + "<label id='aux3' >" + resultados.Costo + "</label>" +
                                                              "<h3>Ultima Fecha de Pago</h3>" + "<label id='aux4' >" + resultados.UltimaFechaPago + "</label>" +
                                                              "<h3>Nombre del Dojo al que pertenece</h3>" + "<label id='aux4' >" + resultados.Dojo_Matricula.Nombre_dojo + "</label>";


            laVista.ejecutarScriptMensualidad();
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
