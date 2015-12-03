using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DominioSKD;
using LogicaNegociosSKD;
using LogicaNegociosSKD.Modulo4;
using templateApp.GUI.Master;


namespace templateApp.GUI.Modulo4
{
    public partial class M4_AgregarHistorialMatricula : System.Web.UI.Page
    {

        private DominioSKD.Dojo elDojoHM = new DominioSKD.Dojo();
        private DominioSKD.Historial_Matricula elHistMat = new DominioSKD.Historial_Matricula();

        private LogicaNegociosSKD.Modulo4.LogicaHistorial_Matricula laLogicaHM = new LogicaNegociosSKD.Modulo4.LogicaHistorial_Matricula();
        private LogicaNegociosSKD.Modulo4.LogicaDojo laLogicaDojoHM = new LogicaNegociosSKD.Modulo4.LogicaDojo();

      
        

                
        protected void btn_agregarHistorialMatricula_Click (object sender, EventArgs e)
        {
            
            try
            {
                
                String RolPersona = (Session[RecursosInterfazMaster.sessionRol].ToString());
                int idPersona = int.Parse(Session[RecursosInterfazMaster.sessionUsuarioID].ToString());

                
                    elHistMat.DojoId_historial_matricula = laLogicaDojoHM.obtenerIdDojo(idPersona);
               

                elHistMat.Fecha_historial_matricula = DateTime.Parse(dateHM.Text);
                elHistMat.Modalidad_historial_matricula = modalidadHM.Value;
                elHistMat.Monto_historial_matricula = float.Parse(cmatriHM.Text);

                laLogicaHM.agregarHistorialMatricula(elHistMat, elDojoHM);
                
                Response.Redirect("M4_ListarHistorialMatricula.aspx?success=1");

            }
            catch
            {

            }
        }
    }
}