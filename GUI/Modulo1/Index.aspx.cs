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

            if ((Request.QueryString[RecursosInterfazModulo1.tipoInfo] == "true"))
                mensajeLogin(true, RecursosInterfazModulo1.logInfo, RecursosInterfazModulo1.tipoInfo);
            else
                infoLog.Visible = false;
            if ((Request.QueryString[RecursosInterfazModulo1.tipoSucess] == "true"))
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
                case "Error": errorLogin.Visible = visible;
                              warningLog.Visible = !visible;
                              infoLog.Visible = !visible;
                              successLog.Visible = !visible;
                               errorLogin.InnerText = mensaje; break;
                case "Warning": warningLog.Visible = visible;
                                errorLogin.Visible = !visible;
                                infoLog.Visible = !visible;
                                successLog.Visible = !visible;
                                warningLog.InnerText = mensaje; break;
                case "Info": infoLog.Visible = visible;
                              errorLogin.Visible = !visible;
                              warningLog.Visible = !visible;
                              successLog.Visible = !visible;
                              infoLog.InnerText = mensaje; break;
                case "Success": successLog.Visible = visible; 
                                errorLogin.Visible =!visible;
                              warningLog.Visible = !visible;
                              infoLog.Visible = !visible;
                              successLog.InnerText = mensaje; break;
            }
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

                string opcion = "true";
                Response.Redirect(RecursosInterfazModulo1.direccionM1_Index + "?" + RecursosInterfazModulo1.tipoInfo + "=" + opcion);
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
                Session[RecursosInterfazMaster.sessionRol] = Respuesta[2];
                Session[RecursosInterfazMaster.sessionUsuarioNombre] = Respuesta[3];
                Session[RecursosInterfazMaster.sessionUsuarioApellido] = Respuesta[4];
                Session[RecursosInterfazMaster.sessionUsuarioCorreo] = Respuesta[0];
                Session[RecursosInterfazMaster.sessionRoles] = Respuesta[5];
                Response.Redirect(RecursosInterfazMaster.direccionMaster_Inicio);
                mensajeLogin(false, RecursosInterfazModulo1.logErr, RecursosInterfazModulo1.tipoErr);
            }
            else
                mensajeLogin(true, RecursosInterfazModulo1.logErr, RecursosInterfazModulo1.tipoErr);
        }
           
    }
}