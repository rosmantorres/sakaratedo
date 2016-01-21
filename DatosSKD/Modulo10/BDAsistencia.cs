using DominioSKD;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatosSKD.Modulo10
{
    public class BDAsistencia
    {
        /// <summary>
        /// Metodo que permite obtener de base de datos todos los eventos con asistencia pasada
        /// </summary>
        /// <returns>lista de eventos</returns>
        public static List<Evento> ListarEventosAsistidos()
        {
            BDConexion laConexion;
            List<Evento> listaEventos = new List<Evento>();
            List<Parametro> parametros;

            try
            {
                laConexion = new BDConexion();
                parametros = new List<Parametro>();
                DataTable dt = laConexion.EjecutarStoredProcedureTuplas(RecursosBDModulo10.ProcedimentoConsultarEventoAsistido, parametros);
                foreach (DataRow row in dt.Rows)
                {
                    Evento evento = new Evento();

                    evento.Id_evento = int.Parse(row[RecursosBDModulo10.aliasIdEvento].ToString());
                    evento.Nombre = row[RecursosBDModulo10.aliasNombreEvento].ToString();
                    Horario horario = new Horario();
                    horario.FechaInicio = DateTime.Parse(row[RecursosBDModulo10.aliasFechaEvento].ToString());
                    TipoEvento tipoEvento = new TipoEvento();
                    tipoEvento.Nombre = row[RecursosBDModulo10.aliasTipoEvento].ToString();
                    evento.Horario = horario;
                    evento.TipoEvento = tipoEvento;
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
        /// Metodo que permite obtener de base de datos todos los eventos con asistencia pasada
        /// </summary>
        /// <returns>lista de competencias</returns>
        public static List<Competencia> ListarCompetenciasAsistidas()
        {
            BDConexion laConexion;
            List<Competencia> listaCompetencia = new List<Competencia>();
            List<Parametro> parametros;

            try
            {
                laConexion = new BDConexion();
                parametros = new List<Parametro>();
                DataTable dt = laConexion.EjecutarStoredProcedureTuplas(RecursosBDModulo10.ProcedimentoConsultarCompetenciaAsistida, parametros);
                foreach (DataRow row in dt.Rows)
                {
                    Competencia competencia = new Competencia();

                    competencia.Id_competencia = int.Parse(row[RecursosBDModulo10.aliasIdCompetencia].ToString());
                    competencia.Nombre = row[RecursosBDModulo10.aliasNombreCompetencia].ToString();
                    competencia.FechaInicio = DateTime.Parse(row[RecursosBDModulo10.aliasFechaCompetencia].ToString());
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
        public static List<Persona> listaAsistentes(string idEvento)
        {
            BDConexion laConexion;
            List<Persona> personas = new List<Persona>();
            try
            {
                laConexion = new BDConexion();
                List<Parametro> parametros = new List<Parametro>();
                Parametro parametro = new Parametro(RecursosBDModulo10.ParametroIdEvento, SqlDbType.Int, idEvento, false);
                parametros.Add(parametro);
                DataTable dt = laConexion.EjecutarStoredProcedureTuplas(RecursosBDModulo10.ProcedimientoAtletasAsistentes, parametros);

                foreach (DataRow row in dt.Rows)
                {
                    Persona persona = new Persona();

                    persona.ID = int.Parse(row[RecursosBDModulo10.aliasIdPersona].ToString());
                    persona.Nombre = row[RecursosBDModulo10.aliasNombrePersona].ToString();
                    persona.IdInscripcion = int.Parse(row[RecursosBDModulo10.aliasIdInscripcion].ToString());
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
        public static List<Persona> listaNoAsistentes(string idEvento)
        {
            BDConexion laConexion;
            List<Persona> personas = new List<Persona>();
            try
            {
                laConexion = new BDConexion();
                List<Parametro> parametros = new List<Parametro>();
                Parametro parametro = new Parametro(RecursosBDModulo10.ParametroIdEvento, SqlDbType.Int, idEvento, false);
                parametros.Add(parametro);
                DataTable dt = laConexion.EjecutarStoredProcedureTuplas(RecursosBDModulo10.ProcedimientoAtletasInasitentes, parametros);

                foreach (DataRow row in dt.Rows)
                {
                    Persona persona = new Persona();

                    persona.ID = int.Parse(row[RecursosBDModulo10.aliasIdPersona].ToString());
                    persona.Nombre = row[RecursosBDModulo10.aliasNombrePersona].ToString();
                    persona.IdInscripcion = int.Parse(row[RecursosBDModulo10.aliasIdInscripcion].ToString());
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
        /// <param name="lista">lista de asistencia</param>
        /// <returns>true si se pudo modificar</returns>
        public static bool ModificarAsistenciaE(List<Asistencia> lista)
        {
            int cont = 0;
            try
            {
                foreach (Asistencia asistencia in lista)
                {
                    List<Parametro> parametros = new List<Parametro>();
                    Parametro parametro = new Parametro(RecursosBDModulo10.ParametroAsistencia, SqlDbType.Char, asistencia.Asistio, false);
                    parametros.Add(parametro);
                    parametro = new Parametro(RecursosBDModulo10.ParametroIdEvento, SqlDbType.Int, asistencia.Evento.Id_evento.ToString(), false);
                    parametros.Add(parametro);
                    parametro = new Parametro(RecursosBDModulo10.ParametroIdInscripcion, SqlDbType.Int, asistencia.Inscripcion.Id_Inscripcion.ToString(), false);
                    parametros.Add(parametro);

                    BDConexion conexion = new BDConexion();
                    conexion.EjecutarStoredProcedure(RecursosBDModulo10.ProcedimientoModificarAsistenciaE, parametros);
                    cont++;
                }

                if (lista.Count.Equals(cont))
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
        public static Competencia consultarCompetenciasXID(string idCompetencia)
        {
            BDConexion laConexion;
            Competencia competencia = new Competencia();
            string diaFecha;
            string mesFecha;
            string anoFecha;
            string fechaInicio;

            try
            {
                laConexion = new BDConexion();
                List<Parametro> parametros = new List<Parametro>();
                Parametro parametro = new Parametro(RecursosBDModulo10.ParametroIdCompetencia, SqlDbType.Int, idCompetencia, false);
                parametros.Add(parametro);
                DataTable dt = laConexion.EjecutarStoredProcedureTuplas(RecursosBDModulo10.ProcedimientoConsultarCompetenciaXID, parametros);

                foreach (DataRow row in dt.Rows)
                {
                    competencia.Id_competencia = int.Parse(row[RecursosBDModulo10.aliasIdCompetencia].ToString());
                    competencia.Nombre = row[RecursosBDModulo10.aliasNombreCompetencia].ToString();
                    diaFecha = Convert.ToDateTime(row[RecursosBDModulo10.aliasFechaCompetencia]).Day.ToString();
                    diaFecha = ModificarFechas(diaFecha);
                    mesFecha = Convert.ToDateTime(row[RecursosBDModulo10.aliasFechaCompetencia]).Month.ToString();
                    mesFecha = ModificarFechas(mesFecha);
                    anoFecha = Convert.ToDateTime(row[RecursosBDModulo10.aliasFechaCompetencia]).Year.ToString();
                    fechaInicio = mesFecha + RecursosBDModulo10.SeparadorFecha + diaFecha + RecursosBDModulo10.SeparadorFecha + anoFecha;
                    competencia.FechaInicio = DateTime.ParseExact(fechaInicio, RecursosBDModulo10.FormatoFecha, CultureInfo.InvariantCulture);
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
        /// Metodo que permite obtener de base de datos una competencia por id
        /// </summary>
        /// <param name="idCompetencia">id de la competencia</param>
        /// <returns>Una Competencia</returns>
        public static Competencia consultarCompetenciasXIDDetalle(string idCompetencia)
        {
            BDConexion laConexion;
            Competencia competencia = new Competencia();
            string diaFecha;
            string mesFecha;
            string anoFecha;
            string fechaInicio;

            try
            {
                laConexion = new BDConexion();
                List<Parametro> parametros = new List<Parametro>();
                Parametro parametro = new Parametro(RecursosBDModulo10.ParametroIdCompetencia, SqlDbType.Int, idCompetencia, false);
                parametros.Add(parametro);
                DataTable dt = laConexion.EjecutarStoredProcedureTuplas(RecursosBDModulo10.ProcedimientoConsultarCompetenciaDetalle, parametros);

                foreach (DataRow row in dt.Rows)
                {
                    competencia.Id_competencia = int.Parse(row[RecursosBDModulo10.aliasIdCompetencia].ToString());
                    competencia.Nombre = row[RecursosBDModulo10.aliasNombreCompetencia].ToString();
                    diaFecha = Convert.ToDateTime(row[RecursosBDModulo10.aliasFechaCompetencia]).Day.ToString();
                    diaFecha = ModificarFechas(diaFecha);
                    mesFecha = Convert.ToDateTime(row[RecursosBDModulo10.aliasFechaCompetencia]).Month.ToString();
                    mesFecha = ModificarFechas(mesFecha);
                    anoFecha = Convert.ToDateTime(row[RecursosBDModulo10.aliasFechaCompetencia]).Year.ToString();
                    fechaInicio = mesFecha + RecursosBDModulo10.SeparadorFecha + diaFecha + RecursosBDModulo10.SeparadorFecha + anoFecha;
                    competencia.FechaInicio = DateTime.ParseExact(fechaInicio, RecursosBDModulo10.FormatoFecha, CultureInfo.InvariantCulture);
                    competencia.TipoCompetencia = row[RecursosBDModulo10.aliasEspecialidadCompetencia].ToString();
                    Categoria categoria = new Categoria();
                    categoria.Id_categoria = int.Parse(row[RecursosBDModulo10.aliasIdCategoria].ToString());
                    categoria.Cinta_inicial = row[RecursosBDModulo10.aliasCintaInicial].ToString();
                    categoria.Cinta_final = row[RecursosBDModulo10.aliasCintaFinal].ToString();
                    categoria.Edad_inicial = int.Parse(row[RecursosBDModulo10.aliasEdadInicial].ToString());
                    categoria.Edad_final = int.Parse(row[RecursosBDModulo10.aliasEdadFinal].ToString());
                    categoria.Sexo = row[RecursosBDModulo10.aliasSexoCategoria].ToString();
                    competencia.Categoria = categoria;
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

        private static String ModificarFechas(string fecha)
        {
            if (int.Parse(fecha) < 10)
                fecha = RecursosBDModulo10.Concatenar0 + fecha.ToString();
            return fecha;
        }

        /// <summary>
        /// Metodo que permite obtener de base de datos todos los atletas asistidos a un evento especifico
        /// </summary>
        /// <param name="idEvento">id del evento</param>
        /// <returns>lista de atletas</returns>
        public static List<Persona> listaAsistentesCompetencia(string idEvento)
        {
            BDConexion laConexion;
            List<Persona> personas = new List<Persona>();
            try
            {
                laConexion = new BDConexion();
                List<Parametro> parametros = new List<Parametro>();
                Parametro parametro = new Parametro(RecursosBDModulo10.ParametroIdCompetencia, SqlDbType.Int, idEvento, false);
                parametros.Add(parametro);
                DataTable dt = laConexion.EjecutarStoredProcedureTuplas(RecursosBDModulo10.ProcedimientoAtletasAsistentesCompetencia, parametros);

                foreach (DataRow row in dt.Rows)
                {
                    Persona persona = new Persona();

                    persona.ID = int.Parse(row[RecursosBDModulo10.aliasIdPersona].ToString());
                    persona.Nombre = row[RecursosBDModulo10.aliasNombrePersona].ToString();
                    persona.IdInscripcion = int.Parse(row[RecursosBDModulo10.aliasIdInscripcion].ToString());
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
        public static List<Persona> listaNoAsistentesCompetencia(string idEvento)
        {
            BDConexion laConexion;
            List<Persona> personas = new List<Persona>();
            try
            {
                laConexion = new BDConexion();
                List<Parametro> parametros = new List<Parametro>();
                Parametro parametro = new Parametro(RecursosBDModulo10.ParametroIdCompetencia, SqlDbType.Int, idEvento, false);
                parametros.Add(parametro);
                DataTable dt = laConexion.EjecutarStoredProcedureTuplas(RecursosBDModulo10.ProcedimientoInasistentesCompetencia, parametros);

                foreach (DataRow row in dt.Rows)
                {
                    Persona persona = new Persona();

                    persona.ID = int.Parse(row[RecursosBDModulo10.aliasIdPersona].ToString());
                    persona.Nombre = row[RecursosBDModulo10.aliasNombrePersona].ToString();
                    persona.IdInscripcion = int.Parse(row[RecursosBDModulo10.aliasIdInscripcion].ToString());
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
        /// <param name="lista">lista de asistencia</param>
        /// <returns>true si se pudo modificar</returns>
        public static bool ModificarAsistenciaC(List<Asistencia> lista)
        {
            int cont = 0;
            try
            {
                foreach (Asistencia asistencia in lista)
                {
                    List<Parametro> parametros = new List<Parametro>();
                    Parametro parametro = new Parametro(RecursosBDModulo10.ParametroIdInscripcion, SqlDbType.Int, asistencia.Inscripcion.Id_Inscripcion.ToString(), false);
                    parametros.Add(parametro);
                    parametro = new Parametro(RecursosBDModulo10.ParametroAsistencia, SqlDbType.Char, asistencia.Asistio, false);
                    parametros.Add(parametro);
                    parametro = new Parametro(RecursosBDModulo10.ParametroIdCompetencia, SqlDbType.Int, asistencia.Competencia.Id_competencia.ToString(), false);
                    parametros.Add(parametro);

                    BDConexion conexion = new BDConexion();
                    conexion.EjecutarStoredProcedure(RecursosBDModulo10.ProcedimientoModificarAsistenciaC, parametros);
                    cont++;
                }


                if (lista.Count.Equals(cont))
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
        public static List<Persona> listaAtletasInscritosEvento(string idEvento)
        {
            BDConexion laConexion;
            List<Persona> personas = new List<Persona>();
            try
            {
                laConexion = new BDConexion();
                List<Parametro> parametros = new List<Parametro>();
                Parametro parametro = new Parametro(RecursosBDModulo10.ParametroIdEvento, SqlDbType.Int, idEvento, false);
                parametros.Add(parametro);
                DataTable dt = laConexion.EjecutarStoredProcedureTuplas(RecursosBDModulo10.ProcedimientoAtletasInscritosEvento, parametros);

                foreach (DataRow row in dt.Rows)
                {
                    Persona persona = new Persona();

                    persona.ID = int.Parse(row[RecursosBDModulo10.aliasIdPersona].ToString());
                    persona.Nombre = row[RecursosBDModulo10.aliasNombrePersona].ToString();
                    persona.IdInscripcion = int.Parse(row[RecursosBDModulo10.aliasIdInscripcion].ToString());
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
        public static List<Inscripcion> listaInasistentesPlanilla(string idEvento)
        {
            BDConexion laConexion;
            List<Inscripcion> inscripciones = new List<Inscripcion>();
            try
            {
                laConexion = new BDConexion();
                List<Parametro> parametros = new List<Parametro>();
                Parametro parametro = new Parametro(RecursosBDModulo10.ParametroIdEvento, SqlDbType.Int, idEvento, false);
                parametros.Add(parametro);
                DataTable dt = laConexion.EjecutarStoredProcedureTuplas(RecursosBDModulo10.ProcedimientoInasistentesPlanilla, parametros);

                foreach (DataRow row in dt.Rows)
                {
                    Inscripcion inscripcion = new Inscripcion();
                    inscripcion.Id_Inscripcion = int.Parse(row[RecursosBDModulo10.aliasIdInscripcion].ToString());
                    inscripcion.Fecha = DateTime.Parse(row[RecursosBDModulo10.aliasFechaInscripcion].ToString());

                    Persona persona = new Persona();
                    persona.ID = int.Parse(row[RecursosBDModulo10.aliasIdPersona].ToString());
                    persona.Nombre = row[RecursosBDModulo10.aliasNombrePersona].ToString();
                    persona.Apellido = row[RecursosBDModulo10.aliasApellidoPersona].ToString();
                    inscripcion.Persona = persona;

                    SolicitudPlanilla solicitud = new SolicitudPlanilla();
                    solicitud.ID = int.Parse(row[RecursosBDModulo10.aliasIdSolicitudPlanilla].ToString());
                    Planilla planilla = new Planilla();
                    planilla.ID = int.Parse(row[RecursosBDModulo10.aliasIdPlanilla].ToString());
                    planilla.Nombre = row[RecursosBDModulo10.aliasNombrePlanilla].ToString();
                    solicitud.Planilla = planilla;
                    inscripcion.Solicitud = solicitud;

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
        /// <param name="lista">lista de asistencia</param>
        /// <returns>true si se pudo agregar</returns>
        public static bool agregarAsistenciaEvento(List<Asistencia> lista)
        {
            int cont = 0;
            try
            {
                foreach (Asistencia asistencia in lista)
                {
                    List<Parametro> parametros = new List<Parametro>();
                    Parametro parametro = new Parametro(RecursosBDModulo10.ParametroIdEvento, SqlDbType.Int, asistencia.Evento.Id_evento.ToString(), false);
                    parametros.Add(parametro);
                    parametro = new Parametro(RecursosBDModulo10.ParametroIdInscripcion, SqlDbType.Int, asistencia.Inscripcion.Id_Inscripcion.ToString(), false);
                    parametros.Add(parametro);
                    parametro = new Parametro(RecursosBDModulo10.ParametroAsistencia, SqlDbType.Char, asistencia.Asistio, false);
                    parametros.Add(parametro);
                    BDConexion conexion = new BDConexion();
                    conexion.EjecutarStoredProcedure(RecursosBDModulo10.ProcedimientoAgregarAsistenciaEvento, parametros);
                    cont++;
                }

                if (lista.Count.Equals(cont))
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
        /// <param name="lista">lista de asistencia</param>
        /// <returns>true si se pudo agregar</returns>
        public static bool agregarAsistenciaCompetencia(List<Asistencia> lista)
        {
            int cont = 0;
            try
            {
                foreach (Asistencia asistencia in lista)
                {
                    List<Parametro> parametros = new List<Parametro>();
                    Parametro parametro = new Parametro(RecursosBDModulo10.ParametroIdCompetencia, SqlDbType.Int, asistencia.Competencia.Id_competencia.ToString(), false);
                    parametros.Add(parametro);
                    parametro = new Parametro(RecursosBDModulo10.ParametroIdInscripcion, SqlDbType.Int, asistencia.Inscripcion.Id_Inscripcion.ToString(), false);
                    parametros.Add(parametro);
                    parametro = new Parametro(RecursosBDModulo10.ParametroAsistencia, SqlDbType.Char, asistencia.Asistio, false);
                    parametros.Add(parametro);
                    BDConexion conexion = new BDConexion();
                    conexion.EjecutarStoredProcedure(RecursosBDModulo10.ProcedimientoAgregarAsistenciaCompetencia, parametros);
                    cont++;
                }

                if (lista.Count.Equals(cont))
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

        public static List<Horario> ListarHorariosCompetencias()
        {
            BDConexion laConexion;
            List<Horario> listaHorarios = new List<Horario>();
            List<Parametro> parametros;

            try
            {
                laConexion = new BDConexion();
                parametros = new List<Parametro>();
                DataTable dt = laConexion.EjecutarStoredProcedureTuplas(RecursosBDModulo10.ProcedimientoFechasCompetencias, parametros);
                foreach (DataRow row in dt.Rows)
                {
                    Horario horario = new Horario();
                    horario.FechaInicio = DateTime.Parse(row[RecursosBDModulo10.aliasFechaCompetencia].ToString());
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

        public static List<Competencia> competenciasPorFecha(String fechaInicio)
        {
            BDConexion laConexion;
            List<Competencia> listaEventos = new List<Competencia>();
            List<Parametro> parametros = new List<Parametro>();
            Parametro parametro = new Parametro(RecursosBDModulo10.ParametroFechaHorario, SqlDbType.DateTime, fechaInicio, false);
            parametros.Add(parametro);

            try
            {
                laConexion = new BDConexion();
                DataTable dt = laConexion.EjecutarStoredProcedureTuplas(RecursosBDModulo10.ProcedimientoListaCompetenciaXFecha, parametros);
                foreach (DataRow row in dt.Rows)
                {
                    Competencia competencia = new Competencia();

                    competencia.Id_competencia = int.Parse(row[RecursosBDModulo10.aliasIdCompetencia].ToString());
                    competencia.Nombre = row[RecursosBDModulo10.aliasNombreCompetencia].ToString();
                    competencia.FechaInicio = DateTime.Parse(row[RecursosBDModulo10.aliasFechaCompetencia].ToString());
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
        public static List<Persona> listaAtletasInscritosCompetencia(string idCompetencia)
        {
            BDConexion laConexion;
            List<Persona> personas = new List<Persona>();
            try
            {
                laConexion = new BDConexion();
                List<Parametro> parametros = new List<Parametro>();
                Parametro parametro = new Parametro(RecursosBDModulo10.ParametroIdCompetencia, SqlDbType.Int, idCompetencia, false);
                parametros.Add(parametro);
                DataTable dt = laConexion.EjecutarStoredProcedureTuplas(RecursosBDModulo10.ProcedimientoAtletasInscritosCompetencia, parametros);

                foreach (DataRow row in dt.Rows)
                {
                    Persona persona = new Persona();

                    persona.ID = int.Parse(row[RecursosBDModulo10.aliasIdPersona].ToString());
                    persona.Nombre = row[RecursosBDModulo10.aliasNombrePersona].ToString();
                    persona.IdInscripcion = int.Parse(row[RecursosBDModulo10.aliasIdInscripcion].ToString());
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
        public static List<Inscripcion> listaInasistentesPlanillaCompetencia(string idCompetencia)
        {
            BDConexion laConexion;
            List<Inscripcion> inscripciones = new List<Inscripcion>();
            try
            {
                laConexion = new BDConexion();
                List<Parametro> parametros = new List<Parametro>();
                Parametro parametro = new Parametro(RecursosBDModulo10.ParametroIdCompetencia, SqlDbType.Int, idCompetencia, false);
                parametros.Add(parametro);
                DataTable dt = laConexion.EjecutarStoredProcedureTuplas(RecursosBDModulo10.ProcedimientoInasistentesPlanillaCompetencia, parametros);

                foreach (DataRow row in dt.Rows)
                {
                    Inscripcion inscripcion = new Inscripcion();
                    inscripcion.Id_Inscripcion = int.Parse(row[RecursosBDModulo10.aliasIdInscripcion].ToString());
                    inscripcion.Fecha = DateTime.Parse(row[RecursosBDModulo10.aliasFechaInscripcion].ToString());

                    Persona persona = new Persona();
                    persona.ID = int.Parse(row[RecursosBDModulo10.aliasIdPersona].ToString());
                    persona.Nombre = row[RecursosBDModulo10.aliasNombrePersona].ToString();
                    persona.Apellido = row[RecursosBDModulo10.aliasApellidoPersona].ToString();
                    inscripcion.Persona = persona;

                    SolicitudPlanilla solicitud = new SolicitudPlanilla();
                    solicitud.ID = int.Parse(row[RecursosBDModulo10.aliasIdSolicitudPlanilla].ToString());
                    Planilla planilla = new Planilla();
                    planilla.ID = int.Parse(row[RecursosBDModulo10.aliasIdPlanilla].ToString());
                    planilla.Nombre = row[RecursosBDModulo10.aliasNombrePlanilla].ToString();
                    solicitud.Planilla = planilla;
                    inscripcion.Solicitud = solicitud;

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
    }
}
