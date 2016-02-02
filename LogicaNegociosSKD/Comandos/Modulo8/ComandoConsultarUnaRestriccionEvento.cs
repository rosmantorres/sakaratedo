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
    public class ComandoConsultarUnaRestriccionEvento : Comando<DominioSKD.Entidad>
    {
        private Entidad parametro;

        public Entidad Parametro
        {
            get { return parametro; }
            set { parametro = value; }
        }

        public ComandoConsultarUnaRestriccionEvento(Entidad nuevaEntidad) 
            :base()
        {
            this.LaEntidad = nuevaEntidad;
        }

        public override DominioSKD.Entidad Ejecutar()
        {
            DominioSKD.Entidad resultado;

            DatosSKD.Fabrica.FabricaDAOSqlServer fabricaDAO = new DatosSKD.Fabrica.FabricaDAOSqlServer();


            try
            {
                IDaoRestriccionEvento daoRestriccionEvento = DatosSKD.Fabrica.FabricaDAOSqlServer.ObtenerDAORestriccionEvento();
                resultado = daoRestriccionEvento.ConsultarRestriccionEvento(this.LaEntidad);

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
