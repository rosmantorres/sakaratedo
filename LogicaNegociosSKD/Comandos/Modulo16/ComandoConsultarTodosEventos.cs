using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DominioSKD;
using DatosSKD.Fabrica;
using DatosSKD.InterfazDAO.Modulo16;
using DatosSKD.InterfazDAO;
using ExcepcionesSKD.Modulo16;
using ExcepcionesSKD;

namespace LogicaNegociosSKD.Comandos.Modulo16
{
    /// <summary>
    /// Comando para consultar la lista de todos los eventos
    /// </summary>
    public class ComandoConsultarTodosEventos : Comando<List<Entidad>>
    {
        #region Atributos
        /// <summary>
        /// Atributos del ComandoConsultarTodosEventos
        /// </summary>
        /// <param name="NONE">No posee paso de parametros</param>
        #endregion

        #region Propiedades
        /// <summary>
        /// Propiedad 
        /// </summary>
        /// <Prop name="NONE">No posee propiedades</param>
        #endregion

        #region Constructores
        /// <summary>
        /// Constructor vacio del ComandoConsultarTodosEventos
        /// </summary>
        public ComandoConsultarTodosEventos()
        {

        }

        #endregion

        #region Metodo Ejecutar
        /// <summary>
        /// Metodo que ejecuta la accion de consultarTodasLosEventos
        /// </summary>
        /// <param name="NONE">Este metodo no posee paso de parametros</param>
        /// <returns>lista de Eventos</returns>
        public override List<Entidad> Ejecutar()
        {
            try
            {
                //Escribo en el logger la entrada a este metodo
                Logger.EscribirInfo(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name,
                    RecursosLogicaModulo16.MENSAJE_ENTRADA_LOGGER,
                    System.Reflection.MethodBase.GetCurrentMethod().Name);

                //Instancio el DAO de Evento
                IdaoEvento daoEventos = FabricaDAOSqlServer.ObtenerDaoEventos();

                //Escribo en el logger la salida a este metodo
                Logger.EscribirInfo(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name,
                    RecursosLogicaModulo16.MENSAJE_SALIDA_LOGGER, System.Reflection.MethodBase.GetCurrentMethod().Name);

                //retorno la entidad de donde sea llamado
                return daoEventos.ConsultarTodos();
            }
            #region catches

            catch (LoggerException e)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, e);
                throw e;
            }
            catch (ItemInvalidoException e)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, e);
                throw e;
            }
            catch (PersonaNoValidaException e)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, e);
                throw e;
            }
            catch (OpcionItemErroneoException e)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, e);
                throw e;
            }
            catch (ParseoVacioException e)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, e);
                throw e;
            }
            catch (ParseoFormatoInvalidoException e)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, e);
                throw e;
            }
            catch (ParseoEnSobrecargaException e)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, e);
                throw e;
            }
            catch (ParametroInvalidoException e)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, e);
                throw e;
            }
            catch (ExceptionSKDConexionBD e)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, e);
                throw e;
            }
            catch (ExceptionSKD e)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, e);
                throw e;
            }
            catch (Exception e)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, e);
                throw new ExceptionSKDConexionBD(RecursosLogicaModulo16.CODIGO_EXCEPCION_GENERICO,
                    RecursosLogicaModulo16.MENSAJE_EXCEPCION_GENERICO, e);
            }

            #endregion
        }
        #endregion
    }
}
