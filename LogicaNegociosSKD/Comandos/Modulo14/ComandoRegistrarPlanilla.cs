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
   public class ComandoRegistrarPlanilla : Comando<bool>
    {
       public override bool Ejecutar()
        {
            DominioSKD.Entidades.Modulo14.Planilla laPlanilla =
                (DominioSKD.Entidades.Modulo14.Planilla)this.LaEntidad;
            bool resultPlanilla = true;
            try
            {
                DaoPlanilla BaseDeDatoPlanilla = (DaoPlanilla)FabricaDAOSqlServer.ObtenerDAOPlanilla();
                resultPlanilla = BaseDeDatoPlanilla.Agregar(laPlanilla);
                BaseDeDatoPlanilla.LimpiarSQLConnection();
                foreach (String nombreDato in laPlanilla.Dato)
                {

                    Boolean resultdatos = BaseDeDatoPlanilla.RegistrarDatosPlanillaBD(laPlanilla.Nombre, nombreDato);
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
            return resultPlanilla;
        }

    }

   
}
