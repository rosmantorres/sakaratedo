using DatosSKD.InterfazDAO.Modulo7;
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
using DatosSKD.Fabrica;

namespace DatosSKD.DAO.Modulo7
{
    /// <summary>
    /// DAO para consultar evento de atleta
    /// </summary>
    public class DaoEvento : DAOGeneral, IDaoEvento
    {
        /// <summary>
        /// No tiene implementacion
        /// </summary>
        /// <param name="parametro"></param>
        /// <returns></returns>
        public bool Agregar(Entidad parametro)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// No tiene implementacion
        /// </summary>
        /// <returns></returns>
        public List<Entidad> ConsultarTodos()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Método para listar las competencias asistidas del atleta
        /// </summary>
        /// <param name="persona">Objeto de tipo Entidad que tiene el id del atleta a consultar</param>
        /// <returns>Retorna lista de objetos de tipo Entidad con la información de competencias asistidas</returns>
        public List<Entidad> ListarCompetenciasAsistidas(Entidad persona)
        {
            Logger.EscribirInfo(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name,
            RecursosDAOModulo7.MensajeInicioInfoLogger, System.Reflection.MethodBase.GetCurrentMethod().Name);

            BDConexion conexion;
            List<Parametro> parametros;
            Parametro parametro = new Parametro();
            Persona idPersona = (Persona)persona;
            List<Entidad> listaDeCompetenciasAsistidas = new List<Entidad>();
            FabricaDAOSqlServer fabricaSql = new FabricaDAOSqlServer();
            DaoUbicacion baseDeDatosUbicacion = fabricaSql.ObtenerDaoUbicacionM7();

            try
            {
                if (idPersona.Id > 0)
                {
                    conexion = new BDConexion();
                    parametros = new List<Parametro>();
                    parametro = new Parametro(RecursosDAOModulo7.ParamIdPersona, SqlDbType.Int, idPersona.Id.ToString(), false);
                    parametros.Add(parametro);
                    DataTable dt = conexion.EjecutarStoredProcedureTuplas(RecursosDAOModulo7.ConsultarCompetenciasAsistidas, parametros);

                    foreach (DataRow row in dt.Rows)
                    {
                        Competencia competencia = new Competencia();// se sustituye por fabrica
                        competencia.Id = int.Parse(row[RecursosDAOModulo7.AliasIdCompetencia].ToString());
                        competencia.Nombre = row[RecursosDAOModulo7.AliasCompetenciaNombre].ToString();
                        if (int.Parse(row[RecursosDAOModulo7.AliasCompetenciaTipo].ToString()).Equals(1))
                            competencia.TipoCompetencia = RecursosDAOModulo7.AliasCompetenciaKata;
                        else if (int.Parse(row[RecursosDAOModulo7.AliasCompetenciaTipo].ToString()).Equals(2))
                            competencia.TipoCompetencia = RecursosDAOModulo7.AliasCompetenciaKumite;
                        else if (int.Parse(row[RecursosDAOModulo7.AliasCompetenciaTipo].ToString()).Equals(3))
                            competencia.TipoCompetencia = RecursosDAOModulo7.AliasCompetenciaKataKumite;
                        competencia.FechaInicio = DateTime.Parse(row[RecursosDAOModulo7.AliasCompetenciaFechaInicio].ToString());
                        competencia.Costo = int.Parse(row[RecursosDAOModulo7.AliasCompetenciaCosto].ToString());

                        Ubicacion idUbicacion = new Ubicacion();//se debe sustituir por fabrica
                        idUbicacion.Id = int.Parse(row[RecursosDAOModulo7.AliasCompetenciaUbicacionId].ToString());
                        competencia.Ubicacion = (Ubicacion)baseDeDatosUbicacion.ConsultarXId(idUbicacion);

                        listaDeCompetenciasAsistidas.Add(competencia);
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

            return listaDeCompetenciasAsistidas;
        }


        /// <summary>
        /// Método para listar las competencias inscritas del atleta
        /// </summary>
        /// <param name="persona">Objeto de tipo Entidad que tiene el id del atleta a consultar</param>
        /// <returns>Retorna lista de objetos de tipo Entidad con la información de competencias inscritas</returns>
        public List<Entidad> ListarCompetenciasInscritas(Entidad persona)
        {
            Logger.EscribirInfo(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name,
            RecursosDAOModulo7.MensajeInicioInfoLogger, System.Reflection.MethodBase.GetCurrentMethod().Name);

            BDConexion conexion;
            List<Parametro> parametros;
            Parametro parametro = new Parametro();
            Persona idPersona = (Persona)persona;
            List<Entidad> listaDeCompetenciasInscritas = new List<Entidad>();
            FabricaDAOSqlServer fabricaSql = new FabricaDAOSqlServer();
            DaoUbicacion baseDeDatosUbicacion = fabricaSql.ObtenerDaoUbicacionM7();

            try
            {
                if (idPersona.Id > 0)
                {
                    conexion = new BDConexion();
                    parametros = new List<Parametro>();
                    parametro = new Parametro(RecursosDAOModulo7.ParamIdUsuarioLogueado, SqlDbType.Int, idPersona.Id.ToString(), false);
                    parametros.Add(parametro);
                    DataTable dt = conexion.EjecutarStoredProcedureTuplas(RecursosDAOModulo7.ConsultarCompetenciasInscritas, parametros);

                    foreach (DataRow row in dt.Rows)
                    {
                        Competencia competencia = new Competencia();// se sustituye por fabrica
                        competencia.Id = int.Parse(row[RecursosDAOModulo7.AliasIdCompetencia].ToString());
                        competencia.Nombre = row[RecursosDAOModulo7.AliasCompetenciaNombre].ToString();
                        if (int.Parse(row[RecursosDAOModulo7.AliasCompetenciaTipo].ToString()).Equals(1))
                            competencia.TipoCompetencia = RecursosDAOModulo7.AliasCompetenciaKata;
                        else if (int.Parse(row[RecursosDAOModulo7.AliasCompetenciaTipo].ToString()).Equals(2))
                            competencia.TipoCompetencia = RecursosDAOModulo7.AliasCompetenciaKumite;
                        else if (int.Parse(row[RecursosDAOModulo7.AliasCompetenciaTipo].ToString()).Equals(3))
                            competencia.TipoCompetencia = RecursosDAOModulo7.AliasCompetenciaKataKumite;
                        competencia.FechaInicio = DateTime.Parse(row[RecursosDAOModulo7.AliasCompetenciaFechaInicio].ToString());
                        competencia.Costo = int.Parse(row[RecursosDAOModulo7.AliasCompetenciaCosto].ToString());

                        Ubicacion idUbicacion = new Ubicacion();//se debe sustituir por fabrica
                        idUbicacion.Id = int.Parse(row[RecursosDAOModulo7.AliasCompetenciaUbicacionId].ToString());
                        competencia.Ubicacion = (Ubicacion)baseDeDatosUbicacion.ConsultarXId(idUbicacion);

                        listaDeCompetenciasInscritas.Add(competencia);
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

            return listaDeCompetenciasInscritas;
        }


        /// <summary>
        /// Método para listar los eventos asistidos del atleta
        /// </summary>
        /// <param name="persona">Objeto de tipo Entidad que tiene el id del atleta a consultar</param>
        /// <returns>Retorna lista de objetos de tipo Entidad con la información de eventos asistidos</returns>
        public List<Entidad> ListarEventosAsistidos(Entidad persona)
        {
            Logger.EscribirInfo(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name,
            RecursosDAOModulo7.MensajeInicioInfoLogger, System.Reflection.MethodBase.GetCurrentMethod().Name);

            BDConexion conexion;
            List<Parametro> parametros;
            Parametro parametro = new Parametro();
            List<Entidad> listaDeEventoAsistidos = new List<Entidad>();
            Persona idPersona = (Persona)persona;
            FabricaDAOSqlServer fabricaSql = new FabricaDAOSqlServer();

            DaoUbicacion baseDeDatosUbicacion = fabricaSql.ObtenerDaoUbicacionM7();
            DaoHorario baseDeDatosHorario = fabricaSql.ObtenerDaoHorarioM7();
            DaoTipoEvento baseDeDatosTipoEvento = fabricaSql.ObtenerDaoTipoEventoM7();

            try
            {
                if (idPersona.Id > 0)
                {
                    conexion = new BDConexion();
                    parametros = new List<Parametro>();
                    parametro = new Parametro(RecursosDAOModulo7.ParamIdPersona, SqlDbType.Int, idPersona.Id.ToString(), false);
                    parametros.Add(parametro);

                    DataTable dt = conexion.EjecutarStoredProcedureTuplas(RecursosDAOModulo7.ConsultarEventosAsistidos, parametros);

                    foreach (DataRow row in dt.Rows)
                    {
                        Evento evento = new Evento();//se debe usar fabrica aqui
                        evento.Id = int.Parse(row[RecursosDAOModulo7.AliasIdEvento].ToString());
                        evento.Nombre = row[RecursosDAOModulo7.AliasEventoNombre].ToString();
                        evento.Descripcion = row[RecursosDAOModulo7.AliasDescripcionEvento].ToString();
                        evento.Costo = float.Parse(row[RecursosDAOModulo7.AliasEventoCosto].ToString());

                        TipoEvento idTipoEvento = new TipoEvento();//se debe usar fabrica aqui
                        idTipoEvento.Id = int.Parse(row[RecursosDAOModulo7.AliasEventoTipoEveId].ToString());
                        evento.TipoEvento = (TipoEvento)baseDeDatosTipoEvento.ConsultarXId(idTipoEvento);

                        Horario idHorario = new Horario();//se debe usar fabrica aqui
                        idHorario.Id = int.Parse(row[RecursosDAOModulo7.AliasEventoHorarioId].ToString());
                        evento.Horario = (Horario)baseDeDatosHorario.ConsultarXId(idHorario);

                        Ubicacion idUbicacion = new Ubicacion();//se debe usar fabrica aqui
                        idUbicacion.Id = int.Parse(row[RecursosDAOModulo7.AliasEventoUbicacionId].ToString());
                        evento.Ubicacion = (Ubicacion)baseDeDatosUbicacion.ConsultarXId(idUbicacion);

                        listaDeEventoAsistidos.Add(evento);
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

            return listaDeEventoAsistidos;
        }

        /// <summary>
        /// Método para listar los eventos inscritos del atleta
        /// </summary>
        /// <param name="persona">Objeto de tipo Entidad que tiene el id del atleta a consultar</param>
        /// <returns>Retorna lista de objetos de tipo Entidad con la información de eventos inscritos</returns>
        public List<Entidad> ListarEventosInscritos(Entidad persona)
        {
            Logger.EscribirInfo(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name,
            RecursosDAOModulo7.MensajeInicioInfoLogger, System.Reflection.MethodBase.GetCurrentMethod().Name);

            BDConexion conexion;
            List<Parametro> parametros;
            Parametro parametro = new Parametro();
            List<Entidad> listaDeEventoInscritos = new List<Entidad>();
            Persona idPersona = (Persona)persona;
            FabricaDAOSqlServer fabricaSql = new FabricaDAOSqlServer();

            DaoUbicacion baseDeDatosUbicacion = fabricaSql.ObtenerDaoUbicacionM7();
            DaoHorario baseDeDatosHorario = fabricaSql.ObtenerDaoHorarioM7();
            DaoTipoEvento baseDeDatosTipoEvento = fabricaSql.ObtenerDaoTipoEventoM7();

            try
            {
                if (idPersona.Id > 0)
                {
                    conexion = new BDConexion();
                    parametros = new List<Parametro>();
                    parametro = new Parametro(RecursosDAOModulo7.ParamIdUsuarioLogueado, SqlDbType.Int, idPersona.Id.ToString(), false);
                    parametros.Add(parametro);

                    DataTable dt = conexion.EjecutarStoredProcedureTuplas(RecursosDAOModulo7.ConsultarEventosInscritos, parametros);

                    foreach (DataRow row in dt.Rows)
                    {
                        Evento evento = new Evento();//se debe usar fabrica aqui
                        evento.Id = int.Parse(row[RecursosDAOModulo7.AliasIdEvento].ToString());
                        evento.Nombre = row[RecursosDAOModulo7.AliasEventoNombre].ToString();
                        evento.Descripcion = row[RecursosDAOModulo7.AliasDescripcionEvento].ToString();
                        evento.Costo = float.Parse(row[RecursosDAOModulo7.AliasEventoCosto].ToString());

                        TipoEvento idTipoEvento = new TipoEvento();//se debe usar fabrica aqui
                        idTipoEvento.Id = int.Parse(row[RecursosDAOModulo7.AliasEventoTipoEveId].ToString());
                        evento.TipoEvento = (TipoEvento)baseDeDatosTipoEvento.ConsultarXId(idTipoEvento);

                        Horario idHorario = new Horario();//se debe usar fabrica aqui
                        idHorario.Id = int.Parse(row[RecursosDAOModulo7.AliasEventoHorarioId].ToString());
                        evento.Horario = (Horario)baseDeDatosHorario.ConsultarXId(idHorario);

                        Ubicacion idUbicacion = new Ubicacion();//se debe usar fabrica aqui
                        idUbicacion.Id = int.Parse(row[RecursosDAOModulo7.AliasEventoUbicacionId].ToString());
                        evento.Ubicacion = (Ubicacion)baseDeDatosUbicacion.ConsultarXId(idUbicacion);

                        listaDeEventoInscritos.Add(evento);
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

            return listaDeEventoInscritos;
        }

        /// <summary>
        /// Método para listar los horarios de practica del atleta
        /// </summary>
        /// <param name="persona"></param>
        /// <returns>Retorna lista de objetos de tipo Entidad con la información de los horarios de practica</returns>
        public List<Entidad> ListarHorarioPractica(Entidad persona)
        {
            Logger.EscribirInfo(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name,
            RecursosDAOModulo7.MensajeInicioInfoLogger, System.Reflection.MethodBase.GetCurrentMethod().Name);

            BDConexion conexion;
            List<Parametro> parametros;
            Parametro parametro = new Parametro();
            List<Entidad> listaDeHorarioPractica = new List<Entidad>();
            Persona idPersona = (Persona)persona;
            FabricaDAOSqlServer fabricaSql = new FabricaDAOSqlServer();

            DaoUbicacion baseDeDatosUbicacion = fabricaSql.ObtenerDaoUbicacionM7();
            DaoHorario baseDeDatosHorario = fabricaSql.ObtenerDaoHorarioM7();
            DaoTipoEvento baseDeDatosTipoEvento = fabricaSql.ObtenerDaoTipoEventoM7();

            try
            {
                if (idPersona.Id > 0)
                {
                    conexion = new BDConexion();
                    parametros = new List<Parametro>();
                    parametro = new Parametro(RecursosDAOModulo7.ParamIdUsuarioLogueado, SqlDbType.Int, idPersona.Id.ToString(), false);
                    parametros.Add(parametro);

                    DataTable dt = conexion.EjecutarStoredProcedureTuplas(RecursosDAOModulo7.ConsultarHorarioPractica, parametros);

                    foreach (DataRow row in dt.Rows)
                    {
                        Evento evento = new Evento();//se debe usar fabrica aqui
                        evento.Id = int.Parse(row[RecursosDAOModulo7.AliasIdEvento].ToString());
                        evento.Nombre = row[RecursosDAOModulo7.AliasEventoNombre].ToString();
                        evento.Descripcion = row[RecursosDAOModulo7.AliasDescripcionEvento].ToString();
                       
                        TipoEvento idTipoEvento = new TipoEvento();//se debe usar fabrica aqui
                        idTipoEvento.Id = int.Parse(row[RecursosDAOModulo7.AliasEventoTipoEveId].ToString());
                        evento.TipoEvento = (TipoEvento)baseDeDatosTipoEvento.ConsultarXId(idTipoEvento);

                        Horario idHorario = new Horario();//se debe usar fabrica aqui
                        idHorario.Id = int.Parse(row[RecursosDAOModulo7.AliasEventoHorarioId].ToString());
                        evento.Horario = (Horario)baseDeDatosHorario.ConsultarXId(idHorario);

                        Ubicacion idUbicacion = new Ubicacion();//se debe usar fabrica aqui
                        idUbicacion.Id = int.Parse(row[RecursosDAOModulo7.AliasEventoUbicacionId].ToString());
                        evento.Ubicacion = (Ubicacion)baseDeDatosUbicacion.ConsultarXId(idUbicacion);

                        listaDeHorarioPractica.Add(evento);
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

            return listaDeHorarioPractica;
        }

        /// <summary>
        /// No tiene implementacion
        /// </summary>
        /// <param name="parametro"></param>
        /// <returns></returns>
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
            FabricaDAOSqlServer fabricaSql = new FabricaDAOSqlServer();

            DaoUbicacion baseDeDatosUbicacion = fabricaSql.ObtenerDaoUbicacionM7();
            DaoHorario baseDeDatosHorario = fabricaSql.ObtenerDaoHorarioM7();
            DaoTipoEvento baseDeDatosTipoEvento = fabricaSql.ObtenerDaoTipoEventoM7();


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

                        evento.Id = int.Parse(row[RecursosDAOModulo7.AliasIdEvento].ToString());
                        evento.Nombre = row[RecursosDAOModulo7.AliasEventoNombre].ToString();
                        evento.Descripcion = row[RecursosDAOModulo7.AliasDescripcionEvento].ToString();
                        evento.Costo = float.Parse(row[RecursosDAOModulo7.AliasEventoCosto].ToString());

                        TipoEvento idTipoEvento = new TipoEvento();//se debe usar fabrica aqui cuando este lista
                        idTipoEvento.Id = int.Parse(row[RecursosDAOModulo7.AliasEventoTipoEveId].ToString());
                        evento.TipoEvento = (TipoEvento)baseDeDatosTipoEvento.ConsultarXId(idTipoEvento);

                        Horario idHorario = new Horario();//se debe usar fabrica aqui cuando este lista
                        idHorario.Id = int.Parse(row[RecursosDAOModulo7.AliasEventoHorarioId].ToString());
                        evento.Horario = (Horario)baseDeDatosHorario.ConsultarXId(idHorario);

                        Ubicacion idUbicacion = new Ubicacion();//se debe usar fabrica aqui cuando este lista
                        idUbicacion.Id = int.Parse(row[RecursosDAOModulo7.AliasEventoUbicacionId].ToString());
                        evento.Ubicacion = (Ubicacion)baseDeDatosUbicacion.ConsultarXId(idUbicacion);
                      
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
            BDConexion conexion;
            List<Parametro> parametros;
            Parametro parametroPersona = new Parametro();
            Parametro parametroCompetencia = new Parametro();
            DateTime fechaInscripcionCompetencia = new DateTime();
            Persona idPersona = (Persona)persona;
            Competencia idCompetencia = (Competencia)competencia;

            try
            {
                if (idPersona.Id > 0 && idCompetencia.Id > 0)
                {
                    conexion = new BDConexion();
                    parametros = new List<Parametro>();
                    parametroPersona = new Parametro(RecursosDAOModulo7.ParamIdPersona, SqlDbType.Int, idPersona.Id.ToString(), false);
                    parametroCompetencia = new Parametro(RecursosDAOModulo7.ParamIdCompetenciaPaga, SqlDbType.Int, idCompetencia.Id.ToString(), false);
                    parametros.Add(parametroPersona);
                    parametros.Add(parametroCompetencia);

                    DataTable dt = conexion.EjecutarStoredProcedureTuplas(
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
            BDConexion conexion;
            List<Parametro> parametros;
            Parametro parametroPersona = new Parametro();
            Parametro parametroEvento = new Parametro();
            DateTime fechaInscripcion = new DateTime();
            Persona idPersona = (Persona)persona;
            Evento idEvento = (Evento)evento;

            try
            {
                if (idPersona.Id > 0 && idEvento.Id > 0)
                {
                    conexion = new BDConexion();
                    parametros = new List<Parametro>();
                    parametroPersona = new Parametro(RecursosDAOModulo7.ParamIdPersona, SqlDbType.Int, idPersona.Id.ToString(), false);
                    parametroEvento = new Parametro(RecursosDAOModulo7.ParamIdEvento, SqlDbType.Int, idEvento.Id.ToString(), false);
                    parametros.Add(parametroPersona);
                    parametros.Add(parametroEvento);

                    DataTable dt = conexion.EjecutarStoredProcedureTuplas(
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
        /// <returns>Retorna fecha en la que se realizo el pago del evento</returns>
        
        public DateTime FechaPagoEvento(Entidad persona, Entidad evento)
        {
            Logger.EscribirInfo(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name,
                  RecursosDAOModulo7.MensajeInicioInfoLogger, System.Reflection.MethodBase.GetCurrentMethod().Name);
            BDConexion conexion;
            List<Parametro> parametros;
            Parametro parametroPersona = new Parametro();
            Parametro parametroEvento = new Parametro();
            DateTime fechaPago = new DateTime();
            Persona idPersona = (Persona)persona;
            Evento idEvento = (Evento)evento;

            try
            {
                if (idPersona.Id > 0 && idEvento.Id > 0)
                {
                    conexion = new BDConexion();
                    parametros = new List<Parametro>();
                    parametroPersona = new Parametro(RecursosDAOModulo7.ParamIdPersona, SqlDbType.Int, idPersona.Id.ToString(), false);
                    parametroEvento = new Parametro(RecursosDAOModulo7.ParamIdEvento, SqlDbType.Int, idEvento.Id.ToString(), false);
                    parametros.Add(parametroPersona);
                    parametros.Add(parametroEvento);

                    DataTable dt = conexion.EjecutarStoredProcedureTuplas(
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
        /// Método para consultar la lista de competencias pagas
        /// </summary>
        /// <param name="persona">Objeto de tipo Entidad que posee el id de la persona</param>
        /// <returns>Retorna lista con objetos de tipo Entidad con la lista de competencias que han sido canceladas</returns>
        public List<Entidad> ListarCompetenciasPaga(Entidad persona)
        {
            Logger.EscribirInfo(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name,
                RecursosDAOModulo7.MensajeInicioInfoLogger, System.Reflection.MethodBase.GetCurrentMethod().Name);

            BDConexion conexion;
            List<Parametro> parametros;
            Parametro parametroQuery = new Parametro();

            FabricaEntidades fabricaEntidades = new FabricaEntidades();
            List<Entidad> listaDeCompetenciasPagas= new List<Entidad>();
            Persona idPersona = (Persona)persona;

            try
            {
                if (idPersona.Id > 0)
                {
                    conexion = new BDConexion();
                    parametros = new List<Parametro>();
                    parametroQuery = new Parametro(RecursosDAOModulo7.ParamIdUsuarioLogueado, SqlDbType.Int, idPersona.Id.ToString(), false);
                    parametros.Add(parametroQuery);

                    DataTable dt = conexion.EjecutarStoredProcedureTuplas(
                                   RecursosDAOModulo7.ConsultarCompetenciasInscritas, parametros);


                    foreach (DataRow row in dt.Rows)
                    {
                        Competencia competencia = (Competencia)FabricaEntidades.ObtenerCompetencia();

                        competencia.Id = int.Parse(row[RecursosDAOModulo7.AliasIdCompetencia].ToString());
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
        /// <returns>Retorna lista con objetos de tipo Entidad con la lista de eventos que han sido pagos</returns>
        /// 
        public List<Entidad> ListarEventosPagos(Entidad persona)
        {
            Logger.EscribirInfo(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name,
                RecursosDAOModulo7.MensajeInicioInfoLogger, System.Reflection.MethodBase.GetCurrentMethod().Name);

            BDConexion conexion;
            List<Parametro> parametros;
            Parametro parametroQuery = new Parametro();

            FabricaEntidades fabricaEntidades = new FabricaEntidades();
            List<Entidad> listaDeEventos = new List<Entidad>();
            Persona idPersona = (Persona)persona;
            FabricaDAOSqlServer fabricaSql = new FabricaDAOSqlServer();
            DaoTipoEvento baseDeDatosTipoEvento = fabricaSql.ObtenerDaoTipoEventoM7();

            try
            {
                if (idPersona.Id > 0)
                {
                    conexion = new BDConexion();
                    parametros = new List<Parametro>();
                    parametroQuery = new Parametro(RecursosDAOModulo7.ParamIdUsuarioLogueado, SqlDbType.Int, idPersona.Id.ToString(), false);
                    parametros.Add(parametroQuery);

                    DataTable dt = conexion.EjecutarStoredProcedureTuplas(
                                   RecursosDAOModulo7.ConsultarEventosPagos, parametros);


                    foreach (DataRow row in dt.Rows)
                    {
                        Evento evento  = (Evento)fabricaEntidades.ObtenerEvento();
                        evento.Id = int.Parse(row[RecursosDAOModulo7.AliasIdEvento].ToString());
                        evento.Nombre = row[RecursosDAOModulo7.AliasEventoNombre].ToString();

                        TipoEvento idTipoEvento = new TipoEvento();//se debe usar fabrica aqui cuando est
                        idTipoEvento.Id = int.Parse(row[RecursosDAOModulo7.AliasEventoTipoEveId].ToString());
                        evento.TipoEvento = (TipoEvento)baseDeDatosTipoEvento.ConsultarXId(idTipoEvento);

                     
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
        /// <returns>Retorna lista con objetos de tipo Entidad con el monto pago del evento</returns>
        
       public float MontoPagoEvento(Entidad persona, Entidad evento)
        {
        Logger.EscribirInfo(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name,
                 RecursosDAOModulo7.MensajeInicioInfoLogger, System.Reflection.MethodBase.GetCurrentMethod().Name);
            BDConexion conexion;
            List<Parametro> parametros;
            Parametro parametroPersona = new Parametro();
            Parametro parametroEvento = new Parametro();
            float monto = new float();
            Persona idPersona = (Persona)persona;
            Evento idEvento = (Evento)evento;
        
            try
            {
                if (idPersona.Id > 0 && idEvento.Id > 0)
                {
                    conexion = new BDConexion();
                    parametros = new List<Parametro>();
                    parametroPersona = new Parametro(RecursosDAOModulo7.ParamIdPersona, SqlDbType.Int, idPersona.Id.ToString(), false);
                    parametroEvento = new Parametro(RecursosDAOModulo7.ParamIdEvento, SqlDbType.Int, idEvento.Id.ToString(), false);
                    parametros.Add(parametroPersona);
                    parametros.Add(parametroEvento);

                    DataTable dt = conexion.EjecutarStoredProcedureTuplas(
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
