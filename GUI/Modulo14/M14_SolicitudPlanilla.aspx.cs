using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace templateApp.GUI.Modulo14
{
    public partial class SolicitudPlanilla : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ((SKD)Page.Master).IdModulo = "14";
        }

        protected void botaceptar_Click(object sender, EventArgs e)
        {
            if (id_fechai.Value == "")
            {
                this.alertlocal.Attributes["class"] = "alert alert-danger";
                this.alertlocal.Attributes["role"] = "alert";
                this.alertlocal.InnerHtml = "<div><button type=\"button\" class=\"close\" data-dismiss=\"alert\" aria-label=\"Close\"><span aria-hidden=\"true\">&times;</span></button>No has seleccionado la fecha de retiro.</div>";
                this.alertlocal.Visible = true;
            }

            if (Id_fechaf.Value == "")
            {
                this.alertlocal.Attributes["class"] = "alert alert-danger";
                this.alertlocal.Attributes["role"] = "alert";
                this.alertlocal.InnerHtml = "<div><button type=\"button\" class=\"close\" data-dismiss=\"alert\" aria-label=\"Close\"><span aria-hidden=\"true\">&times;</span></button>No has seleccionado la fecha reincorporacion.</div>";
                this.alertlocal.Visible = true;
            }
            if (TextBox1.Text == "")
            {
                this.alertlocal.Attributes["class"] = "alert alert-danger";
                this.alertlocal.Attributes["role"] = "alert";
                this.alertlocal.InnerHtml = "<div><button type=\"button\" class=\"close\" data-dismiss=\"alert\" aria-label=\"Close\"><span aria-hidden=\"true\">&times;</span></button>No has introduccido el motivo.</div>";
                this.alertlocal.Visible = true;
            }
            if (id_fechai.Value != "" && Id_fechaf.Value != "" && TextBox1.Text != "")
            {
                this.alertlocal.Attributes["class"] = "alert alert-success";
                this.alertlocal.Attributes["role"] = "alert";
                this.alertlocal.InnerHtml = "<div><button type=\"button\" class=\"close\" data-dismiss=\"alert\" aria-label=\"Close\"><span aria-hidden=\"true\">&times;</span></button>Se ha modificado la solicitud de planilla.</div>";
                this.alertlocal.Visible = true;
            }
        }
    }
}