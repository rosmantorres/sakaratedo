﻿using System;
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
    public partial class M14_MostrarPlanilla : System.Web.UI.Page, IContratoM14MostrarPlanilla
    {
        private int idSolicitud;
        private int idPlanilla;
        private int idIns;
        private string contenido;
        private PresentadorM14MostrarDiseno presentador;

        #region Contratos
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

        public Label NombrePanilla 
        {
            set
            {
                this.NombrePanilla1 = value;
            }
        }
        public Label informacion
        {
            get
            {
                return this.informacion1;
            }
            set
            {
                this.informacion1 = value;
            }
        }

        #endregion

        public M14_MostrarPlanilla()
        {
            presentador = new PresentadorM14MostrarDiseno(this);
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            ((SKD)Page.Master).IdModulo = "14.1";
            try
            {
                if (Request.Cookies["Solicitud"]["id"].ToString() != "")
                {
                    idSolicitud = Convert.ToInt32(Request.Cookies["Solicitud"]["id"]);
                    idIns = Convert.ToInt32(Request.Cookies["Solicitud"]["idIns"]);
                    this.NombrePanilla1.Text = Request.Cookies["Solicitud"]["nombre"].ToString();
                    idPlanilla = Convert.ToInt32(Request.Cookies["Solicitud"]["idPlanilla"]);
                    Request.Cookies["Planilla"].Expires = DateTime.Now;
                    Entidad diseño=presentador.MostrarInformacion(idIns,
                        Convert.ToInt32(Session[RecursosInterfazMaster.sessionUsuarioID]),
                        idSolicitud,idPlanilla);
                    contenido = ((DominioSKD.Entidades.Modulo14.Diseño)diseño).Contenido;
                    this.informacion.Text = contenido;
                }
            }
            catch (ExcepcionesSKD.ExceptionSKDConexionBD ex)
            {
                presentador.Alerta(ex.Message);
            }
            catch (ExcepcionesSKD.Modulo14.BDDiseñoException ex)
            {
                presentador.Alerta(ex.Message);
            }
            catch (ExcepcionesSKD.Modulo14.BDDatosException ex)
            {
                presentador.Alerta(ex.Message);
            }
            catch (ExcepcionesSKD.Modulo14.BDPLanillaException ex)
            {
                presentador.Alerta(ex.Message);
            }
            catch (ExcepcionesSKD.Modulo14.BDSolicitudException ex)
            {
                presentador.Alerta(ex.Message);
            }
            catch (NullReferenceException ex)
            {
                //Alerta(ex.Message);
            }
            catch (Exception ex)
            {
                presentador.Alerta(ex.Message);
            }
            Entidad diseño1=presentador.MostrarInformacion(idIns,
                        Convert.ToInt32(Session[RecursosInterfazMaster.sessionUsuarioID]),
                        idSolicitud, idPlanilla);
            contenido = ((DominioSKD.Entidades.Modulo14.Diseño)diseño1).Contenido;
            this.informacion.Text = contenido;
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

                Response.AddHeader("content-disposition", "attachment; filename=" + this.NombrePanilla1.Text + ".pdf");
                System.Web.HttpContext.Current.Response.Write(pdfDoc);

                Response.Flush();
                Response.End();

            }
            catch (ExcepcionesSKD.ExceptionSKDConexionBD ex)
            {
                presentador.Alerta(ex.Message);
            }
            catch (ExcepcionesSKD.Modulo14.BDDiseñoException ex)
            {
                presentador.Alerta(ex.Message);
            }
            catch (ExcepcionesSKD.Modulo14.BDDatosException ex)
            {
                presentador.Alerta(ex.Message);
            }
            catch (ExcepcionesSKD.Modulo14.BDPLanillaException ex)
            {
                presentador.Alerta(ex.Message);
            }
            catch (ExcepcionesSKD.Modulo14.BDSolicitudException ex)
            {
                presentador.Alerta(ex.Message);
            }
            catch (NullReferenceException ex)
            {
                presentador.Alerta(ex.Message);
            }
            catch (Exception ex)
            {
                presentador.Alerta(ex.Message);
                //Response.Write(ex.ToString());
            }
        }

    }
}