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
using DominioSKD.Entidades.Modulo15;
using DominioSKD.Entidades.Modulo16;
using DatosSKD.InterfazDAO.Modulo16;
using DatosSKD.DAO.Modulo16;
using ExcepcionesSKD;
using ExcepcionesSKD.Modulo16;

namespace DatosSKD.DAO.Modulo16
{
    public class DaoImplemento : DAOGeneral, IdaoImplemento
    {
        #region Constructor
        /// <summary>
        /// Constructor vacio del DAO
        /// </summary>
        public DaoImplemento()
        {

        }
        #endregion

        #region Metodos para ConsultarXId (Listar Productos por id )
        /// <summary>
        /// Metodo que retorma una lista de productos existentes
        /// </summary>
        /// <param name=Entidad>Se pasa el id de la persona</param>
        /// <returns>Lista solo los implementos que puede ver ese usuario logueado de acuerdo a su Dojo</returns>
       
        public Entidad ConsultarXId(Entidad implemento)
        {
            FabricaEntidades laFabrica = new FabricaEntidades();
            List<Implemento> laLista = new List<Implemento>();
            DataTable resultado = new DataTable();
            List<Parametro> parametros = new List<Parametro>();
            Implemento elImplemento;
            ListaImplemento lista = new ListaImplemento();
            Dojo elDojo = new Dojo();

            // Casteamos
            PersonaM1 p = (PersonaM1)implemento;

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
                resultado = EjecutarStoredProcedureTuplas(RecursosBDModulo16.CONSULTAR_INVENTARIO_TOTAL_DOJOS, parametros);

                //Limpio la conexion
                LimpiarSQLConnection();

                //Obtengo todos los elementos del inventario del dojo donde pertenece el usuario logueado
                    foreach (DataRow row in resultado.Rows)
                    {
                        elImplemento = (Implemento)FabricaEntidades.ObtenerImplemento();
                        elDojo = (Dojo)FabricaEntidades.ObtenerDojos();
                        elImplemento.Id_Implemento = int.Parse(row[RecursosBDModulo16.PARAMETRO_IDIMPLEMENTO].ToString());
                        elImplemento.Nombre_Implemento = row[RecursosBDModulo16.PARAMETRO_NOMBRE].ToString();
                        elImplemento.Tipo_Implemento = row[RecursosBDModulo16.PARAMETRO_TIPO].ToString();
                        elImplemento.Marca_Implemento = row[RecursosBDModulo16.PARAMETRO_MARCA].ToString();
                        elImplemento.Precio_Implemento = int.Parse(row[RecursosBDModulo16.PARAMETRO_PRECIO].ToString());
                        elImplemento.Cantida_implemento = int.Parse(row[RecursosBDModulo16.PARAMETRO_CANTIDAD_IMPLEMENTO].ToString());
                        elDojo.Nombre_dojo = row[RecursosBDModulo16.PARAMETRO_DOJO_NOMBRE].ToString();
                        elImplemento.Dojo_Implemento = elDojo;
                        laLista.Add(elImplemento);
                       
                    }
                    //Agrego a la lista
                    lista.ListaImplementos = laLista;

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

        #region Metodo para DetallarImplemento (Detallar Implemento)
            /// <summary>
        /// Metodo que retorma una entidad de tipo implemento
        /// </summary>
        /// <param name=Entidad>Se pasa el id del implemento a buscar</param>
        /// <returns>Todas los atributos de la clase implemento para el detallar</returns>
        
        public Entidad DetallarImplemento(Entidad implemento)
        {
            FabricaEntidades laFabrica = new FabricaEntidades();
            List<Implemento> laLista = new List<Implemento>();
            DataTable resultado = new DataTable();
            List<Parametro> parametros = new List<Parametro>();
            Implemento elImplemento = new Implemento();
            Implemento lista = new Implemento();

            // Casteamos
            Implemento imp = (Implemento)implemento;


            try
            {
                //Escribo en el logger la entrada a este metodo
                Logger.EscribirInfo(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name,
                RecursosBDModulo16.MENSAJE_ENTRADA_LOGGER, System.Reflection.MethodBase.GetCurrentMethod().Name);

                //Creo la lista de los parametros para el stored procedure y los anexo
                parametros = new List<Parametro>();
                Parametro parametro = new Parametro(RecursosBDModulo16.PARAMETRO_ITEM, SqlDbType.Int, imp.Id_Implemento.ToString(), false);
                parametros.Add(parametro);

                //Ejecuto el Stored Procedure 
                resultado = EjecutarStoredProcedureTuplas(RecursosBDModulo16.DETALLAR_IMPLEMENTO, parametros);

                //Limpio la conexion
                LimpiarSQLConnection();

                //Obtengo todos los ids de implemento que posee ese dojo
                foreach (DataRow row in resultado.Rows)
                {
                    elImplemento = (Implemento)FabricaEntidades.ObtenerImplemento();
                    elImplemento.Imagen_implemento = row[RecursosBDModulo16.PARAMETRO_IMAGEN].ToString();
                    elImplemento.Nombre_Implemento = row[RecursosBDModulo16.PARAMETRO_NOMBRE].ToString();
                    elImplemento.Tipo_Implemento = row[RecursosBDModulo16.PARAMETRO_TIPO].ToString();
                    elImplemento.Marca_Implemento = row[RecursosBDModulo16.PARAMETRO_MARCA].ToString();
                    elImplemento.Color_Implemento = row[RecursosBDModulo16.PARAMETRO_COLOR].ToString();
                    elImplemento.Talla_Implemento = row[RecursosBDModulo16.PARAMETRO_TALLA].ToString();
                    elImplemento.Estatus_Implemento = row[RecursosBDModulo16.PARAMETRO_ESTATUS].ToString();
                    elImplemento.Precio_Implemento = int.Parse(row[RecursosBDModulo16.PARAMETRO_PRECIO].ToString());
                    elImplemento.Descripcion_Implemento = row[RecursosBDModulo16.PARAMETRO_DESCRIPCION].ToString();
              
                }

                //Limpio la conexion
                LimpiarSQLConnection();

                //Escribo en el logger la salida a este metodo
                Logger.EscribirInfo(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name,
                RecursosBDModulo16.MENSAJE_SALIDA_LOGGER, System.Reflection.MethodBase.GetCurrentMethod().Name);

                //Retorno la lista
                return elImplemento;

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

        #region Metodo para ListarImplemento

        /// <summary>
        /// Metodo para el listar de productos sin parametro
        /// </summary>
        /// <returns>Retorna una lista de implementos</returns>
        public List<Entidad> ListarImplemento()
        {
            throw new NotImplementedException();
        }

        #endregion

        #region Metodo para ConsultarTodos sin parametros
        /// <summary>
        /// Metodo que devueve un tipoimplemento dado su id
        /// </summary>
        /// <param name="NONE">El metodo no posee paso de parametros</param>
        /// <returns>Retorna una lista de implementos</returns>
      //  public Entidad DetallarImplemento(Entidad implemento)
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
