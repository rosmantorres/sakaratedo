using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Data.Sql;
using ExcepcionesSKD;
using ExcepcionesSKD.Modulo15;
using DatosSKD.Modulo15;
using DominioSKD;
using DatosSKD.InterfazDAO.Modulo15;
using DominioSKD.Fabrica;
using DatosSKD.Modulo4;
using DominioSKD.Entidades.Modulo15;
using DominioSKD.Entidades.Modulo16;
using DatosSKD.DAO.Modulo16;
using ExcepcionesSKD.Modulo16;
using DominioSKD.Entidades.Modulo1;
using ExcepcionesSKD.Modulo15.ExcepcionDao;

namespace DatosSKD.DAO.Modulo15
{
    public class DaoImplemento : DAOGeneral, IDaoImplemento
    {


        #region IDaoImplemento

        #region Metodos para ConsultarXId (Listar Productos por id )
        /// <summary>
        /// Metodo que retorma una lista de productos existentes
        /// </summary>
        /// <param name=Entidad>Se pasa el id de la persona</param>
        /// <returns>Lista solo los implementos que puede ver ese usuario logueado de acuerdo a su Dojo</returns>

        public Entidad ConsultarXId(Entidad implemento)
        {
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
                    elDojo = (Dojo)FabricaEntidades.tenerDojo();
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

        #region idDojo

        /// <summary>
        /// Método que consulta los datos de un dojo
        /// </summary>
        /// <param name="">Id del Dojo a consultar</param>
        /// <returns>La clase Dojo</returns>
        public  Entidad DetallarDojo(Entidad parametroDojo)
        {
            BDConexion laConexion;
            List<Parametro> parametros;
            Parametro elParametro = new Parametro();
            Entidad elDojo = FabricaEntidades.tenerDojo();
      
            try
            {

                laConexion = new BDConexion();
                parametros = new List<Parametro>();


                elParametro = new Parametro(RecursosBDModulo4.ParamIdDojo, SqlDbType.Int,((Dojo)parametroDojo).Dojo_Id.ToString(),
                                            false);
                parametros.Add(elParametro);

                DataTable dt = laConexion.EjecutarStoredProcedureTuplas(
                               RecursosBDModulo4.ConsultarDojoXId, parametros);

                foreach (DataRow row in dt.Rows)
                {


                    ((Dojo)elDojo).Dojo_Id = int.Parse(row[RecursosBDModulo4.AliasIdDojo].ToString());
                    ((Dojo)elDojo).Rif_dojo = row[RecursosBDModulo4.AliasRifDojo].ToString();
                    ((Dojo)elDojo).Nombre_dojo = row[RecursosBDModulo4.AliasNombreDojo].ToString();
                    ((Dojo)elDojo).Telefono_dojo = int.Parse(row[RecursosBDModulo4.AliasTelefonoDojo].ToString());
                    ((Dojo)elDojo).Email_dojo = row[RecursosBDModulo4.AliasEmailDojo].ToString();
                    ((Dojo)elDojo).Logo_dojo = row[RecursosBDModulo4.AliasLogoDojo].ToString();
                    ((Dojo)elDojo).Status_dojo = row[RecursosBDModulo4.AliasStatusDojo].ToString();
                    ((Dojo)elDojo).Registro_dojo = DateTime.Parse(row[RecursosBDModulo4.AliasFechaDojo].ToString());
                    ((Dojo)elDojo).Organizacion_dojo = int.Parse(row[RecursosBDModulo4.AliasIdOrganizacion].ToString());
                    ((Dojo)elDojo).OrgNombre_dojo = row[RecursosBDModulo4.AliasNombreOrganizacion].ToString();
                    ((Dojo)elDojo).Ubicacion = new Ubicacion(int.Parse(row[RecursosBDModulo4.AliasIdUbicacion].ToString()),
                                                            row[RecursosBDModulo4.AliasNombreCiudad].ToString(),
                                                            row[RecursosBDModulo4.AliasNombreEstado].ToString());
                    //elDojo.Matricula_dojo = (BuscarMatriculaVigente(elDojo));

                }
                return elDojo;

            }
            catch (SqlException ex)
            {
                throw new ExcepcionesSKD.ExceptionSKDConexionBD(RecursoGeneralBD.Codigo,
                    RecursoGeneralBD.Mensaje, ex);
            }
            catch (ExcepcionesSKD.ExceptionSKDConexionBD ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw new ExcepcionesSKD.ExceptionSKD(RecursoGeneralBD.Mensaje_Generico_Error, ex);
            }


        }
        #endregion 

        #region listarInventarioDatos
        /// <summary>
        /// Método que lista los datos de un inventario
        /// </summary>
        /// <param name="">Id del Dojo a consultar donde este el inventario</param>
        /// <returns>La clase Implemento</returns>
        List<Entidad> IDaoImplemento.listarInventarioDatos(Entidad parametroDojo)
        {
            BDConexion laConexion;
            List<Entidad> listaDeImplementos = new List<Entidad>();
            List<Parametro> parametros;
            Parametro parametro;
            parametros = new List<Parametro>();

            try
            {
                laConexion = new BDConexion();
                parametros = new List<Parametro>();
                if (((Dojo)parametroDojo != null) && (((Dojo)parametroDojo).Dojo_Id != null))
                {
                    parametro = new Parametro(RecursosBDModulo15.parametroDojoIdImplemento, SqlDbType.Int, ((Dojo)parametroDojo).Dojo_Id.ToString(), false);
                    parametros.Add(parametro);
                }
                else
                {
                    ExcepcionListarInventarioDatos ex = new ExcepcionListarInventarioDatos(RecursosBDModulo15.parametroDojoIdImplemento,
                     RecursosBDModulo15.tabla_dojoImplemento, new Exception());
                    Logger.EscribirError("ConexionBaseDatos", ex);
                    throw ex;
                }

                DataTable dt = laConexion.EjecutarStoredProcedureTuplas(RecursosBDModulo15.nombreProcedureConsultarInventario, parametros);

                foreach (DataRow row in dt.Rows)
                {
                    Entidad implemento = (Implemento)FabricaEntidades.ObtenerImplemento();
                    ((Implemento)implemento).Dojo_Implemento = (Dojo)FabricaEntidades.tenerDojo();

                    ((Implemento)implemento).Id_Implemento = Convert.ToInt32(row[RecursosBDModulo15.tabla_idImplemento]);
                    ((Implemento)implemento).Nombre_Implemento = row[RecursosBDModulo15.tabla_nombreImplemento].ToString();
                    ((Implemento)implemento).Cantida_implemento = Convert.ToInt32(row[RecursosBDModulo15.tabla_cantidadImplemento]);
                    ((Implemento)implemento).Imagen_implemento = row[RecursosBDModulo15.tabla_imagenImplemento].ToString();
                    ((Implemento)implemento).Tipo_Implemento = row[RecursosBDModulo15.tabla_tipoImplemento].ToString();
                    ((Implemento)implemento).Marca_Implemento = row[RecursosBDModulo15.tabla_marcaImplemento].ToString();
                    ((Implemento)implemento).Color_Implemento = row[RecursosBDModulo15.tabla_colorImplemento].ToString();
                    ((Implemento)implemento).Talla_Implemento = row[RecursosBDModulo15.tabla_tallaImplemento].ToString();
                    ((Dojo)(((Implemento)implemento).Dojo_Implemento)).Dojo_Id = Convert.ToInt16(row[RecursosBDModulo15.tabla_dojoImplemento]);
                    ((Implemento)implemento).Stock_Minimo_Implemento = Convert.ToInt32(row[RecursosBDModulo15.tabla_stockImplemento]);
                    ((Implemento)implemento).Estatus_Implemento = row[RecursosBDModulo15.tabla_estatusImplemento].ToString();
                    ((Implemento)implemento).Precio_Implemento = Convert.ToDouble(row[RecursosBDModulo15.tabla_precioImplemento]);
                   // ((Implemento)implemento).Descripcion_Implemento = row[RecursosBDModulo15.tabla_descripcionImplemento].ToString();

                    listaDeImplementos.Add(implemento);

                }

            }
            catch (ExcepcionListarInventarioDatos ex)
            {
                ex = new ExcepcionListarInventarioDatos("Error en DAO listar inventario datos", new Exception());
                Logger.EscribirError("ConexionBaseDatos", ex);
                throw ex;

            }
            catch (ExceptionSKD ex)
            {
                ex = new ExcepcionesSKD.ExceptionSKD("No se pudo completar la operacion", new Exception());
                Logger.EscribirError("ConexionBaseDatos", ex);
                throw ex;
            }

            catch (Exception ex)
            {

                Logger.EscribirError("Error de en DAO listar inventario datos", ex);
                throw ex;
            }

            return listaDeImplementos;
        }
        #endregion

        #region listaInventarioDatos2
        /// <summary>
        /// Método que lista los datos de un inventario
        /// </summary>
        /// <param name="">Id del Dojo a consultar donde este el inventario</param>
        /// <returns>La clase Implemento</returns>
           List<Entidad> IDaoImplemento.listarInventarioDatos2(Entidad parametroDojo)
        {
            BDConexion laConexion;
            List<Entidad> listaDeImplementos = new List<Entidad>();
            List<Parametro> parametros;

            try
            {
                laConexion = new BDConexion();
                parametros = new List<Parametro>();
                Parametro parametro;
                if ((((Dojo)parametroDojo) != null) && (((Dojo)parametroDojo).Dojo_Id != null))
                {
                    parametro = new Parametro(RecursosBDModulo15.parametroDojoIdImplemento, SqlDbType.Int, ((Dojo)parametroDojo).Dojo_Id.ToString(), false);
                    parametros.Add(parametro);
                }
                else
                {
                    ExcepcionlistaInventarioDatos2 ex = new ExcepcionlistaInventarioDatos2(RecursosBDModulo15.parametroDojoIdImplemento,
                      RecursosBDModulo15.tabla_dojoImplemento, new Exception());
                    Logger.EscribirError("ConexionBaseDatos", ex);
                    throw ex;
                }
                DataTable dt = laConexion.EjecutarStoredProcedureTuplas(RecursosBDModulo15.nombreProcedureConsultarInventario2, parametros);

                foreach (DataRow row in dt.Rows)
                {
                    Entidad implemento = FabricaEntidades.ObtenerImplemento();
                    ((Implemento)implemento).Dojo_Implemento = new Dojo();
                    ((Implemento)implemento).Id_Implemento = Convert.ToInt32(row[RecursosBDModulo15.tabla_idImplemento]);
                    ((Implemento)implemento).Nombre_Implemento = row[RecursosBDModulo15.tabla_nombreImplemento].ToString();
                    ((Implemento)implemento).Cantida_implemento = Convert.ToInt32(row[RecursosBDModulo15.tabla_cantidadImplemento]);
                    ((Implemento)implemento).Imagen_implemento = row[RecursosBDModulo15.tabla_imagenImplemento].ToString();
                    ((Implemento)implemento).Tipo_Implemento = row[RecursosBDModulo15.tabla_tipoImplemento].ToString();
                    ((Implemento)implemento).Marca_Implemento = row[RecursosBDModulo15.tabla_marcaImplemento].ToString();
                    ((Implemento)implemento).Color_Implemento = row[RecursosBDModulo15.tabla_colorImplemento].ToString();
                    ((Implemento)implemento).Talla_Implemento = row[RecursosBDModulo15.tabla_tallaImplemento].ToString();
                    ((Dojo)(((Implemento)implemento).Dojo_Implemento)).Dojo_Id = Convert.ToInt32(row[RecursosBDModulo15.tabla_dojoImplemento]);
                    ((Implemento)implemento).Stock_Minimo_Implemento = Convert.ToInt32(row[RecursosBDModulo15.tabla_stockImplemento]);
                    ((Implemento)implemento).Estatus_Implemento = row[RecursosBDModulo15.tabla_estatusImplemento].ToString();
                    ((Implemento)implemento).Precio_Implemento = Convert.ToDouble(row[RecursosBDModulo15.tabla_precioImplemento]);
                    listaDeImplementos.Add(implemento);

                }

            }

            catch (ExcepcionlistaInventarioDatos2 ex)
            {
                ex = new ExcepcionlistaInventarioDatos2("Error en DAO listar inventario datos2", new Exception());
                Logger.EscribirError("ConexionBaseDatos", ex);
                throw ex;

            }
            catch (ExceptionSKD ex)
            {
                ex = new ExcepcionesSKD.ExceptionSKD("No se pudo completar la operacion", new Exception());
                Logger.EscribirError("ConexionBaseDatos", ex);
                throw ex;
            }


            catch (Exception ex)
            {

                Logger.EscribirError("Error de en DAO listar inventario datos2", ex);
                throw ex;
            }
            return listaDeImplementos;
        }
        #endregion 

        #region implementoInventarioDatos
           /// <summary>
           /// Método que lista los datos de un implemento
           /// </summary>
           /// <param name="">Id del implemento a consultar </param>
           /// <returns>La clase Implemento</returns>
          Entidad IDaoImplemento.implementoInventarioDatos(int idImplemento)
        {
            BDConexion laConexion;

            Entidad implemento = FabricaEntidades.ObtenerImplemento();
            ((Implemento)implemento).Dojo_Implemento = (Dojo)FabricaEntidades.tenerDojo();
            List<Parametro> parametros;
            Parametro parametro;
            try
            {
                laConexion = new BDConexion();
                parametros = new List<Parametro>();
                if (idImplemento != null)
                {
                    parametro = new Parametro(RecursosBDModulo15.parametroIdimplemento, SqlDbType.Int, idImplemento.ToString(), false);
                    parametros.Add(parametro);
                }
                else
                    throw new ExcepcionimplementoInventarioDatos(RecursosBDModulo15.parametroIdimplemento,
                        RecursosBDModulo15.tabla_idImplemento, new Exception());

                DataTable dt = laConexion.EjecutarStoredProcedureTuplas(RecursosBDModulo15.nombreProcedureConsultarImplemento, parametros);
                DataRow row;
                row = dt.Rows[0];


                ((Implemento)implemento).Id_Implemento = Convert.ToInt32(row[RecursosBDModulo15.tabla_idImplemento]);
                ((Implemento)implemento).Nombre_Implemento = row[RecursosBDModulo15.tabla_nombreImplemento].ToString();
                ((Implemento)implemento).Cantida_implemento = Convert.ToInt32(row[RecursosBDModulo15.tabla_cantidadImplemento]);
                ((Implemento)implemento).Imagen_implemento = row[RecursosBDModulo15.tabla_imagenImplemento].ToString();
                ((Implemento)implemento).Tipo_Implemento = row[RecursosBDModulo15.tabla_tipoImplemento].ToString();
                ((Implemento)implemento).Marca_Implemento = row[RecursosBDModulo15.tabla_marcaImplemento].ToString();
                ((Implemento)implemento).Color_Implemento = row[RecursosBDModulo15.tabla_colorImplemento].ToString();
                ((Implemento)implemento).Talla_Implemento = row[RecursosBDModulo15.tabla_tallaImplemento].ToString();
                ((Dojo)(((Implemento)implemento).Dojo_Implemento)).Dojo_Id = Convert.ToInt32(row[RecursosBDModulo15.tabla_dojoImplemento]);
                ((Implemento)implemento).Stock_Minimo_Implemento = Convert.ToInt32(row[RecursosBDModulo15.tabla_stockImplemento]);
                ((Implemento)implemento).Estatus_Implemento = row[RecursosBDModulo15.tabla_estatusImplemento].ToString();
                ((Implemento)implemento).Precio_Implemento = Convert.ToDouble(row[RecursosBDModulo15.tabla_precioImplemento]);
                ((Implemento)implemento).Descripcion_Implemento = row[RecursosBDModulo15.tabla_descripcionImplemento].ToString();


            }

            catch (ExcepcionimplementoInventarioDatos ex)
            {
                ex = new ExcepcionimplementoInventarioDatos("Error en DAO implemento inventario datos", new Exception());
                Logger.EscribirError("ConexionBaseDatos", ex);
                throw ex;

            }
            catch (ExceptionSKD ex)
            {
                ex = new ExcepcionesSKD.ExceptionSKD("No se pudo completar la operacion", new Exception());
                Logger.EscribirError("ConexionBaseDatos", ex);
                throw ex;
            }


            catch (Exception ex)
            {

                Logger.EscribirError("Error de en DAO implemento inventario datos", ex);
                throw ex;
            }
            return implemento;
        }

        #endregion

        #region eliminarInventarioDatos
          /// <summary>
          /// Método que elimina los datos de un implemento
          /// </summary>
          /// <param name="">Id del dojo donde se encuentra el implemento, id del inventario </param>
          /// <returns>La clase Implemento</returns>
          bool IDaoImplemento.eliminarInventarioDatos(int idInventario, Entidad parametroDojo)
          {
            BDConexion laConexion;
            List<Parametro> parametros;
            Parametro parametro;
            try
            {
                laConexion = new BDConexion();
                parametros = new List<Parametro>();
                if (idInventario != null)
                {
                    parametro = new Parametro(RecursosBDModulo15.parametroIdimplemento, SqlDbType.Int, idInventario.ToString(), false);
                    parametros.Add(parametro);
                }
                else
                    throw new ExcepcioneliminarInventarioDatos(RecursosBDModulo15.parametroIdimplemento,
                        RecursosBDModulo15.tabla_idImplemento, new Exception());

                if (((Dojo)parametroDojo) != null)
                {
                    parametro = new Parametro(RecursosBDModulo15.parametroDojoIdImplemento, SqlDbType.Int, ((Dojo)parametroDojo).Dojo_Id.ToString(), false);
                    parametros.Add(parametro);
                }
                else
                    throw new ExcepcioneliminarInventarioDatos(RecursosBDModulo15.parametroDojoIdImplemento,
                        RecursosBDModulo15.tabla_dojoImplemento, new Exception());

                laConexion.EjecutarStoredProcedureTuplas(RecursosBDModulo15.nombreProcedureEliminarInventario, parametros);
                return true;
            }


            catch (ExcepcioneliminarInventarioDatos ex)
            {
                ex = new ExcepcioneliminarInventarioDatos("Error en DAO eliminar inventario datos", new Exception());
                Logger.EscribirError("ConexionBaseDatos", ex);
                throw ex;

            }
            catch (ExceptionSKD ex)
            {
                ex = new ExcepcionesSKD.ExceptionSKD("No se pudo completar la operacion", new Exception());
                Logger.EscribirError("ConexionBaseDatos", ex);
                throw ex;
            }


            catch (Exception ex)
            {

                Logger.EscribirError("Error de en DAO eliminar inventario datos", ex);
                throw ex;
            }
            return false;
        }
        #endregion

        #region modificarInventarioDatos
          /// <summary>
          /// Método que modifica los datos de un implemento
          /// </summary>
          /// <param name="">Id del implemento a modificar </param>
          /// <returns>La clase Implemento</returns>
          bool IDaoImplemento.modificarInventarioDatos(Entidad parametroImplemento)
        {
            BDConexion laConexion;
            List<Parametro> parametros;
            Parametro parametro;
            //float precioNuevo = (float)precio_implemento;

            try
            {
                laConexion = new BDConexion();
                parametros = new List<Parametro>();

                if (((Implemento)parametroImplemento) != null)
                {

                    if (((Implemento)parametroImplemento).Id_Implemento != null)
                    {
                        parametro = new Parametro(RecursosBDModulo15.parametroIdimplemento, SqlDbType.Int, ((Implemento)parametroImplemento).Id_Implemento.ToString(), false);
                        parametros.Add(parametro);
                    }
                    else
                    {
                        ExcepcionmodificarInventarioDatos ex = new ExcepcionmodificarInventarioDatos(RecursosBDModulo15.parametroIdimplemento,
                        RecursosBDModulo15.tabla_idImplemento, new Exception());
                        Logger.EscribirError("ConexionBaseDatos", ex);
                        throw ex;
                    }
                    if ((((Implemento)parametroImplemento).Nombre_Implemento != null) && (((Implemento)parametroImplemento).Nombre_Implemento != ""))
                    {
                        parametro = new Parametro(RecursosBDModulo15.parametroNombreImplemento, SqlDbType.VarChar, ((Implemento)parametroImplemento).Nombre_Implemento, false);
                        parametros.Add(parametro);
                    }
                    else
                        throw new ExcepcionmodificarInventarioDatos(RecursosBDModulo15.parametroNombreImplemento,
                          RecursosBDModulo15.tabla_idImplemento, new Exception());

                    if ((((Implemento)parametroImplemento).Tipo_Implemento != null) && (((Implemento)parametroImplemento).Tipo_Implemento != ""))
                    {
                        parametro = new Parametro(RecursosBDModulo15.parametroTipoImplemento, SqlDbType.VarChar, ((Implemento)parametroImplemento).Tipo_Implemento, false);
                        parametros.Add(parametro);
                    }
                    else
                    {
                        ExcepcionmodificarInventarioDatos ex = new ExcepcionmodificarInventarioDatos(RecursosBDModulo15.parametroTipoImplemento,
                        RecursosBDModulo15.tabla_tipoImplemento, new Exception());
                        Logger.EscribirError("ConexionBaseDatos", ex);
                        throw ex;
                    }
                    if ((((Implemento)parametroImplemento).Marca_Implemento != null) && (((Implemento)parametroImplemento).Marca_Implemento != ""))
                    {
                        parametro = new Parametro(RecursosBDModulo15.parametroMarcaImplemento, SqlDbType.VarChar, ((Implemento)parametroImplemento).Marca_Implemento, false);
                        parametros.Add(parametro);
                    }
                    else
                    {
                        ExcepcionmodificarInventarioDatos ex = new ExcepcionmodificarInventarioDatos(RecursosBDModulo15.parametroMarcaImplemento,
                        RecursosBDModulo15.tabla_marcaImplemento, new Exception());
                        Logger.EscribirError("ConexionBaseDatos", ex);
                        throw ex;
                    }
                    if ((((Implemento)parametroImplemento).Color_Implemento != null) && (((Implemento)parametroImplemento).Color_Implemento != ""))
                    {
                        parametro = new Parametro(RecursosBDModulo15.parametroColorImplemento, SqlDbType.VarChar, ((Implemento)parametroImplemento).Color_Implemento, false);
                        parametros.Add(parametro);
                    }
                    else
                    {
                        ExcepcionmodificarInventarioDatos ex = new ExcepcionmodificarInventarioDatos(RecursosBDModulo15.parametroColorImplemento,
                        RecursosBDModulo15.tabla_colorImplemento, new Exception());
                        Logger.EscribirError("ConexionBaseDatos", ex);
                        throw ex;
                    }
                    if ((((Implemento)parametroImplemento).Talla_Implemento != null) && (((Implemento)parametroImplemento).Talla_Implemento != ""))
                    {
                        parametro = new Parametro(RecursosBDModulo15.parametroTallaImplemento, SqlDbType.VarChar, ((Implemento)parametroImplemento).Talla_Implemento, false);
                        parametros.Add(parametro);
                    }
                    else
                    {
                        ExcepcionmodificarInventarioDatos ex = new ExcepcionmodificarInventarioDatos(RecursosBDModulo15.parametroTallaImplemento,
                         RecursosBDModulo15.tabla_tallaImplemento, new Exception());
                        Logger.EscribirError("ConexionBaseDatos", ex);
                        throw ex;
                    }
                    if ((((Implemento)parametroImplemento).Precio_Implemento != null) && (((Implemento)parametroImplemento).Precio_Implemento > 0))
                    {

                        parametro = new Parametro(RecursosBDModulo15.parametroPrecioImplemento, SqlDbType.Float, ((float)((Implemento)parametroImplemento).Precio_Implemento).ToString(), false);
                        parametros.Add(parametro);
                    }
                    else
                    {
                        ExcepcionmodificarInventarioDatos ex = new ExcepcionmodificarInventarioDatos(RecursosBDModulo15.parametroPrecioImplemento,
                        RecursosBDModulo15.tabla_precioImplemento, new Exception());
                        Logger.EscribirError("ConexionBaseDatos", ex);
                        throw ex;
                    }
                    if ((((Implemento)parametroImplemento).Stock_Minimo_Implemento != null) && (((Implemento)parametroImplemento).Stock_Minimo_Implemento > 0))
                    {

                        parametro = new Parametro(RecursosBDModulo15.parametroStockMinimoImplemento, SqlDbType.Int, ((Implemento)parametroImplemento).Stock_Minimo_Implemento.ToString(), false);
                        parametros.Add(parametro);
                    }
                    else
                    {
                        ExcepcionmodificarInventarioDatos ex = new ExcepcionmodificarInventarioDatos(RecursosBDModulo15.parametroStockMinimoImplemento,
                        RecursosBDModulo15.tabla_stockImplemento, new Exception());
                        Logger.EscribirError("ConexionBaseDatos", ex);
                        throw ex;
                    }
                    if ((((Implemento)parametroImplemento).Cantida_implemento != null) && (((Implemento)parametroImplemento).Cantida_implemento > 0))
                    {

                        parametro = new Parametro(RecursosBDModulo15.parametroCantidadInventario, SqlDbType.Int, ((Implemento)parametroImplemento).Cantida_implemento.ToString(), false);
                        parametros.Add(parametro);
                    }
                    else
                    {
                        ExcepcionmodificarInventarioDatos ex = new ExcepcionmodificarInventarioDatos(RecursosBDModulo15.parametroCantidadInventario,
                        RecursosBDModulo15.tabla_cantidadImplemento, new Exception());
                        Logger.EscribirError("ConexionBaseDatos", ex);
                        throw ex;
                    }
                    if ((((Implemento)parametroImplemento).Descripcion_Implemento != null) && (((Implemento)parametroImplemento).Descripcion_Implemento != ""))
                    {

                        parametro = new Parametro(RecursosBDModulo15.parametroDescripcionImplemento, SqlDbType.VarChar, ((Implemento)parametroImplemento).Descripcion_Implemento, false);
                        parametros.Add(parametro);
                    }
                    else
                    {
                        ExcepcionmodificarInventarioDatos ex = new ExcepcionmodificarInventarioDatos(RecursosBDModulo15.parametroDescripcionImplemento,
                        RecursosBDModulo15.tabla_descripcionImplemento, new Exception());
                        Logger.EscribirError("ConexionBaseDatos", ex);
                        throw ex;
                    }
                    if (((Implemento)parametroImplemento).Dojo_Implemento != null)
                    {
                        parametro = new Parametro(RecursosBDModulo15.parametroDojoIdImplemento, SqlDbType.Int, ((Dojo)(((Implemento)parametroImplemento).Dojo_Implemento)).Dojo_Id.ToString(), false);
                        parametros.Add(parametro);
                    }
                    else
                    {
                        ExcepcionmodificarInventarioDatos ex = new ExcepcionmodificarInventarioDatos(RecursosBDModulo15.parametroDojoIdImplemento,
                        RecursosBDModulo15.tabla_dojoImplemento, new Exception());
                        Logger.EscribirError("ConexionBaseDatos", ex);
                        throw ex;
                    }
                    if ((((Implemento)parametroImplemento).Estatus_Implemento != null) && (((Implemento)parametroImplemento).Estatus_Implemento != ""))
                    {
                        parametro = new Parametro(RecursosBDModulo15.parametroEstatusImplemento, SqlDbType.VarChar, ((Implemento)parametroImplemento).Estatus_Implemento, false);
                        parametros.Add(parametro);
                    }
                    else
                    {
                        ExcepcionmodificarInventarioDatos ex = new ExcepcionmodificarInventarioDatos(RecursosBDModulo15.parametroEstatusImplemento,
                        RecursosBDModulo15.tabla_estatusImplemento, new Exception());
                        Logger.EscribirError("ConexionBaseDatos", ex);
                        throw ex;
                    }
                    if ((((Implemento)parametroImplemento).Imagen_implemento != null) && (((Implemento)parametroImplemento).Imagen_implemento != ""))
                    {
                        parametro = new Parametro(RecursosBDModulo15.parametroImagenImplemento, SqlDbType.VarChar, ((Implemento)parametroImplemento).Imagen_implemento, false);
                        parametros.Add(parametro);
                    }
                    else
                    {
                        ExcepcionmodificarInventarioDatos ex = new ExcepcionmodificarInventarioDatos(RecursosBDModulo15.parametroImagenImplemento,
                        RecursosBDModulo15.tabla_imagenImplemento, new Exception());
                        Logger.EscribirError("ConexionBaseDatos", ex);
                        throw ex;
                    }


                    laConexion.EjecutarStoredProcedureTuplas(RecursosBDModulo15.nombreProcedureModificarInventario, parametros);
                    return true;
                }
                else
                {
                    ExcepcionmodificarInventarioDatos ex = new ExcepcionmodificarInventarioDatos(RecursosBDModulo15.parametroImplemento, RecursosBDModulo15.tabla_implemento, new Exception());
                    Logger.EscribirError("ConexionBaseDatos", ex);
                    throw ex;
                }
            }


            catch (ExcepcionmodificarInventarioDatos ex)
            {
                ex = new ExcepcionmodificarInventarioDatos("Error en DAO modificar inventario datos", new Exception());
                Logger.EscribirError("ConexionBaseDatos", ex);
                throw ex;

            }
            catch (ExceptionSKD ex)
            {
                ex = new ExcepcionesSKD.ExceptionSKD("No se pudo completar la operacion", new Exception());
                Logger.EscribirError("ConexionBaseDatos", ex);
                throw ex;
            }


            catch (Exception ex)
            {

                Logger.EscribirError("Error de en DAO modificar inventario datos", ex);
                throw ex;
            }

            return false;
        }
        #endregion

        #region listarInventarioDatos
          /// <summary>
          /// Método que lista los datos de un implemento
          /// </summary>
          /// <param name=""> </param>
          /// <returns>La clase Implemento</returns>
            List<Entidad> IDaoImplemento.listarCarrito()
        {
            BDConexion laConexion;
            List<Entidad> listaDeImplementos = new List<Entidad>();
            List<Parametro> parametros;
            parametros = new List<Parametro>();


            try
            {
                laConexion = new BDConexion();
                parametros = new List<Parametro>();
                DataTable dt = laConexion.EjecutarStoredProcedureTuplas(RecursosBDModulo15.nombreProcedureConsultarCarrito, parametros);

                foreach (DataRow row in dt.Rows)
                {
                    Entidad implemento = FabricaEntidades.ObtenerImplemento();
                    ((Implemento)implemento).Dojo_Implemento = new Dojo();
                    ((Implemento)implemento).Id_Implemento = Convert.ToInt16(row[RecursosBDModulo15.tabla_idImplemento]);
                    ((Implemento)implemento).Nombre_Implemento = row[RecursosBDModulo15.tabla_nombreImplemento].ToString();
                    ((Implemento)implemento).Cantida_implemento = Convert.ToInt16(row[RecursosBDModulo15.tabla_cantidadImplemento]);
                    ((Implemento)implemento).Imagen_implemento = row[RecursosBDModulo15.tabla_imagenImplemento].ToString();
                    ((Implemento)implemento).Tipo_Implemento = row[RecursosBDModulo15.tabla_tipoImplemento].ToString();
                    ((Implemento)implemento).Marca_Implemento = row[RecursosBDModulo15.tabla_marcaImplemento].ToString();
                    ((Implemento)implemento).Color_Implemento = row[RecursosBDModulo15.tabla_colorImplemento].ToString();
                    ((Implemento)implemento).Talla_Implemento = row[RecursosBDModulo15.tabla_tallaImplemento].ToString();
                    ((Dojo)(((Implemento)implemento).Dojo_Implemento)).Dojo_Id = Convert.ToInt16(row[RecursosBDModulo15.tabla_dojoImplemento]);
                    ((Implemento)implemento).Stock_Minimo_Implemento = Convert.ToInt16(row[RecursosBDModulo15.tabla_stockImplemento]);
                    ((Implemento)implemento).Estatus_Implemento = row[RecursosBDModulo15.tabla_estatusImplemento].ToString();
                    ((Implemento)implemento).Precio_Implemento = Convert.ToDouble(row[RecursosBDModulo15.tabla_precioImplemento]);
                  //  ((Implemento)implemento).Descripcion_Implemento = row[RecursosBDModulo15.tabla_descripcionImplemento].ToString();
                    listaDeImplementos.Add(implemento);

                }

            }

            catch (ExcepcionListarInventarioDatos ex)
            {
                ex = new ExcepcionListarInventarioDatos("Error en DAO listar inventario datos", new Exception());
                Logger.EscribirError("ConexionBaseDatos", ex);
                throw ex;

            }
            catch (ExceptionSKD ex)
            {
                ex = new ExcepcionesSKD.ExceptionSKD("No se pudo completar la operacion", new Exception());
                Logger.EscribirError("ConexionBaseDatos", ex);
                throw ex;
            }


            catch (Exception ex)
            {

                Logger.EscribirError("Error de en DAO listar inventario datos", ex);
                throw ex;
            }
            return listaDeImplementos;
        }

        #endregion

        #region implementoInventarioDatosUltimo
            /// <summary>
            /// Método que lista los ultimos datos de un implemento
            /// </summary>
            /// <param name=""> </param>
            /// <returns>La clase Implemento</returns>
          Entidad IDaoImplemento.implementoInventarioDatosUltimo()
        {
            BDConexion laConexion;

            Entidad implemento = FabricaEntidades.ObtenerImplemento();
            ((Implemento)implemento).Dojo_Implemento = new Dojo();
            List<Parametro> parametros;
            try
            {
                laConexion = new BDConexion();
                parametros = new List<Parametro>();
                DataTable dt = laConexion.EjecutarStoredProcedureTuplas(RecursosBDModulo15.nombreProcedureConsultarImplementoU, parametros);
                DataRow row;
                row = dt.Rows[0];


                ((Implemento)implemento).Id_Implemento = Convert.ToInt16(row[RecursosBDModulo15.tabla_idImplemento]);
                ((Implemento)implemento).Nombre_Implemento = row[RecursosBDModulo15.tabla_nombreImplemento].ToString();
                ((Implemento)implemento).Cantida_implemento = Convert.ToInt16(row[RecursosBDModulo15.tabla_cantidadImplemento]);
                ((Implemento)implemento).Imagen_implemento = row[RecursosBDModulo15.tabla_imagenImplemento].ToString();
                ((Implemento)implemento).Tipo_Implemento = row[RecursosBDModulo15.tabla_tipoImplemento].ToString();
                ((Implemento)implemento).Marca_Implemento = row[RecursosBDModulo15.tabla_marcaImplemento].ToString();
                ((Implemento)implemento).Color_Implemento = row[RecursosBDModulo15.tabla_colorImplemento].ToString();
                ((Implemento)implemento).Talla_Implemento = row[RecursosBDModulo15.tabla_tallaImplemento].ToString();
                ((Dojo)(((Implemento)implemento).Dojo_Implemento)).Dojo_Id = Convert.ToInt16(row[RecursosBDModulo15.tabla_dojoImplemento]);
                ((Implemento)implemento).Stock_Minimo_Implemento = Convert.ToInt16(row[RecursosBDModulo15.tabla_stockImplemento]);
                ((Implemento)implemento).Estatus_Implemento = row[RecursosBDModulo15.tabla_estatusImplemento].ToString();
                ((Implemento)implemento).Precio_Implemento = Convert.ToDouble(row[RecursosBDModulo15.tabla_precioImplemento]);
                //((Implemento)implemento).Descripcion_Implemento = row[RecursosBDModulo15.tabla_descripcionImplemento].ToString();
            }


            catch (ExcepcionimplementoInventarioDatosUltimo ex)
            {
                ex = new ExcepcionimplementoInventarioDatosUltimo("Error en DAO implemento inventario datos ultimo", new Exception());
                Logger.EscribirError("ConexionBaseDatos", ex);
                throw ex;

            }
            catch (ExceptionSKD ex)
            {
                ex = new ExcepcionesSKD.ExceptionSKD("No se pudo completar la operacion", new Exception());
                Logger.EscribirError("ConexionBaseDatos", ex);
                throw ex;
            }


            catch (Exception ex)
            {

                Logger.EscribirError("Error de en DAO implemento inventario datos ultimos", ex);
                throw ex;
            }
            return implemento;
        }
        #endregion

        #region implementoInventarioDatosBool
          /// <summary>
          /// Método que lista los datos de un implemento en un inventario
          /// </summary>
          /// <param name="">Id del implemento a consultar </param>
          /// <returns>La clase Implemento</returns>
          bool IDaoImplemento.implementoInventarioDatosBool(int idImplemento)
          {
            BDConexion laConexion;
            FabricaEntidades fabrica = new FabricaEntidades();
            Entidad implemento = new Implemento();
            ((Implemento)implemento).Dojo_Implemento = new Dojo();
            List<Parametro> parametros;
            Parametro parametro;
            try
            {
                laConexion = new BDConexion();
                parametros = new List<Parametro>();
                if (idImplemento != null)
                {
                    parametro = new Parametro(RecursosBDModulo15.parametroIdimplemento, SqlDbType.Int, idImplemento.ToString(), false);
                    parametros.Add(parametro);
                }
                else
                    throw new ExcepcionimplementoInventarioDatosBool(RecursosBDModulo15.parametroIdimplemento,
                        RecursosBDModulo15.tabla_idImplemento, new Exception());

                DataTable dt = laConexion.EjecutarStoredProcedureTuplas(RecursosBDModulo15.nombreProcedureConsultarImplemento, parametros);
                DataRow row;
                row = dt.Rows[0];


                ((Implemento)implemento).Id_Implemento = Convert.ToInt16(row[RecursosBDModulo15.tabla_idImplemento]);
                ((Implemento)implemento).Nombre_Implemento = row[RecursosBDModulo15.tabla_nombreImplemento].ToString();
                ((Implemento)implemento).Cantida_implemento = Convert.ToInt16(row[RecursosBDModulo15.tabla_cantidadImplemento]);
                ((Implemento)implemento).Imagen_implemento = row[RecursosBDModulo15.tabla_imagenImplemento].ToString();
                ((Implemento)implemento).Tipo_Implemento = row[RecursosBDModulo15.tabla_tipoImplemento].ToString();
                ((Implemento)implemento).Marca_Implemento = row[RecursosBDModulo15.tabla_marcaImplemento].ToString();
                ((Implemento)implemento).Color_Implemento = row[RecursosBDModulo15.tabla_colorImplemento].ToString();
                ((Implemento)implemento).Talla_Implemento = row[RecursosBDModulo15.tabla_tallaImplemento].ToString();
                ((Dojo)(((Implemento)implemento).Dojo_Implemento)).Dojo_Id = Convert.ToInt16(row[RecursosBDModulo15.tabla_dojoImplemento]);
                ((Implemento)implemento).Stock_Minimo_Implemento = Convert.ToInt16(row[RecursosBDModulo15.tabla_stockImplemento]);
                ((Implemento)implemento).Estatus_Implemento = row[RecursosBDModulo15.tabla_estatusImplemento].ToString();
                ((Implemento)implemento).Precio_Implemento = Convert.ToDouble(row[RecursosBDModulo15.tabla_precioImplemento]);

            }


            catch (ExcepcionimplementoInventarioDatosBool ex)
            {
                ex = new ExcepcionimplementoInventarioDatosBool("Error en DAO Implemento Inventario Datos Bool", new Exception());
                Logger.EscribirError("ConexionBaseDatos", ex);
                throw ex;

            }
            catch (ExceptionSKD ex)
            {
                ex = new ExcepcionesSKD.ExceptionSKD("No se pudo completar la operacion", new Exception());
                Logger.EscribirError("ConexionBaseDatos", ex);
                throw ex;
            }


            catch (Exception ex)
            {

                Logger.EscribirError("Error de en DAO  implemento inventario datos ultimo", ex);
                throw ex;
            }
            if (((Implemento)implemento).Id_Implemento == idImplemento)
                return true;
            else
                return false;
        }
        #endregion

        #region usuarioImplementoDatos
          /// <summary>
          /// Método que lista los datos de un implemento por usuario
          /// </summary>
          /// <param name="">Id del usuario a consultar </param>
          /// <returns>La clase Implemento</returns>
          int IDaoImplemento.usuarioImplementoDatos(string usuario)
        {
            BDConexion laConexion;
            List<Parametro> parametros;
            Parametro parametro;
            int idDojo;
            try
            {
                laConexion = new BDConexion();
                parametros = new List<Parametro>();
                if (usuario != null)
                {
                    parametro = new Parametro(RecursosBDModulo15.parametroUsuario, SqlDbType.VarChar, usuario, false);
                    parametros.Add(parametro);
                }
                else
                    throw new ExcepcionusuarioImplementoDatos(RecursosBDModulo15.parametroUsuario,
                        RecursosBDModulo15.tabla_dojoImplemento, new Exception());

                DataTable dt = laConexion.EjecutarStoredProcedureTuplas(RecursosBDModulo15.nombreProcedureUsuario, parametros);
                DataRow row;
                row = dt.Rows[0];


                idDojo = Convert.ToInt16(row[RecursosBDModulo15.tabla_dojoImplemento]);
            }

            catch (ExcepcionusuarioImplementoDatos ex)
            {
                ex = new ExcepcionusuarioImplementoDatos("Error en DAO Usuario Implemento Datos", new Exception());
                Logger.EscribirError("ConexionBaseDatos", ex);
                throw ex;

            }
            catch (ExceptionSKD ex)
            {
                ex = new ExcepcionesSKD.ExceptionSKD("No se pudo completar la operacion", new Exception());
                Logger.EscribirError("ConexionBaseDatos", ex);
                throw ex;
            }


            catch (Exception ex)
            {

                Logger.EscribirError("Error de en DAO usuario implemento datos ", ex);
                throw ex;
            }
            return idDojo;
        }
#endregion

          #region 
          #endregion
        #endregion

          #region IDAO

          #region Agregar
          bool InterfazDAO.IDao<Entidad, bool, Entidad>.Agregar(Entidad parametro)
        {

            BDConexion laConexion;
            List<Parametro> parametros;
            Parametro elParametro;


            try
            {
                //float precioNuevo = (float)precio_implemento;
                laConexion = new BDConexion();
                parametros = new List<Parametro>();
                if (((Implemento)parametro) != null)
                {


                    if ((((Implemento)parametro).Nombre_Implemento != null) && (((Implemento)parametro).Nombre_Implemento != ""))
                    {
                        elParametro = new Parametro(RecursosBDModulo15.parametroNombreImplemento, SqlDbType.VarChar, ((Implemento)parametro).Nombre_Implemento, false);

                        parametros.Add(elParametro);
                    }
                    else
                    {
                        ErrorEnParametroDeProcedure ex = new ExcepcionesSKD.Modulo15.ErrorEnParametroDeProcedure(RecursosBDModulo15.parametroNombreImplemento,
                        RecursosBDModulo15.tabla_idImplemento, new Exception());
                        Logger.EscribirError("ConexionBaseDatos", ex);
                        throw ex;
                    }
                    if ((((Implemento)parametro).Tipo_Implemento != null) && (((Implemento)parametro).Tipo_Implemento != ""))
                    {
                        elParametro = new Parametro(RecursosBDModulo15.parametroTipoImplemento, SqlDbType.VarChar, ((Implemento)parametro).Tipo_Implemento, false);
                        parametros.Add(elParametro);
                    }
                    else
                    {
                        ErrorEnParametroDeProcedure ex = new ExcepcionesSKD.Modulo15.ErrorEnParametroDeProcedure(RecursosBDModulo15.parametroTipoImplemento,
                        RecursosBDModulo15.tabla_tipoImplemento, new Exception());
                        Logger.EscribirError("ConexionBaseDatos", ex);
                        throw ex;
                    }
                    if ((((Implemento)parametro).Marca_Implemento != null) && (((Implemento)parametro).Marca_Implemento != ""))
                    {
                        elParametro = new Parametro(RecursosBDModulo15.parametroMarcaImplemento, SqlDbType.VarChar, ((Implemento)parametro).Marca_Implemento, false);
                        parametros.Add(elParametro);
                    }
                    else
                    {
                        ErrorEnParametroDeProcedure ex = new ExcepcionesSKD.Modulo15.ErrorEnParametroDeProcedure(RecursosBDModulo15.parametroMarcaImplemento,
                        RecursosBDModulo15.tabla_marcaImplemento, new Exception());
                        Logger.EscribirError("ConexionBaseDatos", ex);
                        throw ex;
                    }
                    if ((((Implemento)parametro).Color_Implemento != null) && (((Implemento)parametro).Color_Implemento != ""))
                    {
                        elParametro = new Parametro(RecursosBDModulo15.parametroColorImplemento, SqlDbType.VarChar, ((Implemento)parametro).Color_Implemento, false);
                        parametros.Add(elParametro);
                    }
                    else
                    {
                        ErrorEnParametroDeProcedure ex = new ExcepcionesSKD.Modulo15.ErrorEnParametroDeProcedure(RecursosBDModulo15.parametroColorImplemento,
                        RecursosBDModulo15.tabla_colorImplemento, new Exception());
                        Logger.EscribirError("ConexionBaseDatos", ex);
                        throw ex;
                    }
                    if ((((Implemento)parametro).Talla_Implemento != null) && (((Implemento)parametro).Talla_Implemento != ""))
                    {
                        elParametro = new Parametro(RecursosBDModulo15.parametroTallaImplemento, SqlDbType.VarChar, ((Implemento)parametro).Talla_Implemento, false);
                        parametros.Add(elParametro);
                    }
                    else
                    {
                        ErrorEnParametroDeProcedure ex = new ExcepcionesSKD.Modulo15.ErrorEnParametroDeProcedure(RecursosBDModulo15.parametroTallaImplemento,
                         RecursosBDModulo15.tabla_tallaImplemento, new Exception());
                        Logger.EscribirError("ConexionBaseDatos", ex);
                        throw ex;
                    }
                    if ((((Implemento)parametro).Precio_Implemento != null) && (((Implemento)parametro).Precio_Implemento > 0))
                    {

                        elParametro = new Parametro(RecursosBDModulo15.parametroPrecioImplemento, SqlDbType.Float, ((float)((Implemento)parametro).Precio_Implemento).ToString(), false);
                        parametros.Add(elParametro);
                    }
                    else
                    {
                        ErrorEnParametroDeProcedure ex = new ExcepcionesSKD.Modulo15.ErrorEnParametroDeProcedure(RecursosBDModulo15.parametroPrecioImplemento,
                        RecursosBDModulo15.tabla_precioImplemento, new Exception());
                        Logger.EscribirError("ConexionBaseDatos", ex);
                        throw ex;
                    }
                    if ((((Implemento)parametro).Stock_Minimo_Implemento != null) && (((Implemento)parametro).Stock_Minimo_Implemento > 0))
                    {

                        elParametro = new Parametro(RecursosBDModulo15.parametroStockMinimoImplemento, SqlDbType.Int, ((Implemento)parametro).Stock_Minimo_Implemento.ToString(), false);
                        parametros.Add(elParametro);
                    }
                    else
                    {
                        ErrorEnParametroDeProcedure ex = new ExcepcionesSKD.Modulo15.ErrorEnParametroDeProcedure(RecursosBDModulo15.parametroStockMinimoImplemento,
                        RecursosBDModulo15.tabla_stockImplemento, new Exception());
                        Logger.EscribirError("ConexionBaseDatos", ex);
                        throw ex;
                    }

                    if ((((Implemento)parametro).Cantida_implemento != null) && (((Implemento)parametro).Cantida_implemento > 0))
                    {

                        elParametro = new Parametro(RecursosBDModulo15.parametroCantidadInventario, SqlDbType.Int, ((Implemento)parametro).Cantida_implemento.ToString(), false);
                        parametros.Add(elParametro);
                    }
                    else
                    {
                        ErrorEnParametroDeProcedure ex = new ExcepcionesSKD.Modulo15.ErrorEnParametroDeProcedure(RecursosBDModulo15.parametroCantidadInventario,
                        RecursosBDModulo15.tabla_cantidadImplemento, new Exception());
                        Logger.EscribirError("ConexionBaseDatos", ex);
                        throw ex;
                    }
                    if ((((Implemento)parametro).Descripcion_Implemento != null) && (((Implemento)parametro).Descripcion_Implemento != ""))
                    {

                        elParametro = new Parametro(RecursosBDModulo15.parametroDescripcionImplemento, SqlDbType.VarChar, ((Implemento)parametro).Descripcion_Implemento, false);
                        parametros.Add(elParametro);

                    }
                    else
                    {
                        ErrorEnParametroDeProcedure ex = new ExcepcionesSKD.Modulo15.ErrorEnParametroDeProcedure(RecursosBDModulo15.parametroDescripcionImplemento,
                        RecursosBDModulo15.tabla_descripcionImplemento, new Exception());
                        Logger.EscribirError("ConexionBaseDatos", ex);
                        throw ex;
                    }
                    if (((Implemento)parametro).Dojo_Implemento != null)
                    {
                        elParametro = new Parametro(RecursosBDModulo15.parametroDojoIdImplemento, SqlDbType.Int, ((Dojo)(((Implemento)parametro).Dojo_Implemento)).Dojo_Id.ToString(), false);
                        parametros.Add(elParametro);
                    }
                    else
                    {
                        ErrorEnParametroDeProcedure ex = new ExcepcionesSKD.Modulo15.ErrorEnParametroDeProcedure(RecursosBDModulo15.parametroDojoIdImplemento,
                        RecursosBDModulo15.tabla_dojoImplemento, new Exception());
                        Logger.EscribirError("ConexionBaseDatos", ex);
                        throw ex;
                    }
                    if ((((Implemento)parametro).Imagen_implemento != null) && (((Implemento)parametro).Imagen_implemento != ""))
                    {
                        elParametro = new Parametro(RecursosBDModulo15.parametroImagenImplemento, SqlDbType.VarChar, ((Implemento)parametro).Imagen_implemento, false);
                        parametros.Add(elParametro);
                    }
                    else
                    {
                        ErrorEnParametroDeProcedure ex = new ExcepcionesSKD.Modulo15.ErrorEnParametroDeProcedure(RecursosBDModulo15.parametroImagenImplemento,
                        RecursosBDModulo15.tabla_imagenImplemento, new Exception());
                        Logger.EscribirError("ConexionBaseDatos", ex);
                        throw ex;
                    }

                    laConexion.EjecutarStoredProcedureTuplas(RecursosBDModulo15.nombreProcedureAgregarInventario, parametros);
                    return true;
                }

                else
                {
                    ErrorEnParametroDeProcedure ex = new ExcepcionesSKD.Modulo15.ErrorEnParametroDeProcedure(RecursosBDModulo15.parametroImplemento, RecursosBDModulo15.tabla_implemento, new Exception());
                    Logger.EscribirError("ConexionBaseDatos", ex);
                    throw ex;

                }
            }
            catch (ErrorEnParametroDeProcedure ex)
            {

                throw ex;
            }
            catch (ExceptionSKD ex)
            {
                Logger.EscribirError("ConexionBaseDatos", ex);
                throw new ExcepcionesSKD.ExceptionSKD("No se pudo completar la operacion", new Exception());

            }
        }
        #endregion

        #region Modificar
          bool InterfazDAO.IDao<Entidad, bool, Entidad>.Modificar(Entidad parametro)
        {
            BDConexion laConexion;
            List<Parametro> parametros;
            Parametro elParametro;
            //float precioNuevo = (float)precio_implemento;

            try
            {
                laConexion = new BDConexion();
                parametros = new List<Parametro>();

                if (((Implemento)parametro) != null)
                {

                    if (((Implemento)parametro).Id_Implemento != null)
                    {
                        elParametro = new Parametro(RecursosBDModulo15.parametroIdimplemento, SqlDbType.Int, ((Implemento)parametro).Id_Implemento.ToString(), false);
                        parametros.Add(elParametro);
                    }
                    else
                    {
                        ErrorEnParametroDeProcedure ex = new ExcepcionesSKD.Modulo15.ErrorEnParametroDeProcedure(RecursosBDModulo15.parametroIdimplemento,
                        RecursosBDModulo15.tabla_idImplemento, new Exception());
                        Logger.EscribirError("ConexionBaseDatos", ex);
                        throw ex;
                    }
                    if ((((Implemento)parametro).Nombre_Implemento != null) && (((Implemento)parametro).Nombre_Implemento != ""))
                    {
                        elParametro = new Parametro(RecursosBDModulo15.parametroNombreImplemento, SqlDbType.VarChar, ((Implemento)parametro).Nombre_Implemento, false);
                        parametros.Add(elParametro);
                    }
                    else
                        throw new ExcepcionesSKD.Modulo15.ErrorEnParametroDeProcedure(RecursosBDModulo15.parametroNombreImplemento,
                          RecursosBDModulo15.tabla_idImplemento, new Exception());

                    if ((((Implemento)parametro).Tipo_Implemento != null) && (((Implemento)parametro).Tipo_Implemento != ""))
                    {
                        elParametro = new Parametro(RecursosBDModulo15.parametroTipoImplemento, SqlDbType.VarChar, ((Implemento)parametro).Tipo_Implemento, false);
                        parametros.Add(elParametro);
                    }
                    else
                    {
                        ErrorEnParametroDeProcedure ex = new ExcepcionesSKD.Modulo15.ErrorEnParametroDeProcedure(RecursosBDModulo15.parametroTipoImplemento,
                        RecursosBDModulo15.tabla_tipoImplemento, new Exception());
                        Logger.EscribirError("ConexionBaseDatos", ex);
                        throw ex;
                    }
                    if ((((Implemento)parametro).Marca_Implemento != null) && (((Implemento)parametro).Marca_Implemento != ""))
                    {
                        elParametro = new Parametro(RecursosBDModulo15.parametroMarcaImplemento, SqlDbType.VarChar, ((Implemento)parametro).Marca_Implemento, false);
                        parametros.Add(elParametro);
                    }
                    else
                    {
                        ErrorEnParametroDeProcedure ex = new ExcepcionesSKD.Modulo15.ErrorEnParametroDeProcedure(RecursosBDModulo15.parametroMarcaImplemento,
                        RecursosBDModulo15.tabla_marcaImplemento, new Exception());
                        Logger.EscribirError("ConexionBaseDatos", ex);
                        throw ex;
                    }
                    if ((((Implemento)parametro).Color_Implemento != null) && (((Implemento)parametro).Color_Implemento != ""))
                    {
                        elParametro = new Parametro(RecursosBDModulo15.parametroColorImplemento, SqlDbType.VarChar, ((Implemento)parametro).Color_Implemento, false);
                        parametros.Add(elParametro);
                    }
                    else
                    {
                        ErrorEnParametroDeProcedure ex = new ExcepcionesSKD.Modulo15.ErrorEnParametroDeProcedure(RecursosBDModulo15.parametroColorImplemento,
                        RecursosBDModulo15.tabla_colorImplemento, new Exception());
                        Logger.EscribirError("ConexionBaseDatos", ex);
                        throw ex;
                    }
                    if ((((Implemento)parametro).Talla_Implemento != null) && (((Implemento)parametro).Talla_Implemento != ""))
                    {
                        elParametro = new Parametro(RecursosBDModulo15.parametroTallaImplemento, SqlDbType.VarChar, ((Implemento)parametro).Talla_Implemento, false);
                        parametros.Add(elParametro);
                    }
                    else
                    {
                        ErrorEnParametroDeProcedure ex = new ExcepcionesSKD.Modulo15.ErrorEnParametroDeProcedure(RecursosBDModulo15.parametroTallaImplemento,
                         RecursosBDModulo15.tabla_tallaImplemento, new Exception());
                        Logger.EscribirError("ConexionBaseDatos", ex);
                        throw ex;
                    }
                    if ((((Implemento)parametro).Precio_Implemento != null) && (((Implemento)parametro).Precio_Implemento > 0))
                    {

                        elParametro = new Parametro(RecursosBDModulo15.parametroPrecioImplemento, SqlDbType.Float, ((float)((Implemento)parametro).Precio_Implemento).ToString(), false);
                        parametros.Add(elParametro);
                    }
                    else
                    {
                        ErrorEnParametroDeProcedure ex = new ExcepcionesSKD.Modulo15.ErrorEnParametroDeProcedure(RecursosBDModulo15.parametroPrecioImplemento,
                        RecursosBDModulo15.tabla_precioImplemento, new Exception());
                        Logger.EscribirError("ConexionBaseDatos", ex);
                        throw ex;
                    }
                    if ((((Implemento)parametro).Stock_Minimo_Implemento != null) && (((Implemento)parametro).Stock_Minimo_Implemento > 0))
                    {

                        elParametro = new Parametro(RecursosBDModulo15.parametroStockMinimoImplemento, SqlDbType.Int, ((Implemento)parametro).Stock_Minimo_Implemento.ToString(), false);
                        parametros.Add(elParametro);
                    }
                    else
                    {
                        ErrorEnParametroDeProcedure ex = new ExcepcionesSKD.Modulo15.ErrorEnParametroDeProcedure(RecursosBDModulo15.parametroStockMinimoImplemento,
                        RecursosBDModulo15.tabla_stockImplemento, new Exception());
                        Logger.EscribirError("ConexionBaseDatos", ex);
                        throw ex;
                    }
                    if ((((Implemento)parametro).Cantida_implemento != null) && (((Implemento)parametro).Cantida_implemento > 0))
                    {

                        elParametro = new Parametro(RecursosBDModulo15.parametroCantidadInventario, SqlDbType.Int, ((Implemento)parametro).Cantida_implemento.ToString(), false);
                        parametros.Add(elParametro);
                    }
                    else
                    {
                        ErrorEnParametroDeProcedure ex = new ExcepcionesSKD.Modulo15.ErrorEnParametroDeProcedure(RecursosBDModulo15.parametroCantidadInventario,
                        RecursosBDModulo15.tabla_cantidadImplemento, new Exception());
                        Logger.EscribirError("ConexionBaseDatos", ex);
                        throw ex;
                    }
                    if ((((Implemento)parametro).Descripcion_Implemento != null) && (((Implemento)parametro).Descripcion_Implemento != ""))
                    {

                        elParametro = new Parametro(RecursosBDModulo15.parametroDescripcionImplemento, SqlDbType.VarChar, ((Implemento)parametro).Descripcion_Implemento, false);
                        parametros.Add(elParametro);
                    }
                    else
                    {
                        ErrorEnParametroDeProcedure ex = new ExcepcionesSKD.Modulo15.ErrorEnParametroDeProcedure(RecursosBDModulo15.parametroDescripcionImplemento,
                        RecursosBDModulo15.tabla_descripcionImplemento, new Exception());
                        Logger.EscribirError("ConexionBaseDatos", ex);
                        throw ex;
                    }
                    if (((Implemento)parametro).Dojo_Implemento != null)
                    {
                        elParametro = new Parametro(RecursosBDModulo15.parametroDojoIdImplemento, SqlDbType.Int, ((Dojo)(((Implemento)parametro).Dojo_Implemento)).Dojo_Id.ToString(), false);
                        parametros.Add(elParametro);
                    }
                    else
                    {
                        ErrorEnParametroDeProcedure ex = new ExcepcionesSKD.Modulo15.ErrorEnParametroDeProcedure(RecursosBDModulo15.parametroDojoIdImplemento,
                        RecursosBDModulo15.tabla_dojoImplemento, new Exception());
                        Logger.EscribirError("ConexionBaseDatos", ex);
                        throw ex;
                    }
                    if ((((Implemento)parametro).Estatus_Implemento != null) && (((Implemento)parametro).Estatus_Implemento != ""))
                    {
                        elParametro = new Parametro(RecursosBDModulo15.parametroEstatusImplemento, SqlDbType.VarChar, ((Implemento)parametro).Estatus_Implemento, false);
                        parametros.Add(elParametro);
                    }
                    else
                    {
                        ErrorEnParametroDeProcedure ex = new ExcepcionesSKD.Modulo15.ErrorEnParametroDeProcedure(RecursosBDModulo15.parametroEstatusImplemento,
                        RecursosBDModulo15.tabla_estatusImplemento, new Exception());
                        Logger.EscribirError("ConexionBaseDatos", ex);
                        throw ex;
                    }
                    if ((((Implemento)parametro).Imagen_implemento != null) && (((Implemento)parametro).Imagen_implemento != ""))
                    {
                        elParametro = new Parametro(RecursosBDModulo15.parametroImagenImplemento, SqlDbType.VarChar, ((Implemento)parametro).Imagen_implemento, false);
                        parametros.Add(elParametro);
                    }
                    else
                    {
                        ErrorEnParametroDeProcedure ex = new ExcepcionesSKD.Modulo15.ErrorEnParametroDeProcedure(RecursosBDModulo15.parametroImagenImplemento,
                        RecursosBDModulo15.tabla_imagenImplemento, new Exception());
                        Logger.EscribirError("ConexionBaseDatos", ex);
                        throw ex;
                    }


                    laConexion.EjecutarStoredProcedureTuplas(RecursosBDModulo15.nombreProcedureModificarInventario, parametros);
                    return true;
                }
                else
                {
                    ErrorEnParametroDeProcedure ex = new ExcepcionesSKD.Modulo15.ErrorEnParametroDeProcedure(RecursosBDModulo15.parametroImplemento, RecursosBDModulo15.tabla_implemento, new Exception());
                    Logger.EscribirError("ConexionBaseDatos", ex);
                    throw ex;
                }
            }

            catch (SqlException ex)
            {
                throw new ExcepcionesSKD.ExceptionSKDConexionBD(RecursoGeneralBD.Codigo,
                   RecursoGeneralBD.Mensaje, new Exception());
            }

            catch (ErrorEnParametroDeProcedure ex)
            {

                throw ex;
            }
            catch (Exception ex)
            {

                throw new ExcepcionesSKD.ExceptionSKD("No se pudo completar la operacion", new Exception());
            }
            return false;
        }
        #endregion

        #region ConsultarXId
           Entidad InterfazDAO.IDao<Entidad, bool, Entidad>.ConsultarXId(Entidad parametro)
        {
            BDConexion laConexion;

            Entidad implemento = FabricaEntidades.ObtenerImplemento();
            ((Implemento)implemento).Dojo_Implemento = (Dojo)FabricaEntidades.tenerDojo();
            List<Parametro> parametros;
            Parametro elParametro;
            try
            {
                laConexion = new BDConexion();
                parametros = new List<Parametro>();
                if (((Implemento)parametro).Id_Implemento != null)
                {
                    elParametro = new Parametro(RecursosBDModulo15.parametroIdimplemento, SqlDbType.Int, ((Implemento)parametro).Id_Implemento.ToString(), false);
                    parametros.Add(elParametro);
                }
                else
                    throw new ExcepcionesSKD.Modulo15.ErrorEnParametroDeProcedure(RecursosBDModulo15.parametroIdimplemento,
                        RecursosBDModulo15.tabla_idImplemento, new Exception());

                DataTable dt = laConexion.EjecutarStoredProcedureTuplas(RecursosBDModulo15.nombreProcedureConsultarImplemento, parametros);
                DataRow row;
                row = dt.Rows[0];


                ((Implemento)implemento).Id_Implemento = Convert.ToInt16(row[RecursosBDModulo15.tabla_idImplemento]);
                ((Implemento)implemento).Nombre_Implemento = row[RecursosBDModulo15.tabla_nombreImplemento].ToString();
                ((Implemento)implemento).Cantida_implemento = Convert.ToInt16(row[RecursosBDModulo15.tabla_cantidadImplemento]);
                ((Implemento)implemento).Imagen_implemento = row[RecursosBDModulo15.tabla_imagenImplemento].ToString();
                ((Implemento)implemento).Tipo_Implemento = row[RecursosBDModulo15.tabla_tipoImplemento].ToString();
                ((Implemento)implemento).Marca_Implemento = row[RecursosBDModulo15.tabla_marcaImplemento].ToString();
                ((Implemento)implemento).Color_Implemento = row[RecursosBDModulo15.tabla_colorImplemento].ToString();
                ((Implemento)implemento).Talla_Implemento = row[RecursosBDModulo15.tabla_tallaImplemento].ToString();
                ((Dojo)(((Implemento)implemento).Dojo_Implemento)).Dojo_Id = Convert.ToInt16(row[RecursosBDModulo15.tabla_dojoImplemento]);
                ((Implemento)implemento).Stock_Minimo_Implemento = Convert.ToInt16(row[RecursosBDModulo15.tabla_stockImplemento]);
                ((Implemento)implemento).Estatus_Implemento = row[RecursosBDModulo15.tabla_estatusImplemento].ToString();
                ((Implemento)implemento).Precio_Implemento = Convert.ToDouble(row[RecursosBDModulo15.tabla_precioImplemento]);
                ((Implemento)implemento).Descripcion_Implemento = row[RecursosBDModulo15.tabla_descripcionImplemento].ToString();


            }

            catch (SqlException ex)
            {
                throw new ExcepcionesSKD.ExceptionSKDConexionBD(RecursoGeneralBD.Codigo,
                   RecursoGeneralBD.Mensaje, new Exception());
            }
            catch (Exception ex)
            {
                throw new ExcepcionesSKD.ExceptionSKD("No se pudo completar la operacion", new Exception());
            }

            return implemento;
        }
        #endregion

        #region ConsultarTodos
         List<Entidad> InterfazDAO.IDao<Entidad, bool, Entidad>.ConsultarTodos()
        {
            BDConexion laConexion;
            List<Entidad> listaDeImplementos = new List<Entidad>();
            List<Parametro> parametros;
            parametros = new List<Parametro>();


            try
            {
                laConexion = new BDConexion();
                parametros = new List<Parametro>();
                DataTable dt = laConexion.EjecutarStoredProcedureTuplas(RecursosBDModulo15.nombreProcedureConsultarCarrito, parametros);

                foreach (DataRow row in dt.Rows)
                {
                    Entidad implemento = FabricaEntidades.ObtenerImplemento();
                    ((Implemento)implemento).Dojo_Implemento = new Dojo();
                    ((Implemento)implemento).Id_Implemento = Convert.ToInt16(row[RecursosBDModulo15.tabla_idImplemento]);
                    ((Implemento)implemento).Nombre_Implemento = row[RecursosBDModulo15.tabla_nombreImplemento].ToString();
                    ((Implemento)implemento).Cantida_implemento = Convert.ToInt16(row[RecursosBDModulo15.tabla_cantidadImplemento]);
                    ((Implemento)implemento).Imagen_implemento = row[RecursosBDModulo15.tabla_imagenImplemento].ToString();
                    ((Implemento)implemento).Tipo_Implemento = row[RecursosBDModulo15.tabla_tipoImplemento].ToString();
                    ((Implemento)implemento).Marca_Implemento = row[RecursosBDModulo15.tabla_marcaImplemento].ToString();
                    ((Implemento)implemento).Color_Implemento = row[RecursosBDModulo15.tabla_colorImplemento].ToString();
                    ((Implemento)implemento).Talla_Implemento = row[RecursosBDModulo15.tabla_tallaImplemento].ToString();
                    ((Dojo)(((Implemento)implemento).Dojo_Implemento)).Dojo_Id = Convert.ToInt16(row[RecursosBDModulo15.tabla_dojoImplemento]);
                    ((Implemento)implemento).Stock_Minimo_Implemento = Convert.ToInt16(row[RecursosBDModulo15.tabla_stockImplemento]);
                    ((Implemento)implemento).Estatus_Implemento = row[RecursosBDModulo15.tabla_estatusImplemento].ToString();
                    ((Implemento)implemento).Precio_Implemento = Convert.ToDouble(row[RecursosBDModulo15.tabla_precioImplemento]);
                    ((Implemento)implemento).Descripcion_Implemento = row[RecursosBDModulo15.tabla_descripcionImplemento].ToString();
                    listaDeImplementos.Add(implemento);

                }

            }
            catch (SqlException ex)
            {
                throw new ExcepcionesSKD.ExceptionSKDConexionBD(RecursoGeneralBD.Codigo,
                   RecursoGeneralBD.Mensaje, new Exception());
            }
            catch (Exception ex)
            {
                throw new ExcepcionesSKD.ExceptionSKD("No se pudo completar la operacion", new Exception());
            }

            return listaDeImplementos;
        }
        #endregion

        #endregion



        
    }
}
