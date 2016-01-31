using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Interfaz_Presentadores.Modulo8;
using Interfaz_Contratos.Modulo8;
using ExcepcionesSKD;
using System.Text.RegularExpressions;


namespace templateApp.GUI.Modulo8
{
    public partial class interfazModificarRestriccionHorario : System.Web.UI.Page, IContratoModificarRestriccionEvento
    {

        PresentadorModificarRestriccionEvento _presentador;

        #region Implementacion de Contrato

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

        public DropDownList rangoMinimo
        {
            get
            {
                return this.rangoMinimo;
            }
            set
            {
                this.rangoMinimo = value;
            }
        }

        public DropDownList rangoMaximo
        {
            get
            {
                return this.comboCintaMayor;
            }
            set
            {
                this.comboCintaMayor = value;
            }
        }

        public string evento
        {
            get
            {
                return Request.QueryString[RecursoInterfazModulo8.idP];
            }
            set
            {
                String idEvento = Request.QueryString[RecursoInterfazModulo8.idP]; 
            }
        }

        public string alertaClase
        {
            set
            {
                alert.Attributes[RecursoInterfazModulo8.alertClase] = value;
            }
        }

        public string alertaRol
        {
            set
            {
                alert.Attributes[RecursoInterfazModulo8.alertRole] = value;
            }
        }

        public string alerta
        {
            set
            {
                alert.InnerHtml = value;
            }
        }

        public Label myLabel
        {
            get
            {
                return this.labelRest;
            }
            set
            {
                this.labelRest = value;
            }
        }
        #endregion


        #region Constructor

        public interfazModificarRestriccionHorario()
        {
            _presentador = new PresentadorModificarRestriccionEvento(this);
        }
        #endregion
        protected void Page_Load(object sender, EventArgs e)
        {
            String idRest = Request.QueryString[RecursoInterfazModulo8.idP];
            String nombre = Request.QueryString[RecursoInterfazModulo8.nombre];
            String emin = Request.QueryString[RecursoInterfazModulo8.emin];
            String emax = Request.QueryString[RecursoInterfazModulo8.emax];
            String sexo = Request.QueryString[RecursoInterfazModulo8.sexo];
            String descripcion = Request.QueryString[RecursoInterfazModulo8.descripcion];

            if (!IsPostBack)
            {
                ((SKD)Page.Master).IdModulo = RecursoInterfazModulo8.Mod8;
                _presentador.LlenarComboCinta(descripcion);
                _presentador.LlenarComboSexo(sexo);
                _presentador.LlenarComboEdades(emin, emax);
                _presentador.LlenarLabel(idRest, nombre);
            }

        }

        protected void btnaceptar_Click(object sender, EventArgs e)
        {
            Boolean validar = _presentador.ModificarRest();
            if (validar)
            {
                Response.Redirect(RecursoInterfazModulo8.volverRestriccionHorario);
            }
        }
    }
}