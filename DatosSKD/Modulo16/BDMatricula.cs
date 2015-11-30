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
using ExcepcionesSKD.Modulo16.ExcepcionesDeDatos;


namespace DatosSKD.Modulo16
{
    public class BDMatricula
    {


        public static List<DominioSKD.Matricula> mostrarMensualidadesmorosas(int IdPersona)
        {
            BDConexion laConexion;
            List<Matricula> laListaDeMatriculas = new List<Matricula>();
            List<Parametro> parametros;

            try
            {
                laConexion = new BDConexion();
                parametros = new List<Parametro>();
                Parametro parametro = new Parametro(RecursosBDModulo16.PARAMETRO_ID_USUARIO, SqlDbType.Int, IdPersona.ToString(), false);
                parametros.Add(parametro);

                DataTable dt = laConexion.EjecutarStoredProcedureTuplas(
                               RecursosBDModulo16.StoreProcedureConsultarMatriculas, parametros);

                foreach (DataRow row in dt.Rows)
                {
                    Matricula laMatricula = new Matricula();


                    laMatricula.Identificador = (row[RecursosBDModulo16.aliasIdentificadorMatricula].ToString());
                    laMatricula.FechaCreacion = DateTime.Parse(row[RecursosBDModulo16.aliasFechainicio].ToString());
                    laMatricula.UltimaFechaPago = DateTime.Parse(row[RecursosBDModulo16.aliasFechatope].ToString());
                    laListaDeMatriculas.Add(laMatricula);

                }
                return laListaDeMatriculas;
            }

            catch (NullReferenceException ex)
            {

                throw new BDMatriculaException(RecursosBDModulo16.Codigo_ExcepcionNullReference,
                    RecursosBDModulo16.Mensaje_ExcepcionNullReference, ex);

            }

            catch (SqlException ex)
            {
                throw new BDMatriculaException(RecursosBDModulo16.Codigo_ExcepcionSql,
                    RecursosBDModulo16.Mensaje_ExcepcionSql, ex);

            }
            catch (ParametroIncorrectoException ex)
            {
                throw new ParametroIncorrectoException(RecursosBDModulo16.Codigo_ExcepcionParametro,
                    RecursosBDModulo16.Mensaje__ExcepcionParametro, ex);
            }
            catch (AtributoIncorrectoException ex)
            {
                throw new AtributoIncorrectoException(RecursosBDModulo16.Codigo_ExcepcionAtributo,
                    RecursosBDModulo16.Mensaje_ExcepcionAtributo, ex);
            }
            catch (Exception ex)
            {
                throw new BDMatriculaException(RecursosBDModulo16.Codigo_ExcepcionGeneral,
                   RecursosBDModulo16.Mensaje_ExcepcionGeneral, ex);

            }


        }




    }
}
