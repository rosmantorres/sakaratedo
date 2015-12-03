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
        /// <returns>true si se pudo modificar</returns>
        public static void ModificarAsistenciaE(int ins, int eve, string asistio)
        {
            try
            {
                    List<Parametro> parametros = new List<Parametro>();
                    Parametro parametro = new Parametro(RecursosBDModulo10.ParametroAsistencia, SqlDbType.Char, asistio, false);
                    parametros.Add(parametro);
                    parametro = new Parametro(RecursosBDModulo10.ParametroIdEvento, SqlDbType.Int, eve.ToString(), false);
                    parametros.Add(parametro);
                    parametro = new Parametro(RecursosBDModulo10.ParametroIdInscripcion, SqlDbType.Int, ins.ToString(), false);
                    parametros.Add(parametro);
                    
                    BDConexion conexion = new BDConexion();
                    conexion.EjecutarStoredProcedure(RecursosBDModulo10.ProcedimientoModificarAsistenciaE, parametros);
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

        public static String ModificarFechas(string fecha) 
        { 
            if (int.Parse(fecha) < 10) 
                fecha = RecursosBDModulo10.Concatenar0 + fecha.ToString(); 
            return fecha; 
        }

        /// <summary>
        /// Metodo que permite obtener de base de datos todos los atletas asistidos a un evento especifico
        /// </summary>
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
        /// <returns>lista de atletas</returns>
        public static List<Persona> listaNoAsistentesCompetencia(string idEvento)
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

    }
}
