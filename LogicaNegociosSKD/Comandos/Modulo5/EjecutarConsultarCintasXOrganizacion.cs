using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DominioSKD;
using ExcepcionesSKD;
using DatosSKD.Fabrica;
using DatosSKD.InterfazDAO.Modulo5;

namespace LogicaNegociosSKD.Comandos.Modulo5
{
    public class EjecutarConsultarCintasXOrganizacion : Comando<List<Entidad>>
    {

        public EjecutarConsultarCintasXOrganizacion(Entidad nuevaEntidad)
            : base()
        {
            this.LaEntidad = nuevaEntidad;
        }


        /// <summary>
        /// Método Ejecutar el consultar la lista de Cintas por organizacion
        /// </summary>
        /// <returns>Lista de de Cintas por una organizacion</returns>
        public override List<Entidad> Ejecutar()
        {
            Logger.EscribirInfo(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, RecursosComandosModulo5.MensajeInicioInfoLogger, System.Reflection.MethodBase.GetCurrentMethod().Name);

            try
            {

                IDaoCinta miDaoCinta = FabricaDAOSqlServer.ObtenerDaoCinta();
                List<Entidad> _miLista = miDaoCinta.ListarCintasXOrganizacion(this.LaEntidad); 

                if (_miLista != null)
                {
                    Logger.EscribirInfo(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, RecursosComandosModulo5.MensajeFinInfoLogger, System.Reflection.MethodBase.GetCurrentMethod().Name);

                    return _miLista;
                }
                else
                {
                    Logger.EscribirInfo(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, RecursosComandosModulo5.MensajeFinInfoLogger, System.Reflection.MethodBase.GetCurrentMethod().Name);

                    throw new ExcepcionesSKD.Modulo5.ListaVaciaExcepcion(RecursosComandosModulo5.Codigo_Error_Lista_Vacia,
                                      RecursosComandosModulo5.Mensaje_Error_Lista_Vacia, new Exception());


                }
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
