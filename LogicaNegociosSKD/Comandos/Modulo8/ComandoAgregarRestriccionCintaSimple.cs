using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DatosSKD.InterfazDAO.Modulo8;
using DominioSKD;
using DatosSKD.Fabrica;
using ExcepcionesSKD;
using System.Data;
using System.Data.SqlClient;


namespace LogicaNegociosSKD.Comandos.Modulo8
{
    public class ComandoAgregarRestriccionCintaSimple : Comando<Boolean>
    {

        private Entidad parametro;

        public Entidad Parametro
        {
            get { return parametro; }
            set { parametro = value; }
        }

        public ComandoAgregarRestriccionCintaSimple(Entidad nuevaEntidad)
            : base()
        {
            this.LaEntidad = nuevaEntidad;
        }

        public override Boolean Ejecutar()
        {
            try
            {
                FabricaDAOSqlServer fabrica = new FabricaDAOSqlServer();
                IDaoRestriccionCinta miRestCintaDAO = DatosSKD.Fabrica.FabricaDAOSqlServer.ObtenerDAORestriccionCinta();
                miRestCintaDAO.AgregarRestriccionCintaSimple(this.LaEntidad);
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
