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
    public class ComandoConsultarTodosRestriccionCompetencia : Comando<List<Entidad>>
    {

        private Entidad parametro;

        public Entidad Parametro
        {
            get { return parametro; }
            set { parametro = value; }
        }
        public override List<Entidad> Ejecutar()
        {
            List<Entidad> resultado = new List<Entidad>();

            DatosSKD.Fabrica.FabricaDAOSqlServer fabricaDAO = new DatosSKD.Fabrica.FabricaDAOSqlServer();

            
            try
            {

                FabricaDAOSqlServer fabrica = new FabricaDAOSqlServer();
                
                IDaoRestriccionCompetencia daoRestriccionCompetencia = DatosSKD.Fabrica.FabricaDAOSqlServer.ObtenerDAORestriccionCompetencia();
                resultado = daoRestriccionCompetencia.ConsultarTodos();

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
