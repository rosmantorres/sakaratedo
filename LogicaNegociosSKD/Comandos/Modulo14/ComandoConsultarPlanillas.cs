using DatosSKD.DAO.Modulo14;
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
    public class ComandoConsultarPlanillas : Comando<List<Entidad>>
    {
        public override List<Entidad> Ejecutar()
        {
            
            try
            {
                DaoPlanilla dao = (DaoPlanilla)FabricaDAOSqlServer.ObtenerDAOPlanilla();
                List<Entidad> listaplanilla = new List<Entidad>();
                listaplanilla = dao.ConsultarPlanillasCreadas();
                dao.LimpiarSQLConnection();
                foreach (DominioSKD.Entidades.Modulo14.Planilla planilla in listaplanilla)
                {
                    planilla.Dato = dao.ObtenerDatosPlanillaID1(planilla.ID);
                    dao.LimpiarSQLConnection();
                }
                return listaplanilla;
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
