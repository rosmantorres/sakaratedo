using System;
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
        protected void Page_Load(object sender, EventArgs e)
        {


        }

        public void EnvioCorreo(object sender, EventArgs e)
        {

            EnviarCorreo();
        }
        public void ValidarUsuario(object sender, EventArgs e)
        {

            validarUsuario();
        }
        public void EnviarCorreo()
        {
            //BD:Todo esto sera traido de la base de datos 
            String CorreoOrigen = "sakaratedo@gmail.com";
            String ClaveOrigen = "karate1234";
            String DireccionHTTP="Https://EnlaceEncriptado";
            String Mensaje = "Estimado usuario, se ha solicitado desde la plataforma de SA-KARATEDO el reestablecimiento de la contraseña "+
           "asociada a su cuenta, si usted no produjo dicha solicitud omitir la importancia del correo, de lo contrario deberá seguir los "+
           "pasao que a continuacion se le presenta para poder reestablecer su contraseña:<br>"+
           "Diríjase al siguiente enlace en el cual podrá asignar una nueva contraseña a su cuenta de SA-KARATEDO.</br><br></br>"+"<br>"+
           DireccionHTTP+"</br>";
            //BD:End
            String CorreoDestino= RestablecerCorreo.Value;
            new login().EnviarCorreo(CorreoOrigen, ClaveOrigen, CorreoDestino, Mensaje);
            RestablecerCorreo.Value = "";
        }
        public void validarUsuario()
        {
            string correo = userIni.Value;
            string clave = passwordIni.Value;
            string[] Respuesta = new login().iniciarSesion(correo, clave);
            if (Respuesta!=null)
            {
                Session[sessionTag.rol] =Respuesta[2] ;
                Session[sessionTag.usuarioN] = Respuesta[3];
                Session[sessionTag.usuarioA] = Respuesta[4];
                Session[sessionTag.usuarioC] = Respuesta[0];
                Session[sessionTag.roles] = Respuesta[5];
                Response.Redirect("../Master/Inicio.aspx");
            }
           
        }
           
    }
}