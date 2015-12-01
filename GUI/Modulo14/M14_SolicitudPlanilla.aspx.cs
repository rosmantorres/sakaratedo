using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DominioSKD;
using LogicaNegociosSKD;
using LogicaNegociosSKD.Modulo14;

namespace templateApp.GUI.Modulo14
{
    public partial class SolicitudPlanilla : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ((SKD)Page.Master).IdModulo = "14";
             if (!IsPostBack){
               int idPlanilla = Int32.Parse(Request.QueryString[RecursoInterfazModulo14.idPlan]);
               this.id_planilla.Value = idPlanilla.ToString(); 
                 id_planilla.Visible = false;
                 llenarComboEventos();
                 llenarComboCompetencia();
                 LogicaSolicitud lP = new LogicaSolicitud();
                 List<bool> datosRequeridos = lP.DatosRequeridosSolicitud(idPlanilla);
                 if (datosRequeridos[0]==true){
                     fechaRet.Visible = true;
                 }else{
                     fechaRet.Visible = false;
                 }
                 if (datosRequeridos[1]==true){
                     fechaRei.Visible = true;
                 }else{
                     fechaRet.Visible = false;
                 }

             }
        }


        protected void llenarComboEventos()
        {

            LogicaNegociosSKD.Modulo14.LogicaSolicitud lP = new LogicaNegociosSKD.Modulo14.LogicaSolicitud();
            List<String> listEventos = lP.EventosSolicitud(1);
            Dictionary<string, string> options = new Dictionary<string, string>();

            foreach (String item in listEventos)
            {
                options.Add(item,item);
            }

            comboEvento.DataSource = options;
            comboEvento.DataTextField = "value";
            comboEvento.DataValueField = "key";
            comboEvento.DataBind();



        }

        protected void llenarComboCompetencia()
        {

            LogicaNegociosSKD.Modulo14.LogicaSolicitud lP = new LogicaNegociosSKD.Modulo14.LogicaSolicitud();
            List<String> listCompetencias = lP.CompetenciasSolicitud(1);
            Dictionary<string, string> options = new Dictionary<string, string>();

            foreach (String item in listCompetencias)
            {
                options.Add(item, item);
            }

            comboCompetencia.DataSource = options;
            comboCompetencia.DataTextField = "value";
            comboCompetencia.DataValueField = "key";
            comboCompetencia.DataBind();
            
        }

        protected void btnaceptar_Click(object sender, EventArgs e)
        {

            LogicaSolicitud lS = new LogicaSolicitud();

            SolicitudP laSolicitud = new SolicitudP(this.id_fechaI.Value, this.id_fechaF.Value, this.id_motivo.Value, Int32.Parse(this.id_planilla.Value));
            lS.RegistrarSolicitudPlanilla(laSolicitud);
            Response.Redirect("../Modulo14/M14_SolicitarPlanilla.aspx?success=true");
        }
    }
} 