using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DatosSKD.Modulo2;
using System.Collections.Generic;
using DominioSKD;
using System.Data;

namespace LogicaNegociosSKD.Modulo2
{
    public class logicaRol
    {
        /// <summary>
        /// Se cargan los roles de sistema al comboBox
        /// </summary>
        public static List<Rol> cargarRoles()
        {
            /*
            respuesta = RecursosLogicaModulo2.etiquetaAperturaDropDawn;
            respuesta = respuesta + RecursosLogicaModulo2.subEtiquetaSeleccionar;
            List<Rol> roles=BDRoles.ObtenerRolesDeSistema();
            foreach (Rol rol in roles)
            {
                respuesta = respuesta 
                    + RecursosLogicaModulo2.subEtiquetaApertura + rol.Id_rol.ToString()
                    + RecursosLogicaModulo2.subEtiquetaCierreApertura + rol.Nombre 
                    + RecursosLogicaModulo2.subEtiquetaCierreTotal;
            }
            respuesta = respuesta + RecursosLogicaModulo2.etiquetaCierreDropDawn;
            */

            List<Rol> roles = BDRoles.ObtenerRolesDeSistema();
            return roles;

        }

        public static bool eliminarRol(String idUsuario, String idRol)
        {
            try
            {
                BDRoles.EliminarRol(idUsuario, idRol);
                return true;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public static bool agregarRol(String idUsuario, String idRol)
        {
            try
            {
            BDRoles.AgregarRol(idUsuario, idRol);
            return true;
              }
            catch (Exception e)
            {
                throw e;
            }
        }

        public static List<Rol> consultarRolesUsuario(string idUsuario)
        {
            try
            {
                return BDRoles.consultarRolesUsuario(idUsuario);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

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
                    if(diferente)
                        respuesta.Add(rolSistema);
                }
                return respuesta;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public static List<Rol> validarPrioridad(List<Rol> Roles,string usuarioRol)
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
                throw e;
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
            throw new Exception("Rol no registrado/validado en sistema: LogicaNegociosSKD.logicaRol.prioridadRol()");
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
                throw e;
            }

        }
    
    }
}
