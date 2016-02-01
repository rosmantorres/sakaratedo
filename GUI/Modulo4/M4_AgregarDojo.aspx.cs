using Interfaz_Contratos.Modulo4;
using Interfaz_Presentadores.Modulo4;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using templateApp.GUI.Master;

namespace templateApp.GUI.Modulo4
{

    public partial class M4_AgregarDojo : System.Web.UI.Page, IContratoAgregarDojo
    {
        PresentadorAgregarDojo _presentador;


        #region Implementacion de Contrato
        /// <summary>
        /// Se implementan todos los metodos que indica el contrato
        /// </summary>
        public string AlertaClase
        {
            set { alert1.Attributes[M4_RecursoInterfaz.alertClase] = value; }
        }
        public string AlertaRol
        {
            set { alert1.Attributes[M4_RecursoInterfaz.alertRole] = value; }
        }
        public string Alerta
        {
            set { alert1.InnerHtml = value; }
        }
        public string Logo
        {
            get
            {
                string log = logoDojos.Text;
                return log;
            }
        }

        public string Rif
        {
            get { return rifDojo.Text; }
        }
        public string Nombre
        {
            get { return nombreDojo.Text; }
        }
        public string Telefono
        {
            get { return numeroDojo.Text; }
        }
        public string Email
        {
            get { return emailDojo.Text; }
        }
        public string Estado
        {
            get { return estadoDojo.Text; }
        }
        public string Ciudad
        {
            get { return ciudadDojo.Text; }
        }
        public string Direccion
        {
            get { return direccionDojo.Text; }
        }
        public bool StatusAct
        {
            get { return statusDojoA.Checked; }
        }
        public bool StatusIn
        {
            get { return statusDojoI.Checked; }
        }
        public int Persona
        {
            get
            {
                int per = int.Parse(Session[RecursosInterfazMaster.sessionUsuarioID].ToString());
                return per;
            }
        }
        #endregion

        #region Constructor
        /// <summary>
        /// Es el constructor de la clase M4_AgregarDojo
        /// </summary>
        public M4_AgregarDojo()
        {
            _presentador = new PresentadorAgregarDojo(this);
        }

        #endregion
        /// <summary>
        /// Metodo para el inicio de la vista
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Page_Load(object sender, EventArgs e)
        {
            ((SKD)Page.Master).IdModulo = "4";
        }

        /// <summary>
        /// El metodo que perite la llamada del presentador para 
        /// agregar el nuevo Dojo
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Btn_agregarDojo_Click(object sender, EventArgs e)
        {
            if (IsValid)
            {
                _presentador.AgregarDojo_Click();
                Response.Redirect("M4_ListarDojos.aspx?success=1");
            }
        }
    }
}