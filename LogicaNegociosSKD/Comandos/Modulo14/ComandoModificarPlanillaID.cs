using DatosSKD.DAO.Modulo14;
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
        public override Entidad Ejecutar()
        {
            DominioSKD.Entidades.Modulo14.Planilla laPlanilla =( 
                DominioSKD.Entidades.Modulo14.Planilla)this.LaEntidad;

            try
            {
                DaoPlanilla BaseDeDatoPlanilla = (DaoPlanilla)FabricaDAOSqlServer.ObtenerDAOPlanilla();
                BaseDeDatoPlanilla.Modificar(laPlanilla);
                BaseDeDatoPlanilla.LimpiarSQLConnection();
                BaseDeDatoPlanilla.EliminarDatosPlanillaBD(laPlanilla.ID);
                BaseDeDatoPlanilla.LimpiarSQLConnection();
                foreach (String item in laPlanilla.Dato)
                {
                    BaseDeDatoPlanilla.RegistrarDatosPlanillaIdBD(laPlanilla.ID, item);
                    BaseDeDatoPlanilla.LimpiarSQLConnection();
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
