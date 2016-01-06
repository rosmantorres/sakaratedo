using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DatosSKD.InterfazDAO.Modulo8;

namespace LogicaNegociosSKD.Comandos.Modulo8
{
    public class ComandoEliminarListaCompetenciaRestriccionCompetencia : Comando<DominioSKD.Entidad>
    {

        public override Boolean Ejecutar(DominioSKD.Entidad RestriccionCompetencia, List<DominioSKD.Entidad> listaCompetencias)
        {
            Boolean resultado = false;

            DatosSKD.Fabrica.FabricaDAOSqlServer fabricaDAO = new DatosSKD.Fabrica.FabricaDAOSqlServer();

            IDaoRestriccionCompetencia daoRestriccionCompetencia = fabricaDAO.ObtenerDAORestriccionCompetencia();

            try
            {

                resultado = daoRestriccionCompetencia.EliminarListaCompetenciaRestriccionCompetencia(RestriccionCompetencia, listaCompetencias);

            }
            catch (Exception ex)
            {

                throw ex;

            }

            return resultado;

        }

    }
}
