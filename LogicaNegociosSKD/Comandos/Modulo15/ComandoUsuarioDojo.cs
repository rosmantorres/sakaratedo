using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DatosSKD.Fabrica;
using DatosSKD.InterfazDAO.Modulo15;
using DominioSKD;
using ExcepcionesSKD.Modulo15.ExcepcionComando;
using ExcepcionesSKD;

namespace LogicaNegociosSKD.Comandos.Modulo15
{
    public class ComandoUsuarioDojo : Comando<int>
    {
        /// <summary>
        /// Comando Usuario de Dojo
        /// </summary>
        

        public override int Ejecutar()
        {

            IDaoImplemento daoImplemeto = FabricaDAOSqlServer.ObtenerDAOImplemento();
            try
            {
               return daoImplemeto.usuarioImplementoDatos(((Usuario)this.LaEntidad)._Nombre);
            }
            catch (ExcepcionComandoUsuarioDojo ex)
            {
                ex = new ExcepcionComandoUsuarioDojo(RecursosComandoModulo15.ErrorCUDojo, new Exception());
                Logger.EscribirError(RecursosComandoModulo15.ErrorCUDojo, ex);
                throw ex;

            }

            catch (ExceptionSKD ex)
            {
                ex = new ExcepcionesSKD.ExceptionSKD(RecursosComandoModulo15.ErrorOperacion, new Exception());
                Logger.EscribirError(RecursosComandoModulo15.ErrorCUDojo, ex);
                throw ex;
            }

            catch (Exception ex)
            {

                Logger.EscribirError(RecursosComandoModulo15.ErrorCUDojo, ex);
                throw ex;
            }
        }
    }
}
