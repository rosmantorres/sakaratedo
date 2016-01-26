using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Threading.Tasks;
using System.Web.UI.WebControls;
using Interfaz_Contratos.Modulo2;
using Interfaz_Presentadores.Master;
using Interfaz_Presentadores.Modulo1;
using LogicaNegociosSKD.Fabrica;
using LogicaNegociosSKD.Comandos.Modulo2;
using DominioSKD.Fabrica;
using DominioSKD.Entidades.Modulo2;
using DominioSKD.Entidades.Modulo1;
using DominioSKD;

namespace Interfaz_Presentadores.Modulo2
{
    public class PresentadorM2
    {
        #region variables
        private string rolID = "";
        private int rolSelected = 0;
        private int cont = 0;
        private HiddenField Hidden = new HiddenField();
        private Encriptacion cripto = new Encriptacion();
        private String idUsuarioURL;

        private IContratoM2 _iMaster;
        private ValidacionesM2 validaciones = new ValidacionesM2();
        private FabricaComandos laFabrica = new FabricaComandos();
        private static FabricaEntidades laFabricaE = new FabricaEntidades();
        private Cuenta cuenta = (Cuenta)laFabricaE.ObtenerCuenta_M1();
        private Cuenta cuentaComando = (Cuenta)laFabricaE.ObtenerCuenta_M1();
        private Rol rolComando = (Rol)laFabricaE.ObtenerRol_M2();

        private List<Entidad> losRolesDeSistema = laFabricaE.ObtenerListaRol_M2();
        private List<Entidad> rolesDePersona = laFabricaE.ObtenerListaRol_M2();
        private List<Entidad> rolSinPermiso = laFabricaE.ObtenerListaRol_M2();
        private List<Entidad> rolesFiltrados = laFabricaE.ObtenerListaRol_M2();//los roles que el usuario aun no tiene permiso
        
        private String InfoRol=RecursosInterfazPresentadorM2.InfoRol;
        private String EliminarRolEtq=RecursosInterfazPresentadorM2.EliminarRolEtq;
        private String AgregarRolEtq=RecursosInterfazPresentadorM2.AgregarRolEtq;
        private String RolFinEtq = RecursosInterfazPresentadorM2.RolFinEtq;
        private String tdIni=RecursosInterfazPresentadorM2.tdIni;
        private String tdFin=RecursosInterfazPresentadorM2.tdFin;
        private String trInfoIni=RecursosInterfazPresentadorM2.trInfoIni;
        private String trIni=RecursosInterfazPresentadorM2.trIni;
        private String trFin=RecursosInterfazPresentadorM2.trFin;
        #endregion

        public void RolesUsuario(List<Entidad> Roles,String tipo){
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
            _iMaster.NombreUsuaurioEtq = cuenta.Nombre_usuario;
            _iMaster.NombreApellidoEtq = cuenta.PersonaUsuario._Nombre + " " + cuenta.PersonaUsuario._Apellido;
        }
        public void inicio()
        {

            try
            {
                _iMaster.RolesUsuario = "";
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
                        cuentaComando.Id = int.Parse(idUsuarioURL);
                        ComandoCuentaUsuario cuentaConsultada = (ComandoCuentaUsuario)laFabrica.ObtenerCuentaUsuario();
                        cuentaConsultada.LaEntidad = cuentaComando;
                        cuenta =(Cuenta)cuentaConsultada.Ejecutar();
                        rolesDePersona = cuenta.Roles.Cast<Entidad>().ToList();
                    }
                    List<Entidad> rolesDePersonaE = rolesDePersona.Cast<Entidad>().ToList();
                    rolSinPermiso = validaciones.rolNoEditable(rolesDePersonaE,
                            HttpContext.Current.Session[RecursosInterfazMaster.sessionRol].ToString());
                    rolesDePersona = validaciones.validarPrioridad(rolesDePersona,
                        HttpContext.Current.Session[RecursosInterfazMaster.sessionRol].ToString());
                    ComandoRolesDeSistema rolesSistema = (ComandoRolesDeSistema)laFabrica.ObtenerRolesDeSistema();
                    losRolesDeSistema = rolesSistema.Ejecutar();
                    rolesFiltrados = validaciones.filtrarRoles(rolesDePersona, losRolesDeSistema);
                    rolesFiltrados = validaciones.validarPrioridad(rolesFiltrados,
                        HttpContext.Current.Session[RecursosInterfazMaster.sessionRol].ToString());

                    //asigno la imagen del perfil
                    if (cuenta.Imagen == "")
                        _iMaster.ImagenEtqSRC = RecursosInterfazPresentadorM2.imgDefault;
                    else
                        _iMaster.ImagenEtqSRC= _iMaster.ImagenEtqSRC + cuenta.Imagen;

                }
                else
                {
                    HttpContext.Current.Response.Redirect(RecursosInterfazMaster.direccionMaster_Inicio);
                }

                RolesUsuario(rolSinPermiso,RecursosInterfazPresentadorM2.informacionCat);
                RolesUsuario(rolesDePersona, RecursosInterfazPresentadorM2.eliminarCat);
                RolesUsuario(rolesFiltrados, RecursosInterfazPresentadorM2.agregarCat);

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
                ComandoEliminarRol eliminarRol = (ComandoEliminarRol)laFabrica.ObtenerEliminarRol();
                cuentaComando.Id = int.Parse(idUsuarioURL);
                rolComando.Id=int.Parse(_iMaster.RolSelectEqt);
                cuentaComando.Roles.Clear();
                cuentaComando.Roles.Add(rolComando);
                eliminarRol.LaEntidad = cuentaComando;
                eliminarRol.Ejecutar();
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
                ComandoAgregarRol agregarRol = (ComandoAgregarRol)laFabrica.ObtenerAgregarRol();
                cuentaComando.Id = int.Parse(idUsuarioURL);
                rolComando.Id = int.Parse(_iMaster.RolSelectEqt);
                cuentaComando.Roles.Clear();
                cuentaComando.Roles.Add(rolComando);
                agregarRol.LaEntidad = cuentaComando;
                agregarRol.Ejecutar();
                HttpContext.Current.Response.Redirect(HttpContext.Current.Request.RawUrl);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }
    }
}
