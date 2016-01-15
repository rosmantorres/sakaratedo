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

namespace templateApp.GUI.Modulo14
{
    public partial class SolicitudPlanilla : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            ((SKD)Page.Master).IdModulo = "14.1";
             if (!IsPostBack){
                 try
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
                 }
               
             }
        }

        public void Alerta(string msj)
        {
            alert.Attributes["class"] = "alert alert-danger alert-dismissible";
            alert.Attributes["role"] = "alert";
            alert.InnerHtml = "<div><button type=\"button\" class=\"close\" data-dismiss=\"alert\" aria-label=\"Close\"><span aria-hidden=\"true\">&times;</span></button>" + msj + "</div>";
        }
        protected void llenarComboEventos()
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



        }

        protected void llenarComboCompetencia()
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
            
        }

        protected void btnaceptar_Click(object sender, EventArgs e)
        {
            Planilla planilla = new Planilla();
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
                  

     
            Response.Redirect("../Modulo14/M14_SolicitarPlanilla.aspx?success=true");
        }
    }
} 