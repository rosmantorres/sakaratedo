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
    public class ComandoRolesDeSistema:Comando<List<Entidad>>
    {
        /// <summary>
        /// Se cargan los roles de sistema al comboBox
        /// </summary>
        public override List<Entidad> Ejecutar()
        {
            FabricaDAOSqlServer laFabrica = new FabricaDAOSqlServer();
            IDaoRoles conexionBD = laFabrica.ObtenerDaoRoles(); ;
            List<Entidad> roles = conexionBD.ConsultarTodos();
            return roles;

        }
    }
}
