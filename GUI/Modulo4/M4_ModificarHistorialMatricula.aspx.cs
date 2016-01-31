using ExcepcionesSKD;
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
    public partial class M4_ModificarHistorialMatricula : System.Web.UI.Page, IContratoModificarHistorialM
    {
        PresentadorModificarHistorialM _presentador;
        int idHistm;

        #region Implementacion de Contrato
        /// <summary>
        /// Se implementan todos los metodos que indica el contrato
        /// </summary>
        public string Fecha { get { return dateHM.Text; } set { dateHM.Text = value; } }
        public string Modalidad { get { return modalidadHM.Text; } set { modalidadHM.Text = value; } }
        public string Monto { get { return cmatriHM.Text; } set { cmatriHM.Text = value; } }
        public int Persona { get { return int.Parse(Session[RecursosInterfazMaster.sessionUsuarioID].ToString()); } }
        public int IdHistM { get { return idHistm; } set { idHistm = value; } }

        #endregion

        #region Constructor
        /// <summary>
        /// Es el constructor de la clase M4_ModificarHistorialMatricula
        /// </summary>
        public M4_ModificarHistorialMatricula()
        {
            _presentador = new PresentadorModificarHistorialM(this);
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
            this.idHistm = int.Parse(Request.QueryString["matriculaMod"]);

            if (!IsPostBack)
            {
                if ((Request.QueryString["matriculaMod"] != null) || (int.Parse(Request.QueryString["matriculaMod"]) > 0))
                {
                    _presentador.MostrarHistorialM();
                }
            }
        }

        /// <summary>
        /// El metodo que perite la llamada del presentador para 
        /// modificar el Dojo
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Btn_ModificarHistorialM_Click(object sender, EventArgs e)
        {
            try
            {
                _presentador.ModificarHistorialMClick();
                Response.Redirect("M4_ListarHistorialMatricula.aspx?success=3");
            }
            catch (ExcepcionesSKD.ExceptionSKD ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                Response.Redirect("M4_ListarHistorialMatricula.aspx?success=4");
            }
        }
    }
}