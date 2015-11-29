using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Configuration;
using DominioSKD;

namespace DatosSKD.Modulo7
{
    public class BDEvento
    {

        /// <summary>
        /// Método que consulta en la BD para detallar un evento
        /// </summary>
        /// <param name="idEvento">Número entero que representa el ID del evento</param>
        /// <returns>Objeto de tipo Evento</returns>
        public static Evento DetallarEvento(int idEvento)
        {
            BDConexion laConexion;
            List<Parametro> parametros;
            Parametro elParametro = new Parametro();

            try
            {
                laConexion = new BDConexion();
                parametros = new List<Parametro>();
                Evento evento = new Evento();

                elParametro = new Parametro(RecursosBDModulo7.ParamIdEvento, SqlDbType.Int, idEvento.ToString(), false);
                parametros.Add(elParametro);

                DataTable dt = laConexion.EjecutarStoredProcedureTuplas(
                               RecursosBDModulo7.ConsultarEventoXId, parametros);

                foreach (DataRow row in dt.Rows)
                {

                    evento.Id_evento = int.Parse(row[RecursosBDModulo7.AliasIdEvento].ToString());
                    evento.Nombre = row[RecursosBDModulo7.AliasEventoNombre].ToString();
                    evento.Descripcion = row[RecursosBDModulo7.AliasDescripcionEvento].ToString();
                    evento.Costo = float.Parse(row[RecursosBDModulo7.AliasEventoCosto].ToString());
                    evento.TipoEvento = BDTipoEvento.DetallarTipoEvento(int.Parse(row[RecursosBDModulo7.AliasEventoTipoEveId].ToString()));
                    evento.Horario = BDHorario.DetallarHorario(int.Parse(row[RecursosBDModulo7.AliasEventoHorarioId].ToString()));
                    evento.Ubicacion = BDUbicacion.DetallarUbicacion(int.Parse(row[RecursosBDModulo7.AliasEventoUbicacionId].ToString()));

                }

                return evento;

            }
            catch (SqlException ex)
            {
                throw new ExcepcionesSKD.ExceptionSKDConexionBD(RecursoGeneralBD.Codigo,
                    RecursoGeneralBD.Mensaje, ex);
            }/*
            catch (ExcepcionesSKD.Modulo12.CompetenciaInexistenteException ex)
            {
                throw ex;
            }*/
            catch (ExcepcionesSKD.ExceptionSKDConexionBD ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw new ExcepcionesSKD.ExceptionSKD("No se pudo completar la operacion", ex);
            }


        }


