using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using DominioSKD;
using DominioSKD.Entidades.Modulo8;

namespace DatosSKD.DAO.Modulo8
{
    public class DAORestriccionCompetencia : DAOGeneral, InterfazDAO.Modulo8.IDaoRestriccionCompetencia
    {
       #region Metodos IDao
       
       #region Agregar
        /// <summary>
        /// Metodo para agregar una restriccion de competencia a la base de datos.
        /// </summary>
        /// <param name="parametro"></param>
        /// <returns></returns>
        
            public Boolean Agregar(DominioSKD.Entidad parametro)
            {

                DominioSKD.Entidades.Modulo8.RestriccionCompetencia laRestriccionCompetencia =
                (DominioSKD.Entidades.Modulo8.RestriccionCompetencia)parametro;
                
                try
                {
                
                    if (!ExisteRestriccionCompetenciaSimilar(laRestriccionCompetencia))
                    {

                        List<Parametro> parametros;
                        
                        parametros = new List<Parametro>();

                        Parametro elParametro;
                        
                        elParametro = new Parametro(RecursosDAORestriccionCompetencia.ParamDescripcion, SqlDbType.VarChar,
                        laRestriccionCompetencia.Descripcion, false);
                        
                        parametros.Add(elParametro);

                        elParametro = new Parametro(RecursosDAORestriccionCompetencia.ParamEdadMin, SqlDbType.Int,
                        laRestriccionCompetencia.EdadMinima.ToString(), false);
                        
                        parametros.Add(elParametro);

                        elParametro = new Parametro(RecursosDAORestriccionCompetencia.ParamEdadMax, SqlDbType.Int,
                        laRestriccionCompetencia.EdadMaxima.ToString(), false);
                        
                        parametros.Add(elParametro);

                        elParametro = new Parametro(RecursosDAORestriccionCompetencia.ParamRangoMin, SqlDbType.Int,
                        laRestriccionCompetencia.RangoMinimo.ToString(), false);
                        
                        parametros.Add(elParametro);

                        elParametro = new Parametro(RecursosDAORestriccionCompetencia.ParamRangoMax, SqlDbType.Int,
                        laRestriccionCompetencia.RangoMaximo.ToString(), false);
                        
                        parametros.Add(elParametro);

                        elParametro = new Parametro(RecursosDAORestriccionCompetencia.ParamSexo, SqlDbType.VarChar,
                        laRestriccionCompetencia.Sexo, false);
                        
                        parametros.Add(elParametro);

                        elParametro = new Parametro(RecursosDAORestriccionCompetencia.ParamModalidad, SqlDbType.VarChar,
                        laRestriccionCompetencia.Modalidad, false);
                        
                        parametros.Add(elParametro);

                        EjecutarStoredProcedure(RecursosDAORestriccionCompetencia.AgregarRestriccionCompetencia
                        , parametros);

                    }
                    else
                    {     
                    
                        throw new ExcepcionesSKD.Modulo8.RestriccionExistenteException(RecursosDAORestriccionCompetencia.Codigo_Restriccion_Competencia_Existente,
                        RecursosDAORestriccionCompetencia.Mensaje_Restriccion_Competencia_Existente, new Exception());
                    
                    }
                
                }
                catch (SqlException ex)
                {
                
                    throw new ExcepcionesSKD.ExceptionSKDConexionBD(RecursoGeneralBD.Codigo,
                    RecursoGeneralBD.Mensaje, ex);
                
                }
                catch (FormatException ex)
                {

                    throw new ExcepcionesSKD.Modulo8.FormatoIncorrectoException(RecursosDAORestriccionCompetencia.Codigo_Error_Formato,
                    RecursosDAORestriccionCompetencia.Mensaje_Error_Formato, ex);
                
                }
                catch (ExcepcionesSKD.ExceptionSKDConexionBD ex)
                {

                    throw ex;
                
                }
                catch (Exception ex)
                {

                    throw new ExcepcionesSKD.ExceptionSKD(RecursoGeneralBD.Mensaje_Generico_Error, ex);
                
                }
                
                return true;
            
            }
        #endregion

