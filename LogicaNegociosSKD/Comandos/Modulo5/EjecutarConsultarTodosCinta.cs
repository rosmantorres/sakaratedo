using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DatosSKD.Fabrica;
using DatosSKD.InterfazDAO.Modulo5;
using DominioSKD;
using ExcepcionesSKD;
using System.Resources;

namespace LogicaNegociosSKD.Comandos.Modulo5
{
    public class EjecutarConsultarTodosCinta : Comando<List<Entidad>>
    {

        /// <summary>
        /// Método Ejecutar el consultar la lista de cintas 
        /// </summary>
        /// <returns>Lista de cintas</returns>
        public override List<Entidad> Ejecutar()
        {
            Logger.EscribirInfo(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, RecursosComandosModulo5.MensajeInicioInfoLogger, System.Reflection.MethodBase.GetCurrentMethod().Name);

            try { 

            IDaoCinta miDaoCinta = FabricaDAOSqlServer.ObtenerDaoCinta();
            List<Entidad> _miLista = miDaoCinta.ConsultarTodos(); 

            if(_miLista != null)
            {
                Logger.EscribirInfo(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, RecursosComandosModulo5.MensajeFinInfoLogger, System.Reflection.MethodBase.GetCurrentMethod().Name);
           
                return _miLista;
            }
            else
            {
               Logger.EscribirInfo(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, RecursosComandosModulo5.MensajeFinInfoLogger, System.Reflection.MethodBase.GetCurrentMethod().Name);
           
                return null; 
                
            }

           
            
            }
            catch (ExcepcionesSKD.ExceptionSKDConexionBD ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);

                throw ex;
            }
            catch (ExcepcionesSKD.Modulo5.FormatoIncorrectoException ex)
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
