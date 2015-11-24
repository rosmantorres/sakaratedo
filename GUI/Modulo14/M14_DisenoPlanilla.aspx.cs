using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using LogicaNegociosSKD.Modulo14;

namespace templateApp.GUI.Modulo14
{
    public partial class M14_DisenoPlanilla : System.Web.UI.Page
    {
        private LogicaNegociosSKD.Modulo14.LogicaDiseño logica = new LogicaNegociosSKD.Modulo14.LogicaDiseño();
        DominioSKD.Planilla planilla1;
        private Boolean exito;
        private string htmlEncode;

        protected void Page_Load(object sender, EventArgs e)
        {
            ((SKD)Page.Master).IdModulo = "14";
            this.tipoPlanilla.Text = "Retiro";
            this.Planilla.Text = "Vacaciones";
            planilla1 = new DominioSKD.Planilla(1,this.Planilla.Text, true, this.tipoPlanilla.Text);
        }

        protected void btnguardar_Click(object sender, EventArgs e)
        {
            htmlEncode = Server.HtmlEncode(CKEditor1.Text);
            DominioSKD.Diseño diseño = new DominioSKD.Diseño(CKEditor1.Text);
            if (CKEditor1.Text != "")
            {
                exito = logica.AgregarDiseño(diseño,planilla1);
                if (exito)
                {
                    alert.Attributes["class"] = "alert alert-success alert-dismissible";
                    alert.Attributes["role"] = "alert";
                    alert.InnerHtml = "<div><button type=\"button\" class=\"close\" data-dismiss=\"alert\" aria-label=\"Close\"><span aria-hidden=\"true\">&times;</span></button>Diseño de Plantilla guardado satisfactoriamente</div>";
                }
                else
                {
                    alert.Attributes["class"] = "alert alert-danger alert-dismissible";
                    alert.Attributes["role"] = "alert";
                    alert.InnerHtml = "<div><button type=\"button\" class=\"close\" data-dismiss=\"alert\" aria-label=\"Close\"><span aria-hidden=\"true\">&times;</span></button>Error no se pudo guardar el diseño. Intente más tarde</div>";
                }
            }

        }
    }
}