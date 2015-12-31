using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
namespace DatosSKD.DAO.Modulo8
{
    public class DAORestriccionCompetencia : DAOGeneral, InterfazDAO.Modulo8.IDaoRestriccionCompetencia
    {
        #region Metodos IDao
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
                        List<Parametro> parametros = new List<Parametro>();
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

                        EjecutarStoredProcedure(RecursosDAORestriccionCompetencia.AgregarRestriccionCompetencia
                                                 , parametros);

                    }
                    else
                        throw new ExcepcionesSKD.Modulo8.RestriccionExistenteException(RecursosDAORestriccionCompetencia.Codigo_Restriccion_Competencia_Existente,
                                    RecursosDAORestriccionCompetencia.Mensaje_Restriccion_Competencia_Existente, new Exception());
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

                    Parametro elParametro = new Parametro(DatosSKD.DAO.Modulo8.RecursosDAORestriccionCompetencia.ParamDescripcion, SqlDbType.VarChar,
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


    }
}
