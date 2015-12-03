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

namespace DatosSKD.Modulo4
{
    public class BDHistorial_Matricula
    {
        public static bool AgregarHistorialMatricula(Historial_Matricula elHistMat, Dojo elHDojo)
        {
            try
            {
                List<Parametro> parametros = new List<Parametro>();
                Parametro elParametro = new Parametro(RecursosBDModulo4.ParamIdDojo, SqlDbType.Int,
                    elHistMat.DojoId_historial_matricula.ToString(), false);
                parametros.Add(elParametro);

                elParametro = new Parametro(RecursosBDModulo4.ParametroFechaVigenteHistorial, SqlDbType.DateTime,
                    elHistMat.Fecha_historial_matricula.ToString(), false);
                parametros.Add(elParametro);

                elParametro = new Parametro(RecursosBDModulo4.ParametroModalidad, SqlDbType.VarChar,
                    elHistMat.Modalidad_historial_matricula.ToString(), false);
                parametros.Add(elParametro);

                elParametro = new Parametro(RecursosBDModulo4.ParametroMontoMatricula, SqlDbType.VarChar,
                    elHistMat.Monto_historial_matricula.ToString(), false);
                parametros.Add(elParametro);

                BDConexion laConexion = new BDConexion();
                laConexion.EjecutarStoredProcedure(RecursosBDModulo4.AgregarHistorialMatricula, parametros);


            }
            catch (SqlException ex)
            {
                throw new ExcepcionesSKD.ExceptionSKDConexionBD(RecursoGeneralBD.Codigo,
                    RecursoGeneralBD.Mensaje, ex);
            }
            catch (FormatException ex)
            {
                throw new ExcepcionesSKD.Modulo4.FormatoIncorrectoException(RecursosBDModulo4.Codigo_Error_Formato,
                        RecursosBDModulo4.Mensaje_Error_Formato, ex);
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
        
        
        public static List<Historial_Matricula> ListarMatriculas(int IdDojo)
        {
            BDConexion laConexion;
            List<Historial_Matricula> laListaDeMatriculas = new List<Historial_Matricula>();
            List<Parametro> parametros;
            Parametro elParametro = new Parametro();

            try
            {
                laConexion = new BDConexion();
                parametros = new List<Parametro>();
           
                    elParametro = new Parametro(RecursosBDModulo4.ParamIdDojo, SqlDbType.Int, IdDojo.ToString(),
                                                false);
                    parametros.Add(elParametro);

                DataTable dt = laConexion.EjecutarStoredProcedureTuplas(
                               RecursosBDModulo4.ConsultarMatriculasXDojo, parametros);
                foreach (DataRow row in dt.Rows)
                {

                    Historial_Matricula laMatricula = new Historial_Matricula();

                    laMatricula.Id_historial_matricula = int.Parse(row[RecursosBDModulo4.AliasIdMatricula].ToString());
                    laMatricula.Fecha_historial_matricula = DateTime.Parse(row[RecursosBDModulo4.AliasFechaMatricula].ToString());
                    laMatricula.Modalidad_historial_matricula = row[RecursosBDModulo4.AliasModalidad].ToString();
                    laMatricula.Monto_historial_matricula = int.Parse(row[RecursosBDModulo4.AliasMonto].ToString());
                    laMatricula.DojoId_historial_matricula = int.Parse(row[RecursosBDModulo4.AliasIdDojo].ToString());
                    laMatricula.DojoNombre_historial_matricula = row[RecursosBDModulo4.AliasNombreDojo].ToString();
                    
                   laListaDeMatriculas.Add(laMatricula);

                }

            }
            catch (SqlException ex)
            {
                throw new ExcepcionesSKD.ExceptionSKDConexionBD(RecursoGeneralBD.Codigo,
                    RecursoGeneralBD.Mensaje, ex);
            }
            catch (FormatException ex)
            {
                throw new ExcepcionesSKD.Modulo4.FormatoIncorrectoException(RecursosBDModulo4.Codigo_Error_Formato,
                     RecursosBDModulo4.Mensaje_Error_Formato, ex);
            }
            catch (ExcepcionesSKD.ExceptionSKDConexionBD ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw new ExcepcionesSKD.ExceptionSKD(RecursoGeneralBD.Mensaje_Generico_Error, ex);
            }

            return laListaDeMatriculas;
        }


        public static List<Historial_Matricula> ListarMatriculas()
        {
            BDConexion laConexion;
            List<Historial_Matricula> laListaDeMatriculas = new List<Historial_Matricula>();
            List<Parametro> parametros;

            try
            {
                laConexion = new BDConexion();
                parametros = new List<Parametro>();

                DataTable dt = laConexion.EjecutarStoredProcedureTuplas(
                               RecursosBDModulo4.ConsultarMatriculas,parametros);
                foreach (DataRow row in dt.Rows)
                {

                    Historial_Matricula laMatricula = new Historial_Matricula();

                    laMatricula.Id_historial_matricula = int.Parse(row[RecursosBDModulo4.AliasIdMatricula].ToString());
                    laMatricula.Fecha_historial_matricula = DateTime.Parse(row[RecursosBDModulo4.AliasFechaMatricula].ToString());
                    laMatricula.Modalidad_historial_matricula = row[RecursosBDModulo4.AliasModalidad].ToString();
                    laMatricula.Monto_historial_matricula = int.Parse(row[RecursosBDModulo4.AliasMonto].ToString());
                    laMatricula.DojoId_historial_matricula = int.Parse(row[RecursosBDModulo4.AliasIdDojo].ToString());
                    laMatricula.DojoNombre_historial_matricula = row[RecursosBDModulo4.AliasNombreDojo].ToString();

                    laListaDeMatriculas.Add(laMatricula);

                }

            }
            catch (Exception ex)
            {
                throw  ex;
            }

            return laListaDeMatriculas;
        }



        public static int obtenerDojoPersona(int idusuario)
        {
            BDConexion laConexion;
            int id=0;
            List<Parametro> parametros;
            Parametro elParametro = new Parametro();

            try
            {
                laConexion = new BDConexion();
                parametros = new List<Parametro>();
                elParametro = new Parametro(RecursosBDModulo4.ParamIdUsuario, SqlDbType.Int, idusuario.ToString(),
                                               false);
                parametros.Add(elParametro);

                DataTable dt = laConexion.EjecutarStoredProcedureTuplas(
                               RecursosBDModulo4.ConsultarIdPersona, parametros);

                foreach (DataRow row in dt.Rows)
                {
                    id = (int.Parse(row[RecursosBDModulo4.AliasIdDojo].ToString()));

                }

            }
            catch (SqlException ex)
            {
                throw new ExcepcionesSKD.ExceptionSKDConexionBD(RecursoGeneralBD.Codigo,
                    RecursoGeneralBD.Mensaje, ex);
            }
            catch (FormatException ex)
            {
                throw new ExcepcionesSKD.Modulo4.FormatoIncorrectoException(RecursosBDModulo4.Codigo_Error_Formato,
                     RecursosBDModulo4.Mensaje_Error_Formato, ex);
            }
            catch (ExcepcionesSKD.ExceptionSKDConexionBD ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw new ExcepcionesSKD.ExceptionSKD(RecursoGeneralBD.Mensaje_Generico_Error, ex);
            }

            return id;
        
        }

        public static void eliminarMatricula(int idmatricula)
        {
            BDConexion laConexion;
            List<Parametro> parametros;
            Parametro elParametro = new Parametro();

            try
            {

                laConexion = new BDConexion();
                parametros = new List<Parametro>();
                elParametro = new Parametro(RecursosBDModulo4.ParamIdMatricula, SqlDbType.Int, idmatricula.ToString(),
                                               false);
                parametros.Add(elParametro);

                  laConexion.EjecutarStoredProcedure(RecursosBDModulo4.EliminarHMatricula, parametros);


            }
            catch (SqlException ex)
            {
                throw new ExcepcionesSKD.ExceptionSKDConexionBD(RecursoGeneralBD.Codigo,
                    RecursoGeneralBD.Mensaje, ex);
            }
            catch (FormatException ex)
            {
                throw new ExcepcionesSKD.Modulo4.FormatoIncorrectoException(RecursosBDModulo4.Codigo_Error_Formato,
                     RecursosBDModulo4.Mensaje_Error_Formato, ex);
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
    }
}
