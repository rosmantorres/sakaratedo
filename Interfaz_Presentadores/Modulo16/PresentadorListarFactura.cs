﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
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
using iTextSharp.text;
using iTextSharp.text.html.simpleparser;
using iTextSharp.text.pdf;

namespace Interfaz_Presentadores.Modulo16
{
    public class PresentadorListarFactura
    {
       #region Atributos
        private IContratoListarFactura vista;
        private HttpServerUtility server;
        private HttpResponse Response;
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
        public void consultarFacturas(int persona, HttpServerUtility server, HttpResponse response)
        {
            try
            {
                //Escribo en el logger la entrada a este metodo
                Logger.EscribirInfo(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name,
                    M16_Recursointerfaz.MENSAJE_ENTRADA_LOGGER,
                    System.Reflection.MethodBase.GetCurrentMethod().Name);
                this.server = server;
                this.Response = response;
                //Instancio el comando para listar el evento
                Comando<Entidad> comandoListarFacturas = FabricaComandos.CrearComandoConsultarTodasFacturas();

                //Casteamos el parametro
                PersonaM1 param = (PersonaM1)FabricaEntidades.ObtenerPersonaModulo16();
                param._Id = persona;
                comandoListarFacturas.LaEntidad = param;

                // Invocamos el Comando
                ListaCompra com = (ListaCompra)comandoListarFacturas.Ejecutar();

                // Si la lista retorna vacia, retorna un mensaje al usuario
                if (com.ListaCompras.Count == 0)
                {
                    HttpContext.Current.Response.Redirect(M16_Recursointerfaz.EXCEPCION_LISTA_VACIA_FACTURA, false);
                }

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

                    //Nueva celda que tendra el estado de la compra
                    celda = new TableCell();
                    celda.Text = item.Com_estado.ToString();

                    //Agrego la celda a la fila
                    fila.Cells.Add(celda);

                    //Celda que tendra los botones de Detallar e Imprimir
                    celda = new TableCell();
                    Button boton = new Button();
                    boton.ID = M16_Recursointerfaz.REFERENCIA_MATRICULA + item.Com_id.ToString();
                    // El DetalleFactura_Fact llama al metodo encargado de llamar al comando.
                    boton.Command += DetalleFactura_Fact;
                    boton.CssClass = M16_Recursointerfaz.BOTON_INFORMACION;
                    boton.CommandName = item.Com_id.ToString();                 
                    celda.Controls.Add(boton);

                    //Boton que imprime la factura de Modulo15 en .PDF
                    boton = new Button();
                    boton.ID = M16_Recursointerfaz.REFERENCIA_IMPRIMIR + item.Com_id.ToString();
                    boton.Command += DetalleFactura_Fact1;
                    boton.CssClass = M16_Recursointerfaz.BOTON_IMPRIMIR;
                    boton.CommandName = item.Com_id.ToString();  
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
            catch (PersonaNoValidaException ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                HttpContext.Current.Response.Redirect(M16_Recursointerfaz.EXCEPTION_PERSONA_INVALIDA_LINK_FACTURA, false);
            }
            catch (LoggerException ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                HttpContext.Current.Response.Redirect(M16_Recursointerfaz.EXCEPTION_LOGGER_LINK_FACTURA, false);

            }
            catch (ArgumentNullException ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                HttpContext.Current.Response.Redirect(M16_Recursointerfaz.EXCEPTION_PARSEO_VACIO_LINK_FACTURA, false);
            }
            catch (FormatException ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                HttpContext.Current.Response.Redirect(M16_Recursointerfaz.EXCEPTION_FORMATO_LINK_FACTURA, false);

            }
            catch (OverflowException ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                HttpContext.Current.Response.Redirect(M16_Recursointerfaz.EXCEPTION_SOBRECARGA_LINK_FACTURA, false);

            }
            catch (ParametroInvalidoException ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                HttpContext.Current.Response.Redirect(M16_Recursointerfaz.EXCEPTION_PARAMETRO_INVALIDO_LINK_FACTURA, false);
            }
            catch (ExceptionSKDConexionBD ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                HttpContext.Current.Response.Redirect(M16_Recursointerfaz.EXCEPTION_CONEXIONBD_LINK_FACTURA, false);

            }
            catch (ExceptionSKD ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                HttpContext.Current.Response.Redirect(M16_Recursointerfaz.EXCEPTIONSKD_LINK_FACTURA, false);

            }
            catch (Exception ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                HttpContext.Current.Response.Redirect(M16_Recursointerfaz.EXCEPTION_LINK_FACTURA, false);
            }

            #endregion
        }
        #endregion

       #region Metodos para el detalle de la Factura en el Modal (Modulo16)

        /// <summary>
        /// Metodo del presentador que pinta el detalle en el modal de la Factura
        /// </summary>
        /// <param name="evento">La Mensualidad que se ha de mostrar en detalle</param>
        public void DetalleFactura_Fact(object sender, CommandEventArgs e)
        {
            try
            {
                //Escribo en el logger la entrada a este metodo
                Logger.EscribirInfo(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name,
                    M16_Recursointerfaz.MENSAJE_ENTRADA_LOGGER,
                    System.Reflection.MethodBase.GetCurrentMethod().Name);

                string id = e.CommandName;
                DominioSKD.Entidades.Modulo16.Compra compra = (DominioSKD.Entidades.Modulo16.Compra)FabricaEntidades.ObtenerFactura();
                compra.Com_id = int.Parse(id);

                //Casteamos
                Compra resultados = DetalleFactura(compra);
         

                // Imprime los tipos de pago
                foreach (Pago aux in resultados.Listapago)
                {
                    TableRow fila = new TableRow();

                    //Nueva celda que tendra el id de la factura 
                    TableCell celda = new TableCell();
                    celda.Text = aux.TipoPago.ToString();

                    //Agrego la Celda a la fila
                    fila.Cells.Add(celda);

                    vista.tablaDetalleDatos.Rows.Add(fila);
                }
                
                // Imprime el Detalle del Implemento de la Factura
                foreach(DetalleFacturaProducto aux in resultados.Listainventario)
                {
                    TableRow fila = new TableRow();

                    //Nueva celda que tendra el id de la factura 
                    TableCell celda = new TableCell();
                    celda.Text = aux.Producto.Nombre_Implemento;

                    //Agrego la Celda a la fila
                    fila.Cells.Add(celda);

                    celda = new TableCell();
                    celda.Text = aux.Producto.Precio_Implemento.ToString();

                    //Agrego la Celda a la fila
                    fila.Cells.Add(celda);


                    celda = new TableCell();
                    celda.Text = aux.Cantidad_producto.ToString();

                    //Agrego la Celda a la fila
                    fila.Cells.Add(celda);

                    celda = new TableCell();
                    celda.Text = aux.Subtotal.ToString();

                    //Agrego la Celda a la fila
                    fila.Cells.Add(celda);

                    vista.tablaDetalleProductos.Rows.Add(fila);
                }

                // Imprime el Detalle del Evento de la Factura
                foreach (DetalleFacturaEvento aux in resultados.Listaevento)
                {
                    TableRow fila = new TableRow();

                    //Nueva celda que tendra el id de la factura 
                    TableCell celda = new TableCell();
                    celda.Text = aux.Evento.Nombre.ToString();

                    //Agrego la Celda a la fila
                    fila.Cells.Add(celda);

                    celda = new TableCell();
                    celda.Text = aux.Evento.Costo.ToString();

                    //Agrego la Celda a la fila
                    fila.Cells.Add(celda);


                    celda = new TableCell();
                    celda.Text = aux.Cantidad_evento.ToString();

                    //Agrego la Celda a la fila
                    fila.Cells.Add(celda);

                    celda = new TableCell();
                    celda.Text = aux.Subtotal.ToString();

                    //Agrego la Celda a la fila
                    fila.Cells.Add(celda);

                    vista.tablaDetalleEventos.Rows.Add(fila);
                }


                // Imprime el Detalle de la Matricula de la Factura
                foreach (DetalleFacturaMatricula aux in resultados.Listamatricula)
                {
                    TableRow fila = new TableRow();

                    //Nueva celda que tendra el id de la factura 
                    TableCell celda = new TableCell();
                    celda.Text = aux.Matricula.Identificador.ToString();

                    //Agrego la Celda a la fila
                    fila.Cells.Add(celda);

                    celda = new TableCell();
                    celda.Text = aux.Matricula.Costo.ToString();

                    //Agrego la Celda a la fila
                    fila.Cells.Add(celda);


                    celda = new TableCell();
                    celda.Text = aux.Cantidad_matricula.ToString();

                    //Agrego la Celda a la fila
                    fila.Cells.Add(celda);

                    celda = new TableCell();
                    celda.Text = aux.Subtotal.ToString();

                    //Agrego la Celda a la fila
                    fila.Cells.Add(celda);

                    vista.tablaDetalleMatriculas.Rows.Add(fila);
                }

                // Variables para imprimir en el modal
                vista.LiteralDetallesFacturas.Text = M16_Recursointerfaz.SALTO_LINEA + M16_Recursointerfaz.TITULO_NUM_FACTURA + M16_Recursointerfaz.ABRE_LABEL_AUX1 + resultados.Com_id + M16_Recursointerfaz.CIERRE_LABEL +
                                                     M16_Recursointerfaz.TITULO_FECHA_PAGO_FACTURA + M16_Recursointerfaz.ABRE_LABEL_AUX2 + resultados.Com_fecha_compra + M16_Recursointerfaz.CIERRE_LABEL +
                                                     M16_Recursointerfaz.TITULO_TOTAL + M16_Recursointerfaz.ABRE_LABEL_AUX3 + resultados.Monto + M16_Recursointerfaz.CIERRE_LABEL;



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
                HttpContext.Current.Response.Redirect(M16_Recursointerfaz.EXCEPTION_PERSONA_INVALIDA_LINK_FACTURA, false);
            }
            catch (LoggerException ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                HttpContext.Current.Response.Redirect(M16_Recursointerfaz.EXCEPTION_LOGGER_LINK_FACTURA, false);

            }
            catch (ArgumentNullException ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                HttpContext.Current.Response.Redirect(M16_Recursointerfaz.EXCEPTION_PARSEO_VACIO_LINK_FACTURA, false);
            }
            catch (FormatException ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                HttpContext.Current.Response.Redirect(M16_Recursointerfaz.EXCEPTION_FORMATO_LINK_FACTURA, false);

            }
            catch (OverflowException ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                HttpContext.Current.Response.Redirect(M16_Recursointerfaz.EXCEPTION_SOBRECARGA_LINK_FACTURA, false);

            }
            catch (ParametroInvalidoException ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                HttpContext.Current.Response.Redirect(M16_Recursointerfaz.EXCEPTION_PARAMETRO_INVALIDO_LINK_FACTURA, false);
            }
            catch (ExceptionSKDConexionBD ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                HttpContext.Current.Response.Redirect(M16_Recursointerfaz.EXCEPTION_CONEXIONBD_LINK_FACTURA, false);

            }
            catch (ExceptionSKD ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                HttpContext.Current.Response.Redirect(M16_Recursointerfaz.EXCEPTIONSKD_LINK_FACTURA, false);

            }
            catch (Exception ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                HttpContext.Current.Response.Redirect(M16_Recursointerfaz.EXCEPTION_LINK_FACTURA, false);
            }


            #endregion
        }

        /// <summary>
        /// Metodo del presentador que detalla el evento dado un id especifico
        /// </summary>
        /// <param name="evento">El evento que se ha mostrar en detalle</param>
        public Compra DetalleFactura(Entidad compra)
        {
            try
            {
                //Escribo en el logger la entrada a este metodo
                Logger.EscribirInfo(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name,
                    M16_Recursointerfaz.MENSAJE_ENTRADA_LOGGER,
                    System.Reflection.MethodBase.GetCurrentMethod().Name);

                //Casteamos
                Comando<Entidad> DetalleFactura = FabricaComandos.CrearComandoDetallarFactura(compra);
                Compra laFactura = (Compra)DetalleFactura.Ejecutar();

                //Escribo en el logger la salida a este metodo
                Logger.EscribirInfo(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name,
                    M16_Recursointerfaz.MENSAJE_SALIDA_LOGGER, System.Reflection.MethodBase.GetCurrentMethod().Name);

                // Retornamos la Factura
                return laFactura;
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

       #region Metodos para Imprimir la Factura (Modulo14)

        public void DetalleFactura_Fact1(object sender, CommandEventArgs e)
        {

            //Escribo en el logger la entrada a este metodo
            Logger.EscribirInfo(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name,
                M16_Recursointerfaz.MENSAJE_ENTRADA_LOGGER,
                System.Reflection.MethodBase.GetCurrentMethod().Name);

            string id = e.CommandName;
            Compra compra = new Compra();
            compra.Com_id = int.Parse(id);

            //Casteamos
            HttpContext.Current.Response.Redirect("~/GUI/Modulo14/M14_MostrarFacturaDisenoPlanilla.aspx?idComp=" + compra.Com_id.ToString());
        }

        #endregion

    }
}
