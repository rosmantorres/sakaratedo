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
        public static List<Persona> listaAtletasEnCategoriaYAscenso(string idEvento, string idCategoria)
        {
            BDConexion laConexion;
            List<Persona> personas = new List<Persona>();
            try
            {
                laConexion = new BDConexion();
                List<Parametro> parametros = new List<Parametro>();
                Parametro parametro = new Parametro(RecursosBDModulo11.ParametroIdEvento, SqlDbType.Int, idEvento, false);
                parametros.Add(parametro);
                parametro = new Parametro(RecursosBDModulo11.ParametroIdCategoria, SqlDbType.Int, idCategoria, false);
                parametros.Add(parametro);
                DataTable dt = laConexion.EjecutarStoredProcedureTuplas(RecursosBDModulo11.ProcedimientoPersonasEnCategoriaAscenso, parametros);

                foreach (DataRow row in dt.Rows)
                {
                    Persona persona = new Persona();

                    persona.ID = int.Parse(row[RecursosBDModulo11.aliasIdPersona].ToString());
                    persona.Nombre = row[RecursosBDModulo11.aliasNombrePersona].ToString();
                    persona.IdInscripcion = int.Parse(row[RecursosBDModulo11.aliasIdInscripcion].ToString());
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
        /// Metodo que permite obtener de base de datos todos los atletas que participaran a un ascenso por id de evento y categoria
        /// </summary>
        /// <returns>lista de atletas</returns>
        public static List<string> listaEspecialidadesCompetencia(string idCompetencia)
        {
            BDConexion laConexion;
            List<string> especialidades = new List<string>();
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
        /// <param name="idCompetencia">id de la competencia</param>
        /// <param name="idEspecialidad">id de la especialidad</param>
        /// <returns>lista de categorias</returns>
        public static List<Categoria> listaCategoriasCompetencia(string idCompetencia, string idEspecialidad)
        {
            BDConexion laConexion;
            List<Categoria> categorias = new List<Categoria>();
            try
            {
                laConexion = new BDConexion();
                List<Parametro> parametros = new List<Parametro>();
                Parametro parametro = new Parametro(RecursosBDModulo11.ParametroIdCompetencia, SqlDbType.Int, idCompetencia, false);
                parametros.Add(parametro);
                parametro = new Parametro(RecursosBDModulo11.ParametroIdEspecialidad, SqlDbType.Int, idEspecialidad, false);
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
        /// <param name="idEspecialidad">id del evento</param>
        /// <param name="idCompetencia">id de la categoria</param>
        /// <param name="idCategoria">id de la categoria</param>
        /// <returns>lista de atletas</returns>
        public static List<Persona> listaAtletasParticipanCompetencia(string idEspecialidad, string idCompetencia, string idCategoria)
        {
            BDConexion laConexion;
            List<Persona> personas = new List<Persona>();
            try
            {
                laConexion = new BDConexion();
                List<Parametro> parametros = new List<Parametro>();
                Parametro parametro = new Parametro(RecursosBDModulo11.ParametroIdEspecialidad, SqlDbType.Int, idEspecialidad, false);
                parametros.Add(parametro);
                parametro = new Parametro(RecursosBDModulo11.ParametroIdCompetencia, SqlDbType.Int, idCompetencia, false);
                parametros.Add(parametro);
                parametro = new Parametro(RecursosBDModulo11.ParametroIdCategoria, SqlDbType.Int, idCategoria, false);
                parametros.Add(parametro);
                DataTable dt = laConexion.EjecutarStoredProcedureTuplas(RecursosBDModulo11.ProcedimientoPersonasCompitenCompetencia, parametros);

                foreach (DataRow row in dt.Rows)
                {
                    Persona persona = new Persona();

                    persona.ID = int.Parse(row[RecursosBDModulo11.aliasIdPersona].ToString());
                    persona.Nombre = row[RecursosBDModulo11.aliasNombrePersona].ToString();
                    persona.IdInscripcion = int.Parse(row[RecursosBDModulo11.aliasIdInscripcion].ToString());
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
        /// Metodo que permite modificar de base de datos un resultado de un atleta en un examen de ascenso
        /// </summary>
        /// <param name="lista">lista de asistencia</param>
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
    }
}
