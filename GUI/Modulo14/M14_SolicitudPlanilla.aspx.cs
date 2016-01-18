using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DominioSKD;
using LogicaNegociosSKD;
using LogicaNegociosSKD.Modulo14;
using templateApp.GUI.Master;
using Interfaz_Contratos.Modulo14;
using Interfaz_Presentadores.Modulo14;

namespace templateApp.GUI.Modulo14
{
    public partial class SolicitudPlanilla : System.Web.UI.Page, IContratoM14SolicitudPlanilla
    {
        private PresentadorM14SolicitudPlanilla presentador;

        public SolicitudPlanilla()
        {
            presentador = new PresentadorM14SolicitudPlanilla(this);
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            ((SKD)Page.Master).IdModulo = "14.1";
             if (!IsPostBack){
                 
                 presentador.PageLoadSolicitud();
               /*  try
                 {
               int idPlanilla = Int32.Parse(Request.QueryString[RecursoInterfazModulo14.idPlan]);
               this.id_planilla.Value = idPlanilla.ToString(); 
                 id_planilla.Visible = false;
                 
                 LogicaSolicitud lP = new LogicaSolicitud();
                 List<bool> datosRequeridos = lP.DatosRequeridosSolicitud(idPlanilla);
                 if (datosRequeridos[0]==true){
                     fechaRetiro.Visible = true;
                 }else{
                     fechaRetiro.Visible = false;
                 }
                 if (datosRequeridos[1]==true){
                     fechaReincorporacion.Visible = true;
                 }else{
                     fechaReincorporacion.Visible = false;
                 } 
                 if (datosRequeridos[2] == true)
                 {
                     divComboEvento.Visible = true;
                     labelEvento.Visible = true;
                     llenarComboEventos();
                    
                 }
                 else
                 {
                     divComboEvento.Visible = false;
                     labelEvento.Visible = false;
                     
                 }
                 if (datosRequeridos[3] == true)
                 {
                     divComboCompetencia.Visible = true;
                     labelCompetencia.Visible = true;
                    llenarComboCompetencia();
                    
                 }
                 else
                 {
                     divComboCompetencia.Visible = false;
                     labelCompetencia.Visible = false;
                     
                 }
                 if (datosRequeridos[4] == true)
                 {
                     divMotivo.Visible = true;
                    
                 }
                 else
                 {
                     divMotivo.Visible = false;
                 }
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

        #region contratos

        public String planillaId
        {
            get
            {
                return this.id_planilla.Value;
            }
            set
            {
                this.id_planilla.Value = value;
            }
        }
        public String fechaRetiroI
        {
            get
            {
                return this.idFechaI.Value;
            }
        }
        public String FechaReincorporacion
        {
            get
            {
                return this.idFechaF.Value;
            }
        }
        public DropDownList eventoCombo
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
        public DropDownList competenciaCombo
        {
            get
            {
                return this.comboCompetencia;
            }
            set
            {
                this.comboCompetencia = value;
            }
        }
        public String Motivo
        {
            get
            {
                return this.id_motivo.Value;
            }
        }
        public String alertLocalRol
        {
            set
            {
                this.alertlocal.Attributes["role"] = value;
            }
        }
        public String alertLocalClase
        {
            set
            {
                this.alertlocal.Attributes["class"] = value;
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
                this.alertlocal.Visible = value;
            }
        }

        public int IDUsuario
        {
            get
            {
                return Convert.ToInt32(Session[RecursosInterfazMaster.sessionUsuarioID]);
            }
            set
            {
                 Convert.ToInt32(Session[RecursosInterfazMaster.sessionUsuarioID]);
            }
        }
        public bool ComboEventoVisible
        {
            get
            {
                return this.eventoCombo.Visible;
            }
            set
            {
                this.eventoCombo.Visible = value;
            }
        }
        public bool ComboCompetenciaVisible
        {
            get
            {
                return this.comboCompetencia.Visible;
            }
            set
            {
                this.comboCompetencia.Visible = value;
            }
        }
        public int IDPlanilla
        {
            get
            {
                return Int32.Parse(Request.QueryString[RecursoInterfazModulo14.idPlan]);
            }
            set
            {
                Int32.Parse(Request.QueryString[RecursoInterfazModulo14.idPlan]);
            }
        }
        public bool IDPlanillaVisible
        {
            get
            {
                return this.id_planilla.Visible;
            }
            set
            {
                this.id_planilla.Visible = value;
            }
        }
        public bool fechaRetiroVisible
        {
            get
            {
                return this.fechaRetiro.Visible;
            }
            set
            {
                this.fechaRetiro.Visible = value;
            }
        }
        public bool fechaReincorporacionVisible
        {
            get
            {
                return this.fechaReincorporacion.Visible;
            }
            set
            {
                this.fechaReincorporacion.Visible = value;
            }
        }
        public bool divComboEventoVisible
        {
            get
            {
                return this.divComboEvento.Visible;
            }
            set
            {
                this.divComboEvento.Visible = value;
            }
        }
        public bool labelEventoVisible
        {
            get
            {
                return this.labelEvento.Visible;
            }
            set
            {
                this.labelEvento.Visible = value;
            }
        }
        public bool divComboCompetenciaVisible
        {
            get
            {
                return this.comboCompetencia.Visible;
            }
            set
            {
                this.comboCompetencia.Visible = value;
            }
        }
        public bool labelCompetenciaVisible
        {
            get
            {
                return this.labelCompetencia.Visible;
            }
            set
            {
                this.labelCompetencia.Visible = value;
            }
        }
        public bool divMotivoVisible
        {
            get
            {
                return this.divMotivo.Visible;
            }
            set
            {
                this.divMotivo.Visible = value;
            }
        }
        #endregion
        
        public void Alerta(string msj)
        {
           /* alert.Attributes["class"] = "alert alert-danger alert-dismissible";
            alert.Attributes["role"] = "alert";
            alert.InnerHtml = "<div><button type=\"button\" class=\"close\" data-dismiss=\"alert\" aria-label=\"Close\"><span aria-hidden=\"true\">&times;</span></button>" + msj + "</div>";*/
            presentador.Alerta(msj);       
        }
       /* protected void llenarComboEventos()
        {

            LogicaNegociosSKD.Modulo14.LogicaSolicitud lP = new LogicaNegociosSKD.Modulo14.LogicaSolicitud();
            List<SolicitudP> listEventos = lP.EventosSolicitud(Convert.ToInt32(Session[RecursosInterfazMaster.sessionUsuarioID]));
            Dictionary<string, string> options = new Dictionary<string, string>();

            foreach (SolicitudP item in listEventos)
            {
                options.Add(item.ID.ToString(),item.NombreEvento);
            }

            comboEvento.DataSource = options;
            comboEvento.DataTextField = "value";
            comboEvento.DataValueField = "key";
            comboEvento.DataBind();



        }*/

      /*  protected void llenarComboCompetencia()
        {
           
            LogicaNegociosSKD.Modulo14.LogicaSolicitud lP = new LogicaNegociosSKD.Modulo14.LogicaSolicitud();
            List<SolicitudP> listCompetencias = lP.CompetenciasSolicitud(Convert.ToInt32(Session[RecursosInterfazMaster.sessionUsuarioID]));
            Dictionary<string, string> options = new Dictionary<string, string>();

            foreach (SolicitudP item in listCompetencias)
            {
                options.Add(item.ID.ToString(), item.NombreEvento);
            }

            comboCompetencia.DataSource = options;
            comboCompetencia.DataTextField = "value";
            comboCompetencia.DataValueField = "key";
            comboCompetencia.DataBind();
            
        }*/

        protected void btnaceptar_Click(object sender, EventArgs e)
        {
         /*   Planilla planilla = new Planilla();
            planilla.ID = Int32.Parse(this.id_planilla.Value);
            LogicaSolicitud lS = new LogicaSolicitud();
            
            
                        if (comboEvento.Visible == true)
                        {
                            SolicitudP laSolicitud = new SolicitudP(this.idFechaI.Value, this.idFechaF.Value,
                                                         this.id_motivo.Value, planilla, Int32.Parse(this.comboEvento.SelectedValue));
                            lS.RegistrarSolicitudPlanilla(laSolicitud);
                        }
                        if (comboCompetencia.Visible == true)
                        {
                            SolicitudP laSolicitud = new SolicitudP(this.idFechaI.Value, this.idFechaF.Value,
                                                         this.id_motivo.Value, planilla, Int32.Parse(this.comboCompetencia.SelectedValue));
                            lS.RegistrarSolicitudPlanilla(laSolicitud);
                        }
                        if (comboEvento.Visible == false && comboCompetencia.Visible == false)
                        {
                            SolicitudP laSolicitud = new SolicitudP(this.idFechaI.Value, this.idFechaF.Value,
                                                         this.id_motivo.Value, planilla, Convert.ToInt32(Session[RecursosInterfazMaster.sessionUsuarioID]));
                            lS.RegistrarSolicitudIDPersona(laSolicitud);
                        }
                  */

           if( presentador.AgregarSolicitud() == true)
                Response.Redirect("../Modulo14/M14_SolicitarPlanilla.aspx?success=true");
        }
    }
} 