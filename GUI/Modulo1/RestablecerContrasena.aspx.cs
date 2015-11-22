using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace templateApp.GUI.Modulo1
{
    public partial class RestablecerContraseña : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
           
        }

        protected void redireccionarIncio(object sender, EventArgs e)
        {
            
            string opcion="true";
            Response.Redirect(RecursosInterfazModulo1.direccionM1_Index+"?" + RecursosInterfazModulo1.tipoSucess + "=" + opcion);
        }
    }
}