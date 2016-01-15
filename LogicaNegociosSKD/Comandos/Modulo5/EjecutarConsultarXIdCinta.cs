using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DatosSKD.Fabrica;
using DatosSKD.InterfazDAO.Modulo5;
using DominioSKD;
using ExcepcionesSKD;

namespace LogicaNegociosSKD.Comandos.Modulo5
{
    public class EjecutarConsultarXIdCinta : Comando<Entidad>
    {
        public EjecutarConsultarXIdCinta(Entidad nuevaEntidad)
            : base()
        {
            this.LaEntidad = nuevaEntidad;
        }

        /// <summary>
        /// Método Ejecutar el Consultar los Detalles de una Cinta en especifico
        /// </summary>
        /// <param name="nuevaEntidad">Id de la Cinta a consultar</param>
        /// <returns>LaCinta</returns>
        public override Entidad Ejecutar()
        {
            Logger.EscribirInfo(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, RecursosComandosModulo5.MensajeInicioInfoLogger, System.Reflection.MethodBase.GetCurrentMethod().Name);

            try { 
            FabricaDAOSqlServer fabrica = new FabricaDAOSqlServer();
            IDaoCinta miDaoCinta = fabrica.ObtenerDaoCinta(); 
            Entidad _miEntidad= miDaoCinta.ConsultarXId(this.LaEntidad);
            
            if (_miEntidad != null)
            {
                Logger.EscribirInfo(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, RecursosComandosModulo5.MensajeFinInfoLogger, System.Reflection.MethodBase.GetCurrentMethod().Name);

                return _miEntidad;
            }
            else
            {
                return null;

            }
            }
            catch (ExcepcionesSKD.ExceptionSKDConexionBD ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);

                throw ex;
            }
            catch (ExcepcionesSKD.Modulo5.FormatoIncorrectoException ex)
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
