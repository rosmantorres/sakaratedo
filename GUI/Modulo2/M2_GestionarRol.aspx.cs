using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace templateApp.GUI.Modulo2
{
    public partial class M2_Prueba : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            ((SKD)Page.Master).IdModulo = "2";
        }
        protected void EliminarRol(object sender, EventArgs e)
        {
            Console.WriteLine("Entro al metodo EliminarROL");
        }
        protected void AgregarRol(object sender, EventArgs e)
        {
            Console.WriteLine("Entro al metodo agregarROL");
        }
        protected void Selection_Change(Object sender, EventArgs e)
        {

            Console.WriteLine("Entro al metodo Selection_change");
            //String h= RolList.SelectedValue;

        }
    }
}