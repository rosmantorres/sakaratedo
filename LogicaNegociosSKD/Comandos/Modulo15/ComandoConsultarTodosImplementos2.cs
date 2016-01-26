using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DatosSKD.Fabrica;
using DominioSKD;
using ExcepcionesSKD.Modulo15.ExcepcionComando;
using ExcepcionesSKD;

namespace LogicaNegociosSKD.Comandos.Modulo15
{
    public class ComandoConsultarTodosImplementos2 : Comando<List<Entidad>>
    {
        /// <summary>
        /// Comando Consultar todos los Implemento
        /// </summary>
        /// <param name=""> </param>
        /// <returns>una lista de implementos</returns>

        public override List<Entidad> Ejecutar()
        {
            List<Entidad> lista = new List<Entidad>();
            try
            {
                lista = FabricaDAOSqlServer.ObtenerDAOImplemento().listarInventarioDatos2(this.LaEntidad);

            }
            catch (ExcepcionComandoConsultarTodosImplementos2 ex)
            {
                ex = new ExcepcionComandoConsultarTodosImplementos2(RecursosComandoModulo15.ErrorCCTImplementos2, new Exception());
                Logger.EscribirError(RecursosComandoModulo15.ErrorCCTImplementos2, ex);
                throw ex;

            }

            catch (ExceptionSKD ex)
            {
                ex = new ExcepcionesSKD.ExceptionSKD(RecursosComandoModulo15.ErrorOperacion, new Exception());
                Logger.EscribirError(RecursosComandoModulo15.ErrorCCTImplementos2, ex);
                throw ex;
            }

            catch (Exception ex)
            {

                Logger.EscribirError(RecursosComandoModulo15.ErrorCCTImplementos2, ex);
                throw ex;
            }
            return lista;
        }
    }
}
