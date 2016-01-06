﻿using DatosSKD.InterfazDAO.Modulo7;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DominioSKD;
using ExcepcionesSKD;
using ExcepcionesSKD.Modulo7;
using System.Data;
using System.Data.SqlClient;
using DominioSKD.Fabrica;

namespace DatosSKD.DAO.Modulo7
{
    public class DaoEvento : DAOGeneral, IDaoEvento
    {
        public bool Agregar(Entidad parametro)
        {
            throw new NotImplementedException();
        }

        public List<Entidad> ConsultarTodos()
        {
            throw new NotImplementedException();
        }

        public List<Entidad> ListarCompetenciasAsistidas(Entidad persona)
        {
            throw new NotImplementedException();
        }

        public List<Entidad> ListarCompetenciasInscritas(Entidad persona)
        {
            throw new NotImplementedException();
        }

        public List<Entidad> ListarEventosAsistidos(Entidad persona)
        {
            throw new NotImplementedException();
        }

        public List<Entidad> ListarEventosInscritos(Entidad persona)
        {
            throw new NotImplementedException();
        }

        public List<Entidad> ListarHorarioPracticaa(Entidad persona)
        {
            throw new NotImplementedException();
        }

        public bool Modificar(Entidad parametro)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Método para consultar el detalle de un evento
        /// </summary>
        /// <param name="parametro">Objeto de tipo Entidad que posee el id a consultar</param>
        /// <returns>Retorna objeto de tipo Entidad con la informacion detallada del evento</returns>
     
