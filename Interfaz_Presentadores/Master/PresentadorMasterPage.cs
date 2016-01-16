﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Xml;
using Interfaz_Contratos.Master;
using LogicaNegociosSKD.Modulo2;

namespace Interfaz_Presentadores.Master
{
    public class PresentadorMasterPage
    {
        private IContratoMasterPage _iMaster;

        #region etiquetas Menu
        String listIni="<li class='dropdown'>";
        String listFin="</li>";
        String menuIni="<a  class='dropdown-toggle' data-toggle='dropdown' role='button' aria-expanded='false'>";
        String menuFin="<span class='caret'></span></a>";
        String subMenuIni = "<li><a href='";
        String subMenuFin = "</a></li>";
        String ulIni=" <ul class='dropdown-menu' role='menu'>";
        String ulFin="</ul>";
        #endregion

        #region etiquetas Roles
        String listIniRol="<li role='presentation' class='active'><a href='#'>";
        String listIniSesion="<li role='presentation'><a href='";
        String listFinSesion="' class='rolButton'>";
        String listFinRolSesion="</a></li>";
        String logoutIni = "<a href='";
        String logoutMed = "' class='btn btn-default btn-flat' >";
        String logoutFin = "</a>";
        #endregion


        public AlgoritmoDeEncriptacion cripto = new AlgoritmoDeEncriptacion();
        private string des = RecursosLogicaModulo2.claveDES;

        public PresentadorMasterPage(IContratoMasterPage Imaster)
        {
            _iMaster = Imaster;
        }
        
        public void CargarMenuSuperior()
        {
            XmlDocument doc = new XmlDocument();
     
            string[] permisos;//se guardaran los permisos asociados a cada opcion del menuSuperior.xml
            string[] opciones = new string[2];
            String RolEnUso = HttpContext.Current.Session[RecursosInterfazMaster.sessionRol].ToString();
            int i = 0; //iteracion de posicionOpciones
            doc.Load(HttpContext.Current.Server.MapPath(RecursosInterfazMaster.direccionMaster_MenuSuperior));
            foreach (XmlNode node in doc.DocumentElement.ChildNodes)
            {

                String respuesta = "";
                permisos = node.Attributes[RecursosInterfazMaster.sessionRol].
                    InnerText.Split(char.Parse(RecursosInterfazMaster.splitRoles));

                if (validaPermiso(permisos,RolEnUso))
                {
                    
                    respuesta += listIni;
                    respuesta += menuIni + node.Attributes[RecursosInterfazMaster.tagName].InnerText + menuFin;
                    respuesta += ulIni;
                    foreach (XmlNode subNode in node.ChildNodes)
                    {
                        permisos = subNode.Attributes[RecursosInterfazMaster.sessionRol].
                            InnerText.Split(char.Parse(RecursosInterfazMaster.splitRoles));
                        if ((subNode.Attributes[RecursosInterfazMaster.tagLink].InnerText != null) && (validaPermiso(permisos, RolEnUso)))
                        {

                            respuesta += subMenuIni+System.Web.VirtualPathUtility.ToAbsolute(subNode.Attributes[RecursosInterfazMaster.tagLink].InnerText.ToString());
                            respuesta += "'>" + subNode.Attributes[RecursosInterfazMaster.tagName].InnerText.ToString();
                            respuesta += subMenuFin;
                        }
                    }
                    respuesta += ulFin;
                    respuesta += listFin;
                    _iMaster.MenuSuperiorEtq += respuesta.ToString();

                }
            }
      
        }

        private Boolean validaPermiso(string[] permisos, string rolUsuario)
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
                        respuesta = respuesta + subMenuIni + System.Web.VirtualPathUtility.ToAbsolute(node.Attributes[RecursosInterfazMaster.tagLink].InnerText) + "'>";
                        respuesta = respuesta + node.Attributes[RecursosInterfazMaster.tagName].InnerText + subMenuFin;

