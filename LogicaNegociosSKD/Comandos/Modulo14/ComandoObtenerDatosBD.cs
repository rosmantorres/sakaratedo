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
    public class ComandoObtenerDatosBD : Comando<List<String>>
    {
        /// <summary>Para obtener los datos de la bd</summary>
        /// <returns>Regresa una lista con los datos</returns>
        public override List<String> Ejecutar()
        {
            List<String> listaDatos = new List<String>();

            try
            {
                IDaoPlanilla BaseDeDatoPlanilla = FabricaDAOSqlServer.ObtenerDAOPlanilla();
                listaDatos = BaseDeDatoPlanilla.ObtenerDatosBD();
               
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
            return listaDatos;
        }
    }
}
