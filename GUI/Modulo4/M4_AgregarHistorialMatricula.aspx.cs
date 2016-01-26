using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using templateApp.GUI.Master;

namespace templateApp.GUI.Modulo4
{
    public partial class M4_AgregarHistorialMatricula : System.Web.UI.Page
    {

        private DominioSKD.Dojo elDojoHM = new DominioSKD.Dojo();
        private DominioSKD.Historial_Matricula elHistMat = new DominioSKD.Historial_Matricula();


        protected void Page_Load(object sender, EventArgs e)
        {
            ((SKD)Page.Master).IdModulo = "4";

            String RolPersona = (Session[RecursosInterfazMaster.sessionRol].ToString());

        }

        protected void btn_agregarHistorialMatricula_Click (object sender, EventArgs e)
        {
            try
            {
             
                elHistMat.Fecha_historial_matricula = DateTime.Parse(dateHM.Text);
                elHistMat.Modalidad_historial_matricula = modalidadHM.Value;
                elHistMat.Monto_historial_matricula = float.Parse(cmatriHM.Text);
             
                laLogicaHM.agregarHistorialMatricula(elHistMat, elDojoHM);
                
                //Response.Redirect("M4_ListarHistorialMatricula.aspx?success=1");

            }
            catch
            {

            }
        }
    }
}