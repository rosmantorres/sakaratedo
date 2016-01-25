using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DatosSKD.InterfazDAO.Modulo8;
using DominioSKD;

namespace LogicaNegociosSKD.Comandos.Modulo8
{
    public class ComandoConsultarTodosRestriccionCompetencia : Comando<List<Entidad>>
    {

        
        public override List<Entidad> Ejecutar()
        {
            List<Entidad> resultado = new List<Entidad>();

            DatosSKD.Fabrica.FabricaDAOSqlServer fabricaDAO = new DatosSKD.Fabrica.FabricaDAOSqlServer();

            IDaoRestriccionCompetencia daoRestriccionCompetencia = fabricaDAO.ObtenerDAORestriccionCompetencia();

            try
            {

                resultado = daoRestriccionCompetencia.ConsultarTodos();

            }
            catch (Exception ex)
            {

                throw ex;

            }

            return resultado;

        }


    }
}
