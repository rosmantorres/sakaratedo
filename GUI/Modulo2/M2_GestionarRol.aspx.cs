using System;
using System.Collections;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using LogicaNegociosSKD.Modulo2;
using DominioSKD;
using System.Data;
using templateApp.GUI.Master;

namespace templateApp.GUI.Modulo2
{
    public partial class M2_Prueba : System.Web.UI.Page
    {

        public List<Rol> losRolesDeSistema=new List<Rol>();
        public List<Rol> rolesDePersona = new List<Rol>();
        public List<Rol> rolesFiltrados = new List<Rol>();//los roles que el usuario aun no tiene permiso
        public string rolID = "";
        public int rolSelected = 0;
        public int cont = 0;
        public HiddenField Hidden =new HiddenField();
        public List<Rol> rolSinPermiso = new List<Rol>();
        public Cuenta cuentaConsultada ;

        //public Persona usuario;
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                String rolUsuario=Session[RecursosInterfazMaster.sessionRol].ToString();
                Boolean permitido=false;
                List<String> rolesPermitidos = new List<string>
                    (new string[] {RecursosInterfazMaster.rolSistema,RecursosInterfazMaster.rolDojo});
                foreach(String rol in rolesPermitidos){
                    if (rol == rolUsuario)
                        permitido = true;
                    }
                if (permitido)
                {

                    ((SKD)Page.Master).IdModulo = "2";

                    if (Request.QueryString[RecursosInterfazModulo2.parametroIDUsuario] != null)
                    {
                        rolesDePersona = logicaRol.consultarRolesUsuario
                            (Request.QueryString[RecursosInterfazModulo2.parametroIDUsuario]);////QUITAR ESTE PROCEDIMIENTO Y SP
                        cuentaConsultada =
                        logicaRol.cuentaAConsultar(int.Parse(Request.QueryString[RecursosInterfazModulo2.parametroIDUsuario]));
                        rolesDePersona = cuentaConsultada.Roles;
                    }

                    rolSinPermiso = logicaRol.rolNoEditable(rolesDePersona,
                            Session[RecursosInterfazMaster.sessionRol].ToString());
                    rolesDePersona = logicaRol.validarPrioridad(rolesDePersona,
                        Session[RecursosInterfazMaster.sessionRol].ToString());

                    losRolesDeSistema = logicaRol.cargarRoles();
                    rolesFiltrados = logicaRol.filtrarRoles(rolesDePersona, losRolesDeSistema);
                    rolesFiltrados = logicaRol.validarPrioridad(rolesFiltrados,
                        Session[RecursosInterfazMaster.sessionRol].ToString());

                    //asigno la imagen del perfil
                    imageTag.Src = imageTag.Src +cuentaConsultada.Imagen;

                }
                else
                {
                    Response.Redirect(RecursosInterfazMaster.direccionMaster_Inicio);
                }
             
            }
            catch (NullReferenceException ex)
            {


            }


        }
        protected void EliminarRol(object sender, EventArgs e)
        {
            try
            {
          
                logicaRol.eliminarRol(Request.QueryString[RecursosInterfazModulo2.parametroIDUsuario], RolSelect.Value);
                Response.Redirect(Request.RawUrl);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }
        protected void AgregarRol(object sender, EventArgs e)
        {
            try
            {
                logicaRol.agregarRol(Request.QueryString[RecursosInterfazModulo2.parametroIDUsuario], RolSelect.Value);
                Response.Redirect(Request.RawUrl);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

    }
}