        /// <summary>
        /// Método para listar las competencias asistidas del atleta
        /// </summary>
        /// <returns>Lista de competencias</returns>
        public static List<Competencia> ListarCompetenciasAsistidas()
        {
            int idPersona = 1;
            BDConexion laConexion;
            List<Parametro> parametros;
            Parametro elParametro = new Parametro();
            List<Competencia> laListaDeCompetenciasAsistidas = new List<Competencia>();

            try
            {
                laConexion = new BDConexion();
                parametros = new List<Parametro>();

                elParametro = new Parametro(RecursosBDModulo7.ParamIdPersona, SqlDbType.Int, idPersona.ToString(), false);
                parametros.Add(elParametro);

                DataTable dt = laConexion.EjecutarStoredProcedureTuplas(
                               RecursosBDModulo7.ConsultarCompetenciasAsistidas, parametros);

                foreach (DataRow row in dt.Rows)
                {
                    Competencia competencia = new Competencia();
                    competencia.Id_competencia = int.Parse(row[RecursosBDModulo7.AliasIdCompetencia].ToString());
                    competencia.Nombre = row[RecursosBDModulo7.AliasCompetenciaNombre].ToString();
                    if (int.Parse(row[RecursosBDModulo7.AliasCompetenciaTipo].ToString()).Equals(1))                   
                        competencia.TipoCompetencia = RecursosBDModulo7.AliasCompetenciaKata;
                    else if (int.Parse(row[RecursosBDModulo7.AliasCompetenciaTipo].ToString()).Equals(2))
                        competencia.TipoCompetencia = RecursosBDModulo7.AliasCompetenciaKumite;
                    else if (int.Parse(row[RecursosBDModulo7.AliasCompetenciaTipo].ToString()).Equals(3))
                        competencia.TipoCompetencia = RecursosBDModulo7.AliasCompetenciaKataKumite;
                    competencia.FechaInicio = DateTime.Parse(row[RecursosBDModulo7.AliasCompetenciaFechaInicio].ToString());
                    competencia.Costo = int.Parse(row[RecursosBDModulo7.AliasCompetenciaCosto].ToString());
                    competencia.Ubicacion = BDUbicacion.DetallarUbicacion(int.Parse(row[RecursosBDModulo7.AliasCompetenciaUbicacionId].ToString()));
                    laListaDeCompetenciasAsistidas.Add(competencia);
                }

                return laListaDeCompetenciasAsistidas;

            }
            catch (SqlException ex)
            {
                throw new ExcepcionesSKD.ExceptionSKDConexionBD(RecursoGeneralBD.Codigo,
                    RecursoGeneralBD.Mensaje, ex);
            }/*
            catch (ExcepcionesSKD.Modulo12.CompetenciaInexistenteException ex)
            {
                throw ex;
            }*/
            catch (ExcepcionesSKD.ExceptionSKDConexionBD ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw new ExcepcionesSKD.ExceptionSKD("No se pudo completar la operacion", ex);
            }
        }


