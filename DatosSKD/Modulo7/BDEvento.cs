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
    public class BDEvento
    {
        #region Atributos
        BDUbicacion baseDeDatosUbicacion = new BDUbicacion();
        BDHorario baseDeDatosHorario = new BDHorario();
        BDTipoEvento baseDeDatosTipoEvento = new BDTipoEvento();
        #endregion

        /// <summary>
        /// Método que consulta en la BD para detallar un evento
        /// </summary>
        /// <param name="idEvento">Número entero que representa el ID del evento</param>
        /// <returns>Objeto de tipo Evento</returns>
        public Evento DetallarEvento(int idEvento)
        {

                Logger.EscribirInfo(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name,
                RecursosBDModulo7.MensajeInicioInfoLogger, System.Reflection.MethodBase.GetCurrentMethod().Name);
             
                  BDConexion laConexion;
                  List<Parametro> parametros;
                  Parametro elParametro = new Parametro();
                  Evento evento;

            try
            {
                if (idEvento.GetType() == Type.GetType("System.Int32") && idEvento > 0)
                {
                    laConexion = new BDConexion();
                    parametros = new List<Parametro>();
                    evento = new Evento();

                    elParametro = new Parametro(RecursosBDModulo7.ParamIdEvento, SqlDbType.Int, idEvento.ToString(), false);
                    parametros.Add(elParametro);

                    DataTable dt = laConexion.EjecutarStoredProcedureTuplas(RecursosBDModulo7.ConsultarEventoXId, parametros);

                foreach (DataRow row in dt.Rows)
                {

                    evento.Id_evento = int.Parse(row[RecursosBDModulo7.AliasIdEvento].ToString());
                    evento.Nombre = row[RecursosBDModulo7.AliasEventoNombre].ToString();
                    evento.Descripcion = row[RecursosBDModulo7.AliasDescripcionEvento].ToString();
                    evento.Costo = float.Parse(row[RecursosBDModulo7.AliasEventoCosto].ToString());
                    evento.TipoEvento = baseDeDatosTipoEvento.DetallarTipoEvento(int.Parse(row[RecursosBDModulo7.AliasEventoTipoEveId].ToString()));
                    evento.Horario = baseDeDatosHorario.DetallarHorario(int.Parse(row[RecursosBDModulo7.AliasEventoHorarioId].ToString()));
                    evento.Ubicacion = baseDeDatosUbicacion.DetallarUbicacion(int.Parse(row[RecursosBDModulo7.AliasEventoUbicacionId].ToString()));

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
            return evento;
        }

        /// <summary>
        /// Método para listar las competencias asistidas del atleta
        /// </summary>
        /// <returns>Lista de competencias</returns>
        public List<Competencia> ListarCompetenciasAsistidas(int idPersona)
        {

            Logger.EscribirInfo(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name,
            RecursosBDModulo7.MensajeInicioInfoLogger, System.Reflection.MethodBase.GetCurrentMethod().Name);
            BDConexion laConexion;
            List<Parametro> parametros;
            Parametro elParametro = new Parametro();
            List<Competencia> laListaDeCompetenciasAsistidas = new List<Competencia>();

            try
            {
                if (idPersona.GetType() == Type.GetType("System.Int32") && idPersona > 0)
                {
                    laConexion = new BDConexion();
                    parametros = new List<Parametro>();

                    elParametro = new Parametro(RecursosBDModulo7.ParamIdPersona, SqlDbType.Int, idPersona.ToString(), false);
                    parametros.Add(elParametro);

                    DataTable dt = laConexion.EjecutarStoredProcedureTuplas(RecursosBDModulo7.ConsultarCompetenciasAsistidas, parametros);

                foreach (DataRow row in dt.Rows)
                {
                    Competencia competencia = new Competencia();
                    competencia.Id_competencia = int.Parse(row[RecursosBDModulo7.AliasIdCompetencia].ToString());
                    competencia.Nombre = row[RecursosBDModulo7.AliasCompetenciaNombre].ToString();
                    if (int.Parse(row[RecursosBDModulo7.AliasCompetenciaTipo].ToString()).Equals(1))                   
                        competencia.TipoCompetencia = RecursosBDModulo7.AliasCompetenciaKata;
                    else if (int.Parse(row[RecursosBDModulo7.AliasCompetenciaTipo].ToString()).Equals(2))
                        competencia.TipoCompetencia = RecursosBDModulo7.AliasCompetenciaKumite;
                    else if (int.Parse(row[RecursosBDModulo7.AliasCompetenciaTipo].ToString()).Equals(3))
                        competencia.TipoCompetencia = RecursosBDModulo7.AliasCompetenciaKataKumite;
                    competencia.FechaInicio = DateTime.Parse(row[RecursosBDModulo7.AliasCompetenciaFechaInicio].ToString());
                    competencia.Costo = int.Parse(row[RecursosBDModulo7.AliasCompetenciaCosto].ToString());
                    competencia.Ubicacion = baseDeDatosUbicacion.DetallarUbicacion(int.Parse(row[RecursosBDModulo7.AliasCompetenciaUbicacionId].ToString()));
                    laListaDeCompetenciasAsistidas.Add(competencia);
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

            return laListaDeCompetenciasAsistidas;
        }
          

        /// <summary>
        /// Metodo para listar las competencias asistidas del atleta
        /// </summary>
        /// <param name="idPersona"></param>
        /// <returns></returns>
        public List<Competencia> ListarCompetenciasInscritas(int idPersona)
        {
            Logger.EscribirInfo(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name,
              RecursosBDModulo7.MensajeInicioInfoLogger, System.Reflection.MethodBase.GetCurrentMethod().Name);

            BDConexion laConexion;
            List<Parametro> parametros;
            Parametro elParametro = new Parametro();
            List<Competencia> laListaDeCompetenciasInscritas = new List<Competencia>();

            try
            {
                if (idPersona.GetType() == Type.GetType("System.Int32") && idPersona > 0)
                {
                laConexion = new BDConexion();
                parametros = new List<Parametro>();

                elParametro = new Parametro(RecursosBDModulo7.ParamIdUsuarioLogueado, SqlDbType.Int, idPersona.ToString(), false);
                parametros.Add(elParametro);

                DataTable dt = laConexion.EjecutarStoredProcedureTuplas(
                               RecursosBDModulo7.ConsultarCompetenciasInscritas, parametros);

                foreach (DataRow row in dt.Rows)
                {
                    Competencia competencia = new Competencia();
                    competencia.Id_competencia = int.Parse(row[RecursosBDModulo7.AliasIdCompetencia].ToString());
                    competencia.Nombre = row[RecursosBDModulo7.AliasCompetenciaNombre].ToString();
                              if (int.Parse(row[RecursosBDModulo7.AliasCompetenciaTipo].ToString()).Equals(1))
                    competencia.TipoCompetencia = RecursosBDModulo7.AliasCompetenciaKata;
                         else if (int.Parse(row[RecursosBDModulo7.AliasCompetenciaTipo].ToString()).Equals(2))
                    competencia.TipoCompetencia = RecursosBDModulo7.AliasCompetenciaKumite;
                        else if (int.Parse(row[RecursosBDModulo7.AliasCompetenciaTipo].ToString()).Equals(3))
                    competencia.TipoCompetencia = RecursosBDModulo7.AliasCompetenciaKataKumite;
                    competencia.FechaInicio = DateTime.Parse(row[RecursosBDModulo7.AliasCompetenciaFechaInicio].ToString());
                    competencia.Costo = int.Parse(row[RecursosBDModulo7.AliasCompetenciaCosto].ToString());
                    competencia.Ubicacion = baseDeDatosUbicacion.DetallarUbicacion(int.Parse(row[RecursosBDModulo7.AliasCompetenciaUbicacionId].ToString()));
                    laListaDeCompetenciasInscritas.Add(competencia);
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

            
                return laListaDeCompetenciasInscritas;
        }
        
        /// <summary>
        /// Método para listar los eventos asistidos del atleta
        /// </summary>
        /// <returns>Lista de eventos</returns>
        public List<Evento> ListarEventosAsistidos(int idPersona)
        {
            Logger.EscribirInfo(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name,
            RecursosBDModulo7.MensajeInicioInfoLogger, System.Reflection.MethodBase.GetCurrentMethod().Name);

            BDConexion laConexion;
            List<Parametro> parametros;
            Parametro elParametro = new Parametro();
            List<Evento> laListaDeEventoAsistidos = new List<Evento>();

            try
            {
                 if (idPersona.GetType() == Type.GetType("System.Int32") && idPersona > 0)
                {
                
                    laConexion = new BDConexion();
                    parametros = new List<Parametro>();
                
                    elParametro = new Parametro(RecursosBDModulo7.ParamIdPersona, SqlDbType.Int, idPersona.ToString(),false);
                    parametros.Add(elParametro);

                     DataTable dt = laConexion.EjecutarStoredProcedureTuplas(RecursosBDModulo7.ConsultarEventosAsistidos, parametros);

                foreach (DataRow row in dt.Rows)
                {
                    Evento evento = new Evento();
                    evento.Id_evento = int.Parse(row[RecursosBDModulo7.AliasIdEvento].ToString());
                    evento.Nombre = row[RecursosBDModulo7.AliasEventoNombre].ToString();
                    evento.Descripcion = row[RecursosBDModulo7.AliasDescripcionEvento].ToString();
                    evento.Costo = float.Parse(row[RecursosBDModulo7.AliasEventoCosto].ToString());
                    evento.TipoEvento = baseDeDatosTipoEvento.DetallarTipoEvento(int.Parse(row[RecursosBDModulo7.AliasEventoTipoEveId].ToString()));
                    evento.Horario = baseDeDatosHorario.DetallarHorario(int.Parse(row[RecursosBDModulo7.AliasEventoHorarioId].ToString()));
                    evento.Ubicacion = baseDeDatosUbicacion.DetallarUbicacion(int.Parse(row[RecursosBDModulo7.AliasEventoUbicacionId].ToString()));
                    laListaDeEventoAsistidos.Add(evento);
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

            return laListaDeEventoAsistidos;
        }
          
        /// <summary>
        /// Método que devuelve la fecha de una inscripción
        /// </summary>
        /// <returns>Fecha de inscripción</returns>
        public DateTime fechaPagoEvento(int idPersona, int idEvento)
        {
            Logger.EscribirInfo(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name,
            RecursosBDModulo7.MensajeInicioInfoLogger, System.Reflection.MethodBase.GetCurrentMethod().Name);

            BDConexion laConexion;
            List<Parametro> parametros;
            Parametro elParametroPersona = new Parametro();
            Parametro elParametroEvento = new Parametro();
            DateTime fechaPago = new DateTime();

            try
            {
                if ((idPersona.GetType() == Type.GetType("System.Int32") && idPersona > 0) && (idEvento.GetType() == Type.GetType("System.Int32") && idEvento > 0))
                {

                    laConexion = new BDConexion();
                    parametros = new List<Parametro>();

                    elParametroPersona = new Parametro(RecursosBDModulo7.ParamIdPersona, SqlDbType.Int, idPersona.ToString(), false);
                    elParametroEvento = new Parametro(RecursosBDModulo7.ParamIdEvento, SqlDbType.Int, idEvento.ToString(), false);
                    parametros.Add(elParametroPersona);
                    parametros.Add(elParametroEvento);

                    DataTable dt = laConexion.EjecutarStoredProcedureTuplas(RecursosBDModulo7.ConsultarFechaPagoEvento, parametros);

                foreach (DataRow row in dt.Rows)
                {
                    fechaPago = DateTime.Parse(row[RecursosBDModulo7.AliasFechaPago].ToString());
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

            return fechaPago;
        }

        /// <summary>
        /// Método que devuelve la fecha de una inscripción
        /// </summary>
        /// <returns>Fecha de inscripción</returns>
        public DateTime fechaInscripcionEvento(int idPersona, int idEvento)
        {
            Logger.EscribirInfo(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name,
            RecursosBDModulo7.MensajeInicioInfoLogger, System.Reflection.MethodBase.GetCurrentMethod().Name);

            BDConexion laConexion;
            List<Parametro> parametros;
            Parametro elParametroPersona = new Parametro();
            Parametro elParametroEvento = new Parametro();
            DateTime fechaInscripcion = new DateTime();

            try
            {
                if ((idPersona.GetType() == Type.GetType("System.Int32") && idPersona > 0) && (idEvento.GetType() == Type.GetType("System.Int32") && idEvento > 0))
                {

                    laConexion = new BDConexion();
                    parametros = new List<Parametro>();

                    elParametroPersona = new Parametro(RecursosBDModulo7.ParamIdPersona, SqlDbType.Int, idPersona.ToString(), false);
                    elParametroEvento = new Parametro(RecursosBDModulo7.ParamIdEvento, SqlDbType.Int, idEvento.ToString(), false);
                    parametros.Add(elParametroPersona);
                    parametros.Add(elParametroEvento);

                    DataTable dt = laConexion.EjecutarStoredProcedureTuplas(RecursosBDModulo7.ConsultarFechaInscripcion, parametros);

                    foreach (DataRow row in dt.Rows)
                    {
                        fechaInscripcion = DateTime.Parse(row[RecursosBDModulo7.AliasInscripcionFecha].ToString());
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

            return fechaInscripcion;
        }

        /// <summary>
        /// Método que devuelve la fecha de una inscripción
        /// </summary>
        /// <returns>Fecha de inscripción</returns>
        public DateTime fechaInscripcionCompetencia(int idPersona, int idCompetencia)
        {
            Logger.EscribirInfo(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name,
            RecursosBDModulo7.MensajeInicioInfoLogger, System.Reflection.MethodBase.GetCurrentMethod().Name);

            BDConexion laConexion;
            List<Parametro> parametros;
            Parametro elParametroPersona = new Parametro();
            Parametro elParametroCompetencia = new Parametro();
            DateTime fechaInscripcionCompetencia = new DateTime();

            try
            {
                if ((idPersona.GetType() == Type.GetType("System.Int32") && idPersona > 0) && (idCompetencia.GetType() == Type.GetType("System.Int32") && idCompetencia > 0))
                {

                    laConexion = new BDConexion();
                    parametros = new List<Parametro>();

                    elParametroPersona = new Parametro(RecursosBDModulo7.ParamIdPersona, SqlDbType.Int, idPersona.ToString(), false);
                    elParametroCompetencia= new Parametro(RecursosBDModulo7.ParamIdEvento, SqlDbType.Int, idCompetencia.ToString(), false);
                    parametros.Add(elParametroPersona);
                    parametros.Add(elParametroCompetencia);

                    DataTable dt = laConexion.EjecutarStoredProcedureTuplas(RecursosBDModulo7.ConsultarFechaInscripcionCompetencia, parametros);

                    foreach (DataRow row in dt.Rows)
                    {
                        fechaInscripcionCompetencia = DateTime.Parse(row[RecursosBDModulo7.AliasInscripcionFechaCompetencia].ToString());
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

            return fechaInscripcionCompetencia;
        }



        /// <summary>
        /// Metodo que lista los eventos a los cuales estan inscritos los atletas
        /// </summary>
        /// <returns>Lista de Evento Isncrito</returns>
        public List<Evento> ListarEventosInscritos(int idPersona)
        {

            Logger.EscribirInfo(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name,
            RecursosBDModulo7.MensajeInicioInfoLogger, System.Reflection.MethodBase.GetCurrentMethod().Name);
            BDConexion laConexion;
            List<Parametro> parametros;
            Parametro elParametro = new Parametro();
            List<Evento> laListaDeEventoInscrito = new List<Evento>();

            try
            {
                if (idPersona.GetType() == Type.GetType("System.Int32") && idPersona > 0)
                {
                    laConexion = new BDConexion();
                    parametros = new List<Parametro>();
                    elParametro = new Parametro(RecursosBDModulo7.ParamIdUsuarioLogueado, SqlDbType.Int, idPersona.ToString(), false);
                    parametros.Add(elParametro);

                    DataTable dt = laConexion.EjecutarStoredProcedureTuplas(
                               RecursosBDModulo7.ConsultarEventosInscritos, parametros);

                foreach (DataRow row in dt.Rows){
                        Evento evento = new Evento();
                        evento.Id_evento = int.Parse(row[RecursosBDModulo7.AliasIdEvento].ToString());
                        evento.Nombre = row[RecursosBDModulo7.AliasEventoNombre].ToString();
                        evento.Descripcion = row[RecursosBDModulo7.AliasDescripcionEvento].ToString();
                        evento.TipoEvento = baseDeDatosTipoEvento.DetallarTipoEvento(int.Parse(row[RecursosBDModulo7.AliasEventoTipoEveId].ToString()));
                        evento.Horario = baseDeDatosHorario.DetallarHorario(int.Parse(row[RecursosBDModulo7.AliasEventoHorarioId].ToString()));
                        evento.Ubicacion = baseDeDatosUbicacion.DetallarUbicacion(int.Parse(row[RecursosBDModulo7.AliasEventoUbicacionId].ToString()));
                        laListaDeEventoInscrito.Add(evento);
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

            return laListaDeEventoInscrito;
        }

       

        /// <summary>
        /// Método que devuelve el monto pago de una matricula
        /// </summary>
        /// <returns>Pago de matricula</returns>
        public float montoPagoEvento(int idPersona, int idEvento)
        {
            Logger.EscribirInfo(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name,
            RecursosBDModulo7.MensajeInicioInfoLogger, System.Reflection.MethodBase.GetCurrentMethod().Name);

            BDConexion laConexion;
            List<Parametro> parametros;
            Parametro elParametroPersona = new Parametro();
            Parametro elParametroEvento = new Parametro();
            float monto = new float();

            try
            {
                if ((idPersona.GetType() == Type.GetType("System.Int32") && idPersona > 0) && (idEvento.GetType() == Type.GetType("System.Int32") && idEvento > 0))
                {

                    laConexion = new BDConexion();
                    parametros = new List<Parametro>();

                    elParametroPersona = new Parametro(RecursosBDModulo7.ParamIdPersona, SqlDbType.Int, idPersona.ToString(), false);
                    elParametroEvento = new Parametro(RecursosBDModulo7.ParamIdEvento, SqlDbType.Int, idEvento.ToString(), false);
                    parametros.Add(elParametroPersona);
                    parametros.Add(elParametroEvento);

                    DataTable dt = laConexion.EjecutarStoredProcedureTuplas(RecursosBDModulo7.ConsultarMontoEvento, parametros);

                    foreach (DataRow row in dt.Rows)
                    {
                        monto = float.Parse(row[RecursosBDModulo7.AliasMontoEvento].ToString());
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


        ///Metodo que lista los eventos pagos del atleta
        public List<Evento> ListarEventosPagos(int idPersona)
        {
                Logger.EscribirInfo(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name,
                RecursosBDModulo7.MensajeInicioInfoLogger, System.Reflection.MethodBase.GetCurrentMethod().Name);

                BDConexion laConexion;
                List<Parametro> parametros;
                Parametro elParametro = new Parametro();
                List<Evento> laListaDeEventoPago = new List<Evento>();

            try
            {
                if (idPersona.GetType() == Type.GetType("System.Int32") && idPersona > 0)
                {
                  
                    laConexion = new BDConexion();
                    parametros = new List<Parametro>();
                    elParametro = new Parametro(RecursosBDModulo7.ParamIdUsuarioLogueado, SqlDbType.Int, idPersona.ToString(), false);
                    parametros.Add(elParametro);

                DataTable dt = laConexion.EjecutarStoredProcedureTuplas(
                               RecursosBDModulo7.ConsultarEventosPagos, parametros);

                foreach (DataRow row in dt.Rows)
                {
                    Evento evento = new Evento();
                    evento.Id_evento = int.Parse(row[RecursosBDModulo7.AliasIdEvento].ToString());
                    evento.Nombre = row[RecursosBDModulo7.AliasEventoNombre].ToString();
                    evento.TipoEvento = baseDeDatosTipoEvento.DetallarTipoEvento(int.Parse(row[RecursosBDModulo7.AliasEventoTipoEveId].ToString()));
                   
                    laListaDeEventoPago.Add(evento);
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

            return laListaDeEventoPago;
        }

       

        /// <summary>
        /// Metodo para listar las competencias pagadas del atleta
        /// </summary>
        /// <param name="idPersona"></param>
        /// <returns></returns>
        public List<Competencia> ListarCompetenciasPagas(int idPersona)
        {

            Logger.EscribirInfo(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name,
            RecursosBDModulo7.MensajeInicioInfoLogger, System.Reflection.MethodBase.GetCurrentMethod().Name);

            BDConexion laConexion;
            List<Parametro> parametros;
            Parametro elParametro = new Parametro();
            List<Competencia> laListaDeCompetenciasPagas = new List<Competencia>();

            try
            {
                  if (idPersona.GetType() == Type.GetType("System.Int32") && idPersona > 0)
                {
                   laConexion = new BDConexion();
                   parametros = new List<Parametro>();

                   elParametro = new Parametro(RecursosBDModulo7.ParamIdUsuarioLogueado, SqlDbType.Int, idPersona.ToString(), false);
                   parametros.Add(elParametro);

                   DataTable dt = laConexion.EjecutarStoredProcedureTuplas(RecursosBDModulo7.ConsultarCompetenciasInscritas, parametros);

                foreach (DataRow row in dt.Rows)
                {
                    Competencia competencia = new Competencia();

                    competencia.Nombre = row[RecursosBDModulo7.AliasCompetenciaNombre].ToString();
                    if (int.Parse(row[RecursosBDModulo7.AliasCompetenciaTipo].ToString()).Equals(1))
                        competencia.TipoCompetencia = RecursosBDModulo7.AliasCompetenciaKata;
                    else if (int.Parse(row[RecursosBDModulo7.AliasCompetenciaTipo].ToString()).Equals(2))
                        competencia.TipoCompetencia = RecursosBDModulo7.AliasCompetenciaKumite;
                    else if (int.Parse(row[RecursosBDModulo7.AliasCompetenciaTipo].ToString()).Equals(3))
                        competencia.TipoCompetencia = RecursosBDModulo7.AliasCompetenciaKataKumite;
                    competencia.FechaInicio = DateTime.Parse(row[RecursosBDModulo7.AliasCompetenciaFechaInicio].ToString());
                    competencia.Costo = int.Parse(row[RecursosBDModulo7.AliasCompetenciaCosto].ToString());
                    laListaDeCompetenciasPagas.Add(competencia);
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

            return laListaDeCompetenciasPagas;
        }

      
            
        /// <summary>
        /// Metodo que lista los horarios de practica de los atletas
        /// </summary>
        /// <param name="idPersona"></param>
        /// <returns>Lista de los horarios de practica</returns>
         
        public List<Evento> ListarHorarioPractica(int idPersona)
        {
                 Logger.EscribirInfo(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name,
                 RecursosBDModulo7.MensajeInicioInfoLogger, System.Reflection.MethodBase.GetCurrentMethod().Name);

                 BDConexion laConexion;
                 List<Parametro> parametros;
                 Parametro elParametro = new Parametro();
                 List<Evento> laListaDeHorarioPractica = new List<Evento>();

            try
            {
                
                if (idPersona.GetType() == Type.GetType("System.Int32") && idPersona > 0)
                {
                     laConexion = new BDConexion();
                     parametros = new List<Parametro>();


                     elParametro = new Parametro(RecursosBDModulo7.ParamIdUsuarioLogueado, SqlDbType.Int, idPersona.ToString(), false);
                     parametros.Add(elParametro);

                     DataTable dt = laConexion.EjecutarStoredProcedureTuplas(
                               RecursosBDModulo7.ConsultarHorarioPractica, parametros);

                foreach (DataRow row in dt.Rows)
                {
           
                        Evento evento = new Evento();
                        evento.Id_evento = int.Parse(row[RecursosBDModulo7.AliasIdEvento].ToString());
                        evento.Nombre = row[RecursosBDModulo7.AliasEventoNombre].ToString();
                        evento.Descripcion = row[RecursosBDModulo7.AliasDescripcionEvento].ToString();
                        evento.TipoEvento = baseDeDatosTipoEvento.DetallarTipoEvento(int.Parse(row[RecursosBDModulo7.AliasEventoTipoEveId].ToString()));
                        evento.Horario = baseDeDatosHorario.DetallarHorario(int.Parse(row[RecursosBDModulo7.AliasEventoHorarioId].ToString()));
                        evento.Ubicacion = baseDeDatosUbicacion.DetallarUbicacion(int.Parse(row[RecursosBDModulo7.AliasEventoUbicacionId].ToString()));
                        laListaDeHorarioPractica.Add(evento);
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

             return laListaDeHorarioPractica;
        }
    }
}
           

 