using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DatosSKD.InterfazDAO.Modulo8;
using DominioSKD;
using DatosSKD.Fabrica;
using ExcepcionesSKD;
using System.Data.SqlClient;

namespace LogicaNegociosSKD.Comandos.Modulo8
{
    public class ComandoAgregarRestriccionEvento : Comando<Boolean>
    {
        private Entidad parametro;

        public Entidad Parametro
        {
            get { return parametro; }
            set { parametro = value; }
        }

        public ComandoAgregarRestriccionEvento(Entidad nuevaEntidad)
            : base()
        {
            this.LaEntidad = nuevaEntidad;
        }

        public override Boolean Ejecutar()
        {

            try
            {
                FabricaDAOSqlServer fabrica = new FabricaDAOSqlServer();
                IDaoRestriccionEvento miRestCintaDAO = DatosSKD.Fabrica.FabricaDAOSqlServer.ObtenerDAORestriccionEvento();

                miRestCintaDAO.AgregarRestriccionEvento(this.LaEntidad);

                return true;

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

        }
    }
}
