using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DominioSKD;
using ExcepcionesSKD;
using DatosSKD.Fabrica;
using DatosSKD.InterfazDAO.Modulo3;

namespace LogicaNegociosSKD.Comandos.Modulo3
{
    public class EjecutarModificarStatusOrganizacion : Comando<bool>
    {
        public EjecutarModificarStatusOrganizacion(Entidad nuevaEntidad)
            : base()
        {
            this.LaEntidad = nuevaEntidad;
        }


        /// Método Ejecutar el Modificar el status de una Organizacion en especifico
        /// </summary>
        /// <param name="nuevaEntidad">Id de la Organizacion a consultar</param>
        /// <returns>true si modifica, false si no</returns>
        public override bool Ejecutar()
        {
            Logger.EscribirInfo(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, RecursosComandosModulo3.MensajeInicioInfoLogger, System.Reflection.MethodBase.GetCurrentMethod().Name);

            try
            {

                IDaoOrganizacion miDaoOrganizacion = FabricaDAOSqlServer.ObtenerDaoOrganizacion();
                miDaoOrganizacion.ModificarStatus(this.LaEntidad);

                Logger.EscribirInfo(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, RecursosComandosModulo3.MensajeFinInfoLogger, System.Reflection.MethodBase.GetCurrentMethod().Name);

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
