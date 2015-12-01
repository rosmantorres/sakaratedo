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
using ExcepcionesSKD.Modulo7;



namespace DatosSKD.Modulo7
{
    public class BDCompetencia
    {
        #region Atributos
        BDUbicacion baseDeDatosUbicacion = new BDUbicacion();
        #endregion

        #region Métodos
        /// <summary>
        /// Método que consulta en la BD para detallar una Competencia
        /// </summary>
        /// <param name="idCompentecia">Número entero que representa el ID de la competencia</param>
        /// <returns>Objeto de tipo Competencia</returns>
        public Competencia DetallarCompetencia(int idCompetencia)
        {
            Logger.EscribirInfo(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name,
                RecursosBDModulo7.MensajeInicioInfoLogger, System.Reflection.MethodBase.GetCurrentMethod().Name);

            BDConexion laConexion;
            List<Parametro> parametros;
            Parametro elParametro = new Parametro();
            Competencia competencia;
            try
            {
                if (idCompetencia.GetType() == Type.GetType("System.Int32") && idCompetencia > 0)
                {
                  laConexion = new BDConexion();
                  parametros = new List<Parametro>();
                  competencia = new Competencia();

                  elParametro = new Parametro(RecursosBDModulo7.ParamIdCompetencia, SqlDbType.Int, idCompetencia.ToString(), false);
                  parametros.Add(elParametro);

                   DataTable dt = laConexion.EjecutarStoredProcedureTuplas(RecursosBDModulo7.ConsultarCompetenciaXId, parametros);

                foreach (DataRow row in dt.Rows)
                {

                    competencia.Id_competencia = int.Parse(row[RecursosBDModulo7.AliasIdCompetencia].ToString());
                    competencia.Nombre = row[RecursosBDModulo7.AliasCompetenciaNombre].ToString();
                    //competencia.Status = row[RecursosBDModulo7.AliasCompetenciaStatus].ToString();
                    competencia.TipoCompetencia = row[RecursosBDModulo7.AliasCompetenciaTipo].ToString();
                    competencia.FechaInicio = DateTime.Parse(row[RecursosBDModulo7.AliasCompetenciaFechaInicio].ToString());
                    competencia.FechaFin = DateTime.Parse(row[RecursosBDModulo7.AliasCompetenciaFechaFin].ToString());
                    competencia.Costo = float.Parse(row[RecursosBDModulo7.AliasCompetenciaCosto].ToString());
                    competencia.Ubicacion = baseDeDatosUbicacion.DetallarUbicacion(int.Parse(row[RecursosBDModulo7.AliasCompetenciaUbicacionId].ToString()));

                }

                }
                else
                {

                    throw new NumeroEnteroInvalidoException(RecursosBDModulo7.Codigo_Numero_Parametro_Invalido,
                                RecursosBDModulo7.Mensaje_Numero_Parametro_invalido, new Exception());
                }
                


            }
            catch (SqlException ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                throw new ExceptionSKDConexionBD(RecursoGeneralBD.Codigo,
                    RecursoGeneralBD.Mensaje, ex);
            }
            catch (NumeroEnteroInvalidoException ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                throw new NumeroEnteroInvalidoException(RecursosBDModulo7.Codigo_Numero_Parametro_Invalido,
                                RecursosBDModulo7.Mensaje_Numero_Parametro_invalido, new Exception());

            }
            catch (FormatException ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                throw new NumeroEnteroInvalidoException(RecursosBDModulo7.Codigo_Numero_Parametro_Invalido,
                                RecursosBDModulo7.Mensaje_Numero_Parametro_invalido, new Exception());
            }
            catch (ExceptionSKDConexionBD ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                throw ex;
            }
            catch (Exception ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                throw new ExceptionSKD("No se pudo completar la operacion", ex);
            }

            Logger.EscribirInfo(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name,
                RecursosBDModulo7.MensajeFinInfoLogger, System.Reflection.MethodBase.GetCurrentMethod().Name);

            return competencia;
        }


        }
        #endregion

    }

