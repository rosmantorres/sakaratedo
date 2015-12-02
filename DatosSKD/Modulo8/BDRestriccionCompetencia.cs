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

namespace DatosSKD.Modulo8
{
    class BDRestriccionCompetencia
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

        #region existeRestriccionCompetenciaSimilar
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
                        if (int.Parse(elResultado.valor) == 1)
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
        public static bool EliminarRestriccionEvento(RestriccionCompetencia laRestriccion)
        {
            try
            {
                List<Parametro> parametros = new List<Parametro>(); //declaras lista de parametros

                Parametro elParametro = new Parametro(RecursosBDRestriccionEvento.ParamIdRestriccionEvento, SqlDbType.Int,
                    laRestriccion.IdRestriccionComp.ToString(), false);
                //parametro recibe: el alias de la accion (en este caso es la descripcion de mi restriccion de cinta que apunta a un atributo que se llama @DescripcionRestriccionCinta), SqlDbType es el tipo de dato que tiene ese atributo en la base de datos (en este caso es varchar), el elemento que se desea poner en ese lugar (aqui se usa la clase dominio), el false lo dejas asi
                parametros.Add(elParametro);
                //agregas eso que acabas de hacer a la lista de parametros.
                //repites hasta que tengas todos los parametros de tu stored procedure asociado

                BDConexion laConexion = new BDConexion();// abres la conexion
                laConexion.EjecutarStoredProcedure(RecursosBDRestriccionCompetencia.EliminarRestriccionCompetencia
                                             , parametros);

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

        #region atletasQueCumplenRestriccion
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
        
        #endregion

        #region traerListaDeCompetenciasNoAsociadasALaRestriccion

        #endregion

        #region traerIdCompetencia

        #endregion

        #region eliminarCompetenciaDeRestriccionCompetencia
            
        #endregion

        #region ExisteAsociacionCompetenciaRetriccionCompetencia
        #endregion

    }
}
