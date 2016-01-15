using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DatosSKD.Fabrica;
using DatosSKD.InterfazDAO.Modulo3;
using DominioSKD;
using ExcepcionesSKD;

namespace LogicaNegociosSKD.Comandos.Modulo3
{
    public class EjecutarAgregarOrganizacion : Comando<bool>
    {

        public EjecutarAgregarOrganizacion(Entidad nuevaEntidad)
            : base()
        {
            this.LaEntidad = nuevaEntidad;
        }


        public override bool Ejecutar()
        {
            Logger.EscribirInfo(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, RecursosComandosModulo3.MensajeInicioInfoLogger, System.Reflection.MethodBase.GetCurrentMethod().Name);

            try { 
            FabricaDAOSqlServer fabrica = new FabricaDAOSqlServer();
            IDaoOrganizacion miDaoOrganizacion = fabrica.ObtenerDaoOrganizacion();
            miDaoOrganizacion.Agregar(this.LaEntidad); 

            Logger.EscribirInfo(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, RecursosComandosModulo3.MensajeFinInfoLogger, System.Reflection.MethodBase.GetCurrentMethod().Name);

            return false;

            }
            catch (ExcepcionesSKD.ExceptionSKDConexionBD ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);

                throw ex;
            }
            catch (ExcepcionesSKD.Modulo3.FormatoIncorrectoException ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);

                throw ex;
            }
            catch (ExcepcionesSKD.ExceptionSKD ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);

                throw ex;
            }
        }
 

    }
}
