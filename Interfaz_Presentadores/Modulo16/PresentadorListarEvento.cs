using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Interfaz_Contratos.Modulo16;
using DominioSKD.Entidades.Modulo9;
using DominioSKD.Entidades.Modulo16;
using DominioSKD.Fabrica;
using DominioSKD;
using LogicaNegociosSKD.Fabrica;
using LogicaNegociosSKD;
using LogicaNegociosSKD.Comandos.Modulo16;
using System.Web;
using System.Web.UI.WebControls;
using System.Web.UI;

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
                Comando<List<Entidad>> comandoListarEventos = FabricaComandos.CrearComandoConsultarTodosEventos();

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
                    celda.Text = item.Nombre;

                    //Agrego la Celda a la fila
                    fila.Cells.Add(celda);

                    //Nueva celda que tendra la descripcion del evento
                    celda = new TableCell();
                    celda.Text = item.Descripcion;;

                    //Agrego la celda a la fila
                    fila.Cells.Add(celda);

                    //Nueva celda que tendra el costo del evento
                    celda = new TableCell();
                    celda.Text = item.Costo.ToString(); ;

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
                    boton.CssClass = "btn btn-primary glyphicon glyphicon-info-sign";
                    boton.ID = "Evento-" + item.Id_evento.ToString();
                    //boton.Click += AgregarCarrito;

                    //Agrego la celda a la fila
                    fila.Cells.Add(celda);

                    //Agrego la fila a la tabla
                    vista.tablaEventos.Rows.Add(fila);

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
        /// <param name="evento">El evento que se ha mostrar en detalle</param>
        public void DetalleEvento_Event(object sender, CommandEventArgs e)
        {

            string id = e.CommandName;
            Evento evento = new Evento();
            evento.Id = int.Parse(id);

            Evento resultados = DetalleEvento(evento);

            // Variables para imprimir en el modal
            vista.LiteralDetallesEventos.Text = "</br>"+"<h3>Nombre</h3>" + "<label id='aux1' >" +resultados.Nombre + "</label>" + "<h3>Descripcion</h3>" + "<label id='aux2' >" +resultados.Descripcion + "</label>"+"<h3>Costo</h3>" + "<label id='aux3' >" +resultados.Costo + "</label>"  ;
            vista.ejecutarScript();    
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

        // Colocar Codigo 
        #endregion

    }
}
