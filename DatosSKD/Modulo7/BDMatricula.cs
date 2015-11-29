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
    public class BDMatricula
    {

        /// <summary>
        /// Método que consulta en la BD para detallar una matricula
        /// </summary>
        /// <param name="idEvento">Número entero que representa el ID de la matricula</param>
        /// <returns>Objeto de tipo Matricula</returns>
        public static Matricula DetallarMatricula(int idMatricula)
        {

            BDConexion laConexion;
            List<Parametro> parametros;
            Parametro elParametro = new Parametro();

            try
            {
                laConexion = new BDConexion();
                parametros = new List<Parametro>();
                Matricula matricula = new Matricula();

                elParametro = new Parametro(RecursosBDModulo7.ParamIdMatricula, SqlDbType.Int, idMatricula.ToString(), false);
                parametros.Add(elParametro);

                DataTable dt = laConexion.EjecutarStoredProcedureTuplas(
                               RecursosBDModulo7.ConsultarMatriculaXId, parametros);

                foreach (DataRow row in dt.Rows)
                {

                    matricula.Id_matricula = int.Parse(row[RecursosBDModulo7.AliasIdMatricula].ToString());
                    matricula.FechaInicio = row[RecursosBDModulo7.AliasFechaPagoMatricula].ToString();
                    matricula.FechaUltimoPago = row[RecursosBDModulo7.AliasFechaUltimoPagoMatricula].ToString();
                   

                }

                return matricula;

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

        /// <summary>
        /// Método para listar las matriculas pagadas de los atletas
        /// </summary>
        /// <returns>Lista de matriculas</returns>
        public static List<Matricula> ListarMatriculasPagas()
        {
            int idPersona = 1;
            BDConexion laConexion;
            List<Parametro> parametros;
            Parametro elParametro = new Parametro();
            List<Matricula> laListaDeMatriculaPaga = new List<Matricula>();

            try
            {
                laConexion = new BDConexion();
                parametros = new List<Parametro>();

                elParametro = new Parametro(RecursosBDModulo7.ParamIdPersona, SqlDbType.Int, idPersona.ToString(), false);
                parametros.Add(elParametro);

                DataTable dt = laConexion.EjecutarStoredProcedureTuplas(
                               RecursosBDModulo7.ConsultarMatriculasPagas, parametros);

                foreach (DataRow row in dt.Rows)
                {
                    Matricula matricula = new Matricula();
                    matricula.Id_matricula = int.Parse(row[RecursosBDModulo7.AliasIdMatricula].ToString());
                    matricula.FechaInicio = row[RecursosBDModulo7.AliasFechaPagoMatricula].ToString();
                    matricula.FechaUltimoPago = row[RecursosBDModulo7.AliasFechaUltimoPagoMatricula].ToString();
                    laListaDeMatriculaPaga.Add(matricula);
                }

                return laListaDeMatriculaPaga;

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

        
         }
}

     