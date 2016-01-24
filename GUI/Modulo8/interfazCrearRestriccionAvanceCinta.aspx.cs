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
    public partial class interfazCrearRestriccionAvanceCinta : System.Web.UI.Page, IContratoAgregarRestriccionCinta
    {
       PresentadorAgregarRestriccionCinta _presentador;

       #region Implementacion de Contrato

       public string id_rest_cinta
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

       public string descripcion_rest_cinta
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

       public string tiempo_Min
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

       public string tiempo_Max
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

       public string puntaje_min
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

       public string horas_docen
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

       public String alertLocalRol
        {
            set
            {
                this.alertlocal.InnerText = value;
            }
        }

       public String alertLocalClase
        {
            set
            {
                this.alert.InnerText = value;
            }
        }

       public String alertLocal
        {
            set
            {
                this.alertlocal.InnerHtml = value;
            }
        }

       public bool alerta
        {
            set
            {
                this.alert.Visible = value;
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
                ((SKD)Page.Master).IdModulo = "8";
                try
                { 
                _presentador.LlenarComboCinta();
                }
                catch (ExcepcionesSKD.ExceptionSKDConexionBD ex)
                {
                    Alerta(ex.Message);
                }
            }
        }
               
       protected void btnaceptar_Click(object sender, EventArgs e)
        {
            _presentador.agregarRest();

        }

       public void Alerta(string msj)
       {
           _presentador.Alerta(msj);
           /* alert.Attributes["class"] = "alert alert-danger alert-dismissible";
            alert.Attributes["role"] = "alert";
            alert.InnerHtml = "<div><button type=\"button\" class=\"close\" data-dismiss=\"alert\" aria-label=\"Close\"><span aria-hidden=\"true\">&times;</span></button>" + msj + "</div>";*/
       }

       public bool validarInput(String pword)
       {
	      var positiveIntRegex = new System.Text.RegularExpressions.Regex(@"^[a-zA-Z0-9]*$");

	      if (!positiveIntRegex.IsMatch(pword))	
	      {
                return false;
	      }
	      else
	      {
		        return true;
	      }
        }
        
    }
}