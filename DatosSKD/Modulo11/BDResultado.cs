using DominioSKD;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatosSKD.Modulo11
{
    public class BDResultado
    {
        /// <summary>
        /// Metodo que permite obtener de base de datos todos los eventos con asistencia pasada
        /// </summary>
        /// <returns>lista de eventos</returns>
        public static List<Evento> ListarResultadosEventosPasados()
        {
            BDConexion laConexion;
            List<Evento> listaEventos = new List<Evento>();
            List<Parametro> parametros;

            try
            {
                laConexion = new BDConexion();
                parametros = new List<Parametro>();
                DataTable dt = laConexion.EjecutarStoredProcedureTuplas(RecursosBDModulo11.ProcedimientoConsultarResultadoPasadoE, parametros);
                foreach (DataRow row in dt.Rows)
                {
                    Evento evento = new Evento();

                    evento.Id_evento = int.Parse(row[RecursosBDModulo11.aliasIdEvento].ToString());
                    evento.Nombre = row[RecursosBDModulo11.aliasNombreEvento].ToString();
                    Horario horario = new Horario();
                    horario.FechaInicio = DateTime.Parse(row[RecursosBDModulo11.aliasFechaEvento].ToString());
                    TipoEvento tipoEvento = new TipoEvento();
                    tipoEvento.Nombre = row[RecursosBDModulo11.aliasTipoEvento].ToString();
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
                DataTable dt = laConexion.EjecutarStoredProcedureTuplas(RecursosBDModulo11.ProcedimientoConsultarResultadoPasadoC, parametros);
                foreach (DataRow row in dt.Rows)
                {
                    Competencia competencia = new Competencia();

                    competencia.Id_competencia = int.Parse(row[RecursosBDModulo11.aliasIdCompetencia].ToString());
                    competencia.Nombre = row[RecursosBDModulo11.aliasNombreCompetencia].ToString();
                    competencia.FechaInicio = DateTime.Parse(row[RecursosBDModulo11.aliasFechaCompetencia].ToString());
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
        /// Metodo que permite obtener de base de datos todas las categorias que participan en un examen de ascenso
        /// </summary>
        /// <param name="idEvento">id del evento</param>
        /// <returns>lista de categorias</returns>
        public static List<Categoria> listaCategoriasEvento(string idEvento)
        {
            BDConexion laConexion;
            List<Categoria> categorias = new List<Categoria>();
            try
            {
                laConexion = new BDConexion();
                List<Parametro> parametros = new List<Parametro>();
                Parametro parametro = new Parametro(RecursosBDModulo11.ParametroIdEvento, SqlDbType.Int, idEvento, false);
                parametros.Add(parametro);
                DataTable dt = laConexion.EjecutarStoredProcedureTuplas(RecursosBDModulo11.ProcedimientoCategoriasResultadoAscensos, parametros);

                foreach (DataRow row in dt.Rows)
                {
                    Categoria categoria = new Categoria();

                    categoria.Id_categoria = int.Parse(row[RecursosBDModulo11.aliasIdCategoria].ToString());
                    categoria.Edad_inicial = int.Parse(row[RecursosBDModulo11.aliasEdadInicial].ToString());
                    categoria.Edad_final = int.Parse(row[RecursosBDModulo11.aliasEdadFinal].ToString());
                    categoria.Cinta_inicial = row[RecursosBDModulo11.aliasCintaInicial].ToString();
                    categoria.Cinta_final = row[RecursosBDModulo11.aliasCintaFinal].ToString();
                    categoria.Sexo = row[RecursosBDModulo11.aliasSexoCategoria].ToString();
                    categorias.Add(categoria);
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
            return categorias;
        }

        /// <summary>
        /// Metodo que permite obtener de base de datos todos los atletas que participaran a un ascenso por id de evento y categoria
        /// </summary>
        /// <param name="idEvento">id del evento</param>
        /// <param name="idCategoria">id de la categoria</param>
        /// <returns>lista de atletas</returns>
        public static List<Inscripcion> listaAtletasEnCategoriaYAscenso(Evento evento)
        {
            BDConexion laConexion;
            List<Inscripcion> inscripciones = new List<Inscripcion>();
            try
            {
                laConexion = new BDConexion();
                List<Parametro> parametros = new List<Parametro>();
                Parametro parametro = new Parametro(RecursosBDModulo11.ParametroIdEvento, SqlDbType.Int, evento.Id_evento.ToString(), false);
                parametros.Add(parametro);
                parametro = new Parametro(RecursosBDModulo11.ParametroIdCategoria, SqlDbType.Int, evento.Categoria.Id_categoria.ToString(), false);
                parametros.Add(parametro);
                DataTable dt = laConexion.EjecutarStoredProcedureTuplas(RecursosBDModulo11.ProcedimientoPersonasEnCategoriaAscenso, parametros);

                foreach (DataRow row in dt.Rows)
                {
                    Inscripcion inscripcion = new Inscripcion();
                    inscripcion.Id_Inscripcion = int.Parse(row[RecursosBDModulo11.aliasIdInscripcion].ToString());
                    Persona persona = new Persona();
                    persona.ID = int.Parse(row[RecursosBDModulo11.aliasIdPersona].ToString());
                    persona.Nombre = row[RecursosBDModulo11.aliasNombrePersona].ToString();
                    persona.Apellido = row[RecursosBDModulo11.aliasApellidoPersona].ToString();
                    inscripcion.Persona = persona;
                    ResultadoAscenso resultado = new ResultadoAscenso();
                    resultado.Id_ResAscenso = int.Parse(row[RecursosBDModulo11.aliasIdResultado].ToString());
                    resultado.Aprobado = row[RecursosBDModulo11.aliasAprobado].ToString();
                    List<ResultadoAscenso> lista = new List<ResultadoAscenso>();
                    lista.Add(resultado);
                    inscripcion.ResAscenso = lista;
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
        /// Metodo que permite obtener de base de datos todos los atletas que participaran a un ascenso por id de evento y categoria
        /// </summary>
        /// <param name="evento">id del evento</param>
        /// <returns>lista de atletas</returns>
        public static List<Inscripcion> listaInscritosExamenAscenso(Evento evento)
        {
            BDConexion laConexion;
            List<Inscripcion> inscripciones = new List<Inscripcion>();
            try
            {
                laConexion = new BDConexion();
                List<Parametro> parametros = new List<Parametro>();
                Parametro parametro = new Parametro(RecursosBDModulo11.ParametroIdEvento, SqlDbType.Int, evento.Id_evento.ToString(), false);
                parametros.Add(parametro);
                parametro = new Parametro(RecursosBDModulo11.ParametroIdCategoria, SqlDbType.Int, evento.Categoria.Id_categoria.ToString(), false);
                parametros.Add(parametro);
                DataTable dt = laConexion.EjecutarStoredProcedureTuplas(RecursosBDModulo11.ProcedimientoInscritosAscensos, parametros);

                foreach (DataRow row in dt.Rows)
                {
                    Inscripcion inscripcion = new Inscripcion();
                    inscripcion.Id_Inscripcion = int.Parse(row[RecursosBDModulo11.aliasIdInscripcion].ToString());
                    Persona persona = new Persona();
                    persona.ID = int.Parse(row[RecursosBDModulo11.aliasIdPersona].ToString());
                    persona.Nombre = row[RecursosBDModulo11.aliasNombrePersona].ToString();
                    persona.Apellido = row[RecursosBDModulo11.aliasApellidoPersona].ToString();
                    inscripcion.Persona = persona;
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
        /// Metodo que permite obtener de base de datos todas las especialidades inscritas en una competencia especifica
        /// </summary>
        /// <param name="idCompetencia">id de la competencia</param>
        /// <returns>lista de especialidades</returns>
        public static List<string> listaEspecialidadesCompetencia(string idCompetencia)
        {
            BDConexion laConexion;
            List<string> especialidades = new List<string>();
            string especialidad2 = "0";
            especialidades.Add(especialidad2);
            try
            {
                laConexion = new BDConexion();
                List<Parametro> parametros = new List<Parametro>();
                Parametro parametro = new Parametro(RecursosBDModulo11.ParametroIdCompetencia, SqlDbType.Int, idCompetencia, false);
                parametros.Add(parametro);
                DataTable dt = laConexion.EjecutarStoredProcedureTuplas(RecursosBDModulo11.ProcedimientoEspecialidadesEnUnaCompetencia, parametros);

                foreach (DataRow row in dt.Rows)
                {
                    string especialidad = " ";
                    especialidad = row[RecursosBDModulo11.aliasEspecialidadCompetencia].ToString();
                    especialidades.Add(especialidad);
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
            return especialidades;
        }

        /// <summary>
        /// Metodo que permite obtener de base de datos todas las categorias que participan en una competencia 
        /// </summary>
        /// <param name="competencia">id de la competencia</param>
        /// <returns>lista de categorias</returns>
        public static List<Categoria> listaCategoriasCompetencia(Competencia competencia)
        {
            BDConexion laConexion;
            List<Categoria> categorias = new List<Categoria>();
            try
            {
                laConexion = new BDConexion();
                List<Parametro> parametros = new List<Parametro>();
                Parametro parametro = new Parametro(RecursosBDModulo11.ParametroIdCompetencia, SqlDbType.Int, competencia.Id_competencia.ToString(), false);
                parametros.Add(parametro);
                parametro = new Parametro(RecursosBDModulo11.ParametroIdEspecialidad, SqlDbType.Int, competencia.TipoCompetencia, false);
                parametros.Add(parametro);
                DataTable dt = laConexion.EjecutarStoredProcedureTuplas(RecursosBDModulo11.ProcedimientoCategoriasCompetenciaEspecialidad, parametros);

                foreach (DataRow row in dt.Rows)
                {
                    Categoria categoria = new Categoria();

                    categoria.Id_categoria = int.Parse(row[RecursosBDModulo11.aliasIdCategoria].ToString());
                    categoria.Edad_inicial = int.Parse(row[RecursosBDModulo11.aliasEdadInicial].ToString());
                    categoria.Edad_final = int.Parse(row[RecursosBDModulo11.aliasEdadFinal].ToString());
                    categoria.Cinta_inicial = row[RecursosBDModulo11.aliasCintaInicial].ToString();
                    categoria.Cinta_final = row[RecursosBDModulo11.aliasCintaFinal].ToString();
                    categoria.Sexo = row[RecursosBDModulo11.aliasSexoCategoria].ToString();
                    categorias.Add(categoria);
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
            return categorias;
        }

        /// <summary>
        /// Metodo que permite obtener de base de datos todos los atletas que participaran a una competencia por id de especialidad, competencia y categoria
        /// </summary>
        /// <param name="competencia">id de la categoria</param>
        /// <returns>lista de inscripciones</returns>
        public static List<Inscripcion> listaAtletasParticipanCompetenciaKata(Competencia competencia)
        {
            BDConexion laConexion;
            List<Inscripcion> inscripciones = new List<Inscripcion>();
            try
            {
                laConexion = new BDConexion();
                List<Parametro> parametros = new List<Parametro>();
                Parametro parametro = new Parametro(RecursosBDModulo11.ParametroIdEspecialidad, SqlDbType.Int, competencia.TipoCompetencia, false);
                parametros.Add(parametro);
                parametro = new Parametro(RecursosBDModulo11.ParametroIdCompetencia, SqlDbType.Int, competencia.Id_competencia.ToString(), false);
                parametros.Add(parametro);
                parametro = new Parametro(RecursosBDModulo11.ParametroIdCategoria, SqlDbType.Int, competencia.Categoria.Id_categoria.ToString(), false);
                parametros.Add(parametro);
                DataTable dt = laConexion.EjecutarStoredProcedureTuplas(RecursosBDModulo11.ProcedimientoPersonasCompitenCompetencia, parametros);

                foreach (DataRow row in dt.Rows)
                {
                    Inscripcion inscripcion = new Inscripcion();
                    inscripcion.Id_Inscripcion = int.Parse(row[RecursosBDModulo11.aliasIdInscripcion].ToString());
                    Persona persona = new Persona();
                    persona.ID = int.Parse(row[RecursosBDModulo11.aliasIdPersona].ToString());
                    persona.Nombre = row[RecursosBDModulo11.aliasNombrePersona].ToString();
                    persona.Apellido = row[RecursosBDModulo11.aliasApellidoPersona].ToString();
                    inscripcion.Persona = persona;

                    ResultadoKata resultadoKata = new ResultadoKata();
                    resultadoKata.Id_ResKata = int.Parse(row[RecursosBDModulo11.aliasIdResultadoKata].ToString());
                    resultadoKata.Jurado1 = int.Parse(row[RecursosBDModulo11.aliasJurado1].ToString());
                    resultadoKata.Jurado2 = int.Parse(row[RecursosBDModulo11.aliasJurado2].ToString());
                    resultadoKata.Jurado3 = int.Parse(row[RecursosBDModulo11.aliasJurado3].ToString());
                    List<ResultadoKata> resultadosKata = new List<ResultadoKata>();
                    resultadosKata.Add(resultadoKata);
                    inscripcion.ResKata = resultadosKata;
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
        /// Metodo que permite obtener de base de datos todos los atletas que participaran a una competencia por id de especialidad, competencia y categoria
        /// </summary>
        /// <param name="competencia">id de la categoria</param>
        /// <returns>lista de inscripciones</returns>
        public static List<Inscripcion> listaAtletasParticipanCompetenciaKataAmbas(Competencia competencia)
        {
            BDConexion laConexion;
            List<Inscripcion> inscripciones = new List<Inscripcion>();
            try
            {
                laConexion = new BDConexion();
                List<Parametro> parametros = new List<Parametro>();
                Parametro parametro = new Parametro(RecursosBDModulo11.ParametroIdEspecialidad, SqlDbType.Int, competencia.TipoCompetencia, false);
                parametros.Add(parametro);
                parametro = new Parametro(RecursosBDModulo11.ParametroIdCompetencia, SqlDbType.Int, competencia.Id_competencia.ToString(), false);
                parametros.Add(parametro);
                parametro = new Parametro(RecursosBDModulo11.ParametroIdCategoria, SqlDbType.Int, competencia.Categoria.Id_categoria.ToString(), false);
                parametros.Add(parametro);
                DataTable dt = laConexion.EjecutarStoredProcedureTuplas(RecursosBDModulo11.ProcedimientoPersonasCompitenCompetencia, parametros);

                foreach (DataRow row in dt.Rows)
                {
                    Inscripcion inscripcion = new Inscripcion();
                    inscripcion.Id_Inscripcion = int.Parse(row[RecursosBDModulo11.aliasIdInscripcion].ToString());
                    Persona persona = new Persona();
                    persona.ID = int.Parse(row[RecursosBDModulo11.aliasIdPersona].ToString());
                    persona.Nombre = row[RecursosBDModulo11.aliasNombrePersona].ToString();
                    persona.Apellido = row[RecursosBDModulo11.aliasApellidoPersona].ToString();
                    inscripcion.Persona = persona;

                    ResultadoKata resultadoKata = new ResultadoKata();
                    resultadoKata.Id_ResKata = int.Parse(row[RecursosBDModulo11.aliasIdResultadoKata].ToString());
                    resultadoKata.Jurado1 = int.Parse(row[RecursosBDModulo11.aliasJurado1].ToString());
                    resultadoKata.Jurado2 = int.Parse(row[RecursosBDModulo11.aliasJurado2].ToString());
                    resultadoKata.Jurado3 = int.Parse(row[RecursosBDModulo11.aliasJurado3].ToString());
                    List<ResultadoKata> resultadosKata = new List<ResultadoKata>();
                    resultadosKata.Add(resultadoKata);
                    inscripcion.ResKata = resultadosKata;
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
        /// Metodo que permite obtener de base de datos todos los atletas que participaran a una competencia por id de especialidad, competencia y categoria
        /// </summary>
        /// <param name="competencia">id de la categoria</param>
        /// <returns>lista de inscripciones</returns>
        public static List<ResultadoKumite> listaAtletasParticipanCompetenciaKumite(Competencia competencia)
        {
            BDConexion laConexion;
            List<ResultadoKumite> resultados = new List<ResultadoKumite>();
            try
            {
                laConexion = new BDConexion();
                List<Parametro> parametros = new List<Parametro>();
                Parametro parametro = new Parametro(RecursosBDModulo11.ParametroIdEspecialidad, SqlDbType.Int, competencia.TipoCompetencia, false);
                parametros.Add(parametro);
                parametro = new Parametro(RecursosBDModulo11.ParametroIdCompetencia, SqlDbType.Int, competencia.Id_competencia.ToString(), false);
                parametros.Add(parametro);
                parametro = new Parametro(RecursosBDModulo11.ParametroIdCategoria, SqlDbType.Int, competencia.Categoria.Id_categoria.ToString(), false);
                parametros.Add(parametro);
                DataTable dt = laConexion.EjecutarStoredProcedureTuplas(RecursosBDModulo11.ProcedimientoPersonasCompitenCompetencia, parametros);

                foreach (DataRow row in dt.Rows)
                {
                    ResultadoKumite resultado = new ResultadoKumite();
                    Persona persona1 = new Persona();
                    persona1.ID = int.Parse(row[RecursosBDModulo11.aliasIdPersona1].ToString());
                    persona1.Nombre = row[RecursosBDModulo11.aliasNombrePersona1].ToString();
                    persona1.Apellido = row[RecursosBDModulo11.aliasApellidoPersona1].ToString();
                    Inscripcion inscripcion1 = new Inscripcion();
                    inscripcion1.Id_Inscripcion = int.Parse(row[RecursosBDModulo11.aliasIdInscripcion1].ToString());
                    inscripcion1.Persona = persona1;
                    Persona persona2 = new Persona();
                    persona2.ID = int.Parse(row[RecursosBDModulo11.aliasIdPersona2].ToString());
                    persona2.Nombre = row[RecursosBDModulo11.aliasNombrePersona2].ToString();
                    persona2.Apellido = row[RecursosBDModulo11.aliasApellidoPersona2].ToString();
                    Inscripcion inscripcion2 = new Inscripcion();
                    inscripcion2.Id_Inscripcion = int.Parse(row[RecursosBDModulo11.aliasIdInscripcion2].ToString());
                    inscripcion2.Persona = persona2;
                    resultado.Inscripcion1 = inscripcion1;
                    resultado.Inscripcion2 = inscripcion2;
                    resultado.Id_ResKumite = int.Parse(row[RecursosBDModulo11.aliasIdResultadoKumite].ToString());
                    resultado.Puntaje1 = int.Parse(row[RecursosBDModulo11.aliasResultadoAtleta1].ToString());
                    resultado.Puntaje2 = int.Parse(row[RecursosBDModulo11.aliasResultadoAtleta2].ToString());
                    resultados.Add(resultado);
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
            return resultados;
        }

        /// <summary>
        /// Metodo que permite obtener de base de datos todos los atletas que participaran a una competencia por id de especialidad, competencia y categoria
        /// </summary>
        /// <param name="competencia">id de la categoria</param>
        /// <returns>lista de inscripciones</returns>
        public static List<ResultadoKumite> listaAtletasParticipanCompetenciaKumiteAmbas(Competencia competencia)
        {
            BDConexion laConexion;
            List<ResultadoKumite> resultados = new List<ResultadoKumite>();
            try
            {
                laConexion = new BDConexion();
                List<Parametro> parametros = new List<Parametro>();
                Parametro parametro = new Parametro(RecursosBDModulo11.ParametroIdEspecialidad, SqlDbType.Int, competencia.TipoCompetencia, false);
                parametros.Add(parametro);
                parametro = new Parametro(RecursosBDModulo11.ParametroIdCompetencia, SqlDbType.Int, competencia.Id_competencia.ToString(), false);
                parametros.Add(parametro);
                parametro = new Parametro(RecursosBDModulo11.ParametroIdCategoria, SqlDbType.Int, competencia.Categoria.Id_categoria.ToString(), false);
                parametros.Add(parametro);
                DataTable dt = laConexion.EjecutarStoredProcedureTuplas(RecursosBDModulo11.ProcedimientoPersonasCompitenCompetencia, parametros);

                foreach (DataRow row in dt.Rows)
                {
                    ResultadoKumite resultado = new ResultadoKumite();
                    Persona persona1 = new Persona();
                    persona1.ID = int.Parse(row[RecursosBDModulo11.aliasIdPersona1].ToString());
                    persona1.Nombre = row[RecursosBDModulo11.aliasNombrePersona1].ToString();
                    persona1.Apellido = row[RecursosBDModulo11.aliasApellidoPersona1].ToString();
                    Inscripcion inscripcion1 = new Inscripcion();
                    inscripcion1.Id_Inscripcion = int.Parse(row[RecursosBDModulo11.aliasIdInscripcion1].ToString());
                    inscripcion1.Persona = persona1;
                    Persona persona2 = new Persona();
                    persona2.ID = int.Parse(row[RecursosBDModulo11.aliasIdPersona2].ToString());
                    persona2.Nombre = row[RecursosBDModulo11.aliasNombrePersona2].ToString();
                    persona2.Apellido = row[RecursosBDModulo11.aliasApellidoPersona2].ToString();
                    Inscripcion inscripcion2 = new Inscripcion();
                    inscripcion2.Id_Inscripcion = int.Parse(row[RecursosBDModulo11.aliasIdInscripcion2].ToString());
                    inscripcion2.Persona = persona2;
                    resultado.Inscripcion1 = inscripcion1;
                    resultado.Inscripcion2 = inscripcion2;
                    resultado.Id_ResKumite = int.Parse(row[RecursosBDModulo11.aliasIdResultadoKumite].ToString());
                    resultado.Puntaje1 = int.Parse(row[RecursosBDModulo11.aliasResultadoAtleta1].ToString());
                    resultado.Puntaje2 = int.Parse(row[RecursosBDModulo11.aliasResultadoAtleta2].ToString());
                    resultados.Add(resultado);
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
            return resultados;
        }

        /// <summary>
        /// Metodo que permite modificar de base de datos un resultado de un atleta en un examen de ascenso
        /// </summary>
        /// <param name="lista">lista de resultado ascenso</param>
        /// <returns>true si se pudo modificar</returns>
        public static bool ModificarResultadoAscenso(List<ResultadoAscenso> lista)
        {
            int cont = 0;
            try
            {
                foreach (ResultadoAscenso ascenso in lista)
                {
                    List<Parametro> parametros = new List<Parametro>();
                    Parametro parametro = new Parametro(RecursosBDModulo11.ParametroAprobadoResultadoAscenso, SqlDbType.Char, ascenso.Aprobado, false);
                    parametros.Add(parametro);
                    parametro = new Parametro(RecursosBDModulo11.ParametroIdInscripcion, SqlDbType.Int, ascenso.Inscripcion.Id_Inscripcion.ToString(), false);
                    parametros.Add(parametro);
                    parametro = new Parametro(RecursosBDModulo11.ParametroIdEvento, SqlDbType.Int, ascenso.Inscripcion.Evento.Id_evento.ToString(), false);
                    parametros.Add(parametro);

                    BDConexion conexion = new BDConexion();
                    conexion.EjecutarStoredProcedure(RecursosBDModulo11.ProcedimientoModificarExamenAscenso, parametros);
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
        /// Metodo que permite modificar de base de datos un resultado de un atleta en una competencia de especialidad kata
        /// </summary>
        /// <param name="lista">lista de resultado kata</param>
        /// <returns>true si se pudo modificar</returns>
        public static bool ModificarResultadoKata(List<ResultadoKata> lista)
        {
            int cont = 0;
            try
            {
                foreach (ResultadoKata kata in lista)
                {
                    List<Parametro> parametros = new List<Parametro>();
                    Parametro parametro = new Parametro(RecursosBDModulo11.ParametroResultadoJurado1, SqlDbType.Int, kata.Jurado1.ToString(), false);
                    parametros.Add(parametro);
                    parametro = new Parametro(RecursosBDModulo11.ParametroResultadoJurado2, SqlDbType.Int, kata.Jurado2.ToString(), false);
                    parametros.Add(parametro);
                    parametro = new Parametro(RecursosBDModulo11.ParametroResultadoJurado3, SqlDbType.Int, kata.Jurado3.ToString(), false);
                    parametros.Add(parametro);
                    parametro = new Parametro(RecursosBDModulo11.ParametroIdInscripcion, SqlDbType.Int, kata.Inscripcion.Id_Inscripcion.ToString(), false);
                    parametros.Add(parametro);
                    parametro = new Parametro(RecursosBDModulo11.ParametroIdCompetencia, SqlDbType.Int, kata.Inscripcion.Competencia.Id_competencia.ToString(), false);
                    parametros.Add(parametro);

                    BDConexion conexion = new BDConexion();
                    conexion.EjecutarStoredProcedure(RecursosBDModulo11.ProcedimientoModificarKata, parametros);
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
        /// Metodo que permite modificar de base de datos un resultado de un atleta en una competencia de especialidad kumite
        /// </summary>
        /// <param name="lista">lista de resultado kumite</param>
        /// <returns>true si se pudo modificar</returns>
        public static bool ModificarResultadoKumite(List<ResultadoKumite> lista)
        {
            int cont = 0;
            try
            {
                foreach (ResultadoKumite kumite in lista)
                {
                    List<Parametro> parametros = new List<Parametro>();
                    Parametro parametro = new Parametro(RecursosBDModulo11.ParametroResultadoAtleta1, SqlDbType.Int, kumite.Puntaje1.ToString(), false);
                    parametros.Add(parametro);
                    parametro = new Parametro(RecursosBDModulo11.ParametroResultadoAtleta2, SqlDbType.Int, kumite.Puntaje2.ToString(), false);
                    parametros.Add(parametro);
                    parametro = new Parametro(RecursosBDModulo11.ParametroResultadoInscripcion1, SqlDbType.Int, kumite.Inscripcion1.Id_Inscripcion.ToString(), false);
                    parametros.Add(parametro);
                    parametro = new Parametro(RecursosBDModulo11.ParametroResultadoInscripcion2, SqlDbType.Int, kumite.Inscripcion2.Id_Inscripcion.ToString(), false);
                    parametros.Add(parametro);
                    parametro = new Parametro(RecursosBDModulo11.ParametroIdCompetencia, SqlDbType.Int, kumite.Inscripcion1.Competencia.Id_competencia.ToString(), false);
                    parametros.Add(parametro);

                    BDConexion conexion = new BDConexion();
                    conexion.EjecutarStoredProcedure(RecursosBDModulo11.ProcedimientoModificarKumite, parametros);
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
        /// Metodo que permite obtener de base de datos todos los atletas que participaran a una competencia por id de especialidad, competencia y categoria
        /// </summary>
        /// <param name="competencia">id de la categoria</param>
        /// <returns>lista de inscripciones</returns>
        public static List<Inscripcion> listaInscritosCompetencia(Competencia competencia)
        {
            BDConexion laConexion;
            List<Inscripcion> inscripciones = new List<Inscripcion>();
            try
            {
                laConexion = new BDConexion();
                List<Parametro> parametros = new List<Parametro>();
                Parametro parametro = new Parametro(RecursosBDModulo11.ParametroIdEspecialidad, SqlDbType.Int, competencia.TipoCompetencia, false);
                parametros.Add(parametro);
                parametro = new Parametro(RecursosBDModulo11.ParametroIdCompetencia, SqlDbType.Int, competencia.Id_competencia.ToString(), false);
                parametros.Add(parametro);
                parametro = new Parametro(RecursosBDModulo11.ParametroIdCategoria, SqlDbType.Int, competencia.Categoria.Id_categoria.ToString(), false);
                parametros.Add(parametro);
                DataTable dt = laConexion.EjecutarStoredProcedureTuplas(RecursosBDModulo11.ProcedimientoInscritosCompetencia, parametros);

                foreach (DataRow row in dt.Rows)
                {
                    Inscripcion inscripcion = new Inscripcion();
                    inscripcion.Id_Inscripcion = int.Parse(row[RecursosBDModulo11.aliasIdInscripcion].ToString());
                    Persona persona = new Persona();
                    persona.ID = int.Parse(row[RecursosBDModulo11.aliasIdPersona].ToString());
                    persona.Nombre = row[RecursosBDModulo11.aliasNombrePersona].ToString();
                    persona.Apellido = row[RecursosBDModulo11.aliasApellidoPersona].ToString();
                    inscripcion.Persona = persona;
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
        /// Metodo que permite agregar los resultados de un Evento Examen de Ascenso 
        /// </summary>
        /// <param name="lista">lista de Resultados Ascensos</param>
        /// <returns>true si se pudo agregar</returns>
        public static bool agregarResultadoAscenso(List<ResultadoAscenso> lista)
        {
            int cont = 0;
            try
            {
                foreach (ResultadoAscenso resultado in lista)
                {
                    List<Parametro> parametros = new List<Parametro>();
                    Parametro parametro = new Parametro(RecursosBDModulo11.ParametroAprobadoResultadoAscenso, SqlDbType.Char, resultado.Aprobado, false);
                    parametros.Add(parametro);
                    parametro = new Parametro(RecursosBDModulo11.ParametroIdInscripcion, SqlDbType.Int, resultado.Inscripcion.Id_Inscripcion.ToString(), false);
                    parametros.Add(parametro);
                    BDConexion conexion = new BDConexion();
                    conexion.EjecutarStoredProcedure(RecursosBDModulo11.ProcedimientoAgregarAscenso, parametros);
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
        /// Metodo que permite agregar en la base de datos un resultado de un atleta en una competencia de especialidad kata
        /// </summary>
        /// <param name="lista">lista de resultado kata</param>
        /// <returns>true si se pudo agregar</returns>
        public static bool agregarResultadoKata(List<ResultadoKata> lista)
        {
            int cont = 0;
            try
            {
                foreach (ResultadoKata kata in lista)
                {
                    List<Parametro> parametros = new List<Parametro>();
                    Parametro parametro = new Parametro(RecursosBDModulo11.ParametroResultadoJurado1, SqlDbType.Int, kata.Jurado1.ToString(), false);
                    parametros.Add(parametro);
                    parametro = new Parametro(RecursosBDModulo11.ParametroResultadoJurado2, SqlDbType.Int, kata.Jurado2.ToString(), false);
                    parametros.Add(parametro);
                    parametro = new Parametro(RecursosBDModulo11.ParametroResultadoJurado3, SqlDbType.Int, kata.Jurado3.ToString(), false);
                    parametros.Add(parametro);
                    parametro = new Parametro(RecursosBDModulo11.ParametroIdInscripcion, SqlDbType.Int, kata.Inscripcion.Id_Inscripcion.ToString(), false);
                    parametros.Add(parametro);

                    BDConexion conexion = new BDConexion();
                    conexion.EjecutarStoredProcedure(RecursosBDModulo11.ProcedimientoAgregarKata, parametros);
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
        /// Metodo que permite agregar en la base de datos un resultado de un atleta en una competencia de especialidad kumite
        /// </summary>
        /// <param name="lista">lista de resultado kumite</param>
        /// <returns>true si se pudo agregar</returns>
        public static bool agregarResultadoKumite(List<ResultadoKumite> lista)
        {
            int cont = 0;
            try
            {
                foreach (ResultadoKumite kumite in lista)
                {
                    List<Parametro> parametros = new List<Parametro>();
                    Parametro parametro = new Parametro(RecursosBDModulo11.ParametroResultadoAtleta1, SqlDbType.Int, kumite.Puntaje1.ToString(), false);
                    parametros.Add(parametro);
                    parametro = new Parametro(RecursosBDModulo11.ParametroResultadoAtleta2, SqlDbType.Int, kumite.Puntaje2.ToString(), false);
                    parametros.Add(parametro);
                    parametro = new Parametro(RecursosBDModulo11.ParametroResultadoInscripcion1, SqlDbType.Int, kumite.Inscripcion1.Id_Inscripcion.ToString(), false);
                    parametros.Add(parametro);
                    parametro = new Parametro(RecursosBDModulo11.ParametroResultadoInscripcion2, SqlDbType.Int, kumite.Inscripcion2.Id_Inscripcion.ToString(), false);
                    parametros.Add(parametro);
                    BDConexion conexion = new BDConexion();
                    conexion.EjecutarStoredProcedure(RecursosBDModulo11.ProcedimientoAgregarKumite, parametros);
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
        /// Metodo que permite Consultar un evento por id
        /// </summary>
        /// <param name="idEvento">Id del evento</param>
        /// <returns>Retorna un evento</returns>
        public static Evento ConsultarEventoDetalle(String idEvento)
        {
            BDConexion laConexion;
            Evento evento;

            try
            {
                laConexion = new BDConexion();
                evento = new Evento();
                List<Parametro> parametros = new List<Parametro>();
                Parametro parametro = new Parametro(RecursosBDModulo11.ParametroIdEvento, SqlDbType.Int, idEvento, false);
                parametros.Add(parametro);
                DataTable dt = laConexion.EjecutarStoredProcedureTuplas(RecursosBDModulo11.ProcedimientoConsultarEventoDetalle, parametros);

                foreach (DataRow row in dt.Rows)
                {
                    evento.Nombre = row[RecursosBDModulo11.aliasNombreEvento].ToString(); ;
                    evento.Descripcion = row[RecursosBDModulo11.aliasDescripcionEvento].ToString();
                    evento.Estado = Boolean.Parse(row[RecursosBDModulo11.aliasEstadoEvento].ToString());
                    evento.Costo = float.Parse(row[RecursosBDModulo11.aliasCostoEvento].ToString());
                    Horario horario = new Horario();
                    horario.FechaInicio = DateTime.Parse(row[RecursosBDModulo11.aliasFechaInicio].ToString());
                    horario.FechaFin = DateTime.Parse(row[RecursosBDModulo11.aliasFechaFin].ToString());
                    horario.HoraInicio = int.Parse(row[RecursosBDModulo11.aliasHoraInicio].ToString());
                    horario.HoraFin = int.Parse(row[RecursosBDModulo11.aliasHoraFin].ToString());
                    TipoEvento tipoEvento = new TipoEvento();
                    tipoEvento.Id = int.Parse(row[RecursosBDModulo11.aliasIdTipo].ToString());
                    tipoEvento.Nombre = row[RecursosBDModulo11.aliasTipoEvento].ToString();
                    Categoria categoria = new Categoria();
                    categoria.Id_categoria = int.Parse(row[RecursosBDModulo11.aliasIdCategoria].ToString());
                    categoria.Cinta_inicial = row[RecursosBDModulo11.aliasCintaInicial].ToString();
                    categoria.Cinta_final = row[RecursosBDModulo11.aliasCintaFinal].ToString();
                    categoria.Edad_inicial = int.Parse(row[RecursosBDModulo11.aliasEdadInicial].ToString());
                    categoria.Edad_final = int.Parse(row[RecursosBDModulo11.aliasEdadFinal].ToString());
                    categoria.Sexo = row[RecursosBDModulo11.aliasSexoCategoria].ToString();
                    evento.Horario = horario;
                    evento.TipoEvento = tipoEvento;
                    evento.Categoria = categoria;
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
                //Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);

                //throw new ExcepcionesSKD.Modulo12.FormatoIncorrectoException(RecursosBDModulo9.CodigoErrorFormato,
                //     RecursosBDModulo9.MensajeErrorFormato, ex);
                throw ex;
            }
            catch (ExcepcionesSKD.ExceptionSKDConexionBD ex)
            {
                //Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);

                throw ex;
            }
            catch (Exception ex)
            {
                //Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);

                //throw new ExcepcionesSKD.ExceptionSKD(RecursoGeneralBD.Mensaje_Generico_Error, ex);
                throw ex;
            }
            //Logger.EscribirInfo(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, RecursosBDModulo9.MensajeFinInfoLogger, System.Reflection.MethodBase.GetCurrentMethod().Name);

            return evento;
        }
    }
}
