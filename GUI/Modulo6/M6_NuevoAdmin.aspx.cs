using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace templateApp.GUI.Modulo6
{
    public partial class M6_NuevoAdmin : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ((SKD)Page.Master).IdModulo = "6";
        }

        protected void natDropChanged(object sender, EventArgs e)
        {

        }

        protected void agreeButton_Click(object sender, EventArgs e)
        {

        }
    }
}