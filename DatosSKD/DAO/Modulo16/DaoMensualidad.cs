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
using DominioSKD.Entidades.Modulo6;
using DominioSKD.Entidades.Modulo16;
using DatosSKD.InterfazDAO.Modulo16;
using DatosSKD.DAO.Modulo16;
using ExcepcionesSKD;
using ExcepcionesSKD.Modulo16;

namespace DatosSKD.DAO.Modulo16
{
    public class DaoMensualidad : DAOGeneral, IdaoMensualidad
    {
        #region Constructor
        /// <summary>
        /// Constructor vacio del DAO
        /// </summary>
        public DaoMensualidad()
        {

        }
        #endregion

        #region Metodo de Listar Mensualidades Morosas (ConsultarXId)
        /// <summary>
        /// Metodo que retorma una lista de Matriculas Morosas Existentes
        /// </summary>
        /// <param name=Entidad>Se pasa el id del usuario logueado</param>
        /// <returns>Todas las mensualidades morosas asociadas al id de la persona logueada</returns>
        public Entidad ConsultarXId(Entidad entidad)
        {
            FabricaEntidades laFabrica = new FabricaEntidades();
            List<Matricula> laLista = new List<Matricula>();
            DataTable resultado = new DataTable();
            List<Parametro> parametros = new List<Parametro>();
            Matricula laMatricula;
            ListaMatricula lista = new ListaMatricula();

            //Casteamos
            PersonaM1 p = (PersonaM1)entidad;

            try
            {
                //Escribo en el logger la entrada a este metodo
                Logger.EscribirInfo(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name,
                RecursosBDModulo16.MENSAJE_ENTRADA_LOGGER, System.Reflection.MethodBase.GetCurrentMethod().Name);

                //Creo la lista de los parametros para el stored procedure y los anexo
                parametros = new List<Parametro>();
                Parametro parametro = new Parametro(RecursosBDModulo16.PARAMETRO_ID_USUARIO, SqlDbType.Int, p._Id.ToString(), false);
                parametros.Add(parametro);

                //Ejecuto el Stored Procedure 
                resultado = EjecutarStoredProcedureTuplas(RecursosBDModulo16.CONSULTAR_MATRICULAS_MOROSAS,
                    parametros);

                //Limpio la conexion
                LimpiarSQLConnection();

                //Obtengo todos las mensualidades que debe el usuario logueado
                foreach (DataRow row in resultado.Rows)
                {
                    laMatricula = (Matricula)laFabrica.ObtenerMatricula();
                    laMatricula.Id = int.Parse(row[RecursosBDModulo16.PARAMETRO_ID_MATRICULA].ToString());
                    laMatricula.Identificador = row[RecursosBDModulo16.PARAMETRO_IDENTIFICADOR_MAT].ToString();
                    laMatricula.Costo = int.Parse(row[RecursosBDModulo16.PARAMETRO_PRECIO_MATRICULA].ToString());
                    laMatricula.UltimaFechaPago= DateTime.Parse(row[RecursosBDModulo16.PARAMETRO_FECHA_PAGO_MATRICULA].ToString());
                    laMatricula.Mes = int.Parse(row[RecursosBDModulo16.PARAMETRO_MES_DEUDOR_MATRICULA].ToString());
                    laMatricula.Anio = int.Parse(row[RecursosBDModulo16.PARAMETRO_ANIO_DEUDOR_MATRICULA].ToString());
                    laLista.Add(laMatricula);

                }

                //Agrego a la lista
                lista.ListaMatriculas = laLista;

                //Limpio la conexion
                LimpiarSQLConnection();

                //Escribo en el logger la salida a este metodo
                Logger.EscribirInfo(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name,
                RecursosBDModulo16.MENSAJE_SALIDA_LOGGER, System.Reflection.MethodBase.GetCurrentMethod().Name);

                //Retorno la lista
                return lista;

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

        #region Metodo del detallar mensualidad Morosa (DetallarMansualidad por ID)
        /// <summary>
        /// Metodo que devueve un tipomensualidad dado su id
        /// </summary>
        /// <param name="Entidad">Indica el objeto a detallar</param>
        /// <returns>Retorna la mensualidad en especifico con todos sus detalles</returns>
        public Entidad DetallarMensualidad(Entidad matricula)
        {
            FabricaEntidades laFabrica = new FabricaEntidades();
            List<Matricula> laLista = new List<Matricula>();
            DataTable resultado = new DataTable();
            List<Parametro> parametros = new List<Parametro>();
            Matricula laMatricula = new Matricula();
            Dojo elDojo = new Dojo();
            Matricula lista = new Matricula();

            //Casteamos
            Matricula mat = (Matricula)matricula;


            try
            {
                //Escribo en el logger la entrada a este metodo
                Logger.EscribirInfo(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name,
                RecursosBDModulo16.MENSAJE_ENTRADA_LOGGER, System.Reflection.MethodBase.GetCurrentMethod().Name);

                //Creo la lista de los parametros para el stored procedure y los anexo
                parametros = new List<Parametro>();
                Parametro parametro = new Parametro(RecursosBDModulo16.ParamIdMatricula, SqlDbType.Int, mat.Id.ToString(), false);
                parametros.Add(parametro);

                //Ejecuto el Stored Procedure 
                resultado = EjecutarStoredProcedureTuplas(RecursosBDModulo16.DETALLAR_MATRICULA, parametros);

                //Limpio la conexion
                LimpiarSQLConnection();

                //Obtengo cada atributo de la mensualidad solicitada
                foreach (DataRow row in resultado.Rows)
                {
                    laMatricula = (Matricula)laFabrica.ObtenerMatricula();
                    elDojo = (Dojo)FabricaEntidades.ObtenerDojos();
                    laMatricula.Id = int.Parse(row[RecursosBDModulo16.PARAMETRO_ID_MATRICULA].ToString());
                    laMatricula.Identificador = row[RecursosBDModulo16.PARAMETRO_IDENTIFICADOR_MAT].ToString();
                    laMatricula.Costo = int.Parse(row[RecursosBDModulo16.PARAMETRO_PRECIO_MATRICULA].ToString());
                    laMatricula.UltimaFechaPago = DateTime.Parse(row[RecursosBDModulo16.PARAMETRO_FECHA_PAGO_MATRICULA].ToString());
                    elDojo.Nombre_dojo = row[RecursosBDModulo16.PARAMETRO_DOJO_NOMBRE].ToString();
                    laMatricula.Dojo_Matricula = elDojo;

                }

                //Limpio la conexion
                LimpiarSQLConnection();

                //Escribo en el logger la salida a este metodo
                Logger.EscribirInfo(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name,
                RecursosBDModulo16.MENSAJE_SALIDA_LOGGER, System.Reflection.MethodBase.GetCurrentMethod().Name);

                //Retorno la Matricula
                return laMatricula;
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

        #region Metodo Listar Mensualidad
        /// <summary>
        /// Metodo que devueve todas las mensualidades
        /// </summary>
        /// <param name="NONE">Este procedimiento no posee paso de paramentros</param>
        /// <returns>Retorna todas las mensualidades sin filtro</returns>
        public List<Entidad> ListarMensualidad()
        {
            throw new NotImplementedException();
        }

        #endregion

        #region Metodo de ConsultarTodos
        /// <summary>
        /// Metodo que devueve todas las mensualidades
        /// </summary>
        /// <param name="NONE">Este procedimiento no posee paso de paramentros</param>
        /// <returns>Retorna todas las mensualidades</returns>
        public List<Entidad> ConsultarTodos()
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
