﻿using System;
using System.Collections.Generic;
using System.Xml;
using System.Text;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using templateApp.GUI.Master;
using templateApp.GUI.Modulo1;

namespace templateApp
{
    public partial class SKD : System.Web.UI.MasterPage
    {
        private string idModulo;
        private Dictionary<string, string> opcionesDelMenu = new Dictionary<string, string>();
        private Dictionary<string, string[,]> subOpcionesDelMenu = new Dictionary<string, string[,]>(); //Se guardaran las sub opciones del menú
        private string[] rolesUsuario = new string[10];//los roles que el usuario tiene registrado

        public string IdModulo
        {
            get { return idModulo; }
            set { idModulo = value; }
        }
        public Dictionary<string, string> OpcionesDelMenu
        {
            get { return opcionesDelMenu; }
            set { opcionesDelMenu = value; }
        }
        public Dictionary<string, string[,]> SubOpcionesDelMenu
        {
            get { return subOpcionesDelMenu; }
            set { subOpcionesDelMenu = value; }
        }
        public string[] RolesUsuario
        {
            get { return rolesUsuario; }
            set { rolesUsuario = value; }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if(Session[RecursosInterfazMaster.sessionUsuarioCorreo]!=null)
            {
            XmlDocument doc = new XmlDocument();
            doc.Load(Server.MapPath(RecursosInterfazMaster.direccionMaster_MenuLateral));
            idModulo = IdModulo;
            foreach (XmlNode node in doc.DocumentElement.ChildNodes)
                foreach (XmlNode subNode in node.ChildNodes)
                    if (!(subNode.Attributes[RecursosInterfazMaster.tagId] == null) && 
                        subNode.Attributes[RecursosInterfazMaster.tagId].InnerText.Equals(IdModulo))
                    {
                        OpcionesDelMenu[node.Attributes[RecursosInterfazMaster.tagName].InnerText] =
                            node.Attributes[RecursosInterfazMaster.tagLink].InnerText;
                        break;
                    }
            asignarUsuario();
            DropDownMenu();
            }
            else
                Response.Redirect(RecursosInterfazModulo1.direccionM1_Index);

        }

        /// <summary>
        /// Se realizan la asignacion de los datos de usuario a la plantilla (nombre,apellido, roles etc)
        /// </summary>
        protected void asignarUsuario()
        {

            userName.InnerText = (string)Session[RecursosInterfazMaster.sessionUsuarioNombre] + " "
                + Session[RecursosInterfazMaster.sessionUsuarioApellido];
            userTag.InnerText = (string)Session[RecursosInterfazMaster.sessionUsuarioNombre] + " "
                + Session[RecursosInterfazMaster.sessionUsuarioApellido];
            string[] roles = Session[RecursosInterfazMaster.sessionRoles].ToString().Split(char.Parse(RecursosInterfazMaster.splitRoles));
            int cont = 0;
            foreach (string perfil in roles)
            {
                rolesUsuario[cont] = perfil;
                cont++;
            }
            if (Request.QueryString[RecursosInterfazMaster.sessionRol] ==RecursosInterfazMaster.sessionLogout)
                logout();
            if (Request.QueryString[RecursosInterfazMaster.sessionRol] != null)
                Session[RecursosInterfazMaster.sessionRol] = Request.QueryString[RecursosInterfazMaster.sessionRol];


        }

        /// <summary>
        /// Metodo para validar si el rol esta contenido en los permisos de las opciones
        /// </summary>
        /// <param name="permisos">permisos de opciones</param>
        /// <param name="rolUsuario">rol de usuario</param>
        /// <returns>true:si tiene permiso;false:si no tiene permiso</returns>
        protected Boolean validaRol(string[] permisos, string rolUsuario)
        {
            foreach (string rol in permisos)
            {
                if (rol == rolUsuario)
                    return true;
            }
            return false;
        }

        /// <summary>
        /// El metodo guarda en la variable DropDownM de tipo Dictionary las Subopciones de la Opcion en el menú
        /// </summary>
        protected void DropDownMenu()
        {
            string rol = (string)(Session[RecursosInterfazMaster.sessionRol]);
            XmlDocument doc = new XmlDocument();
            string[] permisos;//se guardaran los permisos asociados a cada opcion del menuSuperior.xml
            string[] opciones = new string[2];
            int i = 0; //iteracion de posicionOpciones
            doc.Load(Server.MapPath(RecursosInterfazMaster.direccionMaster_MenuSuperior));
            foreach (XmlNode node in doc.DocumentElement.ChildNodes)
            {
                i = 0;
                permisos = node.Attributes[RecursosInterfazMaster.sessionRol].InnerText.Split(char.Parse(RecursosInterfazMaster.splitRoles));

                if (validaRol(permisos, rol))
                {
                    string[,] posicionOpcinones = new string[2, node.ChildNodes.Count];
                    foreach (XmlNode subNode in node.ChildNodes)
                    {

                        permisos = subNode.Attributes[RecursosInterfazMaster.sessionRol].
                            InnerText.Split(char.Parse(RecursosInterfazMaster.splitRoles));
                        if ((subNode.Attributes[RecursosInterfazMaster.tagLink].InnerText != null) && (validaRol(permisos, rol)))
                        {

                            posicionOpcinones[0, i] = (string)subNode.Attributes[RecursosInterfazMaster.tagName].InnerText.ToString();
                            posicionOpcinones[1, i] = subNode.Attributes[RecursosInterfazMaster.tagLink].InnerText.ToString();
                            i++;
                        }
                    }

                    SubOpcionesDelMenu[node.Attributes[RecursosInterfazMaster.tagName].InnerText] = posicionOpcinones;

                }
            }
        }
        /// <summary>
        /// Metodo para el boto Sing Out de la tabla de usuario
        /// </summary>
        protected void logout()
        {
            Session.Remove(RecursosInterfazMaster.sessionRol);
            Session.Remove(RecursosInterfazMaster.sessionRoles);
            Session.Remove(RecursosInterfazMaster.sessionUsuarioApellido);
            Session.Remove(RecursosInterfazMaster.sessionUsuarioCorreo);
            Session.Remove(RecursosInterfazMaster.sessionUsuarioNombre);
            Response.Redirect(RecursosInterfazModulo1.direccionM1_Index);
        }
    }
}