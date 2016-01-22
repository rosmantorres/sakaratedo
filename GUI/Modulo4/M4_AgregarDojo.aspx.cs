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

        public string logo
        {
            get
            {
                string log = logoDojo.Text;
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
        //string latitud { get; }
        //string longitud { get; }
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

        public M4_AgregarDojo()
		{
			_presentador = new PresentadorAgregarDojo(this);
		}

		#endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            ((SKD)Page.Master).IdModulo = "4";
        }

        protected void btn_agregarDojo_Click(object sender, EventArgs e)
        {
            _presentador.agregarDojo_Click();
           // Response.Redirect("M4_ListarDojos.aspx?success=1");
        }
    }
}