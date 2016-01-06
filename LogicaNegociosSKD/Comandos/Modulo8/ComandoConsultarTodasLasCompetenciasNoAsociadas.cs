using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DatosSKD.InterfazDAO.Modulo8;

namespace LogicaNegociosSKD.Comandos.Modulo8
{
    class ComandoConsultarTodasLasCompetenciasNoAsociadas : Comando<DominioSKD.Entidad>
    {

        public override List<DominioSKD.Entidad> Ejecutar(DominioSKD.Entidad RestriccionCompetencia)
        {
            List<DominioSKD.Entidad> resultado;

            DatosSKD.Fabrica.FabricaDAOSqlServer fabricaDAO = new DatosSKD.Fabrica.FabricaDAOSqlServer();

            IDaoRestriccionCompetencia daoRestriccionCompetencia = fabricaDAO.ObtenerDAORestriccionCompetencia();

            try
            {

                resultado = daoRestriccionCompetencia.ConsultarTodasLasCompetenciasNoAsociadas(RestriccionCompetencia);

            }
            catch (Exception ex)
            {

                throw ex;

            }

            return resultado;

        }

    }
}
