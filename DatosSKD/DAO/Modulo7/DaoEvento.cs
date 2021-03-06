﻿using DatosSKD.InterfazDAO.Modulo7;
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
using DominioSKD.Entidades.Modulo7;

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
            List<Parametro> parametros;
            Parametro parametro = new Parametro();
            PersonaM7 idPersona = (PersonaM7)persona;
            List<Entidad> listaDeCompetenciasAsistidas = new List<Entidad>();
            DaoUbicacion baseDeDatosUbicacion = FabricaDAOSqlServer.ObtenerDaoUbicacionM7();

            try
            {
                if (idPersona.Id > 0)
                {
                    parametros = new List<Parametro>();
                    parametro = new Parametro(RecursosDAOModulo7.ParamIdPersona, SqlDbType.Int, idPersona.Id.ToString(), false);
                    parametros.Add(parametro);
                    DataTable dt = this.EjecutarStoredProcedureTuplas(RecursosDAOModulo7.ConsultarCompetenciasAsistidas, parametros);

                    foreach (DataRow row in dt.Rows)
                    {
                        CompetenciaM7 competencia = (CompetenciaM7)FabricaEntidades.ObtenerCompetenciaM7();
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

                        UbicacionM7 idUbicacion = (UbicacionM7)FabricaEntidades.ObtenerUbicacionM7();
                        idUbicacion.Id = int.Parse(row[RecursosDAOModulo7.AliasCompetenciaUbicacionId].ToString());
                        competencia.Ubicacion = (UbicacionM7)baseDeDatosUbicacion.ConsultarXId(idUbicacion);

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
                throw new ExceptionSKDConexionBD(RecursoGeneralBD.Codigo,RecursoGeneralBD.Mensaje, ex);
            }
            catch (NumeroEnteroInvalidoException ex)
            {
                throw new NumeroEnteroInvalidoException(RecursosDAOModulo7.Codigo_Numero_Parametro_Invalido,
                                RecursosDAOModulo7.Mensaje_Numero_Parametro_invalido, new Exception());
            }
            catch (FormatException ex)
            {
                throw new NumeroEnteroInvalidoException(RecursosDAOModulo7.Codigo_Numero_Parametro_Invalido,
                                RecursosDAOModulo7.Mensaje_Numero_Parametro_invalido, new Exception());
            }
            catch (ExceptionSKDConexionBD ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw new ExceptionSKD(RecursosDAOModulo7.MensajeExceptionSKD, ex);
            }

            return listaDeCompetenciasAsistidas;
        }


        /// <summary>
        /// Método para listar las competencias inscritas del atleta
        /// </summary>
        /// <param name="persona">Objeto de tipo Entidad que tiene el id del atleta a consultar</param>
        /// <returns>Retorna lista de objetos de tipo Entidad con la información de competencias inscritas</returns>
        public List<Entidad> ListarCompetenciasInscritas(Entidad persona)
        {
            List<Parametro> parametros;
            Parametro parametro = new Parametro();
            PersonaM7 idPersona = (PersonaM7)persona;
            List<Entidad> listaDeCompetenciasInscritas = new List<Entidad>();
            DaoUbicacion baseDeDatosUbicacion = FabricaDAOSqlServer.ObtenerDaoUbicacionM7();

            try
            {
                if (idPersona.Id > 0)
                {
                    parametros = new List<Parametro>();
                    parametro = new Parametro(RecursosDAOModulo7.ParamIdUsuarioLogueado, SqlDbType.Int, idPersona.Id.ToString(), false);
                    parametros.Add(parametro);
                    DataTable dt = this.EjecutarStoredProcedureTuplas(RecursosDAOModulo7.ConsultarCompetenciasInscritas, parametros);

                    foreach (DataRow row in dt.Rows)
                    {
                        CompetenciaM7 competencia = (CompetenciaM7)FabricaEntidades.ObtenerCompetenciaM7();
                        FabricaEntidades.ObtenerCompetenciaM7();
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

                        UbicacionM7 idUbicacion = (UbicacionM7)FabricaEntidades.ObtenerUbicacionM7();
                        idUbicacion.Id = int.Parse(row[RecursosDAOModulo7.AliasCompetenciaUbicacionId].ToString());
                        competencia.Ubicacion = (UbicacionM7)baseDeDatosUbicacion.ConsultarXId(idUbicacion);

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
                throw new ExceptionSKDConexionBD(RecursoGeneralBD.Codigo,
                    RecursoGeneralBD.Mensaje, ex);
            }
            catch (NumeroEnteroInvalidoException ex)
            {
                throw new NumeroEnteroInvalidoException(RecursosDAOModulo7.Codigo_Numero_Parametro_Invalido,
                                RecursosDAOModulo7.Mensaje_Numero_Parametro_invalido, new Exception());
            }
            catch (FormatException ex)
            {
                throw new NumeroEnteroInvalidoException(RecursosDAOModulo7.Codigo_Numero_Parametro_Invalido,
                                RecursosDAOModulo7.Mensaje_Numero_Parametro_invalido, new Exception());
            }
            catch (ExceptionSKDConexionBD ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw new ExceptionSKD(RecursosDAOModulo7.MensajeExceptionSKD, ex);
            }

            return listaDeCompetenciasInscritas;
        }


        /// <summary>
        /// Método para listar los eventos asistidos del atleta
        /// </summary>
        /// <param name="persona">Objeto de tipo Entidad que tiene el id del atleta a consultar</param>
        /// <returns>Retorna lista de objetos de tipo Entidad con la información de eventos asistidos</returns>
        public List<Entidad> ListarEventosAsistidos(Entidad persona)
        {
            List<Parametro> parametros;
            Parametro parametro = new Parametro();
            List<Entidad> listaDeEventoAsistidos = new List<Entidad>();
            PersonaM7 idPersona = (PersonaM7)persona;

            DaoUbicacion baseDeDatosUbicacion = FabricaDAOSqlServer.ObtenerDaoUbicacionM7();
            DaoHorario baseDeDatosHorario = FabricaDAOSqlServer.ObtenerDaoHorarioM7();
            DaoTipoEvento baseDeDatosTipoEvento = FabricaDAOSqlServer.ObtenerDaoTipoEventoM7();

            try
            {
                if (idPersona.Id > 0)
                {
                    parametros = new List<Parametro>();
                    parametro = new Parametro(RecursosDAOModulo7.ParamIdPersona, SqlDbType.Int, idPersona.Id.ToString(), false);
                    parametros.Add(parametro);

                    DataTable dt = this.EjecutarStoredProcedureTuplas(RecursosDAOModulo7.ConsultarEventosAsistidos, parametros);

                    foreach (DataRow row in dt.Rows)
                    {
                        EventoM7 evento = (EventoM7)FabricaEntidades.ObtenerEventoM7();
                        evento.Id = int.Parse(row[RecursosDAOModulo7.AliasIdEvento].ToString());
                        evento.Nombre = row[RecursosDAOModulo7.AliasEventoNombre].ToString();
                        evento.Descripcion = row[RecursosDAOModulo7.AliasDescripcionEvento].ToString();
                        evento.Costo = float.Parse(row[RecursosDAOModulo7.AliasEventoCosto].ToString());

                        TipoEventoM7 idTipoEvento = (TipoEventoM7)FabricaEntidades.ObtenerTipoEventoM7();
                        idTipoEvento.Id = int.Parse(row[RecursosDAOModulo7.AliasEventoTipoEveId].ToString());
                        evento.TipoEvento = (TipoEventoM7)baseDeDatosTipoEvento.ConsultarXId(idTipoEvento);

                        HorarioM7 idHorario = (HorarioM7)FabricaEntidades.ObtenerHorarioM7();
                        idHorario.Id = int.Parse(row[RecursosDAOModulo7.AliasEventoHorarioId].ToString());
                        evento.Horario = (HorarioM7)baseDeDatosHorario.ConsultarXId(idHorario);

                        UbicacionM7 idUbicacion = (UbicacionM7)FabricaEntidades.ObtenerUbicacionM7();
                        idUbicacion.Id = int.Parse(row[RecursosDAOModulo7.AliasEventoUbicacionId].ToString());
                        evento.Ubicacion = (UbicacionM7)baseDeDatosUbicacion.ConsultarXId(idUbicacion);

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
                throw new ExceptionSKDConexionBD(RecursoGeneralBD.Codigo,RecursoGeneralBD.Mensaje, ex);
            }
            catch (NumeroEnteroInvalidoException ex)
            {
                throw new NumeroEnteroInvalidoException(RecursosDAOModulo7.Codigo_Numero_Parametro_Invalido,
                                RecursosDAOModulo7.Mensaje_Numero_Parametro_invalido, new Exception());
            }
            catch (FormatException ex)
            {
                throw new NumeroEnteroInvalidoException(RecursosDAOModulo7.Codigo_Numero_Parametro_Invalido,
                                RecursosDAOModulo7.Mensaje_Numero_Parametro_invalido, new Exception());
            }
            catch (ExceptionSKDConexionBD ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw new ExceptionSKD(RecursosDAOModulo7.MensajeExceptionSKD, ex);
            }

            return listaDeEventoAsistidos;
        }

        /// <summary>
        /// Método para listar los eventos inscritos del atleta
        /// </summary>
        /// <param name="persona">Objeto de tipo Entidad que tiene el id del atleta a consultar</param>
        /// <returns>Retorna lista de objetos de tipo Entidad con la información de eventos inscritos</returns>
        public List<Entidad> ListarEventosInscritos(Entidad persona)
        {
            List<Parametro> parametros;
            Parametro parametro = new Parametro();
            List<Entidad> listaDeEventoInscritos = new List<Entidad>();
            PersonaM7 idPersona = (PersonaM7)persona;

            DaoUbicacion baseDeDatosUbicacion = FabricaDAOSqlServer.ObtenerDaoUbicacionM7();
            DaoHorario baseDeDatosHorario = FabricaDAOSqlServer.ObtenerDaoHorarioM7();
            DaoTipoEvento baseDeDatosTipoEvento = FabricaDAOSqlServer.ObtenerDaoTipoEventoM7();

            try
            {
                if (idPersona.Id > 0)
                {
                    parametros = new List<Parametro>();
                    parametro = new Parametro(RecursosDAOModulo7.ParamIdUsuarioLogueado, SqlDbType.Int, idPersona.Id.ToString(), false);
                    parametros.Add(parametro);

                    DataTable dt = this.EjecutarStoredProcedureTuplas(RecursosDAOModulo7.ConsultarEventosInscritos, parametros);

                    foreach (DataRow row in dt.Rows)
                    {
                        EventoM7 evento = (EventoM7)FabricaEntidades.ObtenerEventoM7();
                        evento.Id = int.Parse(row[RecursosDAOModulo7.AliasIdEvento].ToString());
                        evento.Nombre = row[RecursosDAOModulo7.AliasEventoNombre].ToString();
                        evento.Descripcion = row[RecursosDAOModulo7.AliasDescripcionEvento].ToString();
                        evento.Costo = float.Parse(row[RecursosDAOModulo7.AliasEventoCosto].ToString());

                        TipoEventoM7 idTipoEvento = (TipoEventoM7)FabricaEntidades.ObtenerTipoEventoM7();
                        idTipoEvento.Id = int.Parse(row[RecursosDAOModulo7.AliasEventoTipoEveId].ToString());
                        evento.TipoEvento = (TipoEventoM7)baseDeDatosTipoEvento.ConsultarXId(idTipoEvento);

                        HorarioM7 idHorario = (HorarioM7)FabricaEntidades.ObtenerHorarioM7();
                        idHorario.Id = int.Parse(row[RecursosDAOModulo7.AliasEventoHorarioId].ToString());
                        evento.Horario = (HorarioM7)baseDeDatosHorario.ConsultarXId(idHorario);

                        UbicacionM7 idUbicacion = (UbicacionM7)FabricaEntidades.ObtenerUbicacionM7();
                        idUbicacion.Id = int.Parse(row[RecursosDAOModulo7.AliasEventoUbicacionId].ToString());
                        evento.Ubicacion = (UbicacionM7)baseDeDatosUbicacion.ConsultarXId(idUbicacion);

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
                throw new ExceptionSKDConexionBD(RecursoGeneralBD.Codigo,RecursoGeneralBD.Mensaje, ex);
            }
            catch (NumeroEnteroInvalidoException ex)
            {
                throw new NumeroEnteroInvalidoException(RecursosDAOModulo7.Codigo_Numero_Parametro_Invalido,
                                RecursosDAOModulo7.Mensaje_Numero_Parametro_invalido, new Exception());
            }
            catch (FormatException ex)
            {
                throw new NumeroEnteroInvalidoException(RecursosDAOModulo7.Codigo_Numero_Parametro_Invalido,
                                RecursosDAOModulo7.Mensaje_Numero_Parametro_invalido, new Exception());
            }
            catch (ExceptionSKDConexionBD ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw new ExceptionSKD(RecursosDAOModulo7.MensajeExceptionSKD, ex);
            }

            return listaDeEventoInscritos;
        }

        /// <summary>
        /// Método para listar los horarios de practica del atleta
        /// </summary>
        /// <param name="persona"></param>
        /// <returns>Retorna lista de objetos de tipo Entidad con la información de los horarios de practica</returns>
        public List<Entidad> ListarHorarioPractica(Entidad persona)
        {
            List<Parametro> parametros;
            Parametro parametro = new Parametro();
            List<Entidad> listaDeHorarioPractica = new List<Entidad>();
            PersonaM7 idPersona = (PersonaM7)persona;

            DaoUbicacion baseDeDatosUbicacion = FabricaDAOSqlServer.ObtenerDaoUbicacionM7();
            DaoHorario baseDeDatosHorario = FabricaDAOSqlServer.ObtenerDaoHorarioM7();
            DaoTipoEvento baseDeDatosTipoEvento = FabricaDAOSqlServer.ObtenerDaoTipoEventoM7();

            try
            {
                if (idPersona.Id > 0)
                {
                    parametros = new List<Parametro>();
                    parametro = new Parametro(RecursosDAOModulo7.ParamIdUsuarioLogueado, SqlDbType.Int, idPersona.Id.ToString(), false);
                    parametros.Add(parametro);

                    DataTable dt = this.EjecutarStoredProcedureTuplas(RecursosDAOModulo7.ConsultarHorarioPractica, parametros);

                    foreach (DataRow row in dt.Rows)
                    {
                        EventoM7 evento = (EventoM7)FabricaEntidades.ObtenerEventoM7();
                        evento.Id = int.Parse(row[RecursosDAOModulo7.AliasIdEvento].ToString());
                        evento.Nombre = row[RecursosDAOModulo7.AliasEventoNombre].ToString();
                        evento.Descripcion = row[RecursosDAOModulo7.AliasDescripcionEvento].ToString();

                        TipoEventoM7 idTipoEvento = (TipoEventoM7)FabricaEntidades.ObtenerTipoEventoM7();
                        idTipoEvento.Id = int.Parse(row[RecursosDAOModulo7.AliasEventoTipoEveId].ToString());
                        evento.TipoEvento = (TipoEventoM7)baseDeDatosTipoEvento.ConsultarXId(idTipoEvento);

                        HorarioM7 idHorario = (HorarioM7)FabricaEntidades.ObtenerHorarioM7();
                        idHorario.Id = int.Parse(row[RecursosDAOModulo7.AliasEventoHorarioId].ToString());
                        evento.Horario = (HorarioM7)baseDeDatosHorario.ConsultarXId(idHorario);

                        UbicacionM7 idUbicacion = (UbicacionM7)FabricaEntidades.ObtenerUbicacionM7();
                        idUbicacion.Id = int.Parse(row[RecursosDAOModulo7.AliasEventoUbicacionId].ToString());
                        evento.Ubicacion = (UbicacionM7)baseDeDatosUbicacion.ConsultarXId(idUbicacion);

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
                throw new ExceptionSKDConexionBD(RecursoGeneralBD.Codigo,RecursoGeneralBD.Mensaje, ex);
            }
            catch (NumeroEnteroInvalidoException ex)
            {
                throw new NumeroEnteroInvalidoException(RecursosDAOModulo7.Codigo_Numero_Parametro_Invalido,
                                RecursosDAOModulo7.Mensaje_Numero_Parametro_invalido, new Exception());
            }
            catch (FormatException ex)
            {
                throw new NumeroEnteroInvalidoException(RecursosDAOModulo7.Codigo_Numero_Parametro_Invalido,
                                RecursosDAOModulo7.Mensaje_Numero_Parametro_invalido, new Exception());
            }
            catch (ExceptionSKDConexionBD ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw new ExceptionSKD(RecursosDAOModulo7.MensajeExceptionSKD, ex);
            }

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
            List<Parametro> parametros;
            Parametro parametroQuery = new Parametro();
            FabricaEntidades fabricaEntidades = new FabricaEntidades();
            EventoM7 idEvento = (EventoM7)parametro;
            EventoM7 evento = (EventoM7)FabricaEntidades.ObtenerEventoM7();

            DaoUbicacion baseDeDatosUbicacion = FabricaDAOSqlServer.ObtenerDaoUbicacionM7();
            DaoHorario baseDeDatosHorario = FabricaDAOSqlServer.ObtenerDaoHorarioM7();
            DaoTipoEvento baseDeDatosTipoEvento = FabricaDAOSqlServer.ObtenerDaoTipoEventoM7();

            try
            {
                if (idEvento.Id > 0)
                {
                    parametros = new List<Parametro>();
                    parametroQuery = new Parametro(RecursosDAOModulo7.ParamIdEvento, SqlDbType.Int, idEvento.Id.ToString(), false);
                    parametros.Add(parametroQuery);

                    DataTable dt = this.EjecutarStoredProcedureTuplas(
                                    RecursosDAOModulo7.ConsultarEventoXId, parametros);

                    foreach (DataRow row in dt.Rows)
                    {

                        evento.Id = int.Parse(row[RecursosDAOModulo7.AliasIdEvento].ToString());
                        evento.Nombre = row[RecursosDAOModulo7.AliasEventoNombre].ToString();
                        evento.Descripcion = row[RecursosDAOModulo7.AliasDescripcionEvento].ToString();
                        evento.Costo = float.Parse(row[RecursosDAOModulo7.AliasEventoCosto].ToString());

                        TipoEventoM7 idTipoEvento = (TipoEventoM7)FabricaEntidades.ObtenerTipoEventoM7();
                        idTipoEvento.Id = int.Parse(row[RecursosDAOModulo7.AliasEventoTipoEveId].ToString());
                        evento.TipoEvento = (TipoEventoM7)baseDeDatosTipoEvento.ConsultarXId(idTipoEvento);

                        HorarioM7 idHorario = (HorarioM7)FabricaEntidades.ObtenerHorarioM7();
                        idHorario.Id = int.Parse(row[RecursosDAOModulo7.AliasEventoHorarioId].ToString());
                        evento.Horario = (HorarioM7)baseDeDatosHorario.ConsultarXId(idHorario);

                        UbicacionM7 idUbicacion = (UbicacionM7)FabricaEntidades.ObtenerUbicacionM7();
                        idUbicacion.Id = int.Parse(row[RecursosDAOModulo7.AliasEventoUbicacionId].ToString());
                        evento.Ubicacion = (UbicacionM7)baseDeDatosUbicacion.ConsultarXId(idUbicacion);
                      
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
                throw new ExceptionSKDConexionBD(RecursoGeneralBD.Codigo,RecursoGeneralBD.Mensaje, ex);
            }
            catch (NumeroEnteroInvalidoException ex)
            {
                throw new NumeroEnteroInvalidoException(RecursosDAOModulo7.Codigo_Numero_Parametro_Invalido,
                                 RecursosDAOModulo7.Mensaje_Numero_Parametro_invalido, new Exception());
            }
            catch (FormatException ex)
            {
                throw new NumeroEnteroInvalidoException(RecursosDAOModulo7.Codigo_Numero_Parametro_Invalido,
                                 RecursosDAOModulo7.Mensaje_Numero_Parametro_invalido, new Exception());
            }
            catch (ExceptionSKDConexionBD ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw new ExceptionSKD(RecursosDAOModulo7.MensajeExceptionSKD, ex);
            }

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
            List<Parametro> parametros;
            Parametro parametroPersona = new Parametro();
            Parametro parametroCompetencia = new Parametro();
            DateTime fechaInscripcionCompetencia = new DateTime();
            PersonaM7 idPersona = (PersonaM7)persona;
            CompetenciaM7 idCompetencia = (CompetenciaM7)competencia;

            try
            {
                if (idPersona.Id > 0 && idCompetencia.Id > 0)
                {
                    parametros = new List<Parametro>();
                    parametroPersona = new Parametro(RecursosDAOModulo7.ParamIdPersona, SqlDbType.Int, idPersona.Id.ToString(), false);
                    parametroCompetencia = new Parametro(RecursosDAOModulo7.ParamIdCompetenciaPaga, SqlDbType.Int, idCompetencia.Id.ToString(), false);
                    parametros.Add(parametroPersona);
                    parametros.Add(parametroCompetencia);

                    DataTable dt = this.EjecutarStoredProcedureTuplas(
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
                throw new ExceptionSKDConexionBD(RecursoGeneralBD.Codigo,
                    RecursoGeneralBD.Mensaje, ex);
            }
            catch (NumeroEnteroInvalidoException ex)
            {
                throw new NumeroEnteroInvalidoException(RecursosDAOModulo7.Codigo_Numero_Parametro_Invalido,
                                RecursosDAOModulo7.Mensaje_Numero_Parametro_invalido, new Exception());
            }
            catch (FormatException ex)
            {
                throw new NumeroEnteroInvalidoException(RecursosDAOModulo7.Codigo_Numero_Parametro_Invalido,
                                RecursosDAOModulo7.Mensaje_Numero_Parametro_invalido, new Exception());
            }
            catch (ExceptionSKDConexionBD ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                throw new ExceptionSKD(RecursosDAOModulo7.MensajeExceptionSKD, ex);
            }

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
            List<Parametro> parametros;
            Parametro parametroPersona = new Parametro();
            Parametro parametroEvento = new Parametro();
            DateTime fechaInscripcion = new DateTime();
            PersonaM7 idPersona = (PersonaM7)persona;
            EventoM7 idEvento = (EventoM7)evento;

            try
            {
                if (idPersona.Id > 0 && idEvento.Id > 0)
                {
                    parametros = new List<Parametro>();
                    parametroPersona = new Parametro(RecursosDAOModulo7.ParamIdPersona, SqlDbType.Int, idPersona.Id.ToString(), false);
                    parametroEvento = new Parametro(RecursosDAOModulo7.ParamIdEvento, SqlDbType.Int, idEvento.Id.ToString(), false);
                    parametros.Add(parametroPersona);
                    parametros.Add(parametroEvento);

                    DataTable dt = this.EjecutarStoredProcedureTuplas(
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
                throw new ExceptionSKDConexionBD(RecursoGeneralBD.Codigo,
                    RecursoGeneralBD.Mensaje, ex);
            }
            catch (NumeroEnteroInvalidoException ex)
            {
                throw new NumeroEnteroInvalidoException(RecursosDAOModulo7.Codigo_Numero_Parametro_Invalido,
                                RecursosDAOModulo7.Mensaje_Numero_Parametro_invalido, new Exception());
            }
            catch (FormatException ex)
            {
                throw new NumeroEnteroInvalidoException(RecursosDAOModulo7.Codigo_Numero_Parametro_Invalido,
                                RecursosDAOModulo7.Mensaje_Numero_Parametro_invalido, new Exception());
            }
            catch (ExceptionSKDConexionBD ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw new ExceptionSKD(RecursosDAOModulo7.MensajeExceptionSKD, ex);
            }

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
            List<Parametro> parametros;
            Parametro parametroPersona = new Parametro();
            Parametro parametroEvento = new Parametro();
            DateTime fechaPago = new DateTime();
            PersonaM7 idPersona = (PersonaM7)persona;
            EventoM7 idEvento = (EventoM7)evento;

            try
            {
                if (idPersona.Id > 0 && idEvento.Id > 0)
                {
                    parametros = new List<Parametro>();
                    parametroPersona = new Parametro(RecursosDAOModulo7.ParamIdPersona, SqlDbType.Int, idPersona.Id.ToString(), false);
                    parametroEvento = new Parametro(RecursosDAOModulo7.ParamIdEvento, SqlDbType.Int, idEvento.Id.ToString(), false);
                    parametros.Add(parametroPersona);
                    parametros.Add(parametroEvento);

                    DataTable dt = this.EjecutarStoredProcedureTuplas(
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
                throw new ExceptionSKDConexionBD(RecursoGeneralBD.Codigo,
                    RecursoGeneralBD.Mensaje, ex);
            }
            catch (NumeroEnteroInvalidoException ex)
            {
                throw new NumeroEnteroInvalidoException(RecursosDAOModulo7.Codigo_Numero_Parametro_Invalido,
                                RecursosDAOModulo7.Mensaje_Numero_Parametro_invalido, new Exception());
            }
            catch (FormatException ex)
            {
                throw new NumeroEnteroInvalidoException(RecursosDAOModulo7.Codigo_Numero_Parametro_Invalido,
                                RecursosDAOModulo7.Mensaje_Numero_Parametro_invalido, new Exception());
            }
            catch (ExceptionSKDConexionBD ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw new ExceptionSKD(RecursosDAOModulo7.MensajeExceptionSKD, ex);
            }

            return fechaPago;
        }

        /// <summary>
        /// Método para consultar la lista de competencias pagas
        /// </summary>
        /// <param name="persona">Objeto de tipo Entidad que posee el id de la persona</param>
        /// <returns>Retorna lista con objetos de tipo Entidad con la lista de competencias que han sido canceladas</returns>
        public List<Entidad> ListarCompetenciasPaga(Entidad persona)
        {
            List<Parametro> parametros;
            Parametro parametroQuery = new Parametro();        
            List<Entidad> listaDeCompetenciasPagas= new List<Entidad>();
            PersonaM7 idPersona = (PersonaM7)persona;

            try
            {
                if (idPersona.Id > 0)
                {
                    parametros = new List<Parametro>();
                    parametroQuery = new Parametro(RecursosDAOModulo7.ParamIdUsuarioLogueado, SqlDbType.Int, idPersona.Id.ToString(), false);
                    parametros.Add(parametroQuery);

                    DataTable dt = this.EjecutarStoredProcedureTuplas(
                                   RecursosDAOModulo7.ConsultarCompetenciasInscritas, parametros);


                    foreach (DataRow row in dt.Rows)
                    {
                        CompetenciaM7 competencia = (CompetenciaM7)FabricaEntidades.ObtenerCompetenciaM7();

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
                throw new ExceptionSKDConexionBD(RecursoGeneralBD.Codigo,RecursoGeneralBD.Mensaje, ex);
            }
            catch (NumeroEnteroInvalidoException ex)
            {
                throw new NumeroEnteroInvalidoException(RecursosDAOModulo7.Codigo_Numero_Parametro_Invalido,
                                RecursosDAOModulo7.Mensaje_Numero_Parametro_invalido, new Exception());

            }
            catch (FormatException ex)
            {
                throw new NumeroEnteroInvalidoException(RecursosDAOModulo7.Codigo_Numero_Parametro_Invalido,
                                RecursosDAOModulo7.Mensaje_Numero_Parametro_invalido, new Exception());
            }
            catch (ExceptionSKDConexionBD ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw new ExceptionSKD(RecursosDAOModulo7.MensajeExceptionSKD, ex);
            }

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
            List<Parametro> parametros;
            Parametro parametroQuery = new Parametro();
            List<Entidad> listaDeEventos = new List<Entidad>();
            PersonaM7 idPersona = (PersonaM7)persona;
            DaoTipoEvento baseDeDatosTipoEvento = FabricaDAOSqlServer.ObtenerDaoTipoEventoM7();

            try
            {
                if (idPersona.Id > 0)
                {
                    parametros = new List<Parametro>();
                    parametroQuery = new Parametro(RecursosDAOModulo7.ParamIdUsuarioLogueado, SqlDbType.Int, idPersona.Id.ToString(), false);
                    parametros.Add(parametroQuery);

                    DataTable dt = this.EjecutarStoredProcedureTuplas(
                                   RecursosDAOModulo7.ConsultarEventosPagos, parametros);


                    foreach (DataRow row in dt.Rows)
                    {
                        EventoM7 evento  = (EventoM7)FabricaEntidades.ObtenerEventoM7();
                        evento.Id = int.Parse(row[RecursosDAOModulo7.AliasIdEvento].ToString());
                        evento.Nombre = row[RecursosDAOModulo7.AliasEventoNombre].ToString();

                        TipoEventoM7 idTipoEvento = (TipoEventoM7)FabricaEntidades.ObtenerTipoEventoM7();
                        idTipoEvento.Id = int.Parse(row[RecursosDAOModulo7.AliasEventoTipoEveId].ToString());
                        evento.TipoEvento = (TipoEventoM7)baseDeDatosTipoEvento.ConsultarXId(idTipoEvento);
                     
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
                throw new ExceptionSKDConexionBD(RecursoGeneralBD.Codigo,
                    RecursoGeneralBD.Mensaje, ex);
            }
            catch (NumeroEnteroInvalidoException ex)
            {
                throw new NumeroEnteroInvalidoException(RecursosDAOModulo7.Codigo_Numero_Parametro_Invalido,
                                RecursosDAOModulo7.Mensaje_Numero_Parametro_invalido, new Exception());

            }
            catch (FormatException ex)
            {
                throw new NumeroEnteroInvalidoException(RecursosDAOModulo7.Codigo_Numero_Parametro_Invalido,
                                RecursosDAOModulo7.Mensaje_Numero_Parametro_invalido, new Exception());
            }
            catch (ExceptionSKDConexionBD ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw new ExceptionSKD(RecursosDAOModulo7.MensajeExceptionSKD, ex);
            }

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
            List<Parametro> parametros;
            Parametro parametroPersona = new Parametro();
            Parametro parametroEvento = new Parametro();
            float monto = new float();
            PersonaM7 idPersona = (PersonaM7)persona;
            EventoM7 idEvento = (EventoM7)evento;
       
            try
            {
                if (idPersona.Id > 0 && idEvento.Id > 0)
                {
                    parametros = new List<Parametro>();
                    parametroPersona = new Parametro(RecursosDAOModulo7.ParamIdPersona, SqlDbType.Int, idPersona.Id.ToString(), false);
                    parametroEvento = new Parametro(RecursosDAOModulo7.ParamIdEvento, SqlDbType.Int, idEvento.Id.ToString(), false);
                    parametros.Add(parametroPersona);
                    parametros.Add(parametroEvento);

                    DataTable dt = this.EjecutarStoredProcedureTuplas(
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
                throw new ExceptionSKDConexionBD(RecursoGeneralBD.Codigo,RecursoGeneralBD.Mensaje, ex);
            }
            catch (NumeroEnteroInvalidoException ex)
            {
                throw new NumeroEnteroInvalidoException(RecursosDAOModulo7.Codigo_Numero_Parametro_Invalido,
                                RecursosDAOModulo7.Mensaje_Numero_Parametro_invalido, new Exception());
            }
            catch (FormatException ex)
            {
                throw new NumeroEnteroInvalidoException(RecursosDAOModulo7.Codigo_Numero_Parametro_Invalido,
                                RecursosDAOModulo7.Mensaje_Numero_Parametro_invalido, new Exception());
            }
            catch (ExceptionSKDConexionBD ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw new ExceptionSKD(RecursosDAOModulo7.MensajeExceptionSKD, ex);
            }

            return monto;
        
        }
    }
}
