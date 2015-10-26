using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace templateApp.GUI.Modulo14
{
    public partial class M14_SolicitarPlanilla : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ((SKD)Page.Master).IdModulo = "14";
                llenarComboTipoPlanilla();  
        }


        protected void llenarComboTipoPlanilla()
        {

            Dictionary<string, string> options = new Dictionary<string, string>();
            options.Add("-1", "Selecciona una opcion");
            options.Add("1", "Retiro");
            options.Add("2", "Ascenso");
            options.Add("3", "Otro");

            comboTipoPlanilla.DataSource = options;
            comboTipoPlanilla.DataTextField = "value";
            comboTipoPlanilla.DataValueField = "key";
            comboTipoPlanilla.DataBind();


        }
    }
    
       
}