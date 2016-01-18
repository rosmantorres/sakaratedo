using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ExcepcionesSKD;
using Interfaz_Contratos.Modulo14;
using Interfaz_Presentadores.Modulo14;

namespace templateApp.GUI.Modulo14
{
    public partial class M14_SolicitarPlanilla : System.Web.UI.Page, IContratoM14SolicitarPlanilla
    {
        private LogicaNegociosSKD.Modulo14.LogicaSolicitud logica = new LogicaNegociosSKD.Modulo14.LogicaSolicitud();
        List<DominioSKD.Planilla> lista;
        private PresentadorM14SolicitarPlanilla presentador;

        public M14_SolicitarPlanilla()
        {
            presentador = new PresentadorM14SolicitarPlanilla(this);
        }
        #region contratos
        public String tablaSolicitarP
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
        protected void Page_Load(object sender, EventArgs e)
        {
            ((SKD)Page.Master).IdModulo = "14.1";
            if (!IsPostBack)
            {
                presentador.PageLoadSolicitarPlanilla();
               /* try
                {
                    List<DominioSKD.Planilla> listaPlanilla = LlenarTabla();
                    LlenarInformacion(listaPlanilla);
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
                }*/
            }
        }

        public void Alerta(string msj)
        {
            presentador.Alerta(msj);
            /*alert.Attributes["class"] = "alert alert-danger alert-dismissible";
            alert.Attributes["role"] = "alert";
            alert.InnerHtml = "<div><button type=\"button\" class=\"close\" data-dismiss=\"alert\" aria-label=\"Close\"><span aria-hidden=\"true\">&times;</span></button>" + msj + "</div>";
        */}

       /* public void LlenarInformacion(List<DominioSKD.Planilla> lista)
        {
            this.lista = lista;
            try
            {
                foreach (DominioSKD.Planilla plani in lista)
                {
                    this.tabla.Text += RecursoInterfazModulo14.AbrirTR;
                    this.tabla.Text += RecursoInterfazModulo14.AbrirTD + plani.Nombre.ToString() + RecursoInterfazModulo14.CerrarTD;
                    this.tabla.Text += RecursoInterfazModulo14.AbrirTD + plani.TipoPlanilla.ToString() + RecursoInterfazModulo14.CerrarTD;
                    this.tabla.Text += RecursoInterfazModulo14.AbrirTD;
                    this.tabla.Text += RecursoInterfazModulo14.BotonSolicitarPlanilla + plani.ID + RecursoInterfazModulo14.IdDis + plani.Diseño.ID + RecursoInterfazModulo14.CerrarSolicitud;
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
        }*/
        /*public List<DominioSKD.Planilla> LlenarTabla()
        {
            try
            {
                return logica.ConsultarPlanillasASolicitar();
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
    }
    
       
}