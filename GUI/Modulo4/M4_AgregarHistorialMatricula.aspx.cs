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

        private LogicaNegociosSKD.Modulo4.LogicaHistorial_Matricula laLogicaHM = new LogicaNegociosSKD.Modulo4.LogicaHistorial_Matricula();

        protected void Page_Load(object sender, EventArgs e)
        {
            ((SKD)Page.Master).IdModulo = "4";

            String RolPersona = (Session[RecursosInterfazMaster.sessionRol].ToString());

            if (String.Compare(RolPersona, "Sistema") == 0)
            {
                this.comboOrganizacion.Text += M4_RecursoInterfaz.comboOrganizacionInicio;
                //ciclo
                this.comboOrganizacion.Text += M4_RecursoInterfaz.AbrirOpcion + "valor" + M4_RecursoInterfaz.CentroOpcion + "nombre" + M4_RecursoInterfaz.CierreOpcion;
                //fin del ciclo
                this.comboOrganizacion.Text += M4_RecursoInterfaz.comboCerrar;
            }
            else
                if (String.Compare(RolPersona, "Organización") == 0)
                {
                    this.comboDojo.Text += M4_RecursoInterfaz.comboDojoInicio;
                    //ciclo
                    this.comboDojo.Text += M4_RecursoInterfaz.AbrirOpcion + "valor" + M4_RecursoInterfaz.CentroOpcion + "nombre" + M4_RecursoInterfaz.CierreOpcion;
                    //fin del ciclo
                    this.comboDojo.Text += M4_RecursoInterfaz.comboCerrar;
                }

        }

        protected void btn_agregarHistorialMatricula_Click (object sender, EventArgs e)
        {
            try
            {
                int idDojo;
                String RolPersona = (Session[RecursosInterfazMaster.sessionRol].ToString());

                if (String.Compare(RolPersona, "Sistema") == 0 || String.Compare(RolPersona, "Organización") == 0)
                {
                    //id del select dojo
                }
                else
                    if (String.Compare(RolPersona, "Dojo") == 0)
                    {
                       //Busco id del dojo del administrador
                    }

                elHistMat.Fecha_historial_matricula = DateTime.Parse(dateHM.Text);
                elHistMat.Modalidad_historial_matricula = modalidadHM.Value;
                elHistMat.Monto_historial_matricula = float.Parse(cmatriHM.Text);
                
                //elDojo.Rif_dojo = rifDojo.Text;

                laLogicaHM.agregarHistorialMatricula(elHistMat, elDojoHM);
                
                //Response.Redirect("M4_ListarHistorialMatricula.aspx?success=1");

            }
            catch
            {

            }
        }
    }
}