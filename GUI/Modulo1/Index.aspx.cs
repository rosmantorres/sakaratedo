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
                mensajeLogin( RecursosInterfazModulo1.logInfo, RecursosInterfazModulo1.tipoInfo);
            else
                infoLog.Visible = false;

            if ((Request.QueryString[RecursosInterfazModulo1.tipoSucess] == RecursosInterfazModulo1.parametroURLReestablecerExito))
                mensajeLogin( RecursosInterfazModulo1.logSuccess, RecursosInterfazModulo1.tipoSucess);
            else
                successLog.Visible = false;

        }

        public void EnvioCorreo(object sender, EventArgs e)
        {

            EnviarCorreo();
        }
        public void ValidarUsuario(object sender, EventArgs e)
        {

            consultarUsuario();
        }
        /// <summary>
        /// Metodo para Establecer un mensaje de alerta en el login
        /// </summary>
        /// <param name="visible">Si queremos que sea visible</param>
        /// <param name="mensaje">Mensaje que aparecerá en la alerta</param>
        /// <param name="tipo">stirng Error;Warning;Info;Sucess</param>
        public void mensajeLogin(string mensaje,string tipo)
        {
            switch (tipo)
            {
                case "Error": mensajeVisible(false, false, false, true,mensaje); break;
                case "Warning": mensajeVisible(false, false, true, false,mensaje); break;
                case "Info": mensajeVisible(false, true, false, false,mensaje); break;
                case "Success": mensajeVisible(true, false, false, false,mensaje); break;
            }
        }

        public void mensajeVisible(bool success,bool info,bool warning,bool error,string mensaje)
        {
            successLog.Visible = success;
            warningLog.Visible = warning;
            errorLogin.Visible = error;
            infoLog.Visible = info;

            if (success)
                successLog.InnerText = mensaje;
            else if (info)
                infoLog.InnerText = mensaje;
            else if (warning)
                warningLog.InnerText = mensaje;
            else if (error)
                errorLogin.InnerText = mensaje;

        }


        /// <summary>
        /// Metodo para el envio de correo electrónico 
        /// </summary>
        public void EnviarCorreo()
        {
            //BD:Todo esto sera traido de la base de datos 
            
            //BD:End
            String CorreoDestino= RestablecerCorreo.Value;
            try
            {
               // mensajeLogin( RecursosInterfazModulo1.logInfo, RecursosInterfazModulo1.tipoInfo);
                new logicaLogin().EnviarCorreo(CorreoDestino);
                Response.Redirect(RecursosInterfazModulo1.direccionM1_Index + "?"
                    + RecursosInterfazModulo1.tipoInfo + "=" +
                    RecursosInterfazModulo1.parametroURLCorreoEnviado);
            }
            catch (Exception e)
            {
                mensajeLogin(e.Message,RecursosInterfazModulo1.tipoErr);
            }
            finally
            {
                RestablecerCorreo.Value = "";
            }
                    
           
        }
        public void consultarUsuario()
        {
            string correo = userIni.Value;
            string clave = passwordIni.Value;
            string[] Respuesta = new logicaLogin().iniciarSesion(correo, clave);
            if (Respuesta != null)
            {
                Session[RecursosInterfazMaster.sessionRol] = Respuesta[3];
                Session[RecursosInterfazMaster.sessionUsuarioNombre] = Respuesta[1];
                Session[RecursosInterfazMaster.sessionRoles] = Respuesta[2];
                Session[RecursosInterfazMaster.sessionUsuarioID] = Respuesta[0];
                Session[RecursosInterfazMaster.sessionImagen] = Respuesta[4];
                Response.Redirect(RecursosInterfazMaster.direccionMaster_Inicio);
                mensajeLogin( RecursosInterfazModulo1.logErr, RecursosInterfazModulo1.tipoErr);
            }
            else
                mensajeLogin( RecursosInterfazModulo1.logErr, RecursosInterfazModulo1.tipoErr);
        }
           
    }
}