using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using LogicaNegociosSKD.Modulo8;
using ExcepcionesSKD;
using Interfaz_Contratos.Modulo8;
using Interfaz_Presentadores.Modulo8;
using DominioSKD;


namespace templateApp.GUI.Modulo8
{
    public partial class interfazModificarRestriccionEvento : System.Web.UI.Page, IContratoModificarRestriccionCompetencia
    {
        private PresentadorModificarRestriccionCompetencia _presentador;
        #region Constructor_presentador
        public interfazModificarRestriccionEvento()
        {
            _presentador = new PresentadorModificarRestriccionCompetencia(this);
        }
        #endregion
        #region contrato

        public string id
        {
            get
            {
                return Request.QueryString["idPlan"];
            }
            set
            {
                this.descripcion = Request.QueryString["idPlan"];
            }
        }
        public String descripcion { get; set; }
        //ListBox competenciasRelacionadas { get; set; }
        //ListBox competeciasNoRelacionadas { get; set; }
        public DropDownList rangoMinimo
        {
            get
            {
                return this.comboRangoMinimo;
            }

            set
            {
                this.comboRangoMinimo = value;
            }

        }
        public DropDownList rangoMaximo
        {
            get
            {
                return this.comboRangoMaximo;
            }

            set
            {
                this.comboRangoMaximo = value;
            }

        }
        public DropDownList edadMinima
        {
            get
            {
                return this.comboEdadMinima;
            }

            set
            {
                this.comboEdadMinima = value;
            }

        }
        public DropDownList edadMaxima
        {
            get
            {
                return this.comboEdadMaxima;
            }

            set
            {
                this.comboEdadMaxima = value;
            }

        }

        public DropDownList sexo
        {
            get
            {
                return this.comboSexo;
            }

            set
            {
                this.comboSexo = value;
            }

        }

        public DropDownList modalidad
        {
            get
            {
                return this.comboModalidad;
            }

            set
            {
                this.comboModalidad = value;
            }

        }
        #endregion
        protected void Page_Load(object sender, EventArgs e)
        {
            String idEvento = Request.QueryString["idPlan"];
            if (!IsPostBack)
            {
                ((SKD)Page.Master).IdModulo = "8";
                _presentador.LlenarComboEdades();
                _presentador.LlenarComboModalidad();
                _presentador.LlenarComboRangos();
                _presentador.LlenarComboSexo();
            }
        }


        protected void btnaceptar_Click(object sender, EventArgs e)
        {
            _presentador.ModificarRest();

        }
    }
}