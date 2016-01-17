using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using DominioSKD;
using DominioSKD;

namespace DatosSKD.Modulo9
{

    public class BDEvento
    {

        /// <summary>
        /// Metodo que permite agregar un Evento a la BD
        /// </summary>
        /// <param name="evento">El Evento a Agregar</param>
        /// <returns>Retorna true o false</returns>
        public bool CrearEvento(Evento evento)
        {
            try
            {
                //parametros para insertar un evento
                List<Parametro> parametros = new List<Parametro>();
                Parametro parametro = new Parametro(RecursosBDModulo9.ParametroNombreEvento, SqlDbType.VarChar, evento.Nombre, false);
                parametros.Add(parametro);
                parametro = new Parametro(RecursosBDModulo9.ParametroDescripcionEvento, SqlDbType.VarChar, evento.Descripcion, false);
                parametros.Add(parametro);
                parametro = new Parametro(RecursosBDModulo9.ParametroCostoEvento, SqlDbType.Float, evento.Costo.ToString(), false);
                parametros.Add(parametro);
                parametro = new Parametro(RecursosBDModulo9.ParametroEstadoEvento, SqlDbType.VarChar, evento.Estado.ToString(), false);
                parametros.Add(parametro);
                parametro = new Parametro(RecursosBDModulo9.ParametroIdPersona, SqlDbType.Int, evento.Persona.ID.ToString(), false);
                parametros.Add(parametro);
                parametro = new Parametro(RecursosBDModulo9.ParametroIdUbicacion, SqlDbType.Int, evento.Ubicacion.Id_ubicacion.ToString(), false);
                parametros.Add(parametro);
                parametro = new Parametro(RecursosBDModulo9.ParametroIdTipoEvento, SqlDbType.Int, evento.TipoEvento.Id.ToString(), false);
                parametros.Add(parametro);
                parametro = new Parametro(RecursosBDModulo9.ParametroIdCategoria, SqlDbType.Int, evento.Categoria.Id_categoria.ToString(), false);
                parametros.Add(parametro);
                parametro = new Parametro(RecursosBDModulo9.ParametroFechaInicio, SqlDbType.Date, evento.Horario.FechaInicio.ToString(), false);
                parametros.Add(parametro);
                parametro = new Parametro(RecursosBDModulo9.ParametroFechaFin, SqlDbType.Date, evento.Horario.FechaFin.ToString(), false);
                parametros.Add(parametro);
                parametro = new Parametro(RecursosBDModulo9.ParametroHoraInicio, SqlDbType.Int, evento.Horario.HoraInicio.ToString(), false);
                parametros.Add(parametro);
                parametro = new Parametro(RecursosBDModulo9.ParametroHoraFin, SqlDbType.Int, evento.Horario.HoraFin.ToString(), false);
                parametros.Add(parametro);

                BDConexion con = new BDConexion();
                List<Resultado> resultados = con.EjecutarStoredProcedure(RecursosBDModulo9.ProcedimientoAgregarEvento, parametros);

                //si la creacion es correcta retorna true

                if (resultados != null)
                {
                    return true;
                }
                else
                {
                    return false;

                }

            }
            catch (SqlException ex)
            {
                throw new ExcepcionesSKD.ExceptionSKDConexionBD(RecursoGeneralBD.Codigo,
                    RecursoGeneralBD.Mensaje, ex);
            }
        }

        /// <summary>
        /// Metodo que permite obtener de base de datos todos los eventos de un administrador
        /// </summary>
        /// <returns>lista de eventos</returns>


