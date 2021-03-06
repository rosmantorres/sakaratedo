﻿using DatosSKD.Fabrica;
using DatosSKD.InterfazDAO.Modulo10;
using DominioSKD;
using DominioSKD.Fabrica;
using ExcepcionesSKD;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatosSKD.DAO.Modulo10
{
    public class DaoAsistencia : DAOGeneral, IDaoAsistencia
    {
        #region IDaoAsistencia
        /// <summary>
        /// Metodo que permite obtener de base de datos todos los eventos con asistencia pasada
        /// </summary>
        /// <returns>lista de eventos</returns>
        public List<Entidad> ListarEventosAsistidos()
        {
            Logger.EscribirInfo(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, RecursosDAOModulo10.MensajeInicioInfoLogger, System.Reflection.MethodBase.GetCurrentMethod().Name);
            List<Entidad> listaEventos = new List<Entidad>();
            List<Parametro> parametros;

            try
            {
                parametros = new List<Parametro>();
                DataTable dt = EjecutarStoredProcedureTuplas(RecursosDAOModulo10.ProcedimentoConsultarEventoAsistido, parametros);
                foreach (DataRow row in dt.Rows)
                {
                    Entidad evento = DominioSKD.Fabrica.FabricaEntidades.ObtenerEventoM10();
                    ((DominioSKD.Entidades.Modulo10.Evento) evento).Id = int.Parse(row[RecursosDAOModulo10.aliasIdEvento].ToString());
                    ((DominioSKD.Entidades.Modulo10.Evento) evento).Nombre = row[RecursosDAOModulo10.aliasNombreEvento].ToString();
                    Entidad horario = DominioSKD.Fabrica.FabricaEntidades.ObtenerHorarioM10();
                    ((DominioSKD.Entidades.Modulo10.Horario)horario).FechaInicio = DateTime.Parse(row[RecursosDAOModulo10.aliasFechaEvento].ToString());
                    Entidad tipo = DominioSKD.Fabrica.FabricaEntidades.ObtenerTipoEventoM10();
                    ((DominioSKD.Entidades.Modulo10.TipoEvento)tipo).Nombre = row[RecursosDAOModulo10.aliasTipoEvento].ToString();
                    ((DominioSKD.Entidades.Modulo10.Evento)evento).Horario = horario as DominioSKD.Entidades.Modulo10.Horario;
                    ((DominioSKD.Entidades.Modulo10.Evento)evento).TipoEvento = tipo as DominioSKD.Entidades.Modulo10.TipoEvento;
                    listaEventos.Add(evento);
                }

            }
            catch (SqlException ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                throw new ExcepcionesSKD.ExceptionSKDConexionBD(RecursoGeneralBD.Codigo,
                    RecursoGeneralBD.Mensaje, ex);
            }
            catch (FormatException ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                throw new ExcepcionesSKD.Modulo12.FormatoIncorrectoException(RecursosDAOModulo10.CodigoErrorFormato,
                     RecursosDAOModulo10.MensajeErrorFormato, ex);
            }
            catch (ExcepcionesSKD.ExceptionSKDConexionBD ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                throw ex;
            }
            catch (Exception ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                throw new ExcepcionesSKD.ExceptionSKD(RecursoGeneralBD.Mensaje_Generico_Error, ex);
            }

            return listaEventos;
        }

        /// <summary>
        /// Metodo que permite obtener de base de datos todas las competencias con asistencia pasada
        /// </summary>
        /// <returns>lista de competencias</returns>
        public List<Entidad> ListarCompetenciasAsistidas()
        {
            Logger.EscribirInfo(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, RecursosDAOModulo10.MensajeInicioInfoLogger, System.Reflection.MethodBase.GetCurrentMethod().Name);
            List<Entidad> listaCompetencia = new List<Entidad>();
            List<Parametro> parametros;

            try
            {
                parametros = new List<Parametro>();
                DataTable dt = EjecutarStoredProcedureTuplas(RecursosDAOModulo10.ProcedimentoConsultarCompetenciaAsistida, parametros);
                foreach (DataRow row in dt.Rows)
                {
                    DominioSKD.Fabrica.FabricaEntidades fabrica = new DominioSKD.Fabrica.FabricaEntidades();
                    Entidad competencia = FabricaEntidades.ObtenerCompetencia();
                    
                    ((DominioSKD.Entidades.Modulo12.Competencia) competencia).Id = int.Parse(row[RecursosDAOModulo10.aliasIdCompetencia].ToString());
                    ((DominioSKD.Entidades.Modulo12.Competencia) competencia).Nombre = row[RecursosDAOModulo10.aliasNombreCompetencia].ToString();
                    ((DominioSKD.Entidades.Modulo12.Competencia) competencia).FechaInicio = DateTime.Parse(row[RecursosDAOModulo10.aliasFechaCompetencia].ToString());
                    listaCompetencia.Add(competencia);
                }

            }
            catch (SqlException ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                throw new ExcepcionesSKD.ExceptionSKDConexionBD(RecursoGeneralBD.Codigo,
                    RecursoGeneralBD.Mensaje, ex);
            }
            catch (FormatException ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                throw new ExcepcionesSKD.Modulo12.FormatoIncorrectoException(RecursosDAOModulo10.CodigoErrorFormato,
                     RecursosDAOModulo10.MensajeErrorFormato, ex);
            }
            catch (ExcepcionesSKD.ExceptionSKDConexionBD ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                throw ex;
            }
            catch (Exception ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                throw new ExcepcionesSKD.ExceptionSKD(RecursoGeneralBD.Mensaje_Generico_Error, ex);
            }

            return listaCompetencia;
        }

        /// <summary>
        /// Metodo que permite obtener de base de datos todos los atletas asistidos a un evento especifico
        /// </summary>
        /// <param name="idEvento">id del evento</param>
        /// <returns>lista de atletas</returns>
        public List<Entidad> ListaAsistentesEvento(string idEvento)
        {
            Logger.EscribirInfo(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, RecursosDAOModulo10.MensajeInicioInfoLogger, System.Reflection.MethodBase.GetCurrentMethod().Name);
            List<Entidad> personas = new List<Entidad>();
            try
            {
                List<Parametro> parametros = new List<Parametro>();
                Parametro parametro = new Parametro(RecursosDAOModulo10.ParametroIdEvento, SqlDbType.Int, idEvento, false);
                parametros.Add(parametro);
                DataTable dt = EjecutarStoredProcedureTuplas(RecursosDAOModulo10.ProcedimientoAtletasAsistentes, parametros);

                foreach (DataRow row in dt.Rows)
                {
                    Entidad persona = DominioSKD.Fabrica.FabricaEntidades.ObtenerPersonaM10();
                    ((DominioSKD.Entidades.Modulo10.Persona) persona).Id = int.Parse(row[RecursosDAOModulo10.aliasIdPersona].ToString());
                    ((DominioSKD.Entidades.Modulo10.Persona) persona).Nombre = row[RecursosDAOModulo10.aliasNombrePersona].ToString();
                    ((DominioSKD.Entidades.Modulo10.Persona) persona).IdInscripcion = int.Parse(row[RecursosDAOModulo10.aliasIdInscripcion].ToString());
                    personas.Add(persona);
                }
            }
            catch (SqlException ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                throw new ExcepcionesSKD.ExceptionSKDConexionBD(RecursoGeneralBD.Codigo,
                    RecursoGeneralBD.Mensaje, ex);
            }
            catch (FormatException ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                throw new ExcepcionesSKD.Modulo12.FormatoIncorrectoException(RecursosDAOModulo10.CodigoErrorFormato,
                     RecursosDAOModulo10.MensajeErrorFormato, ex);
            }
            catch (ExcepcionesSKD.ExceptionSKDConexionBD ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                throw ex;
            }
            catch (Exception ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                throw new ExcepcionesSKD.ExceptionSKD(RecursoGeneralBD.Mensaje_Generico_Error, ex);
            }
            return personas;
        }

        /// <summary>
        /// Metodo que permite obtener de base de datos todos los atletas no asistidos a un evento especifico
        /// </summary>
        /// <param name="idEvento">id del evento</param>
        /// <returns>lista de atletas</returns>
        public List<Entidad> ListaNoAsistentesEvento(string idEvento)
        {
            Logger.EscribirInfo(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, RecursosDAOModulo10.MensajeInicioInfoLogger, System.Reflection.MethodBase.GetCurrentMethod().Name);
            List<Entidad> personas = new List<Entidad>();
            try
            {
                List<Parametro> parametros = new List<Parametro>();
                Parametro parametro = new Parametro(RecursosDAOModulo10.ParametroIdEvento, SqlDbType.Int, idEvento, false);
                parametros.Add(parametro);
                DataTable dt = EjecutarStoredProcedureTuplas(RecursosDAOModulo10.ProcedimientoAtletasInasitentes, parametros);

                foreach (DataRow row in dt.Rows)
                {
                    Entidad persona = DominioSKD.Fabrica.FabricaEntidades.ObtenerPersonaM10();
                    ((DominioSKD.Entidades.Modulo10.Persona)persona).Id = int.Parse(row[RecursosDAOModulo10.aliasIdPersona].ToString());
                    ((DominioSKD.Entidades.Modulo10.Persona)persona).Nombre = row[RecursosDAOModulo10.aliasNombrePersona].ToString();
                    ((DominioSKD.Entidades.Modulo10.Persona)persona).IdInscripcion = int.Parse(row[RecursosDAOModulo10.aliasIdInscripcion].ToString());
                    personas.Add(persona);
                }
            }
            catch (SqlException ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                throw new ExcepcionesSKD.ExceptionSKDConexionBD(RecursoGeneralBD.Codigo,
                    RecursoGeneralBD.Mensaje, ex);
            }
            catch (FormatException ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                throw new ExcepcionesSKD.Modulo12.FormatoIncorrectoException(RecursosDAOModulo10.CodigoErrorFormato,
                     RecursosDAOModulo10.MensajeErrorFormato, ex);
            }
            catch (ExcepcionesSKD.ExceptionSKDConexionBD ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                throw ex;
            }
            catch (Exception ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                throw new ExcepcionesSKD.ExceptionSKD(RecursoGeneralBD.Mensaje_Generico_Error, ex);
            }
            return personas;

        }

        public string ModificarFechas(string fecha)
        {
            if (int.Parse(fecha) < 10)
                fecha = RecursosDAOModulo10.Concatenar0 + fecha.ToString();
            return fecha;
        }

        /// <summary>
        /// Metodo que permite obtener de base de datos todos los atletas asistidos a un evento especifico
        /// </summary>
        /// <param name="idCompetencia">id del evento</param>
        /// <returns>lista de atletas</returns>
        public List<Entidad> ListaAsistentesCompetencia(string idCompetencia)
        {
            Logger.EscribirInfo(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, RecursosDAOModulo10.MensajeInicioInfoLogger, System.Reflection.MethodBase.GetCurrentMethod().Name);
            List<Entidad> personas = new List<Entidad>();
            try
            {
                List<Parametro> parametros = new List<Parametro>();
                Parametro parametro = new Parametro(RecursosDAOModulo10.ParametroIdCompetencia, SqlDbType.Int, idCompetencia, false);
                parametros.Add(parametro);
                DataTable dt = EjecutarStoredProcedureTuplas(RecursosDAOModulo10.ProcedimientoAtletasAsistentesCompetencia, parametros);

                foreach (DataRow row in dt.Rows)
                {
                    Entidad persona = DominioSKD.Fabrica.FabricaEntidades.ObtenerPersonaM10();
                    ((DominioSKD.Entidades.Modulo10.Persona)persona).Id = int.Parse(row[RecursosDAOModulo10.aliasIdPersona].ToString());
                    ((DominioSKD.Entidades.Modulo10.Persona)persona).Nombre = row[RecursosDAOModulo10.aliasNombrePersona].ToString();
                    ((DominioSKD.Entidades.Modulo10.Persona)persona).IdInscripcion = int.Parse(row[RecursosDAOModulo10.aliasIdInscripcion].ToString());
                    personas.Add(persona);
                }
            }
            catch (SqlException ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                throw new ExcepcionesSKD.ExceptionSKDConexionBD(RecursoGeneralBD.Codigo,
                    RecursoGeneralBD.Mensaje, ex);
            }
            catch (FormatException ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                throw new ExcepcionesSKD.Modulo12.FormatoIncorrectoException(RecursosDAOModulo10.CodigoErrorFormato,
                     RecursosDAOModulo10.MensajeErrorFormato, ex);
            }
            catch (ExcepcionesSKD.ExceptionSKDConexionBD ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                throw ex;
            }
            catch (Exception ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                throw new ExcepcionesSKD.ExceptionSKD(RecursoGeneralBD.Mensaje_Generico_Error, ex);
            }
            return personas;
        }

        /// <summary>
        /// Metodo que permite obtener de base de datos todos los atletas no asistidos a un evento especifico
        /// </summary>
        /// <param name="idCompetencia">id del evento</param>
        /// <returns>lista de atletas</returns>
        public List<Entidad> ListaNoAsistentesCompetencia(string idCompetencia)
        {
            Logger.EscribirInfo(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, RecursosDAOModulo10.MensajeInicioInfoLogger, System.Reflection.MethodBase.GetCurrentMethod().Name);
            List<Entidad> personas = new List<Entidad>();
            try
            {
                List<Parametro> parametros = new List<Parametro>();
                Parametro parametro = new Parametro(RecursosDAOModulo10.ParametroIdCompetencia, SqlDbType.Int, idCompetencia, false);
                parametros.Add(parametro);
                DataTable dt = EjecutarStoredProcedureTuplas(RecursosDAOModulo10.ProcedimientoInasistentesCompetencia, parametros);

                foreach (DataRow row in dt.Rows)
                {
                    Entidad persona = DominioSKD.Fabrica.FabricaEntidades.ObtenerPersonaM10();
                    ((DominioSKD.Entidades.Modulo10.Persona)persona).Id = int.Parse(row[RecursosDAOModulo10.aliasIdPersona].ToString());
                    ((DominioSKD.Entidades.Modulo10.Persona)persona).Nombre = row[RecursosDAOModulo10.aliasNombrePersona].ToString();
                    ((DominioSKD.Entidades.Modulo10.Persona)persona).IdInscripcion = int.Parse(row[RecursosDAOModulo10.aliasIdInscripcion].ToString());
                    personas.Add(persona);
                }
            }
            catch (SqlException ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                throw new ExcepcionesSKD.ExceptionSKDConexionBD(RecursoGeneralBD.Codigo,
                    RecursoGeneralBD.Mensaje, ex);
            }
            catch (FormatException ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                throw new ExcepcionesSKD.Modulo12.FormatoIncorrectoException(RecursosDAOModulo10.CodigoErrorFormato,
                     RecursosDAOModulo10.MensajeErrorFormato, ex);
            }
            catch (ExcepcionesSKD.ExceptionSKDConexionBD ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                throw ex;
            }
            catch (Exception ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                throw new ExcepcionesSKD.ExceptionSKD(RecursoGeneralBD.Mensaje_Generico_Error, ex);
            }
            return personas;
        }

        /// <summary>
        /// Metodo que permite modificar de base de datos una asistencia de un atleta 
        /// </summary>
        /// <param name="listaEntidad">lista de asistencia</param>
        /// <returns>true si se pudo modificar</returns>
        public bool ModificarAsistenciaEvento(List<Entidad> listaEntidad)
        {
            Logger.EscribirInfo(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, RecursosDAOModulo10.MensajeInicioInfoLogger, System.Reflection.MethodBase.GetCurrentMethod().Name);
            int cont = 0;
            try
            {
                foreach (Entidad asistencia in listaEntidad)
                {
                    List<Parametro> parametros = new List<Parametro>();
                    Parametro parametro = new Parametro(RecursosDAOModulo10.ParametroAsistencia, SqlDbType.Char, ((DominioSKD.Entidades.Modulo10.Asistencia)asistencia).Asistio, false);
                    parametros.Add(parametro);
                    parametro = new Parametro(RecursosDAOModulo10.ParametroIdEvento, SqlDbType.Int, ((DominioSKD.Entidades.Modulo10.Asistencia)asistencia).Evento.Id.ToString(), false);
                    parametros.Add(parametro);
                    parametro = new Parametro(RecursosDAOModulo10.ParametroIdInscripcion, SqlDbType.Int, ((DominioSKD.Entidades.Modulo10.Asistencia)asistencia).Inscripcion.Id.ToString(), false);
                    parametros.Add(parametro);

                    EjecutarStoredProcedure(RecursosDAOModulo10.ProcedimientoModificarAsistenciaE, parametros);
                    cont++;
                }

                if (listaEntidad.Count.Equals(cont))
                {
                    Logger.EscribirInfo(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, RecursosDAOModulo10.MensajeFinInfoLogger, System.Reflection.MethodBase.GetCurrentMethod().Name);
                    return true;
                }
                else
                {
                    Logger.EscribirInfo(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, RecursosDAOModulo10.MensajeFinInfoLogger, System.Reflection.MethodBase.GetCurrentMethod().Name);
                    return false;
                }
            }
            catch (SqlException ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                throw new ExcepcionesSKD.ExceptionSKDConexionBD(RecursoGeneralBD.Codigo,
                    RecursoGeneralBD.Mensaje, ex);
            }
            catch (FormatException ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                throw new ExcepcionesSKD.Modulo12.FormatoIncorrectoException(RecursosDAOModulo10.CodigoErrorFormato,
                     RecursosDAOModulo10.MensajeErrorFormato, ex);
            }
            catch (ExcepcionesSKD.ExceptionSKDConexionBD ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                throw ex;
            }
            catch (Exception ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                throw new ExcepcionesSKD.ExceptionSKD(RecursoGeneralBD.Mensaje_Generico_Error, ex);
            }
        }

        /// <summary>
        /// Metodo que permite obtener de base de datos una competencia por id
        /// </summary>
        /// <param name="idCompetencia">id de la competencia</param>
        /// <returns>Una Competencia</returns>
        public Entidad ConsultarCompetenciasXId(string idCompetencia)
        {
            Logger.EscribirInfo(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, RecursosDAOModulo10.MensajeInicioInfoLogger, System.Reflection.MethodBase.GetCurrentMethod().Name);
            DominioSKD.Fabrica.FabricaEntidades fabrica = new DominioSKD.Fabrica.FabricaEntidades();
            Entidad competencia = FabricaEntidades.ObtenerCompetencia();
            string diaFecha;
            string mesFecha;
            string anoFecha;
            string fechaInicio;

            try
            {
                List<Parametro> parametros = new List<Parametro>();
                Parametro parametro = new Parametro(RecursosDAOModulo10.ParametroIdCompetencia, SqlDbType.Int, idCompetencia, false);
                parametros.Add(parametro);
                DataTable dt = EjecutarStoredProcedureTuplas(RecursosDAOModulo10.ProcedimientoConsultarCompetenciaXID, parametros);

                foreach (DataRow row in dt.Rows)
                {
                    ((DominioSKD.Entidades.Modulo12.Competencia)competencia).Id = int.Parse(row[RecursosDAOModulo10.aliasIdCompetencia].ToString());
                    ((DominioSKD.Entidades.Modulo12.Competencia)competencia).Nombre = row[RecursosDAOModulo10.aliasNombreCompetencia].ToString();
                    diaFecha = Convert.ToDateTime(row[RecursosDAOModulo10.aliasFechaCompetencia]).Day.ToString();
                    diaFecha = ModificarFechas(diaFecha);
                    mesFecha = Convert.ToDateTime(row[RecursosDAOModulo10.aliasFechaCompetencia]).Month.ToString();
                    mesFecha = ModificarFechas(mesFecha);
                    anoFecha = Convert.ToDateTime(row[RecursosDAOModulo10.aliasFechaCompetencia]).Year.ToString();
                    fechaInicio = mesFecha + RecursosDAOModulo10.SeparadorFecha + diaFecha + RecursosDAOModulo10.SeparadorFecha + anoFecha;
                    ((DominioSKD.Entidades.Modulo12.Competencia)competencia).FechaInicio = DateTime.ParseExact(fechaInicio, RecursosDAOModulo10.FormatoFecha, CultureInfo.InvariantCulture);
                }
            }
            catch (SqlException ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                throw new ExcepcionesSKD.ExceptionSKDConexionBD(RecursoGeneralBD.Codigo,
                    RecursoGeneralBD.Mensaje, ex);
            }
            catch (FormatException ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                throw new ExcepcionesSKD.Modulo12.FormatoIncorrectoException(RecursosDAOModulo10.CodigoErrorFormato,
                     RecursosDAOModulo10.MensajeErrorFormato, ex);
            }
            catch (ExcepcionesSKD.ExceptionSKDConexionBD ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                throw ex;
            }
            catch (Exception ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                throw new ExcepcionesSKD.ExceptionSKD(RecursoGeneralBD.Mensaje_Generico_Error, ex);
            }
            return competencia;
        }

        /// <summary>
        /// Metodo que permite modificar de base de datos una asistencia de un atleta 
        /// </summary>
        /// <param name="listaEntidad">lista de asistencia</param>
        /// <returns>true si se pudo modificar</returns>
        public bool ModificarAsistenciaCompetencia(List<Entidad> listaEntidad)
        {
            Logger.EscribirInfo(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, RecursosDAOModulo10.MensajeInicioInfoLogger, System.Reflection.MethodBase.GetCurrentMethod().Name);
            int cont = 0;
            try
            {
                foreach (Entidad asistencia in listaEntidad)
                {
                    List<Parametro> parametros = new List<Parametro>();
                    Parametro parametro = new Parametro(RecursosDAOModulo10.ParametroIdInscripcion, SqlDbType.Int, ((DominioSKD.Entidades.Modulo10.Asistencia)asistencia).Inscripcion.Id.ToString(), false);
                    parametros.Add(parametro);
                    parametro = new Parametro(RecursosDAOModulo10.ParametroAsistencia, SqlDbType.Char, ((DominioSKD.Entidades.Modulo10.Asistencia)asistencia).Asistio, false);
                    parametros.Add(parametro);
                    parametro = new Parametro(RecursosDAOModulo10.ParametroIdCompetencia, SqlDbType.Int, ((DominioSKD.Entidades.Modulo10.Asistencia)asistencia).Competencia.Id.ToString(), false);
                    parametros.Add(parametro);

                    EjecutarStoredProcedure(RecursosDAOModulo10.ProcedimientoModificarAsistenciaC, parametros);
                    cont++;
                }


                if (listaEntidad.Count.Equals(cont))
                {
                    Logger.EscribirInfo(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, RecursosDAOModulo10.MensajeFinInfoLogger, System.Reflection.MethodBase.GetCurrentMethod().Name);
                    return true;
                }
                else
                {
                    Logger.EscribirInfo(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, RecursosDAOModulo10.MensajeFinInfoLogger, System.Reflection.MethodBase.GetCurrentMethod().Name);
                    return false;
                }
            }
            catch (SqlException ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                throw new ExcepcionesSKD.ExceptionSKDConexionBD(RecursoGeneralBD.Codigo,
                    RecursoGeneralBD.Mensaje, ex);
            }
            catch (FormatException ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                throw new ExcepcionesSKD.Modulo12.FormatoIncorrectoException(RecursosDAOModulo10.CodigoErrorFormato,
                     RecursosDAOModulo10.MensajeErrorFormato, ex);
            }
            catch (ExcepcionesSKD.ExceptionSKDConexionBD ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                throw ex;
            }
            catch (Exception ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                throw new ExcepcionesSKD.ExceptionSKD(RecursoGeneralBD.Mensaje_Generico_Error, ex);
            }
        }

        /// <summary>
        /// Metodo que permite obtener de base de datos todos los atletas inscritos a un evento especifico
        /// </summary>
        /// <param name="idEvento">id del evento</param>
        /// <returns>lista de atletas</returns>
        public List<Entidad> ListaAtletasInscritosEvento(string idEvento)
        {
            Logger.EscribirInfo(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, RecursosDAOModulo10.MensajeInicioInfoLogger, System.Reflection.MethodBase.GetCurrentMethod().Name);
            List<Entidad> personas = new List<Entidad>();
            try
            {
                List<Parametro> parametros = new List<Parametro>();
                Parametro parametro = new Parametro(RecursosDAOModulo10.ParametroIdEvento, SqlDbType.Int, idEvento, false);
                parametros.Add(parametro);
                DataTable dt = EjecutarStoredProcedureTuplas(RecursosDAOModulo10.ProcedimientoAtletasInscritosEvento, parametros);

                foreach (DataRow row in dt.Rows)
                {
                    Entidad persona = DominioSKD.Fabrica.FabricaEntidades.ObtenerPersonaM10();
                    ((DominioSKD.Entidades.Modulo10.Persona)persona).Id = int.Parse(row[RecursosDAOModulo10.aliasIdPersona].ToString());
                    ((DominioSKD.Entidades.Modulo10.Persona)persona).Nombre = row[RecursosDAOModulo10.aliasNombrePersona].ToString();
                    ((DominioSKD.Entidades.Modulo10.Persona)persona).IdInscripcion = int.Parse(row[RecursosDAOModulo10.aliasIdInscripcion].ToString());
                    personas.Add(persona);
                }
            }
            catch (SqlException ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                throw new ExcepcionesSKD.ExceptionSKDConexionBD(RecursoGeneralBD.Codigo,
                    RecursoGeneralBD.Mensaje, ex);
            }
            catch (FormatException ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                throw new ExcepcionesSKD.Modulo12.FormatoIncorrectoException(RecursosDAOModulo10.CodigoErrorFormato,
                     RecursosDAOModulo10.MensajeErrorFormato, ex);
            }
            catch (ExcepcionesSKD.ExceptionSKDConexionBD ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                throw ex;
            }
            catch (Exception ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                throw new ExcepcionesSKD.ExceptionSKD(RecursoGeneralBD.Mensaje_Generico_Error, ex);
            }
            return personas;
        }

        /// <summary>
        /// Metodo que permite obtener de base de datos todos los atletas inasistentes por planilla en un evento
        /// </summary>
        /// <param name="idEvento">id del evento</param>
        /// <returns>lista de atletas</returns>
        public List<Entidad> ListaInasistentesPlanilla(string idEvento)
        {
            Logger.EscribirInfo(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, RecursosDAOModulo10.MensajeInicioInfoLogger, System.Reflection.MethodBase.GetCurrentMethod().Name);
            List<Entidad> inscripciones = new List<Entidad>();
            DominioSKD.Fabrica.FabricaEntidades fabrica = new DominioSKD.Fabrica.FabricaEntidades();

            try
            {
                List<Parametro> parametros = new List<Parametro>();
                Parametro parametro = new Parametro(RecursosDAOModulo10.ParametroIdEvento, SqlDbType.Int, idEvento, false);
                parametros.Add(parametro);
                DataTable dt = EjecutarStoredProcedureTuplas(RecursosDAOModulo10.ProcedimientoInasistentesPlanilla, parametros);

                foreach (DataRow row in dt.Rows)
                {
                    Entidad inscripcion = DominioSKD.Fabrica.FabricaEntidades.ObtenerInscripcion();
                    ((DominioSKD.Entidades.Modulo10.Inscripcion)inscripcion).Id = int.Parse(row[RecursosDAOModulo10.aliasIdInscripcion].ToString());
                    ((DominioSKD.Entidades.Modulo10.Inscripcion)inscripcion).Fecha = DateTime.Parse(row[RecursosDAOModulo10.aliasFechaInscripcion].ToString());

                    Entidad persona = DominioSKD.Fabrica.FabricaEntidades.ObtenerPersonaM10();
                    ((DominioSKD.Entidades.Modulo10.Persona)persona).Id = int.Parse(row[RecursosDAOModulo10.aliasIdPersona].ToString());
                    ((DominioSKD.Entidades.Modulo10.Persona)persona).Nombre = row[RecursosDAOModulo10.aliasNombrePersona].ToString();
                    ((DominioSKD.Entidades.Modulo10.Persona)persona).Apellido = row[RecursosDAOModulo10.aliasApellidoPersona].ToString();
                    ((DominioSKD.Entidades.Modulo10.Inscripcion)inscripcion).Persona = persona as DominioSKD.Entidades.Modulo10.Persona;

                    Entidad solicitud = DominioSKD.Fabrica.FabricaEntidades.ObtenerSolicitudPlanilla();
                    ((DominioSKD.Entidades.Modulo14.SolicitudPlanilla)solicitud).Id = int.Parse(row[RecursosDAOModulo10.aliasIdSolicitudPlanilla].ToString());
                    Entidad planilla = DominioSKD.Fabrica.FabricaEntidades.ObtenerPlanilla();
                    ((DominioSKD.Entidades.Modulo14.Planilla)planilla).Id = int.Parse(row[RecursosDAOModulo10.aliasIdPlanilla].ToString());
                    ((DominioSKD.Entidades.Modulo14.Planilla)planilla).Nombre = row[RecursosDAOModulo10.aliasNombrePlanilla].ToString();
                    ((DominioSKD.Entidades.Modulo14.SolicitudPlanilla)solicitud).Planilla = planilla as DominioSKD.Entidades.Modulo14.Planilla;
                    ((DominioSKD.Entidades.Modulo10.Inscripcion)inscripcion).Solicitud = solicitud as DominioSKD.Entidades.Modulo14.SolicitudPlanilla;

                    inscripciones.Add(inscripcion);
                }
            }
            catch (SqlException ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                throw new ExcepcionesSKD.ExceptionSKDConexionBD(RecursoGeneralBD.Codigo,
                    RecursoGeneralBD.Mensaje, ex);
            }
            catch (FormatException ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                throw new ExcepcionesSKD.Modulo12.FormatoIncorrectoException(RecursosDAOModulo10.CodigoErrorFormato,
                     RecursosDAOModulo10.MensajeErrorFormato, ex);
            }
            catch (ExcepcionesSKD.ExceptionSKDConexionBD ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                throw ex;
            }
            catch (Exception ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                throw new ExcepcionesSKD.ExceptionSKD(RecursoGeneralBD.Mensaje_Generico_Error, ex);
            }
            return inscripciones;
        }

        /// <summary>
        /// Metodo que permite agregar la asistencia a un evento 
        /// </summary>
        /// <param name="listaEntidad">lista de asistencia</param>
        /// <returns>true si se pudo agregar</returns>
        public bool AgregarAsistenciaEvento(List<Entidad> listaEntidad)
        {
            Logger.EscribirInfo(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, RecursosDAOModulo10.MensajeInicioInfoLogger, System.Reflection.MethodBase.GetCurrentMethod().Name);
            int cont = 0;
            try
            {
                foreach (Entidad asistencia in listaEntidad)
                {
                    List<Parametro> parametros = new List<Parametro>();
                    Parametro parametro = new Parametro(RecursosDAOModulo10.ParametroIdEvento, SqlDbType.Int, ((DominioSKD.Entidades.Modulo10.Asistencia)asistencia).Evento.Id.ToString(), false);
                    parametros.Add(parametro);
                    parametro = new Parametro(RecursosDAOModulo10.ParametroIdInscripcion, SqlDbType.Int, ((DominioSKD.Entidades.Modulo10.Asistencia)asistencia).Inscripcion.Id.ToString(), false);
                    parametros.Add(parametro);
                    parametro = new Parametro(RecursosDAOModulo10.ParametroAsistencia, SqlDbType.Char, ((DominioSKD.Entidades.Modulo10.Asistencia)asistencia).Asistio, false);
                    parametros.Add(parametro);
                    EjecutarStoredProcedure(RecursosDAOModulo10.ProcedimientoAgregarAsistenciaEvento, parametros);
                    cont++;
                }

                if (listaEntidad.Count.Equals(cont))
                {
                    Logger.EscribirInfo(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, RecursosDAOModulo10.MensajeFinInfoLogger, System.Reflection.MethodBase.GetCurrentMethod().Name);
                    return true;
                }
                else
                {
                    Logger.EscribirInfo(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, RecursosDAOModulo10.MensajeFinInfoLogger, System.Reflection.MethodBase.GetCurrentMethod().Name);
                    return false;
                }

            }
            catch (SqlException ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                throw new ExcepcionesSKD.ExceptionSKDConexionBD(RecursoGeneralBD.Codigo,
                    RecursoGeneralBD.Mensaje, ex);
            }
            catch (FormatException ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                throw new ExcepcionesSKD.Modulo12.FormatoIncorrectoException(RecursosDAOModulo10.CodigoErrorFormato,
                     RecursosDAOModulo10.MensajeErrorFormato, ex);
            }
            catch (ExcepcionesSKD.ExceptionSKDConexionBD ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                throw ex;
            }
            catch (Exception ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                throw new ExcepcionesSKD.ExceptionSKD(RecursoGeneralBD.Mensaje_Generico_Error, ex);
            }
        }

        /// <summary>
        /// Metodo que permite agregar la asistencia a un evento 
        /// </summary>
        /// <param name="listaEntidad">lista de asistencia</param>
        /// <returns>true si se pudo agregar</returns>
        public bool AgregarAsistenciaCompetencia(List<Entidad> listaEntidad)
        {
            Logger.EscribirInfo(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, RecursosDAOModulo10.MensajeInicioInfoLogger, System.Reflection.MethodBase.GetCurrentMethod().Name);
            int cont = 0;
            try
            {
                foreach (Entidad asistencia in listaEntidad)
                {
                    List<Parametro> parametros = new List<Parametro>();
                    Parametro parametro = new Parametro(RecursosDAOModulo10.ParametroIdCompetencia, SqlDbType.Int, ((DominioSKD.Entidades.Modulo10.Asistencia)asistencia).Competencia.Id.ToString(), false);
                    parametros.Add(parametro);
                    parametro = new Parametro(RecursosDAOModulo10.ParametroIdInscripcion, SqlDbType.Int, ((DominioSKD.Entidades.Modulo10.Asistencia)asistencia).Inscripcion.Id.ToString(), false);
                    parametros.Add(parametro);
                    parametro = new Parametro(RecursosDAOModulo10.ParametroAsistencia, SqlDbType.Char, ((DominioSKD.Entidades.Modulo10.Asistencia)asistencia).Asistio, false);
                    parametros.Add(parametro);
                    EjecutarStoredProcedure(RecursosDAOModulo10.ProcedimientoAgregarAsistenciaCompetencia, parametros);
                    cont++;
                }

                if (listaEntidad.Count.Equals(cont))
                {
                    Logger.EscribirInfo(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, RecursosDAOModulo10.MensajeFinInfoLogger, System.Reflection.MethodBase.GetCurrentMethod().Name);
                    return true;
                }
                else
                {
                    Logger.EscribirInfo(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, RecursosDAOModulo10.MensajeFinInfoLogger, System.Reflection.MethodBase.GetCurrentMethod().Name);
                    return false;
                }

            }
            catch (SqlException ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                throw new ExcepcionesSKD.ExceptionSKDConexionBD(RecursoGeneralBD.Codigo,
                    RecursoGeneralBD.Mensaje, ex);
            }
            catch (FormatException ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                throw new ExcepcionesSKD.Modulo12.FormatoIncorrectoException(RecursosDAOModulo10.CodigoErrorFormato,
                     RecursosDAOModulo10.MensajeErrorFormato, ex);
            }
            catch (ExcepcionesSKD.ExceptionSKDConexionBD ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                throw new ExcepcionesSKD.ExceptionSKD(RecursoGeneralBD.Mensaje_Generico_Error, ex);
            }
            catch (Exception ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                throw new ExcepcionesSKD.ExceptionSKD(RecursoGeneralBD.Mensaje_Generico_Error, ex);
            }
        }

        /// <summary>
        /// Metodo que retorna todas las fechas donde hay competencias disponibles
        /// </summary>
        /// <returns>lista de horario</returns>
        public List<Entidad> ListarHorariosCompetencia()
        {
            Logger.EscribirInfo(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, RecursosDAOModulo10.MensajeInicioInfoLogger, System.Reflection.MethodBase.GetCurrentMethod().Name);
            List<Entidad> listaHorarios = new List<Entidad>();
            List<Parametro> parametros;

            try
            {
                parametros = new List<Parametro>();
                DataTable dt = EjecutarStoredProcedureTuplas(RecursosDAOModulo10.ProcedimientoFechasCompetencias, parametros);
                foreach (DataRow row in dt.Rows)
                {
                    Entidad horario = DominioSKD.Fabrica.FabricaEntidades.ObtenerHorarioM10();
                    ((DominioSKD.Entidades.Modulo10.Horario)horario).FechaInicio = DateTime.Parse(row[RecursosDAOModulo10.aliasFechaCompetencia].ToString());
                    listaHorarios.Add(horario);
                }

            }
            catch (SqlException ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                throw new ExcepcionesSKD.ExceptionSKDConexionBD(RecursoGeneralBD.Codigo,
                    RecursoGeneralBD.Mensaje, ex);
            }
            catch (FormatException ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                throw new ExcepcionesSKD.Modulo12.FormatoIncorrectoException(RecursosDAOModulo10.CodigoErrorFormato,
                     RecursosDAOModulo10.MensajeErrorFormato, ex);
            }
            catch (ExcepcionesSKD.ExceptionSKDConexionBD ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                throw ex;
            }
            catch (Exception ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                throw new ExcepcionesSKD.ExceptionSKD(RecursoGeneralBD.Mensaje_Generico_Error, ex);
            }


            return listaHorarios;
        }

        /// <summary>
        /// Metodo que dado una fecha retorna todas las competencias que existen
        /// </summary>
        /// <param name="fechaInicio">fecha inicio</param>
        /// <returns>lista de competencias</returns>
        public List<Entidad> CompetenciasPorFecha(string fechaInicio)
        {
            Logger.EscribirInfo(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, RecursosDAOModulo10.MensajeInicioInfoLogger, System.Reflection.MethodBase.GetCurrentMethod().Name);
            DominioSKD.Fabrica.FabricaEntidades fabrica = new DominioSKD.Fabrica.FabricaEntidades();
            List<Entidad> listaEventos = new List<Entidad>();
            List<Parametro> parametros = new List<Parametro>();
            Parametro parametro = new Parametro(RecursosDAOModulo10.ParametroFechaHorario, SqlDbType.DateTime, fechaInicio, false);
            parametros.Add(parametro);

            try
            {
                DataTable dt = EjecutarStoredProcedureTuplas(RecursosDAOModulo10.ProcedimientoListaCompetenciaXFecha, parametros);
                foreach (DataRow row in dt.Rows)
                {
                    Entidad competencia = FabricaEntidades.ObtenerCompetencia();
                    ((DominioSKD.Entidades.Modulo12.Competencia)competencia).Id = int.Parse(row[RecursosDAOModulo10.aliasIdCompetencia].ToString());
                    ((DominioSKD.Entidades.Modulo12.Competencia)competencia).Nombre = row[RecursosDAOModulo10.aliasNombreCompetencia].ToString();
                    ((DominioSKD.Entidades.Modulo12.Competencia)competencia).FechaInicio = DateTime.Parse(row[RecursosDAOModulo10.aliasFechaCompetencia].ToString());
                    listaEventos.Add(competencia);
                }
            }
            catch (SqlException ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                throw new ExcepcionesSKD.ExceptionSKDConexionBD(RecursoGeneralBD.Codigo,
                    RecursoGeneralBD.Mensaje, ex);
            }
            catch (FormatException ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                throw new ExcepcionesSKD.Modulo12.FormatoIncorrectoException(RecursosDAOModulo10.CodigoErrorFormato,
                     RecursosDAOModulo10.MensajeErrorFormato, ex);
            }
            catch (ExcepcionesSKD.ExceptionSKDConexionBD ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                throw ex;
            }
            catch (Exception ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                throw new ExcepcionesSKD.ExceptionSKD(RecursoGeneralBD.Mensaje_Generico_Error, ex);
            }

            return listaEventos;
        }

        /// <summary>
        /// Metodo que permite obtener de base de datos todos los atletas inscritos a una competencia especifica
        /// </summary>
        /// <param name="idCompetencia">id de la Competencia</param>
        /// <returns>lista de atletas</returns>
        public List<Entidad> ListaAtletasInscritosCompetencia(string idCompetencia)
        {
            Logger.EscribirInfo(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, RecursosDAOModulo10.MensajeInicioInfoLogger, System.Reflection.MethodBase.GetCurrentMethod().Name);
            List<Entidad> personas = new List<Entidad>();
            try
            {
                List<Parametro> parametros = new List<Parametro>();
                Parametro parametro = new Parametro(RecursosDAOModulo10.ParametroIdCompetencia, SqlDbType.Int, idCompetencia, false);
                parametros.Add(parametro);
                DataTable dt = EjecutarStoredProcedureTuplas(RecursosDAOModulo10.ProcedimientoAtletasInscritosCompetencia, parametros);

                foreach (DataRow row in dt.Rows)
                {
                    Entidad persona = DominioSKD.Fabrica.FabricaEntidades.ObtenerPersonaM10();
                    ((DominioSKD.Entidades.Modulo10.Persona)persona).Id = int.Parse(row[RecursosDAOModulo10.aliasIdPersona].ToString());
                    ((DominioSKD.Entidades.Modulo10.Persona)persona).Nombre = row[RecursosDAOModulo10.aliasNombrePersona].ToString();
                    ((DominioSKD.Entidades.Modulo10.Persona)persona).IdInscripcion = int.Parse(row[RecursosDAOModulo10.aliasIdInscripcion].ToString());
                    personas.Add(persona);
                }
            }
            catch (SqlException ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                throw new ExcepcionesSKD.ExceptionSKDConexionBD(RecursoGeneralBD.Codigo,
                    RecursoGeneralBD.Mensaje, ex);
            }
            catch (FormatException ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                throw new ExcepcionesSKD.Modulo12.FormatoIncorrectoException(RecursosDAOModulo10.CodigoErrorFormato,
                     RecursosDAOModulo10.MensajeErrorFormato, ex);
            }
            catch (ExcepcionesSKD.ExceptionSKDConexionBD ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                throw ex;
            }
            catch (Exception ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                throw new ExcepcionesSKD.ExceptionSKD(RecursoGeneralBD.Mensaje_Generico_Error, ex);
            }
            return personas;
        }

        /// <summary>
        /// Metodo que permite obtener de base de datos todos los atletas inasistentes por planilla en un evento
        /// </summary>
        /// <param name="idCompetencia">id de la competencia</param>
        /// <returns>lista de atletas</returns>
        public List<Entidad> ListaInasistentesPlanillaCompetencia(string idCompetencia)
        {
            Logger.EscribirInfo(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, RecursosDAOModulo10.MensajeInicioInfoLogger, System.Reflection.MethodBase.GetCurrentMethod().Name);
            DominioSKD.Fabrica.FabricaEntidades fabrica = new DominioSKD.Fabrica.FabricaEntidades();
            List<Entidad> inscripciones = new List<Entidad>();
            try
            {
                List<Parametro> parametros = new List<Parametro>();
                Parametro parametro = new Parametro(RecursosDAOModulo10.ParametroIdCompetencia, SqlDbType.Int, idCompetencia, false);
                parametros.Add(parametro);
                DataTable dt = EjecutarStoredProcedureTuplas(RecursosDAOModulo10.ProcedimientoInasistentesPlanillaCompetencia, parametros);

                foreach (DataRow row in dt.Rows)
                {
                    Entidad inscripcion = DominioSKD.Fabrica.FabricaEntidades.ObtenerInscripcion();
                    ((DominioSKD.Entidades.Modulo10.Inscripcion)inscripcion).Id = int.Parse(row[RecursosDAOModulo10.aliasIdInscripcion].ToString());
                    ((DominioSKD.Entidades.Modulo10.Inscripcion)inscripcion).Fecha = DateTime.Parse(row[RecursosDAOModulo10.aliasFechaInscripcion].ToString());

                    Entidad persona = DominioSKD.Fabrica.FabricaEntidades.ObtenerPersonaM10();
                    ((DominioSKD.Entidades.Modulo10.Persona)persona).Id = int.Parse(row[RecursosDAOModulo10.aliasIdPersona].ToString());
                    ((DominioSKD.Entidades.Modulo10.Persona)persona).Nombre = row[RecursosDAOModulo10.aliasNombrePersona].ToString();
                    ((DominioSKD.Entidades.Modulo10.Persona)persona).Apellido = row[RecursosDAOModulo10.aliasApellidoPersona].ToString();
                    ((DominioSKD.Entidades.Modulo10.Inscripcion)inscripcion).Persona = persona as DominioSKD.Entidades.Modulo10.Persona;

                    Entidad solicitud = DominioSKD.Fabrica.FabricaEntidades.ObtenerSolicitudPlanilla();
                    ((DominioSKD.Entidades.Modulo14.SolicitudPlanilla)solicitud).Id = int.Parse(row[RecursosDAOModulo10.aliasIdSolicitudPlanilla].ToString());
                    Entidad planilla = DominioSKD.Fabrica.FabricaEntidades.ObtenerPlanilla();
                    ((DominioSKD.Entidades.Modulo14.Planilla)planilla).Id = int.Parse(row[RecursosDAOModulo10.aliasIdPlanilla].ToString());
                    ((DominioSKD.Entidades.Modulo14.Planilla)planilla).Nombre = row[RecursosDAOModulo10.aliasNombrePlanilla].ToString();
                    ((DominioSKD.Entidades.Modulo14.SolicitudPlanilla)solicitud).Planilla = planilla as DominioSKD.Entidades.Modulo14.Planilla;
                    ((DominioSKD.Entidades.Modulo10.Inscripcion)inscripcion).Solicitud = solicitud as DominioSKD.Entidades.Modulo14.SolicitudPlanilla;
                    inscripciones.Add(inscripcion);
                }
            }
            catch (SqlException ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                throw new ExcepcionesSKD.ExceptionSKDConexionBD(RecursoGeneralBD.Codigo,
                    RecursoGeneralBD.Mensaje, ex);
            }
            catch (FormatException ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                throw new ExcepcionesSKD.Modulo12.FormatoIncorrectoException(RecursosDAOModulo10.CodigoErrorFormato,
                     RecursosDAOModulo10.MensajeErrorFormato, ex);
            }
            catch (ExcepcionesSKD.ExceptionSKDConexionBD ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                throw ex;
            }
            catch (Exception ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                throw new ExcepcionesSKD.ExceptionSKD(RecursoGeneralBD.Mensaje_Generico_Error, ex);
            }
            return inscripciones;
        }

        /// <summary>
        /// Metodo que permite obtener de base de datos una competencia por id
        /// </summary>
        /// <param name="idCompetencia">id de la competencia</param>
        /// <returns>Una Competencia</returns>
        public Entidad ConsultarCompetenciaXIdDetalle(string idCompetencia)
        {
            Logger.EscribirInfo(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, RecursosDAOModulo10.MensajeInicioInfoLogger, System.Reflection.MethodBase.GetCurrentMethod().Name);
            Entidad competencia;
            string diaFecha;
            string mesFecha;
            string anoFecha;
            string fechaInicio;
            DominioSKD.Fabrica.FabricaEntidades fabrica = new DominioSKD.Fabrica.FabricaEntidades();

            try
            {
                competencia = FabricaEntidades.ObtenerCompetencia();
                List<Parametro> parametros = new List<Parametro>();
                Parametro parametro = new Parametro(RecursosDAOModulo10.ParametroIdCompetencia, SqlDbType.Int, idCompetencia, false);
                parametros.Add(parametro);
                DataTable dt = EjecutarStoredProcedureTuplas(RecursosDAOModulo10.ProcedimientoConsultarCompetenciaDetalle, parametros);

                foreach (DataRow row in dt.Rows)
                {
                    ((DominioSKD.Entidades.Modulo12.Competencia)competencia).Id = int.Parse(row[RecursosDAOModulo10.aliasIdCompetencia].ToString());
                    ((DominioSKD.Entidades.Modulo12.Competencia)competencia).Nombre = row[RecursosDAOModulo10.aliasNombreCompetencia].ToString();
                    diaFecha = Convert.ToDateTime(row[RecursosDAOModulo10.aliasFechaCompetencia]).Day.ToString();
                    diaFecha = ModificarFechas(diaFecha);
                    mesFecha = Convert.ToDateTime(row[RecursosDAOModulo10.aliasFechaCompetencia]).Month.ToString();
                    mesFecha = ModificarFechas(mesFecha);
                    anoFecha = Convert.ToDateTime(row[RecursosDAOModulo10.aliasFechaCompetencia]).Year.ToString();
                    fechaInicio = mesFecha + RecursosDAOModulo10.SeparadorFecha + diaFecha + RecursosDAOModulo10.SeparadorFecha + anoFecha;
                    ((DominioSKD.Entidades.Modulo12.Competencia)competencia).FechaInicio = DateTime.ParseExact(fechaInicio, RecursosDAOModulo10.FormatoFecha, CultureInfo.InvariantCulture);
                    ((DominioSKD.Entidades.Modulo12.Competencia)competencia).TipoCompetencia = row[RecursosDAOModulo10.aliasEspecialidadCompetencia].ToString();
                    Entidad categoria = FabricaEntidades.ObtenerCategoria();
                    ((DominioSKD.Entidades.Modulo12.Categoria)categoria).Id = int.Parse(row[RecursosDAOModulo10.aliasIdCategoria].ToString());
                    ((DominioSKD.Entidades.Modulo12.Categoria)categoria).Cinta_inicial = row[RecursosDAOModulo10.aliasCintaInicial].ToString();
                    ((DominioSKD.Entidades.Modulo12.Categoria)categoria).Cinta_final = row[RecursosDAOModulo10.aliasCintaFinal].ToString();
                    ((DominioSKD.Entidades.Modulo12.Categoria)categoria).Edad_inicial = int.Parse(row[RecursosDAOModulo10.aliasEdadInicial].ToString());
                    ((DominioSKD.Entidades.Modulo12.Categoria)categoria).Edad_final = int.Parse(row[RecursosDAOModulo10.aliasEdadFinal].ToString());
                    ((DominioSKD.Entidades.Modulo12.Categoria)categoria).Sexo = row[RecursosDAOModulo10.aliasSexoCategoria].ToString();
                    ((DominioSKD.Entidades.Modulo12.Competencia)competencia).Categoria = categoria as DominioSKD.Entidades.Modulo12.Categoria;
                }
            }
            catch (SqlException ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                throw new ExcepcionesSKD.ExceptionSKDConexionBD(RecursoGeneralBD.Codigo,
                    RecursoGeneralBD.Mensaje, ex);
            }
            catch (FormatException ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                throw new ExcepcionesSKD.Modulo12.FormatoIncorrectoException(RecursosDAOModulo10.CodigoErrorFormato,
                     RecursosDAOModulo10.MensajeErrorFormato, ex);
            }
            catch (ExcepcionesSKD.ExceptionSKDConexionBD ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                throw ex;
            }
            catch (Exception ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                throw new ExcepcionesSKD.ExceptionSKD(RecursoGeneralBD.Mensaje_Generico_Error, ex);
            }
            return competencia;
        }

        /// <summary>
        /// Metodo que permite obtener de base de datos un evento por id
        /// </summary>
        /// <param name="idEvento">id de la competencia</param>
        /// <returns>Un Evento</returns>
        public Entidad ConsultarEventoXID(string idEvento)
        {
            Logger.EscribirInfo(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, RecursosDAOModulo10.MensajeInicioInfoLogger, System.Reflection.MethodBase.GetCurrentMethod().Name);
            Entidad evento;
            try
            {
                evento = DominioSKD.Fabrica.FabricaEntidades.ObtenerEventoM10();
                List<Parametro> parametros = new List<Parametro>();
                Parametro parametro = new Parametro(RecursosDAOModulo10.ParametroIdEvento, SqlDbType.Int, idEvento, false);
                parametros.Add(parametro);
                DataTable dt = EjecutarStoredProcedureTuplas(RecursosDAOModulo10.ProcedimientoConsultarEventoXId, parametros);

                foreach (DataRow row in dt.Rows)
                {
                    ((DominioSKD.Entidades.Modulo10.Evento)evento).Nombre = row[RecursosDAOModulo10.aliasNombreEvento].ToString(); ;
                    ((DominioSKD.Entidades.Modulo10.Evento)evento).Descripcion = row[RecursosDAOModulo10.AliasDescripcionEvento].ToString();
                    ((DominioSKD.Entidades.Modulo10.Evento)evento).Estado = Boolean.Parse(row[RecursosDAOModulo10.AliasEstadoEvento].ToString());
                    ((DominioSKD.Entidades.Modulo10.Evento)evento).Costo = float.Parse(row[RecursosDAOModulo10.AliasCostoEvento].ToString());
                    Entidad horario = DominioSKD.Fabrica.FabricaEntidades.ObtenerHorarioM10();
                    ((DominioSKD.Entidades.Modulo10.Horario)horario).FechaInicio = DateTime.Parse(row[RecursosDAOModulo10.AliasFechaInicio].ToString());
                    ((DominioSKD.Entidades.Modulo10.Horario)horario).FechaFin = DateTime.Parse(row[RecursosDAOModulo10.AliasFechaFin].ToString());
                    ((DominioSKD.Entidades.Modulo10.Horario)horario).HoraInicio = int.Parse(row[RecursosDAOModulo10.AliasHoraInicio].ToString());
                    ((DominioSKD.Entidades.Modulo10.Horario)horario).HoraFin = int.Parse(row[RecursosDAOModulo10.AliasHoraFin].ToString());
                    Entidad tipoEvento = DominioSKD.Fabrica.FabricaEntidades.ObtenerTipoEventoM10();
                    ((DominioSKD.Entidades.Modulo10.TipoEvento)tipoEvento).Nombre = row[RecursosDAOModulo10.aliasTipoEvento].ToString();
                    ((DominioSKD.Entidades.Modulo10.Evento)evento).Horario = horario as DominioSKD.Entidades.Modulo10.Horario;
                    ((DominioSKD.Entidades.Modulo10.Evento)evento).TipoEvento = tipoEvento as DominioSKD.Entidades.Modulo10.TipoEvento;
                }


            }
            catch (SqlException ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                throw new ExcepcionesSKD.ExceptionSKDConexionBD(RecursoGeneralBD.Codigo,
                    RecursoGeneralBD.Mensaje, ex);
            }
            catch (FormatException ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                throw new ExcepcionesSKD.Modulo12.FormatoIncorrectoException(RecursosDAOModulo10.CodigoErrorFormato,
                     RecursosDAOModulo10.MensajeErrorFormato, ex);
            }
            catch (ExcepcionesSKD.ExceptionSKDConexionBD ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                throw ex;
            }
            catch (Exception ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                throw new ExcepcionesSKD.ExceptionSKD(RecursoGeneralBD.Mensaje_Generico_Error, ex);
            }
            return evento;
        }

        /// <summary>
        /// Metodo que permite obtener de base de datos un evento por id
        /// </summary>
        /// <returns>Lista de Entidad tipo Horario</returns>
        public List<Entidad> TodasLasFechasEventoM10() 
        {
            Logger.EscribirInfo(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, RecursosDAOModulo10.MensajeInicioInfoLogger, System.Reflection.MethodBase.GetCurrentMethod().Name);
            List<Entidad> listaHorarios = new List<Entidad>();
            try
            {
                List<Parametro> parametros;
                parametros = new List<Parametro>();
                DataTable dt = EjecutarStoredProcedureTuplas(RecursosDAOModulo10.ProcedimientoTodasLasFechasEvento, parametros);
                foreach (DataRow row in dt.Rows)
                {
                    Entidad horario = DominioSKD.Fabrica.FabricaEntidades.ObtenerHorarioM10();
                    ((DominioSKD.Entidades.Modulo10.Horario)horario).FechaInicio = DateTime.Parse(row[RecursosDAOModulo10.AliasFechaInicio].ToString());
                    ((DominioSKD.Entidades.Modulo10.Horario)horario).FechaFin = DateTime.Parse(row[RecursosDAOModulo10.AliasFechaFin].ToString());
                    ((DominioSKD.Entidades.Modulo10.Horario)horario).HoraInicio = int.Parse(row[RecursosDAOModulo10.AliasHoraInicio].ToString());
                    ((DominioSKD.Entidades.Modulo10.Horario)horario).HoraFin = int.Parse(row[RecursosDAOModulo10.AliasHoraFin].ToString());
                    listaHorarios.Add(horario);
                }

            }
            catch (SqlException ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                throw new ExcepcionesSKD.ExceptionSKDConexionBD(RecursoGeneralBD.Codigo,
                    RecursoGeneralBD.Mensaje, ex);
            }
            catch (FormatException ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                throw new ExcepcionesSKD.Modulo12.FormatoIncorrectoException(RecursosDAOModulo10.CodigoErrorFormato,
                     RecursosDAOModulo10.MensajeErrorFormato, ex);
            }
            catch (ExcepcionesSKD.ExceptionSKDConexionBD ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                throw ex;
            }
            catch (Exception ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                throw new ExcepcionesSKD.ExceptionSKD(RecursoGeneralBD.Mensaje_Generico_Error, ex);
            }

            return listaHorarios;
        }

        public List<Entidad> EventosPorRangosdeFechaM10(string fechaInicio)
        {
            Logger.EscribirInfo(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, RecursosDAOModulo10.MensajeInicioInfoLogger, System.Reflection.MethodBase.GetCurrentMethod().Name);
            List<Entidad> listaEventos = new List<Entidad>();
            List<Parametro> parametros = new List<Parametro>();
            Parametro parametro = new Parametro(RecursosDAOModulo10.AliasFechaInicio, SqlDbType.Date, fechaInicio, false);
            parametros.Add(parametro);
            parametro = new Parametro(RecursosDAOModulo10.AliasFechaFin, SqlDbType.Date, fechaInicio, false);
            parametros.Add(parametro);

            try
            {
                DataTable dt = EjecutarStoredProcedureTuplas(RecursosDAOModulo10.ProcedimientoConsultarEventosPorFechas, parametros);
                foreach (DataRow row in dt.Rows)
                {
                    Entidad evento = DominioSKD.Fabrica.FabricaEntidades.ObtenerEventoM10();
                    ((DominioSKD.Entidades.Modulo10.Evento)evento).Id = int.Parse(row[RecursosDAOModulo10.aliasIdEvento].ToString());
                    ((DominioSKD.Entidades.Modulo10.Evento)evento).Nombre = row[RecursosDAOModulo10.aliasNombreEvento].ToString();
                    ((DominioSKD.Entidades.Modulo10.Evento)evento).Descripcion = row[RecursosDAOModulo10.AliasDescripcionEvento].ToString();
                    ((DominioSKD.Entidades.Modulo10.Evento)evento).Estado = Boolean.Parse(row[RecursosDAOModulo10.AliasEstadoEvento].ToString());
                    Entidad horario = DominioSKD.Fabrica.FabricaEntidades.ObtenerHorarioM10();
                    ((DominioSKD.Entidades.Modulo10.Horario)horario).FechaInicio = DateTime.Parse(row[RecursosDAOModulo10.AliasFechaInicio].ToString());
                    ((DominioSKD.Entidades.Modulo10.Horario)horario).FechaFin = DateTime.Parse(row[RecursosDAOModulo10.AliasFechaFin].ToString());
                    ((DominioSKD.Entidades.Modulo10.Horario)horario).HoraInicio = int.Parse(row[RecursosDAOModulo10.AliasHoraInicio].ToString());
                    ((DominioSKD.Entidades.Modulo10.Horario)horario).HoraFin = int.Parse(row[RecursosDAOModulo10.AliasHoraFin].ToString());
                    Entidad tipoEvento = DominioSKD.Fabrica.FabricaEntidades.ObtenerTipoEventoM10();
                    ((DominioSKD.Entidades.Modulo10.TipoEvento)tipoEvento).Nombre = row[RecursosDAOModulo10.aliasTipoEvento].ToString();
                    ((DominioSKD.Entidades.Modulo10.Evento)evento).Horario = horario as DominioSKD.Entidades.Modulo10.Horario;
                    ((DominioSKD.Entidades.Modulo10.Evento)evento).TipoEvento = tipoEvento as DominioSKD.Entidades.Modulo10.TipoEvento;
                    listaEventos.Add(evento);
                }

            }
            catch (SqlException ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                throw new ExcepcionesSKD.ExceptionSKDConexionBD(RecursoGeneralBD.Codigo,
                    RecursoGeneralBD.Mensaje, ex);
            }
            catch (FormatException ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                throw new ExcepcionesSKD.Modulo12.FormatoIncorrectoException(RecursosDAOModulo10.CodigoErrorFormato,
                     RecursosDAOModulo10.MensajeErrorFormato, ex);
            }
            catch (ExcepcionesSKD.ExceptionSKDConexionBD ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                throw ex;
            }
            catch (Exception ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                throw new ExcepcionesSKD.ExceptionSKD(RecursoGeneralBD.Mensaje_Generico_Error, ex);
            }

            return listaEventos;

        }
        #endregion

        #region IDAO
        public bool Agregar(List<Entidad> parametro)
        {
            throw new NotImplementedException();
        }

        public bool Modificar(List<Entidad> parametro)
        {
            throw new NotImplementedException();
        }

        public Entidad ConsultarXId(List<Entidad> parametro)
        {
            throw new NotImplementedException();
        }

        public List<Entidad> ConsultarTodos()
        {
            throw new NotImplementedException();
        }
        #endregion

        
    }
}
