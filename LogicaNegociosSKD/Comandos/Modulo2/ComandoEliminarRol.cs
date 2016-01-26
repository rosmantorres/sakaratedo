using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DominioSKD.Entidades.Modulo1;
using DatosSKD.Fabrica;
using DatosSKD.InterfazDAO.Modulo2;

namespace LogicaNegociosSKD.Comandos.Modulo2
{
    public class ComandoEliminarRol:Comando<Boolean>
    {
        /// <summary>
        /// elimina un rol del usuario  conexion con datos
        /// </summary>
        /// <returns> true si  se pudo eliminar false si no se pudo eliminar el rol</returns>
        public override Boolean Ejecutar()
        {
            try
            {
                FabricaDAOSqlServer laFabrica = new FabricaDAOSqlServer();
                Cuenta cta = (Cuenta)LaEntidad;
                IDaoRoles conexionBD = laFabrica.ObtenerDaoRoles();
                conexionBD.EliminarRol(cta.Id.ToString(), cta.Roles[0].Id.ToString());
                return true;
            }
            catch (Exception e)
            {
                throw new ExcepcionesSKD.Modulo2.RolesException(RecursosComandoModulo2.Codigo_Error_EliminarRol,
                          RecursosComandoModulo2.Mensaje_Error_EliminarRol, e);
            }
        }
    }
}