        public Entidad ConsultarXId(Entidad parametro)
        {
            Logger.EscribirInfo(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name,
              RecursosDAOModulo7.MensajeInicioInfoLogger, System.Reflection.MethodBase.GetCurrentMethod().Name);

            BDConexion conexion;
            List<Parametro> parametros;
            Parametro parametroQuery = new Parametro();
            FabricaEntidades fabricaEntidades = new FabricaEntidades();
            Evento idEvento = (Evento)parametro;
            Evento evento = (Evento)fabricaEntidades.ObtenerEvento();

            try
            {
                if (idEvento.Id > 0)
                {
                    conexion = new BDConexion();
                    parametros = new List<Parametro>();
                    parametroQuery = new Parametro(RecursosDAOModulo7.ParamIdEvento, SqlDbType.Int, idEvento.Id.ToString(), false);
                    parametros.Add(parametroQuery);

                    DataTable dt = conexion.EjecutarStoredProcedureTuplas(
                                    RecursosDAOModulo7.ConsultarEventoXId, parametros);

                    foreach (DataRow row in dt.Rows)
                    {

                        evento.Id_evento = int.Parse(row[RecursosDAOModulo7.AliasIdEvento].ToString());
                        evento.Nombre = row[RecursosDAOModulo7.AliasEventoNombre].ToString();
                        evento.Descripcion = row[RecursosDAOModulo7.AliasDescripcionEvento].ToString();
                        evento.Costo = float.Parse(row[RecursosDAOModulo7.AliasEventoCosto].ToString());
                       // evento.TipoEvento = baseDeDatosTipoEvento.DetallarTipoEvento(int.Parse(row[RecursosDAOModulo7.AliasEventoTipoEveId].ToString()));
                        //evento.Horario = baseDeDatosHorario.DetallarHorario(int.Parse(row[RecursosDAOModulo7.AliasEventoHorarioId].ToString()));
                        //evento.Ubicacion = baseDeDatosUbicacion.DetallarUbicacion(int.Parse(row[RecursosDAOModulo7.AliasEventoUbicacionId].ToString()));
                    }
                }
                else
                {
                    throw new NumeroEnteroInvalidoException(RecursosDAOModulo7.Codigo_Numero_Parametro_Invalido,
                                 RecursosDAOModulo7.Mensaje_Numero_Parametro_invalido, new Exception());
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
                throw new NumeroEnteroInvalidoException(RecursosDAOModulo7.Codigo_Numero_Parametro_Invalido,
                                 RecursosDAOModulo7.Mensaje_Numero_Parametro_invalido, new Exception());
            }
            catch (FormatException ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                throw new NumeroEnteroInvalidoException(RecursosDAOModulo7.Codigo_Numero_Parametro_Invalido,
                                 RecursosDAOModulo7.Mensaje_Numero_Parametro_invalido, new Exception());
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
                 RecursosDAOModulo7.MensajeFinInfoLogger, System.Reflection.MethodBase.GetCurrentMethod().Name);
            return evento;
        }

        /// <summary>
        /// Método para consultar la fecha de inscripcion de una competencia
        /// </summary>
        /// <param name="persona">Objeto de tipo Entidad que posee el id de la persona</param>
        /// <param name="competencia">Objeto de tipo Entidad que posee el id de la competencia</param>
        /// <returns>Retorna objeto de tipo Entidad con la fecha de inscripcion de la competencia</returns>
   
        public DateTime FechaInscripcionCompetencia(Entidad persona, Entidad competencia)
        {
            Logger.EscribirInfo(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name,
                 RecursosDAOModulo7.MensajeInicioInfoLogger, System.Reflection.MethodBase.GetCurrentMethod().Name);
            BDConexion laConexion;
            List<Parametro> parametros;
            Parametro parametroPersona = new Parametro();
            Parametro parametroCompetencia = new Parametro();
            DateTime fechaInscripcionCompetencia = new DateTime();
            Persona idPersona = (Persona)persona;
            Competencia idCompetencia = (Competencia)competencia;

            try
            {
                if (idPersona.ID > 0 && idCompetencia.Id_competencia > 0)
                {
                    laConexion = new BDConexion();
                    parametros = new List<Parametro>();
                    parametroPersona = new Parametro(RecursosDAOModulo7.ParamIdPersona, SqlDbType.Int, idPersona.ID.ToString(), false);
                    parametroCompetencia = new Parametro(RecursosDAOModulo7.ParamIdCompetenciaPaga, SqlDbType.Int, idCompetencia.Id_competencia.ToString(), false);
                    parametros.Add(parametroPersona);
                    parametros.Add(parametroCompetencia);

                    DataTable dt = laConexion.EjecutarStoredProcedureTuplas(
                                   RecursosDAOModulo7.ConsultarFechaInscripcionCompetencia, parametros);

                    foreach (DataRow row in dt.Rows)
                    {

                        fechaInscripcionCompetencia = DateTime.Parse(row[RecursosDAOModulo7.AliasInscripcionFechaCompetencia].ToString());
                    }
                }
                else
                {
                    throw new NumeroEnteroInvalidoException(RecursosDAOModulo7.Codigo_Numero_Parametro_Invalido,
                                RecursosDAOModulo7.Mensaje_Numero_Parametro_invalido, new Exception());
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
                throw new NumeroEnteroInvalidoException(RecursosDAOModulo7.Codigo_Numero_Parametro_Invalido,
                                RecursosDAOModulo7.Mensaje_Numero_Parametro_invalido, new Exception());
            }
            catch (FormatException ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                throw new NumeroEnteroInvalidoException(RecursosDAOModulo7.Codigo_Numero_Parametro_Invalido,
                                RecursosDAOModulo7.Mensaje_Numero_Parametro_invalido, new Exception());
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
                RecursosDAOModulo7.MensajeFinInfoLogger, System.Reflection.MethodBase.GetCurrentMethod().Name);

            return fechaInscripcionCompetencia;
        }

        /// <summary>
        /// Método para consultar la fecha de inscripcion de un evento
        /// </summary>
        /// <param name="persona">Objeto de tipo Entidad que posee el id de la persona</param>
        /// <param name="evento">Objeto de tipo Entidad que posee el id del evento</param>
        /// <returns>Retorna objeto de tipo Entidad con la fecha de inscripcion del evento</returns>
        
        public DateTime FechaInscripcionEvento(Entidad persona, Entidad evento)
        {
            Logger.EscribirInfo(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name,
                 RecursosDAOModulo7.MensajeInicioInfoLogger, System.Reflection.MethodBase.GetCurrentMethod().Name);
            BDConexion laConexion;
            List<Parametro> parametros;
            Parametro parametroPersona = new Parametro();
            Parametro elParametroEvento = new Parametro();
            DateTime fechaInscripcion = new DateTime();
            Persona idPersona = (Persona)persona;
            Evento idEvento = (Evento)evento;

            try
            {
                if (idPersona.ID > 0 && idEvento.Id_evento > 0)
                {
                    laConexion = new BDConexion();
                    parametros = new List<Parametro>();
                    parametroPersona = new Parametro(RecursosDAOModulo7.ParamIdPersona, SqlDbType.Int, idPersona.ID.ToString(), false);
                    elParametroEvento = new Parametro(RecursosDAOModulo7.ParamIdEvento, SqlDbType.Int, idEvento.ToString(), false);
                    parametros.Add(parametroPersona);
                    parametros.Add(elParametroEvento);

                    DataTable dt = laConexion.EjecutarStoredProcedureTuplas(
                                   RecursosDAOModulo7.ConsultarFechaInscripcion, parametros);

                    foreach (DataRow row in dt.Rows)
                    {

                        fechaInscripcion = DateTime.Parse(row[RecursosDAOModulo7.AliasInscripcionFecha].ToString());
                    }
                }
                else
                {
                    throw new NumeroEnteroInvalidoException(RecursosDAOModulo7.Codigo_Numero_Parametro_Invalido,
                                RecursosDAOModulo7.Mensaje_Numero_Parametro_invalido, new Exception());
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
                throw new NumeroEnteroInvalidoException(RecursosDAOModulo7.Codigo_Numero_Parametro_Invalido,
                                RecursosDAOModulo7.Mensaje_Numero_Parametro_invalido, new Exception());
            }
            catch (FormatException ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                throw new NumeroEnteroInvalidoException(RecursosDAOModulo7.Codigo_Numero_Parametro_Invalido,
                                RecursosDAOModulo7.Mensaje_Numero_Parametro_invalido, new Exception());
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
                RecursosDAOModulo7.MensajeFinInfoLogger, System.Reflection.MethodBase.GetCurrentMethod().Name);

            return fechaInscripcion;
        }

        /// <summary>
        /// Método para consultar la fecha de pago de un evento
        /// </summary>
        /// <param name="persona">Objeto de tipo Entidad que posee el id de la persona</param>
        /// <param name="evento">Objeto de tipo Entidad que posee el id del evento</param>
        /// <returns>Retorna objeto de tipo Entidad con la fecha en la que se realizo el pago del evento</returns>
        
        public DateTime FechaPagoEvento(Entidad persona, Entidad evento)
        {
            Logger.EscribirInfo(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name,
                  RecursosDAOModulo7.MensajeInicioInfoLogger, System.Reflection.MethodBase.GetCurrentMethod().Name);
            BDConexion laConexion;
            List<Parametro> parametros;
            Parametro parametroPersona = new Parametro();
            Parametro parametroEvento = new Parametro();
            DateTime fechaPago = new DateTime();
            Persona idPersona = (Persona)persona;
            Evento idEvento = (Evento)evento;

            try
            {
                if (idPersona.ID > 0 && idEvento.Id_evento > 0)
                {
                    laConexion = new BDConexion();
                    parametros = new List<Parametro>();
                    parametroPersona = new Parametro(RecursosDAOModulo7.ParamIdPersona, SqlDbType.Int, idPersona.ID.ToString(), false);
                    parametroEvento = new Parametro(RecursosDAOModulo7.ParamIdEvento, SqlDbType.Int, idEvento.ToString(), false);
                    parametros.Add(parametroPersona);
                    parametros.Add(parametroEvento);

                    DataTable dt = laConexion.EjecutarStoredProcedureTuplas(
                                   RecursosDAOModulo7.ConsultarFechaPagoEvento, parametros);

                    foreach (DataRow row in dt.Rows)
                    {

                        fechaPago = DateTime.Parse(row[RecursosDAOModulo7.AliasFechaPago].ToString());
                    }
                }
                else
                {
                    throw new NumeroEnteroInvalidoException(RecursosDAOModulo7.Codigo_Numero_Parametro_Invalido,
                                RecursosDAOModulo7.Mensaje_Numero_Parametro_invalido, new Exception());
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
                throw new NumeroEnteroInvalidoException(RecursosDAOModulo7.Codigo_Numero_Parametro_Invalido,
                                RecursosDAOModulo7.Mensaje_Numero_Parametro_invalido, new Exception());
            }
            catch (FormatException ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                throw new NumeroEnteroInvalidoException(RecursosDAOModulo7.Codigo_Numero_Parametro_Invalido,
                                RecursosDAOModulo7.Mensaje_Numero_Parametro_invalido, new Exception());
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
                RecursosDAOModulo7.MensajeFinInfoLogger, System.Reflection.MethodBase.GetCurrentMethod().Name);

            return fechaPago;
        }

        /// <summary>
        /// Método para consultar la lista de competencias pagos
        /// </summary>
        /// <param name="persona">Objeto de tipo Entidad que posee el id de la persona</param>
        /// <returns>Retorna objeto de tipo Entidad con la lista de competencias que han sido canceladas</returns>
        
        public List<Entidad> ListarCompetenciasPaga(Entidad persona)
        {
            Logger.EscribirInfo(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name,
                RecursosDAOModulo7.MensajeInicioInfoLogger, System.Reflection.MethodBase.GetCurrentMethod().Name);

            BDConexion laConexion;
            List<Parametro> parametros;
            Parametro parametroQuery = new Parametro();

            FabricaEntidades fabricaEntidades = new FabricaEntidades();
            List<Entidad> listaDeCompetenciasPagas= new List<Entidad>();
            Persona idPersona = (Persona)persona;

            try
            {
                if (idPersona.ID > 0)
                {
                    laConexion = new BDConexion();
                    parametros = new List<Parametro>();
                    parametroQuery = new Parametro(RecursosDAOModulo7.ParamIdUsuarioLogueado, SqlDbType.Int, idPersona.ID.ToString(), false);
                    parametros.Add(parametroQuery);

                    DataTable dt = laConexion.EjecutarStoredProcedureTuplas(
                                   RecursosDAOModulo7.ConsultarCompetenciasInscritas, parametros);


                    foreach (DataRow row in dt.Rows)
                    {
                        Competencia competencia = (Competencia)fabricaEntidades.ObtenerCompetencia();

                        competencia.Id_competencia = int.Parse(row[RecursosDAOModulo7.AliasIdCompetencia].ToString());
                        competencia.Nombre = row[RecursosDAOModulo7.AliasCompetenciaNombre].ToString();
                        if (int.Parse(row[RecursosDAOModulo7.AliasCompetenciaTipo].ToString()).Equals(1))
                            competencia.TipoCompetencia = RecursosDAOModulo7.AliasCompetenciaKata;
                        else if (int.Parse(row[RecursosDAOModulo7.AliasCompetenciaTipo].ToString()).Equals(2))
                            competencia.TipoCompetencia = RecursosDAOModulo7.AliasCompetenciaKumite;
                        else if (int.Parse(row[RecursosDAOModulo7.AliasCompetenciaTipo].ToString()).Equals(3))
                            competencia.TipoCompetencia = RecursosDAOModulo7.AliasCompetenciaKataKumite;
                        competencia.FechaInicio = DateTime.Parse(row[RecursosDAOModulo7.AliasCompetenciaFechaInicio].ToString());
                        competencia.Costo = int.Parse(row[RecursosDAOModulo7.AliasCompetenciaCosto].ToString());
                        listaDeCompetenciasPagas.Add(competencia);
                    }
                }
                else
                {

                    throw new NumeroEnteroInvalidoException(RecursosDAOModulo7.Codigo_Numero_Parametro_Invalido,
                                RecursosDAOModulo7.Mensaje_Numero_Parametro_invalido, new Exception());
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
                throw new NumeroEnteroInvalidoException(RecursosDAOModulo7.Codigo_Numero_Parametro_Invalido,
                                RecursosDAOModulo7.Mensaje_Numero_Parametro_invalido, new Exception());

            }
            catch (FormatException ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                throw new NumeroEnteroInvalidoException(RecursosDAOModulo7.Codigo_Numero_Parametro_Invalido,
                                RecursosDAOModulo7.Mensaje_Numero_Parametro_invalido, new Exception());
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
                RecursosDAOModulo7.MensajeFinInfoLogger, System.Reflection.MethodBase.GetCurrentMethod().Name);

            return listaDeCompetenciasPagas;
        }

        /// <summary>
        /// Método para consultar la lista de eventos pagos
        /// </summary>
        /// <param name="persona">Objeto de tipo Entidad que posee el id de la persona</param>
        /// <returns>Retorna objeto de tipo Entidad con la lista de eventos que han sido pagos</returns>
        /// 
        public List<Entidad> ListarEventosPagos(Entidad persona)
        {
            Logger.EscribirInfo(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name,
                RecursosDAOModulo7.MensajeInicioInfoLogger, System.Reflection.MethodBase.GetCurrentMethod().Name);

            BDConexion laConexion;
            List<Parametro> parametros;
            Parametro parametroQuery = new Parametro();

            FabricaEntidades fabricaEntidades = new FabricaEntidades();
            List<Entidad> listaDeEventos = new List<Entidad>();
            Persona idPersona = (Persona)persona;

            try
            {
                if (idPersona.ID > 0)
                {
                    laConexion = new BDConexion();
                    parametros = new List<Parametro>();
                    parametroQuery = new Parametro(RecursosDAOModulo7.ParamIdUsuarioLogueado, SqlDbType.Int, idPersona.ID.ToString(), false);
                    parametros.Add(parametroQuery);

                    DataTable dt = laConexion.EjecutarStoredProcedureTuplas(
                                   RecursosDAOModulo7.ConsultarEventosPagos, parametros);


                    foreach (DataRow row in dt.Rows)
                    {
                        Evento evento  = (Evento)fabricaEntidades.ObtenerEvento();
                    
                        evento.Id_evento = int.Parse(row[RecursosDAOModulo7.AliasIdEvento].ToString());
                        evento.Nombre = row[RecursosDAOModulo7.AliasEventoNombre].ToString();
                       // evento.TipoEvento = baseDeDatosTipoEvento.DetallarTipoEvento(int.Parse(row[RecursosDAOModulo7.AliasEventoTipoEveId].ToString()));
                        listaDeEventos.Add(evento);
                    }
                }
                else
                {

                    throw new NumeroEnteroInvalidoException(RecursosDAOModulo7.Codigo_Numero_Parametro_Invalido,
                                RecursosDAOModulo7.Mensaje_Numero_Parametro_invalido, new Exception());
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
                throw new NumeroEnteroInvalidoException(RecursosDAOModulo7.Codigo_Numero_Parametro_Invalido,
                                RecursosDAOModulo7.Mensaje_Numero_Parametro_invalido, new Exception());

            }
            catch (FormatException ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                throw new NumeroEnteroInvalidoException(RecursosDAOModulo7.Codigo_Numero_Parametro_Invalido,
                                RecursosDAOModulo7.Mensaje_Numero_Parametro_invalido, new Exception());
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
                RecursosDAOModulo7.MensajeFinInfoLogger, System.Reflection.MethodBase.GetCurrentMethod().Name);

            return listaDeEventos;
        }

        /// <summary>
        /// Método para consultar el monto cancelado de un evento
        /// </summary>
        /// <param name="persona">Objeto de tipo Entidad que posee el id de la persona</param>
        /// <param name="evento">Objeto de tipo Entidad que posee el id del evento</param>
        /// <returns>Retorna objeto de tipo Entidad con el monto pago del evento</returns>
        
       public float MontoPagoEvento(Entidad persona, Entidad evento)
        {
        Logger.EscribirInfo(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name,
                 RecursosDAOModulo7.MensajeInicioInfoLogger, System.Reflection.MethodBase.GetCurrentMethod().Name);
            BDConexion laConexion;
            List<Parametro> parametros;
            Parametro parametroPersona = new Parametro();
            Parametro parametroEvento = new Parametro();
            float monto = new float();
            Persona idPersona = (Persona)persona;
            Evento idEvento = (Evento)evento;
        
            try
            {
                if (idPersona.ID > 0 && idEvento.Id_evento > 0)
                {
                    laConexion = new BDConexion();
                    parametros = new List<Parametro>();
                    parametroPersona = new Parametro(RecursosDAOModulo7.ParamIdPersona, SqlDbType.Int, idPersona.ID.ToString(), false);
                    parametroEvento = new Parametro(RecursosDAOModulo7.ParamIdEvento, SqlDbType.Int, idEvento.Id_evento.ToString(), false);
                    parametros.Add(parametroPersona);
                    parametros.Add(parametroEvento);

                    DataTable dt = laConexion.EjecutarStoredProcedureTuplas(
                                   RecursosDAOModulo7.ConsultarMontoEvento, parametros);

                    foreach (DataRow row in dt.Rows)
                    {
                        monto = float.Parse(row[RecursosDAOModulo7.AliasMontoEvento].ToString());
                    }
                }
                else
                {
                    throw new NumeroEnteroInvalidoException(RecursosDAOModulo7.Codigo_Numero_Parametro_Invalido,
                                RecursosDAOModulo7.Mensaje_Numero_Parametro_invalido, new Exception());
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
                throw new NumeroEnteroInvalidoException(RecursosDAOModulo7.Codigo_Numero_Parametro_Invalido,
                                RecursosDAOModulo7.Mensaje_Numero_Parametro_invalido, new Exception());
            }
            catch (FormatException ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                throw new NumeroEnteroInvalidoException(RecursosDAOModulo7.Codigo_Numero_Parametro_Invalido,
                                RecursosDAOModulo7.Mensaje_Numero_Parametro_invalido, new Exception());
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
                RecursosDAOModulo7.MensajeFinInfoLogger, System.Reflection.MethodBase.GetCurrentMethod().Name);

            return monto;
        
        }
    }
}
