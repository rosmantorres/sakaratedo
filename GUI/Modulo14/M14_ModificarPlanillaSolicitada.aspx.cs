using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using LogicaNegociosSKD;
using LogicaNegociosSKD.Modulo14;
using DominioSKD;
using templateApp.GUI.Master;
using Interfaz_Contratos.Modulo14;
using Interfaz_Presentadores.Modulo14;


namespace templateApp.GUI.Modulo14
{
    public partial class ModificarPlanillaSolicitada : System.Web.UI.Page, IContratoM14ModificarPlanillaSolicitada
    {
        public int idIns; 
         private PresentadorM14ModificarPlanillaSolicitada presentador;

         public ModificarPlanillaSolicitada()
            {
                presentador = new PresentadorM14ModificarPlanillaSolicitada(this);
            }
        protected void Page_Load(object sender, EventArgs e)
        {
           ((SKD)Page.Master).IdModulo = "14.1";
            if (!IsPostBack)
            {
                presentador.PageLoadModificarPlanillaSolicitada();
               /* int idSolicitud = Int32.Parse(Request.QueryString[RecursoInterfazModulo14.idSol]);
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
                }*/

            }

        }


        #region contratos
        public int IDInscripcion
        {
            get
            {
                return this.idIns;
            }
            set
            {
                this.idIns = value;
            }
        }
        public String solicitudId
        {
            get
            {
                return this.id_solicitud.Value;
            }
            set
            {
                this.id_solicitud.Value = value;
            }
        }
        public String FechaRetiro
        {
            get
            {
                return this.idFechaI.Value;
            }
            set
            {
                this.idFechaI.Value = value;
            }
        }
        public String FechaReincorporacion
        {
            get
            {
                return this.idFechaF.Value;
            }
            set
            {
                this.idFechaF.Value = value;
            }
        }
        public DropDownList EventoCombo
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
        public DropDownList CompetenciaCombo
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
            set
            {
                this.id_motivo.Value = value;
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
                return this.comboEvento.Visible;
            }
            set
            {
                this.comboEvento.Visible = value;
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
        public int IDSolicitud
        {
            get
            {
                return Int32.Parse(Request.QueryString[RecursoInterfazModulo14.idSol]);
            }
            set
            {
                Int32.Parse(Request.QueryString[RecursoInterfazModulo14.idSol]);
            }
        }
        public bool IDSolicitudVisible
        {
            get
            {
                return this.id_solicitud.Visible;
            }
            set
            {
                this.id_solicitud.Visible= value;
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
                return this.divComboCompetencia.Visible;
            }
            set
            {
                this.divComboCompetencia.Visible = value;
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

   /*     protected void llenarComboEventos()
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

        }*/

   /*     protected void llenarComboCompetencia()
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


        protected void boteditar_Click(object sender, EventArgs e)
        {
            /*LogicaSolicitud lS = new LogicaSolicitud();

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
            }*/

            if (presentador.EditarPlanillaSolicitada() == true)
                Response.Redirect("../Modulo14/M14_ConsultarPlanillasSolicitadas.aspx?success=true");
        }
    }
}