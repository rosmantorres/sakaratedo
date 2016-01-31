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
    public partial class M4_ListarHistorialMatricula : System.Web.UI.Page, IContratoListarHistorialM
    {

        PresentadorListarHistorialM _presentador;
        private string success;
        private string eliminarString;

        #region Implementacion de Contrato
        public string Success
        {
            get { return success; }
            set { success = value; }
        }
        
        public string EliminarString
        {
            get { return eliminarString; }
            set { eliminarString = value; }
        }
        public string Cabecera
        {
            get { return sta.Text; }
            set { sta.Text = value; }
        }
        public string LaTabla
        {
            get { return laTabla.Text; }
            set { laTabla.Text = value; }
        }
        public string AlertaClase
        {
            set { alert.Attributes[M4_RecursoInterfaz.alertClase] = value; }
        }
        public string AlertaRol
        {
            set { alert.Attributes[M4_RecursoInterfaz.alertRole] = value; }
        }
        public string Alerta
        {
            set { alert.InnerHtml = value; }
        }
        #endregion

        #region Constructor
        /// <summary>
        /// Es el constructor de la clase M4_ListarHistorialMatricula
        /// </summary>
        public M4_ListarHistorialMatricula()
        {
            _presentador = new PresentadorListarHistorialM(this);
        }

        #endregion
        protected void Page_Load(object sender, EventArgs e)
        {
            ((SKD)Page.Master).IdModulo = "4";

            this.Success = Request.QueryString["success"];
            this.EliminarString = Request.QueryString["matriculaEliminar"];
            string RolPersona = (Session[RecursosInterfazMaster.sessionRol].ToString());
            int idlog = int.Parse(Session[RecursosInterfazMaster.sessionUsuarioID].ToString());

            if (EliminarString != null)
            {
                EliminarMatricula(eliminarString);
            }

            _presentador.ListarHistorialM(RolPersona, idlog);
        }

        protected void EliminarMatricula(String matriculaEliminar)
        {
            int idHistM= int.Parse(matriculaEliminar);
            try
            {
                _presentador.EliminarMatricula(idHistM);
                Response.Redirect("M4_ListarHistorialMatricula.aspx?success=2");

            }
            catch (Exception ex)
            {
                throw ex;//agregar alerta de conexion a la base de datos
            }

        }
    }
}