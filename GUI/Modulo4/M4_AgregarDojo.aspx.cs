using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace templateApp.GUI.Modulo4
{
    public partial class M4_AgregarDojo : System.Web.UI.Page
    {

        private DominioSKD.Dojo elDojo = new DominioSKD.Dojo();
        private DominioSKD.Historial_Matricula elHistorial = new DominioSKD.Historial_Matricula();
        private DominioSKD.Ubicacion laUbicacion = new DominioSKD.Ubicacion();

        private LogicaNegociosSKD.Modulo4.LogicaDojo laLogica = new LogicaNegociosSKD.Modulo4.LogicaDojo();

        protected void Page_Load(object sender, EventArgs e)
        {
            ((SKD)Page.Master).IdModulo = "4";
        }

        protected void btn_agregarDojo_Click(object sender, EventArgs e)
        {
            Random r = new Random();
            string lat = (r.Next(0, 180000) / 1000).ToString();
            string lon = (r.Next(-180000, 0) / 1000).ToString();

            try
            {
                elDojo.Logo_dojo = logoDojo.Text;
                elDojo.Rif_dojo = rifDojo.Text;
                elDojo.Nombre_dojo = nombreDojo.Text;
                elDojo.Telefono_dojo = int.Parse(numeroDojo.Text);
                elDojo.Email_dojo = emailDojo.Text;
                // laUbicacion.Latitud = txtLAT.Value.ToString();
                //  laUbicacion.Longitud = txtLONG.Value.ToString();
                laUbicacion.Latitud = lat;
                laUbicacion.Longitud = lon;
                laUbicacion.Ciudad = ciudad.Value;
                laUbicacion.Estado = estado.Value;
                laUbicacion.Direccion = direccionDojo.Text;

                if (statusDojoA.Checked)
                    elDojo.Status_dojo = "true";
                if (statusDojoI.Checked)
                    elDojo.Status_dojo = "false";

                elDojo.Registro_dojo = DateTime.Parse(dateDojo.Text);

                elHistorial.Modalidad_historial_matricula = modalidad.Value;

                elHistorial.Monto_historial_matricula = float.Parse(cmatriDojo.Text);



                laLogica.agregarDojo(elDojo, elHistorial, laUbicacion);

                Response.Redirect("M4_ListarDojos.aspx?success=1");

            }
            catch
            {

            }
        }
    }
}