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
    public partial class M4_AgregarHistorialMatricula : System.Web.UI.Page, IContratoAgregarHistorialM
    {
        PresentadorAgregarHistorialM _presentador;


        #region Implementacion de Contrato
        /// <summary>
        /// Se implementan todos los metodos que indica el contrato
        /// </summary>
        public string Fecha { get { return dateHM.Text; } }
        public string Modalidad { get { return modalidadHM.Text; } }
        public string Monto { get { return cmatriHM.Text; } }
        public int Persona { get { return int.Parse(Session[RecursosInterfazMaster.sessionUsuarioID].ToString()); } }
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
        #endregion

         #region Constructor
        /// <summary>
        /// Es el constructor de la clase M4_AgregarHistorialMatricula
        /// </summary>
        public M4_AgregarHistorialMatricula()
        {
            _presentador = new PresentadorAgregarHistorialM(this);
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
        /// agregar el nuevo Historial Matricula
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Btn_agregarHistorialM_Click(object sender, EventArgs e)
        {
            if (IsValid)
            {
                _presentador.AgregarHistorialM_Click();
                Response.Redirect("M4_ListarHistorialMatricula.aspx?success=1");
            }

        }
    }
}