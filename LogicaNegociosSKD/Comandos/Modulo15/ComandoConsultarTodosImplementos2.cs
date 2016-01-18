using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DatosSKD.Fabrica;
using DominioSKD;

namespace LogicaNegociosSKD.Comandos.Modulo15
{
    public class ComandoConsultarTodosImplementos2 : Comando<List<Entidad>>
    {

        public override List<Entidad> Ejecutar()
        {
            List<Entidad> lista = new List<Entidad>();
            try
            {
                FabricaDAOSqlServer fabrica = new FabricaDAOSqlServer();
                lista = fabrica.ObtenerDAOImplemento().ConsultarTodos();

            }
            catch (Exception ex)
            {

                throw ex;
            }
            return lista;
        }
    }
}
