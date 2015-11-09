using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace templateApp.GUI.Modulo10
{
    public partial class M10_AgregarAsistenciaEventos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ((SKD)Page.Master).IdModulo = "10";
        }

        protected void comboCat_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void comboEve_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}