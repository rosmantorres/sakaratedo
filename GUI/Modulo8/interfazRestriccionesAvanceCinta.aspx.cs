using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace templateApp.GUI.Modulo8
{
    public partial class interfazRestriccionesAvanceCinta : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            ((SKD)Page.Master).IdModulo = "8.3";
            String success = Request.QueryString["actionSuccess"];

            if (success != null)
            {
                if (success.Equals("1"))
                {
                    alert.Attributes["class"] = "alert alert-success alert-dismissible";
                    alert.Attributes["role"] = "alert";
                    alert.InnerHtml = "<div><button type=\"button\" class=\"close\" data-dismiss=\"alert\" aria-label=\"Close\"><span aria-hidden=\"true\">&times;</span></button>Restriccion agregada exitosamente</div>";
                }
                else
                {
                    if (success.Equals("2"))
                    {
                        alert.Attributes["class"] = "alert alert-success alert-dismissible";
                        alert.Attributes["role"] = "alert";
                        alert.InnerHtml = "<div><button type=\"button\" class=\"close\" data-dismiss=\"alert\" aria-label=\"Close\"><span aria-hidden=\"true\">&times;</span></button>Restriccion eliminada exitosamente</div>";
                    }
                    else
                        if (success.Equals("3"))
                        {
                            alert.Attributes["class"] = "alert alert-success alert-dismissible";
                            alert.Attributes["role"] = "alert";
                            alert.InnerHtml = "<div><button type=\"button\" class=\"close\" data-dismiss=\"alert\" aria-label=\"Close\"><span aria-hidden=\"true\">&times;</span></button>Restriccion modificada exitosamente</div>";
                        }
                }
            }

        }
    }
}