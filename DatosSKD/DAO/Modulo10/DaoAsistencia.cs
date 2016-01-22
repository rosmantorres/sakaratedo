using DatosSKD.Fabrica;
using DatosSKD.InterfazDAO.Modulo10;
using DominioSKD;
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
                throw new ExcepcionesSKD.ExceptionSKDConexionBD(RecursoGeneralBD.Codigo,
                    RecursoGeneralBD.Mensaje, ex);
            }
            catch (FormatException ex)
            {
                /*throw new ExcepcionesSKD.Modulo12.FormatoIncorrectoException(RecursosBDModulo9.CodigoErrorFormato,
                     RecursosBDModulo9.MensajeErrorFormato, ex);*/
                throw ex;
            }
            catch (ExcepcionesSKD.ExceptionSKDConexionBD ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
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
            List<Entidad> listaCompetencia = new List<Entidad>();
            List<Parametro> parametros;

            try
            {
                parametros = new List<Parametro>();
                DataTable dt = EjecutarStoredProcedureTuplas(RecursosDAOModulo10.ProcedimentoConsultarCompetenciaAsistida, parametros);
                foreach (DataRow row in dt.Rows)
                {
                    DominioSKD.Fabrica.FabricaEntidades fabrica = new DominioSKD.Fabrica.FabricaEntidades();
                    Entidad competencia = fabrica.ObtenerCompetencia();
                    
                    ((DominioSKD.Entidades.Modulo12.Competencia) competencia).Id = int.Parse(row[RecursosDAOModulo10.aliasIdCompetencia].ToString());
                    ((DominioSKD.Entidades.Modulo12.Competencia) competencia).Nombre = row[RecursosDAOModulo10.aliasNombreCompetencia].ToString();
                    ((DominioSKD.Entidades.Modulo12.Competencia) competencia).FechaInicio = DateTime.Parse(row[RecursosDAOModulo10.aliasFechaCompetencia].ToString());
                    listaCompetencia.Add(competencia);
                }

            }
            catch (SqlException ex)
            {
                throw new ExcepcionesSKD.ExceptionSKDConexionBD(RecursoGeneralBD.Codigo,
                    RecursoGeneralBD.Mensaje, ex);
            }
            catch (FormatException ex)
            {
                /*throw new ExcepcionesSKD.Modulo12.FormatoIncorrectoException(RecursosBDModulo9.CodigoErrorFormato,
                     RecursosBDModulo9.MensajeErrorFormato, ex);*/
                throw ex;
            }
            catch (ExcepcionesSKD.ExceptionSKDConexionBD ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
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
                throw new ExcepcionesSKD.ExceptionSKDConexionBD(RecursoGeneralBD.Codigo,
                    RecursoGeneralBD.Mensaje, ex);
            }
            catch (FormatException ex)
            {
                //throw new ExcepcionesSKD.Modulo12.FormatoIncorrectoException(RecursosBDModulo10.CodigoErrorFormato,
                //     RecursosBDModulo10.MensajeErrorFormato, ex);
                throw ex;
            }
            catch (ExcepcionesSKD.ExceptionSKDConexionBD ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
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
                throw new ExcepcionesSKD.ExceptionSKDConexionBD(RecursoGeneralBD.Codigo,
                    RecursoGeneralBD.Mensaje, ex);
            }
            catch (FormatException ex)
            {
                //throw new ExcepcionesSKD.Modulo12.FormatoIncorrectoException(RecursosBDModulo10.CodigoErrorFormato,
                //     RecursosBDModulo10.MensajeErrorFormato, ex);
                throw ex;
            }
            catch (ExcepcionesSKD.ExceptionSKDConexionBD ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
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
                throw new ExcepcionesSKD.ExceptionSKDConexionBD(RecursoGeneralBD.Codigo,
                    RecursoGeneralBD.Mensaje, ex);
            }
            catch (FormatException ex)
            {
                //throw new ExcepcionesSKD.Modulo12.FormatoIncorrectoException(RecursosBDModulo10.CodigoErrorFormato,
                //     RecursosBDModulo10.MensajeErrorFormato, ex);
                throw ex;
            }
            catch (ExcepcionesSKD.ExceptionSKDConexionBD ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
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
                throw new ExcepcionesSKD.ExceptionSKDConexionBD(RecursoGeneralBD.Codigo,
                    RecursoGeneralBD.Mensaje, ex);
            }
            catch (FormatException ex)
            {
                //throw new ExcepcionesSKD.Modulo12.FormatoIncorrectoException(RecursosBDModulo10.CodigoErrorFormato,
                //     RecursosBDModulo10.MensajeErrorFormato, ex);
                throw ex;
            }
            catch (ExcepcionesSKD.ExceptionSKDConexionBD ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
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
                    //Logger.EscribirInfo(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, RecursosBDModulo9.MensajeFinInfoLogger, System.Reflection.MethodBase.GetCurrentMethod().Name);
                    return true;
                }
                else
                {
                    //Logger.EscribirInfo(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, RecursosBDModulo9.MensajeFinInfoLogger, System.Reflection.MethodBase.GetCurrentMethod().Name);
                    return false;
                }
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            catch (FormatException ex)
            {
                throw ex;
            }
            catch (ExcepcionesSKD.ExceptionSKDConexionBD ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Metodo que permite obtener de base de datos una competencia por id
        /// </summary>
        /// <param name="idCompetencia">id de la competencia</param>
        /// <returns>Una Competencia</returns>
        public Entidad ConsultarCompetenciasXId(string idCompetencia)
        {
            DominioSKD.Fabrica.FabricaEntidades fabrica = new DominioSKD.Fabrica.FabricaEntidades();
            Entidad competencia = fabrica.ObtenerCompetencia();
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
                throw new ExcepcionesSKD.ExceptionSKDConexionBD(RecursoGeneralBD.Codigo,
                    RecursoGeneralBD.Mensaje, ex);
            }
            catch (FormatException ex)
            {
                //throw new ExcepcionesSKD.Modulo12.FormatoIncorrectoException(RecursosBDModulo10.CodigoErrorFormato,
                //     RecursosBDModulo10.MensajeErrorFormato, ex);
                throw ex;
            }
            catch (ExcepcionesSKD.ExceptionSKDConexionBD ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
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
                    //Logger.EscribirInfo(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, RecursosBDModulo9.MensajeFinInfoLogger, System.Reflection.MethodBase.GetCurrentMethod().Name);
                    return true;
                }
                else
                {
                    //Logger.EscribirInfo(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, RecursosBDModulo9.MensajeFinInfoLogger, System.Reflection.MethodBase.GetCurrentMethod().Name);
                    return false;
                }
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            catch (FormatException ex)
            {
                throw ex;
            }
            catch (ExcepcionesSKD.ExceptionSKDConexionBD ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Metodo que permite obtener de base de datos todos los atletas inscritos a un evento especifico
        /// </summary>
        /// <param name="idEvento">id del evento</param>
        /// <returns>lista de atletas</returns>
        public List<Entidad> ListaAtletasInscritosEvento(string idEvento)
        {
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
                throw new ExcepcionesSKD.ExceptionSKDConexionBD(RecursoGeneralBD.Codigo,
                    RecursoGeneralBD.Mensaje, ex);
            }
            catch (FormatException ex)
            {
                //throw new ExcepcionesSKD.Modulo12.FormatoIncorrectoException(RecursosBDModulo10.CodigoErrorFormato,
                //     RecursosBDModulo10.MensajeErrorFormato, ex);
                throw ex;
            }
            catch (ExcepcionesSKD.ExceptionSKDConexionBD ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
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

                    Entidad solicitud = fabrica.ObtenerSolicitudPlanilla();
                    ((DominioSKD.Entidades.Modulo14.SolicitudPlanilla)solicitud).Id = int.Parse(row[RecursosDAOModulo10.aliasIdSolicitudPlanilla].ToString());
                    Entidad planilla = fabrica.ObtenerPlanilla();
                    ((DominioSKD.Entidades.Modulo14.Planilla)planilla).Id = int.Parse(row[RecursosDAOModulo10.aliasIdPlanilla].ToString());
                    ((DominioSKD.Entidades.Modulo14.Planilla)planilla).Nombre = row[RecursosDAOModulo10.aliasNombrePlanilla].ToString();
                    ((DominioSKD.Entidades.Modulo14.SolicitudPlanilla)solicitud).Planilla = planilla as DominioSKD.Entidades.Modulo14.Planilla;
                    ((DominioSKD.Entidades.Modulo10.Inscripcion)inscripcion).Solicitud = solicitud as DominioSKD.Entidades.Modulo14.SolicitudPlanilla;

                    inscripciones.Add(inscripcion);
                }
            }
            catch (SqlException ex)
            {
                throw new ExcepcionesSKD.ExceptionSKDConexionBD(RecursoGeneralBD.Codigo,
                    RecursoGeneralBD.Mensaje, ex);
            }
            catch (FormatException ex)
            {
                //throw new ExcepcionesSKD.Modulo12.FormatoIncorrectoException(RecursosBDModulo10.CodigoErrorFormato,
                //     RecursosBDModulo10.MensajeErrorFormato, ex);
                throw ex;
            }
            catch (ExcepcionesSKD.ExceptionSKDConexionBD ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
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
                    //Logger.EscribirInfo(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, RecursosBDModulo9.MensajeFinInfoLogger, System.Reflection.MethodBase.GetCurrentMethod().Name);
                    return true;
                }
                else
                {
                    //Logger.EscribirInfo(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, RecursosBDModulo9.MensajeFinInfoLogger, System.Reflection.MethodBase.GetCurrentMethod().Name);
                    return false;
                }

            }
            catch (SqlException ex)
            {
                throw ex;
            }
            catch (FormatException ex)
            {
                throw ex;
            }
            catch (ExcepcionesSKD.ExceptionSKDConexionBD ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Metodo que permite agregar la asistencia a un evento 
        /// </summary>
        /// <param name="listaEntidad">lista de asistencia</param>
        /// <returns>true si se pudo agregar</returns>
        public bool AgregarAsistenciaCompetencia(List<Entidad> listaEntidad)
        {
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
                    //Logger.EscribirInfo(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, RecursosBDModulo9.MensajeFinInfoLogger, System.Reflection.MethodBase.GetCurrentMethod().Name);
                    return true;
                }
                else
                {
                    //Logger.EscribirInfo(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, RecursosBDModulo9.MensajeFinInfoLogger, System.Reflection.MethodBase.GetCurrentMethod().Name);
                    return false;
                }

            }
            catch (SqlException ex)
            {
                throw ex;
            }
            catch (FormatException ex)
            {
                throw ex;
            }
            catch (ExcepcionesSKD.ExceptionSKDConexionBD ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Metodo que retorna todas las fechas donde hay competencias disponibles
        /// </summary>
        /// <returns>lista de horario</returns>
        public List<Entidad> ListarHorariosCompetencia()
        {
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
                //Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);

                throw new ExcepcionesSKD.ExceptionSKDConexionBD(RecursoGeneralBD.Codigo,
                    RecursoGeneralBD.Mensaje, ex);
            }
            catch (FormatException ex)
            {
                /*Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);

                throw new ExcepcionesSKD.Modulo12.FormatoIncorrectoException(RecursosBDModulo9.CodigoErrorFormato,
                     RecursosBDModulo9.MensajeErrorFormato, ex);*/
                throw ex;
            }
            catch (ExcepcionesSKD.ExceptionSKDConexionBD ex)
            {
                /*Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);

                throw ex;*/
                throw ex;
            }
            catch (Exception ex)
            {
                /*Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);

                throw new ExcepcionesSKD.ExceptionSKD(RecursoGeneralBD.Mensaje_Generico_Error, ex);*/
            }
            //Logger.EscribirInfo(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, RecursosBDModulo9.MensajeFinInfoLogger, System.Reflection.MethodBase.GetCurrentMethod().Name);


            return listaHorarios;
        }

        /// <summary>
        /// Metodo que dado una fecha retorna todas las competencias que existen
        /// </summary>
        /// <param name="fechaInicio">fecha inicio</param>
        /// <returns>lista de competencias</returns>
        public List<Entidad> CompetenciasPorFecha(string fechaInicio)
        {
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
                    Entidad competencia = fabrica.ObtenerCompetencia();
                    ((DominioSKD.Entidades.Modulo12.Competencia)competencia).Id = int.Parse(row[RecursosDAOModulo10.aliasIdCompetencia].ToString());
                    ((DominioSKD.Entidades.Modulo12.Competencia)competencia).Nombre = row[RecursosDAOModulo10.aliasNombreCompetencia].ToString();
                    ((DominioSKD.Entidades.Modulo12.Competencia)competencia).FechaInicio = DateTime.Parse(row[RecursosDAOModulo10.aliasFechaCompetencia].ToString());
                    listaEventos.Add(competencia);
                }
            }
            catch (SqlException ex)
            {
                //Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);

                throw new ExcepcionesSKD.ExceptionSKDConexionBD(RecursoGeneralBD.Codigo,
                    RecursoGeneralBD.Mensaje, ex);
            }
            catch (FormatException ex)
            {
                /*Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);

                throw new ExcepcionesSKD.Modulo12.FormatoIncorrectoException(RecursosBDModulo9.CodigoErrorFormato,
                     RecursosBDModulo9.MensajeErrorFormato, ex);*/
                throw ex;
            }
            catch (ExcepcionesSKD.ExceptionSKDConexionBD ex)
            {
                //Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);

                throw ex;
            }
            catch (Exception ex)
            {
                /*Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);

                throw new ExcepcionesSKD.ExceptionSKD(RecursoGeneralBD.Mensaje_Generico_Error, ex);*/
                throw ex;
            }
            //Logger.EscribirInfo(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, RecursosBDModulo9.MensajeFinInfoLogger, System.Reflection.MethodBase.GetCurrentMethod().Name);

            return listaEventos;
        }

        /// <summary>
        /// Metodo que permite obtener de base de datos todos los atletas inscritos a una competencia especifica
        /// </summary>
        /// <param name="idCompetencia">id de la Competencia</param>
        /// <returns>lista de atletas</returns>
        public List<Entidad> ListaAtletasInscritosCompetencia(string idCompetencia)
        {
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
                throw new ExcepcionesSKD.ExceptionSKDConexionBD(RecursoGeneralBD.Codigo,
                    RecursoGeneralBD.Mensaje, ex);
            }
            catch (FormatException ex)
            {
                //throw new ExcepcionesSKD.Modulo12.FormatoIncorrectoException(RecursosBDModulo10.CodigoErrorFormato,
                //     RecursosBDModulo10.MensajeErrorFormato, ex);
                throw ex;
            }
            catch (ExcepcionesSKD.ExceptionSKDConexionBD ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
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

                    Entidad solicitud = fabrica.ObtenerSolicitudPlanilla();
                    ((DominioSKD.Entidades.Modulo14.SolicitudPlanilla)solicitud).Id = int.Parse(row[RecursosDAOModulo10.aliasIdSolicitudPlanilla].ToString());
                    Entidad planilla = fabrica.ObtenerPlanilla();
                    ((DominioSKD.Entidades.Modulo14.Planilla)planilla).Id = int.Parse(row[RecursosDAOModulo10.aliasIdPlanilla].ToString());
                    ((DominioSKD.Entidades.Modulo14.Planilla)planilla).Nombre = row[RecursosDAOModulo10.aliasNombrePlanilla].ToString();
                    ((DominioSKD.Entidades.Modulo14.SolicitudPlanilla)solicitud).Planilla = planilla as DominioSKD.Entidades.Modulo14.Planilla;
                    ((DominioSKD.Entidades.Modulo10.Inscripcion)inscripcion).Solicitud = solicitud as DominioSKD.Entidades.Modulo14.SolicitudPlanilla;
                    inscripciones.Add(inscripcion);
                }
            }
            catch (SqlException ex)
            {
                throw new ExcepcionesSKD.ExceptionSKDConexionBD(RecursoGeneralBD.Codigo,
                    RecursoGeneralBD.Mensaje, ex);
            }
            catch (FormatException ex)
            {
                //throw new ExcepcionesSKD.Modulo12.FormatoIncorrectoException(RecursosBDModulo10.CodigoErrorFormato,
                //     RecursosBDModulo10.MensajeErrorFormato, ex);
                throw ex;
            }
            catch (ExcepcionesSKD.ExceptionSKDConexionBD ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
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
            Entidad competencia;
            string diaFecha;
            string mesFecha;
            string anoFecha;
            string fechaInicio;
            DominioSKD.Fabrica.FabricaEntidades fabrica = new DominioSKD.Fabrica.FabricaEntidades();

            try
            {
                competencia = fabrica.ObtenerCompetencia();
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
                    Entidad categoria = fabrica.ObtenerCategoria();
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
                throw new ExcepcionesSKD.ExceptionSKDConexionBD(RecursoGeneralBD.Codigo,
                    RecursoGeneralBD.Mensaje, ex);
            }
            catch (FormatException ex)
            {
                //throw new ExcepcionesSKD.Modulo12.FormatoIncorrectoException(RecursosBDModulo10.CodigoErrorFormato,
                //     RecursosBDModulo10.MensajeErrorFormato, ex);
                throw ex;
            }
            catch (ExcepcionesSKD.ExceptionSKDConexionBD ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw new ExcepcionesSKD.ExceptionSKD(RecursoGeneralBD.Mensaje_Generico_Error, ex);
            }
            return competencia;
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
