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
        public string logo
        {
            get
            {
                string log = logoDojos.Text;
                return log; 
            }
        }
      
        public string rif
        {
            get { return rifDojo.Text; } 
        }
        public string nombre 
        {
            get { return nombreDojo.Text; }
        }
        public string telefono 
        {
            get { return numeroDojo.Text; }
        }
        public string email
        {
            get { return emailDojo.Text; }
        }
        public string estado 
        {
            get { return estadoDojo.Text; }
        }
        public string ciudad 
        {
            get { return ciudadDojo.Text; }
        }
        public string direccion
        {
            get { return direccionDojo.Text; }
        }
        public bool statusAct
        {
            get { return statusDojoA.Checked; } 
        }
        public bool statusIn
        {
            get { return statusDojoI.Checked; }
        }
        public int persona
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
        protected void btn_agregarDojo_Click(object sender, EventArgs e)
        {
            _presentador.AgregarDojo_Click();
           // Response.Redirect("M4_ListarDojos.aspx?success=1");
        }
    }
}