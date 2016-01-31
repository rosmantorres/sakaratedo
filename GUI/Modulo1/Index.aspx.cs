using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using templateApp.GUI.Modulo1;
using templateApp.GUI.Master;
using LogicaNegociosSKD.Modulo1;
using LogicaNegociosSKD.Modulo2;
using Interfaz_Contratos.Modulo1;
using Interfaz_Presentadores.Modulo1;

namespace templateApp.GUI.Modulo1
{
    public partial class Index : System.Web.UI.Page , IContratoM1Inicio
    {        
        private PresentadorM1Inicio presentador;
        
        String IContratoM1Inicio.UserNameEtq
        {
            get { return userIni.Value; }
            set { userIni.Value = value; }
        }
        String IContratoM1Inicio.PasswordEtq
        {
            get { return passwordIni.Value; }
            set { passwordIni.Value = value; }
        }
        Boolean IContratoM1Inicio.ErrorLogin
        {
            get { return errorLogin.Visible; }
            set { errorLogin.Visible = value; }
        }
        Boolean IContratoM1Inicio.InfoLog
        {
            get { return infoLog.Visible; }
            set { infoLog.Visible = value; }
        }
        Boolean IContratoM1Inicio.WarningLog
        {
            get { return warningLog.Visible; }
            set { warningLog.Visible = value; }
        }
        Boolean IContratoM1Inicio.SuccessLog
        {
            get { return successLog.Visible; }
            set { successLog.Visible = value; }
        }
        String IContratoM1Inicio.ErrorLoginText
        {
            get { return errorLogin.InnerText; }
            set { errorLogin.InnerText = value; }
        }
        String IContratoM1Inicio.InfoLogText
        {
            get { return infoLog.InnerText; }
            set { infoLog.InnerText = value; }
        }
        String IContratoM1Inicio.WarningLogText
        {
            get { return warningLog.InnerText; }
            set { warningLog.InnerText = value; }
        }
        String IContratoM1Inicio.SuccessLogText
        {
            get { return successLog.InnerText; }
            set { successLog.InnerText = value; }
        }
        String IContratoM1Inicio.RestablecerCorreoEtq
        {
            get { return RestablecerCorreo.Value; }
            set { RestablecerCorreo.Value = value; }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            presentador = new PresentadorM1Inicio(this);
            presentador.Inicio();
            
        }
        /// <summary>
        /// Metodo que envia 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void EnvioCorreo(object sender, EventArgs e)
        {
            presentador.EnviarCorreo();
        }

        /// <summary>
        /// Metodo resultante de accionar el acceder realiza la conexion con LogicaNegocioSKD para validar los input
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void ValidarUsuario(object sender, EventArgs e)
        {
            presentador.ValidarUsuario();
        }
       
       

           
    }
}