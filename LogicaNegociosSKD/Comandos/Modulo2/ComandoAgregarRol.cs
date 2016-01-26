using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DatosSKD.InterfazDAO.Modulo2;
using DatosSKD.Fabrica;
using DominioSKD.Entidades.Modulo1;

namespace LogicaNegociosSKD.Comandos.Modulo2
{
    public class ComandoAgregarRol: Comando<Boolean>
    {
        /// <summary>
        /// agrega un rol al usuario  conexion con datos
        /// </summary>
        /// <returns> true si  se pudo Agregar false si no se pudo Agregar el rol</returns>
        public override Boolean Ejecutar()
        {
            try
            {
                FabricaDAOSqlServer laFabrica = new FabricaDAOSqlServer();
                IDaoRoles conexionBD = laFabrica.ObtenerDaoRoles();
                Cuenta cta = (Cuenta)LaEntidad;
                conexionBD.AgregarRol(cta.Id.ToString(), cta.Roles[0].Id.ToString());
                return true;
            }
            catch (Exception e)
            {
                throw new ExcepcionesSKD.Modulo2.RolesException(RecursosComandoModulo2.Codigo_Error_AgregarRol,
                         RecursosComandoModulo2.Mensaje_Error_AgregarRol, e);
            }
        }
    }
}
