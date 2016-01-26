using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DominioSKD.Entidades.Modulo2;
using DominioSKD;

namespace Interfaz_Presentadores.Modulo2
{
    public class ValidacionesM2
    {

        /// <summary>
        /// Metodo que retorna los roles que el usuario NO tiene asignado
        /// </summary>
        /// <param name="usuarioRol">Lista de los roles que el usuario tiene asignado</param>
        /// <param name="sistemaRol">Lista de los roles de sistema</param>
        /// <returns>Lista de roles que el usuario no tiene asignado</returns>
        public  List<Entidad> filtrarRoles(List<Entidad> usuarioRol, List<Entidad> sistemaRol)
        {
            bool diferente;
            try
            {
                List<Entidad> respuesta = new List<Entidad>();
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
                throw new ExcepcionesSKD.Modulo2.RolesException(RecursosInterfazPresentadorM2.Codigo_Error_FiltrarRol,
                         RecursosInterfazPresentadorM2.Mensaje_Error_FiltarRol, e);
            }
        }
        /// <summary>
        /// valida la prioridad del rol recibido
        /// </summary>
        /// <param name="Roles">lista de roles con sus atributos</param>
        /// <param name="usuarioRol">usuario al que se le validaran los roles</param>
        /// <returns>lista de roles del usuario con la validacion de sus prioridades</returns>
        public List<Entidad> validarPrioridad(List<Entidad> Roles, string usuarioRol)
        {

            List<Entidad> respuesta = new List<Entidad>();
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
                throw new ExcepcionesSKD.Modulo2.RolesException(RecursosInterfazPresentadorM2.Codigo_Error_ValidarPrioridad,
                                         RecursosInterfazPresentadorM2.Mensaje_Error_ValidarPrioridad, e);
            }

        }

        /// <summary>
        /// Metodo que retorna la importancia del rol en una forma ascendiente, el de mayor prioridad es el numero mas bajo
        /// </summary>
        /// <param name="nombreRol"></param>
        /// <returns>La importancia del rol (Menor = Mejor).</returns>
        public  int prioridadRol(string nombreRol)
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
            throw new ExcepcionesSKD.Modulo2.RolesException(RecursosInterfazPresentadorM2.Mensaje_Error_RolSinRegistro);
        }

        /// <summary>
        /// Este metodo retorna los roles que el usuario a editar posee pero que no se pueden editar por el rol de la sesión
        /// </summary>
        /// <param name="Roles"></param>
        /// <param name="usuarioRol"></param>
        /// <returns></returns>
        public  List<Entidad> rolNoEditable(List<Entidad> Roles, string usuarioRol)
        {

            List<Entidad> respuesta = new List<Entidad>();
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
                throw new ExcepcionesSKD.Modulo2.RolesException(RecursosInterfazPresentadorM2.Codigo_Error_RolNoEditable,
                                                        RecursosInterfazPresentadorM2.Mensaje_Error_RolNoEditable, e);
            }

        }
    }
}
