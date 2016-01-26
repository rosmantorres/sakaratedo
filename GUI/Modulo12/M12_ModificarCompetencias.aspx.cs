using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DominioSKD;
using System.Text.RegularExpressions;
using System.Globalization;
using Interfaz_Contratos.Modulo12;
using Interfaz_Presentadores.Modulo12;

namespace templateApp.GUI.Modulo12
{
    public partial class M12_ModificarCompetencias : System.Web.UI.Page, IContratoModificarCompetencias
    {
        public  string laLatitud;
        public  string laLongitud;

        private PresentadorModificarCompetencias presentador;

        public M12_ModificarCompetencias()
        {
            presentador = new PresentadorModificarCompetencias(this);
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            ((SKD)Page.Master).IdModulo = M12_RecursoInterfaz.idModuloModificar;
            
            if (!IsPostBack)
            {
                presentador.ObtenerVariablesURL();

            }
        }

        #region void

        protected void comboCintaDesde_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void comboCintaHasta_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void comboSexo_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void comboOrgs_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        #endregion 

        protected void btn_modificarComp_Click_Click(object sender, EventArgs e)
        {
            presentador.ModificarCompetencia();
        }

        #region Contrato
        string IContratoModificarCompetencias.nombreComp
        {
            get { return nombreComp.Text; }
            set { nombreComp.Text = value; }
        }

        string IContratoModificarCompetencias.tipoCompKumite
        {
            get { return input_tipo_kumite.Text; }
            set { input_tipo_kumite.Text = value; }
        }

        bool IContratoModificarCompetencias.tipoCompKumiteBool
        {
            get { return input_tipo_kumite.Checked; }
            set { input_tipo_kumite.Checked = value; }
        }

        string IContratoModificarCompetencias.tipoCompKata
        {
            get { return input_tipo_kata.Text; }
            set { input_tipo_kata.Text = value; }
        }

        bool IContratoModificarCompetencias.tipoCompKataBool
        {
            get { return input_tipo_kata.Checked; }
            set { input_tipo_kata.Checked = value; }
        }

        string IContratoModificarCompetencias.tipoCompAmbos
        {
            get { return input_tipo_ambos.Text; }
            set { input_tipo_ambos.Text = value; }
        }

        bool IContratoModificarCompetencias.tipoCompAmbosBool
        {
            get { return input_tipo_ambos.Checked; }
            set { input_tipo_ambos.Checked = value; }
        }

        bool IContratoModificarCompetencias.orgCompBool
        {
            get { return organizaciones.Checked; }
            set { organizaciones.Checked = value; }
        }

        DropDownList IContratoModificarCompetencias.organizacionComp
        {
            get
            {
                return comboOrgs;
            }
            set
            {
                comboOrgs = value;
            }
        }

        string IContratoModificarCompetencias.statusIniciarComp
        {
            get { return input_status_porIniciar.Text; }
            set { input_status_porIniciar.Text = value; }
        }

        bool IContratoModificarCompetencias.statusIniciarCompBool
        {
            get { return input_status_porIniciar.Checked; }
            set { input_status_porIniciar.Checked = value; }
        }

        string IContratoModificarCompetencias.statusEnCursoComp
        {
            get { return input_status_enCurso.Text; }
            set { input_status_enCurso.Text = value; }
        }

        bool IContratoModificarCompetencias.statusEnCursoCompBool
        {
            get { return input_status_enCurso.Checked; }
            set { input_status_enCurso.Checked = value; }
        }

        string IContratoModificarCompetencias.statusFinalizadoComp
        {
            get { return input_status_Finalizado.Text; }
            set { input_status_Finalizado.Text = value; }
        }

        bool IContratoModificarCompetencias.statusFinalizadoCompBool 
        {
            get { return input_status_Finalizado.Checked; }
            set { input_status_Finalizado.Checked = value; }
        }

        string IContratoModificarCompetencias.costoComp
        {
            get { return costoComp.Text; }
            set { costoComp.Text = value; }
        }

        string IContratoModificarCompetencias.inicioComp
        {
            get { return fechaIni.Value; }
            set { fechaIni.Value = value; }
        }

        string IContratoModificarCompetencias.finComp
        {
            get { return fechaFin.Value; }
            set { fechaFin.Value = value; }
        }

        string IContratoModificarCompetencias.latitudComp
        {
            get { return txtLAT.Value; }
            set { txtLAT.Value = value;
            laLatitud = value;
            }
        }

        string IContratoModificarCompetencias.longitudComp
        {
            get { return txtLONG.Value; }
            set { txtLONG.Value = value;
            laLongitud = value;
            }
        }

        DropDownList IContratoModificarCompetencias.categIniComp
        {
            get
            {
                return comboCintaDesde;
            }
            set
            {
                comboCintaDesde = value;
            }
        }

        DropDownList IContratoModificarCompetencias.categFinComp
        {
            get
            {
                return comboCintaHasta;
            }
            set
            {
                comboCintaHasta = value;
            }
        }

        string IContratoModificarCompetencias.edadIniComp
        {
            get { return edad_desde.Text; }
            set { edad_desde.Text = value; }
        }

        string IContratoModificarCompetencias.edadFinComp
        {
            get { return edad_hasta.Text; }
            set { edad_hasta.Text = value; }
        }

        string IContratoModificarCompetencias.categSexoMComp
        {
            get { return input_sexo_M.Text; }
            set { input_sexo_M.Text = value; }
        }

        bool IContratoModificarCompetencias.categSexoMCompBool
        {
            get { return input_sexo_M.Checked; }
            set { input_sexo_M.Checked = value; }
        }

        string IContratoModificarCompetencias.cateSexoFComp
        {
            get { return input_sexo_F.Text; }
            set { input_sexo_F.Text = value; }
        }

        bool IContratoModificarCompetencias.cateSexoFCompBool
        {
            get { return input_sexo_F.Checked; }
            set { input_sexo_F.Checked = value; }
        }

        public string alertaClase
        {
            set { alert.Attributes[M12_RecursoInterfaz.alertClase] = value; }
        }

        public string alertaRol
        {
            set { alert.Attributes[M12_RecursoInterfaz.alertRole] = value; }
        }

        public string alerta
        {
            set { alert.InnerHtml = value; }
        }
        #endregion
    }
}