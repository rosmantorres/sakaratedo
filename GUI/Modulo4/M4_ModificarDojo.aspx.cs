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
    public partial class M4_ModificarDojo : System.Web.UI.Page, IContratoModificarDojo
    {
        PresentadorModificarDojo _presentador;
        int idDojom;

       #region Implementacion de Contrato
        /// <summary>
        /// Se implementan todos los metodos que indica el contrato
        /// </summary>
        public int idDojo 
        {
            get { return idDojom; }
            set { idDojom = value; } 
        }
        public string imglogo 
        {
            set { logDojo.ImageUrl = value; }
        }
        public string logo
        {
            get
            {
                string log = logDojos.Text;
                return log; 
            }
            set { logDojos.Text = value; }

        }
      
        public string rif
        {
            get { return rifDojo.Text; }
            set { rifDojo.Text = value; }
        }

        public string nombre 
        {
            get { return nombreDojo.Text; }
            set { nombreDojo.Text = value; }
        }

        public string telefono 
        {
            get { return numeroDojo.Text; }
            set { numeroDojo.Text = value; }
        }

        public string email
        {
            get { return emailDojo.Text; }
            set { emailDojo.Text = value; }
        }

        public string estado 
        {
            get { return estadoDojo.Text; }
            set { estadoDojo.Text = value; }

        }

        public string ciudad 
        {
            get { return ciudadDojo.Text; }
            set { ciudadDojo.Text = value; }
        }

        public string direccion
        {
            get { return direccionDojo.Text; }
            set { direccionDojo.Text = value; }
        }

        public bool statusAct
        {
            get { return statusDojoA.Checked; }
            set { statusDojoA.Checked = value; }
        }

        public bool statusIn
        {
            get { return statusDojoI.Checked; }
            set { statusDojoI.Checked = value; }
        }

        #endregion

       #region Constructor
        /// <summary>
        /// Es el constructor de la clase M4_AgregarDojo
        /// </summary>
        public M4_ModificarDojo()
		{
			_presentador = new PresentadorModificarDojo(this);
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
            this.idDojom = int.Parse(Request.QueryString["dojoMod"]);

            if (!IsPostBack)
            {
                if ((Request.QueryString["dojoMod"] != null) || (int.Parse(Request.QueryString["dojoMod"]) > 0))
                {
                    _presentador.MostrarDojo();
                }
            }
        }




        
        
        
        
        
        /// <summary>
        /// El metodo que perite la llamada del presentador para 
        /// modificar el Dojo
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Btn_ModificarDojo_Click(object sender, EventArgs e)
        {
           bool opc = _presentador.ModificarDojo_Click();
            if (opc)
                Response.Redirect("M4_ListarDojos.aspx?success=3");
            else
                Response.Redirect("M4_ListarDojos.aspx?success=4");
        }


    }
}