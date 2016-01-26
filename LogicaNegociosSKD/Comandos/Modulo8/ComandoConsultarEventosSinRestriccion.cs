using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DatosSKD.InterfazDAO.Modulo8;
using DominioSKD;
using DatosSKD.DAO.Modulo8;
using ExcepcionesSKD;
using System.Data.SqlClient;

namespace LogicaNegociosSKD.Comandos.Modulo8
{
    public class ComandoConsultarEventosSinRestriccion : Comando<List<DominioSKD.Entidad>>
    {
        private Entidad RestriccionEvento;

        public Entidad LaRestriccionCompetencia
        {
            get { return RestriccionEvento; }
            set { RestriccionEvento = value; }
        }
        public override List<DominioSKD.Entidad> Ejecutar()
        {
            List<DominioSKD.Entidad> resultado;

            DatosSKD.Fabrica.FabricaDAOSqlServer fabricaDAO = new DatosSKD.Fabrica.FabricaDAOSqlServer();                    

            try
            {
                IDaoRestriccionEvento daoRestriccionEvento = DatosSKD.Fabrica.FabricaDAOSqlServer.ObtenerDAORestriccionEvento();
                resultado = daoRestriccionEvento.ConsultarEventosSinRestriccion();

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
