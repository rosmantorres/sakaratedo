using DatosSKD.Fabrica;
using DatosSKD.InterfazDAO.Modulo9;
using DominioSKD;
using ExcepcionesSKD;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegociosSKD.Comandos.Modulo9
{
    public class ComandoModificarEventoConTipo : Comando<bool>
    {
        public ComandoModificarEventoConTipo(Entidad entidad)
        { LaEntidad = entidad; }

        public override bool Ejecutar()
        {
            Logger.EscribirInfo(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, RecursosComandosModulo9.MensajeInicioInfoLogger, System.Reflection.MethodBase.GetCurrentMethod().Name);
            try
            {
                DatosSKD.DAO.Modulo9.DaoEvento daoEvento = (DatosSKD.DAO.Modulo9.DaoEvento)FabricaDAOSqlServer.ObtenerDaoEvento();
                Logger.EscribirInfo(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, RecursosComandosModulo9.MensajeFinInfoLogger, System.Reflection.MethodBase.GetCurrentMethod().Name);
                return daoEvento.ModificarEventoConTipo(LaEntidad);

            }
            catch (ExcepcionesSKD.ExceptionSKDConexionBD ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);

                throw ex;
            }
            catch (ExcepcionesSKD.Modulo12.FormatoIncorrectoException ex)
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
