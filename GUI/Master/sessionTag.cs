using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.SessionState;

namespace templateApp.GUI.Master
{
    public  class sessionTag
    {

        public static string rol = "rol";///Rol del usuario
        public static string roles = "roles";///Roles que puede tener un usuario 
        public static string usuarioN = "Nombre";///Nombre del usuario
        public static string usuarioA = "Apellido";///Apellido del usuario
        public static string usuarioC = "Correo";///Correo del usuario
                                                 
        ///Tags asociados a las etiquetas XML
        public static string nameTag = "nombre";///Tag asociado a la etiqueta XML de menuSuperior.xml
        public static string linkTag = "link";///Tag asociado a la etiqueta XML de menuSuperior.xml
    }
}