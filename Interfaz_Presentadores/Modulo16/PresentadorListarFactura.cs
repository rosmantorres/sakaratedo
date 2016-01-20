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
using DominioSKD.Entidades.Modulo1;

namespace Interfaz_Presentadores.Modulo16
{
    public class PresentadorListarFactura
    {
       #region Atributos
        private IContratoListarFactura vista;
        #endregion

       #region Constructores
        /// <summary>
        /// Constructor del presentador
        /// </summary>
        /// <param name="laVista">instancia de la vista</param>
        public PresentadorListarFactura(IContratoListarFactura laVista)
        {
            vista = laVista;
            
        }
        #endregion

       #region Metodo para el consultar de la lista de Facturas
        /// <summary>
        /// metodo para consultar la lista de las Facturas
        /// </summary>
        public void consultarFacturas(int persona)
        {
            try
            {
                //Escribo en el logger la entrada a este metodo
                Logger.EscribirInfo(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name,
                    M16_Recursointerfaz.MENSAJE_ENTRADA_LOGGER,
                    System.Reflection.MethodBase.GetCurrentMethod().Name);

                //Instancio el comando para listar el evento
                FabricaComandos fabrica = new FabricaComandos();
                Comando<Entidad> comandoListarFacturas = fabrica.CrearComandoConsultarTodasFacturas();

                //Casteamos el parametro
                PersonaM1 param = new PersonaM1();
                param._Id = persona;
                comandoListarFacturas.LaEntidad = param;

                // Invocamos el Comando
                ListaCompra com = (ListaCompra)comandoListarFacturas.Ejecutar();

                //Obtenemos cada factura para ponerla en la tabla
                foreach (Entidad aux in com.ListaCompras)
                {
                    //Casteamos la entidad como una Compra
                    Compra item = (Compra)aux;

                    //Creamos la nueva fila que ira en la tabla
                    TableRow fila = new TableRow();

                    //Nueva celda que tendra el id de la factura 
                    TableCell celda = new TableCell();
                    celda.Text = item.Com_id.ToString();

                    //Agrego la Celda a la fila
                    fila.Cells.Add(celda);

                    //Nueva celda que tendra el tipo pago
                    celda = new TableCell();
                    celda.Text = item.Com_tipo_pago.ToString();

                    //Agrego la celda a la fila
                    fila.Cells.Add(celda);

                    //Nueva celda que tendra la fecha de la compra
                    celda = new TableCell();
                    celda.Text = item.Com_fecha_compra.ToString();

                    //Agrego la celda a la fila
                    fila.Cells.Add(celda);

                    //Nueva celda que tendra el estado de la compra
                    celda = new TableCell();
                    celda.Text = item.Com_estado.ToString();

                    //Agrego la celda a la fila
                    fila.Cells.Add(celda);

                    //Celda que tendra los botones de Detallar e Imprimir
                    celda = new TableCell();
                    Button boton = new Button();
                    boton.ID = "Matricula-" + item.Id.ToString();
                    boton.Command += DetalleFactura_Fact;
                    boton.CssClass = "btn btn-primary glyphicon glyphicon-info-sign";
                    boton.CommandName = item.Id.ToString();                 
                    celda.Controls.Add(boton);

                    //Agrego la celda a la fila
                    fila.Cells.Add(celda);

                    //Escribo en el logger la salida a este metodo
                    Logger.EscribirInfo(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name,
                    M16_Recursointerfaz.MENSAJE_SALIDA_LOGGER, System.Reflection.MethodBase.GetCurrentMethod().Name);

                    //Agrego la fila a la tabla
                    vista.tablaFacturas.Rows.Add(fila);

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

       #region Metodos para el detalle de la Factura

        /// <summary>
        /// Metodo del presentador que pinta el detalle en el modal
        /// </summary>
        /// <param name="evento">La Mensualidad que se ha de mostrar en detalle</param>
        public void DetalleFactura_Fact(object sender, CommandEventArgs e)
        {

        }
        #endregion

    }
}
