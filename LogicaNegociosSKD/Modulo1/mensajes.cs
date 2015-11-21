using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LogicaNegociosSKD.Modulo1
{
    public class mensajes
    {
        public static string logErr = "Contraseña y/o usuario incorrecto.";//mensae para alertar sobre usuario y/o contrasea incorrecto en el login
        public static string logInfo = "¡Correo enviado!";
        public static string logWarning = "¡El correo no se encuentra registrado en SA-KARATEDO.!";
        public static string logSuccess = "Se reestableció con exito su contraseña";


        public static string tipoErr = "Error";
        public static string tipoWarning = "Warning";
        public static string tipoInfo = "Info";
        public static string tipoSucess = "Success";
    }
}