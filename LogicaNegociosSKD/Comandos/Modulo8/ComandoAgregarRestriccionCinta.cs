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
    public class ComandoAgregarRestriccionCinta : Comando<Boolean>
    {

        private Entidad parametro;

        public Entidad Parametro
        {
            get { return parametro; }
            set { parametro = value; }
        }

        public ComandoAgregarRestriccionCinta(Entidad nuevaEntidad)
            : base()
        {
            this.LaEntidad = nuevaEntidad;
        }

        public override Boolean Ejecutar()
        {

            //Logger.EscribirInfo(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, RecursosDaoModulo5.MensajeInicioInfoLogger, System.Reflection.MethodBase.GetCurrentMethod().Name);

            try
            {
                FabricaDAOSqlServer fabrica = new FabricaDAOSqlServer();
                IDaoRestriccionCinta miRestCintaDAO = DatosSKD.Fabrica.FabricaDAOSqlServer.ObtenerDAORestriccionCinta();

                miRestCintaDAO.AgregarRestriccionCinta(this.LaEntidad);
                //Logger.EscribirInfo(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, RecursosDaoModulo5.MensajeFinInfoLogger, System.Reflection.MethodBase.GetCurrentMethod().Name);

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





            /*  Boolean resultado = false;
            
              DatosSKD.Fabrica.FabricaDAOSqlServer fabricaDAO = new DatosSKD.Fabrica.FabricaDAOSqlServer();
            
              IDaoRestriccionCinta daoRestriccionCinta = fabricaDAO.ObtenerDAORestriccionCinta();

              try
              {

                  resultado = daoRestriccionCinta.AgregarRestriccionCinta(this.parametro);
            
              }
              catch (Exception ex)
              {
                
                  throw ex;
            
              }
            
              return resultado;

          }
       */
        }
    }
}
