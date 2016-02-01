using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DominioSKD;
using ExcepcionesSKD;
using DatosSKD.Fabrica;
using DatosSKD.InterfazDAO.Modulo5;

namespace LogicaNegociosSKD.Comandos.Modulo5
{
    public class EjecutarModificarStatusCinta : Comando<bool>
    {
        public EjecutarModificarStatusCinta(Entidad nuevaEntidad)
            : base()
        {
            this.LaEntidad = nuevaEntidad;
        }

        /// <summary>
        /// Método Ejecutar el Modificar el status de una Cinta en especifico
        /// </summary>
        /// <param name="nuevaEntidad">Id de la Cinta a consultar</param>
        /// <returns>true si modifica, false si no</returns>
        public override bool Ejecutar()
        {
            Logger.EscribirInfo(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, RecursosComandosModulo5.MensajeInicioInfoLogger, System.Reflection.MethodBase.GetCurrentMethod().Name);

            try
            {

                IDaoCinta miDaoCinta = FabricaDAOSqlServer.ObtenerDaoCinta();
                miDaoCinta.ModificarStatus(this.LaEntidad);

                Logger.EscribirInfo(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, RecursosComandosModulo5.MensajeFinInfoLogger, System.Reflection.MethodBase.GetCurrentMethod().Name);

                return true;


            }
            catch (ExcepcionesSKD.ExceptionSKDConexionBD ex)
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
