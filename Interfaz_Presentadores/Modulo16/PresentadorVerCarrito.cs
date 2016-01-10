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
                Button boton = new Button();
                boton.Click += Modificar_Carrito;
                boton.CssClass = "btn btn-success glyphicon glyphicon-shopping-cart";
                boton.ID = "Implemento-" + item.Id_Implemento.ToString();
                celda.Controls.Add(boton);

                //Boton informacion
                boton = new Button();
                boton.CssClass = "btn btn-primary glyphicon glyphicon-info-sign";
                boton.ID = "Informacion-" + item.Id_Implemento.ToString();

                //Aqui agregamos atributos para que pueda hacer la llamada de cargar los modales
                boton.Attributes.Add("data-toggle", "modal");
                boton.Attributes.Add("data-target", "#modal-info1");

                //Se modifica para que el boton no haga postback
                boton.OnClientClick = "return false;";
                boton.UseSubmitBehavior = false;
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

                //Nueva celda que tendra el costo del implemento
                celda = new TableCell();
                celda.Text = item.Costo.ToString();

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
                Button boton = new Button();
                boton.Click += Modificar_Carrito;
                boton.CssClass = "btn btn-success glyphicon glyphicon-shopping-cart";
                boton.ID = "Evento-" + item.Id_evento.ToString();
                celda.Controls.Add(boton);

                //Boton informacion
                boton = new Button();
                boton.CssClass = "btn btn-primary glyphicon glyphicon-info-sign";
                boton.ID = "Informacion-" + item.Id_evento.ToString();

                //Aqui agregamos atributos para que pueda hacer la llamada de cargar los modales
                boton.Attributes.Add("data-toggle", "modal");
                boton.Attributes.Add("data-target", "#modal-info2");

                //Se modifica para que el boton no haga postback
                boton.OnClientClick = "return false;";
                boton.UseSubmitBehavior = false;
                celda.Controls.Add(boton);

                //Agrego la celda a la fila
                fila.Cells.Add(celda);

                //Agrego la fila a la tabla
                this.laVista.tablaEvento.Rows.Add(fila);
            }

            //Obtenemos cada implemento para ponerlos en la tabla            
            foreach (KeyValuePair<Entidad, int> aux in elCarrito.Listamatricula)
            {
                //Casteamos la entidad como una matricula
                Matricula item = aux.Key as Matricula;

                //Creamos la nueva fila que ira en la tabla
                TableRow fila = new TableRow();

                //Nueva celda que tendra el nombre del evento
                TableCell celda = new TableCell();
                celda.Text = item.Identificador;

                //Agrego la Celda a la fila
                fila.Cells.Add(celda);

                //Nueva celda que tendra el costo del implemento
                celda = new TableCell();
                celda.Text = item.Costo.ToString();

                //Agrego la celda a la fila
                fila.Cells.Add(celda);

                //Nueva celda que tendra el textbox para poner la cantidad del implemento
                celda = new TableCell();
                TextBox texto = new TextBox();
                texto.Text = aux.Value.ToString();
                celda.Controls.Add(texto);

                //Agrego la celda a la fila
                fila.Cells.Add(celda);

                //Celda que tendra los botones de Modificar y Eliminar
                celda = new TableCell();
                Button boton = new Button();
                boton.Click += Modificar_Carrito;
                boton.CssClass = "btn btn-success glyphicon glyphicon-shopping-cart";
                boton.ID = "Evento-" + item.Id.ToString();
                celda.Controls.Add(boton);                

                //Se modifica para que el boton no haga postback
                boton.OnClientClick = "return false;";
                boton.UseSubmitBehavior = false;
                celda.Controls.Add(boton);

                //Agrego la celda a la fila
                fila.Cells.Add(celda);

                //Agrego la fila a la tabla
                this.laVista.tablaMatricula.Rows.Add(fila);
            }
        }
        #endregion

        #region ModificarCarrito
        /// <summary>
        /// Metodo del presentador que modifica la cantidad de un item determinado en el carrito de una persona
        /// </summary>
        /// <param name="sender">El boton que manda la accion</param>
        /// <param name="e">El evento</param>
        void Modificar_Carrito(object sender, EventArgs e)
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
        #endregion

    }
}
