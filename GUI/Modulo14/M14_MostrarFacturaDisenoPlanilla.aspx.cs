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
namespace templateApp.GUI.Modulo14
{
    public partial class M14_MostrarFacturaDisenoPlanilla : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
             Imprimir(Request.QueryString[RecursoInterfazModulo14.QueryIdPlan]);
            //Imprimir(RecursoInterfazModulo14.ProbarDiseno);
            Response.Redirect("~/GUI/Modulo16/M16_ListarFacturas.aspx");

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
            catch (ExcepcionesSKD.ExceptionSKDConexionBD ex)
            {
                
            }
            catch (ExcepcionesSKD.Modulo14.BDDiseñoException ex)
            {
                
            }
            catch (ExcepcionesSKD.Modulo14.BDDatosException ex)
            {
                
            }
            catch (ExcepcionesSKD.Modulo14.BDPLanillaException ex)
            {
                
            }
            catch (ExcepcionesSKD.Modulo14.BDSolicitudException ex)
            {
                
            }
            catch (NullReferenceException ex)
            {
                
            }
            catch (Exception ex)
            {
                
            }
        
        }
    }
}