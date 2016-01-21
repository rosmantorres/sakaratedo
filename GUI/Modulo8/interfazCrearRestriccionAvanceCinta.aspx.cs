using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Interfaz_Presentadores.Modulo8;
using Interfaz_Contratos.Modulo8;
using ExcepcionesSKD;

namespace templateApp.GUI.Modulo8
{
    public partial class interfazCrearRestriccionAvanceCinta : System.Web.UI.Page, IContratoAgregarRestriccionCinta
    {
       PresentadorAgregarRestriccionCinta _presentador;

       #region Implementacion de Contrato

       public String id_rest_cinta
       {
           get
           {
               return this.tiempo_minimo.Value;
           }
           set
           {
               this.tiempo_minimo.Value = value;
           }
       }

       public String descripcion_rest_cinta
        {
            get
            {
                return this.descripcion.Value;
            }
            set
            {
                this.descripcion.Value = value;
            }
        }

       public String tiempo_Min
        {
            get
            {
                return this.tiempo_minimo.Value;
            }
            set
            {
                this.tiempo_minimo.Value = value;
            }
        }

       public String tiempo_Max
        {
            get
            {
                return this.tiempo_maximo.Value;
            }
            set
            {
                this.tiempo_maximo.Value = value;
            }
        }

       public String puntaje_min
        {
            get
            {
                return this.puntaje_minimo.Value;
            }
            set
            {
                this.puntaje_minimo.Value = value;
            }
        }

        public String horas_docen
        {
            get
            {
                return this.horas_docentes.Value;
            }
            set
            {
                this.horas_docentes.Value = value;
            }
        }

        public DropDownList comboRestCinta
        {
            get
            {
                return this.comboCinta;
            }
            set
            {
                this.comboCinta = value;
            }
        }
        #endregion

       #region Constructor
        public interfazCrearRestriccionAvanceCinta()
		{
            _presentador = new PresentadorAgregarRestriccionCinta(this);
		}
        #endregion

       protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ((SKD)Page.Master).IdModulo = "14";
                
                   // _presentador.LlenarComboTipoPlanilla();
            }
        }
               
       protected void btnaceptar_Click(object sender, EventArgs e)
        {
            string opcionDato = descripcion.Value.ToString();
            string opciondato2 = tiempo_minimo.Value;
            string opciondato3 = tiempo_maximo.Value;
            string opciondato4 = puntaje_minimo.Value;
            string opciondato5 = horas_docentes.Value;


            /*RestriccionCinta Restriccion = new RestriccionCinta(opcionDato, Int32.Parse(opciondato2), Int32.Parse(opciondato3), Int32.Parse(opciondato4), Int32.Parse(opciondato5));

            LogicaRestriccionCinta LRC = new LogicaRestriccionCinta();

            if (this.comboCinta.SelectedValue != "-1" && this.comboCinta.SelectedValue != "-2")
            {
                LRC.AgregarRestriccionCinta(Restriccion, Int32.Parse(this.comboCinta.SelectedValue));
            }*/

        }
        
    }
}