using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DatosSKD.Modulo2;
using System.Collections.Generic;
using DominioSKD;
using System.Data;
using ExcepcionesSKD;

namespace LogicaNegociosSKD.Modulo2
{
    public class logicaRol
    {
        /// <summary>
        /// Se cargan los roles de sistema al comboBox
        /// </summary>
        public static List<Rol> cargarRoles()
        {
            BDRoles conexionBD = new BDRoles();
            List<Rol> roles = conexionBD.ObtenerRolesDeSistema();
            return roles;

        }
        /// <summary>
        /// elimina un rol del usuario  conexion con datos
        /// </summary>
        /// <param name="idUsuario">id del usuario que se le eliminara el rol</param>
        /// <param name="idRol">id del rol a eliminar</param>
        /// <returns> true si  se pudo eliminar false si no se pudo eliminar el rol</returns>
        public static bool eliminarRol(String idUsuario, String idRol)
        {
            try
            {
                BDRoles conexionBD = new BDRoles();
                conexionBD.EliminarRol(idUsuario, idRol);
                return true;
            }
            catch (Exception e)
            {
                throw new ExcepcionesSKD.Modulo2.RolesException(RecursosLogicaModulo2.Codigo_Error_EliminarRol,
                          RecursosLogicaModulo2.Mensaje_Error_EliminarRol, e);
            }
        }
        /// <summary>
        /// agrega un rol al usuario  conexion con datos
        /// </summary>
        /// <param name="idUsuario">id del usuario que se le Agregar el rol</param>
        /// <param name="idRol">id del rol a Agregar</param>
        /// <returns> true si  se pudo Agregar false si no se pudo Agregar el rol</returns>
        public static bool agregarRol(String idUsuario, String idRol)
        {
            try
            {
                BDRoles conexionBD = new BDRoles();
                conexionBD.AgregarRol(idUsuario, idRol);
                return true;
            }
            catch (Exception e)
            {
                throw new ExcepcionesSKD.Modulo2.RolesException(RecursosLogicaModulo2.Codigo_Error_AgregarRol,
                         RecursosLogicaModulo2.Mensaje_Error_AgregarRol, e);
            }
        }
        /// <summary>
        ///  lista los roles del usuario con sus respectivos atributos
        /// </summary>
        /// <param name="idUsuario">id del usuario que le consultaran los roles</param>
        /// <returns> lista de roles del usuario con sus respectivos atributos</returns>
        public static List<Rol> consultarRolesUsuario(string idUsuario)
        {
            try
            {
                BDRoles conexionBD = new BDRoles();
                return conexionBD.consultarRolesUsuario(idUsuario);
            }
            catch (Exception e)
            {
                throw new ExcepcionesSKD.Modulo2.RolesException(RecursosLogicaModulo2.Codigo_Error_ConsultarRolUsuario,
                         RecursosLogicaModulo2.Mensaje_Error_ConsultarRolUsuario, e);
            }
        }

        /// <summary>
        /// Metodo que retorna los roles que el usuario NO tiene asignado
        /// </summary>
        /// <param name="usuarioRol">Lista de los roles que el usuario tiene asignado</param>
        /// <param name="sistemaRol">Lista de los roles de sistema</param>
        /// <returns>Lista de roles que el usuario no tiene asignado</returns>
        public static List<Rol> filtrarRoles(List<Rol> usuarioRol, List<Rol> sistemaRol)
        {
            bool diferente;
            try
            {
                List<Rol> respuesta = new List<Rol>();
                foreach (Rol rolSistema in sistemaRol)
                {
                    diferente = true;
                    foreach (Rol rolUsuario in usuarioRol)
                    {
                        if (rolSistema.Id_rol == rolUsuario.Id_rol)
                            diferente = false;
                    }
                    if (diferente)
                        respuesta.Add(rolSistema);
                }
                return respuesta;
            }
            catch (Exception e)
            {
                throw new ExcepcionesSKD.Modulo2.RolesException(RecursosLogicaModulo2.Codigo_Error_FiltrarRol,
                         RecursosLogicaModulo2.Mensaje_Error_FiltarRol, e);
            }
        }
        /// <summary>
        /// valida la prioridad del rol recibido
        /// </summary>
        /// <param name="Roles">lista de roles con sus atributos</param>
        /// <param name="usuarioRol">usuario al que se le validaran los roles</param>
        /// <returns>lista de roles del usuario con la validacion de sus prioridades</returns>
        public static List<Rol> validarPrioridad(List<Rol> Roles, string usuarioRol)
        {

            List<Rol> respuesta = new List<Rol>();
            try
            {
                foreach (Rol rol in Roles)
                {
                    if (prioridadRol(rol.Nombre) >= prioridadRol(usuarioRol))
                        respuesta.Add(rol);

                }
                return respuesta;
            }
            catch (Exception e)
            {
                throw new ExcepcionesSKD.Modulo2.RolesException(RecursosLogicaModulo2.Codigo_Error_ValidarPrioridad,
                                         RecursosLogicaModulo2.Mensaje_Error_ValidarPrioridad, e);
            }

        }

        /// <summary>
        /// Metodo que retorna la importancia del rol en una forma ascendiente, el de mayor prioridad es el numero mas bajo
        /// </summary>
        /// <param name="nombreRol"></param>
        /// <returns>La importancia del rol (Menor = Mejor).</returns>
        public static int prioridadRol(string nombreRol)
        {
            switch (nombreRol)
            {
                case "Sistema": return 1;
                case "Admin Sistema": return 1;
                case "Organización": return 2;
                case "Admin Organización": return 2;
                case "Dojo": return 3;
                case "Admin Dojo": return 3;
                case "Entrenador": return 4;
                case "Atleta": return 5;
                case "Representante": return 6;
            }
            throw new ExcepcionesSKD.Modulo2.RolesException(RecursosLogicaModulo2.Mensaje_Error_RolSinRegistro);
        }

        /// <summary>
        /// Este metodo retorna los roles que el usuario a editar posee pero que no se pueden editar por el rol de la sesión
        /// </summary>
        /// <param name="Roles"></param>
        /// <param name="usuarioRol"></param>
        /// <returns></returns>
        public static List<Rol> rolNoEditable(List<Rol> Roles, string usuarioRol)
        {

            List<Rol> respuesta = new List<Rol>();
            try
            {
                foreach (Rol rol in Roles)
                {
                    if (prioridadRol(rol.Nombre) < prioridadRol(usuarioRol))
                        respuesta.Add(rol);

                }
                return respuesta;
            }
            catch (Exception e)
            {
                throw new ExcepcionesSKD.Modulo2.RolesException(RecursosLogicaModulo2.Codigo_Error_RolNoEditable,
                                                        RecursosLogicaModulo2.Mensaje_Error_RolNoEditable, e);
            }

        }
        /// <summary>
        /// Retorna un usuario por su ID sin su contraseña
        /// </summary>
        /// <param name="id_usuario">ID del usuario a consultar</param> 
        /// <returns>Cuenta de usuario sin contraseña</returns>
        public static Cuenta cuentaAConsultar(int idUsuario)
        {
            try
            {

                BDRoles conexionBD = new BDRoles();
                return conexionBD.ObtenerUsuario(idUsuario);
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
