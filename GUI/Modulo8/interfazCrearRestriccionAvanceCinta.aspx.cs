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

      /* public void alertaCamposVacios()
       {
           this.alert.Attributes[RecursoInterfazModulo8.alertClase] = RecursoInterfazModulo8.alertaError;
           this.alert.Attributes[RecursoInterfazModulo8.alertRole] = RecursoInterfazModulo8.tipoAlerta;
           this.alert.InnerHtml = RecursoInterfazModulo8.alertaHtml + RecursoInterfazModulo8.camposVacios + RecursoInterfazModulo8.alertaHtmlFinal;
           this.alert.Visible = true;
       }
       public void alertaAgregarFallidoOrden(ExcepcionesSKD.Modulo8.RestriccionExistenteException ex)
       {
           this.alert.Attributes[RecursoInterfazModulo8.alertClase] = RecursoInterfazModulo8.alertaError;
           this.alert.Attributes[RecursoInterfazModulo8.alertRole] = RecursoInterfazModulo8.tipoAlerta;
           this.alert.InnerHtml = RecursoInterfazModulo8.alertaHtml + ex.Message + RecursoInterfazModulo8.alertaHtmlFinal;
           this.alert.Visible = true;
       }
       public void alertaAgregarFallidoRepetida(ExcepcionesSKD.Modulo8.RestriccionRepetidaException ex)
       {
           this.alert.Attributes[RecursoInterfazModulo8.alertClase] = RecursoInterfazModulo8.alertaError;
           this.alert.Attributes[RecursoInterfazModulo8.alertRole] = RecursoInterfazModulo8.tipoAlerta;
           this.alert.InnerHtml = RecursoInterfazModulo8.alertaHtml + ex.Message + RecursoInterfazModulo8.alertaHtmlFinal;
           this.alert.Visible = true;
       }*/
       public void Respuesta()
       {
           this.Response.Redirect(RecursoInterfazModulo8.ReturnRestCinta);
       }
       public string alertaClase
       {
           set
           {
               this.alert.Attributes["class"] = value;
           }
       }
       public string alertaRol
       {
           set
           {
               this.alert.Attributes["role"] = value;
           }
       }
       public string alerta
       {
           set
           {
               this.alert.InnerHtml = value;
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
                ((SKD)Page.Master).IdModulo = RecursoInterfazModulo8.Mod8;
                try
                {
                    _presentador.LlenarComboCinta();
                }
                catch (ExcepcionesSKD.ExceptionSKDConexionBD ex)
                {
                    _presentador.Alerta(ex.Message);
                }
            }
        }
        
               
       protected void btnaceptar_Click(object sender, EventArgs e)
        {
            if (_presentador.agregarRest() == true)
            {
                Response.Redirect(RecursoInterfazModulo8.ReturnRestCinta);
            }

        }
       /*public void Alerta(string msj)
       {
          /* _presentador.Alerta(msj);
            alert.Attributes["class"] = "alert alert-danger alert-dismissible";
            alert.Attributes["role"] = "alert";
            alert.InnerHtml = "<div><button type=\"button\" class=\"close\" data-dismiss=\"alert\" aria-label=\"Close\"><span aria-hidden=\"true\">&times;</span></button>" + msj + "</div>";
       }*/

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