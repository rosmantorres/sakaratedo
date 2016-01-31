using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DatosSKD.InterfazDAO.Modulo8;
using DominioSKD;
using ExcepcionesSKD.Modulo8;
using System.Data.SqlClient;
using ExcepcionesSKD;


namespace LogicaNegociosSKD.Comandos.Modulo8
{
    public class ComandoEliminarLogicoRestriccionCompetencia : Comando<Boolean>
    {
        private Entidad parametro;

        public Entidad Parametro
        {
            get { return parametro; }
            set { parametro = value; }
        }

        public ComandoEliminarLogicoRestriccionCompetencia(Entidad nuevaEntidad)
            : base()
        {
            this.parametro = nuevaEntidad;
        }
        public override Boolean Ejecutar()
        {
            Boolean resultado = false;

            DatosSKD.Fabrica.FabricaDAOSqlServer fabricaDAO = new DatosSKD.Fabrica.FabricaDAOSqlServer();

            IDaoRestriccionCompetencia daoRestriccionCompetencia = fabricaDAO.ObtenerDAORestriccionCompetencia();

            try
            {

                resultado = daoRestriccionCompetencia.EliminarLogicoRestriccionCompetencia(this.parametro);

            }
            catch (RestriccionExistenteException ex)
            {

                throw ex;

            }
            catch (SqlException ex)
            {


                throw ex;

            }
            catch (FormatException ex)
            {
                throw ex;

            }
            catch (ExceptionSKDConexionBD ex)
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
