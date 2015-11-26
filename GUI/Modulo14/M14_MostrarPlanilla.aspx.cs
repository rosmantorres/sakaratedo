using System;
using System.Collections.Generic;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using iTextSharp.text;
using iTextSharp.text.html.simpleparser;
using iTextSharp.text.pdf;

namespace templateApp.GUI.Modulo14
{
    public partial class M14_MostrarPlanilla : System.Web.UI.Page
    {
        private DominioSKD.Planilla planilla1;
        private LogicaNegociosSKD.Modulo14.LogicaDiseño logica = new LogicaNegociosSKD.Modulo14.LogicaDiseño();
        private string contenido;
        protected void Page_Load(object sender, EventArgs e)
        {
            ((SKD)Page.Master).IdModulo = "14";
            MostrarInformacion();
        }

        public void MostrarInformacion()
        {
            planilla1 = new DominioSKD.Planilla(1,"Retiro", true, "Vacaciones");
            DominioSKD.Diseño diseño = logica.ConsultarDiseño(planilla1.ID);
            contenido = diseño.Contenido;
            this.informacion.Text = contenido;
        }

        protected void imprimir_Click(object sender, EventArgs e)
        {
            Document pdfDoc = new Document(PageSize.A4, 10, 10, 10, 10);

            try
            {
                PdfWriter.GetInstance(pdfDoc, System.Web.HttpContext.Current.Response.OutputStream);

                //Open PDF Document to write data 
                pdfDoc.Open();


                string cadenaFinal = contenido;
                string path = Server.MapPath("img/Carnet_titulo.jpg");
                if (contenido.Contains("<img src='img/perfil.jpg' Height='80' Width='90'/>"))
                {
                    string path1 = Server.MapPath("img/perfil.jpg");
                    contenido.Replace("<img src='img/perfil.jpg' Height='80' Width='90'/>", "<img src='" + path1 + "' Height='80' Width='90'/>");
                }
                string encabezado = "<img src='" + path + "' Height='48' Width='570'/><br/><br/>";
                //Assign Html content in a string to write in PDF 
                string strContent =encabezado + cadenaFinal;

                //Read string contents using stream reader and convert html to parsed conent 
                var parsedHtmlElements = HTMLWorker.ParseToList(new StringReader(strContent), null);

                //Get each array values from parsed elements and add to the PDF document 
                foreach (var htmlElement in parsedHtmlElements)
                    pdfDoc.Add(htmlElement as IElement);

                //Close your PDF 
                pdfDoc.Close();

                Response.ContentType = "application/pdf";

                //Set default file Name as current datetime 
                Response.AddHeader("content-disposition", "attachment; filename=Planilla.pdf");
                System.Web.HttpContext.Current.Response.Write(pdfDoc);

                Response.Flush();
                Response.End();

            }
            catch (Exception ex)
            {
                Response.Write(ex.ToString());
            }
        }

    }
}