                        break;
                    }
                _iMaster.MenuLateralEtq += respuesta;
            }
        }

        public void CargarRoles()
        {
            String Respuesta="";
            String RolEnUso = HttpContext.Current.Session[RecursosInterfazMaster.sessionRol].ToString();
            Respuesta +=listIniRol+RolEnUso+listFinRolSesion;
            foreach (string opcion in _iMaster.RolesUsuario) 
                if ((opcion != null) && (opcion != RolEnUso)){
                        Respuesta+=listIniSesion ;
                        Respuesta+=System.Web.VirtualPathUtility.ToAbsolute(
                            RecursosInterfazMaster.direccionMaster_Inicio+"?"+RecursosInterfazMaster.sessionRol+"="+cripto.EncriptarCadenaDeCaracteres(opcion,des));
                        Respuesta+=listFinSesion+opcion+listFinRolSesion;
                }
            _iMaster.RolesEtq = Respuesta;
        }
   
        public void imagenSet(String imagen)
        {
            if (imagen == "")
            {
                imagen = RecursosInterfazMaster.imageDefault;
            }
            _iMaster.ImagenUsuarioEtq = imagen;
            _iMaster.ImagenTagEtq = imagen;
        }

        public void LogOut()
        {
            String Respuesta = "";
            Respuesta += logoutIni + System.Web.VirtualPathUtility.ToAbsolute(
                RecursosInterfazMaster.direccionMaster_Inicio+"?"+RecursosInterfazMaster.sessionRol+"="+RecursosInterfazMaster.sessionLogout);
            Respuesta += logoutMed + RecursosInterfazMaster.LogOutText + logoutFin;
            _iMaster.LogoutEtq = Respuesta;
        }

        /// <summary>
        /// Se realizan la asignacion de los datos de usuario a la plantilla (nombre,apellido, roles etc)
        /// </summary>
        public void asignarUsuario()
        {
            LogOut();
            string imagen = HttpContext.Current.Session[RecursosInterfazMaster.sessionImagen].ToString();
            String RolEnUso = HttpContext.Current.Session[RecursosInterfazMaster.sessionRol].ToString();
            String RolesUsuario = HttpContext.Current.Session[RecursosInterfazMaster.sessionRoles].ToString();
            String NombreUsuario= (string)HttpContext.Current.Session[RecursosInterfazMaster.sessionUsuarioNombre];
            String NombreCompleto=(string)HttpContext.Current.Session[RecursosInterfazMaster.sessionUsuarioNombre];
            imagenSet(imagen);
            _iMaster.NombreEtq = NombreUsuario;
            _iMaster.NombreTagEtq = NombreCompleto;
            string[] roles = RolesUsuario.Split(char.Parse(RecursosInterfazMaster.splitRoles));
            int cont = 0;
            foreach (string perfil in roles)
            {
                _iMaster.RolesUsuario[cont] = perfil;
                cont++;
            }
            string rol = cripto.DesencriptarCadenaDeCaracteres
                  (HttpContext.Current.Request.QueryString[RecursosInterfazMaster.sessionRol], RecursosLogicaModulo2.claveDES);


                if (rol != null)
                {
                    HttpContext.Current.Session[RecursosInterfazMaster.sessionRol] = rol;
                }

        }

        /// <summary>
        /// Metodo para el boto Sing Out de la tabla de usuario
        /// </summary>
        public void validarSesion()
        {
            if (HttpContext.Current.Request.QueryString[RecursosInterfazMaster.sessionRol] == RecursosInterfazMaster.sessionLogout)
            {
                HttpContext.Current.Session.Remove(RecursosInterfazMaster.sessionRol);
                HttpContext.Current.Session.Remove(RecursosInterfazMaster.sessionRoles);
                HttpContext.Current.Session.Remove(RecursosInterfazMaster.sessionUsuarioID);
                HttpContext.Current.Session.Remove(RecursosInterfazMaster.sessionUsuarioNombre);
                HttpContext.Current.Session.Remove(RecursosInterfazMaster.sessionImagen);
                HttpContext.Current.Response.Redirect(RecursosInterfazMaster.direccionM1_Index);
            }
        }
    }
}
