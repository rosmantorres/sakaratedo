using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Threading.Tasks;
using LogicaNegociosSKD.Modulo2;
using DominioSKD;
using System.Web.UI.WebControls;
using Interfaz_Contratos.Modulo2;
using Interfaz_Presentadores.Master;
using Interfaz_Presentadores.Modulo1;

namespace Interfaz_Presentadores.Modulo2
{
    public class PresentadorM2
    {
        public List<Rol> losRolesDeSistema = new List<Rol>();
        public List<Rol> rolesDePersona = new List<Rol>();
        public List<Rol> rolesFiltrados = new List<Rol>();//los roles que el usuario aun no tiene permiso
        public string rolID = "";
        public int rolSelected = 0;
        public int cont = 0;
        public HiddenField Hidden = new HiddenField();
        public List<Rol> rolSinPermiso = new List<Rol>();
        public Cuenta cuentaConsultada = new Cuenta();
        public AlgoritmoDeEncriptacion cripto = new AlgoritmoDeEncriptacion();
        public String idUsuarioURL;
        private IContratoM2 _iMaster;
        private String InfoRol="<a title='Info' class='btn btn-info glyphicon glyphicon-info-sign 'data-toggle='modal' "+
                               "data-target='#modal-info' data-id='";
        private String EliminarRolEtq="<a title='Eliminar' class='btn btn-danger glyphicon glyphicon-remove-sign botonRol' "+
                       "data-toggle='modal' data-target='#modal-delete' data-id='";
        private String AgregarRolEtq="<a title='Añadir' class='btn btn-success glyphicon glyphicon-plus-sign botonRol' "+
                                     "data-toggle='modal' data-target='#modal-create' data-id='";
        private String RolFinEtq = "' href='#'></a>";
        private String tdIni="<td>";
        private String tdFin="</td>";
        private String trInfoIni="<tr style='background: rgb(224, 235, 235);'>";
        private String trIni="<tr>";
        private String trFin="</tr>";


        public void RolesUsuario(List<Rol> Roles,String tipo){
            String respuesta="";
            String RolEtq="";
            String trInicial=trIni;
            switch(tipo){
                case "Info":RolEtq=InfoRol; trInicial=trInfoIni;break;
                case "Agregar": RolEtq=AgregarRolEtq;break;
                case "Eliminar":RolEtq=EliminarRolEtq;break;
            }
            foreach(Rol rol in Roles){
                _iMaster.RolesUsuario+=trInicial;
                _iMaster.RolesUsuario += tdIni + rol.Nombre + tdFin + tdIni + rol.Descripcion + tdFin + tdIni + rol.Fecha_creacion.ToString() + tdFin;
                _iMaster.RolesUsuario += tdIni + RolEtq + rol.Id_rol + RolFinEtq + tdFin + trFin;
            }
            if (respuesta != "") 
            _iMaster.RolesUsuario += respuesta;
        }

        public PresentadorM2(IContratoM2 iMaster)
        {
            _iMaster = iMaster;

        }
        public void SetEtiquetas()
        {
            _iMaster.NombreUsuaurioEtq = cuentaConsultada.Nombre_usuario;
            _iMaster.NombreApellidoEtq = cuentaConsultada.PersonaUsuario._Nombre + " " + cuentaConsultada.PersonaUsuario._Apellido;
        }
        public void inicio()
        {

            try
            {

                String rolUsuario = HttpContext.Current.Session[RecursosInterfazMaster.sessionRol].ToString();
                Boolean permitido = false;
                List<String> rolesPermitidos = new List<string>
                    (new string[] { RecursosInterfazMaster.rolSistema, RecursosInterfazMaster.rolDojo });
                foreach (String rol in rolesPermitidos)
                {
                    if (rol == rolUsuario)
                        permitido = true;
                }
                if (permitido)
                {

                    if (HttpContext.Current.Request.QueryString[RecursosInterfazPresentadorM2.parametroIDUsuario] != null)
                    {
                        idUsuarioURL = cripto.DesencriptarCadenaDeCaracteres
                             (HttpContext.Current.Request.QueryString[RecursosInterfazPresentadorM2.parametroIDUsuario], RecursosLogicaModulo2.claveDES);

                        rolesDePersona = logicaRol.consultarRolesUsuario(idUsuarioURL);
                        cuentaConsultada =
                        logicaRol.cuentaAConsultar(int.Parse(idUsuarioURL));
                        rolesDePersona = cuentaConsultada.Roles;
                    }

                    rolSinPermiso = logicaRol.rolNoEditable(rolesDePersona,
                            HttpContext.Current.Session[RecursosInterfazMaster.sessionRol].ToString());
                    rolesDePersona = logicaRol.validarPrioridad(rolesDePersona,
                        HttpContext.Current.Session[RecursosInterfazMaster.sessionRol].ToString());

                    losRolesDeSistema = logicaRol.cargarRoles();
                    rolesFiltrados = logicaRol.filtrarRoles(rolesDePersona, losRolesDeSistema);
                    rolesFiltrados = logicaRol.validarPrioridad(rolesFiltrados,
                        HttpContext.Current.Session[RecursosInterfazMaster.sessionRol].ToString());

                    //asigno la imagen del perfil
                    if (cuentaConsultada.Imagen == "")
                        _iMaster.ImagenEtqSRC = "../../dist/img/AvatarSKD.jpg";
                    else
                        _iMaster.ImagenEtqSRC= _iMaster.ImagenEtqSRC + cuentaConsultada.Imagen;

                }
                else
                {
                    HttpContext.Current.Response.Redirect(RecursosInterfazMaster.direccionMaster_Inicio);
                }

                RolesUsuario(rolSinPermiso,"Info");
                RolesUsuario(rolesDePersona, "Eliminar");
                RolesUsuario(rolesFiltrados, "Agregar");

            }
            catch (NullReferenceException ex)
            {
                HttpContext.Current.Response.Redirect(RecursosInterfazPresentadorM1.direccionM1_Index);
            }
        }
        
        public void EliminarRol()
        {
            try
            {

                logicaRol.eliminarRol(idUsuarioURL, _iMaster.RolSelectEqt);
                HttpContext.Current.Response.Redirect(HttpContext.Current.Request.RawUrl);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }

        }

        public void AgregarRol()
        {
            try
            {
                logicaRol.agregarRol(idUsuarioURL, _iMaster.RolSelectEqt);
                HttpContext.Current.Response.Redirect(HttpContext.Current.Request.RawUrl);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }
    }
}
