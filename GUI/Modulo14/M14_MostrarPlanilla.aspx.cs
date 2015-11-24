using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace templateApp.GUI.Modulo14
{
    public partial class M14_MostrarPlanilla : System.Web.UI.Page
    {
        private DominioSKD.Planilla planilla1;
        private LogicaNegociosSKD.Modulo14.LogicaDiseño logica = new LogicaNegociosSKD.Modulo14.LogicaDiseño();
        protected void Page_Load(object sender, EventArgs e)
        {
            ((SKD)Page.Master).IdModulo = "14";
            MostrarInformacion();
        }

        public void MostrarInformacion()
        {
            planilla1 = new DominioSKD.Planilla(1,"Retiro", true, "Vacaciones");
            DominioSKD.Diseño diseño = logica.ConsultarDiseño(planilla1);
            this.informacion.Text = Server.HtmlDecode(diseño.Contenido);
        }
    }
}