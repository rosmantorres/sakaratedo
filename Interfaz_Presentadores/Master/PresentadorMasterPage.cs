using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Xml;
using Interfaz_Contratos;

namespace Interfaz_Presentadores.Master
{
    public class PresentadorMasterPage
    {
        private IContratoMasterPage _iMaster;
        #region etiquetas
        String listIni="<li class='dropdown'>";
        String listFin="</li>";
        String menuIni="<a  class='dropdown-toggle' data-toggle='dropdown' role='button' aria-expanded='false'>";
        String menuFin="<span class='caret'></span></a>";
        String subMenuIni = "<li><a href='";
        String subMenuFin = "</a></li>";
        String ulIni=" <ul class='dropdown-menu' role='menu'>";
        String ulFin="</ul>";
        #endregion
        public PresentadorMasterPage(IContratoMasterPage Imaster)
        {
            _iMaster = Imaster;
        }
        
        public void CargarMenuSuperior()
        {
            XmlDocument doc = new XmlDocument();
     
            string[] permisos;//se guardaran los permisos asociados a cada opcion del menuSuperior.xml
            string[] opciones = new string[2];
            int i = 0; //iteracion de posicionOpciones
            doc.Load(HttpContext.Current.Server.MapPath(RecursosInterfazMaster.direccionMaster_MenuSuperior));
            foreach (XmlNode node in doc.DocumentElement.ChildNodes)
            {

                String respuesta = "";
                permisos = node.Attributes[RecursosInterfazMaster.sessionRol].
                    InnerText.Split(char.Parse(RecursosInterfazMaster.splitRoles));

                if (validaRol(permisos,_iMaster.RolEnUso))
                {
                    
                    respuesta += listIni;
                    respuesta += menuIni + node.Attributes[RecursosInterfazMaster.tagName].InnerText + menuFin;
                    respuesta += ulIni;
                    foreach (XmlNode subNode in node.ChildNodes)
                    {
                        permisos = subNode.Attributes[RecursosInterfazMaster.sessionRol].
                            InnerText.Split(char.Parse(RecursosInterfazMaster.splitRoles));
                        if ((subNode.Attributes[RecursosInterfazMaster.tagLink].InnerText != null) && (validaRol(permisos, _iMaster.RolEnUso)))
                        {

                            respuesta += subMenuIni+System.Web.VirtualPathUtility.ToAbsolute(subNode.Attributes[RecursosInterfazMaster.tagLink].InnerText.ToString());
                            respuesta += "'>" + subNode.Attributes[RecursosInterfazMaster.tagName].InnerText.ToString();
                            respuesta += subMenuFin;
                        }
                    }
                    respuesta += ulFin;
                    respuesta += listFin;
                    _iMaster.MenuSuperiorList += respuesta.ToString();

                }
            }
      
        }

        private Boolean validaRol(string[] permisos, string rolUsuario)
        {
            foreach (string rol in permisos)
            {
                if (rol == rolUsuario)
                    return true;
            }
            return false;
        }

        public void CargarMenuLateral()
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(HttpContext.Current.Server.MapPath(RecursosInterfazMaster.direccionMaster_MenuLateral));
            foreach (XmlNode node in doc.DocumentElement.ChildNodes)
            {
                String respuesta = "";
                foreach (XmlNode subNode in node.ChildNodes)
                    if (!(subNode.Attributes[RecursosInterfazMaster.tagId] == null) &&
                        subNode.Attributes[RecursosInterfazMaster.tagId].InnerText.Equals(_iMaster.IdModulo))
                    {
                        respuesta = respuesta + subMenuIni + node.Attributes[RecursosInterfazMaster.tagLink].InnerText + "'>";
                        respuesta = respuesta + node.Attributes[RecursosInterfazMaster.tagName].InnerText + subMenuFin;

                        break;
                    }
                _iMaster.MenuLateralList += respuesta;
            }
        }

        public void ValidarSesion()
        {
           
        }
        public void validarPermiso()
        {

        }
    }
}
