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
    public class DaoResultadoKumite : DAOGeneral, IDaoResultadoKumite
    {
        #region IDaoResultadoKumite
        /// <summary>
        /// Metodo que permite obtener de base de datos todos los atletas que participaran a una competencia por id de especialidad, competencia y categoria
        /// </summary>
        /// <param name="entidad">id de la categoria</param>
        /// <returns>lista de inscripciones</returns>
        public List<DominioSKD.Entidad> ListaAtletasParticipanCompetenciaKumite(DominioSKD.Entidad entidad)
        {
            List<Entidad> resultados = new List<Entidad>();
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
                    Entidad resultado = DominioSKD.Fabrica.FabricaEntidades.ObtenerResultadoKumite();
                    Entidad persona1 = DominioSKD.Fabrica.FabricaEntidades.ObtenerPersonaM10();
                    ((DominioSKD.Entidades.Modulo10.Persona)persona1).Id = int.Parse(row[RecursosDAOModulo11.aliasIdPersona1].ToString());
                    ((DominioSKD.Entidades.Modulo10.Persona)persona1).Nombre = row[RecursosDAOModulo11.aliasNombrePersona1].ToString();
                    ((DominioSKD.Entidades.Modulo10.Persona)persona1).Apellido = row[RecursosDAOModulo11.aliasApellidoPersona1].ToString();
                    Entidad inscripcion1 = DominioSKD.Fabrica.FabricaEntidades.ObtenerInscripcion();
                    ((DominioSKD.Entidades.Modulo10.Inscripcion)inscripcion1).Id = int.Parse(row[RecursosDAOModulo11.aliasIdInscripcion1].ToString());
                    ((DominioSKD.Entidades.Modulo10.Inscripcion)inscripcion1).Persona = persona1 as DominioSKD.Entidades.Modulo10.Persona;
                    Entidad persona2 = DominioSKD.Fabrica.FabricaEntidades.ObtenerPersonaM10();
                    ((DominioSKD.Entidades.Modulo10.Persona)persona2).Id = int.Parse(row[RecursosDAOModulo11.aliasIdPersona2].ToString());
                    ((DominioSKD.Entidades.Modulo10.Persona)persona2).Nombre = row[RecursosDAOModulo11.aliasNombrePersona2].ToString();
                    ((DominioSKD.Entidades.Modulo10.Persona)persona2).Apellido = row[RecursosDAOModulo11.aliasApellidoPersona2].ToString();
                    Entidad inscripcion2 = DominioSKD.Fabrica.FabricaEntidades.ObtenerInscripcion();
                    ((DominioSKD.Entidades.Modulo10.Inscripcion)inscripcion2).Id = int.Parse(row[RecursosDAOModulo11.aliasIdInscripcion2].ToString());
                    ((DominioSKD.Entidades.Modulo10.Inscripcion)inscripcion2).Persona = persona2 as DominioSKD.Entidades.Modulo10.Persona;
                    ((DominioSKD.Entidades.Modulo11.ResultadoKumite)resultado).Inscripcion1 = inscripcion1 as DominioSKD.Entidades.Modulo10.Inscripcion;
                    ((DominioSKD.Entidades.Modulo11.ResultadoKumite)resultado).Inscripcion2 = inscripcion2 as DominioSKD.Entidades.Modulo10.Inscripcion;
                    ((DominioSKD.Entidades.Modulo11.ResultadoKumite)resultado).Id = int.Parse(row[RecursosDAOModulo11.aliasIdResultadoKumite].ToString());
                    ((DominioSKD.Entidades.Modulo11.ResultadoKumite)resultado).Puntaje1 = int.Parse(row[RecursosDAOModulo11.aliasResultadoAtleta1].ToString());
                    ((DominioSKD.Entidades.Modulo11.ResultadoKumite)resultado).Puntaje2 = int.Parse(row[RecursosDAOModulo11.aliasResultadoAtleta2].ToString());
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
        /// <param name="entidad">id de la categoria</param>
        /// <returns>lista de inscripciones</returns>
        public List<DominioSKD.Entidad> ListaAtletasParticipanCompetenciaKumiteAmbos(DominioSKD.Entidad entidad)
        {
            List<Entidad> resultados = new List<Entidad>();
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
                    Entidad resultado = DominioSKD.Fabrica.FabricaEntidades.ObtenerResultadoKumite();
                    Entidad persona1 = DominioSKD.Fabrica.FabricaEntidades.ObtenerPersonaM10();
                    ((DominioSKD.Entidades.Modulo10.Persona)persona1).Id = int.Parse(row[RecursosDAOModulo11.aliasIdPersona1].ToString());
                    ((DominioSKD.Entidades.Modulo10.Persona)persona1).Nombre = row[RecursosDAOModulo11.aliasNombrePersona1].ToString();
                    ((DominioSKD.Entidades.Modulo10.Persona)persona1).Apellido = row[RecursosDAOModulo11.aliasApellidoPersona1].ToString();
                    Entidad inscripcion1 = DominioSKD.Fabrica.FabricaEntidades.ObtenerInscripcion();
                    ((DominioSKD.Entidades.Modulo10.Inscripcion)inscripcion1).Id = int.Parse(row[RecursosDAOModulo11.aliasIdInscripcion1].ToString());
                    ((DominioSKD.Entidades.Modulo10.Inscripcion)inscripcion1).Persona = persona1 as DominioSKD.Entidades.Modulo10.Persona;
                    Entidad persona2 = DominioSKD.Fabrica.FabricaEntidades.ObtenerPersonaM10();
                    ((DominioSKD.Entidades.Modulo10.Persona)persona2).Id = int.Parse(row[RecursosDAOModulo11.aliasIdPersona2].ToString());
                    ((DominioSKD.Entidades.Modulo10.Persona)persona2).Nombre = row[RecursosDAOModulo11.aliasNombrePersona2].ToString();
                    ((DominioSKD.Entidades.Modulo10.Persona)persona2).Apellido = row[RecursosDAOModulo11.aliasApellidoPersona2].ToString();
                    Entidad inscripcion2 = DominioSKD.Fabrica.FabricaEntidades.ObtenerInscripcion();
                    ((DominioSKD.Entidades.Modulo10.Inscripcion)inscripcion2).Id = int.Parse(row[RecursosDAOModulo11.aliasIdInscripcion2].ToString());
                    ((DominioSKD.Entidades.Modulo10.Inscripcion)inscripcion2).Persona = persona2 as DominioSKD.Entidades.Modulo10.Persona;
                    ((DominioSKD.Entidades.Modulo11.ResultadoKumite)resultado).Inscripcion1 = inscripcion1 as DominioSKD.Entidades.Modulo10.Inscripcion;
                    ((DominioSKD.Entidades.Modulo11.ResultadoKumite)resultado).Inscripcion2 = inscripcion2 as DominioSKD.Entidades.Modulo10.Inscripcion;
                    ((DominioSKD.Entidades.Modulo11.ResultadoKumite)resultado).Id = int.Parse(row[RecursosDAOModulo11.aliasIdResultadoKumite].ToString());
                    ((DominioSKD.Entidades.Modulo11.ResultadoKumite)resultado).Puntaje1 = int.Parse(row[RecursosDAOModulo11.aliasResultadoAtleta1].ToString());
                    ((DominioSKD.Entidades.Modulo11.ResultadoKumite)resultado).Puntaje2 = int.Parse(row[RecursosDAOModulo11.aliasResultadoAtleta2].ToString());
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
        /// <param name="entidad">id de la categoria</param>
        /// <returns>lista de inscripciones</returns>
        public List<DominioSKD.Entidad> ListaInscritosCompetencia(DominioSKD.Entidad entidad)
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
                DataTable dt = EjecutarStoredProcedureTuplas(RecursosDAOModulo11.ProcedimientoInscritosCompetencia, parametros);

                foreach (DataRow row in dt.Rows)
                {
                    Entidad inscripcion = DominioSKD.Fabrica.FabricaEntidades.ObtenerInscripcion();
                    ((DominioSKD.Entidades.Modulo10.Inscripcion)inscripcion).Id = int.Parse(row[RecursosDAOModulo11.aliasIdInscripcion].ToString());
                    Entidad persona = DominioSKD.Fabrica.FabricaEntidades.ObtenerPersonaM10();
                    ((DominioSKD.Entidades.Modulo10.Persona)persona).Id = int.Parse(row[RecursosDAOModulo11.aliasIdPersona].ToString());
                    ((DominioSKD.Entidades.Modulo10.Persona)persona).Nombre = row[RecursosDAOModulo11.aliasNombrePersona].ToString();
                    ((DominioSKD.Entidades.Modulo10.Persona)persona).Apellido = row[RecursosDAOModulo11.aliasApellidoPersona].ToString();
                    ((DominioSKD.Entidades.Modulo10.Inscripcion)inscripcion).Persona = persona as DominioSKD.Entidades.Modulo10.Persona;
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

        #region IDao
        /// <summary>
        /// Metodo que permite agregar en la base de datos un resultado de un atleta en una competencia de especialidad kumite
        /// </summary>
        /// <param name="lista">lista de resultado kumite</param>
        /// <returns>true si se pudo agregar</returns>
        public bool Agregar(List<DominioSKD.Entidad> parametro)
        {
            int cont = 0;
            try
            {
                foreach (Entidad kumite in parametro)
                {
                    List<Parametro> parametros = new List<Parametro>();
                    Parametro parametro2 = new Parametro(RecursosDAOModulo11.ParametroResultadoAtleta1, SqlDbType.Int, ((DominioSKD.Entidades.Modulo11.ResultadoKumite)kumite).Puntaje1.ToString(), false);
                    parametros.Add(parametro2);
                    parametro2 = new Parametro(RecursosDAOModulo11.ParametroResultadoAtleta2, SqlDbType.Int, ((DominioSKD.Entidades.Modulo11.ResultadoKumite)kumite).Puntaje2.ToString(), false);
                    parametros.Add(parametro2);
                    parametro2 = new Parametro(RecursosDAOModulo11.ParametroResultadoInscripcion1, SqlDbType.Int, ((DominioSKD.Entidades.Modulo11.ResultadoKumite)kumite).Inscripcion1.Id.ToString(), false);
                    parametros.Add(parametro2);
                    parametro2 = new Parametro(RecursosDAOModulo11.ParametroResultadoInscripcion2, SqlDbType.Int, ((DominioSKD.Entidades.Modulo11.ResultadoKumite)kumite).Inscripcion2.Id.ToString(), false);
                    parametros.Add(parametro2);
                    EjecutarStoredProcedure(RecursosDAOModulo11.ProcedimientoAgregarKumite, parametros);
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
        /// Metodo que permite modificar de base de datos un resultado de un atleta en una competencia de especialidad kumite
        /// </summary>
        /// <param name="lista">lista de resultado kumite</param>
        /// <returns>true si se pudo modificar</returns>
        public bool Modificar(List<DominioSKD.Entidad> parametro)
        {
            int cont = 0;
            try
            {
                foreach (Entidad kumite in parametro)
                {
                    List<Parametro> parametros = new List<Parametro>();
                    Parametro parametro2 = new Parametro(RecursosDAOModulo11.ParametroResultadoAtleta1, SqlDbType.Int, ((DominioSKD.Entidades.Modulo11.ResultadoKumite)kumite).Puntaje1.ToString(), false);
                    parametros.Add(parametro2);
                    parametro2 = new Parametro(RecursosDAOModulo11.ParametroResultadoAtleta2, SqlDbType.Int, ((DominioSKD.Entidades.Modulo11.ResultadoKumite)kumite).Puntaje2.ToString(), false);
                    parametros.Add(parametro2);
                    parametro2 = new Parametro(RecursosDAOModulo11.ParametroResultadoInscripcion1, SqlDbType.Int, ((DominioSKD.Entidades.Modulo11.ResultadoKumite)kumite).Inscripcion1.Id.ToString(), false);
                    parametros.Add(parametro2);
                    parametro2 = new Parametro(RecursosDAOModulo11.ParametroResultadoInscripcion2, SqlDbType.Int, ((DominioSKD.Entidades.Modulo11.ResultadoKumite)kumite).Inscripcion2.Id.ToString(), false);
                    parametros.Add(parametro2);
                    parametro2 = new Parametro(RecursosDAOModulo11.ParametroIdCompetencia, SqlDbType.Int, ((DominioSKD.Entidades.Modulo11.ResultadoKumite)kumite).Inscripcion1.Competencia.Id.ToString(), false);
                    parametros.Add(parametro2);
                    EjecutarStoredProcedure(RecursosDAOModulo11.ProcedimientoModificarKumite, parametros);
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