        public List<Evento> ListarEventos()
        {
            BDConexion laConexion;
            List<Evento> listaEventos = new List<Evento>();
            List<Parametro> parametros;

            try
            {
                laConexion = new BDConexion();
                parametros = new List<Parametro>();
                DataTable dt = laConexion.EjecutarStoredProcedureTuplas(RecursosBDModulo9.ProcedimientoConsultarEventos, parametros);
                foreach (DataRow row in dt.Rows)
                {
                    Evento evento = new Evento();

                    evento.Id_evento = int.Parse(row[RecursosBDModulo9.AliasIdEvento].ToString());
                    //Console.Out.WriteLine(evento.Id_evento);
                    evento.Nombre = row[RecursosBDModulo9.AliasNombreEvento].ToString();
                    evento.Descripcion = row[RecursosBDModulo9.AliasDescripcionEvento].ToString();
                    evento.Estado = Boolean.Parse(row[RecursosBDModulo9.AliasEstadoEvento].ToString());
                    evento.Costo = float.Parse(row[RecursosBDModulo9.AliasCostoEvento].ToString());
                    Horario horario = new Horario();
                    horario.FechaInicio = DateTime.Parse(row[RecursosBDModulo9.AliasFechaInicio].ToString());
                    horario.FechaFin = DateTime.Parse(row[RecursosBDModulo9.AliasFechaFin].ToString());
                    horario.HoraInicio = int.Parse(row[RecursosBDModulo9.AliasHoraInicio].ToString());
                    horario.HoraFin = int.Parse(row[RecursosBDModulo9.AliasHoraFin].ToString());
                    TipoEvento tipoEvento = new TipoEvento();
                    tipoEvento.Nombre = row[RecursosBDModulo9.AliasTipoEvento].ToString();
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
                throw new ExcepcionesSKD.Modulo12.FormatoIncorrectoException(RecursosBDModulo9.CodigoErrorFormato,
                     RecursosBDModulo9.MensajeErrorFormato, ex);
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
        /// Metodo que permite Consultar un evento por id
        /// </summary>
        /// <param name="idEvento">Id del evento</param>
        /// <returns>Retorna un evento</returns>

        public Evento ConsultarEvento(String idEvento)
        {
            BDConexion laConexion;
            Evento evento;
            try
            {
                Console.Out.WriteLine(idEvento);
                laConexion = new BDConexion();
                evento = new Evento();
                List<Parametro> parametros = new List<Parametro>();
                Parametro parametro = new Parametro(RecursosBDModulo9.ParametroIdEvento, SqlDbType.Int, idEvento, false);
                /*Console.Out.WriteLine(parametro.valor);
                Console.Out.WriteLine(parametro.tipoDato);
                Console.Out.WriteLine(RecursosBDModulo9.ParametroIdEvento);*/
                parametros.Add(parametro);
                DataTable dt = laConexion.EjecutarStoredProcedureTuplas(RecursosBDModulo9.ProcedimentoConsultarEventoXID, parametros);
                
                foreach (DataRow row in dt.Rows)
                {
                    evento.Nombre = row[RecursosBDModulo9.AliasNombreEvento].ToString(); ;
                    Console.Out.WriteLine(evento.Nombre);
                    evento.Descripcion = row[RecursosBDModulo9.AliasDescripcionEvento].ToString();
                    evento.Estado = Boolean.Parse(row[RecursosBDModulo9.AliasEstadoEvento].ToString());
                    evento.Costo = float.Parse(row[RecursosBDModulo9.AliasCostoEvento].ToString());
                    Horario horario = new Horario();
                    horario.FechaInicio = DateTime.Parse(row[RecursosBDModulo9.AliasFechaInicio].ToString());
                    horario.FechaFin = DateTime.Parse(row[RecursosBDModulo9.AliasFechaFin].ToString());
                    horario.HoraInicio = int.Parse(row[RecursosBDModulo9.AliasHoraInicio].ToString());
                    horario.HoraFin = int.Parse(row[RecursosBDModulo9.AliasHoraFin].ToString());
                    TipoEvento tipoEvento = new TipoEvento();
                    tipoEvento.Nombre = row[RecursosBDModulo9.AliasTipoEvento].ToString();
                    evento.Horario = horario;
                    evento.TipoEvento = tipoEvento;
                }


            }
            catch (SqlException ex)
            {
                throw new ExcepcionesSKD.ExceptionSKDConexionBD(RecursoGeneralBD.Codigo,
                    RecursoGeneralBD.Mensaje, ex);
            }
            catch (FormatException ex)
            {
                throw new ExcepcionesSKD.Modulo12.FormatoIncorrectoException(RecursosBDModulo9.CodigoErrorFormato,
                     RecursosBDModulo9.MensajeErrorFormato, ex);
            }
            catch (ExcepcionesSKD.ExceptionSKDConexionBD ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw new ExcepcionesSKD.ExceptionSKD(RecursoGeneralBD.Mensaje_Generico_Error, ex);
            }
            return evento;


        }

        /// <summary>
        /// Metodo Solicitado por M10 que retorna todas las fechas donde hay eventos
        /// </summary>
        /// <returns>lista de horario</returns>

        public List<Horario> ListarHorarios()
        {
            BDConexion laConexion;
            List<Horario> listaHorarios = new List<Horario>();
            List<Parametro> parametros;

            try
            {
                laConexion = new BDConexion();
                parametros = new List<Parametro>();
                DataTable dt = laConexion.EjecutarStoredProcedureTuplas(RecursosBDModulo9.ProcedimientoConsultarHorarios, parametros);
                foreach (DataRow row in dt.Rows)
                {

                    Horario horario = new Horario();
                    horario.FechaInicio = DateTime.Parse(row[RecursosBDModulo9.AliasFechaInicio].ToString());
                    horario.FechaFin = DateTime.Parse(row[RecursosBDModulo9.AliasFechaFin].ToString());
                    horario.HoraInicio = int.Parse(row[RecursosBDModulo9.AliasHoraInicio].ToString());
                    horario.HoraFin = int.Parse(row[RecursosBDModulo9.AliasHoraFin].ToString());
                    listaHorarios.Add(horario);
                }

            }
            catch (SqlException ex)
            {
                throw new ExcepcionesSKD.ExceptionSKDConexionBD(RecursoGeneralBD.Codigo,
                    RecursoGeneralBD.Mensaje, ex);
            }
            catch (FormatException ex)
            {
                throw new ExcepcionesSKD.Modulo12.FormatoIncorrectoException(RecursosBDModulo9.CodigoErrorFormato,
                     RecursosBDModulo9.MensajeErrorFormato, ex);
            }
            catch (ExcepcionesSKD.ExceptionSKDConexionBD ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw new ExcepcionesSKD.ExceptionSKD(RecursoGeneralBD.Mensaje_Generico_Error, ex);
            }

            return listaHorarios;

        }

        /// <summary>
        /// Metodo solicitado por M10 que dado un rango de fechas retorna todos los eventos que estan en ese rango
        /// </summary>
        /// <param name="fechaInicio">fecha inicio</param>
        /// <param name="fechaFin">fecha fin</param>
        /// <returns>lista de eventos</returns>


        public List<Evento> EventosPorFecha(String fechaInicio, String fechaFin)
        {
            BDConexion laConexion;
            List<Evento> listaEventos = new List<Evento>();
            List<Parametro> parametros = new List<Parametro>();
            Parametro parametro = new Parametro(RecursosBDModulo9.ParametroFechaInicio, SqlDbType.Date, fechaInicio, false);
            parametros.Add(parametro);
            parametro = new Parametro(RecursosBDModulo9.ParametroFechaFin, SqlDbType.Date, fechaFin, false);
            parametros.Add(parametro);

            try
            {
                laConexion = new BDConexion();
                DataTable dt = laConexion.EjecutarStoredProcedureTuplas(RecursosBDModulo9.ProcedimientoConsultarEventosRangoFecha, parametros);
                foreach (DataRow row in dt.Rows)
                {
                    Evento evento = new Evento();

                    evento.Id_evento = int.Parse(row[RecursosBDModulo9.AliasIdEvento].ToString());
                    Console.Out.WriteLine(evento.Id_evento);
                    evento.Nombre = row[RecursosBDModulo9.AliasNombreEvento].ToString();
                    evento.Descripcion = row[RecursosBDModulo9.AliasDescripcionEvento].ToString();
                    evento.Estado = Boolean.Parse(row[RecursosBDModulo9.AliasEstadoEvento].ToString());
                    Horario horario = new Horario();
                    horario.FechaInicio = DateTime.Parse(row[RecursosBDModulo9.AliasFechaInicio].ToString());
                    horario.FechaFin = DateTime.Parse(row[RecursosBDModulo9.AliasFechaFin].ToString());
                    horario.HoraInicio = int.Parse(row[RecursosBDModulo9.AliasHoraInicio].ToString());
                    horario.HoraFin = int.Parse(row[RecursosBDModulo9.AliasHoraFin].ToString());
                    TipoEvento tipoEvento = new TipoEvento();
                    tipoEvento.Nombre = row[RecursosBDModulo9.AliasTipoEvento].ToString();
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
                throw new ExcepcionesSKD.Modulo12.FormatoIncorrectoException(RecursosBDModulo9.CodigoErrorFormato,
                     RecursosBDModulo9.MensajeErrorFormato, ex);
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
        /// Metodo Solicitado por M10 que retorna todas las fechas donde hay ascensos
        /// </summary>
        /// <returns>lista de horario</returns>
        
        public List<Horario> ListarHorariosAscensos()
        {
            BDConexion laConexion;
            List<Horario> listaHorarios = new List<Horario>();
            List<Parametro> parametros;

            try
            {
                laConexion = new BDConexion();
                parametros = new List<Parametro>();
                DataTable dt = laConexion.EjecutarStoredProcedureTuplas(RecursosBDModulo9.ProcedimientoConsultarFechasAscensos, parametros);
                foreach (DataRow row in dt.Rows)
                {

                    Horario horario = new Horario();
                    horario.FechaInicio = DateTime.Parse(row[RecursosBDModulo9.AliasFechaInicio].ToString());
                    horario.FechaFin = DateTime.Parse(row[RecursosBDModulo9.AliasFechaFin].ToString());
                    horario.HoraInicio = int.Parse(row[RecursosBDModulo9.AliasHoraInicio].ToString());
                    horario.HoraFin = int.Parse(row[RecursosBDModulo9.AliasHoraFin].ToString());
                    listaHorarios.Add(horario);
                }

            }
            catch (SqlException ex)
            {
                throw new ExcepcionesSKD.ExceptionSKDConexionBD(RecursoGeneralBD.Codigo,
                    RecursoGeneralBD.Mensaje, ex);
            }
            catch (FormatException ex)
            {
                throw new ExcepcionesSKD.Modulo12.FormatoIncorrectoException(RecursosBDModulo9.CodigoErrorFormato,
                     RecursosBDModulo9.MensajeErrorFormato, ex);
            }
            catch (ExcepcionesSKD.ExceptionSKDConexionBD ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw new ExcepcionesSKD.ExceptionSKD(RecursoGeneralBD.Mensaje_Generico_Error, ex);
            }

            return listaHorarios;

        }

        /// <summary>
        /// Metodo solicitado por M10 que dado un rango de fecha retorna los eventos tipo ascenso que esten en el rango
        /// </summary>
        /// <param name="fechaInicio">fecha inicio</param>
        /// <param name="fechaFin">fecha fin</param>
        /// <returns>lista de eventos</returns>

        public List<Evento> AcsensosPorFecha(String fechaInicio, String fechaFin)
        {
            BDConexion laConexion;
            List<Evento> listaEventos = new List<Evento>();
            List<Parametro> parametros = new List<Parametro>();
            Parametro parametro = new Parametro(RecursosBDModulo9.ParametroFechaInicio, SqlDbType.Date, fechaInicio, false);
            parametros.Add(parametro);
            parametro = new Parametro(RecursosBDModulo9.ParametroFechaFin, SqlDbType.Date, fechaFin, false);
            parametros.Add(parametro);

            try
            {
                laConexion = new BDConexion();
                DataTable dt = laConexion.EjecutarStoredProcedureTuplas(RecursosBDModulo9.ProcedimientoConsultarAscensosRangoFecha, parametros);
                foreach (DataRow row in dt.Rows)
                {
                    Evento evento = new Evento();

                    evento.Id_evento = int.Parse(row[RecursosBDModulo9.AliasIdEvento].ToString());
                    Console.Out.WriteLine(evento.Id_evento);
                    evento.Nombre = row[RecursosBDModulo9.AliasNombreEvento].ToString();
                    evento.Descripcion = row[RecursosBDModulo9.AliasDescripcionEvento].ToString();
                    evento.Estado = Boolean.Parse(row[RecursosBDModulo9.AliasEstadoEvento].ToString());
                    Horario horario = new Horario();
                    horario.FechaInicio = DateTime.Parse(row[RecursosBDModulo9.AliasFechaInicio].ToString());
                    horario.FechaFin = DateTime.Parse(row[RecursosBDModulo9.AliasFechaFin].ToString());
                    horario.HoraInicio = int.Parse(row[RecursosBDModulo9.AliasHoraInicio].ToString());
                    horario.HoraFin = int.Parse(row[RecursosBDModulo9.AliasHoraFin].ToString());
                    TipoEvento tipoEvento = new TipoEvento();
                    tipoEvento.Nombre = row[RecursosBDModulo9.AliasTipoEvento].ToString();
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
                throw new ExcepcionesSKD.Modulo12.FormatoIncorrectoException(RecursosBDModulo9.CodigoErrorFormato,
                     RecursosBDModulo9.MensajeErrorFormato, ex);
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
    }
}

