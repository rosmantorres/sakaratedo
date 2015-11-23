using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace templateApp.GUI.Modulo15
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ((SKD)Page.Master).IdModulo = "15";
            String success = Request.QueryString["eliminacionSuccess"];
            String comprobar = Request.QueryString["comprobar"];
            String modificar = Request.QueryString["modificar"];

            if (success != null)
            {
                if (success.Equals("1"))
                {
                  

                    alert.Attributes["class"] = "alert alert-success alert-dismissible";
                    alert.Attributes["role"] = "alert";
                    alert.InnerHtml = "<div><button type=\"button\" class=\"close\" data-dismiss=\"alert\" aria-label=\"Close\"><span aria-hidden=\"true\">&times;</span></button>Implemento deportivo eliminado exitosamente</div>";
                }

            }

            if (comprobar != null) {


                if (comprobar.Equals("exito"))
                {

                    alert.Attributes["class"] = "alert alert-success alert-dismissible";
                    alert.Attributes["role"] = "alert";
                    alert.InnerHtml = "<div><button type=\"button\" class=\"close\" data-dismiss=\"alert\" aria-label=\"Close\"><span aria-hidden=\"true\">&times;</span></button>Se agregó el implemento exitosamente</div>";
                }
            }

            if (modificar != null)
            {


                if (modificar.Equals("exito"))
                {

                    alert.Attributes["class"] = "alert alert-success alert-dismissible";
                    alert.Attributes["role"] = "alert";
                    alert.InnerHtml = "<div><button type=\"button\" class=\"close\" data-dismiss=\"alert\" aria-label=\"Close\"><span aria-hidden=\"true\">&times;</span></button>Se modifico el implemento exitosamente</div>";
                }
            }

        }
    }
}