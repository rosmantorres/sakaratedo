﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using templateApp.GUI.Modulo1;
using templateApp.GUI.Master;

namespace templateApp.GUI.Modulo1
{
    public partial class Index : System.Web.UI.Page
    {
        public Boolean valueInfo = false;
        protected void Page_Load(object sender, EventArgs e)
        {

            errorLogin.Visible = false;
            warningLog.Visible = false;

            if ((Request.QueryString[mensajes.tipoInfo] == "true"))
                mensajeLogin(true, mensajes.logInfo, mensajes.tipoInfo);
            else
                infoLog.Visible = false;

            if ((Request.QueryString[mensajes.tipoSucess] == "true"))
                mensajeLogin(true, mensajes.logSuccess, mensajes.tipoSucess);
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
            String CorreoOrigen = "sakaratedo@gmail.com";
            String ClaveOrigen = "karate1234";
            string puerto = "23072";
            String DireccionHTTP = "http://localhost:"+puerto+"/GUI/Modulo1/RestablecerContrasena.aspx";
            String Mensaje = "Estimado usuario, se ha solicitado desde la plataforma de SA-KARATEDO el reestablecimiento de la contraseña "+
           "asociada a su cuenta, si usted no produjo dicha solicitud omitir la importancia del correo, de lo contrario deberá seguir los "+
           "pasao que a continuacion se le presenta para poder reestablecer su contraseña:<br>"+
           "Diríjase al siguiente enlace en el cual podrá asignar una nueva contraseña a su cuenta de SA-KARATEDO.</br><br></br>"+"<br>"+
           DireccionHTTP+"</br>";
            //BD:End
            String CorreoDestino= RestablecerCorreo.Value;
            if (CorreoDestino == "falla@gmail.com")
            {

                mensajeLogin(true, mensajes.logWarning, mensajes.tipoWarning);
            }
            else
            {
                mensajeLogin(true, mensajes.logInfo, mensajes.tipoInfo);
                new login().EnviarCorreo(CorreoOrigen, ClaveOrigen, CorreoDestino, Mensaje);

                string opcion = "true";
                Response.Redirect("~/GUI/Modulo1/Index.aspx?" + mensajes.tipoInfo + "=" + opcion);
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
                Session[sessionTag.rol] = Respuesta[2];
                Session[sessionTag.usuarioN] = Respuesta[3];
                Session[sessionTag.usuarioA] = Respuesta[4];
                Session[sessionTag.usuarioC] = Respuesta[0];
                Session[sessionTag.roles] = Respuesta[5];
                Response.Redirect("~/GUI/Master/Inicio.aspx");
                mensajeLogin(false, mensajes.logErr, mensajes.tipoErr);
            }
            else
                mensajeLogin(true,mensajes.logErr,mensajes.tipoErr);
        }
           
    }
}