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
using templateApp.GUI.Modulo1;

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
        public Cuenta cuentaConsultada =new Cuenta() ;
        public AlgoritmoDeEncriptacion cripto = new AlgoritmoDeEncriptacion();
        public String idUsuarioURL;

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
                       idUsuarioURL= cripto.DesencriptarCadenaDeCaracteres
                            (Request.QueryString[RecursosInterfazModulo2.parametroIDUsuario],RecursosLogicaModulo2.claveDES);
                    
                        rolesDePersona = logicaRol.consultarRolesUsuario(idUsuarioURL);
                        cuentaConsultada =
                        logicaRol.cuentaAConsultar(int.Parse(idUsuarioURL));
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
                    if(cuentaConsultada.Imagen=="")
                        imageTag.Src = "../../dist/img/AvatarSKD.jpg";
                    else
                        imageTag.Src = imageTag.Src +cuentaConsultada.Imagen;

                }
                else
                {
                    Response.Redirect(RecursosInterfazMaster.direccionMaster_Inicio);
                }
             
            }
            catch (NullReferenceException ex)
            {
                Response.Redirect(RecursosInterfazModulo1.direccionM1_Index);
            }


        }
        protected void EliminarRol(object sender, EventArgs e)
        {
            try
            {
          
                logicaRol.eliminarRol(idUsuarioURL, RolSelect.Value);
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
                logicaRol.agregarRol(idUsuarioURL, RolSelect.Value);
                Response.Redirect(Request.RawUrl);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

    }
}