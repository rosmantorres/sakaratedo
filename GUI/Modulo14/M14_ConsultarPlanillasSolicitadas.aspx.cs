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
using templateApp.GUI.Master;

namespace templateApp.GUI.Modulo14
{
    public partial class M14_ConsultarPlanillasSolicitadas : System.Web.UI.Page, IContratoM14ConsultarPlanillasSolicitadas
    {
        private LogicaSolicitud logica = new LogicaSolicitud();
        private PresentadorM14ConsultarPlanillasSolicitadas presentador;

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
        public string tablaplanillas
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

        public M14_ConsultarPlanillasSolicitadas()
        {
            presentador = new PresentadorM14ConsultarPlanillasSolicitadas(this);
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            ((SKD)Page.Master).IdModulo = "14.1";
            try
            {
                List<Entidad> listaSolicitud = 
                    presentador.LlenarTabla(Convert.ToInt32(Session[RecursosInterfazMaster.sessionUsuarioID]));
                presentador.LlenarInformacion(listaSolicitud);
                string exito = Request.QueryString[RecursoInterfazModulo14.QueryIdSolici];
                string exito1 = Request.QueryString[RecursoInterfazModulo14.QueryIdEliminar];
                if (exito != null)
                    LlamarVentana_Click();
                if (exito1 != null)
                    EliminarFilaTable();
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


        /*public void LlenarInformacion(List<DominioSKD.SolicitudPlanilla> lista)
        {
            try
            {
                this.lista = lista;
                foreach (DominioSKD.SolicitudPlanilla solici in lista)
                {
                    this.tabla.Text += RecursoInterfazModulo14.AbrirTR;
                    this.tabla.Text += RecursoInterfazModulo14.AbrirTD + solici.ID + RecursoInterfazModulo14.CerrarTD;
                    this.tabla.Text += RecursoInterfazModulo14.AbrirTD + solici.Planilla.Nombre + RecursoInterfazModulo14.CerrarTD;
                    this.tabla.Text += RecursoInterfazModulo14.AbrirTD + solici.Planilla.TipoPlanilla + RecursoInterfazModulo14.CerrarTD;
                    this.tabla.Text += RecursoInterfazModulo14.AbrirTD + solici.FechaRetiro.ToShortDateString() + RecursoInterfazModulo14.Espacio + solici.FechaReincorporacion.ToShortDateString() + RecursoInterfazModulo14.CerrarTD;
                    this.tabla.Text += RecursoInterfazModulo14.AbrirTD + solici.FechaCreacion.ToShortDateString() + RecursoInterfazModulo14.CerrarTD;
                    this.tabla.Text += RecursoInterfazModulo14.AbrirTD + solici.Evento + RecursoInterfazModulo14.CerrarTD;
                    this.tabla.Text += RecursoInterfazModulo14.AbrirTD;
                    this.tabla.Text += RecursoInterfazModulo14.BotonInfoSolicitud + solici.ID + RecursoInterfazModulo14.idIns + solici.IdInscripcion + RecursoInterfazModulo14.Nombre + solici.Planilla.Nombre + RecursoInterfazModulo14.IdPlanilla + solici.Planilla.ID + RecursoInterfazModulo14.BotonCerrar;
                    this.tabla.Text += RecursoInterfazModulo14.BotonModificarSolicitud + solici.ID + RecursoInterfazModulo14.BotonCerrar;
                    this.tabla.Text += RecursoInterfazModulo14.BotonEliminarSolicitud + solici.ID + RecursoInterfazModulo14.BotonCerrar;
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
        public List<DominioSKD.SolicitudPlanilla> LlenarTabla()
        {
            
            try
            {
                return logica.ListarPlanillasSolicitadas(Convert.ToInt32(Session[RecursosInterfazMaster.sessionUsuarioID]));
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
        }*/

        public void LlamarVentana_Click()
        {

            HttpCookie aCookie = new HttpCookie(RecursoInterfazModulo14.CookieSolicitud);
            aCookie.Values[RecursoInterfazModulo14.CookieId] = Request.QueryString[RecursoInterfazModulo14.QueryIdSolici];
            aCookie.Values[RecursoInterfazModulo14.CookieIdIns] = Request.QueryString[RecursoInterfazModulo14.CookieIdIns];
            aCookie.Values[RecursoInterfazModulo14.CookieNombre] = Request.QueryString[RecursoInterfazModulo14.CookieNombre];
            aCookie.Values[RecursoInterfazModulo14.CookieIdPlanilla] = Request.QueryString[RecursoInterfazModulo14.CookieIdPlanilla];
            aCookie.Expires = DateTime.Now.AddMinutes(15);
            Response.Cookies.Add(aCookie);
            HttpContext.Current.Response.Redirect(RecursoInterfazModulo14.PaginaMostrarPlanilla);
        }

        public void EliminarFilaTable()
        {
            presentador.EliminarFilaTable(Request, Convert.ToInt32(Request.QueryString[RecursoInterfazModulo14.QueryIdEliminar]));
                this.tabla.Text = null;
                List<Entidad> listaSolicitud = presentador.LlenarTabla(Convert.ToInt32(Session[RecursosInterfazMaster.sessionUsuarioID]));
                presentador.LlenarInformacion(listaSolicitud);
             
        }
    }
}