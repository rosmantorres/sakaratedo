using DominioSKD;
using Interfaz_Contratos.Modulo10;
using Interfaz_Presentadores.Modulo10;
using LogicaNegociosSKD.Modulo10;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace templateApp.GUI.Modulo10
{
    public partial class M10_ListarAsistenciaEventos : System.Web.UI.Page, IContratoListarAsistencia
    {
        PresentadorListarAsistencia presentador;

        public M10_ListarAsistenciaEventos()
        {
            presentador = new PresentadorListarAsistencia(this);
        }

        #region Contrato
        string IContratoListarAsistencia.tabla
        {
            get
            {
                return tabla.Text;
            }
            set
            {
                tabla.Text = value;
            }
        }

        public string alertaClase
        {
            set { alert.Attributes[M10_RecursosInterfaz.alertClase] = value; }
        }

        public string alertaRol
        {
            set { alert.Attributes[M10_RecursosInterfaz.alertRole] = value; }
        }

        public string alerta
        {
            set { alert.InnerHtml = value; }
        }
        #endregion
        
        protected void Page_Load(object sender, EventArgs e)
        {
            ((SKD)Page.Master).IdModulo = "10";

            presentador.ObtenerUrls_ObtenerAlerts();

            if (!IsPostBack)
            {
                presentador.CargaTablaEventosCompetencias();
            }
        }
    }
}