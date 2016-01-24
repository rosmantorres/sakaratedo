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

 
        protected void boteditar_Click(object sender, EventArgs e)
        {
            if (presentador.EditarPlanillaSolicitada() == true)
                Response.Redirect("../Modulo14/M14_ConsultarPlanillasSolicitadas.aspx?success=true");
        }
    }
}