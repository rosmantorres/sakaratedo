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
        protected void Page_Load(object sender, EventArgs e)
        {
            ((SKD)Page.Master).IdModulo = "14";
            if (!IsPostBack)
            {
                List<DominioSKD.Planilla> listaPlanilla = LlenarTabla();
                LlenarInformacion(listaPlanilla);
            }

        }

        public void LlenarInformacion(List<DominioSKD.Planilla> lista)
        {
            foreach (DominioSKD.Planilla plani in lista)
            {
                this.tabla.Text += RecursoInterfazModulo14.AbrirTR;
                this.tabla.Text += RecursoInterfazModulo14.AbrirTD + plani.Nombre.ToString() + RecursoInterfazModulo14.CerrarTD;
                this.tabla.Text += RecursoInterfazModulo14.AbrirTD + plani.TipoPlanilla.ToString() + RecursoInterfazModulo14.CerrarTD;
                this.tabla.Text += RecursoInterfazModulo14.AbrirTD + plani.Status.ToString() + RecursoInterfazModulo14.CerrarTD;
                this.tabla.Text += RecursoInterfazModulo14.AbrirTD;
                this.tabla.Text += RecursoInterfazModulo14.BotonInfo + plani.ID + RecursoInterfazModulo14.BotonCerrar;
                this.tabla.Text += RecursoInterfazModulo14.BotonModificar + plani.ID + RecursoInterfazModulo14.BotonCerrar;
                this.tabla.Text += RecursoInterfazModulo14.CerrarTD;
                this.tabla.Text += RecursoInterfazModulo14.CerrarTR;
            }
        }
        public List<DominioSKD.Planilla> LlenarTabla()
        {
            return logica.ConsultarPlanillas();
        }

    }
}