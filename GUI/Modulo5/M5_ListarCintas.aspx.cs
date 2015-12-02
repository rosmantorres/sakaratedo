using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using LogicaNegociosSKD.Modulo5;


namespace templateApp.GUI.Modulo5
{
    public partial class M5_ListarCintas : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ((SKD)Page.Master).IdModulo = "5";

            ListItem asd = new ListItem();
            asd.Text = "creado desde servidor";
            asd.Value = "el id";
            this.hola.Items.Add(asd);
            // ves ahora puedes usarlo aca en codigo
            // ese DropDownList1 es el q intento ponerte en codigo html, es su ID
            LogicaCinta _logicaCinta = new LogicaCinta();
           // _logicaCinta.
                

        }
    }
}