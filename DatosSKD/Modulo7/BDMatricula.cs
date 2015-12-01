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
    public class BDMatricula
    {

        /// <summary>
        /// Método que consulta en la BD para detallar una matricula
        /// </summary>
        /// <param name="idEvento">Número entero que representa el ID de la matricula</param>
        /// <returns>Objeto de tipo Matricula</returns>
        
        public Matricula DetallarMatricula(int idMatricula)
        {
            Logger.EscribirInfo(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name,
            RecursosBDModulo7.MensajeInicioInfoLogger, System.Reflection.MethodBase.GetCurrentMethod().Name);
           
            BDConexion laConexion;
            List<Parametro> parametros;
            Parametro elParametro = new Parametro();
            Matricula matricula;

            try
            {
                if (idMatricula.GetType() == Type.GetType("System.Int32") && idMatricula > 0)
                {
                    laConexion = new BDConexion();
                    parametros = new List<Parametro>();
                    matricula = new Matricula();

                    elParametro = new Parametro(RecursosBDModulo7.ParamIdMatricula, SqlDbType.Int, idMatricula.ToString(), false);
                    parametros.Add(elParametro);

                    DataTable dt = laConexion.EjecutarStoredProcedureTuplas(RecursosBDModulo7.ConsultarMatriculaXId, parametros);

                  foreach (DataRow row in dt.Rows)
                  {

                      //matricula.estado= row[RecursosBDModulo7.AliasEventoNombre].ToString();
                      matricula.FechaCreacion = DateTime.Parse(row[RecursosBDModulo7.AliasFechaPagoMatricula].ToString());
                      matricula.UltimaFechaPago = DateTime.Parse(row[RecursosBDModulo7.AliasFechaUltimoPagoMatricula].ToString());
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
            return matricula;
        }

        /// <summary>
        /// Método que devuelve el monto pago de una matricula
        /// </summary>
        /// <returns>Pago de matricula</returns>
        public float  montoPagoMatricula(int idPersona, int idMatricula)
        {
            Logger.EscribirInfo(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name,
            RecursosBDModulo7.MensajeInicioInfoLogger, System.Reflection.MethodBase.GetCurrentMethod().Name);

            BDConexion laConexion;
            List<Parametro> parametros;
            Parametro elParametroPersona = new Parametro();
            Parametro elParametroMatricula = new Parametro();
            float monto = new float();

            try
            {
                if ((idPersona.GetType() == Type.GetType("System.Int32") && idPersona > 0) && (idMatricula.GetType() == Type.GetType("System.Int32") && idMatricula > 0))
                {

                    laConexion = new BDConexion();
                    parametros = new List<Parametro>();

                    elParametroPersona = new Parametro(RecursosBDModulo7.ParamIdPersona, SqlDbType.Int, idPersona.ToString(), false);
                    elParametroMatricula = new Parametro(RecursosBDModulo7.ParamIdMatricula, SqlDbType.Int, idMatricula.ToString(), false);
                    parametros.Add(elParametroPersona);
                    parametros.Add(elParametroMatricula);

                    DataTable dt = laConexion.EjecutarStoredProcedureTuplas(RecursosBDModulo7.ConsultarMontoMatricula, parametros);

                    foreach (DataRow row in dt.Rows)
                    {
                        monto = float.Parse(row[RecursosBDModulo7.AliasMontoMatricula].ToString());
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

            return monto;
        }

        /// <summary>
        /// Método para listar las matriculas pagadas de los atletas
        /// </summary>
        /// <returns>Lista de matriculas</returns>
        public List<Matricula> ListarMatriculasPagas(int idPersona)
        {

            Logger.EscribirInfo(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name,
            RecursosBDModulo7.MensajeInicioInfoLogger, System.Reflection.MethodBase.GetCurrentMethod().Name);


            BDConexion laConexion;
            List<Parametro> parametros;
            Parametro elParametro = new Parametro();
            List<Matricula> laListaDeMatriculaPaga = new List<Matricula>();

            try
            {

                if (idPersona.GetType() == Type.GetType("System.Int32") && idPersona > 0)
                {
                    laConexion = new BDConexion();
                    parametros = new List<Parametro>();
                    elParametro = new Parametro(RecursosBDModulo7.ParamIdUsuarioLogueado, SqlDbType.Int, idPersona.ToString(), false);
                    parametros.Add(elParametro);
                    
                    DataTable dt = laConexion.EjecutarStoredProcedureTuplas(RecursosBDModulo7.ConsultarMatriculasPagas, parametros);

                 foreach (DataRow row in dt.Rows)
                 {
                      Matricula matricula = new Matricula();
                      matricula.Identificador = row[RecursosBDModulo7.AliasIdentificadorMatricula].ToString();
                      //matricula.Estado = Boolean.Parse(row[RecursosBDModulo7.AliasEstadoMatricula].ToString());
                      matricula.FechaCreacion = DateTime.Parse(row[RecursosBDModulo7.AliasFechaPagoMatricula].ToString());
                      matricula.UltimaFechaPago = DateTime.Parse(row[RecursosBDModulo7.AliasFechaUltimoPagoMatricula].ToString());
                      //matricula.Monto= float.Parse(row[RecursosBDModulo7.AliasMontoMatricula].ToString());
                      laListaDeMatriculaPaga.Add(matricula);
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

            return laListaDeMatriculaPaga;
        }
          }
}
