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
    /// <summary>
    /// Clase para el manejo de los objetos tipo Cinta con la Base de Datos
    /// </summary>
    public class BDCinta
    {
        /// <summary>
        /// Método para listar las cintas obtenidas del atleta
        /// </summary>
        /// <returns>Lista de cintas</returns>
        public List<Cinta> ListarCintasObtenidas(int idPersona)
        {
            Logger.EscribirInfo(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name,
                RecursosBDModulo7.MensajeInicioInfoLogger, System.Reflection.MethodBase.GetCurrentMethod().Name);

            BDConexion laConexion;
            List<Parametro> parametros;
            Parametro elParametro = new Parametro();
            List<Cinta> laListaDeCintas = new List<Cinta>();

            try
            {
                if (idPersona.GetType() == Type.GetType("System.Int32") && idPersona > 0)
                {
                    laConexion = new BDConexion();
                    parametros = new List<Parametro>();
                    elParametro = new Parametro(RecursosBDModulo7.ParamIdPersona, SqlDbType.Int, idPersona.ToString(), false);
                    parametros.Add(elParametro);

                    DataTable dt = laConexion.EjecutarStoredProcedureTuplas(
                                   RecursosBDModulo7.ConsultarCintas, parametros);

                    foreach (DataRow row in dt.Rows)
                    {
                        Cinta cinta = new Cinta();
                        cinta.Id_cinta = int.Parse(row[RecursosBDModulo7.AliasIdCinta].ToString());
                        cinta.Color_nombre = row[RecursosBDModulo7.AliasCintaNombre].ToString();
                        cinta.Rango = row[RecursosBDModulo7.AliasCintaRango].ToString();
                        cinta.Clasificacion = row[RecursosBDModulo7.AliasCintaClasificacion].ToString();
                        cinta.Significado = row[RecursosBDModulo7.AliasCintaSignificado].ToString();
                        cinta.Orden = int.Parse(row[RecursosBDModulo7.AliasCintaOrden].ToString());
                        laListaDeCintas.Add(cinta);
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

            return laListaDeCintas;
        }

        /// <summary>
        /// Método para detallar una cinta
        /// </summary>
        /// <param name="idCinta">Número entero que representa el ID de la cinta</param>
        /// <returns>Objeto de tipo Cinta</returns>
        public Cinta DetallarCinta(int idCinta)
        {
            Logger.EscribirInfo(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name,
                RecursosBDModulo7.MensajeInicioInfoLogger, System.Reflection.MethodBase.GetCurrentMethod().Name);

            BDConexion laConexion;
            List<Parametro> parametros;
            Parametro elParametro = new Parametro();
            Cinta cinta;

            try
            {
                if (idCinta.GetType() == Type.GetType("System.Int32") && idCinta > 0)
                {
                    laConexion = new BDConexion();
                    parametros = new List<Parametro>();
                    cinta = new Cinta();

                    elParametro = new Parametro(RecursosBDModulo7.ParamIdCinta, SqlDbType.Int, idCinta.ToString(), false);
                    parametros.Add(elParametro);

                    DataTable dt = laConexion.EjecutarStoredProcedureTuplas(
                                   RecursosBDModulo7.ConsultarCintaXId, parametros);

                    foreach (DataRow row in dt.Rows)
                    {
                        cinta.Id_cinta = int.Parse(row[RecursosBDModulo7.AliasIdCinta].ToString());
                        cinta.Color_nombre = row[RecursosBDModulo7.AliasCintaNombre].ToString();
                        cinta.Rango = row[RecursosBDModulo7.AliasCintaRango].ToString();
                        cinta.Clasificacion = row[RecursosBDModulo7.AliasCintaClasificacion].ToString();
                        cinta.Significado = row[RecursosBDModulo7.AliasCintaSignificado].ToString();
                        cinta.Orden = int.Parse(row[RecursosBDModulo7.AliasCintaOrden].ToString());
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
            return cinta;
        }

        /// <summary>
        /// Método para obtener la ultima cinta de una persona
        /// </summary>
        /// <param name="idPersona">Número entero que representa el ID de la Persona</param>
        /// <returns>Objeto de tipo Cinta</returns>
        public Cinta UltimaCinta(int idPersona)
        {
            Logger.EscribirInfo(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name,
                RecursosBDModulo7.MensajeInicioInfoLogger, System.Reflection.MethodBase.GetCurrentMethod().Name);

            BDConexion laConexion;
            List<Parametro> parametros;
            Parametro elParametro = new Parametro();
            Cinta cinta;
            try
            {
                if (idPersona.GetType() == Type.GetType("System.Int32") && idPersona > 0)
                {
                    laConexion = new BDConexion();
                    parametros = new List<Parametro>();
                    cinta = new Cinta();

                    elParametro = new Parametro(RecursosBDModulo7.ParamIdPersona, SqlDbType.Int, idPersona.ToString(), false);
                    parametros.Add(elParametro);

                    DataTable dt = laConexion.EjecutarStoredProcedureTuplas(
                                   RecursosBDModulo7.ConsultarUltimaCinta, parametros);

                    foreach (DataRow row in dt.Rows)
                    {

                        cinta.Id_cinta = int.Parse(row[RecursosBDModulo7.AliasIdCinta].ToString());
                        cinta.Color_nombre = row[RecursosBDModulo7.AliasCintaNombre].ToString();
                        cinta.Rango = row[RecursosBDModulo7.AliasCintaRango].ToString();
                        cinta.Clasificacion = row[RecursosBDModulo7.AliasCintaClasificacion].ToString();
                        cinta.Significado = row[RecursosBDModulo7.AliasCintaSignificado].ToString();
                        cinta.Orden = int.Parse(row[RecursosBDModulo7.AliasCintaOrden].ToString());

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
            return cinta;
        }

        /// <summary>
        /// Método que devuelve la fecha de la obtencion de las cintas para una persona
        /// </summary>
        /// <returns>Fecha de inscripción</returns>
        public DateTime fechaCinta(int idPersona, int idCinta)
        {
            Logger.EscribirInfo(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name,
                RecursosBDModulo7.MensajeInicioInfoLogger, System.Reflection.MethodBase.GetCurrentMethod().Name);
            BDConexion laConexion;
            List<Parametro> parametros;
            Parametro elParametroPersona = new Parametro();
            Parametro elParametroCinta = new Parametro();
            DateTime fechaCinta = new DateTime();

            try
            {
                if (idPersona.GetType() == Type.GetType("System.Int32") && idPersona > 0 && 
                    idCinta.GetType() == Type.GetType("System.Int32") && idCinta > 0)
                {
                    laConexion = new BDConexion();
                    parametros = new List<Parametro>();

                    elParametroPersona = new Parametro(RecursosBDModulo7.ParamIdPersona, SqlDbType.Int, idPersona.ToString(), false);
                    elParametroCinta = new Parametro(RecursosBDModulo7.ParamIdCinta, SqlDbType.Int, idCinta.ToString(), false);
                    parametros.Add(elParametroPersona);
                    parametros.Add(elParametroCinta);

                    DataTable dt = laConexion.EjecutarStoredProcedureTuplas(
                                   RecursosBDModulo7.ConsultarFechaCinta, parametros);

                    foreach (DataRow row in dt.Rows)
                    {
                        fechaCinta = DateTime.Parse(row[RecursosBDModulo7.AliasCintaFecha].ToString());
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
            return fechaCinta;
        }
    }
}
