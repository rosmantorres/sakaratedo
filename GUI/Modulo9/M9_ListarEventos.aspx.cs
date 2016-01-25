using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DominioSKD;
using System.Text.RegularExpressions;
using System.Globalization;
using Interfaz_Contratos.Modulo9;
using Interfaz_Presentadores.Modulo9;
using templateApp.GUI.Master;

namespace templateApp.GUI.Modulo9
{
    public partial class M9_ListarEventos : System.Web.UI.Page, IContratoListarEventos
    {
        private PresentadorListarEventos presentador;
        public M9_ListarEventos()
        {
            presentador = new PresentadorListarEventos(this);
        }


        protected void Page_Load(object sender, EventArgs e)
        {
            ((SKD)Page.Master).IdModulo = M9_RecursoInterfaz.idModulo;
            presentador.ObtenerVariablesURL();

            if (!IsPostBack)
            {
                presentador.ListarEventos(Session[RecursosInterfazMaster.sessionUsuarioID].ToString());
            }
        }


        #region Contrato

        string IContratoListarEventos.ilaTabla{
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
            set { alert.Attributes[M9_RecursoInterfaz.alertClase] = value; }
        }

        public string alertaRol
        {
            set { alert.Attributes[M9_RecursoInterfaz.alertRole] = value; }
        }

        public string alerta
        {
            set { alert.InnerHtml = value; }
        }


        #endregion


    }
}