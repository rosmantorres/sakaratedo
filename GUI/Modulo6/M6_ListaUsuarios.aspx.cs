using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DominioSKD;
using LogicaNegociosSKD.Modulo6;
using LogicaNegociosSKD.Modulo2;

namespace templateApp.GUI.Modulo6
{
    public partial class M6_ListaUsuarios : System.Web.UI.Page
    {
        public List<Cuenta> lasCuentas = new List<Cuenta>();
        public AlgoritmoDeEncriptacion cripto = new AlgoritmoDeEncriptacion();
        public string DES = RecursosLogicaModulo2.claveDES;
        protected void Page_Load(object sender, EventArgs e)
        {
            ((SKD)Page.Master).IdModulo = "6";
            LogicaListar lg = new LogicaListar();
            lasCuentas = lg.Listar();

        }
    }
}