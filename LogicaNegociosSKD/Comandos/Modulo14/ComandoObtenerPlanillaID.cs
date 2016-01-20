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
   public class ComandoObtenerPlanillaID : Comando<Entidad>
    {

        private int idPlanilla;

        public int IdPlanilla
        {
            get { return idPlanilla; }
            set { idPlanilla = value; }
        }

        public override Entidad Ejecutar()
        {
            FabricaDAOSqlServer fabrica = new FabricaDAOSqlServer();
            FabricaEntidades fabricaEntidades = new FabricaEntidades();
            Planilla planilla = (Planilla)fabricaEntidades.ObtenerPlanilla();
            try
            {

                DaoPlanilla BaseDeDatoPlanilla = (DaoPlanilla)fabrica.ObtenerDAOPlanilla();
                
                planilla.ID = this.idPlanilla;
                Entidad entidad = BaseDeDatoPlanilla.ConsultarXId(planilla);
                BaseDeDatoPlanilla.LimpiarSQLConnection();
                planilla.Nombre = ((Planilla)entidad).Nombre;
                planilla.Dato = BaseDeDatoPlanilla.ObtenerDatosPlanillaID(idPlanilla);
               
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
            return planilla;
        }
    }
}
