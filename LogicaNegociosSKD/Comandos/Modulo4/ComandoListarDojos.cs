using DatosSKD.Fabrica;
using DatosSKD.InterfazDAO.Modulo4;
using DominioSKD;
using ExcepcionesSKD;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegociosSKD.Comandos.Modulo4
{
    public class ComandoListarDojos : Comando<List<Entidad>>
    {
        /// <summary>
        /// Método que sirve de enlace entre los datos
        /// y la vista que ejecuta el Listar dojos
        /// </summary>
        /// <returns>retorna lista de dojos</returns>
        public override List<Entidad> Ejecutar()
        {
            Logger.EscribirInfo(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name
                , RecursosComandoModulo4.MensajeInicioInfoLogger, System.Reflection.MethodBase.GetCurrentMethod().Name);
            try
            {
                IDaoDojo daoDojo = FabricaDAOSqlServer.ObtenerDAODojo();

                Logger.EscribirInfo(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name
                    , RecursosComandoModulo4.MensajeFinInfoLogger, System.Reflection.MethodBase.GetCurrentMethod().Name);
                if (this.LaEntidad == null)
                    return daoDojo.ConsultarTodos();
                else
                    return daoDojo.ConsultarTodosOrganizacion(this.LaEntidad);
            }
            catch (ExcepcionesSKD.ExceptionSKDConexionBD ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);

                throw ex;
            }
            catch (ExcepcionesSKD.Modulo4.FormatoIncorrectoException ex)
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