       #region Modificar
            public Boolean Modificar (DominioSKD.Entidad parametro)
            {
                throw new NotImplementedException();
            }
            #endregion

       #region ConsultarXId

            public DominioSKD.Entidad ConsultarXId(DominioSKD.Entidad parametro)
            {
                throw new NotImplementedException();
            }    

            #endregion

       #region ConsultarTodos

            public List<DominioSKD.Entidad> ConsultarTodos()
            {
                throw new NotImplementedException();
            }     

            #endregion


       #endregion

       #region Existe Restriccion

        /// <summary>
        /// Metodo que permite corroborar dado un objeto tipo RestriccionCompetencia
        /// si existe una restriccion de competencia con los mismos parametros en la
        /// base de datos
        /// </summary>
        /// <param name="parametro"> Objeto de tipo generico que sera interpretado
        /// como un objeto del tipo RestriccionCompetencia</param>
        /// <returns>Retorna True si encuentra una restriccion similar en la base
        /// de datos, o False si no existe tal restriccion de competencia.</returns>
        
        public Boolean ExisteRestriccionCompetenciaSimilar(DominioSKD.Entidad parametro)
        {
        
            DominioSKD.Entidades.Modulo8.RestriccionCompetencia laRestriccionCompetencia =
            (DominioSKD.Entidades.Modulo8.RestriccionCompetencia)parametro;
            
            Boolean retorno = false;
            
            List<Parametro> parametros;
            
            try
            {
                parametros = new List<Parametro>();

                Parametro elParametro;

                elParametro = new Parametro(DatosSKD.DAO.Modulo8.RecursosDAORestriccionCompetencia.ParamDescripcion, SqlDbType.VarChar,
                laRestriccionCompetencia.Descripcion, false);
                    
                parametros.Add(elParametro);

                elParametro = new Parametro(RecursosDAORestriccionCompetencia.ParamEdadMin, SqlDbType.Int,
                laRestriccionCompetencia.EdadMinima.ToString(), false);
                    
                parametros.Add(elParametro);

                elParametro = new Parametro(RecursosDAORestriccionCompetencia.ParamEdadMax, SqlDbType.Int,
                laRestriccionCompetencia.EdadMaxima.ToString(), false);
                    
                parametros.Add(elParametro);

                elParametro = new Parametro(RecursosDAORestriccionCompetencia.ParamRangoMin, SqlDbType.Int,
                laRestriccionCompetencia.RangoMinimo.ToString(), false);
                    
                parametros.Add(elParametro);

                elParametro = new Parametro(RecursosDAORestriccionCompetencia.ParamRangoMax, SqlDbType.Int,
                laRestriccionCompetencia.RangoMaximo.ToString(), false);
                    
                parametros.Add(elParametro);

                elParametro = new Parametro(RecursosDAORestriccionCompetencia.ParamSexo, SqlDbType.VarChar,
                laRestriccionCompetencia.Sexo, false);
                    
                parametros.Add(elParametro);

                elParametro = new Parametro(RecursosDAORestriccionCompetencia.ParamModalidad, SqlDbType.VarChar,
                laRestriccionCompetencia.Modalidad, false);
                    
                parametros.Add(elParametro);

                elParametro = new Parametro(RecursosDAORestriccionCompetencia.ParamSalidaNumRestriccion, SqlDbType.Int, true);
                    
                parametros.Add(elParametro);

                List<Resultado> resultados = EjecutarStoredProcedure(RecursosDAORestriccionCompetencia.ExisteRestriccionCompetencia
                , parametros);

                foreach (Resultado elResultado in resultados)
                {
                        
                    if (elResultado.etiqueta == RecursosDAORestriccionCompetencia.ParamSalidaNumRestriccion)
                        
                        if (int.Parse(elResultado.valor) != 0)
                            
                            retorno = true;
                            
                        else
                            
                            retorno = false;
                    
                 }

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

                
            return retorno;
            
        }
        
       #endregion

       #region traerIdRestriccionCompetencia
        /// <summary>
        /// Metodo que retorna el id de una restriccion de competencia
        /// dada una configuracion de parametros especifica.
        /// </summary>
        /// <param name="parametro">Tipo: RestriccionCompetencia,
        /// objeto con la informacion de una restriccion para competencias</param>
        /// <returns>Retorna null si no existe una restriccion con dicha configuracion
        /// retorna un entero correspondiente al id en caso de existir la restriccion</returns>
        public int traerIdRestriccionCompetencia(DominioSKD.Entidad parametro)
        {
            ///Logger.EscribirInfo(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, RecursosDAORestriccionCompetencia.MensajeInicioInfoLogger, System.Reflection.MethodBase.GetCurrentMethod().Name);

            DominioSKD.Entidades.Modulo8.RestriccionCompetencia laRestriccionCompetencia =
                (DominioSKD.Entidades.Modulo8.RestriccionCompetencia)parametro;

            List<int> listaIdCompetencias = new List<int>();
            
            int elId = -1;
            List<Parametro> parametros;

            try
            {
                
                parametros = new List<Parametro>();

                parametros = new List<Parametro>();
                Parametro elParametro = new Parametro(RecursosDAORestriccionCompetencia.ParamDescripcion, SqlDbType.VarChar,
                  laRestriccionCompetencia.Descripcion, false);
                parametros.Add(elParametro);

                elParametro = new Parametro(RecursosDAORestriccionCompetencia.ParamEdadMin, SqlDbType.Int,
                     laRestriccionCompetencia.EdadMinima.ToString(), false);
                parametros.Add(elParametro);

                elParametro = new Parametro(RecursosDAORestriccionCompetencia.ParamEdadMax, SqlDbType.Int,
                    laRestriccionCompetencia.EdadMaxima.ToString(), false);
                parametros.Add(elParametro);

                elParametro = new Parametro(RecursosDAORestriccionCompetencia.ParamRangoMin, SqlDbType.Int,
                     laRestriccionCompetencia.RangoMinimo.ToString(), false);
                parametros.Add(elParametro);

                elParametro = new Parametro(RecursosDAORestriccionCompetencia.ParamRangoMax, SqlDbType.Int,
                    laRestriccionCompetencia.RangoMaximo.ToString(), false);
                parametros.Add(elParametro);

                elParametro = new Parametro(RecursosDAORestriccionCompetencia.ParamSexo, SqlDbType.VarChar,
                    laRestriccionCompetencia.Sexo, false);
                parametros.Add(elParametro);

                elParametro = new Parametro(RecursosDAORestriccionCompetencia.ParamModalidad, SqlDbType.VarChar,
                    laRestriccionCompetencia.Modalidad, false);
                parametros.Add(elParametro);



                DataTable dt = EjecutarStoredProcedureTuplas(RecursosDAORestriccionCompetencia.RestornarIdRestriccionCompetencia
                                             , parametros);

                foreach (DataRow row in dt.Rows)
                {
                    elId = int.Parse(row[RecursosDAORestriccionCompetencia.AliasIdRestriccionCompetencia].ToString());
                    listaIdCompetencias.Add(elId);
                }
            }
            catch (SqlException ex)
            {
               // Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                throw new ExcepcionesSKD.ExceptionSKDConexionBD(RecursoGeneralBD.Codigo,
                    RecursoGeneralBD.Mensaje, ex);
            }
            catch (FormatException ex)
            {
               // Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                throw new ExcepcionesSKD.Modulo12.FormatoIncorrectoException(RecursosDAORestriccionCompetencia.Codigo_Error_Formato,
                     RecursosDAORestriccionCompetencia.Mensaje_Error_Formato, ex);
            }
            catch (ExcepcionesSKD.ExceptionSKDConexionBD ex)
            {
                //Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                throw ex;
            }
            catch (Exception ex)
            {
                //Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                throw new ExcepcionesSKD.ExceptionSKD(RecursoGeneralBD.Mensaje_Generico_Error, ex);
            }

