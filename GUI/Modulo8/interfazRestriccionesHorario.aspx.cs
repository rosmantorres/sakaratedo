using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using LogicaNegociosSKD;
using ExcepcionesSKD;
using Interfaz_Contratos.Modulo8;
using Interfaz_Presentadores.Modulo8;
using DominioSKD;
using System.Text.RegularExpressions;
using System.Globalization;
using templateApp.GUI.Master;


namespace templateApp.GUI.Modulo8
{
    public partial class interfazRestriccionesHorario : System.Web.UI.Page, IContratoConsultarRestriccionEvento
    {
        private PresentadorConsultarRestriccionesEvento _presentador;

        #region Contratos
        public string alertaClase
        {
            set { alert.Attributes[RecursoInterfazModulo8.alertClase] = value; }
        }
        public string alertaRol
        {
            set { alert.Attributes[RecursoInterfazModulo8.alertRole] = value; }
        }

        public string alerta
        {
            set { alert.InnerHtml = value; }
        }

        public string RestriccionesCreadas
        {
            get
            {
                return this.tabla.Text;
            }
            set
            {
                this.tabla.Text = value;
            }
        }

        #endregion

        public interfazRestriccionesHorario()
        {
            _presentador = new PresentadorConsultarRestriccionesEvento(this);
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            ((SKD)Page.Master).IdModulo = RecursoInterfazModulo8.interfazRH;
            _presentador.ObtenerVariablesURL();

            if (!IsPostBack)
            {
                // List<Entidad> listaRestricciones = _presentador.LlenarTabla();
                _presentador.LlenarInformacion();
            }

        }
    }
}