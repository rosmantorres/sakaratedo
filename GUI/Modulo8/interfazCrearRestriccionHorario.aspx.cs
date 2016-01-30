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
    public partial class interfazCrearRestriccionHorario : System.Web.UI.Page, IContratoAgregarRestriccionEvento
    {
        PresentadorAgregarRestriccionEvento _presentador;

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

        public DropDownList eventos
        {
            get
            {
                return this.comboEvento;
            }
            set
            {
                this.comboEvento = value;
            }
        }
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
      
        #endregion


        #region Constructor

        public interfazCrearRestriccionHorario()
        {
            _presentador = new PresentadorAgregarRestriccionEvento(this);
        }
        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ((SKD)Page.Master).IdModulo = "8";
                _presentador.LlenarComboCinta();
                _presentador.LlenarComboEvento();
                _presentador.LlenarComboSexo();
                _presentador.LlenarComboEdades();
            }

        }

        protected void btnaceptar_Click(object sender, EventArgs e)
        {
            Boolean validar = _presentador.agregarRest();
            if (validar)
            {
                Response.Redirect(RecursoInterfazModulo8.volverRestriccionHorario);
            }
        }
    }
}