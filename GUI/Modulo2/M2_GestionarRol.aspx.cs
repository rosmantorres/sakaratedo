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

namespace templateApp.GUI.Modulo2
{
    public partial class M2_Prueba : System.Web.UI.Page
    {

        public List<Rol> losRolesDeSistema=new List<Rol>();
        public List<Rol> rolesDePersona = new List<Rol>();
        public List<Rol> rolesFiltrados = new List<Rol>();//los roles que el usuario aun no tiene permiso
        //public Persona usuario;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openModal();", true);
                ((SKD)Page.Master).IdModulo = "2";

                if (Request.QueryString[RecursosInterfazModulo2.parametroIDUsuario] != null)
                    rolesDePersona=logicaRol.consultarRolesUsuario
                        (Request.QueryString[RecursosInterfazModulo2.parametroIDUsuario]);

                losRolesDeSistema = logicaRol.cargarRoles();//Se cargan todos los roles del sistema

                rolesFiltrados = logicaRol.filtrarRoles(rolesDePersona, losRolesDeSistema);

                RolList.Items.Clear();
                foreach (Rol rol in losRolesDeSistema)
                {
                    RolList.Items.Add(new ListItem(rol.Nombre.ToString(), rol.Id_rol.ToString()));
                }
    
            }
        }
        protected void EliminarRol(object sender, EventArgs e)
        {
            try
            {
                logicaRol.eliminarRol(Request.QueryString[RecursosInterfazModulo2.parametroIDUsuario], "1");
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
                logicaRol.agregarRol(Request.QueryString[RecursosInterfazModulo2.parametroIDUsuario],"1");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

    }
}