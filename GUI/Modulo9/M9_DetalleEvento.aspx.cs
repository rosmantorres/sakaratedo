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

namespace templateApp.GUI.Modulo9
{
    public partial class M9_DetalleEvento : System.Web.UI.Page, IContratoDetalleEvento
    {
        private PresentadorDetalleEvento presentador;
        public M9_DetalleEvento()
        {
            presentador = new PresentadorDetalleEvento(this);
        }


        protected void Page_Load(object sender, EventArgs e)
        {
            ((SKD)Page.Master).IdModulo = M9_RecursoInterfaz.idModulo;

            presentador.ObtenerVariableURL();
        }

        #region Contrato


        string IContratoDetalleEvento.iNombreEvento
        {
            set { nombreEvento.Text = value; }
        }
        string IContratoDetalleEvento.iTipoEvento
        {
            set { tipoEvento.Text = value; }
        }
        string IContratoDetalleEvento.iCostoEvento
        {
            set { costoEvento.Text = value ; }
        }
        string IContratoDetalleEvento.iFechaInicio
        {
            set { fechaInicio.Text = value; }
        }
        string IContratoDetalleEvento.iFechaFin
        {
            set {  fechaFin.Text = value; }
        }
        string IContratoDetalleEvento.iHoraInicio
        {
            set {  horaInicio.Text = value; }
        }
        string IContratoDetalleEvento.iHoraFin
        {
            set { horaFin.Text = value; }
        }
        string IContratoDetalleEvento.iDescripcionEvento
        {
            set {  descripcionEvento.Text = value; }
        }
        string IContratoDetalleEvento.iStatusEvento
        {
            set {  statusEvento.Text = value; }
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