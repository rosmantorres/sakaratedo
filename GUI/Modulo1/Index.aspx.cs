using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using templateApp.GUI.Modulo1;
using templateApp.GUI.Master;
using LogicaNegociosSKD.Modulo1;

namespace templateApp.GUI.Modulo1
{
    public partial class Index : System.Web.UI.Page
    {
        public Boolean valueInfo = false;
        protected void Page_Load(object sender, EventArgs e)
        {

            errorLogin.Visible = false;
            warningLog.Visible = false;

            if ((Request.QueryString[RecursosInterfazModulo1.tipoInfo] == RecursosInterfazModulo1.parametroURLCorreoEnviado))
                mensajeLogin(true, RecursosInterfazModulo1.logInfo, RecursosInterfazModulo1.tipoInfo);
            else
                infoLog.Visible = false;

            if ((Request.QueryString[RecursosInterfazModulo1.tipoSucess] == RecursosInterfazModulo1.parametroURLReestablecerExito))
                mensajeLogin(true, RecursosInterfazModulo1.logSuccess, RecursosInterfazModulo1.tipoSucess);
            else
                successLog.Visible = false;

        }

        public void EnvioCorreo(object sender, EventArgs e)
        {

            EnviarCorreo();
        }
        public void ValidarUsuario(object sender, EventArgs e)
        {

            validarUsuario();
        }
        /// <summary>
        /// Metodo para Establecer un mensaje de alerta en el login
        /// </summary>
        /// <param name="visible">Si queremos que sea visible</param>
        /// <param name="mensaje">Mensaje que aparecerá en la alerta</param>
        /// <param name="tipo">stirng Error;Warning;Info;Sucess</param>
        public void mensajeLogin(Boolean visible,string mensaje,string tipo)
        {
            switch (tipo)
            {
                case "Error": mensajeVisible(false, false, false, true); break;
                case "Warning": mensajeVisible(false, false, true, false); break;
                case "Info": mensajeVisible(false, true, false, false); break;
                case "Success": mensajeVisible(true, false, false, false); break;
            }
        }

        public void mensajeVisible(bool success,bool info,bool warning,bool error)
        {
            successLog.Visible = success;
            warningLog.Visible = warning;
            errorLogin.Visible = error;
            infoLog.Visible = info;

        }


        /// <summary>
        /// Metodo para el envio de correo electrónico 
        /// </summary>
        public void EnviarCorreo()
        {
            //BD:Todo esto sera traido de la base de datos 
            
            //BD:End
            String CorreoDestino= RestablecerCorreo.Value;
            if (CorreoDestino == "falla@gmail.com")
            {

                mensajeLogin(true, RecursosInterfazModulo1.logWarning, RecursosInterfazModulo1.tipoWarning);
            }
            else
            {
                mensajeLogin(true, RecursosInterfazModulo1.logInfo, RecursosInterfazModulo1.tipoInfo);
                new login().EnviarCorreo( CorreoDestino);

                Response.Redirect(RecursosInterfazModulo1.direccionM1_Index + "?" + RecursosInterfazModulo1.tipoInfo + "=" + RecursosInterfazModulo1.parametroURLCorreoEnviado);
            }
            RestablecerCorreo.Value = "";
                    
           
        }
        public void validarUsuario()
        {
            string correo = userIni.Value;
            string clave = passwordIni.Value;
            string[] Respuesta = new login().iniciarSesion(correo, clave);
            if (Respuesta != null)
            {
                Session[RecursosInterfazMaster.sessionRol] = Respuesta[3];
                Session[RecursosInterfazMaster.sessionUsuarioNombre] = Respuesta[1];
                Session[RecursosInterfazMaster.sessionRoles] = Respuesta[2];
                Session[RecursosInterfazMaster.sessionUsuarioID] = Respuesta[0];
                Response.Redirect(RecursosInterfazMaster.direccionMaster_Inicio);
                mensajeLogin(false, RecursosInterfazModulo1.logErr, RecursosInterfazModulo1.tipoErr);
            }
            else
                mensajeLogin(true, RecursosInterfazModulo1.logErr, RecursosInterfazModulo1.tipoErr);
        }
           
    }
}