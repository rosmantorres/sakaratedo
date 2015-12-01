using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace templateApp.GUI.Modulo14
{
    public partial class M14_SolicitarPlanilla : System.Web.UI.Page
    {
        private LogicaNegociosSKD.Modulo14.LogicaSolicitud logica = new LogicaNegociosSKD.Modulo14.LogicaSolicitud();
        List<DominioSKD.Planilla> lista;

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
            this.lista = lista;
            foreach (DominioSKD.Planilla plani in lista)
            {
                this.tabla.Text += RecursoInterfazModulo14.AbrirTR;
                this.tabla.Text += RecursoInterfazModulo14.AbrirTD + plani.Nombre.ToString() + RecursoInterfazModulo14.CerrarTD;
                this.tabla.Text += RecursoInterfazModulo14.AbrirTD + plani.TipoPlanilla.ToString() + RecursoInterfazModulo14.CerrarTD;
                this.tabla.Text += RecursoInterfazModulo14.AbrirTD;
                this.tabla.Text += RecursoInterfazModulo14.BotonSolicitarPlanilla + plani.ID + RecursoInterfazModulo14.IdDis+plani.Diseño.ID + RecursoInterfazModulo14.CerrarSolicitud;              
                this.tabla.Text += RecursoInterfazModulo14.CerrarTD;
                this.tabla.Text += RecursoInterfazModulo14.CerrarTR;
            }
        }
        public List<DominioSKD.Planilla> LlenarTabla()
        {
            return logica.ConsultarPlanillasASolicitar();
        }
    }
    
       
}