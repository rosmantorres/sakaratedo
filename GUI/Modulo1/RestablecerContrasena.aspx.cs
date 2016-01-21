using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using LogicaNegociosSKD.Modulo1;
using LogicaNegociosSKD.Modulo2;
using templateApp.GUI.Master;
using Interfaz_Presentadores.Modulo1;
using Interfaz_Contratos.Modulo1;

namespace templateApp.GUI.Modulo1
{
    public partial class RestablecerContraseña : System.Web.UI.Page , IContratoM1Restablecer
    {
        
        string IdUser = "";
        string value;
        private PresentadorM1Restablecer presentador;
        AlgoritmoDeEncriptacion cripto = new AlgoritmoDeEncriptacion();

        String IContratoM1Restablecer.ClaveEtq
        {
            get { return password3.Value; }
        }
        String IContratoM1Restablecer.ClaveConfirmacionEtq
        {
            get { return password4.Value; }
        }
        String IContratoM1Restablecer.InfoRestablecerEtqText
        {
            get { return infoRestablecer.InnerText; }
            set { infoRestablecer.InnerText = value; }
        }
        String IContratoM1Restablecer.WarningCaracterEtqText
        {
            get { return warningCaracteres.InnerText; }
            set { warningCaracteres.InnerText = value; }
        }
        Boolean IContratoM1Restablecer.InfoRestablecerEtq
        {
            get { return infoRestablecer.Visible; }
            set { infoRestablecer.Visible = value; }
        }
        Boolean IContratoM1Restablecer.WarningCaracterEtq
        {
            get { return warningCaracteres.Visible; }
            set { warningCaracteres.Visible = value; }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            presentador = new PresentadorM1Restablecer(this);
            presentador.Inicio();
            
        }
        public void redireccionarInicio(object sender, EventArgs e)
        {
            presentador.RedireccionarInicio();
        }
      
    }
}