using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Configuration;
using DatosSKD.DAO;
using DominioSKD.Fabrica;
using DominioSKD;
using DominioSKD.Entidades.Modulo16;
using DatosSKD.InterfazDAO.Modulo16;
using DatosSKD.DAO.Modulo16;
using ExcepcionesSKD;
using ExcepcionesSKD.Modulo16;

namespace DatosSKD.DAO.Modulo16
{
    public class DaoEvento : DAOGeneral, IdaoEvento
    {
        #region Constructor
        /// <summary>
        /// Constructor vacio del DAO
        /// </summary>
        public DaoEvento()
        {

        }
        #endregion

        #region Metodos para ConsultarTodos (Listar Eventos)
        /// <summary>
        /// Metodo que retorma una lista de eventos existentes
        /// </summary>
        /// <param name=NONE>Este metodo no posee paso de parametros</param>
        /// <returns>Todo lo que tiene actualmente el inventario de eventos</returns>
        public List<Entidad> ConsultarTodos()
        {
            FabricaEntidades laFabrica = new FabricaEntidades();
            List<Entidad> laLista = new List<Entidad>();
            DataTable resultado = new DataTable();
            List<Parametro> parametros = new List<Parametro>();
            Evento elEvento;

            try
            {
                //Escribo en el logger la entrada a este metodo
                Logger.EscribirInfo(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name,
                RecursosBDModulo16.MENSAJE_ENTRADA_LOGGER, System.Reflection.MethodBase.GetCurrentMethod().Name);

                //Ejecuto el Stored Procedure 
                resultado = EjecutarStoredProcedureTuplas(RecursosBDModulo16.CONSULTAR_EVENTOS, parametros);

                //Limpio la conexion
                LimpiarSQLConnection();

                //Obtengo todos los ids que existen de evento
                foreach (DataRow row in resultado.Rows)
                {
                    elEvento = (Evento)laFabrica.ObtenerEvento();
                    elEvento.Id_evento = int.Parse(row[RecursosBDModulo16.PARAMETRO_IDEVENTO].ToString());
                    elEvento.Nombre = row[RecursosBDModulo16.PARAMETRO_NOMBRE].ToString();
                    elEvento.Descripcion = row[RecursosBDModulo16.PARAMETRO_DESCRIPCION].ToString();
                    elEvento.Costo = int.Parse(row[RecursosBDModulo16.PARAMETRO_PRECIO].ToString());
                    laLista.Add(elEvento);

                }

                //Limpio la conexion
                LimpiarSQLConnection();

                //Escribo en el logger la salida a este metodo
                Logger.EscribirInfo(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name,
                RecursosBDModulo16.MENSAJE_SALIDA_LOGGER, System.Reflection.MethodBase.GetCurrentMethod().Name);

                //Retorno la lista
                return laLista;

            }
            #region catches
            catch (LoggerException e)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, e);
                throw e;
            }
            catch (ArgumentNullException e)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, e);
                throw new ParseoVacioException(RecursosBDModulo16.CODIGO_EXCEPCION_ARGUMENTO_NULO,
                    RecursosBDModulo16.MENSAJE_EXCEPCION_ARGUMENTO_NULO, e);
            }
            catch (FormatException e)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, e);
                throw new ParseoFormatoInvalidoException(RecursosBDModulo16.CODIGO_EXCEPCION_FORMATO_INVALIDO,
                    RecursosBDModulo16.MENSAJE_EXCEPCION_FORMATO_INVALIDO, e);
            }
            catch (OverflowException e)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, e);
                throw new ParseoEnSobrecargaException(RecursosBDModulo16.CODIGO_EXCEPCION_SOBRECARGA,
                    RecursosBDModulo16.MENSAJE_EXCEPCION_SOBRECARGA, e);
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
                throw new ExceptionSKD(RecursosBDModulo16.CODIGO_EXCEPCION_GENERICO,
                    RecursosBDModulo16.MENSAJE_EXCEPCION_GENERICO, e);
            }
            #endregion
        }

        #endregion

        #region Metodo para ConsultarXId (Detallar Evento)
        /// <summary>
        /// Metodo que retorma una entidad de tipo evento
        /// </summary>
        /// <param name=Entidad>Se pasa el id del evento a buscar</param>
        /// <returns>Todas los atributos de la clase evento para el detallar</returns>
        public Entidad ConsultarXId(Entidad evento)
        {
            FabricaEntidades laFabrica = new FabricaEntidades();
            List<Evento> laLista = new List<Evento>();
            DataTable resultado = new DataTable();
            List<Parametro> parametros = new List<Parametro>();
            Evento elEvento = new Evento();
            Evento lista = new Evento();

            // Casteamos
            Evento eve = (Evento)evento;

                try
                {
                    //Escribo en el logger la entrada a este metodo
                    Logger.EscribirInfo(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name,
                    RecursosBDModulo16.MENSAJE_ENTRADA_LOGGER, System.Reflection.MethodBase.GetCurrentMethod().Name);

                    //Creo la lista de los parametros para el stored procedure y los anexo
                    parametros = new List<Parametro>();
                    Parametro parametro = new Parametro(RecursosBDModulo16.PARAMETRO_ITEM, SqlDbType.Int, eve.Id.ToString(), false);
                    parametros.Add(parametro);

                    //Ejecuto el Stored Procedure 
                    resultado = EjecutarStoredProcedureTuplas(RecursosBDModulo16.DETALLAR_EVENTO, parametros);

                    //Limpio la conexion
                    LimpiarSQLConnection();

                    //Obtengo todos los elementos del evento
                    foreach (DataRow row in resultado.Rows)
                    {
                        elEvento = (Evento)laFabrica.ObtenerEvento();
                        elEvento.Id_evento = int.Parse(row[RecursosBDModulo16.PARAMETRO_IDEVENTO].ToString());
                        elEvento.Nombre = row[RecursosBDModulo16.PARAMETRO_NOMBRE].ToString();
                        elEvento.Costo = int.Parse(row[RecursosBDModulo16.PARAMETRO_PRECIO].ToString());
                        elEvento.Descripcion = row[RecursosBDModulo16.PARAMETRO_DESCRIPCION].ToString();

                    }

                    //Limpio la conexion
                    LimpiarSQLConnection();

                    //Escribo en el logger la salida a este metodo
                    Logger.EscribirInfo(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name,
                    RecursosBDModulo16.MENSAJE_SALIDA_LOGGER, System.Reflection.MethodBase.GetCurrentMethod().Name);

                    //Retorno el evento
                    return elEvento;

                }

                #region catches
                catch (LoggerException e)
                {
                    Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, e);
                    throw e;
                }
                catch (ArgumentNullException e)
                {
                    Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, e);
                    throw new ParseoVacioException(RecursosBDModulo16.CODIGO_EXCEPCION_ARGUMENTO_NULO,
                        RecursosBDModulo16.MENSAJE_EXCEPCION_ARGUMENTO_NULO, e);
                }
                catch (FormatException e)
                {
                    Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, e);
                    throw new ParseoFormatoInvalidoException(RecursosBDModulo16.CODIGO_EXCEPCION_FORMATO_INVALIDO,
                        RecursosBDModulo16.MENSAJE_EXCEPCION_FORMATO_INVALIDO, e);
                }
                catch (OverflowException e)
                {
                    Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, e);
                    throw new ParseoEnSobrecargaException(RecursosBDModulo16.CODIGO_EXCEPCION_SOBRECARGA,
                        RecursosBDModulo16.MENSAJE_EXCEPCION_SOBRECARGA, e);
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
                    throw new ExceptionSKD(RecursosBDModulo16.CODIGO_EXCEPCION_GENERICO, 
                        RecursosBDModulo16.MENSAJE_EXCEPCION_GENERICO, e);
                }
                #endregion          
        }

        #endregion 

        #region Metodo para DetallarEvento

        /// <summary>
        /// Metodo que devueve un tipoevento dado su id
        /// </summary>
        /// <param name="Id_evento">Indica el objeto a detallar</param>
        /// <returns>Retorna un evento en especifico con todos sus detalles</returns>
        public Entidad DetallarEvento(int Id_evento)
        {
            throw new NotImplementedException();
        }

        #endregion

        #region Metodo para ListarEvento

        /// <summary>
        /// Metodo para el listar de evento sin parametro
        /// </summary>
        /// <returns>Retorna una lista de eventos</returns>
        public List<Entidad> ListarEvento()
        {
            throw new NotImplementedException();
        }

        #endregion

        #region Metodo de Agregar
        /// <summary>
        /// Metodo que que no implementamos
        /// </summary>
        public Entidad Agregar(Entidad entidad)
        {
            throw new NotImplementedException();
        }

        #endregion

        #region Metodo de Modificar
        /// <summary>
        /// Metodo que que no implementamos
        /// </summary>
        public Entidad Modificar(Entidad entidad)
        {
            throw new NotImplementedException();
        }

        #endregion

    }
}
