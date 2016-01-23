using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DatosSKD.Fabrica;
using DatosSKD.InterfazDAO.Modulo3;
using DominioSKD;
using ExcepcionesSKD;

namespace LogicaNegociosSKD.Comandos.Modulo3
{
    public class EjecutarModificarOrganizacion : Comando<bool>
    {
        public EjecutarModificarOrganizacion(Entidad nuevaEntidad)
            : base()
        {
            this.LaEntidad = nuevaEntidad;
        }

        /// <summary>
        /// Método Ejecutar el Modificar una Organizacion en especifico
        /// </summary>
        /// <param name="nuevaEntidad">Id de la Organizacion a consultar</param>
        /// <returns>true si modifica, false si no</returns>
        public override bool Ejecutar()
        {
            Logger.EscribirInfo(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, RecursosComandosModulo3.MensajeInicioInfoLogger, System.Reflection.MethodBase.GetCurrentMethod().Name);

            try { 

            IDaoOrganizacion miDaoOrganizacion = FabricaDAOSqlServer.ObtenerDaoOrganizacion();
            miDaoOrganizacion.Modificar(this.LaEntidad);

            Logger.EscribirInfo(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, RecursosComandosModulo3.MensajeFinInfoLogger, System.Reflection.MethodBase.GetCurrentMethod().Name);

            return false;

            }
            catch (ExcepcionesSKD.ExceptionSKDConexionBD ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);

                throw ex;
            }
            catch (ExcepcionesSKD.Modulo3.FormatoIncorrectoException ex)
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
