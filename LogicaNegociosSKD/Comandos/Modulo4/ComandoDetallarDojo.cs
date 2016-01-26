using DatosSKD.Fabrica;
using DatosSKD.InterfazDAO.Modulo4;
using DominioSKD;
using ExcepcionesSKD;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegociosSKD.Comandos.Modulo4
{
    class ComandoDetallarDojo : Comando<Entidad>
    {
        /// <summary>
        /// /// <summary>
        /// Método que sirve de enlace entre los datos
        /// y la vista que ejecuta el detalle de un dojo
        /// </summary>
        /// <returns>retorna el dojo</returns>
        public override Entidad Ejecutar()
        {
            Logger.EscribirInfo(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name
                , RecursosComandoModulo4.MensajeInicioInfoLogger, System.Reflection.MethodBase.GetCurrentMethod().Name);
            try
            {
                IDaoDojo daoDojo = FabricaDAOSqlServer.ObtenerDAODojo();

                Logger.EscribirInfo(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name
                    , RecursosComandoModulo4.MensajeFinInfoLogger, System.Reflection.MethodBase.GetCurrentMethod().Name);
                
                return daoDojo.ConsultarXId(this.LaEntidad);
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
