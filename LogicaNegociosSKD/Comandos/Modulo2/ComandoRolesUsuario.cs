using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DominioSKD.Entidades.Modulo2;
using DominioSKD.Entidades.Modulo1;
using DatosSKD.Fabrica;
using DatosSKD.InterfazDAO.Modulo2;


namespace LogicaNegociosSKD.Comandos.Modulo2
{
    public class ComandoRolesUsuario: Comando<List<Rol>>
    {
        /// <summary>
        ///  lista los roles del usuario con sus respectivos atributos
        /// </summary>
        /// <returns> lista de roles del usuario con sus respectivos atributos</returns>
        public override List<Rol> Ejecutar()
        {
            try
            {
                Cuenta cta = (Cuenta)LaEntidad;
                FabricaDAOSqlServer laFabrica = new FabricaDAOSqlServer();
                IDaoRoles conexionBD = laFabrica.ObtenerDaoRoles();
                return conexionBD.consultarRolesUsuario(cta.Id.ToString());
            }
            catch (Exception e)
            {
                throw new ExcepcionesSKD.Modulo2.RolesException(RecursosComandoModulo2.Codigo_Error_ConsultarRolUsuario,
                         RecursosComandoModulo2.Mensaje_Error_ConsultarRolUsuario, e);
            }
        }

    }
}
