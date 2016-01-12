using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace templateApp.GUI.Modulo11
{
    public partial class M11_DetalleResultadoCompetencia : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void bCancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("M11_ListarResultadoCompetencia.aspx");
        }
    }
}