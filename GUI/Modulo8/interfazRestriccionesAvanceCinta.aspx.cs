using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
//using LogicaNegociosSKD..Modulo14;
using ExcepcionesSKD;
using Interfaz_Contratos.Modulo8;
using Interfaz_Presentadores.Modulo8;
using DominioSKD;


namespace templateApp.GUI.Modulo8
{
    public partial class interfazRestriccionesAvanceCinta : System.Web.UI.Page, IContratoConsultarResticcionCinta
    {
        private PresentadorConsultarRestriccionesCinta _presentador;

        #region Contratos
        public string alertaClase
        {
            set
            {
                this.alerta.Attributes["class"] = value;
            }
        }
        public string alertaRol
        {
            set
            {
                this.alerta.Attributes["role"] = value;
            }
        }
        public string alert
        {
            set
            {
                this.alerta.InnerHtml = value;
            }
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

        public interfazRestriccionesAvanceCinta()
        {
            _presentador = new PresentadorConsultarRestriccionesCinta(this);
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            String success = Request.QueryString["idPlan"];
            String stat = Request.QueryString["stat"];

            ((SKD)Page.Master).IdModulo = "8.3";

            if (success != null)
            {
                int id = Convert.ToInt32(success);
                int sta = Convert.ToInt32(stat);
                _presentador.CambiarStatus(id, sta);

                if (sta.Equals("1"))
                {
                    alerta.Attributes["class"] = "alert alert-success alert-dismissible";
                    alerta.Attributes["role"] = "alert";
                    alerta.InnerHtml = "<div><button type=\"button\" class=\"close\" data-dismiss=\"alert\" aria-label=\"Close\"><span aria-hidden=\"true\">&times;</span></button>Restricción modificada exitosamente</div>";
                }
                else
                {
                    if (success.Equals("2"))
                    {
                        alerta.Attributes["class"] = "alert alert-success alert-dismissible";
                        alerta.Attributes["role"] = "alert";
                        alerta.InnerHtml = "<div><button type=\"button\" class=\"close\" data-dismiss=\"alert\" aria-label=\"Close\"><span aria-hidden=\"true\">&times;</span></button>Restricción eliminada exitosamente</div>";
                    }
                    else
                        if (success.Equals("3"))
                        {
                            alerta.Attributes["class"] = "alert alert-success alert-dismissible";
                            alerta.Attributes["role"] = "alert";
                            alerta.InnerHtml = "<div><button type=\"button\" class=\"close\" data-dismiss=\"alert\" aria-label=\"Close\"><span aria-hidden=\"true\">&times;</span></button>Restricción agregada exitosamente</div>";
                        }
                }
            }


            if (!IsPostBack)
            {

                List<Entidad> listaRestricciones = _presentador.LlenarTabla();
                _presentador.LlenarInformacion(listaRestricciones);
            }

            

        }
    }
}