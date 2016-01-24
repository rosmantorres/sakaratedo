using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using LogicaNegociosSKD.Modulo14;
using ExcepcionesSKD;
using Interfaz_Contratos.Modulo14;
using Interfaz_Presentadores.Modulo14;
using DominioSKD;


namespace templateApp.GUI.Modulo14
{
    public partial class M14ConsultarPlanillas : System.Web.UI.Page, IContratoM14ConsultarPlanillas
    {
        #region atributos
        private PresentadorM14ConsultarPlanillas presentador;
        private LogicaNegociosSKD.Modulo14.LogicaPlanilla logica = new LogicaNegociosSKD.Modulo14.LogicaPlanilla();
        #endregion

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
        public string planillaCreadas
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

        #region metodos

        public M14ConsultarPlanillas()
        {
            presentador = new PresentadorM14ConsultarPlanillas(this);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Page_Load(object sender, EventArgs e)
        {
            ((SKD)Page.Master).IdModulo = "14";

            try
            {
                if (!IsPostBack)
                {
                    
                    List<Entidad> listaPlanilla = presentador.LlenarTabla();
                    presentador.LlenarInformacion(listaPlanilla);
                }

                string exito = Request.QueryString[RecursoInterfazModulo14.QueryIdPlan];
                if (exito != null)
                    LlamarVentana_Click();
            }
            catch (ExcepcionesSKD.ExceptionSKDConexionBD ex)
            {
                presentador.Alerta(ex.Message);
            }
            catch (ExcepcionesSKD.Modulo14.BDDiseñoException ex)
            {
                presentador.Alerta(ex.Message);
            }
            catch (ExcepcionesSKD.Modulo14.BDDatosException ex)
            {
                presentador.Alerta(ex.Message);
            }
            catch (ExcepcionesSKD.Modulo14.BDPLanillaException ex)
            {
                presentador.Alerta(ex.Message);
            }
            catch (ExcepcionesSKD.Modulo14.BDSolicitudException ex)
            {
                presentador.Alerta(ex.Message);
            }
            catch (NullReferenceException ex)
            {
                presentador.Alerta(ex.Message);
            }
            catch (Exception ex)
            {
                presentador.Alerta(ex.Message);
            }           

        }

        /// <summary>
        /// 
        /// </summary>
        public void LlamarVentana_Click()
        {
            if (Request.QueryString["status"] == "true")
            {
                int id = Convert.ToInt32(Request.QueryString[RecursoInterfazModulo14.QueryIdPlan]);
                presentador.CambiarStatus(id);
                HttpContext.Current.Response.Redirect("M14_ConsultarPlanillas.aspx");
            }
            else
            {
                HttpCookie aCookie = new HttpCookie(RecursoInterfazModulo14.CookiePlanilla);
                aCookie.Values[RecursoInterfazModulo14.CookieId] = Request.QueryString[RecursoInterfazModulo14.QueryIdPlan];
                aCookie.Values[RecursoInterfazModulo14.CookieNombre] = Request.QueryString[RecursoInterfazModulo14.CookieNombre];
                aCookie.Values[RecursoInterfazModulo14.Tipo] = Request.QueryString[RecursoInterfazModulo14.Tipo];
                aCookie.Values[RecursoInterfazModulo14.CookieDis] = RecursoInterfazModulo14.Numero1;
                aCookie.Expires = DateTime.Now.AddMinutes(15);
                Response.Cookies.Add(aCookie);
                HttpContext.Current.Response.Redirect(RecursoInterfazModulo14.PaginaDisenoPlanilla);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void CambioDeStatus_Click(object sender, EventArgs e)
        {

        }
        #endregion


    }
}