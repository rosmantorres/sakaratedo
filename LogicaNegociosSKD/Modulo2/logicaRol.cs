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
            try
            {
                List<Rol> respuesta = new List<Rol>();
                foreach (Rol rolusuario in usuarioRol)
                {
                    foreach (Rol rolSistema in sistemaRol)
                    {
                        if (rolSistema.Id_rol == rolusuario.Id_rol)
                            respuesta.Add(rolSistema);
                    }
                }
                return sistemaRol;
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
