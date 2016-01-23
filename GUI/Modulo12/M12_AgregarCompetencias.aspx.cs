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
    public partial class M12_AgregarCompetencias : System.Web.UI.Page, IContratoAgregarCompetencias
    {
        //private DominioSKD.Competencia laCompetencia = new DominioSKD.Competencia();
        //private LogicaNegociosSKD.Modulo12.LogicaCompetencias laLogica = new LogicaNegociosSKD.Modulo12.LogicaCompetencias();
        //private List<Organizacion> listaOrg = new List<Organizacion>();
        //private List<Cinta> listaCintaDesde = new List<Cinta>();
        //private List<Cinta> listaCintaHasta = new List<Cinta>();

        private PresentadorAgregarCompetencia presentador;

        public M12_AgregarCompetencias()
        {
            presentador = new PresentadorAgregarCompetencia(this);
        }


        protected void Page_Load(object sender, EventArgs e)
        {
            ((SKD)Page.Master).IdModulo = M12_RecursoInterfaz.idModulo;

            presentador.ObtenerVariablesURL();

            #region LLENAR COMBO ORGANIZACIONES DE COMPETENCIA Y COMBOS CINTA
            if (!IsPostBack)
            {
                presentador.LlenarCombos();
            }
            #endregion

        }

        protected void btn_agregarComp_Click(object sender, EventArgs e)
        {

            presentador.AgregarCompetencia();
        }


        #region void
        protected void comboSexo_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void comboOrgs_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void comboCintaHasta_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        #endregion
        #region Contrato
        string IContratoAgregarCompetencias.nombreComp
        {
            get { return nombreComp.Text; }
        }

        string IContratoAgregarCompetencias.tipoCompKumite
        {
            get { return input_tipo_kumite.Text; }
        }

        bool IContratoAgregarCompetencias.tipoCompKumiteBool
        {
            get { return input_tipo_kumite.Checked; }
        }

        string IContratoAgregarCompetencias.tipoCompKata
        {
            get { return input_tipo_kata.Text; }
        }

        bool IContratoAgregarCompetencias.tipoCompKataBool
        {
            get { return input_tipo_kata.Checked; }
        }

        string IContratoAgregarCompetencias.tipoCompAmbos
        {
            get { return input_tipo_ambos.Text; }
        }

        bool IContratoAgregarCompetencias.tipoCompAmbosBool
        {
            get { return input_tipo_ambos.Checked; }
        }

        bool IContratoAgregarCompetencias.orgCompBool
        {
            get { return organizaciones.Checked; }
        }

        DropDownList IContratoAgregarCompetencias.organizacionComp
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

        string IContratoAgregarCompetencias.statusIniciarComp
        {
            get { return input_status_porIniciar.Text; }
        }

        bool IContratoAgregarCompetencias.statusIniciarCompBool
        {
            get { return input_status_porIniciar.Checked; }
        }

        string IContratoAgregarCompetencias.statusEnCursoComp
        {
            get { return input_status_enCurso.Text; }
        }

        bool IContratoAgregarCompetencias.statusEnCursoCompBool
        {
            get { return input_status_enCurso.Checked; }
        }

        string IContratoAgregarCompetencias.costoComp
        {
            get { return costoComp.Text; }
        }

        string IContratoAgregarCompetencias.inicioComp
        {
            get { return fechaIni.Value; }
        }

        string IContratoAgregarCompetencias.finComp
        {
            get { return fechaFin.Value; }
        }

        string IContratoAgregarCompetencias.latitudComp
        {
            get { return txtLAT.Value; }
        }

        string IContratoAgregarCompetencias.longitudComp
        {
            get { return txtLONG.Value; }
        }

        DropDownList IContratoAgregarCompetencias.categIniComp
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

        DropDownList IContratoAgregarCompetencias.categFinComp
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

        string IContratoAgregarCompetencias.edadIniComp
        {
            get { return edad_desde.Text; }
        }

        string IContratoAgregarCompetencias.edadFinComp
        {
            get { return edad_hasta.Text; }
        }

        string IContratoAgregarCompetencias.categSexoMComp
        {
            get { return input_sexo_M.Text; }
        }

        bool IContratoAgregarCompetencias.categSexoMCompBool
        {
            get { return input_sexo_M.Checked; }
        }

        string IContratoAgregarCompetencias.cateSexoFComp
        {
            get { return input_sexo_F.Text; }
        }

        bool IContratoAgregarCompetencias.cateSexoFCompBool
        {
            get { return input_sexo_F.Checked; }
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