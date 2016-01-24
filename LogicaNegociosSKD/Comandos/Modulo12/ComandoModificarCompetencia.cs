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
    /// Comando para modificar una competencia
    /// </summary>
    public class ComandoModificarCompetencia : Comando<bool>
    {

        /// <summary>
        /// Constructor del comando
        /// </summary>
        /// <param name="parametro">Competencia a modificar</param>
        public ComandoModificarCompetencia(Entidad entidad)
        {
            LaEntidad = entidad;
        }

        /// <summary>
        /// Metodo que ejecuta el comando
        /// </summary>
        /// <returns>booleano que refleja el exito de la ejecucion del comando</returns>
        public override bool Ejecutar()
        {
            Logger.EscribirInfo(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name
                , RecursosComandoModulo12.MensajeInicioInfoLogger, System.Reflection.MethodBase.GetCurrentMethod().Name);

            try
            {
                //FabricaDAOSqlServer laFabrica = new FabricaDAOSqlServer();
                IDaoCompetencia daoCompetencia = FabricaDAOSqlServer.ObtenerDAOCompetencia();

                Logger.EscribirInfo(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name
                    , RecursosComandoModulo12.MensajeFinInfoLogger, System.Reflection.MethodBase.GetCurrentMethod().Name);

                return daoCompetencia.Modificar(this.LaEntidad);
            }
            catch (ExcepcionesSKD.ExceptionSKDConexionBD ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);

                throw ex;
            }
            catch (ExcepcionesSKD.Modulo12.CompetenciaExistenteException ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);

                throw ex;
            }
            catch (ExcepcionesSKD.Modulo12.CompetenciaInexistenteException ex)
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