        /// <summary>
        /// Método para listar las competencias inscritas del atleta
        /// </summary>
        /// <returns>Lista de competencias</returns>
        public static List<Competencia> ListarCompetenciasInscritas()
        {
            int idPersona = 1;
            BDConexion laConexion;
            List<Parametro> parametros;
            Parametro elParametro = new Parametro();
            List<Competencia> laListaDeCompetenciasInscritas = new List<Competencia>();

            try
            {
                laConexion = new BDConexion();
                parametros = new List<Parametro>();

                elParametro = new Parametro(RecursosBDModulo7.ParamIdUsuarioLogueado, SqlDbType.Int, idPersona.ToString(), false);
                parametros.Add(elParametro);

                DataTable dt = laConexion.EjecutarStoredProcedureTuplas(
                               RecursosBDModulo7.ConsultarCompetenciasInscritas, parametros);

                foreach (DataRow row in dt.Rows)
                {
                    Competencia competencia = new Competencia();
                    competencia.Id_competencia = int.Parse(row[RecursosBDModulo7.AliasIdCompetencia].ToString());
                    competencia.Nombre = row[RecursosBDModulo7.AliasCompetenciaNombre].ToString();
                              if (int.Parse(row[RecursosBDModulo7.AliasCompetenciaTipo].ToString()).Equals(1))
                    competencia.TipoCompetencia = RecursosBDModulo7.AliasCompetenciaKata;
                         else if (int.Parse(row[RecursosBDModulo7.AliasCompetenciaTipo].ToString()).Equals(2))
                    competencia.TipoCompetencia = RecursosBDModulo7.AliasCompetenciaKumite;
                        else if (int.Parse(row[RecursosBDModulo7.AliasCompetenciaTipo].ToString()).Equals(3))
                    competencia.TipoCompetencia = RecursosBDModulo7.AliasCompetenciaKataKumite;
                    competencia.FechaInicio = DateTime.Parse(row[RecursosBDModulo7.AliasCompetenciaFechaInicio].ToString());
                    competencia.Costo = int.Parse(row[RecursosBDModulo7.AliasCompetenciaCosto].ToString());
                    competencia.Ubicacion = BDUbicacion.DetallarUbicacion(int.Parse(row[RecursosBDModulo7.AliasCompetenciaUbicacionId].ToString()));
                    laListaDeCompetenciasInscritas.Add(competencia);
                }

                return laListaDeCompetenciasInscritas;

            }
            catch (SqlException ex)
            {
                throw new ExcepcionesSKD.ExceptionSKDConexionBD(RecursoGeneralBD.Codigo,
                    RecursoGeneralBD.Mensaje, ex);
            }/*
            catch (ExcepcionesSKD.Modulo12.CompetenciaInexistenteException ex)
            {
                throw ex;
            }*/
            catch (ExcepcionesSKD.ExceptionSKDConexionBD ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw new ExcepcionesSKD.ExceptionSKD("No se pudo completar la operacion", ex);
            }
        }
        /// <summary>
        /// Método para listar los eventos asistidos del atleta
        /// </summary>
        /// <returns>Lista de eventos</returns>
        public static List<Evento> ListarEventosAsistidos()
        {
            int idPersona = 1;
            BDConexion laConexion;
            List<Parametro> parametros;
            Parametro elParametro = new Parametro();
            List<Evento> laListaDeEventoAsistidos = new List<Evento>();

            try
            {
                laConexion = new BDConexion();
                parametros = new List<Parametro>();
                
                elParametro = new Parametro(RecursosBDModulo7.ParamIdPersona, SqlDbType.Int, idPersona.ToString(),false);
                parametros.Add(elParametro);

                DataTable dt = laConexion.EjecutarStoredProcedureTuplas(
                               RecursosBDModulo7.ConsultarEventosAsistidos, parametros);

                foreach (DataRow row in dt.Rows)
                {
                    Evento evento = new Evento();
                    evento.Id_evento = int.Parse(row[RecursosBDModulo7.AliasIdEvento].ToString());
                    evento.Nombre = row[RecursosBDModulo7.AliasEventoNombre].ToString();
                    evento.Descripcion = row[RecursosBDModulo7.AliasDescripcionEvento].ToString();
                    evento.Costo = float.Parse(row[RecursosBDModulo7.AliasEventoCosto].ToString());
                    evento.TipoEvento = BDTipoEvento.DetallarTipoEvento(int.Parse(row[RecursosBDModulo7.AliasEventoTipoEveId].ToString()));
                    evento.Horario = BDHorario.DetallarHorario(int.Parse(row[RecursosBDModulo7.AliasEventoHorarioId].ToString()));
                    evento.Ubicacion = BDUbicacion.DetallarUbicacion(int.Parse(row[RecursosBDModulo7.AliasEventoUbicacionId].ToString()));
                    laListaDeEventoAsistidos.Add(evento);
                }

                return laListaDeEventoAsistidos; 

            }
            catch (SqlException ex)
            {
                throw new ExcepcionesSKD.ExceptionSKDConexionBD(RecursoGeneralBD.Codigo,
                    RecursoGeneralBD.Mensaje, ex);
            }/*
            catch (ExcepcionesSKD.Modulo12.CompetenciaInexistenteException ex)
            {
                throw ex;
            }*/
            catch (ExcepcionesSKD.ExceptionSKDConexionBD ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw new ExcepcionesSKD.ExceptionSKD("No se pudo completar la operacion", ex);
            }
        }

        /// <summary>
        /// Método que devuelve la fecha de una inscripción
        /// </summary>
        /// <returns>Fecha de inscripción</returns>
        public static DateTime fechaInscripcion(int idPersona, int idEvento)
        {

            BDConexion laConexion;
            List<Parametro> parametros;
            Parametro elParametroPersona = new Parametro();
            Parametro elParametroEvento = new Parametro();
            DateTime fechaInscripcion = new DateTime();

            try
            {
                laConexion = new BDConexion();
                parametros = new List<Parametro>();

                elParametroPersona = new Parametro(RecursosBDModulo7.ParamIdPersona, SqlDbType.Int, idPersona.ToString(), false);
                elParametroEvento = new Parametro(RecursosBDModulo7.ParamIdEvento, SqlDbType.Int, idEvento.ToString(), false);
                parametros.Add(elParametroPersona);
                parametros.Add(elParametroEvento);

                DataTable dt = laConexion.EjecutarStoredProcedureTuplas(
                               RecursosBDModulo7.ConsultarFechaInscripcion, parametros);

                foreach (DataRow row in dt.Rows)
                {
                    fechaInscripcion = DateTime.Parse(row[RecursosBDModulo7.AliasInscripcionFecha].ToString());
                }

                return fechaInscripcion;

            }
            catch (SqlException ex)
            {
                throw new ExcepcionesSKD.ExceptionSKDConexionBD(RecursoGeneralBD.Codigo,
                    RecursoGeneralBD.Mensaje, ex);
            }/*
            catch (ExcepcionesSKD.Modulo12.CompetenciaInexistenteException ex)
            {
                throw ex;
            }*/
            catch (ExcepcionesSKD.ExceptionSKDConexionBD ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw new ExcepcionesSKD.ExceptionSKD("No se pudo completar la operacion", ex);
            }
        }

