using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using LogicaNegociosSKD.Modulo1;

namespace templateApp.GUI.Modulo1
{
    public partial class RestablecerContraseña : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        public void redireccionarInicio(object sender, EventArgs e)
        {
           /* string pass1=password3.Value ;
            string pass2= password4.Value;
            logicaRestablecer Restablecer = new logicaRestablecer();
            string IdUser=Request.QueryString[RecursosInterfazModulo1.parametroURLID];
            if (pass1 != "" && pass1 == pass2 && pass1.Length > 7)
            {
                if(Restablecer.restablecerContrasena(IdUser, pass1))
                Response.Redirect(RecursosInterfazModulo1.direccionM1_Index + "?"
                    + RecursosInterfazModulo1.tipoSucess + "=" +
                    RecursosInterfazModulo1.parametroURLReestablecerExito);
            }
            */
        }
    }
}