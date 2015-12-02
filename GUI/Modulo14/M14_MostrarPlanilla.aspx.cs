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

namespace templateApp.GUI.Modulo14
{
    public partial class M14_MostrarPlanilla : System.Web.UI.Page
    {
        private LogicaNegociosSKD.Modulo14.LogicaDiseño logica = new LogicaNegociosSKD.Modulo14.LogicaDiseño();
        private string contenido;
        private int idSolicitud;
        private int idPlanilla;
        private int idIns;

        protected void Page_Load(object sender, EventArgs e)
        {
            ((SKD)Page.Master).IdModulo = "14";
            try
            {
                if (Request.Cookies["Solicitud"]["id"].ToString() != "")
                {
                    idSolicitud = Convert.ToInt32(Request.Cookies["Solicitud"]["id"]);
                    idIns = Convert.ToInt32(Request.Cookies["Solicitud"]["idIns"]);
                    this.NombrePanilla.Text = Request.Cookies["Solicitud"]["nombre"].ToString();
                    idPlanilla = Convert.ToInt32(Request.Cookies["Solicitud"]["idPlanilla"]);
                    Request.Cookies["Planilla"].Expires = DateTime.Now;
                    MostrarInformacion();
                }
            }
            catch (ExcepcionesSKD.ExceptionSKDConexionBD ex)
            {
                Alerta(ex.Message);
            }
            catch (ExcepcionesSKD.Modulo14.BDDiseñoException ex)
            {
                Alerta(ex.Message);
            }
            catch (ExcepcionesSKD.Modulo14.BDDatosException ex)
            {
                Alerta(ex.Message);
            }
            catch (ExcepcionesSKD.Modulo14.BDPLanillaException ex)
            {
                Alerta(ex.Message);
            }
            catch (ExcepcionesSKD.Modulo14.BDSolicitudException ex)
            {
                Alerta(ex.Message);
            }
            catch (NullReferenceException ex)
            {
                //Alerta(ex.Message);
            }
            catch (Exception ex)
            {
                Alerta(ex.Message);
            }
            MostrarInformacion();
        }

        public void Alerta(string msj)
        {
            alert.Attributes["class"] = "alert alert-danger alert-dismissible";
            alert.Attributes["role"] = "alert";
            alert.InnerHtml = "<div><button type=\"button\" class=\"close\" data-dismiss=\"alert\" aria-label=\"Close\"><span aria-hidden=\"true\">&times;</span></button>" + msj + "</div>";
        }

        public void MostrarInformacion()
        {
             try
             {
            DominioSKD.Diseño diseño = logica.ConsultarDiseño(idPlanilla, Convert.ToInt32(Session[RecursosInterfazMaster.sessionUsuarioID]), idIns, idSolicitud);
            contenido = diseño.Contenido;
            this.informacion.Text = contenido;
            }
             catch (ExcepcionesSKD.ExceptionSKDConexionBD ex)
             {
                 Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                 throw ex;
             }
             catch (ExcepcionesSKD.Modulo14.BDDiseñoException ex)
             {
                 Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                 throw ex;
             }
             catch (ExcepcionesSKD.Modulo14.BDDatosException ex)
             {
                 Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                 throw ex;
             }
             catch (ExcepcionesSKD.Modulo14.BDPLanillaException ex)
             {
                 Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                 throw ex;
             }
             catch (ExcepcionesSKD.Modulo14.BDSolicitudException ex)
             {
                 Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                 throw ex;
             }
             catch (Exception ex)
             {
                 Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                 //throw ex;
             }
        }

        protected void imprimir_Click(object sender, EventArgs e)
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

                Response.AddHeader("content-disposition", "attachment; filename=" + this.NombrePanilla.Text + ".pdf");
                System.Web.HttpContext.Current.Response.Write(pdfDoc);

                Response.Flush();
                Response.End();

            }
            catch (ExcepcionesSKD.ExceptionSKDConexionBD ex)
            {
                Alerta(ex.Message);
            }
            catch (ExcepcionesSKD.Modulo14.BDDiseñoException ex)
            {
                Alerta(ex.Message);
            }
            catch (ExcepcionesSKD.Modulo14.BDDatosException ex)
            {
                Alerta(ex.Message);
            }
            catch (ExcepcionesSKD.Modulo14.BDPLanillaException ex)
            {
                Alerta(ex.Message);
            }
            catch (ExcepcionesSKD.Modulo14.BDSolicitudException ex)
            {
                Alerta(ex.Message);
            }
            catch (NullReferenceException ex)
            {
                Alerta(ex.Message);
            }
            catch (Exception ex)
            {
                Alerta(ex.Message);
                //Response.Write(ex.ToString());
            }
        }

    }
}