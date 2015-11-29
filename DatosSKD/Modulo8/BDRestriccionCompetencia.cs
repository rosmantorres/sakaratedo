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
    }
}
