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
    public class ComandoConsultarCintaTodas : Comando<List<DominioSKD.Entidad>>
    {

        private Entidad RestriccionCinta;

        public Entidad restriccionCinta
        {
            get { return RestriccionCinta; }
            set { RestriccionCinta = value; }
        }

        public override List<DominioSKD.Entidad> Ejecutar()
        {
            List<DominioSKD.Entidad> ListaCintas = new List<Entidad>();
            DatosSKD.Fabrica.FabricaDAOSqlServer fabricaDAO = new DatosSKD.Fabrica.FabricaDAOSqlServer();            

            try
            {
                IDaoRestriccionCinta daoRestriccionCinta = DatosSKD.Fabrica.FabricaDAOSqlServer.ObtenerDAORestriccionCinta();
                ListaCintas = daoRestriccionCinta.ConsultarCintaTodas();

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

            return ListaCintas;

        }
    }
}