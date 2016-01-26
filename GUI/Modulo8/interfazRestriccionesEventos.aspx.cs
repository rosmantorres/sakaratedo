using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using LogicaNegociosSKD.Comandos.Modulo14;
using ExcepcionesSKD;
using Interfaz_Contratos.Modulo8;
using Interfaz_Presentadores.Modulo8;
using DominioSKD;

namespace templateApp.GUI.Modulo8
{


    public partial class interfazRestriccionesEventos : System.Web.UI.Page, IContratoConsultarRestriccionCompetencia
    {

        private PresentadorConsultarTodosRestriccionCompetencia _presentador;

        #region contratos
        public string restriccionCompetencia
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

        #region constructor
        public interfazRestriccionesEventos()
        {
            _presentador = new PresentadorConsultarTodosRestriccionCompetencia(this);
        }
        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            ((SKD)Page.Master).IdModulo = "8.2";
            if (!IsPostBack)
            {
                List<Entidad> listaRestricciones = _presentador.LlenarTabla();
                _presentador.cargarInformacion(listaRestricciones);
            }
            String success = Request.QueryString["actionSuccess"];

            if (success != null)
            {
                if (success.Equals("1"))
                {
                    alert.Attributes["class"] = "alert alert-success alert-dismissible";
                    alert.Attributes["role"] = "alert";
                    alert.InnerHtml = "<div><button type=\"button\" class=\"close\" data-dismiss=\"alert\" aria-label=\"Close\"><span aria-hidden=\"true\">&times;</span></button>Restricción agregada exitosamente</div>";
                }
                else
                {
                    if (success.Equals("2"))
                    {
                        alert.Attributes["class"] = "alert alert-success alert-dismissible";
                        alert.Attributes["role"] = "alert";
                        alert.InnerHtml = "<div><button type=\"button\" class=\"close\" data-dismiss=\"alert\" aria-label=\"Close\"><span aria-hidden=\"true\">&times;</span></button>Restricción eliminada exitosamente</div>";
                    }
                    else
                        if (success.Equals("3"))
                        {
                            alert.Attributes["class"] = "alert alert-success alert-dismissible";
                            alert.Attributes["role"] = "alert";
                            alert.InnerHtml = "<div><button type=\"button\" class=\"close\" data-dismiss=\"alert\" aria-label=\"Close\"><span aria-hidden=\"true\">&times;</span></button>Restricción modificada exitosamente</div>";
                        }
                }
            }
        }
    }
}