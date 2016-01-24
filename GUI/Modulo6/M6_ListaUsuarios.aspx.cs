using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DominioSKD.Entidades.Modulo1;
//using LogicaNegociosSKD.Modulo6;
using LogicaNegociosSKD.Modulo2;
using Interfaz_Contratos.Master;

namespace templateApp.GUI.Modulo6
{
    public partial class M6_ListaUsuarios : System.Web.UI.Page
    {
        public List<Cuenta> lasCuentas = new List<Cuenta>();
        public AlgoritmoDeEncriptacion cripto = new AlgoritmoDeEncriptacion();
        public string DES = RecursosLogicaModulo2.claveDES;
        protected void Page_Load(object sender, EventArgs e)
        {
            IContratoMasterPage _iMaster = ((SKD)Page.Master);
            _iMaster.IdModulo = "6";
            //LogicaListar lg = new LogicaListar();
            //lasCuentas = lg.Listar();

        }
    }
}