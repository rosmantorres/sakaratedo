using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DominioSKD;
using System.Text.RegularExpressions;
using System.Globalization;
using Interfaz_Contratos.Modulo9;
using Interfaz_Presentadores.Modulo9;
using templateApp.GUI.Master;

namespace templateApp.GUI.Modulo9
{
    public partial class prueba : System.Web.UI.Page, IContratoAgregarEvento
    {
        private PresentadorAgregarEvento presentador;
        public prueba()
        {
            presentador = new PresentadorAgregarEvento(this);
            
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            ((SKD)Page.Master).IdModulo = M9_RecursoInterfaz.idModulo;

            presentador.ObtenerVariablesURL();

            #region LLENAR COMBO TIPOEVENTO
            if (!IsPostBack)
            {
                otroEvento.Visible = false;
                presentador.LlenarCombos();
            }
            #endregion
        }
        protected void btn_agregarEventoClick(object sender, EventArgs e)
        {
            presentador.AgregarEvento(Session[RecursosInterfazMaster.sessionUsuarioID].ToString());
        }
        #region void
        protected void comboTipoEvento_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        #endregion
        #region Contrato
        DropDownList IContratoAgregarEvento.iComboTipoEvento
        {
            get
            {
                return comboTipoEvento;
            }
            set
            {
                comboTipoEvento = value;
            }
        }
        string IContratoAgregarEvento.iNombreEvento
        {
            get { return nombreEvento.Text; }
        }
        string IContratoAgregarEvento.iOtroEvento
        {
            get { return otroEvento.Text; }
        }
        string IContratoAgregarEvento.iCostoEvento
        {
            get { return costoEvento.Text; }
        }
        string IContratoAgregarEvento.iFechaInicio
        {
            get { return fechaIniValue.Value; }
        }
        string IContratoAgregarEvento.iFechaFin
        {
            get { return fechaFinValue.Value; }
        }
        string IContratoAgregarEvento.iHoraInicio
        {
            get { return horaInicio.Text; }
        }
        string IContratoAgregarEvento.iHoraFin
        {
            get { return horaFin.Text; }
        }
        string IContratoAgregarEvento.iDescripcionEvento
        {
            get { return descripcionEvento.Text; }
        }

        string IContratoAgregarEvento.iStatusActivo
        {
            get { return inputEstadoActivo.Text; }
        }

        bool IContratoAgregarEvento.iStatusActivoBool
        {
            get { return inputEstadoActivo.Checked; }
        }
        string IContratoAgregarEvento.iStatusInactivo
        {
            get { return inputEstadoInactivo.Text; }
        }

        bool IContratoAgregarEvento.iStatusInactivoBool
        {
            get { return inputEstadoInactivo.Checked; }
        }
        public string alertaClase
        {
            set { alert.Attributes[M9_RecursoInterfaz.alertClase] = value; }
        }

        public string alertaRol
        {
            set { alert.Attributes[M9_RecursoInterfaz.alertRole] = value; }
        }

        public string alerta
        {
            set { alert.InnerHtml = value; }
        }







        #endregion




    }
}