using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Configuration;
using DominioSKD;
using ExcepcionesSKD;
using System.Globalization;
using DatosSKD.Modulo12;

namespace DatosSKD.Modulo8
{
    public class BDRestriccionCompetencia
    {
        #region ListarRestriccionesCompetencia
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static List<RestriccionCompetencia> ListarRestriccionesCompetencia()
        {
            BDConexion laConexion;
            List<RestriccionCompetencia> listaDeRestriccionesCompetencia = new List<RestriccionCompetencia>();
            List<Parametro> parametros;

            try
            {
                laConexion = new BDConexion();
                parametros = new List<Parametro>();


                DataTable dt = laConexion.EjecutarStoredProcedureTuplas(
                               RecursosBDRestriccionCompetencia.ConsultarTodasRestriccionCompetencia, parametros);

                foreach (DataRow row in dt.Rows)
                {
                    RestriccionCompetencia restriccionDeCompetencia = new RestriccionCompetencia();

                    restriccionDeCompetencia.IdRestriccionComp = int.Parse(row[RecursosBDRestriccionCompetencia.AliasIdRestriccionCompetencia].ToString());
                    restriccionDeCompetencia.Descripcion = row[RecursosBDRestriccionCompetencia.AliasDescripcion].ToString();
                    restriccionDeCompetencia.EdadMinima = int.Parse(row[RecursosBDRestriccionCompetencia.AliasEdadMin].ToString());
                    restriccionDeCompetencia.EdadMaxima = int.Parse(row[RecursosBDRestriccionCompetencia.AliasEdadMax].ToString());
                    restriccionDeCompetencia.Sexo = row[RecursosBDRestriccionCompetencia.AliasSexo].ToString();
                    restriccionDeCompetencia.Modalidad = row[RecursosBDRestriccionCompetencia.AliasModalidad].ToString();

                    listaDeRestriccionesCompetencia.Add(restriccionDeCompetencia);

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

            return listaDeRestriccionesCompetencia;
        } 
        #endregion

        #region ExisteRestriccionCompetenciaSimilar
        public static bool ExisteRestriccionCompetenciaSimilar(RestriccionCompetencia laRestriccionCompetencia)
        {
            bool retorno = false;
            BDConexion laConexion;
            List<Parametro> parametros;

            try
            {
                laConexion = new BDConexion();
                parametros = new List<Parametro>();

                Parametro elParametro = new Parametro(RecursosBDRestriccionCompetencia.ParamDescripcion, SqlDbType.VarChar,
                       laRestriccionCompetencia.Descripcion, false);
                parametros.Add(elParametro);

                elParametro = new Parametro(RecursosBDRestriccionCompetencia.ParamEdadMin, SqlDbType.Int,
                     laRestriccionCompetencia.EdadMinima.ToString(), false);
                parametros.Add(elParametro);

                elParametro = new Parametro(RecursosBDRestriccionCompetencia.ParamEdadMax, SqlDbType.Int,
                    laRestriccionCompetencia.EdadMaxima.ToString(), false);
                parametros.Add(elParametro);

                elParametro = new Parametro(RecursosBDRestriccionCompetencia.ParamRangoMin, SqlDbType.Int,
                     laRestriccionCompetencia.RangoMinimo.ToString(), false);
                parametros.Add(elParametro);

                elParametro = new Parametro(RecursosBDRestriccionCompetencia.ParamRangoMax, SqlDbType.Int,
                    laRestriccionCompetencia.RangoMaximo.ToString(), false);
                parametros.Add(elParametro);

                elParametro = new Parametro(RecursosBDRestriccionCompetencia.ParamSexo, SqlDbType.VarChar,
                    laRestriccionCompetencia.Sexo, false);
                parametros.Add(elParametro);

                elParametro = new Parametro(RecursosBDRestriccionCompetencia.ParamModalidad, SqlDbType.VarChar,
                    laRestriccionCompetencia.Modalidad, false);
                parametros.Add(elParametro);


                elParametro = new Parametro(RecursosBDRestriccionCompetencia.ParamSalidaNumRestriccion, SqlDbType.Int, true);
                parametros.Add(elParametro);

                List<Resultado> resultados = laConexion.EjecutarStoredProcedure(RecursosBDRestriccionCompetencia.ExisteRestriccionCompetencia
                                             , parametros);

                foreach (Resultado elResultado in resultados)
                {
                    if (elResultado.etiqueta == RecursosBDRestriccionCompetencia.ParamSalidaNumRestriccion)
                        if (int.Parse(elResultado.valor) != 0 )
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

        #region Agregar Restriccion
        public static bool AgregarRestriccionCompetencia(RestriccionCompetencia laRestriccionCompetencia)
        {
            try
            {
                if (!ExisteRestriccionCompetenciaSimilar(laRestriccionCompetencia))
                {
                    List<Parametro> parametros = new List<Parametro>();
                    Parametro elParametro = new Parametro(RecursosBDRestriccionCompetencia.ParamDescripcion, SqlDbType.VarChar,
                      laRestriccionCompetencia.Descripcion, false);
                    parametros.Add(elParametro);

                    elParametro = new Parametro(RecursosBDRestriccionCompetencia.ParamEdadMin, SqlDbType.Int,
                         laRestriccionCompetencia.EdadMinima.ToString(), false);
                    parametros.Add(elParametro);

                    elParametro = new Parametro(RecursosBDRestriccionCompetencia.ParamEdadMax, SqlDbType.Int,
                        laRestriccionCompetencia.EdadMaxima.ToString(), false);
                    parametros.Add(elParametro);

                    elParametro = new Parametro(RecursosBDRestriccionCompetencia.ParamRangoMin, SqlDbType.Int,
                         laRestriccionCompetencia.RangoMinimo.ToString(), false);
                    parametros.Add(elParametro);

                    elParametro = new Parametro(RecursosBDRestriccionCompetencia.ParamRangoMax, SqlDbType.Int,
                        laRestriccionCompetencia.RangoMaximo.ToString(), false);
                    parametros.Add(elParametro);

                    elParametro = new Parametro(RecursosBDRestriccionCompetencia.ParamSexo, SqlDbType.VarChar,
                        laRestriccionCompetencia.Sexo, false);
                    parametros.Add(elParametro);

                    elParametro = new Parametro(RecursosBDRestriccionCompetencia.ParamModalidad, SqlDbType.VarChar,
                        laRestriccionCompetencia.Modalidad, false);
                    parametros.Add(elParametro);



                    BDConexion laConexion = new BDConexion();
                    laConexion.EjecutarStoredProcedure(RecursosBDRestriccionCompetencia.AgregarRestriccionCompetencia, parametros);

                }
                else
                    throw new ExcepcionesSKD.Modulo8.RestriccionExistenteException(RecursosBDRestriccionCompetencia.Codigo_Restriccion_Competencia_Existente,
                                RecursosBDRestriccionCompetencia.Mensaje_Restriccion_Competencia_Existente, new Exception());
            }
            catch (SqlException ex)
            {
                throw new ExcepcionesSKD.ExceptionSKDConexionBD(RecursoGeneralBD.Codigo,
                    RecursoGeneralBD.Mensaje, ex);
            }
            catch (FormatException ex)
            {
                throw new ExcepcionesSKD.Modulo8.FormatoIncorrectoException(RecursosBDRestriccionCompetencia.Codigo_Error_Formato,
                     RecursosBDRestriccionCompetencia.Mensaje_Error_Formato, ex);
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

        #region modificar Restriccion

        public static bool ModificarCompetencia(RestriccionCompetencia laRestriccionCompetencia)
        {
            Logger.EscribirInfo(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, RecursosBDRestriccionCompetencia.MensajeInicioInfoLogger, System.Reflection.MethodBase.GetCurrentMethod().Name);

            try
            {
                if (!ExisteRestriccionCompetenciaSimilar(laRestriccionCompetencia))
                {
                    List<Parametro> parametros = new List<Parametro>();
                    Parametro elParametro = new Parametro(RecursosBDRestriccionCompetencia.ParamIdRestriccionCompetencia, SqlDbType.Int,
                        laRestriccionCompetencia.IdRestriccionComp.ToString(), false);
                    parametros.Add(elParametro);
                    elParametro = new Parametro(RecursosBDRestriccionCompetencia.ParamDescripcion, SqlDbType.VarChar,
                        laRestriccionCompetencia.Descripcion, false);
                    parametros.Add(elParametro);
                    elParametro = new Parametro(RecursosBDRestriccionCompetencia.ParamEdadMin, SqlDbType.Int,
                         laRestriccionCompetencia.EdadMinima.ToString(), false);
                    parametros.Add(elParametro);

                    elParametro = new Parametro(RecursosBDRestriccionCompetencia.ParamEdadMax, SqlDbType.Int,
                        laRestriccionCompetencia.EdadMaxima.ToString(), false);
                    parametros.Add(elParametro);

                    elParametro = new Parametro(RecursosBDRestriccionCompetencia.ParamRangoMin, SqlDbType.Int,
                         laRestriccionCompetencia.RangoMinimo.ToString(), false);
                    parametros.Add(elParametro);

                    elParametro = new Parametro(RecursosBDRestriccionCompetencia.ParamRangoMax, SqlDbType.Int,
                        laRestriccionCompetencia.RangoMaximo.ToString(), false);
                    parametros.Add(elParametro);

                    elParametro = new Parametro(RecursosBDRestriccionCompetencia.ParamSexo, SqlDbType.VarChar,
                        laRestriccionCompetencia.Sexo, false);
                    parametros.Add(elParametro);

                    elParametro = new Parametro(RecursosBDRestriccionCompetencia.ParamModalidad, SqlDbType.VarChar,
                        laRestriccionCompetencia.Modalidad, false);
                    parametros.Add(elParametro);

                    BDConexion laConexion = new BDConexion();
                    laConexion.EjecutarStoredProcedure(RecursosBDRestriccionCompetencia.ModificarRestriccionCompetencia, parametros);
                }
                else
                {
                    Logger.EscribirWarning(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, RecursosBDRestriccionCompetencia.Mensaje_Restriccion_Competencia_Existente, System.Reflection.MethodBase.GetCurrentMethod().Name);

                    throw new ExcepcionesSKD.Modulo8.RestriccionExistenteException(RecursosBDRestriccionCompetencia.Codigo_Restriccion_Competencia_Existente,
                                 RecursosBDRestriccionCompetencia.Mensaje_Restriccion_Competencia_Existente, new Exception());
                }
            }
            catch (SqlException ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);

                throw new ExcepcionesSKD.ExceptionSKDConexionBD(RecursoGeneralBD.Codigo,
                    RecursoGeneralBD.Mensaje, ex);
            }
            catch (FormatException ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);

                throw new ExcepcionesSKD.Modulo8.FormatoIncorrectoException(RecursosBDRestriccionCompetencia.Codigo_Error_Formato,
                     RecursosBDRestriccionCompetencia.Mensaje_Error_Formato, ex);
            }
            catch (ExcepcionesSKD.ExceptionSKDConexionBD ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);

                throw ex;
            }
            catch (Exception ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);

                throw new ExcepcionesSKD.ExceptionSKD(RecursoGeneralBD.Mensaje_Generico_Error, ex);
            }

            Logger.EscribirInfo(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, RecursosBDRestriccionCompetencia.MensajeFinInfoLogger, System.Reflection.MethodBase.GetCurrentMethod().Name);

            return true;
        }

        #endregion

        #region EliminarRestriccion
        public static bool EliminarRestriccionCompetencia(RestriccionCompetencia laRestriccionCompetencia)
        {
            try
            {
                if (ExisteRestriccionCompetenciaSimilar(laRestriccionCompetencia))
                {
                List<Parametro> parametros = new List<Parametro>(); //declaras lista de parametros

                Parametro elParametro = new Parametro(RecursosBDRestriccionCompetencia.ParamDescripcion, SqlDbType.VarChar,
                      laRestriccionCompetencia.Descripcion, false);
                parametros.Add(elParametro);

                elParametro = new Parametro(RecursosBDRestriccionCompetencia.ParamEdadMin, SqlDbType.Int,
                     laRestriccionCompetencia.EdadMinima.ToString(), false);
                parametros.Add(elParametro);

                elParametro = new Parametro(RecursosBDRestriccionCompetencia.ParamEdadMax, SqlDbType.Int,
                    laRestriccionCompetencia.EdadMaxima.ToString(), false);
                parametros.Add(elParametro);

                elParametro = new Parametro(RecursosBDRestriccionCompetencia.ParamRangoMin, SqlDbType.Int,
                     laRestriccionCompetencia.RangoMinimo.ToString(), false);
                parametros.Add(elParametro);

                elParametro = new Parametro(RecursosBDRestriccionCompetencia.ParamRangoMax, SqlDbType.Int,
                    laRestriccionCompetencia.RangoMaximo.ToString(), false);
                parametros.Add(elParametro);

                elParametro = new Parametro(RecursosBDRestriccionCompetencia.ParamSexo, SqlDbType.VarChar,
                    laRestriccionCompetencia.Sexo, false);
                parametros.Add(elParametro);

                elParametro = new Parametro(RecursosBDRestriccionCompetencia.ParamModalidad, SqlDbType.VarChar,
                    laRestriccionCompetencia.Modalidad, false);
                parametros.Add(elParametro);

                BDConexion laConexion = new BDConexion();// abres la conexion
                laConexion.EjecutarStoredProcedure(RecursosBDRestriccionCompetencia.EliminarRestriccionCompetencia
                                             , parametros);

              }
                else
                    throw new ExcepcionesSKD.Modulo8.RestriccionExistenteException(RecursosBDRestriccionCompetencia.Codigo_Restriccion_Competencia_No_Existente,
                                RecursosBDRestriccionCompetencia.Mensaje_Restriccion_Competencia_No_Existente, new Exception());
            }
            catch (SqlException ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                throw new ExcepcionesSKD.ExceptionSKDConexionBD(RecursoGeneralBD.Codigo,
                    RecursoGeneralBD.Mensaje, ex);
            }
            catch (ExcepcionesSKD.ExceptionSKDConexionBD ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                throw ex;
            }
            catch (Exception ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                throw new ExcepcionesSKD.ExceptionSKD(RecursoGeneralBD.Mensaje_Generico_Error, ex);
            }


            return true;
        }
        #endregion

        #region AtletasQueCumplenRestriccion
        public static List<int> atletasQueCumplenRestriccion(RestriccionCompetencia laRestriccionCompetencia)
        {
            Logger.EscribirInfo(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, RecursosBDRestriccionCompetencia.MensajeInicioInfoLogger, System.Reflection.MethodBase.GetCurrentMethod().Name);

            List<int> listaIdAtletas = new List<int>();
            BDConexion laConexion;
            List<Parametro> parametros;

            try
            {
                laConexion = new BDConexion();
                parametros = new List<Parametro>();

                Parametro elParametro = new Parametro(RecursosBDRestriccionCompetencia.ParamIdRestriccionCompetencia, SqlDbType.Int
                                                      , laRestriccionCompetencia.IdRestriccionComp.ToString(), false);
                parametros.Add(elParametro);



                DataTable dt = laConexion.EjecutarStoredProcedureTuplas(RecursosBDRestriccionCompetencia.AtletasCumplenRestriccion
                                             , parametros);

                foreach (DataRow row in dt.Rows)
                {
                    int elId = new int();

                    elId = int.Parse(row[RecursosBDRestriccionCompetencia.AliasIdAtleta].ToString());


                    listaIdAtletas.Add(elId);

                }
            }
            catch (SqlException ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                throw new ExcepcionesSKD.ExceptionSKDConexionBD(RecursoGeneralBD.Codigo,
                    RecursoGeneralBD.Mensaje, ex);
            }
            catch (FormatException ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                throw new ExcepcionesSKD.Modulo12.FormatoIncorrectoException(RecursosBDRestriccionCompetencia.Codigo_Error_Formato,
                     RecursosBDRestriccionCompetencia.Mensaje_Error_Formato, ex);
            }
            catch (ExcepcionesSKD.ExceptionSKDConexionBD ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                throw ex;
            }
            catch (Exception ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                throw new ExcepcionesSKD.ExceptionSKD(RecursoGeneralBD.Mensaje_Generico_Error, ex);
            }

            Logger.EscribirInfo(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, RecursosBDRestriccionCompetencia.MensajeFinInfoLogger, System.Reflection.MethodBase.GetCurrentMethod().Name);

            return listaIdAtletas;

        }
        #endregion

        #region competenciasQuePuedeIrUnAtleta
        public static List<int> competenciasQuePuedeIrUnAtleta(Persona laPersona)
        {
            Logger.EscribirInfo(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, RecursosBDRestriccionCompetencia.MensajeInicioInfoLogger, System.Reflection.MethodBase.GetCurrentMethod().Name);

            List<int> listaIdCompetencias = new List<int>();
            BDConexion laConexion;
            List<Parametro> parametros;

            try
            {
                laConexion = new BDConexion();
                parametros = new List<Parametro>();

                Parametro elParametro = new Parametro(RecursosBDRestriccionCompetencia.ParamIdPersona, SqlDbType.Int
                                                      , laPersona.ID.ToString(), false);
                parametros.Add(elParametro);



                DataTable dt = laConexion.EjecutarStoredProcedureTuplas(RecursosBDRestriccionCompetencia.EventosQuePuedeAsistirUnAtleta
                                             , parametros);

                foreach (DataRow row in dt.Rows)
                {
                    int elId = new int();

                    elId = int.Parse(row[RecursosBDRestriccionCompetencia.AliasIdCompetencia].ToString());


                    listaIdCompetencias.Add(elId);

                }
            }
            catch (SqlException ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                throw new ExcepcionesSKD.ExceptionSKDConexionBD(RecursoGeneralBD.Codigo,
                    RecursoGeneralBD.Mensaje, ex);
            }
            catch (FormatException ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                throw new ExcepcionesSKD.Modulo12.FormatoIncorrectoException(RecursosBDRestriccionCompetencia.Codigo_Error_Formato,
                     RecursosBDRestriccionCompetencia.Mensaje_Error_Formato, ex);
            }
            catch (ExcepcionesSKD.ExceptionSKDConexionBD ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                throw ex;
            }
            catch (Exception ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                throw new ExcepcionesSKD.ExceptionSKD(RecursoGeneralBD.Mensaje_Generico_Error, ex);
            }

            Logger.EscribirInfo(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, RecursosBDRestriccionCompetencia.MensajeFinInfoLogger, System.Reflection.MethodBase.GetCurrentMethod().Name);

            return listaIdCompetencias;

        }
        #endregion

        #region traerListaDeCompetenciasAsociadasALaRestriccion
        public static List<Competencia> ListarCompetenciasAsociadasALaRestriccion(RestriccionCompetencia laRestriccionCompetencia)
        {
            BDConexion laConexion;
            List<Competencia> listaDeCompetencias = new List<Competencia>();
            List<Parametro> parametros;
                   

            try
            {
                laConexion = new BDConexion();
                parametros = new List<Parametro>();
                
                Parametro elParametro = new Parametro(RecursosBDRestriccionCompetencia.ParamIdRestriccionCompetencia, SqlDbType.Int,
                                                      laRestriccionCompetencia.IdRestriccionComp.ToString(), false);
                parametros.Add(elParametro);

                DataTable dt = laConexion.EjecutarStoredProcedureTuplas(
                               RecursosBDRestriccionCompetencia.ConsultarCompetenciasAsociadasALaRestriccion, parametros);

                foreach (DataRow row in dt.Rows)
                {
                    Competencia laCompetencia = new Competencia();

                     laCompetencia.Id_competencia = int.Parse(row[RecursosBDRestriccionCompetencia.AliasIdCompetencia].ToString());
                    laCompetencia.Nombre = row[RecursosBDRestriccionCompetencia.AliasNombreCompetencia].ToString();
                    laCompetencia.TipoCompetencia = row[RecursosBDRestriccionCompetencia.AliasTipoCompetencia].ToString();

                    if (laCompetencia.TipoCompetencia == "1")
                        laCompetencia.TipoCompetencia = RecursosBDRestriccionCompetencia.TipoCompetenciaKata;
                    else
                        laCompetencia.TipoCompetencia = RecursosBDRestriccionCompetencia.TipoCompetenciaKumite;

                    laCompetencia.Status = row[RecursosBDRestriccionCompetencia.AliasStatusCompetencia].ToString();
                    laCompetencia.OrganizacionTodas = Convert.ToBoolean(row[RecursosBDRestriccionCompetencia.AliasTodasOrganizaciones].ToString());

                    if (laCompetencia.OrganizacionTodas == false)
                        laCompetencia.Organizacion = new Organizacion(int.Parse(row[RecursosBDRestriccionCompetencia.AliasIdOrganizacion].ToString())
                                                                        , row[RecursosBDRestriccionCompetencia.AliasNombreOrganizacion].ToString());
                    else
                    {
                        laCompetencia.Organizacion = new Organizacion(RecursosBDRestriccionCompetencia.TodasLasOrganizaciones);
                    }
                    laCompetencia.Ubicacion = new Ubicacion(int.Parse(row[RecursosBDRestriccionCompetencia.AliasIdUbicacion].ToString()),
                                                            row[RecursosBDRestriccionCompetencia.AliasNombreCiudad].ToString(),
                                                            row[RecursosBDRestriccionCompetencia.AliasNombreEstado].ToString());

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
      
        #region traerListaDeCompetenciasNoAsociadasALaRestriccion
        public static List<Competencia> ListarCompetenciasNoAsociadasALaRestriccion(RestriccionCompetencia laRestriccionCompetencia)
        {
            BDConexion laConexion;
            List<Competencia> listaDeCompetencias = new List<Competencia>();
            List<Parametro> parametros;


            try
            {
                laConexion = new BDConexion();
                parametros = new List<Parametro>();

                Parametro elParametro = new Parametro(RecursosBDRestriccionCompetencia.ParamIdRestriccionCompetencia, SqlDbType.Int,
                                                      laRestriccionCompetencia.IdRestriccionComp.ToString(), false);
                parametros.Add(elParametro);

                DataTable dt = laConexion.EjecutarStoredProcedureTuplas(
                               RecursosBDRestriccionCompetencia.ConsultarTodasLasCompetenciasNoAsociadas, parametros);

                foreach (DataRow row in dt.Rows)
                {
                    Competencia laCompetencia = new Competencia();

                    laCompetencia.Id_competencia = int.Parse(row[RecursosBDRestriccionCompetencia.AliasIdCompetencia].ToString());
                    laCompetencia.Nombre = row[RecursosBDRestriccionCompetencia.AliasNombreCompetencia].ToString();
                    laCompetencia.TipoCompetencia = row[RecursosBDRestriccionCompetencia.AliasTipoCompetencia].ToString();

                    if (laCompetencia.TipoCompetencia == "1")
                        laCompetencia.TipoCompetencia = RecursosBDRestriccionCompetencia.TipoCompetenciaKata;
                    else
                        laCompetencia.TipoCompetencia = RecursosBDRestriccionCompetencia.TipoCompetenciaKumite;

                    laCompetencia.Status = row[RecursosBDRestriccionCompetencia.AliasStatusCompetencia].ToString();
                    laCompetencia.OrganizacionTodas = Convert.ToBoolean(row[RecursosBDRestriccionCompetencia.AliasTodasOrganizaciones].ToString());

                    if (laCompetencia.OrganizacionTodas == false)
                        laCompetencia.Organizacion = new Organizacion(int.Parse(row[RecursosBDRestriccionCompetencia.AliasIdOrganizacion].ToString())
                                                                        , row[RecursosBDRestriccionCompetencia.AliasNombreOrganizacion].ToString());
                    else
                    {
                        laCompetencia.Organizacion = new Organizacion(RecursosBDRestriccionCompetencia.TodasLasOrganizaciones);
                    }
                    laCompetencia.Ubicacion = new Ubicacion(int.Parse(row[RecursosBDRestriccionCompetencia.AliasIdUbicacion].ToString()),
                                                            row[RecursosBDRestriccionCompetencia.AliasNombreCiudad].ToString(),
                                                            row[RecursosBDRestriccionCompetencia.AliasNombreEstado].ToString());

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

        #region traerIdCompetenciaPorNombre PENDIENTE
        //public static Competencia TraerCompetencia(int idCompetencia)
        //{
        //    Logger.EscribirInfo(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, RecursosBDModulo12.MensajeInicioInfoLogger, System.Reflection.MethodBase.GetCurrentMethod().Name);
        //    BDConexion laConexion;
        //    List<Parametro> parametros;
        //    Parametro elParametro = new Parametro();
        //    Competencia laCompetencia = new Competencia();
        //    laCompetencia.Id_competencia = idCompetencia;
        //    string diaFecha;
        //    string mesFecha;
        //    string anoFecha;
        //    string fechaInicio;
        //    string fechaFin;

        //    try
        //    {
        //        if (DatosSKD.Modulo12.BDCompetencia.BuscarIDCompetencia(laCompetencia))
        //        {
        //            laConexion = new BDConexion();
        //            parametros = new List<Parametro>();


        //            elParametro = new Parametro(RecursosBDModulo12.ParamIdCompetencia, SqlDbType.Int, idCompetencia.ToString(),
        //                                        false);
        //            parametros.Add(elParametro);

        //            DataTable dt = laConexion.EjecutarStoredProcedureTuplas(
        //                           RecursosBDModulo12.ConsultarCompetenciasXId, parametros);

        //            foreach (DataRow row in dt.Rows)
        //            {


        //                laCompetencia.Id_competencia = int.Parse(row[RecursosBDModulo12.AliasIdCompetencia].ToString());
        //                laCompetencia.Nombre = row[RecursosBDModulo12.AliasNombreCompetencia].ToString();
        //                laCompetencia.TipoCompetencia = row[RecursosBDModulo12.AliasTipoCompetencia].ToString();

        //                if (laCompetencia.TipoCompetencia == RecursosBDModulo12.TipoCompetencia1)
        //                    laCompetencia.TipoCompetencia = RecursosBDModulo12.TipoCompetenciaKata;
        //                if (laCompetencia.TipoCompetencia == RecursosBDModulo12.TipoCompetencia2)
        //                    laCompetencia.TipoCompetencia = RecursosBDModulo12.TipoCompetenciaKumite;
        //                if (laCompetencia.TipoCompetencia == RecursosBDModulo12.TipoCompetencia3)
        //                    laCompetencia.TipoCompetencia = RecursosBDModulo12.TipoCompetenciaAmbos;

        //                laCompetencia.Status = row[RecursosBDModulo12.AliasStatusCompetencia].ToString();
        //                laCompetencia.OrganizacionTodas = Convert.ToBoolean(row[RecursosBDModulo12.AliasTodasOrganizaciones].ToString());

        //                diaFecha = Convert.ToDateTime(row[RecursosBDModulo12.AliasFechaInicio]).Day.ToString();

        //                diaFecha = ModificarFechas(diaFecha);
        //                // if (int.Parse(diaFecha) < 10)
        //                //   diaFecha = "0" + diaFecha.ToString();

        //                mesFecha = Convert.ToDateTime(row[RecursosBDModulo12.AliasFechaInicio]).Month.ToString();

        //                mesFecha = ModificarFechas(mesFecha);
        //                //if (int.Parse(mesFecha) < 10)
        //                //  mesFecha = "0" + mesFecha.ToString();

        //                anoFecha = Convert.ToDateTime(row[RecursosBDModulo12.AliasFechaInicio]).Year.ToString();
        //                fechaInicio = mesFecha + RecursosBDModulo12.SeparadorFecha + diaFecha + RecursosBDModulo12.SeparadorFecha + anoFecha;
        //                //laCompetencia.FechaInicio = Convert.ToDateTime(fechaInicio);

        //                laCompetencia.FechaInicio = DateTime.ParseExact(fechaInicio, RecursosBDModulo12.FormatoFecha,
        //                    CultureInfo.InvariantCulture);

        //                diaFecha = Convert.ToDateTime(row[RecursosBDModulo12.AliasFechaFin]).Day.ToString();

        //                diaFecha = ModificarFechas(diaFecha);
        //                //if (int.Parse(diaFecha) < 10)
        //                //  diaFecha = "0" + diaFecha.ToString();

        //                mesFecha = Convert.ToDateTime(row[RecursosBDModulo12.AliasFechaFin]).Month.ToString();

        //                mesFecha = ModificarFechas(mesFecha);
        //                //if (int.Parse(mesFecha) < 10)
        //                //  mesFecha = "0" + mesFecha.ToString();

        //                anoFecha = Convert.ToDateTime(row[RecursosBDModulo12.AliasFechaFin]).Year.ToString();
        //                fechaFin = mesFecha + RecursosBDModulo12.SeparadorFecha + diaFecha + RecursosBDModulo12.SeparadorFecha + anoFecha;
        //                //laCompetencia.FechaFin = Convert.ToDateTime(fechaFin);

        //                laCompetencia.FechaFin = DateTime.ParseExact(fechaFin, RecursosBDModulo12.FormatoFecha,
        //                    CultureInfo.InvariantCulture);

        //                laCompetencia.Costo = float.Parse(row[RecursosBDModulo12.AliasCostoCompetencia].ToString());

        //                if (laCompetencia.OrganizacionTodas == false)
        //                    laCompetencia.Organizacion = new Organizacion(int.Parse(row[RecursosBDModulo12.AliasIdOrganizacion].ToString())
        //                                                                    , row[RecursosBDModulo12.AliasNombreOrganizacion].ToString());
        //                else
        //                {
        //                    laCompetencia.Organizacion = new Organizacion(RecursosBDModulo12.TodasLasOrganizaciones);
        //                }
        //                laCompetencia.Ubicacion = new Ubicacion(int.Parse(row[RecursosBDModulo12.AliasIdUbicacion].ToString()),
        //                                                        row[RecursosBDModulo12.AliasLatitudDireccion].ToString(),
        //                                                        row[RecursosBDModulo12.AliasLongitudDireccion].ToString(),
        //                                                        row[RecursosBDModulo12.AliasNombreCiudad].ToString(),
        //                                                        row[RecursosBDModulo12.AliasNombreEstado].ToString(),
        //                                                        row[RecursosBDModulo12.AliasNombreDireccion].ToString());

        //                laCompetencia.Categoria = new Categoria(int.Parse(row[RecursosBDModulo12.AliasIdCategoria].ToString()),
        //                                                         int.Parse(row[RecursosBDModulo12.AliasEdadInicio].ToString()),
        //                                                         int.Parse(row[RecursosBDModulo12.AliasEdadFin].ToString()),
        //                                                         row[RecursosBDModulo12.AliasCintaInicio].ToString(),
        //                                                         row[RecursosBDModulo12.AliasCintaFin].ToString(),
        //                                                         row[RecursosBDModulo12.AliasSexo].ToString());


        //            }

        //            Logger.EscribirInfo(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, RecursosBDModulo12.MensajeFinInfoLogger, System.Reflection.MethodBase.GetCurrentMethod().Name);

        //            return laCompetencia;
        //        }
        //        else
        //        {

        //            Logger.EscribirWarning(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, RecursosBDModulo12.Mensaje_Competencia_Inexistente, System.Reflection.MethodBase.GetCurrentMethod().Name);

        //            throw new ExcepcionesSKD.Modulo12.CompetenciaInexistenteException(RecursosBDModulo12.Codigo_Competencia_Inexistente,
        //                        RecursosBDModulo12.Mensaje_Competencia_Inexistente, new Exception());
        //        }
        //    }
        //    catch (SqlException ex)
        //    {
        //        Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
        //        throw new ExcepcionesSKD.ExceptionSKDConexionBD(RecursoGeneralBD.Codigo,
        //            RecursoGeneralBD.Mensaje, ex);
        //    }
        //    catch (FormatException ex)
        //    {
        //        Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
        //        throw new ExcepcionesSKD.Modulo12.FormatoIncorrectoException(RecursosBDModulo12.Codigo_Error_Formato,
        //             RecursosBDModulo12.Mensaje_Error_Formato, ex);
        //    }
        //    catch (ExcepcionesSKD.Modulo12.CompetenciaInexistenteException ex)
        //    {
        //        Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
        //        throw ex;
        //    }
        //    catch (ExcepcionesSKD.ExceptionSKDConexionBD ex)
        //    {
        //        Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
        //        throw ex;
        //    }
        //    catch (Exception ex)
        //    {
        //        Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
        //        throw new ExcepcionesSKD.ExceptionSKD(RecursoGeneralBD.Mensaje_Generico_Error, ex);
        //    }


        //}
        #endregion

        #region EliminarCompetenciaRestriccionCompetencia
        public static bool EliminarCompetenciaRestriccionCompetencia(RestriccionCompetencia laRestriccionCompetencia, Competencia laCompetencia)
        {
            try
            {

                List<Parametro> parametros = new List<Parametro>();
                Parametro elParametro = new Parametro(RecursosBDRestriccionCompetencia.ParamIdRestriccionCompetencia, SqlDbType.Int,
                  laRestriccionCompetencia.IdRestriccionComp.ToString(), false);
                parametros.Add(elParametro);

                elParametro = new Parametro(RecursosBDRestriccionCompetencia.ParamIdCompetencia, SqlDbType.Int,
                     laCompetencia.Id_competencia.ToString(), false);
                parametros.Add(elParametro);





                BDConexion laConexion = new BDConexion();
                laConexion.EjecutarStoredProcedure(RecursosBDRestriccionCompetencia.EliminarCompetenciaRestriccionCompetencia, parametros);

            }

            catch (SqlException ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                throw new ExcepcionesSKD.ExceptionSKDConexionBD(RecursoGeneralBD.Codigo,
                    RecursoGeneralBD.Mensaje, ex);
            }
            catch (ExcepcionesSKD.ExceptionSKDConexionBD ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                throw ex;
            }
            catch (Exception ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                throw new ExcepcionesSKD.ExceptionSKD(RecursoGeneralBD.Mensaje_Generico_Error, ex);
            }


            return true;
        }
        #endregion

        #region AgregarCompetenciaRestriccionCompetencia
        public static bool AgregarCompetenciaRestriccionCompetencia(RestriccionCompetencia laRestriccionCompetencia, Competencia laCompetencia)
        {
            try
            {
                
                    List<Parametro> parametros = new List<Parametro>();
                    Parametro elParametro = new Parametro(RecursosBDRestriccionCompetencia.ParamIdRestriccionCompetencia, SqlDbType.Int,
                      laRestriccionCompetencia.IdRestriccionComp.ToString(), false);
                    parametros.Add(elParametro);

                    elParametro = new Parametro(RecursosBDRestriccionCompetencia.ParamIdCompetencia, SqlDbType.Int,
                         laCompetencia.Id_competencia.ToString(), false);
                    parametros.Add(elParametro);

                    



                    BDConexion laConexion = new BDConexion();
                    laConexion.EjecutarStoredProcedure(RecursosBDRestriccionCompetencia.AgregarCompetenciaRestriccionCompetencia, parametros);

              
            }
            catch (SqlException ex)
            {
                throw new ExcepcionesSKD.ExceptionSKDConexionBD(RecursoGeneralBD.Codigo,
                    RecursoGeneralBD.Mensaje, ex);
            }
            catch (FormatException ex)
            {
                throw new ExcepcionesSKD.Modulo8.FormatoIncorrectoException(RecursosBDRestriccionCompetencia.Codigo_Error_Formato,
                     RecursosBDRestriccionCompetencia.Mensaje_Error_Formato, ex);
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

        #region traerRestriccionCompetencia
        public static RestriccionCompetencia TraerRestriccionCompetencia(int idRestriccionCompetencia)
        {
            Logger.EscribirInfo(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, RecursosBDModulo12.MensajeInicioInfoLogger, System.Reflection.MethodBase.GetCurrentMethod().Name);
            BDConexion laConexion;
            List<Parametro> parametros;
            Parametro elParametro = new Parametro();
            RestriccionCompetencia laRestriccionCompetencia = new RestriccionCompetencia();
            laRestriccionCompetencia.IdRestriccionComp = idRestriccionCompetencia;
            string diaFecha;
            string mesFecha;
            string anoFecha;
            string fechaInicio;
            string fechaFin;

            try
            {
                if (ExisteRestriccionCompetenciaSimilar(laRestriccionCompetencia))
                {
                    laConexion = new BDConexion();
                    parametros = new List<Parametro>();


                    elParametro = new Parametro(RecursosBDRestriccionCompetencia.ParamIdRestriccionCompetencia, SqlDbType.Int, idRestriccionCompetencia.ToString(),
                                                false);
                    parametros.Add(elParametro);

                    DataTable dt = laConexion.EjecutarStoredProcedureTuplas(
                                   RecursosBDRestriccionCompetencia.ConsultarRestriccionCompetenciasXId, parametros);

                    foreach (DataRow row in dt.Rows)
                    {


                        laRestriccionCompetencia.IdRestriccionComp = int.Parse(row[RecursosBDRestriccionCompetencia.AliasIdRestriccionCompetencia].ToString());
                        laRestriccionCompetencia.Descripcion = row[RecursosBDRestriccionCompetencia.AliasDescripcion].ToString();
                        laRestriccionCompetencia.EdadMinima = int.Parse(row[RecursosBDRestriccionCompetencia.AliasEdadMin].ToString());
                        laRestriccionCompetencia.EdadMaxima = int.Parse(row[RecursosBDRestriccionCompetencia.AliasEdadMax].ToString());
                        laRestriccionCompetencia.RangoMinimo = int.Parse(row[RecursosBDRestriccionCompetencia.AliasRangoMin].ToString());
                        laRestriccionCompetencia.RangoMaximo = int.Parse(row[RecursosBDRestriccionCompetencia.AliasRangoMax].ToString());
                        laRestriccionCompetencia.Sexo = row[RecursosBDRestriccionCompetencia.AliasSexo].ToString();
                        laRestriccionCompetencia.Modalidad = row[RecursosBDRestriccionCompetencia.AliasModalidad].ToString();

                    }

                    Logger.EscribirInfo(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, RecursosBDRestriccionCompetencia.MensajeFinInfoLogger, System.Reflection.MethodBase.GetCurrentMethod().Name);

                    return laRestriccionCompetencia;
                }
                else
                {

                    Logger.EscribirWarning(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, RecursosBDModulo12.Mensaje_Competencia_Inexistente, System.Reflection.MethodBase.GetCurrentMethod().Name);

                    throw new ExcepcionesSKD.Modulo12.CompetenciaInexistenteException(RecursosBDModulo12.Codigo_Competencia_Inexistente,
                                RecursosBDModulo12.Mensaje_Competencia_Inexistente, new Exception());
                }
            }
            catch (SqlException ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                throw new ExcepcionesSKD.ExceptionSKDConexionBD(RecursoGeneralBD.Codigo,
                    RecursoGeneralBD.Mensaje, ex);
            }
            catch (FormatException ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                throw new ExcepcionesSKD.Modulo12.FormatoIncorrectoException(RecursosBDModulo12.Codigo_Error_Formato,
                     RecursosBDModulo12.Mensaje_Error_Formato, ex);
            }
            catch (ExcepcionesSKD.Modulo12.CompetenciaInexistenteException ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                throw ex;
            }
            catch (ExcepcionesSKD.ExceptionSKDConexionBD ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                throw ex;
            }
            catch (Exception ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                throw new ExcepcionesSKD.ExceptionSKD(RecursoGeneralBD.Mensaje_Generico_Error, ex);
            }


        }
        #endregion


        public static String ModificarFechas(string fecha)
        {
            if (int.Parse(fecha) < 10)
                fecha = RecursosBDModulo12.Concatenar0 + fecha.ToString();

            return fecha;
        }
    }
}
