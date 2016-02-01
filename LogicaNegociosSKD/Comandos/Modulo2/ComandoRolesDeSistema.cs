using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DominioSKD.Entidades.Modulo2;
using DatosSKD.InterfazDAO.Modulo2;
using DatosSKD.Fabrica;

namespace LogicaNegociosSKD.Comandos.Modulo2
{
    public class ComandoRolesDeSistema:Comando<List<Rol>>
    {
        /// <summary>
        /// Se cargan los roles de sistema al comboBox
        /// </summary>
        public override List<Rol> Ejecutar()
        {
            FabricaDAOSqlServer laFabrica = new FabricaDAOSqlServer();
            IDaoRoles conexionBD = laFabrica.ObtenerDaoRoles(); ;
            List<Rol> roles = conexionBD.ConsultarTodos().Cast<Rol>().ToList();
            return roles;

        }
    }
}
