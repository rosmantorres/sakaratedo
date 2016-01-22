using DatosSKD.InterfazDAO.Modulo11;
using DominioSKD;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatosSKD.DAO.Modulo11
{
    public class DaoResultadoKata : DAOGeneral, IDaoResultadoKata
    {
        #region IDaoResultadoKata
        /// <summary>
        /// Metodo que permite obtener de base de datos todos los eventos con asistencia pasada
        /// </summary>
        /// <returns>lista de competencias</returns>
        public List<DominioSKD.Entidad> ListarCompetenciasAsistidas()
        {
            List<Entidad> listaCompetencia = new List<Entidad>();
            List<Parametro> parametros;
            DominioSKD.Fabrica.FabricaEntidades fabrica = new DominioSKD.Fabrica.FabricaEntidades();

            try
            {
                parametros = new List<Parametro>();
                DataTable dt = EjecutarStoredProcedureTuplas(RecursosDAOModulo11.ProcedimientoConsultarResultadoPasadoC, parametros);
                foreach (DataRow row in dt.Rows)
                {
                    Entidad competencia = fabrica.ObtenerCompetencia();
                    ((DominioSKD.Entidades.Modulo12.Competencia)competencia).Id = int.Parse(row[RecursosDAOModulo11.aliasIdCompetencia].ToString());
                    ((DominioSKD.Entidades.Modulo12.Competencia)competencia).Nombre = row[RecursosDAOModulo11.aliasNombreCompetencia].ToString();
                    ((DominioSKD.Entidades.Modulo12.Competencia)competencia).FechaInicio = DateTime.Parse(row[RecursosDAOModulo11.aliasFechaCompetencia].ToString());
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
        /// Metodo que permite obtener de base de datos todas las especialidades inscritas en una competencia especifica
        /// </summary>
        /// <param name="idCompetencia">id de la competencia</param>
        /// <returns>lista de especialidades</returns>
        public List<string> ListaEspecialidadesCompetencia(string idCompetencia)
        {
            List<string> especialidades = new List<string>();
            string especialidad2 = "0";
            especialidades.Add(especialidad2);
            try
            {
                List<Parametro> parametros = new List<Parametro>();
                Parametro parametro = new Parametro(RecursosDAOModulo11.ParametroIdCompetencia, SqlDbType.Int, idCompetencia, false);
                parametros.Add(parametro);
                DataTable dt = EjecutarStoredProcedureTuplas(RecursosDAOModulo11.ProcedimientoEspecialidadesEnUnaCompetencia, parametros);

                foreach (DataRow row in dt.Rows)
                {
                    string especialidad = " ";
                    especialidad = row[RecursosDAOModulo11.aliasEspecialidadCompetencia].ToString();
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
        /// <param name="entidad">id de la competencia</param>
        /// <returns>lista de categorias</returns>
        public List<DominioSKD.Entidad> ListaCategoriaCompetencia(DominioSKD.Entidad entidad)
        {
            List<Entidad> categorias = new List<Entidad>();
            DominioSKD.Fabrica.FabricaEntidades fabrica = new DominioSKD.Fabrica.FabricaEntidades();
            try
            {
                List<Parametro> parametros = new List<Parametro>();
                Parametro parametro = new Parametro(RecursosDAOModulo11.ParametroIdCompetencia, SqlDbType.Int, ((DominioSKD.Entidades.Modulo12.Competencia)entidad).Id.ToString(), false);
                parametros.Add(parametro);
                parametro = new Parametro(RecursosDAOModulo11.ParametroIdEspecialidad, SqlDbType.Int, ((DominioSKD.Entidades.Modulo12.Competencia)entidad).TipoCompetencia, false);
                parametros.Add(parametro);
                DataTable dt = EjecutarStoredProcedureTuplas(RecursosDAOModulo11.ProcedimientoCategoriasCompetenciaEspecialidad, parametros);

                foreach (DataRow row in dt.Rows)
                {
                    Entidad categoria = fabrica.ObtenerCategoria();
                    ((DominioSKD.Entidades.Modulo12.Categoria)categoria).Id = int.Parse(row[RecursosDAOModulo11.aliasIdCategoria].ToString());
                    ((DominioSKD.Entidades.Modulo12.Categoria)categoria).Edad_inicial = int.Parse(row[RecursosDAOModulo11.aliasEdadInicial].ToString());
                    ((DominioSKD.Entidades.Modulo12.Categoria)categoria).Edad_final = int.Parse(row[RecursosDAOModulo11.aliasEdadFinal].ToString());
                    ((DominioSKD.Entidades.Modulo12.Categoria)categoria).Cinta_inicial = row[RecursosDAOModulo11.aliasCintaInicial].ToString();
                    ((DominioSKD.Entidades.Modulo12.Categoria)categoria).Cinta_final = row[RecursosDAOModulo11.aliasCintaFinal].ToString();
                    ((DominioSKD.Entidades.Modulo12.Categoria)categoria).Sexo = row[RecursosDAOModulo11.aliasSexoCategoria].ToString();
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
        /// <param name="entidad">id de la categoria</param>
        /// <returns>lista de inscripciones</returns>
        public List<DominioSKD.Entidad> ListaAtletasParticipanCompetenciaKata(DominioSKD.Entidad entidad)
        {
            List<Entidad> inscripciones = new List<Entidad>();
            try
            {
                List<Parametro> parametros = new List<Parametro>();
                Parametro parametro = new Parametro(RecursosDAOModulo11.ParametroIdEspecialidad, SqlDbType.Int, ((DominioSKD.Entidades.Modulo12.Competencia)entidad).TipoCompetencia, false);
                parametros.Add(parametro);
                parametro = new Parametro(RecursosDAOModulo11.ParametroIdCompetencia, SqlDbType.Int, ((DominioSKD.Entidades.Modulo12.Competencia)entidad).Id.ToString(), false);
                parametros.Add(parametro);
                parametro = new Parametro(RecursosDAOModulo11.ParametroIdCategoria, SqlDbType.Int, ((DominioSKD.Entidades.Modulo12.Competencia)entidad).Categoria.Id.ToString(), false);
                parametros.Add(parametro);
                DataTable dt = EjecutarStoredProcedureTuplas(RecursosDAOModulo11.ProcedimientoPersonasCompitenCompetencia, parametros);

                foreach (DataRow row in dt.Rows)
                {
                    Entidad inscripcion = DominioSKD.Fabrica.FabricaEntidades.ObtenerInscripcion();
                    ((DominioSKD.Entidades.Modulo10.Inscripcion)inscripcion).Id = int.Parse(row[RecursosDAOModulo11.aliasIdInscripcion].ToString());
                    Entidad persona = DominioSKD.Fabrica.FabricaEntidades.ObtenerPersonaM10();
                    ((DominioSKD.Entidades.Modulo10.Persona)persona).Id = int.Parse(row[RecursosDAOModulo11.aliasIdPersona].ToString());
                    ((DominioSKD.Entidades.Modulo10.Persona)persona).Nombre = row[RecursosDAOModulo11.aliasNombrePersona].ToString();
                    ((DominioSKD.Entidades.Modulo10.Persona)persona).Apellido = row[RecursosDAOModulo11.aliasApellidoPersona].ToString();
                    ((DominioSKD.Entidades.Modulo10.Inscripcion)inscripcion).Persona = persona as DominioSKD.Entidades.Modulo10.Persona;

                    Entidad resultadoKata = DominioSKD.Fabrica.FabricaEntidades.ObtenerResultadoKata();
                    ((DominioSKD.Entidades.Modulo11.ResultadoKata)resultadoKata).Id = int.Parse(row[RecursosDAOModulo11.aliasIdResultadoKata].ToString());
                    ((DominioSKD.Entidades.Modulo11.ResultadoKata)resultadoKata).Jurado1 = int.Parse(row[RecursosDAOModulo11.aliasJurado1].ToString());
                    ((DominioSKD.Entidades.Modulo11.ResultadoKata)resultadoKata).Jurado2 = int.Parse(row[RecursosDAOModulo11.aliasJurado2].ToString());
                    ((DominioSKD.Entidades.Modulo11.ResultadoKata)resultadoKata).Jurado3 = int.Parse(row[RecursosDAOModulo11.aliasJurado3].ToString());
                    List<Entidad> resultadosKata = new List<Entidad>();
                    resultadosKata.Add(resultadoKata);
                    ((DominioSKD.Entidades.Modulo10.Inscripcion)inscripcion).ResKata = resultadosKata;
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
        /// <param name="entidad">id de la categoria</param>
        /// <returns>lista de inscripciones</returns>
        public List<DominioSKD.Entidad> ListaAtletasParticipanCompetenciaKataAmbos(DominioSKD.Entidad entidad)
        {
            List<Entidad> inscripciones = new List<Entidad>();
            try
            {
                List<Parametro> parametros = new List<Parametro>();
                Parametro parametro = new Parametro(RecursosDAOModulo11.ParametroIdEspecialidad, SqlDbType.Int, ((DominioSKD.Entidades.Modulo12.Competencia)entidad).TipoCompetencia, false);
                parametros.Add(parametro);
                parametro = new Parametro(RecursosDAOModulo11.ParametroIdCompetencia, SqlDbType.Int, ((DominioSKD.Entidades.Modulo12.Competencia)entidad).Id.ToString(), false);
                parametros.Add(parametro);
                parametro = new Parametro(RecursosDAOModulo11.ParametroIdCategoria, SqlDbType.Int, ((DominioSKD.Entidades.Modulo12.Competencia)entidad).Categoria.Id.ToString(), false);
                parametros.Add(parametro);
                DataTable dt = EjecutarStoredProcedureTuplas(RecursosDAOModulo11.ProcedimientoPersonasCompitenCompetencia, parametros);

                foreach (DataRow row in dt.Rows)
                {
                    Entidad inscripcion = DominioSKD.Fabrica.FabricaEntidades.ObtenerInscripcion();
                    ((DominioSKD.Entidades.Modulo10.Inscripcion)inscripcion).Id = int.Parse(row[RecursosDAOModulo11.aliasIdInscripcion].ToString());
                    Entidad persona = DominioSKD.Fabrica.FabricaEntidades.ObtenerPersonaM10();
                    ((DominioSKD.Entidades.Modulo10.Persona)persona).Id = int.Parse(row[RecursosDAOModulo11.aliasIdPersona].ToString());
                    ((DominioSKD.Entidades.Modulo10.Persona)persona).Nombre = row[RecursosDAOModulo11.aliasNombrePersona].ToString();
                    ((DominioSKD.Entidades.Modulo10.Persona)persona).Apellido = row[RecursosDAOModulo11.aliasApellidoPersona].ToString();
                    ((DominioSKD.Entidades.Modulo10.Inscripcion)inscripcion).Persona = persona as DominioSKD.Entidades.Modulo10.Persona;

                    Entidad resultadoKata = DominioSKD.Fabrica.FabricaEntidades.ObtenerResultadoKata();
                    ((DominioSKD.Entidades.Modulo11.ResultadoKata)resultadoKata).Id = int.Parse(row[RecursosDAOModulo11.aliasIdResultadoKata].ToString());
                    ((DominioSKD.Entidades.Modulo11.ResultadoKata)resultadoKata).Jurado1 = int.Parse(row[RecursosDAOModulo11.aliasJurado1].ToString());
                    ((DominioSKD.Entidades.Modulo11.ResultadoKata)resultadoKata).Jurado2 = int.Parse(row[RecursosDAOModulo11.aliasJurado2].ToString());
                    ((DominioSKD.Entidades.Modulo11.ResultadoKata)resultadoKata).Jurado3 = int.Parse(row[RecursosDAOModulo11.aliasJurado3].ToString());
                    List<Entidad> resultadosKata = new List<Entidad>();
                    resultadosKata.Add(resultadoKata);
                    ((DominioSKD.Entidades.Modulo10.Inscripcion)inscripcion).ResKata = resultadosKata;
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
        #endregion

        #region IDAO
        /// <summary>
        /// Metodo que permite agregar en la base de datos un resultado de un atleta en una competencia de especialidad kata
        /// </summary>
        /// <param name="parametro">lista de resultado kata</param>
        /// <returns>true si se pudo agregar</returns>
        public bool Agregar(List<DominioSKD.Entidad> parametro)
        {
            int cont = 0;
            try
            {
                foreach (Entidad kata in parametro)
                {
                    List<Parametro> parametros = new List<Parametro>();
                    Parametro parametro2 = new Parametro(RecursosDAOModulo11.ParametroResultadoJurado1, SqlDbType.Int, ((DominioSKD.Entidades.Modulo11.ResultadoKata)kata).Jurado1.ToString(), false);
                    parametros.Add(parametro2);
                    parametro2 = new Parametro(RecursosDAOModulo11.ParametroResultadoJurado2, SqlDbType.Int, ((DominioSKD.Entidades.Modulo11.ResultadoKata)kata).Jurado2.ToString(), false);
                    parametros.Add(parametro2);
                    parametro2 = new Parametro(RecursosDAOModulo11.ParametroResultadoJurado3, SqlDbType.Int, ((DominioSKD.Entidades.Modulo11.ResultadoKata)kata).Jurado3.ToString(), false);
                    parametros.Add(parametro2);
                    parametro2 = new Parametro(RecursosDAOModulo11.ParametroIdInscripcion, SqlDbType.Int, ((DominioSKD.Entidades.Modulo11.ResultadoKata)kata).Inscripcion.Id.ToString(), false);
                    parametros.Add(parametro2);

                    EjecutarStoredProcedure(RecursosDAOModulo11.ProcedimientoAgregarKata, parametros);
                    cont++;
                }

                if (parametro.Count.Equals(cont))
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
        /// <param name="parametro">lista de resultado kata</param>
        /// <returns>true si se pudo modificar</returns>
        public bool Modificar(List<DominioSKD.Entidad> parametro)
        {
            int cont = 0;
            try
            {
                foreach (Entidad kata in parametro)
                {
                    List<Parametro> parametros = new List<Parametro>();
                    Parametro parametro2 = new Parametro(RecursosDAOModulo11.ParametroResultadoJurado1, SqlDbType.Int, ((DominioSKD.Entidades.Modulo11.ResultadoKata)kata).Jurado1.ToString(), false);
                    parametros.Add(parametro2);
                    parametro2 = new Parametro(RecursosDAOModulo11.ParametroResultadoJurado2, SqlDbType.Int, ((DominioSKD.Entidades.Modulo11.ResultadoKata)kata).Jurado2.ToString(), false);
                    parametros.Add(parametro2);
                    parametro2 = new Parametro(RecursosDAOModulo11.ParametroResultadoJurado3, SqlDbType.Int, ((DominioSKD.Entidades.Modulo11.ResultadoKata)kata).Jurado3.ToString(), false);
                    parametros.Add(parametro2);
                    parametro2 = new Parametro(RecursosDAOModulo11.ParametroIdInscripcion, SqlDbType.Int, ((DominioSKD.Entidades.Modulo11.ResultadoKata)kata).Inscripcion.Id.ToString(), false);
                    parametros.Add(parametro2);
                    parametro2 = new Parametro(RecursosDAOModulo11.ParametroIdCompetencia, SqlDbType.Int, ((DominioSKD.Entidades.Modulo11.ResultadoKata)kata).Inscripcion.Competencia.Id.ToString(), false);
                    parametros.Add(parametro2);

                    EjecutarStoredProcedure(RecursosDAOModulo11.ProcedimientoModificarKata, parametros);
                    cont++;
                }

                if (parametro.Count.Equals(cont))
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

        public DominioSKD.Entidad ConsultarXId(List<DominioSKD.Entidad> parametro)
        {
            throw new NotImplementedException();
        }

        public List<DominioSKD.Entidad> ConsultarTodos()
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}
