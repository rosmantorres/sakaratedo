using DatosSKD.DAO.Modulo14;
using DatosSKD.InterfazDAO.Modulo14;
using DatosSKD.Fabrica;
using DominioSKD;
using ExcepcionesSKD;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegociosSKD.Comandos.Modulo14
{
    public class ComandoModificarPlanillaID : Comando<Entidad>
    {
        /// <summary>Modificar una planilla por id</summary>
        /// <param name="laPlanilla">la planilla</param>
        /// <returns>Regresa true si se modifico y false si no</returns>
        /// 
        public override Entidad Ejecutar()
        {
            DominioSKD.Entidades.Modulo14.Planilla laPlanilla =( 
                DominioSKD.Entidades.Modulo14.Planilla)this.LaEntidad;

            try
            {
                IDaoPlanilla BaseDeDatoPlanilla = FabricaDAOSqlServer.ObtenerDAOPlanilla();
                BaseDeDatoPlanilla.Modificar(laPlanilla);
                BaseDeDatoPlanilla.EliminarDatosPlanillaBD(laPlanilla.ID);
                foreach (String item in laPlanilla.Dato)
                {
                    BaseDeDatoPlanilla.RegistrarDatosPlanillaIdBD(laPlanilla.ID, item);
                }

                
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
            return laPlanilla;
        }
    }
}
