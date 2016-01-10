﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using LogicaNegociosSKD;
using LogicaNegociosSKD.Modulo14;
using DominioSKD;
using templateApp.GUI.Master;


namespace templateApp.GUI.Modulo14
{
    public partial class ModificarPlanillaSolicitada : System.Web.UI.Page
    {
        private int idIns; 
        protected void Page_Load(object sender, EventArgs e)
        {
            ((SKD)Page.Master).IdModulo = "14.1";
            if (!IsPostBack)
            {
                int idSolicitud = Int32.Parse(Request.QueryString[RecursoInterfazModulo14.idSol]);
                this.id_solicitud.Value = idSolicitud.ToString();
                id_solicitud.Visible = false;
                SolicitudP laSolicitud = new SolicitudP();
                LogicaSolicitud lP = new LogicaSolicitud();
                laSolicitud = lP.ObtenerSolicitudID(Int32.Parse(this.id_solicitud.Value));
                this.idFechaI.Value = laSolicitud.FechaRetiro;
                this.idFechaF.Value = laSolicitud.FechaReincorporacion;
                this.id_motivo.Value = laSolicitud.Motivo;
                idIns = laSolicitud.IDInscripcion;

                List<bool> datosRequeridos = lP.DatosRequeridosSolicitud(laSolicitud.ID);
                if (datosRequeridos[0] == true)
                {
                    fechaRetiro.Visible = true;
                }
                else
                {
                    fechaRetiro.Visible = false;
                }
                if (datosRequeridos[1] == true)
                {
                    fechaReincorporacion.Visible = true;
                }
                else
                {
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

        }

        protected void llenarComboEventos()
        {

            LogicaNegociosSKD.Modulo14.LogicaSolicitud lP = new LogicaNegociosSKD.Modulo14.LogicaSolicitud();
            List<SolicitudP> listEventos = lP.EventosSolicitud(Convert.ToInt32(Session[RecursosInterfazMaster.sessionUsuarioID]));
            Dictionary<string, string> options = new Dictionary<string, string>();

            foreach (SolicitudP item in listEventos)
            {

                options.Add(item.ID.ToString(), item.NombreEvento);
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


        protected void boteditar_Click(object sender, EventArgs e)
        {
            LogicaSolicitud lS = new LogicaSolicitud();

            if (comboEvento.Visible == true)
            {
                SolicitudP laSolicitud = new SolicitudP(Int32.Parse(this.id_solicitud.Value), this.idFechaI.Value, this.idFechaF.Value,
                                             this.id_motivo.Value, Int32.Parse(this.comboEvento.SelectedValue));
                lS.ModificarSolicitudID(laSolicitud);
            }
            if (comboCompetencia.Visible == true)
            {
                SolicitudP laSolicitud = new SolicitudP(Int32.Parse(this.id_solicitud.Value), this.idFechaI.Value, this.idFechaF.Value,
                                             this.id_motivo.Value, Int32.Parse(this.comboCompetencia.SelectedValue));
                lS.ModificarSolicitudID(laSolicitud);
            }
            if (comboEvento.Visible == false && comboCompetencia.Visible == false)
            {
                SolicitudP laSolicitud = new SolicitudP(Int32.Parse(this.id_solicitud.Value), this.idFechaI.Value, this.idFechaF.Value,
                                             this.id_motivo.Value, idIns);
                lS.ModificarSolicitudID(laSolicitud);
            }


            Response.Redirect("../Modulo14/M14_ConsultarPlanillasSolicitadas.aspx?success=true");
        }
    }
}