using System;
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

                    //Nueva celda que tendra el estado de la compra
                    celda = new TableCell();
                    celda.Text = item.Com_estado.ToString();

                    //Agrego la celda a la fila
                    fila.Cells.Add(celda);

                    //Celda que tendra los botones de Detallar e Imprimir
                    celda = new TableCell();
                    Button boton = new Button();
                    boton.ID = "Matricula-" + item.Com_id.ToString();
                    // El DetalleFactura_Fact llama al metodo encargado de llamar al comando.
                    boton.Command += DetalleFactura_Fact;
                    boton.CssClass = "btn btn-primary glyphicon glyphicon-info-sign";
                    boton.CommandName = item.Com_id.ToString();                 
                    celda.Controls.Add(boton);

                    //Boton que imprime la factura de Modulo15
                    boton = new Button();
                    boton.ID = "Imprimir-" + item.Com_id.ToString();
                   // boton.Click += ImprimirFactura; // Aqui debes llamar a tu metodo para imprimir
                    boton.Command += DetalleFactura_Fact1;
                    boton.CssClass = "btn btn-success glyphicon glyphicon-print";
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

       #region Metodos para el detalle de la Factura

        /// <summary>
        /// Metodo del presentador que pinta el detalle en el modal
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
                Compra compra = new Compra();
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
                vista.LiteralDetallesFacturas.Text = "</br>" + "<h3>Nro. Factura</h3>" + "<label id='aux1' >" + resultados.Com_id + "</label>" +
                                                            "<h3>Fecha de Pago</h3>" + "<label id='aux2' >" + resultados.Com_fecha_compra + "</label>" +
                                                            "<h3>Total</h3>" + "<label id='aux3' >" + resultados.Monto + "</label>";



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
            Comando<Entidad> DetalleFactura = FabricaComandos.CrearComandoDetallarFactura(compra);
            Compra laFactura = (Compra)DetalleFactura.Ejecutar();
            return laFactura;

        }

        public Compra DetalleFactura1(Entidad compra)
        {
            Comando<Entidad> DetalleFactura = FabricaComandos.CrearComandoDetallarFactura(compra);
            Compra laFactura = (Compra)DetalleFactura.Ejecutar();
            return laFactura;

        }

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
                Compra resultados = DetalleFactura1(compra);
                imprimir_Click(resultados);
          }

         public void imprimir_Click(Compra compra)
         {
             Document pdfDoc = new Document(PageSize.A4, 10, 10, 10, 10);

             try
             {
                 PdfWriter.GetInstance(pdfDoc, System.Web.HttpContext.Current.Response.OutputStream);
                 pdfDoc.Open();


                 string cadenaFinal = ConstruirDiseno(compra);
                 string path = server.MapPath("Carnet_titulo.jpg");

                 string encabezado = "<img src='" + path + "' Height='48' Width='570'/><br/><br/>";

                 string strContent = encabezado + cadenaFinal;

                 var parsedHtmlElements = HTMLWorker.ParseToList(new StringReader(strContent), null);

                 foreach (var htmlElement in parsedHtmlElements)
                     pdfDoc.Add(htmlElement as IElement);
                 pdfDoc.Close();

                 Response.ContentType = "application/pdf";

                 Response.AddHeader("content-disposition", "attachment; filename=" + "factura" + ".pdf");
                 System.Web.HttpContext.Current.Response.Write(pdfDoc);

                 Response.Flush();
                 Response.End();

             }
             catch (ExcepcionesSKD.ExceptionSKDConexionBD ex)
             {
                 Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                 HttpContext.Current.Response.Redirect(ex.Mensaje, false);
             }
             catch (ExcepcionesSKD.Modulo14.BDDiseñoException ex)
             {
                 Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                 HttpContext.Current.Response.Redirect(ex.Mensaje, false);
             }
             catch (ExcepcionesSKD.Modulo14.BDDatosException ex)
             {
                 Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                 HttpContext.Current.Response.Redirect(ex.Mensaje, false);
             }
             catch (ExcepcionesSKD.Modulo14.BDPLanillaException ex)
             {
                 Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                 HttpContext.Current.Response.Redirect(ex.Mensaje, false);
             }
             catch (ExcepcionesSKD.Modulo14.BDSolicitudException ex)
             {
                 Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                 HttpContext.Current.Response.Redirect(ex.Mensaje, false);
             }
             catch (NullReferenceException ex)
             {
                 Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                 HttpContext.Current.Response.Redirect(ex.Message, false);
             }
             catch (Exception ex)
             {
                 Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                 HttpContext.Current.Response.Redirect(ex.Message, false);
             }
        
         }

         public string ConstruirDiseno(Compra compra)
         {
             string encabezado = "<table align='left' border='1' cellpadding='1' cellspacing='1' style='width:700px'><tbody><tr><td><strong>Nro de Factura</strong></td><td>";
             string numeroFact = encabezado + compra.Com_id + "</td><td><strong>Fecha de Pago</strong></td><td>";
             string finEncabezado = numeroFact + compra.Com_fecha_compra + "</td></tr></tbody></table><p>&nbsp;</p><p>&nbsp;</p>";
             string formasPago = finEncabezado + "<p><strong>Formas de Pago</strong></p>";
             string pago="";
             foreach (Pago pag in compra.Listapago)
             {
                 pago+= "<p>" + pag.TipoPago + "</p>";
             }
             string finPago = formasPago + pago;
             string encabezadoDetallePro = finPago +"<table align='left' border='1' cellpadding='1' cellspacing='1' style='width:700px'><tbody><tr><td>&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; <strong>&nbsp;Detalles de los productos</strong></td></tr></tbody></table><p>&nbsp;</p>";
             string productos = encabezadoDetallePro + "<table align='left' border='1' cellpadding='1' cellspacing='1' style='width:700px'><tbody><tr><td><strong>Nombre</strong></td><td><strong>Precio unitario</strong></td><td><strong>Cantidad</strong></td><td><strong>Subtotal</strong></td></tr>";
             string detalle = "";
             foreach(DetalleFacturaProducto detaPro in compra.Listainventario)
             {
                 detalle += "<tr><td>"+ detaPro.Producto.Nombre_Implemento;
                 detalle += "</td><td>" + detaPro.Producto.Precio_Implemento;
                 detalle += "</td><td>" + detaPro.Cantidad_producto;
                 detalle += "</td><td>" + detaPro.Subtotal + "</td></tr>";
             }
             string finEncabezadoDetallePro = productos + detalle + "</tbody></table><p>&nbsp;</p><p>&nbsp;</p>";
             string encabezadoDetalleEven = "<table align='left' border='1' cellpadding='1' cellspacing='1' style='width:700px'><tbody><tr><td>&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;<strong>&nbsp;Detalles de los eventos</strong></td></tr></tbody></table><p>&nbsp;</p>";
             string evento = encabezadoDetalleEven + "<table align='left' border='1' cellpadding='1' cellspacing='1' style='width:700px'><tbody><tr><td><strong>Nombre</strong></td><td><strong>Precio Unitario</strong></td><td><strong>Cantidad</strong></td><td><strong>Subtotal</strong></td></tr>";
             string detalleEve = "";
             foreach (DetalleFacturaEvento eve in compra.Listaevento)
             {
                 detalleEve += "<tr><td>" + eve.Evento.Nombre;
                 detalleEve += "<tr><td>" + eve.Evento.Costo;
                 detalleEve += "<tr><td>" + eve.Cantidad_evento;
                 detalleEve += "<tr><td>" + eve.Subtotal + "</td></tr>";
             }

             string finEncabezadoDetalleEve = evento + detalleEve + "</tbody></table><p>&nbsp;</p><p>&nbsp;</p>";
             string encabezadoDetalleMatri = "<table align='left' border='1' cellpadding='1' cellspacing='1' style='width:700px'><tbody><tr><td>&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&nbsp;<strong>Detalles de las matriculas</strong></td></tr></tbody></table><p>&nbsp;</p>";
             string matricula = encabezadoDetalleMatri + "<table align='left' border='1' cellpadding='1' cellspacing='1' style='width:700px'><tbody><tr><td><strong>Nombre</strong></td><td><strong>Precio Unitario</strong></td><td><strong>Cantidad</strong></td><td><strong>Subtotal</strong></td></tr>";
             string detalleMatri = "";
             foreach (DetalleFacturaMatricula matri in compra.Listamatricula)
             {
                 detalleMatri += "<tr><td>" + matri.Matricula.Identificador;
                 detalleMatri += "<tr><td>" + matri.Matricula.Costo;
                 detalleMatri += "<tr><td>" + matri.Cantidad_matricula;
                 detalleMatri += "<tr><td>" + matri.Subtotal+ "</td></tr>";
             }
             string finEncabezadoDetalleMatri = matricula + detalleMatri + "</tbody></table><p>&nbsp;</p><p>&nbsp;</p>";
             string total = finEncabezadoDetalleMatri +"<p><strong>Total:</strong>" + compra.Monto + "</p>";
             return total;
         }

       #endregion


    }
}
