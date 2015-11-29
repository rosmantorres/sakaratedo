using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using LogicaNegociosSKD.Modulo14;
using DominioSKD;

namespace templateApp.GUI.Modulo14
{
    public partial class M14_ConsultarPlanillasSolicitadas : System.Web.UI.Page
    {
        private LogicaSolicitud logica = new LogicaSolicitud();
        List<DominioSKD.SolicitudPlanilla> lista;

        protected void Page_Load(object sender, EventArgs e)
        {
            ((SKD)Page.Master).IdModulo = "14";
            if (!IsPostBack)
            {
                List<DominioSKD.SolicitudPlanilla> listaSolicitud = LlenarTabla();
                LlenarInformacion(listaSolicitud);
            }
            string exito = Request.QueryString["idSolici"];
            if (exito != null)
                LlamarVentana_Click();
        }

        public void LlenarInformacion(List<DominioSKD.SolicitudPlanilla> lista)
        {
            this.lista = lista;
            foreach (DominioSKD.SolicitudPlanilla solici in lista)
            {
                
                this.tabla.Text += RecursoInterfazModulo14.AbrirTR;
                this.tabla.Text += RecursoInterfazModulo14.AbrirTD + solici.ID + RecursoInterfazModulo14.CerrarTD;
                this.tabla.Text += RecursoInterfazModulo14.AbrirTD + solici.Planilla.Nombre + RecursoInterfazModulo14.CerrarTD;
                this.tabla.Text += RecursoInterfazModulo14.AbrirTD + solici.Planilla.TipoPlanilla + RecursoInterfazModulo14.CerrarTD;
                this.tabla.Text += RecursoInterfazModulo14.AbrirTD + solici.FechaRetiro.ToShortDateString() + "--"+solici.FechaReincorporacion.ToShortDateString() + RecursoInterfazModulo14.CerrarTD;
                this.tabla.Text += RecursoInterfazModulo14.AbrirTD + solici.FechaCreacion.ToShortDateString() + RecursoInterfazModulo14.CerrarTD;
                this.tabla.Text += RecursoInterfazModulo14.AbrirTD + solici.Evento + RecursoInterfazModulo14.CerrarTD;
                this.tabla.Text += RecursoInterfazModulo14.AbrirTD;
                this.tabla.Text += RecursoInterfazModulo14.BotonInfoSolicitud + solici.ID + RecursoInterfazModulo14.Nombre + solici.Planilla.Nombre + RecursoInterfazModulo14.IdPlanilla + solici.Planilla.ID + RecursoInterfazModulo14.BotonCerrar;
                this.tabla.Text += RecursoInterfazModulo14.BotonModificarSolicitud + solici.ID  + RecursoInterfazModulo14.BotonCerrar;
                this.tabla.Text += RecursoInterfazModulo14.BotonEliminarSolicitud + solici.ID + RecursoInterfazModulo14.BotonCerrar;
                this.tabla.Text += RecursoInterfazModulo14.CerrarTD;
                this.tabla.Text += RecursoInterfazModulo14.CerrarTR;
            }
        }
        public List<DominioSKD.SolicitudPlanilla> LlenarTabla()
        {
            return logica.ListarPlanillasSolicitadas(6);
        }

        public void LlamarVentana_Click()
        {

            HttpCookie aCookie = new HttpCookie("Solicitud");
            aCookie.Values["id"] = Request.QueryString["idSolici"];
            aCookie.Values["nombre"] = Request.QueryString["nombre"];
            aCookie.Values["idPlanilla"] = Request.QueryString["idPlanilla"];
            aCookie.Expires = DateTime.Now.AddMinutes(15);
            Response.Cookies.Add(aCookie);
            HttpContext.Current.Response.Redirect("M14_MostrarPlanilla.aspx");
        }
    }
}