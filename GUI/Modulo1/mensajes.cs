using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace templateApp.GUI.Modulo1
{
    public class mensajes
    {
        public static string logErr = "Contraseña y/o usuario incorrecto.";//mensae para alertar sobre usuario y/o contrasea incorrecto en el login
        public static string logAlert = "";
        public static string logWarning = "¡El correo no se encuentra registrado en SA-KARATEDO.!";
        public static string logSucess = "";

        public static string tipoErr = "Error";
        public static string tipoWarning = "Warning";
        public static string tipoInfo = "Sucess";
        public static string tipoSucess = "Info";
    }
}