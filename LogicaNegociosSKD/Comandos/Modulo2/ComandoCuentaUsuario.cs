using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DominioSKD;
using DatosSKD.InterfazDAO.Modulo2;
using DatosSKD.Fabrica;

namespace LogicaNegociosSKD.Comandos.Modulo2
{
    public class ComandoCuentaUsuario:Comando<Entidad>
    {
        /// <summary>
        /// Retorna un usuario por su ID sin su contraseña
        /// </summary>
        /// <returns>Cuenta de usuario sin contraseña</returns>
        public override Entidad Ejecutar()
        {
            try
            {
                FabricaDAOSqlServer laFabrica = new FabricaDAOSqlServer();
                IDaoRoles conexionBD = laFabrica.ObtenerDaoRoles();
                return conexionBD.ConsultarXId(LaEntidad);
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