        /// <summary>
        /// Metodo que lista los eventos a los cuales estan inscritos los atletas
        /// </summary>
        /// <returns>Lista de Evento Isncrito</returns>
        public static List<Evento> ListarEventosInscritos()
        {
            int idPersona = 1;
            BDConexion laConexion;
            List<Parametro> parametros;
            Parametro elParametro = new Parametro();
            List<Evento> laListaDeEventoInscrito = new List<Evento>();

            try
            {
                laConexion = new BDConexion();
                parametros = new List<Parametro>();


                elParametro = new Parametro(RecursosBDModulo7.ParamIdUsuarioLogueado, SqlDbType.Int, idPersona.ToString(), false);
                parametros.Add(elParametro);

                DataTable dt = laConexion.EjecutarStoredProcedureTuplas(
                               RecursosBDModulo7.ConsultarEventosInscritos, parametros);

                foreach (DataRow row in dt.Rows){
                        Evento evento = new Evento();
                        evento.Id_evento = int.Parse(row[RecursosBDModulo7.AliasIdEvento].ToString());
                        evento.Nombre = row[RecursosBDModulo7.AliasEventoNombre].ToString();
                        evento.Descripcion = row[RecursosBDModulo7.AliasDescripcionEvento].ToString();
                        evento.TipoEvento = BDTipoEvento.DetallarTipoEvento(int.Parse(row[RecursosBDModulo7.AliasEventoTipoEveId].ToString()));
                        evento.Horario = BDHorario.DetallarHorario(int.Parse(row[RecursosBDModulo7.AliasEventoHorarioId].ToString()));
                        evento.Ubicacion = BDUbicacion.DetallarUbicacion(int.Parse(row[RecursosBDModulo7.AliasEventoUbicacionId].ToString()));
                        laListaDeEventoInscrito.Add(evento);
                }
           
                return laListaDeEventoInscrito;
            }
            catch (SqlException ex)
            {
                throw new ExcepcionesSKD.ExceptionSKDConexionBD(RecursoGeneralBD.Codigo,
                    RecursoGeneralBD.Mensaje, ex);
            }/*
            catch (ExcepcionesSKD.Modulo12.CompetenciaInexistenteException ex)
            {
                throw ex;
            }*/
            catch (ExcepcionesSKD.ExceptionSKDConexionBD ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw new ExcepcionesSKD.ExceptionSKD("No se pudo completar la operacion", ex);
            }
        }

