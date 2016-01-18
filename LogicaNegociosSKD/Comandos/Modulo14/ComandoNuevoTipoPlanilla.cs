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
   public class ComandoNuevoTipoPlanilla : Comando<Boolean>
    {
        private String nombreTipo;

        public String NombreTipo
        {
            get { return nombreTipo; }
            set { nombreTipo = value; }
        }

        public override Boolean Ejecutar()
        {
            FabricaDAOSqlServer fabrica = new FabricaDAOSqlServer();
            Boolean result = true;
            try
            {
                DaoPlanilla BaseDeDatoPlanilla = (DaoPlanilla)fabrica.ObtenerDAOPlanilla();
                result = BaseDeDatoPlanilla.RegistrarTipoPlanilla(this.nombreTipo);
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
            return result;
        }
    }
}
