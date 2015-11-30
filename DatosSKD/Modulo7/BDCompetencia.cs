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
            BDConexion laConexion;
            List<Parametro> parametros;
            Parametro elParametro = new Parametro();

            try
            {
                laConexion = new BDConexion();
                parametros = new List<Parametro>();
                Competencia competencia = new Competencia();

                elParametro = new Parametro(RecursosBDModulo7.ParamIdCompetencia, SqlDbType.Int, idCompetencia.ToString(), false);
                parametros.Add(elParametro);

                DataTable dt = laConexion.EjecutarStoredProcedureTuplas(
                               RecursosBDModulo7.ConsultarCompetenciaXId, parametros);

                foreach (DataRow row in dt.Rows)
                {

                    competencia.Id_competencia = int.Parse(row[RecursosBDModulo7.AliasIdCompetencia].ToString());
                    competencia.Nombre = row[RecursosBDModulo7.AliasCompetenciaNombre].ToString();
                    competencia.Status = row[RecursosBDModulo7.AliasCompetenciaStatus].ToString();
                    competencia.TipoCompetencia = row[RecursosBDModulo7.AliasCompetenciaTipo].ToString();
                    competencia.FechaInicio = DateTime.Parse(row[RecursosBDModulo7.AliasCompetenciaFechaInicio].ToString());
                    competencia.FechaFin = DateTime.Parse(row[RecursosBDModulo7.AliasCompetenciaFechaFin].ToString());
                    competencia.Costo = float.Parse(row[RecursosBDModulo7.AliasCompetenciaCosto].ToString());
                    competencia.Ubicacion = baseDeDatosUbicacion.DetallarUbicacion(int.Parse(row[RecursosBDModulo7.AliasCompetenciaUbicacionId].ToString()));

                }

                return competencia;

            }
            catch (SqlException ex)
            {
                throw new ExcepcionesSKD.ExceptionSKDConexionBD(RecursoGeneralBD.Codigo,
                    RecursoGeneralBD.Mensaje, ex);
            }/*
            catch (ExcepcionesSKD.Modulo12.CompetenciaInexistenteException ex)
            {
                throw ex;
            }*/
            catch (ExcepcionesSKD.ExceptionSKDConexionBD ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw new ExcepcionesSKD.ExceptionSKD("No se pudo completar la operacion", ex);
            }


        }
        #endregion

    }
}
