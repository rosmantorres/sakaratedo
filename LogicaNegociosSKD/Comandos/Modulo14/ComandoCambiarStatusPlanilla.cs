using DatosSKD.DAO.Modulo14;
using DatosSKD.InterfazDAO.Modulo14;
using DatosSKD.Fabrica;
using DominioSKD;
using DominioSKD.Fabrica;
using ExcepcionesSKD;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegociosSKD.Comandos.Modulo14
{
    public class ComandoCambiarStatusPlanilla : Comando<Boolean>
    {
        private int idPlanilla;

        public int IDPlanilla
        {
            set { idPlanilla = value; }
            get { return idPlanilla; }
        }
        /// <summary>
        /// Método que cambia el status de una planilla
        /// </summary>
        /// <param name="idPlanilla">Id de la planilla a modificar</param>
        /// <returns>Retorna True se se realizo la modificación con éxito.
        /// De lo contrario devuelve False</returns>
        public override Boolean Ejecutar()
        {
            try
            {
                IDaoPlanilla dao = FabricaDAOSqlServer.ObtenerDAOPlanilla();
                return dao.CambiarStatus(idPlanilla);
            }
            catch (ExcepcionesSKD.ExceptionSKDConexionBD ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);

                throw ex;
            }
            catch (ExcepcionesSKD.Modulo14.BDPLanillaException ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                throw ex;
            }
            catch (Exception ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                throw ex;
            }
        }
    }
}
