using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DominioSKD;
using LogicaNegociosSKD;
using LogicaNegociosSKD.Modulo12;
using Interfaz_Contratos.Modulo12;
using Interfaz_Presentadores.Modulo12;

namespace templateApp.GUI.Modulo12
{
    public partial class M12_ListarCompetencias : System.Web.UI.Page, IContratoListarCompetencias
    {
        private List<Competencia> laLista = new List<Competencia>();
        private PresentadorListarCompetencias presentador;

        public M12_ListarCompetencias()
        {
            presentador = new PresentadorListarCompetencias(this);
        }

        #region Contrato

        string IContratoListarCompetencias.laTabla
        {
            get
            {
                return laTabla.Text;
            }
            set
            {
                laTabla.Text = value;
            }
        }

        public string alertaClase
        {
            set { alert.Attributes[M12_RecursoInterfaz.alertClase] = value; }
        }

        public string alertaRol
        {
            set { alert.Attributes[M12_RecursoInterfaz.alertRole] = value; }
        }

        public string alerta
        {
            set { alert.InnerHtml = value; }
        }


        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            ((SKD)Page.Master).IdModulo = M12_RecursoInterfaz.idModulo;
            presentador.ObtenerVariablesURL();

            if (!IsPostBack)
            {
                presentador.ConsultarCompetencias();
            }
        }

        protected void btn_eliminarComp_Click(object sender, EventArgs e)
        {

        }

        protected void llenarModalInfo(int elIdCompetencia)
        {
            Competencia laCompetencia = new Competencia();
            LogicaCompetencias logica = new LogicaCompetencias();
            laCompetencia = logica.detalleCompetenciaXId(elIdCompetencia);

        }

    }
}