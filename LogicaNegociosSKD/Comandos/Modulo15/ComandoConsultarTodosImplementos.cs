using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DatosSKD.Fabrica;
using DominioSKD;
using DatosSKD.InterfazDAO.Modulo15;
using ExcepcionesSKD.Modulo15.ExcepcionComando;
using ExcepcionesSKD;

namespace LogicaNegociosSKD.Comandos.Modulo15
{
    public class ComandoConsultarTodosImplementos : Comando<List<Entidad>>
    {
        /// <summary>
        /// Comando Consultar todos los Implemento
        /// </summary>
        /// <param name=""> </param>
        /// <returns>una lista de implementos</returns>
        public override List<Entidad> Ejecutar()
        {
            List<Entidad> lista=new List<Entidad>();
            try
            {
                lista = FabricaDAOSqlServer.ObtenerDAOImplemento().listarInventarioDatos(this.LaEntidad);

            }
            catch (ExcepcionComandoConsultarTodosImplementos ex)
            {
                ex = new ExcepcionComandoConsultarTodosImplementos(RecursosComandoModulo15.ErrorCCImplementos, new Exception());
                Logger.EscribirError(RecursosComandoModulo15.ErrorCCImplementos, ex);
                throw ex;

            }

            catch (ExceptionSKD ex)
            {
                ex = new ExcepcionesSKD.ExceptionSKD(RecursosComandoModulo15.ErrorOperacion, new Exception());
                Logger.EscribirError(RecursosComandoModulo15.ErrorCCImplementos, ex);
                throw ex;
            }

            catch (Exception ex)
            {

                Logger.EscribirError(RecursosComandoModulo15.ErrorCCImplementos, ex);
                throw ex;
            }
            return lista;
        }
    }
}
