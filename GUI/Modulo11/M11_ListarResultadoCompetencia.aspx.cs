using DominioSKD;
using Interfaz_Contratos.Modulo11;
using Interfaz_Presentadores.Modulo11;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace templateApp.GUI.Modulo11
{
    public partial class ListarResultadoCompetencia : System.Web.UI.Page, IContratoListarResultadoCompetencia
    {
        PresentadorListaResultado presentador;
        public ListarResultadoCompetencia()
        {
            presentador = new PresentadorListaResultado(this);
        }

        #region Contrato
        public Literal Tabla
        {
            get
            {
                return dataTable;
            }
            set
            {
                dataTable = value;
            }
        }

        public string alertaClase
        {
            set { alert.Attributes[M11_RecursoInterfaz.alertClase] = value; }
        }

        public string alertaRol
        {
            set { alert.Attributes[M11_RecursoInterfaz.alertRole] = value; }
        }

        public string alerta
        {
            set { alert.InnerHtml = value; }
        }
        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            ((SKD)Page.Master).IdModulo = "11";
            presentador.ObtenerUrls_ObtenerAlerts();
            
            #region Carga de tabla de Eventos y Competencias
            if (!IsPostBack)
            {
                presentador.CargaTablaEventosCompetencias();
            }
            #endregion

        }
    }
}