   ///Metodo que lista los eventos pagos del atleta
        public static List<Evento> ListarEventosPagos()
        {
            
            int idPersona = 1;
            BDConexion laConexion;
            List<Parametro> parametros;
            Parametro elParametro = new Parametro();
            List<Evento> laListaDeEventoPago = new List<Evento>();

            try
            {
                laConexion = new BDConexion();
                parametros = new List<Parametro>();


                elParametro = new Parametro(RecursosBDModulo7.ParamIdPersona, SqlDbType.Int, idPersona.ToString(), false);
                parametros.Add(elParametro);

                DataTable dt = laConexion.EjecutarStoredProcedureTuplas(
                               RecursosBDModulo7.ConsultarEventosPagos,parametros);

                foreach (DataRow row in dt.Rows)
                {
                    Evento evento = new Evento();
                    evento.Id_evento = int.Parse(row[RecursosBDModulo7.AliasIdEvento].ToString());
                    evento.Nombre = row[RecursosBDModulo7.AliasEventoNombre].ToString();
                    evento.Descripcion = row[RecursosBDModulo7.AliasDescripcionEvento].ToString();
                    evento.Costo = float.Parse(row[RecursosBDModulo7.AliasEventoCosto].ToString());
                    evento.TipoEvento = BDTipoEvento.DetallarTipoEvento(int.Parse(row[RecursosBDModulo7.AliasEventoTipoEveId].ToString()));
                    evento.Horario = BDHorario.DetallarHorario(int.Parse(row[RecursosBDModulo7.AliasEventoHorarioId].ToString()));
                    evento.Ubicacion = BDUbicacion.DetallarUbicacion(int.Parse(row[RecursosBDModulo7.AliasEventoUbicacionId].ToString()));
                    laListaDeEventoPago.Add(evento);
                }

                return laListaDeEventoPago;

            }
            catch (SqlException ex)
            {
                throw new ExcepcionesSKD.ExceptionSKDConexionBD(RecursoGeneralBD.Codigo,
                    RecursoGeneralBD.Mensaje, ex);
            }
            catch (ExcepcionesSKD.ExceptionSKDConexionBD ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw new ExcepcionesSKD.ExceptionSKD("No se pudo completar la operacion", ex);
            }


            //return laListaDeEventosPagos;
        }

        /// <summary>
        /// Metodo que lista los eventos a los cuales estan inscritos los atletas
        /// </summary>
        /// <returns>Lista de los horarios de practica</returns>
     
        public static List<Evento> ListarHorarioPractica()
        {
            int idPersona = 1;
            BDConexion laConexion;
            List<Parametro> parametros;
            Parametro elParametro = new Parametro();
            List<Evento> laListaDeHorarioPractica = new List<Evento>();

            try
            {
                laConexion = new BDConexion();
                parametros = new List<Parametro>();


                elParametro = new Parametro(RecursosBDModulo7.ParamIdUsuarioLogueado, SqlDbType.Int, idPersona.ToString(), false);
                parametros.Add(elParametro);

                DataTable dt = laConexion.EjecutarStoredProcedureTuplas(
                               RecursosBDModulo7.ConsultarHorarioPractica, parametros);

                foreach (DataRow row in dt.Rows)
                {
                        Evento evento = new Evento();
                        evento.Id_evento = int.Parse(row[RecursosBDModulo7.AliasIdEvento].ToString());
                        evento.Nombre = row[RecursosBDModulo7.AliasEventoNombre].ToString();
                        evento.Descripcion = row[RecursosBDModulo7.AliasDescripcionEvento].ToString();
                        evento.TipoEvento = BDTipoEvento.DetallarTipoEvento(int.Parse(row[RecursosBDModulo7.AliasEventoTipoEveId].ToString()));
                        evento.Horario = BDHorario.DetallarHorario(int.Parse(row[RecursosBDModulo7.AliasEventoHorarioId].ToString()));
                        evento.Ubicacion = BDUbicacion.DetallarUbicacion(int.Parse(row[RecursosBDModulo7.AliasEventoUbicacionId].ToString()));
                        laListaDeHorarioPractica.Add(evento);
                }

            return laListaDeHorarioPractica;
               }
            catch (SqlException ex)
            {
                throw new ExcepcionesSKD.ExceptionSKDConexionBD(RecursoGeneralBD.Codigo,
                    RecursoGeneralBD.Mensaje, ex);
            }/*
            catch (ExcepcionesSKD.Modulo12.CompetenciaInexistenteException ex)
            {
                throw ex;
            }*/
            catch (ExcepcionesSKD.ExceptionSKDConexionBD ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw new ExcepcionesSKD.ExceptionSKD("No se pudo completar la operacion", ex);
            }
        }


    }
}
