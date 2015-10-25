using System;
using System.Collections.Generic;
using System.Xml;
using System.Text;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using templateApp.GUI.Master;

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
            XmlDocument doc = new XmlDocument();
            doc.Load(Server.MapPath("~/GUI/Master/menuLateral.xml"));
            idModulo = IdModulo;
            foreach (XmlNode node in doc.DocumentElement.ChildNodes)
                foreach (XmlNode subNode in node.ChildNodes)
                    if (!(subNode.Attributes["id"] == null) && subNode.Attributes["id"].InnerText.Equals(IdModulo))
                    {
                        OpcionesDelMenu[node.Attributes["nombre"].InnerText] = node.Attributes["link"].InnerText;
                        break;
                    }
            asignarUsuario();
            DropDownMenu();
        }

        /// <summary>
        /// Se realizan la asignacion de los datos de usuario a la plantilla (nombre,apellido, roles etc)
        /// </summary>
        protected void asignarUsuario()
        {

            userName.InnerText = (string)Session[sessionTag.usuarioN] + " " + Session[sessionTag.usuarioA];
            userTag.InnerText = (string)Session[sessionTag.usuarioN] + " " + Session[sessionTag.usuarioA];
            string[] roles = Session[sessionTag.roles].ToString().Split('-');
            int cont = 0;
            foreach (string perfil in roles)
            {
                rolesUsuario[cont] = perfil;
                cont++;
            }

            if (Request.QueryString[sessionTag.rol] != null)
                Session[sessionTag.rol] = Request.QueryString[sessionTag.rol];


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
            string rol = (string)(Session[sessionTag.rol]);
            XmlDocument doc = new XmlDocument();
            string[] permisos;//se guardaran los permisos asociados a cada opcion del menuSuperior.xml
            string[] opciones = new string[2];
            int i = 0; //iteracion de posicionOpciones
            doc.Load(Server.MapPath("~/GUI/Master/menuSuperior.xml"));
            foreach (XmlNode node in doc.DocumentElement.ChildNodes)
            {
                i = 0;
                permisos = node.Attributes[sessionTag.rol].InnerText.Split('-');

                if (validaRol(permisos, rol))
                {
                    string[,] posicionOpcinones = new string[2, node.ChildNodes.Count];
                    foreach (XmlNode subNode in node.ChildNodes)
                    {

                        permisos = subNode.Attributes[sessionTag.rol].InnerText.Split('-');
                        if ((subNode.Attributes[sessionTag.linkTag].InnerText != null) && (validaRol(permisos, rol)))
                        {

                            posicionOpcinones[0, i] = (string)subNode.Attributes[sessionTag.nameTag].InnerText.ToString();
                            posicionOpcinones[1, i] = subNode.Attributes[sessionTag.linkTag].InnerText.ToString();
                            i++;
                        }
                    }

                    SubOpcionesDelMenu[node.Attributes[sessionTag.nameTag].InnerText] = posicionOpcinones;

                }
            }
        }
        /// <summary>
        /// Metodo para el boto Sing Out de la tabla de usuario
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void logout(object sender, EventArgs e)
        {
            Session.Remove(sessionTag.rol);
            Session.Remove(sessionTag.roles);
            Session.Remove(sessionTag.usuarioA);
            Session.Remove(sessionTag.usuarioC);
            Session.Remove(sessionTag.usuarioN);
            Response.Redirect("../Modulo1/Index.aspx");
        }
    }
}