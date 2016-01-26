using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using iTextSharp.text;
using iTextSharp.text.html.simpleparser;
using iTextSharp.text.pdf;
using templateApp.GUI.Master;
using ExcepcionesSKD;
using Interfaz_Contratos.Modulo14;
using Interfaz_Presentadores.Modulo14;
using DominioSKD;
using DominioSKD.Entidades.Modulo16;
namespace templateApp.GUI.Modulo14
{
    public partial class M14_MostrarFacturaDisenoPlanilla : System.Web.UI.Page, IContartoM14MostrarFacturaPlanilla
    {
        private PresentadorM14MostrarFacturaPlanilla presentador;
        private string texto;

        public string Texto
        {
            set
            {
                this.texto = value;
            }
            get
            {
                return this.texto;
            }
        }

        public string alertaClase
        {
            set
            {
                this.alerta.Attributes["class"] = value;
            }
        }
        public string alertaRol
        {
            set
            {
                this.alerta.Attributes["role"] = value;
            }
        }
        public string alert
        {
            set
            {
                this.alerta.InnerHtml = value;
            }
        }

        public M14_MostrarFacturaDisenoPlanilla()
        {
            presentador = new PresentadorM14MostrarFacturaPlanilla(this);
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                int idCompra = Convert.ToInt32(Request.QueryString["idComp"]);
                Compra compra = new Compra();
                compra.Com_id = idCompra;
                Compra resultado = presentador.DetalleFactura1(compra);
                string completo = ConstruirDiseno(resultado);
                Imprimir(completo);
                //Imprimir(Request.QueryString[RecursoInterfazModulo14.QueryIdPlan]);
                //Imprimir(RecursoInterfazModulo14.ProbarDiseno);
                Response.Redirect("~/GUI/Modulo16/M16_ListarFacturas.aspx");
            }
            catch (LoggerException ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                Alerta(ex.Message);

            }
            catch (ArgumentNullException ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                Alerta(ex.Message);
            }
            catch (FormatException ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                Alerta(ex.Message);

            }
            catch (OverflowException ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                Alerta(ex.Message);

            }
            catch (ParametroInvalidoException ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                Alerta(ex.Message);
            }
            catch (ExceptionSKDConexionBD ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                Alerta(ex.Message);

            }
            catch (ExceptionSKD ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                Alerta(ex.Message);

            }
            catch (Exception ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                Alerta(ex.Message);
            }

        }

        public void Imprimir(string contenido)
        {
            Document pdfDoc = new Document(PageSize.A4, 10, 10, 10, 10);

            try
            {
                PdfWriter.GetInstance(pdfDoc, System.Web.HttpContext.Current.Response.OutputStream);
                pdfDoc.Open();


                string cadenaFinal = contenido;
                string path = Server.MapPath("img/Carnet_titulo.jpg");

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
            catch (Exception ex)
            {
                Alerta(ex.Message);
            }
        
        }

        public void Alerta(string msj)
        {
            presentador.Alerta(msj);
        }

        public string ConstruirDiseno(Compra compra)
        {
            
            string encabezado = "<table align='left' border='1' cellpadding='1' cellspacing='1' style='width:700px'><tbody><tr><td><strong>Nro de Factura</strong></td><td>";
            string numeroFact = encabezado + compra.Com_id + "</td><td><strong>Fecha de Pago</strong></td><td>";
            string finEncabezado = numeroFact + compra.Com_fecha_compra + "</td></tr></tbody></table><p>&nbsp;</p><p>&nbsp;</p>";
            string formasPago = finEncabezado + "<p><strong>Formas de Pago</strong></p>";
            string pago = "";
            foreach (Pago pag in compra.Listapago)
            {
                pago += "<p>" + pag.TipoPago + "</p>";
            }
            string finPago = formasPago + pago;
            string encabezadoDetallePro = finPago + "<table align='left' border='1' cellpadding='1' cellspacing='1' style='width:700px'><tbody><tr><td>&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; <strong>&nbsp;Detalles de los productos</strong></td></tr></tbody></table><p>&nbsp;</p>";
            string productos = encabezadoDetallePro + "<table align='left' border='1' cellpadding='1' cellspacing='1' style='width:700px'><tbody><tr><td><strong>Nombre</strong></td><td><strong>Precio unitario</strong></td><td><strong>Cantidad</strong></td><td><strong>Subtotal</strong></td></tr>";
            string detalle = "";
            foreach (DetalleFacturaProducto detaPro in compra.Listainventario)
            {
                detalle += "<tr><td>" + detaPro.Producto.Nombre_Implemento;
                detalle += "</td><td>" + detaPro.Producto.Precio_Implemento;
                detalle += "</td><td>" + detaPro.Cantidad_producto;
                detalle += "</td><td>" + detaPro.Subtotal + "</td></tr>";
            }
            string finEncabezadoDetallePro = productos + detalle + "</tbody></table><p>&nbsp;</p><p>&nbsp;</p>";
            string encabezadoDetalleEven = finEncabezadoDetallePro + "<table align='left' border='1' cellpadding='1' cellspacing='1' style='width:700px'><tbody><tr><td>&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;<strong>&nbsp;Detalles de los eventos</strong></td></tr></tbody></table><p>&nbsp;</p>";
            string evento = encabezadoDetalleEven + "<table align='left' border='1' cellpadding='1' cellspacing='1' style='width:700px'><tbody><tr><td><strong>Nombre</strong></td><td><strong>Precio Unitario</strong></td><td><strong>Cantidad</strong></td><td><strong>Subtotal</strong></td></tr>";
            string detalleEve = "";
            foreach (DetalleFacturaEvento eve in compra.Listaevento)
            {
                detalleEve += "<tr><td>" + eve.Evento.Nombre;
                detalleEve += "</td><td>" + eve.Evento.Costo;
                detalleEve += "</td><td>" + eve.Cantidad_evento;
                detalleEve += "</td><td>" + eve.Subtotal + "</td></tr>";
            }

            string finEncabezadoDetalleEve = evento + detalleEve + "</tbody></table><p>&nbsp;</p><p>&nbsp;</p>";
            string encabezadoDetalleMatri = finEncabezadoDetalleEve + "<table align='left' border='1' cellpadding='1' cellspacing='1' style='width:700px'><tbody><tr><td>&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&nbsp;<strong>Detalles de las matriculas</strong></td></tr></tbody></table><p>&nbsp;</p>";
            string matricula = encabezadoDetalleMatri + "<table align='left' border='1' cellpadding='1' cellspacing='1' style='width:700px'><tbody><tr><td><strong>Nombre</strong></td><td><strong>Precio Unitario</strong></td><td><strong>Cantidad</strong></td><td><strong>Subtotal</strong></td></tr>";
            string detalleMatri = "";
            foreach (DetalleFacturaMatricula matri in compra.Listamatricula)
            {
                detalleMatri += "<tr><td>" + matri.Matricula.Identificador;
                detalleMatri += "</td><td>" + matri.Matricula.Costo;
                detalleMatri += "</td><td>" + matri.Cantidad_matricula;
                detalleMatri += "</td><td>" + matri.Subtotal + "</td></tr>";
            }
            string finEncabezadoDetalleMatri = matricula + detalleMatri + "</tbody></table><p>&nbsp;</p><p>&nbsp;</p>";
            string total = finEncabezadoDetalleMatri + "<p><strong>Total:</strong>" + compra.Monto + "</p>";
            return total;
        }
    }
}