using DatosSKD.DAO.Modulo14;
using DatosSKD.InterfazDAO.Modulo14;
using DatosSKD.Fabrica;
using ExcepcionesSKD;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegociosSKD.Comandos.Modulo14
{
   public class ComandoObtenerDatosPlanilla : Comando<List<String>>
    {
        private int idPlanilla;

        public int IdPlanilla
        {
            get { return idPlanilla; }
            set { idPlanilla = value; }
        }
        /// <summary>
        /// Método que devuelve una lista de sting con los datos que posee 
        /// una planilla
        /// </summary>
        /// <param name="idPlanilla">iD de la planilla de la cual se desean 
        /// saber sus datos</param>
        /// <returns>Regresa la lista con dichos datos</returns>
       public override List<String> Ejecutar()
        {
            List<String> datos;
            try
            {
                IDaoPlanilla BaseDeDatoPlanilla = FabricaDAOSqlServer.ObtenerDAOPlanilla();
                datos = BaseDeDatoPlanilla.ObtenerDatosPlanillaID(this.idPlanilla);
                
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
            return datos;
        }
    }
}
