using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DatosSKD.InterfazDAO.Modulo8;
using DominioSKD;
using System.Data.SqlClient;
using DatosSKD.Fabrica;


namespace LogicaNegociosSKD.Comandos.Modulo8
{
    public class ComandoConsultarTodasLasCompetenciasNoAsociadas : Comando<List<DominioSKD.Entidad>>
    {
        private Entidad RestriccionCompetencia;

        public Entidad LaRestriccionCompetencia
        {
            get { return RestriccionCompetencia; }
            set { RestriccionCompetencia = value; }
        }
        public override List<DominioSKD.Entidad> Ejecutar()
        {
            List<DominioSKD.Entidad> resultado;

            DatosSKD.Fabrica.FabricaDAOSqlServer fabricaDAO = new DatosSKD.Fabrica.FabricaDAOSqlServer();


            FabricaDAOSqlServer fabrica = new FabricaDAOSqlServer();

            IDaoRestriccionCompetencia daoRestriccionCompetencia = DatosSKD.Fabrica.FabricaDAOSqlServer.ObtenerDAORestriccionCompetencia();

            try
            {

                resultado = daoRestriccionCompetencia.ConsultarTodasLasCompetenciasNoAsociadas(this.RestriccionCompetencia);

            }
            catch (SqlException ex)
            {
                throw ex;
            }
            catch (FormatException ex)
            {
                throw ex;
            }
            catch (ExcepcionesSKD.ExceptionSKDConexionBD ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return resultado;

        }

    }
}
