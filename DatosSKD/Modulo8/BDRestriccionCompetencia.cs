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
                         laRestriccionCompetencia.EdadMinima.ToString(), false);
                    parametros.Add(elParametro);

                    elParametro = new Parametro(RecursosBDRestriccionCompetencia.ParamRangoMax, SqlDbType.Int,
                        laRestriccionCompetencia.EdadMaxima.ToString(), false);
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

    }
}