            //Logger.EscribirInfo(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, RecursosDAORestriccionCompetencia.MensajeFinInfoLogger, System.Reflection.MethodBase.GetCurrentMethod().Name);

            return elId;
        }
        #endregion

       #region AgregarCompetenciaRestriccionCompetencia
        
        /// <summary>
        /// Metodo para crear relaciones entre Restricciones y Competencias.
        /// </summary>
        /// <param name="parametro1">Tipo: objeto RestriccionCompetencia</param>
        /// <param name="parametro2">Tipo: objeto Competencia</param>
        /// <returns>True si se crea la relacion exitosamente, False si ya existe o falla la creacion</returns>
        
        public Boolean AgregarCompetenciaRestriccionCompetencia(DominioSKD.Entidad parametro1, DominioSKD.Entidad parametro2)
        {
            
            DominioSKD.Entidades.Modulo8.RestriccionCompetencia laRestriccionCompetencia =
            (DominioSKD.Entidades.Modulo8.RestriccionCompetencia)parametro1;
           
            DominioSKD.Entidades.Modulo12.Competencia laCompetencia =
            (DominioSKD.Entidades.Modulo12.Competencia)parametro2;

            if (!ExisteCompetenciaRestriccionCompetencia(laRestriccionCompetencia, laCompetencia))
            {
               
                try
                {
                    
                    List<Parametro> parametros = new List<Parametro>();

                    Parametro elParametro;

                    elParametro = new Parametro(RecursosDAORestriccionCompetencia.ParamIdRestriccionCompetencia, SqlDbType.Int,
                    laRestriccionCompetencia.IdRestriccionComp.ToString(), false);

                    parametros.Add(elParametro);

                    elParametro = new Parametro(RecursosDAORestriccionCompetencia.ParamIdCompetencia, SqlDbType.Int,
                    laCompetencia.Id_competencia.ToString(), false);

                    parametros.Add(elParametro);

                    EjecutarStoredProcedure(RecursosDAORestriccionCompetencia.AgregarCompetenciaRestriccionCompetencia, parametros);

                }

                catch (SqlException ex)
                {

                    throw new ExcepcionesSKD.ExceptionSKDConexionBD(RecursoGeneralBD.Codigo, RecursoGeneralBD.Mensaje, ex);

                }

                catch (FormatException ex)
                {

                    throw new ExcepcionesSKD.Modulo8.FormatoIncorrectoException(RecursosDAORestriccionCompetencia.Codigo_Error_Formato,
                    RecursosDAORestriccionCompetencia.Mensaje_Error_Formato, ex);

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
            else
            {
               
                return false;
            
            }
            
            return true;
        
        } 
        
       #endregion

       #region ConsultarTodasLasCompetenciasNoAsociadas
        
        /// <summary>
        /// Metodo que dado un objeto RestriccionCompetencia, retorna una lista
        /// de objetos Competencia los cuales no estan relacionados con la RestriccionCompetencia provista
        /// </summary>
        /// <param name="parametro">Tipo: Objeto RestriccionCompetencia</param>
        /// <returns>Lista de objetos: Competencia</returns>
        
        public List<DominioSKD.Entidad> ConsultarTodasLasCompetenciasNoAsociadas(DominioSKD.Entidad parametro)
        {
            
            List<DominioSKD.Entidad> listaDeCompetencias = new List<DominioSKD.Entidad>();
            
            List<Parametro> parametros;

            DominioSKD.Entidades.Modulo8.RestriccionCompetencia laRestriccionCompetencia =
            (DominioSKD.Entidades.Modulo8.RestriccionCompetencia)parametro;
            
            try
            {
                
                parametros = new List<Parametro>();

                Parametro elParametro;

                elParametro = new Parametro(RecursosDAORestriccionCompetencia.ParamIdRestriccionCompetencia, SqlDbType.Int,
                laRestriccionCompetencia.IdRestriccionComp.ToString(), false);
                
                parametros.Add(elParametro);

                DataTable dt;

                dt = EjecutarStoredProcedureTuplas(RecursosDAORestriccionCompetencia.ConsultarTodasLasCompetenciasNoAsociadas, parametros);

                foreach (DataRow row in dt.Rows)
                {

                    Competencia laCompetencia;

                    laCompetencia = new Competencia();

                    laCompetencia.Id_competencia = int.Parse(row[RecursosDAORestriccionCompetencia.AliasIdCompetencia].ToString());
                    
                    laCompetencia.Nombre = row[RecursosDAORestriccionCompetencia.AliasNombreCompetencia].ToString();
                    
                    laCompetencia.TipoCompetencia = row[RecursosDAORestriccionCompetencia.AliasTipoCompetencia].ToString();

                    if (laCompetencia.TipoCompetencia == "1")
                    {
                       
                        laCompetencia.TipoCompetencia = RecursosDAORestriccionCompetencia.TipoCompetenciaKata;

                    }
                    else
                    { 

                        laCompetencia.TipoCompetencia = RecursosDAORestriccionCompetencia.TipoCompetenciaKumite;

                    }

                    laCompetencia.Status = row[RecursosDAORestriccionCompetencia.AliasStatusCompetencia].ToString();
                    
                    laCompetencia.OrganizacionTodas = Convert.ToBoolean(row[RecursosDAORestriccionCompetencia.AliasTodasOrganizaciones].ToString());

                    
                    if (laCompetencia.OrganizacionTodas == false)
                    {   
 
                        laCompetencia.Organizacion = new Organizacion(int.Parse(row[RecursosDAORestriccionCompetencia.AliasIdOrganizacion].ToString())
                        , row[RecursosDAORestriccionCompetencia.AliasNombreOrganizacion].ToString());
                    
                    }
                    else
                    { 

                        laCompetencia.Organizacion = new Organizacion(RecursosDAORestriccionCompetencia.TodasLasOrganizaciones);
                    
                    }
                    
                    laCompetencia.Ubicacion = new Ubicacion(int.Parse(row[RecursosDAORestriccionCompetencia.AliasIdUbicacion].ToString()),
                    row[RecursosDAORestriccionCompetencia.AliasNombreCiudad].ToString(), row[RecursosDAORestriccionCompetencia.AliasNombreEstado].ToString());

                    listaDeCompetencias.Add(laCompetencia);
                
                }

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

            return listaDeCompetencias;

        } 

        #endregion

       #region ConsultarTodasLasCompetenciasAsociadas
        
        /// <summary>
        /// Metodo que dado un objeto RestriccionCompetencia, retorna una lista
        /// de objetos Competencia los cuales estan relacionados con la RestriccionCompetencia provista
        /// </summary>
        /// <param name="parametro">Tipo: Objeto RestriccionCompetencia</param>
        /// <returns>Lista de objetos: Competencia</returns>
        
        public List<DominioSKD.Entidad> ConsultarTodasLasCompetenciasAsociadas(DominioSKD.Entidad parametro)
        {

            List<DominioSKD.Entidad> listaDeCompetencias;

            listaDeCompetencias = new List<DominioSKD.Entidad>();
            
            List<Parametro> parametros;
            
            DominioSKD.Entidades.Modulo8.RestriccionCompetencia laRestriccionCompetencia =
            (DominioSKD.Entidades.Modulo8.RestriccionCompetencia)parametro;

            try
            {
                
                parametros = new List<Parametro>();

                Parametro elParametro;
                
                elParametro = new Parametro(RecursosDAORestriccionCompetencia.ParamIdRestriccionCompetencia, SqlDbType.Int,
                laRestriccionCompetencia.IdRestriccionComp.ToString(), false);
                
                parametros.Add(elParametro);

                DataTable dt;
                
                dt = EjecutarStoredProcedureTuplas(RecursosDAORestriccionCompetencia.ConsultarCompetenciasAsociadasALaRestriccion, parametros);

                foreach (DataRow row in dt.Rows)
                {
                    
                    Competencia laCompetencia;
                    
                    laCompetencia = new Competencia();

                    laCompetencia.Id_competencia = int.Parse(row[RecursosDAORestriccionCompetencia.AliasIdCompetencia].ToString());
                    
                    laCompetencia.Nombre = row[RecursosDAORestriccionCompetencia.AliasNombreCompetencia].ToString();
                    
                    laCompetencia.TipoCompetencia = row[RecursosDAORestriccionCompetencia.AliasTipoCompetencia].ToString();

                    if (laCompetencia.TipoCompetencia == "1")
                    {
                     
                        laCompetencia.TipoCompetencia = RecursosDAORestriccionCompetencia.TipoCompetenciaKata;
                    
                    }
                    else
                    { 
                     
                        laCompetencia.TipoCompetencia = RecursosDAORestriccionCompetencia.TipoCompetenciaKumite;
                    
                    }

                    laCompetencia.Status = row[RecursosDAORestriccionCompetencia.AliasStatusCompetencia].ToString();
                    
                    laCompetencia.OrganizacionTodas = Convert.ToBoolean(row[RecursosDAORestriccionCompetencia.AliasTodasOrganizaciones].ToString());

                    if (laCompetencia.OrganizacionTodas == false)
                    {
                        
                        laCompetencia.Organizacion = new Organizacion(int.Parse(row[RecursosDAORestriccionCompetencia.AliasIdOrganizacion].ToString())
                        , row[RecursosDAORestriccionCompetencia.AliasNombreOrganizacion].ToString());
                    
                    }
                    else
                    {
                    
                        laCompetencia.Organizacion = new Organizacion(RecursosDAORestriccionCompetencia.TodasLasOrganizaciones);
                    
                    }
                    
                    laCompetencia.Ubicacion = new Ubicacion(int.Parse(row[RecursosDAORestriccionCompetencia.AliasIdUbicacion].ToString()),
                    row[RecursosDAORestriccionCompetencia.AliasNombreCiudad].ToString(), row[RecursosDAORestriccionCompetencia.AliasNombreEstado].ToString());

                    listaDeCompetencias.Add(laCompetencia);
                
                }

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

            return listaDeCompetencias;
        
        } 
        
       #endregion

       #region EliminarCompetenciaRestriccionCompetencia
       
        /// <summary>
        /// Metodo para eliminar relaciones entre Restricciones y Competencias.
        /// </summary>
        /// <param name="parametro1">Tipo: objeto RestriccionCompetencia</param>
        /// <param name="parametro2">Tipo: objeto Competencia</param>
        /// <returns>True si se elimina la relacion exitosamente, False si no existe o falla la eliminacion</returns>
        
        public Boolean EliminarCompetenciaRestriccionCompetencia(DominioSKD.Entidad parametro1, DominioSKD.Entidad parametro2)
        {

            DominioSKD.Entidades.Modulo8.RestriccionCompetencia laRestriccionCompetencia =
            (DominioSKD.Entidades.Modulo8.RestriccionCompetencia)parametro1;
            
            DominioSKD.Entidades.Modulo12.Competencia laCompetencia =
            (DominioSKD.Entidades.Modulo12.Competencia)parametro2;

            if (ExisteCompetenciaRestriccionCompetencia(laRestriccionCompetencia, laCompetencia))
            {

                try
                {

                    List<Parametro> parametros;

                    parametros = new List<Parametro>();

                    Parametro elParametro;

                    elParametro = new Parametro(RecursosDAORestriccionCompetencia.ParamIdRestriccionCompetencia, SqlDbType.Int,
                    laRestriccionCompetencia.IdRestriccionComp.ToString(), false);

                    parametros.Add(elParametro);

                    elParametro = new Parametro(RecursosDAORestriccionCompetencia.ParamIdCompetencia, SqlDbType.Int,
                    laCompetencia.Id_competencia.ToString(), false);

                    parametros.Add(elParametro);

                    EjecutarStoredProcedure(RecursosDAORestriccionCompetencia.EliminarCompetenciaRestriccionCompetencia, parametros);

                }

                catch (SqlException ex)
                {

                    throw new ExcepcionesSKD.ExceptionSKDConexionBD(RecursoGeneralBD.Codigo, RecursoGeneralBD.Mensaje, ex);

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
            else
            {

                return false;

            }
            
            return true;

        } 
        
       #endregion

       #region RetornarIdCompetenciaRestriccionCompetencia
        
        /// <summary>
        /// Metodo que retorna el id de una relacion entre RestriccionCompetencia y
        /// una competencia
        /// </summary>
        /// <param name="parametro1">objeto tipo: RestriccionCompetencia</param>
        /// <param name="parametro2">objeto tipo: Competencia</param>
        /// <returns>Entero correspondiente al id de la relacion</returns>
        
        public int RetornarIdCompetenciaRestriccionCompetencia(DominioSKD.Entidad parametro1, DominioSKD.Entidad parametro2)
        {
        
            DominioSKD.Entidades.Modulo8.RestriccionCompetencia laRestriccionCompetencia =
            (DominioSKD.Entidades.Modulo8.RestriccionCompetencia)parametro1;
            
            DominioSKD.Entidades.Modulo12.Competencia laCompetencia =
            (DominioSKD.Entidades.Modulo12.Competencia)parametro2;
            
            int elId = -1;
            
            List<int> listaIdCompetencias = new List<int>();
            
            try
            {

                List<Parametro> parametros;
                
                parametros = new List<Parametro>();

                Parametro elParametro;

                elParametro = new Parametro(RecursosDAORestriccionCompetencia.ParamIdRestriccionCompetencia, SqlDbType.Int,
                laRestriccionCompetencia.IdRestriccionComp.ToString(), false);
                
                parametros.Add(elParametro);

                elParametro = new Parametro(RecursosDAORestriccionCompetencia.ParamIdCompetencia, SqlDbType.Int,
                laCompetencia.Id_competencia.ToString(), false);
                
                parametros.Add(elParametro);

                DataTable dt;

                dt = EjecutarStoredProcedureTuplas(RecursosDAORestriccionCompetencia.RetornarIdCompetenciaRestriccionCompetencia, parametros);

                foreach (DataRow row in dt.Rows)
                {

                    elId = int.Parse(row[RecursosDAORestriccionCompetencia.ParamIdCompetenciaRestriccionCompetencia].ToString());
                    
                    listaIdCompetencias.Add(elId);

                }
            }
            catch (SqlException ex)
            {

                throw new ExcepcionesSKD.ExceptionSKDConexionBD(RecursoGeneralBD.Codigo,
                RecursoGeneralBD.Mensaje, ex);

            }
            catch (FormatException ex)
            {

                throw new ExcepcionesSKD.Modulo8.FormatoIncorrectoException(RecursosDAORestriccionCompetencia.Codigo_Error_Formato,
                RecursosDAORestriccionCompetencia.Mensaje_Error_Formato, ex);
            
            }
            catch (ExcepcionesSKD.ExceptionSKDConexionBD ex)
            {
             
                throw ex;
            
            }
            catch (Exception ex)
            {
            
                throw new ExcepcionesSKD.ExceptionSKD(RecursoGeneralBD.Mensaje_Generico_Error, ex);
            
            }
            
            return elId;

        } 

        #endregion

       #region ExisteCompetenciaRestriccionCompetencia
        /// <summary>
        /// Metodo que retorna si existe una relacion entre una RestriccionCompetencia y una Competencia dadas
        /// </summary>
        /// <param name="parametro1">objeto tipo: RestriccionCompetencia</param>
        /// <param name="parametro2">objeto tipo: Competencia</param>
        /// <returns>retorna true si existe false si no existe</returns>
        public Boolean ExisteCompetenciaRestriccionCompetencia(DominioSKD.Entidad parametro1, DominioSKD.Entidad parametro2)
        {

            DominioSKD.Entidades.Modulo8.RestriccionCompetencia laRestriccionCompetencia =
            (DominioSKD.Entidades.Modulo8.RestriccionCompetencia)parametro1;
            
            DominioSKD.Entidades.Modulo12.Competencia laCompetencia =
            (DominioSKD.Entidades.Modulo12.Competencia)parametro2;

            Boolean retorno = false;

            List<Parametro> parametros;

            try
            {
            
                parametros = new List<Parametro>();

                Parametro elParametro;

                elParametro = new Parametro(RecursosDAORestriccionCompetencia.ParamIdRestriccionCompetencia, SqlDbType.Int,
                laRestriccionCompetencia.IdRestriccionComp.ToString(), false);
                
                parametros.Add(elParametro);

                elParametro = new Parametro(RecursosDAORestriccionCompetencia.ParamIdCompetencia, SqlDbType.Int,
                laCompetencia.Id_competencia.ToString(), false);
                
                parametros.Add(elParametro);

                List<Resultado> resultados;
                
                resultados = EjecutarStoredProcedure(RecursosDAORestriccionCompetencia.ExisteRestriccionCompetencia
                , parametros);

                foreach (Resultado elResultado in resultados)
                {
                
                    if (elResultado.etiqueta == RecursosDAORestriccionCompetencia.ParamSalidaNumRestriccion)
                    { 

                        if (int.Parse(elResultado.valor) != 0)
                        
                            retorno = true;
                        
                        else
                        
                            retorno = false;
                    
                    }
                
                }

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

            return retorno;
        
        } 
        #endregion

       #region AgregarListaCompetenciaRestriccionCompetencia
        
        /// <summary>
        /// Metodo para crear las relaciones entre una lista de competencias y una restriccion de competencia
        /// </summary>
        /// <param name="parametro1">objeto tipo: RestriccionCompetencia</param>
        /// <param name="parametro2">lista de objetos tipo : Competencia</param>
        /// <returns></returns>
      
        public Boolean AgregarListaCompetenciaRestriccionCompetencia (DominioSKD.Entidad parametro1, List<DominioSKD.Entidad> parametro2)
       {
           
           DominioSKD.Entidad restriccion = parametro1;
           
           Boolean resultado = false;
           
           try
           {

               foreach (DominioSKD.Entidad competencia in parametro2)
               {

                   try
                   {

                       resultado = AgregarCompetenciaRestriccionCompetencia(restriccion, competencia);
                      
                       resultado = true;
                   
                   }
                   catch (Exception ex)
                   {
                       
                       throw ex;
                   
                   }
                   
               }

           }
           catch (Exception ex1)
           {

               throw ex1;
           
           }
           
            return resultado;
       
       }
       
       #endregion

       #region EliminarListaCompetenciaRestriccionCompetencia
       
       /// <summary>
       /// Metodo para eliminar las relaciones entre una lista de competencias y una restriccion de competencia
       /// </summary>
       /// <param name="parametro1">objeto tipo: RestriccionCompetencia</param>
       /// <param name="parametro2">lista de objetos tipo : Competencia</param>
       /// <returns></returns>
       
       public Boolean EliminarListaCompetenciaRestriccionCompetencia(DominioSKD.Entidad parametro1, List<DominioSKD.Entidad> parametro2)
       {

           DominioSKD.Entidad restriccion = parametro1;
           
           Boolean resultado = false;
           
           try
           {

               foreach (DominioSKD.Entidad competencia in parametro2)
               {

                   try
                   {
                    
                       resultado = EliminarCompetenciaRestriccionCompetencia(restriccion, competencia);
                       resultado = true;
                   
                   }
                   catch (Exception ex)
                   {

                       throw ex;
                   
                   }

               }

           }
           catch (Exception ex1)
           {

               throw ex1;
           
           }
           
           return resultado;
       
       }
             
       #endregion
    
    }

}
