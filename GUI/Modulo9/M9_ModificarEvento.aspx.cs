using DominioSKD;
using System;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DominioSKD;
using LogicaNegociosSKD;
using Interfaz_Contratos.Modulo9;
using Interfaz_Presentadores.Modulo9;
using templateApp.GUI.Master;

namespace templateApp.GUI.Modulo9
{
    public partial class M9_ModificarEvento : System.Web.UI.Page, IContratoModificarEvento
    {  
        private PresentadorModificarEvento presentador;
        public M9_ModificarEvento()
        {
            presentador = new PresentadorModificarEvento(this);
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            ((SKD)Page.Master).IdModulo = M9_RecursoInterfaz.idModulo;

            presentador.ObtenerVariablesURL();

            #region LLENAR COMBO TIPOEVENTO
            if (!IsPostBack)
            {

                presentador.LlenarCombos();
            }
            #endregion
        }
        #region void
        protected void btn_agregarEventoClick(object sender, EventArgs e)
        {
            presentador.ModificarEvento();

        }

        protected void comboTipoEvento_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        #endregion
        #region Contrato
        DropDownList IContratoModificarEvento.iComboTipoEvento
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
        string IContratoModificarEvento.iNombreEvento
        {
            get { return nombreEvento.Text; }
            set { nombreEvento.Text = value; }
        }
        string IContratoModificarEvento.iCostoEvento
        {
            get { return costoEvento.Text; }
            set { costoEvento.Text = value; }
        }
        string IContratoModificarEvento.iFechaInicio
        {

            get { return fechaIniValue.Value; }
            set { fechaInicio.Value = value; }
        }
        string IContratoModificarEvento.iFechaFin
        {
            get { return fechaFinValue.Value; }
            set { fechaFin.Value = value; }
            
        }
        string IContratoModificarEvento.iHoraInicio
        {
            get { return horaInicio.Text; }
            set { horaInicio.Text = value; }

        }
        string IContratoModificarEvento.iHoraFin
        {
            get { return horaFin.Text; }
            set { horaFin.Text = value; }
        }
        string IContratoModificarEvento.iDescripcionEvento
        {
            get { return descripcionEvento.Text; }
            set { descripcionEvento.Text = value; }
        }
        bool IContratoModificarEvento.iStatusActivoBool
        {
            get { return inputEstadoActivo.Checked; }
            set { inputEstadoActivo.Checked = value; }
        }
        bool IContratoModificarEvento.iStatusInactivoBool
        {
            get { return inputEstadoInactivo.Checked; }
            set { inputEstadoInactivo.Checked = value; }
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