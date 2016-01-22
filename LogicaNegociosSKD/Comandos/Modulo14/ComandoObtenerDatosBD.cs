using DatosSKD.DAO.Modulo14;
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
        public override List<String> Ejecutar()
        {
            List<String> listaDatos = new List<String>();

            try
            {
                DaoPlanilla BaseDeDatoPlanilla = (DaoPlanilla)FabricaDAOSqlServer.ObtenerDAOPlanilla();
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
