using DatosSKD.Fabrica;
using DatosSKD.InterfazDAO.Modulo12;
using DominioSKD;
using ExcepcionesSKD;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegociosSKD.Comandos.Modulo12
{
    /// <summary>
    /// Comando para consultar cintas
    /// </summary>
    public class ComandoConsultarOrganizaciones : Comando<List<Entidad>>
    {
        /// <summary>
        /// Metodo que ejecuta el comando
        /// </summary>
        /// <returns>Lista de Entidad con las organizaciones</returns>
        public override List<Entidad> Ejecutar()
        {
            Logger.EscribirInfo(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, 
                RecursosComandoModulo12.MensajeInicioInfoLogger, System.Reflection.MethodBase.GetCurrentMethod().Name);

            try
            {
                //FabricaDAOSqlServer laFabrica = new FabricaDAOSqlServer();
                IDaoCompetencia daoCompetencia = FabricaDAOSqlServer.ObtenerDAOCompetencia();

                Logger.EscribirInfo(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name
                    , RecursosComandoModulo12.MensajeFinInfoLogger, System.Reflection.MethodBase.GetCurrentMethod().Name);

                return daoCompetencia.M12ListarOrganizaciones();
            }
            catch (ExcepcionesSKD.ExceptionSKDConexionBD ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);

                throw ex;
            }
            catch (ExcepcionesSKD.Modulo12.FormatoIncorrectoException ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);

                throw ex;
            }
            catch (ExcepcionesSKD.ExceptionSKD ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);

                throw ex;
            }

        }
    }
}
