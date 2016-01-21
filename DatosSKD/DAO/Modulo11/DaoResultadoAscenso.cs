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
    public class DaoResultadoAscenso : DAOGeneral, IDaoResultadoAscenso
    {
        #region IDaoResultadoAscenso
        /// <summary>
        /// Metodo que permite obtener de base de datos todos los eventos con asistencia pasada
        /// </summary>
        /// <returns>lista de eventos</returns>
        public List<DominioSKD.Entidad> ListarResultadosEventosPasados()
        {
            List<Entidad> listaEventos = new List<Entidad>();
            List<Parametro> parametros;

            try
            {
                Conectar();
                parametros = new List<Parametro>();
                DataTable dt = EjecutarStoredProcedureTuplas(RecursosDAOModulo11.ProcedimientoConsultarResultadoPasadoE, parametros);
                foreach (DataRow row in dt.Rows)
                {
                    Entidad evento = DominioSKD.Fabrica.FabricaEntidades.ObtenerEventoM10();
                    ((DominioSKD.Entidades.Modulo10.Evento)evento).Id = int.Parse(row[RecursosDAOModulo11.aliasIdEvento].ToString());
                    ((DominioSKD.Entidades.Modulo10.Evento)evento).Nombre = row[RecursosDAOModulo11.aliasNombreEvento].ToString();
                    Entidad horario = DominioSKD.Fabrica.FabricaEntidades.ObtenerHorarioM10();
                    ((DominioSKD.Entidades.Modulo10.Horario)horario).FechaInicio = DateTime.Parse(row[RecursosDAOModulo11.aliasFechaEvento].ToString());
                    Entidad tipoEvento = DominioSKD.Fabrica.FabricaEntidades.ObtenerTipoEventoM10();
                    ((DominioSKD.Entidades.Modulo10.TipoEvento)tipoEvento).Nombre = row[RecursosDAOModulo11.aliasTipoEvento].ToString();
                    ((DominioSKD.Entidades.Modulo10.Evento)evento).Horario = horario as DominioSKD.Entidades.Modulo10.Horario;
                    ((DominioSKD.Entidades.Modulo10.Evento)evento).TipoEvento = tipoEvento as DominioSKD.Entidades.Modulo10.TipoEvento;
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
            finally
            {
                Desconectar();
            }

            return listaEventos;
        }

        /// <summary>
        /// Metodo que permite obtener de base de datos todas las categorias que participan en un examen de ascenso
        /// </summary>
        /// <param name="idEvento">id del evento</param>
        /// <returns>lista de categorias</returns>
        public List<DominioSKD.Entidad> ListaCategoriaEvento(string idEvento)
        {
            List<Entidad> categorias = new List<Entidad>();
            DominioSKD.Fabrica.FabricaEntidades fabrica = new DominioSKD.Fabrica.FabricaEntidades();
            try
            {
                Conectar();
                List<Parametro> parametros = new List<Parametro>();
                Parametro parametro = new Parametro(RecursosDAOModulo11.ParametroIdEvento, SqlDbType.Int, idEvento, false);
                parametros.Add(parametro);
                DataTable dt = EjecutarStoredProcedureTuplas(RecursosDAOModulo11.ProcedimientoCategoriasResultadoAscensos, parametros);

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
            finally
            {
                Desconectar();
            }
            return categorias;
        }

        /// <summary>
        /// Metodo que permite obtener de base de datos todos los atletas que participaran a un ascenso por id de evento y categoria
        /// </summary>
        /// <param name="entidad">id de la categoria</param>
        /// <returns>lista de atletas</returns>
        public List<DominioSKD.Entidad> ListaAtletasEnCategoriaYAscenso(DominioSKD.Entidad entidad)
        {
            List<Entidad> inscripciones = new List<Entidad>();
            try
            {
                Conectar();
                List<Parametro> parametros = new List<Parametro>();
                Parametro parametro = new Parametro(RecursosDAOModulo11.ParametroIdEvento, SqlDbType.Int, ((DominioSKD.Entidades.Modulo9.Evento)entidad).Id.ToString(), false);
                parametros.Add(parametro);
                parametro = new Parametro(RecursosDAOModulo11.ParametroIdCategoria, SqlDbType.Int, ((DominioSKD.Entidades.Modulo9.Evento)entidad).Categoria.Id.ToString(), false);
                parametros.Add(parametro);
                DataTable dt = EjecutarStoredProcedureTuplas(RecursosDAOModulo11.ProcedimientoPersonasEnCategoriaAscenso, parametros);

                foreach (DataRow row in dt.Rows)
                {
                    Entidad inscripcion = DominioSKD.Fabrica.FabricaEntidades.ObtenerInscripcion();
                    ((DominioSKD.Entidades.Modulo10.Inscripcion)inscripcion).Id = int.Parse(row[RecursosDAOModulo11.aliasIdInscripcion].ToString());
                    Entidad persona = DominioSKD.Fabrica.FabricaEntidades.ObtenerPersonaM10();
                    ((DominioSKD.Entidades.Modulo10.Persona)persona).Id = int.Parse(row[RecursosDAOModulo11.aliasIdPersona].ToString());
                    ((DominioSKD.Entidades.Modulo10.Persona)persona).Nombre = row[RecursosDAOModulo11.aliasNombrePersona].ToString();
                    ((DominioSKD.Entidades.Modulo10.Persona)persona).Apellido = row[RecursosDAOModulo11.aliasApellidoPersona].ToString();
                    ((DominioSKD.Entidades.Modulo10.Inscripcion)inscripcion).Persona = persona as DominioSKD.Entidades.Modulo10.Persona;
                    Entidad resultado = DominioSKD.Fabrica.FabricaEntidades.ObtenerResultadoAscenso();
                    ((DominioSKD.Entidades.Modulo11.ResultadoAscenso)resultado).Id = int.Parse(row[RecursosDAOModulo11.aliasIdResultado].ToString());
                    ((DominioSKD.Entidades.Modulo11.ResultadoAscenso)resultado).Aprobado = row[RecursosDAOModulo11.aliasAprobado].ToString();
                    List<Entidad> lista = new List<Entidad>();
                    lista.Add(resultado);
                    ((DominioSKD.Entidades.Modulo10.Inscripcion)inscripcion).ResAscenso = lista;
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
            finally
            {
                Desconectar();
            }
            return inscripciones;
        }

        /// <summary>
        /// Metodo que permite obtener de base de datos todos los atletas que participaran a un ascenso por id de evento y categoria
        /// </summary>
        /// <param name="entidad">id del evento</param>
        /// <returns>lista de atletas</returns>
        public List<DominioSKD.Entidad> ListaInscritosExamenAscenso(DominioSKD.Entidad entidad)
        {
            List<Entidad> inscripciones = new List<Entidad>();
            try
            {
                Conectar();
                List<Parametro> parametros = new List<Parametro>();
                Parametro parametro = new Parametro(RecursosDAOModulo11.ParametroIdEvento, SqlDbType.Int, ((DominioSKD.Entidades.Modulo9.Evento)entidad).Id.ToString(), false);
                parametros.Add(parametro);
                parametro = new Parametro(RecursosDAOModulo11.ParametroIdCategoria, SqlDbType.Int, ((DominioSKD.Entidades.Modulo9.Evento)entidad).Categoria.Id.ToString(), false);
                parametros.Add(parametro);
                DataTable dt = EjecutarStoredProcedureTuplas(RecursosDAOModulo11.ProcedimientoInscritosAscensos, parametros);

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
            finally
            {
                Desconectar();
            }
            return inscripciones;
        }

        /// <summary>
        /// Metodo que permite Consultar un evento por id
        /// </summary>
        /// <param name="idEvento">Id del evento</param>
        /// <returns>Retorna un evento</returns>
        public DominioSKD.Entidad ConsultarEventoDetalle(string idEvento)
        {
            Entidad evento;
            DominioSKD.Fabrica.FabricaEntidades fabrica = new DominioSKD.Fabrica.FabricaEntidades();
            try
            {
                Conectar();
                evento = DominioSKD.Fabrica.FabricaEntidades.ObtenerEventoM10();
                List<Parametro> parametros = new List<Parametro>();
                Parametro parametro = new Parametro(RecursosDAOModulo11.ParametroIdEvento, SqlDbType.Int, idEvento, false);
                parametros.Add(parametro);
                DataTable dt = EjecutarStoredProcedureTuplas(RecursosDAOModulo11.ProcedimientoConsultarEventoDetalle, parametros);

                foreach (DataRow row in dt.Rows)
                {
                    ((DominioSKD.Entidades.Modulo10.Evento)evento).Nombre = row[RecursosDAOModulo11.aliasNombreEvento].ToString(); ;
                    ((DominioSKD.Entidades.Modulo10.Evento)evento).Descripcion = row[RecursosDAOModulo11.aliasDescripcionEvento].ToString();
                    ((DominioSKD.Entidades.Modulo10.Evento)evento).Estado = Boolean.Parse(row[RecursosDAOModulo11.aliasEstadoEvento].ToString());
                    ((DominioSKD.Entidades.Modulo10.Evento)evento).Costo = float.Parse(row[RecursosDAOModulo11.aliasCostoEvento].ToString());
                    Entidad horario = DominioSKD.Fabrica.FabricaEntidades.ObtenerHorarioM10();
                    ((DominioSKD.Entidades.Modulo10.Horario)horario).FechaInicio = DateTime.Parse(row[RecursosDAOModulo11.aliasFechaInicio].ToString());
                    ((DominioSKD.Entidades.Modulo10.Horario)horario).FechaFin = DateTime.Parse(row[RecursosDAOModulo11.aliasFechaFin].ToString());
                    ((DominioSKD.Entidades.Modulo10.Horario)horario).HoraInicio = int.Parse(row[RecursosDAOModulo11.aliasHoraInicio].ToString());
                    ((DominioSKD.Entidades.Modulo10.Horario)horario).HoraFin = int.Parse(row[RecursosDAOModulo11.aliasHoraFin].ToString());
                    Entidad tipoEvento = DominioSKD.Fabrica.FabricaEntidades.ObtenerTipoEventoM10();
                    ((DominioSKD.Entidades.Modulo10.TipoEvento)tipoEvento).Id = int.Parse(row[RecursosDAOModulo11.aliasIdTipo].ToString());
                    ((DominioSKD.Entidades.Modulo10.TipoEvento)tipoEvento).Nombre = row[RecursosDAOModulo11.aliasTipoEvento].ToString();
                    Entidad categoria = fabrica.ObtenerCategoria();
                    ((DominioSKD.Entidades.Modulo12.Categoria)categoria).Id = int.Parse(row[RecursosDAOModulo11.aliasIdCategoria].ToString());
                    ((DominioSKD.Entidades.Modulo12.Categoria)categoria).Cinta_inicial = row[RecursosDAOModulo11.aliasCintaInicial].ToString();
                    ((DominioSKD.Entidades.Modulo12.Categoria)categoria).Cinta_final = row[RecursosDAOModulo11.aliasCintaFinal].ToString();
                    ((DominioSKD.Entidades.Modulo12.Categoria)categoria).Edad_inicial = int.Parse(row[RecursosDAOModulo11.aliasEdadInicial].ToString());
                    ((DominioSKD.Entidades.Modulo12.Categoria)categoria).Edad_final = int.Parse(row[RecursosDAOModulo11.aliasEdadFinal].ToString());
                    ((DominioSKD.Entidades.Modulo12.Categoria)categoria).Sexo = row[RecursosDAOModulo11.aliasSexoCategoria].ToString();

                    ((DominioSKD.Entidades.Modulo10.Evento)evento).Horario = horario as DominioSKD.Entidades.Modulo10.Horario;
                    ((DominioSKD.Entidades.Modulo10.Evento)evento).TipoEvento = tipoEvento as DominioSKD.Entidades.Modulo10.TipoEvento;
                    ((DominioSKD.Entidades.Modulo10.Evento)evento).Categoria = categoria as DominioSKD.Entidades.Modulo12.Categoria;
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
            finally
            {
                Desconectar();
            }
            //Logger.EscribirInfo(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, RecursosBDModulo9.MensajeFinInfoLogger, System.Reflection.MethodBase.GetCurrentMethod().Name);

            return evento;
        }
        #endregion

        #region Idao
        /// <summary>
        /// Metodo que permite agregar los resultados de un Evento Examen de Ascenso 
        /// </summary>
        /// <param name="parametro">lista de Resultados Ascensos</param>
        /// <returns>true si se pudo agregar</returns>
        public bool Agregar(List<DominioSKD.Entidad> parametro)
        {
            int cont = 0;
            try
            {
                Conectar();
                foreach (Entidad resultado in parametro)
                {
                    List<Parametro> parametros = new List<Parametro>();
                    Parametro parametro2 = new Parametro(RecursosDAOModulo11.ParametroAprobadoResultadoAscenso, SqlDbType.Char, ((DominioSKD.Entidades.Modulo11.ResultadoAscenso)resultado).Aprobado, false);
                    parametros.Add(parametro2);
                    parametro2 = new Parametro(RecursosDAOModulo11.ParametroIdInscripcion, SqlDbType.Int, ((DominioSKD.Entidades.Modulo11.ResultadoAscenso)resultado).Inscripcion.Id.ToString(), false);
                    parametros.Add(parametro2);
                    EjecutarStoredProcedure(RecursosDAOModulo11.ProcedimientoAgregarAscenso, parametros);
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
            finally
            {
                Desconectar();
            }
        }

        /// <summary>
        /// Metodo que permite modificar de base de datos un resultado de un atleta en un examen de ascenso
        /// </summary>
        /// <param name="parametro">lista de resultado ascenso</param>
        /// <returns>true si se pudo modificar</returns>
        public bool Modificar(List<DominioSKD.Entidad> parametro)
        {
            int cont = 0;
            try
            {
                Conectar();
                foreach (Entidad ascenso in parametro)
                {
                    List<Parametro> parametros = new List<Parametro>();
                    Parametro parametro2 = new Parametro(RecursosDAOModulo11.ParametroAprobadoResultadoAscenso, SqlDbType.Char, ((DominioSKD.Entidades.Modulo11.ResultadoAscenso)ascenso).Aprobado, false);
                    parametros.Add(parametro2);
                    parametro2 = new Parametro(RecursosDAOModulo11.ParametroIdInscripcion, SqlDbType.Int, ((DominioSKD.Entidades.Modulo11.ResultadoAscenso)ascenso).Inscripcion.Id.ToString(), false);
                    parametros.Add(parametro2);
                    parametro2 = new Parametro(RecursosDAOModulo11.ParametroIdEvento, SqlDbType.Int, ((DominioSKD.Entidades.Modulo11.ResultadoAscenso)ascenso).Inscripcion.Evento.Id.ToString(), false);
                    parametros.Add(parametro2);

                    EjecutarStoredProcedure(RecursosDAOModulo11.ProcedimientoModificarExamenAscenso, parametros);
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
            finally
            {
                Desconectar();
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
