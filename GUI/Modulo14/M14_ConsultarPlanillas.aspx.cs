using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.Odbc;
using System.Data.SqlClient;
using ExcepcionesSKD;


namespace templateApp.GUI.Modulo14
{
    public partial class M14ConsultarPlanillas : System.Web.UI.Page
    {
        #region atributos
        private LogicaNegociosSKD.Modulo14.LogicaPlanilla logica = new LogicaNegociosSKD.Modulo14.LogicaPlanilla();
        List<DominioSKD.Planilla> lista;
        #endregion

        #region metodos
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
                    List<DominioSKD.Planilla> listaPlanilla = LlenarTabla();
                    LlenarInformacion(listaPlanilla);
                }

                string exito = Request.QueryString[RecursoInterfazModulo14.QueryIdPlan];
                if (exito != null)
                    LlamarVentana_Click();
            }
            catch (ExcepcionesSKD.ExceptionSKDConexionBD ex)
            {
                Alerta(ex.Message);
            }
            catch (ExcepcionesSKD.Modulo14.BDDiseñoException ex)
            {
                Alerta(ex.Message);
            }
            catch (ExcepcionesSKD.Modulo14.BDDatosException ex)
            {
                Alerta(ex.Message);
            }
            catch (ExcepcionesSKD.Modulo14.BDPLanillaException ex)
            {
                Alerta(ex.Message);
            }
            catch (ExcepcionesSKD.Modulo14.BDSolicitudException ex)
            {
                Alerta(ex.Message);
            }
            catch (NullReferenceException ex)
            {
                Alerta(ex.Message);
            }
            catch (Exception ex)
            {
                Alerta(ex.Message);
            }           

        }

        public void Alerta(string msj)
        {
            alert.Attributes["class"] = "alert alert-danger alert-dismissible";
            alert.Attributes["role"] = "alert";
            alert.InnerHtml = "<div><button type=\"button\" class=\"close\" data-dismiss=\"alert\" aria-label=\"Close\"><span aria-hidden=\"true\">&times;</span></button>" + msj + "</div>";
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="lista"></param>
        public void LlenarInformacion(List<DominioSKD.Planilla> lista)
        {
            try
            {
                this.lista = lista;
                foreach (DominioSKD.Planilla plani in lista)
                {
                    this.tabla.Text += RecursoInterfazModulo14.AbrirTR;
                    this.tabla.Text += RecursoInterfazModulo14.AbrirTD + plani.ID.ToString() + RecursoInterfazModulo14.CerrarTD;
                    this.tabla.Text += RecursoInterfazModulo14.AbrirTD + plani.Nombre.ToString() + RecursoInterfazModulo14.CerrarTD;
                    this.tabla.Text += RecursoInterfazModulo14.AbrirTD + plani.TipoPlanilla.ToString() + RecursoInterfazModulo14.CerrarTD;
                    this.tabla.Text += RecursoInterfazModulo14.AbrirTD + plani.Status.ToString() + RecursoInterfazModulo14.CerrarTD;
                    this.tabla.Text += RecursoInterfazModulo14.AbrirTD;
                    foreach (string dat in plani.Dato)
                    {
                        this.tabla.Text += dat + RecursoInterfazModulo14.linea;
                    }
                    this.tabla.Text += RecursoInterfazModulo14.CerrarTD;
                    this.tabla.Text += RecursoInterfazModulo14.AbrirTD;
                    this.tabla.Text += RecursoInterfazModulo14.BotonModificar + plani.ID + RecursoInterfazModulo14.Nombre + plani.Nombre + RecursoInterfazModulo14.Tipo + plani.TipoPlanilla + RecursoInterfazModulo14.BotonCerrar;
                    this.tabla.Text += RecursoInterfazModulo14.BotonModificarRegistro + plani.ID + RecursoInterfazModulo14.Nombre + plani.Nombre + RecursoInterfazModulo14.Tipo + plani.TipoPlanilla + RecursoInterfazModulo14.BotonCerrar;
                    if (plani.Status)
                        this.tabla.Text += RecursoInterfazModulo14.BotonActivarPlanilla + plani.ID + RecursoInterfazModulo14.BotonCerrar;
                    else
                        this.tabla.Text += RecursoInterfazModulo14.BotonDesactivarPlanilla + plani.ID + RecursoInterfazModulo14.BotonCerrar;
                    this.tabla.Text += RecursoInterfazModulo14.CerrarTD;
                    this.tabla.Text += RecursoInterfazModulo14.CerrarTR;

                }
            }
            catch (NullReferenceException ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                throw ex;
            }
            catch (Exception ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                throw ex;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public List<DominioSKD.Planilla> LlenarTabla()
        {
            try
            {
                return logica.ConsultarPlanillas();
            }
            catch (ExcepcionesSKD.ExceptionSKDConexionBD ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                throw ex;
            }
            catch (ExcepcionesSKD.Modulo14.BDDiseñoException ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                throw ex;
            }
            catch (ExcepcionesSKD.Modulo14.BDDatosException ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                throw ex;
            }
            catch (ExcepcionesSKD.Modulo14.BDPLanillaException ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                throw ex;
            }
            catch (ExcepcionesSKD.Modulo14.BDSolicitudException ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                throw ex;
            }
            catch (Exception ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                throw ex;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public void LlamarVentana_Click()
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