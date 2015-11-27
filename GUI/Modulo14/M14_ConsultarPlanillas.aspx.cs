using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.Odbc;
using System.Data.SqlClient;


namespace templateApp.GUI.Modulo14
{
    public partial class M14ConsultarPlanillas : System.Web.UI.Page
    {
        private LogicaNegociosSKD.Modulo14.LogicaPlanilla logica = new LogicaNegociosSKD.Modulo14.LogicaPlanilla();
        List<DominioSKD.Planilla> lista;

        protected void Page_Load(object sender, EventArgs e)
        {
            ((SKD)Page.Master).IdModulo = "14";
            if (!IsPostBack)
            {
                List<DominioSKD.Planilla> listaPlanilla = LlenarTabla();
                LlenarInformacion(listaPlanilla);
            }
            string exito = Request.QueryString["idPlan"];
            if (exito != null)
                LlamarVentana_Click();
            

        }

        public void LlenarInformacion(List<DominioSKD.Planilla> lista)
        {
            this.lista = lista;
            foreach (DominioSKD.Planilla plani in lista)
            {
                this.tabla.Text += RecursoInterfazModulo14.AbrirTR;
                this.tabla.Text += RecursoInterfazModulo14.AbrirTD + plani.ID.ToString() + RecursoInterfazModulo14.CerrarTD;
                this.tabla.Text += RecursoInterfazModulo14.AbrirTD + plani.Nombre.ToString() + RecursoInterfazModulo14.CerrarTD;
                this.tabla.Text += RecursoInterfazModulo14.AbrirTD + plani.TipoPlanilla.ToString() + RecursoInterfazModulo14.CerrarTD;
                this.tabla.Text += RecursoInterfazModulo14.AbrirTD + plani.Status.ToString() + RecursoInterfazModulo14.CerrarTD;
                this.tabla.Text += RecursoInterfazModulo14.AbrirTD;
                this.tabla.Text += RecursoInterfazModulo14.BotonInfo + plani.ID + RecursoInterfazModulo14.BotonCerrar;
                this.tabla.Text += RecursoInterfazModulo14.BotonModificar + plani.ID +RecursoInterfazModulo14.Nombre+ plani.Nombre +RecursoInterfazModulo14.Tipo+ plani.TipoPlanilla+ RecursoInterfazModulo14.BotonCerrar1;
                this.tabla.Text += RecursoInterfazModulo14.BotonModificarRegistro + plani.ID + RecursoInterfazModulo14.Nombre + plani.Nombre + RecursoInterfazModulo14.Tipo + plani.TipoPlanilla + RecursoInterfazModulo14.BotonCerrar1;
                this.tabla.Text += RecursoInterfazModulo14.CerrarTD;
                this.tabla.Text += RecursoInterfazModulo14.CerrarTR;
            }
        }
        public List<DominioSKD.Planilla> LlenarTabla()
        {
            return logica.ConsultarPlanillas();
        }

        public void LlamarVentana_Click()
        {

            HttpCookie aCookie = new HttpCookie("Planilla");
            aCookie.Values["id"] = Request.QueryString["idPlan"];
            aCookie.Values["nombre"] = Request.QueryString["nombre"];
            aCookie.Values["tipo"] = Request.QueryString["tipo"];
            aCookie.Values["diseno"] = "1";
            aCookie.Expires = DateTime.Now.AddMinutes(15);
            Response.Cookies.Add(aCookie);
            HttpContext.Current.Response.Redirect("M14_DisenoPlanilla.aspx");
        }

    }
}