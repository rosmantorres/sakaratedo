using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExcepcionesSKD;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using DominioSKD.Fabrica;
using DominioSKD.Entidades;
using DominioSKD;



namespace DatosSKD.DAO.Modulo9
{
    public class DaoEvento:DAOGeneral        
    {
        #region Metodos
        /// <summary>
        /// Metodo que permite agregar un Evento a la BD
        /// </summary>
        /// <param name="evento">El Evento a Agregar</param>
        /// <returns>Retorna true o false</returns>
        public bool CrearEvento(Entidad eventoParametro)
        {
            Logger.EscribirInfo(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, RecursosDaoEvento.MensajeInicioInfoLogger, System.Reflection.MethodBase.GetCurrentMethod().Name);

            try
            {
                //parametros para insertar un evento
                DominioSKD.Entidades.Modulo9.Evento evento = (DominioSKD.Entidades.Modulo9.Evento)eventoParametro;

                List<Parametro> parametros = new List<Parametro>();
                Parametro parametro = new Parametro(RecursosDaoEvento.ParametroNombreEvento, SqlDbType.VarChar, evento.Nombre, false);
                parametros.Add(parametro);
                parametro = new Parametro(RecursosDaoEvento.ParametroDescripcionEvento, SqlDbType.VarChar, evento.Descripcion, false);
                parametros.Add(parametro);
                parametro = new Parametro(RecursosDaoEvento.ParametroCostoEvento, SqlDbType.Float, evento.Costo.ToString(), false);
                parametros.Add(parametro);
                parametro = new Parametro(RecursosDaoEvento.ParametroEstadoEvento, SqlDbType.VarChar, evento.Estado.ToString(), false);
                parametros.Add(parametro);
                parametro = new Parametro(RecursosDaoEvento.ParametroIdPersona, SqlDbType.Int, evento.Persona.ID.ToString(), false);
                parametros.Add(parametro);
                parametro = new Parametro(RecursosDaoEvento.ParametroIdUbicacion, SqlDbType.Int,"1", false);
                parametros.Add(parametro);
                parametro = new Parametro(RecursosDaoEvento.ParametroIdTipoEvento, SqlDbType.Int, evento.TipoEvento.Id.ToString(), false);
                parametros.Add(parametro);
                parametro = new Parametro(RecursosDaoEvento.ParametroIdCategoria, SqlDbType.Int, "1", false);
                parametros.Add(parametro);
                parametro = new Parametro(RecursosDaoEvento.ParametroFechaInicio, SqlDbType.Date, evento.Horario.FechaInicio.ToString(), false);
                parametros.Add(parametro);
                parametro = new Parametro(RecursosDaoEvento.ParametroFechaFin, SqlDbType.Date, evento.Horario.FechaFin.ToString(), false);
                parametros.Add(parametro);
                parametro = new Parametro(RecursosDaoEvento.ParametroHoraInicio, SqlDbType.Int, evento.Horario.HoraInicio.ToString(), false);
                parametros.Add(parametro);
                parametro = new Parametro(RecursosDaoEvento.ParametroHoraFin, SqlDbType.Int, evento.Horario.HoraFin.ToString(), false);
                parametros.Add(parametro);

                BDConexion con = new BDConexion();
                List<Resultado> resultados = con.EjecutarStoredProcedure(RecursosDaoEvento.ProcedimientoAgregarEvento, parametros);

                //si la creacion es correcta retorna true

                if (resultados != null)
                {
                    Logger.EscribirInfo(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, RecursosDaoEvento.MensajeFinInfoLogger, System.Reflection.MethodBase.GetCurrentMethod().Name);
                    return true;
                }
                else
                {
                    Logger.EscribirInfo(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, RecursosDaoEvento.MensajeFinInfoLogger, System.Reflection.MethodBase.GetCurrentMethod().Name);
                    return false;

                }

            }
            catch (SqlException ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                throw new ExcepcionesSKD.ExceptionSKDConexionBD(RecursoGeneralBD.Codigo,
                    RecursoGeneralBD.Mensaje, ex);
            }
            catch (FormatException ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);

                throw new ExcepcionesSKD.Modulo12.FormatoIncorrectoException(RecursosDaoEvento.CodigoErrorFormato,
                     RecursosDaoEvento.MensajeErrorFormato, ex);
            }
            catch (ExcepcionesSKD.ExceptionSKDConexionBD ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);

                throw ex;
            }
            catch (Exception ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);

                throw new ExcepcionesSKD.ExceptionSKD(RecursoGeneralBD.Mensaje_Generico_Error, ex);
            }
        }
        /// <summary>
        /// Metodo que permite agregar un Evento a la BD con un tipo de evento Nuevo
        /// </summary>
        /// <param name="evento"></param>
        /// <returns></returns>
        public bool CrearEventoConTipo(Entidad eventoParametro)
        {
            Logger.EscribirInfo(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, RecursosDaoEvento.MensajeInicioInfoLogger, System.Reflection.MethodBase.GetCurrentMethod().Name);

            try
            {
                DominioSKD.Entidades.Modulo9.Evento evento = (DominioSKD.Entidades.Modulo9.Evento)eventoParametro;

                //parametros para insertar un evento
                List<Parametro> parametros = new List<Parametro>();
                Parametro parametro = new Parametro(RecursosDaoEvento.ParametroNombreEvento, SqlDbType.VarChar, evento.Nombre, false);
                parametros.Add(parametro);
                parametro = new Parametro(RecursosDaoEvento.ParametroDescripcionEvento, SqlDbType.VarChar, evento.Descripcion, false);
                parametros.Add(parametro);
                parametro = new Parametro(RecursosDaoEvento.ParametroCostoEvento, SqlDbType.Float, evento.Costo.ToString(), false);
                parametros.Add(parametro);
                parametro = new Parametro(RecursosDaoEvento.ParametroEstadoEvento, SqlDbType.VarChar, evento.Estado.ToString(), false);
                parametros.Add(parametro);
                parametro = new Parametro(RecursosDaoEvento.ParametroIdPersona, SqlDbType.Int, evento.Persona.ID.ToString(), false);
                parametros.Add(parametro);
                parametro = new Parametro(RecursosDaoEvento.ParametroIdUbicacion, SqlDbType.Int, "1", false);
                parametros.Add(parametro);
                parametro = new Parametro(RecursosDaoEvento.ParametroNombreTipoEvento, SqlDbType.VarChar, evento.TipoEvento.Nombre.ToString(), false);
                parametros.Add(parametro);
                parametro = new Parametro(RecursosDaoEvento.ParametroFechaInicio, SqlDbType.Date, evento.Horario.FechaInicio.ToString(), false);
                parametros.Add(parametro);
                parametro = new Parametro(RecursosDaoEvento.ParametroFechaFin, SqlDbType.Date, evento.Horario.FechaFin.ToString(), false);
                parametros.Add(parametro);
                parametro = new Parametro(RecursosDaoEvento.ParametroHoraInicio, SqlDbType.Int, evento.Horario.HoraInicio.ToString(), false);
                parametros.Add(parametro);
                parametro = new Parametro(RecursosDaoEvento.ParametroHoraFin, SqlDbType.Int, evento.Horario.HoraFin.ToString(), false);
                parametros.Add(parametro);

                BDConexion con = new BDConexion();
                List<Resultado> resultados = con.EjecutarStoredProcedure(RecursosDaoEvento.ProcedimientoAgregarEventoConTipo, parametros);

                //si la creacion es correcta retorna true

                if (resultados != null)
                {
                    Logger.EscribirInfo(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, RecursosDaoEvento.MensajeFinInfoLogger, System.Reflection.MethodBase.GetCurrentMethod().Name);
                    return true;
                }
                else
                {
                    Logger.EscribirInfo(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, RecursosDaoEvento.MensajeFinInfoLogger, System.Reflection.MethodBase.GetCurrentMethod().Name);
                    return false;

                }

            }
            catch (SqlException ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                throw new ExcepcionesSKD.ExceptionSKDConexionBD(RecursoGeneralBD.Codigo,
                    RecursoGeneralBD.Mensaje, ex);
            }
            catch (FormatException ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);

                throw new ExcepcionesSKD.Modulo12.FormatoIncorrectoException(RecursosDaoEvento.CodigoErrorFormato,
                     RecursosDaoEvento.MensajeErrorFormato, ex);
            }
            catch (ExcepcionesSKD.ExceptionSKDConexionBD ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);

                throw ex;
            }
            catch (Exception ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);

                throw new ExcepcionesSKD.ExceptionSKD(RecursoGeneralBD.Mensaje_Generico_Error, ex);
            }

        }

        /// <summary>
        /// Metodo que modifica un evento en BD
        /// </summary>
        /// <param name="evento">Evento a modificar</param>
        /// <returns>Verdadero o Falso</returns>
        public bool ModificarEvento(Entidad eventoParametro)
        {
            Logger.EscribirInfo(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, RecursosDaoEvento.MensajeInicioInfoLogger, System.Reflection.MethodBase.GetCurrentMethod().Name);

            try
            {

                DominioSKD.Entidades.Modulo9.Evento evento = (DominioSKD.Entidades.Modulo9.Evento)eventoParametro;
                //parametros para insertar un evento
                List<Parametro> parametros = new List<Parametro>();
                Parametro parametro = new Parametro(RecursosDaoEvento.ParametroIdEvento, SqlDbType.Int, evento.Id.ToString(), false);
                parametros.Add(parametro);
                parametro = new Parametro(RecursosDaoEvento.ParametroNombreEvento, SqlDbType.VarChar, evento.Nombre, false);
                parametros.Add(parametro);
                parametro = new Parametro(RecursosDaoEvento.ParametroDescripcionEvento, SqlDbType.VarChar, evento.Descripcion, false);
                parametros.Add(parametro);
                parametro = new Parametro(RecursosDaoEvento.ParametroCostoEvento, SqlDbType.Float, evento.Costo.ToString(), false);
                parametros.Add(parametro);
                parametro = new Parametro(RecursosDaoEvento.ParametroEstadoEvento, SqlDbType.VarChar, evento.Estado.ToString(), false);
                parametros.Add(parametro);
                parametro = new Parametro(RecursosDaoEvento.ParametroIdUbicacion, SqlDbType.Int, "1", false);
                parametros.Add(parametro);
                parametro = new Parametro(RecursosDaoEvento.ParametroIdTipoEvento, SqlDbType.Int, evento.TipoEvento.Id.ToString(), false);
                parametros.Add(parametro);
                parametro = new Parametro(RecursosDaoEvento.ParametroFechaInicio, SqlDbType.Date, evento.Horario.FechaInicio.ToString(), false);
                parametros.Add(parametro);
                parametro = new Parametro(RecursosDaoEvento.ParametroFechaFin, SqlDbType.Date, evento.Horario.FechaFin.ToString(), false);
                parametros.Add(parametro);
                parametro = new Parametro(RecursosDaoEvento.ParametroHoraInicio, SqlDbType.Int, evento.Horario.HoraInicio.ToString(), false);
                parametros.Add(parametro);
                parametro = new Parametro(RecursosDaoEvento.ParametroHoraFin, SqlDbType.Int, evento.Horario.HoraFin.ToString(), false);
                parametros.Add(parametro);

                BDConexion con = new BDConexion();
                List<Resultado> resultados = con.EjecutarStoredProcedure(RecursosDaoEvento.ProcedimientoModificarEvento, parametros);

                //si la creacion es correcta retorna true

                if (resultados != null)
                {
                    Logger.EscribirInfo(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, RecursosDaoEvento.MensajeFinInfoLogger, System.Reflection.MethodBase.GetCurrentMethod().Name);
                    return true;
                }
                else
                {
                    Logger.EscribirInfo(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, RecursosDaoEvento.MensajeFinInfoLogger, System.Reflection.MethodBase.GetCurrentMethod().Name);
                    return false;

                }

            }
            catch (SqlException ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                throw new ExcepcionesSKD.ExceptionSKDConexionBD(RecursoGeneralBD.Codigo,
                    RecursoGeneralBD.Mensaje, ex);
            }
            catch (FormatException ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);

                throw new ExcepcionesSKD.Modulo12.FormatoIncorrectoException(RecursosDaoEvento.CodigoErrorFormato,
                     RecursosDaoEvento.MensajeErrorFormato, ex);
            }
            catch (ExcepcionesSKD.ExceptionSKDConexionBD ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);

                throw ex;
            }
            catch (Exception ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);

                throw new ExcepcionesSKD.ExceptionSKD(RecursoGeneralBD.Mensaje_Generico_Error, ex);
            }

        }

        /// <summary>
        /// Metodo que modifica un evento al agregar un nuevo tipo de evento
        /// </summary>
        /// <param name="evento">el evento a modificar</param>
        /// <returns>Verdadero o Falso</returns>

        public bool ModificarEventoConTipo(Entidad eventoParametro)
        {
            Logger.EscribirInfo(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, RecursosDaoEvento.MensajeInicioInfoLogger, System.Reflection.MethodBase.GetCurrentMethod().Name);

            try
            {
                DominioSKD.Entidades.Modulo9.Evento evento = (DominioSKD.Entidades.Modulo9.Evento)eventoParametro;
                //parametros para insertar un evento
                List<Parametro> parametros = new List<Parametro>();
                Parametro parametro = new Parametro(RecursosDaoEvento.ParametroIdEvento, SqlDbType.Int, evento.Id.ToString(), false);
                parametros.Add(parametro);
                parametro = new Parametro(RecursosDaoEvento.ParametroNombreEvento, SqlDbType.VarChar, evento.Nombre, false);
                parametros.Add(parametro);
                parametro = new Parametro(RecursosDaoEvento.ParametroDescripcionEvento, SqlDbType.VarChar, evento.Descripcion, false);
                parametros.Add(parametro);
                parametro = new Parametro(RecursosDaoEvento.ParametroCostoEvento, SqlDbType.Float, evento.Costo.ToString(), false);
                parametros.Add(parametro);
                parametro = new Parametro(RecursosDaoEvento.ParametroEstadoEvento, SqlDbType.VarChar, evento.Estado.ToString(), false);
                parametros.Add(parametro);
                parametro = new Parametro(RecursosDaoEvento.ParametroIdUbicacion, SqlDbType.Int, "1", false);
                parametros.Add(parametro);
                parametro = new Parametro(RecursosDaoEvento.ParametroNombreTipoEvento, SqlDbType.VarChar, evento.TipoEvento.Nombre.ToString(), false);
                parametros.Add(parametro);
                parametro = new Parametro(RecursosDaoEvento.ParametroFechaInicio, SqlDbType.Date, evento.Horario.FechaInicio.ToString(), false);
                parametros.Add(parametro);
                parametro = new Parametro(RecursosDaoEvento.ParametroFechaFin, SqlDbType.Date, evento.Horario.FechaFin.ToString(), false);
                parametros.Add(parametro);
                parametro = new Parametro(RecursosDaoEvento.ParametroHoraInicio, SqlDbType.Int, evento.Horario.HoraInicio.ToString(), false);
                parametros.Add(parametro);
                parametro = new Parametro(RecursosDaoEvento.ParametroHoraFin, SqlDbType.Int, evento.Horario.HoraFin.ToString(), false);
                parametros.Add(parametro);

                BDConexion con = new BDConexion();
                List<Resultado> resultados = con.EjecutarStoredProcedure(RecursosDaoEvento.ProcedimientoModificarEventoConTipo, parametros);

                //si la creacion es correcta retorna true

                if (resultados != null)
                {
                    Logger.EscribirInfo(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, RecursosDaoEvento.MensajeFinInfoLogger, System.Reflection.MethodBase.GetCurrentMethod().Name);
                    return true;
                }
                else
                {
                    Logger.EscribirInfo(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, RecursosDaoEvento.MensajeFinInfoLogger, System.Reflection.MethodBase.GetCurrentMethod().Name);
                    return false;

                }

            }
            catch (SqlException ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                throw new ExcepcionesSKD.ExceptionSKDConexionBD(RecursoGeneralBD.Codigo,
                    RecursoGeneralBD.Mensaje, ex);
            }
            catch (FormatException ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);

                throw new ExcepcionesSKD.Modulo12.FormatoIncorrectoException(RecursosDaoEvento.CodigoErrorFormato,
                     RecursosDaoEvento.MensajeErrorFormato, ex);
            }
            catch (ExcepcionesSKD.ExceptionSKDConexionBD ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);

                throw ex;
            }
            catch (Exception ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);

                throw new ExcepcionesSKD.ExceptionSKD(RecursoGeneralBD.Mensaje_Generico_Error, ex);
            }

        }

        /// <summary>
        /// Metodo que permite obtener de base de datos todos los eventos de un administrador
        /// </summary>
        /// <returns>lista de eventos</returns>

        public List<Entidad> ListarEventos(int idPersona)
        {
            BDConexion laConexion;
            List<Entidad> listaEventos = new List<Entidad>();
            List<Parametro> parametros;
            Logger.EscribirInfo(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, RecursosDaoEvento.MensajeInicioInfoLogger, System.Reflection.MethodBase.GetCurrentMethod().Name);
            DominioSKD.Entidades.Modulo9.Evento evento;
            DominioSKD.Entidades.Modulo9.Horario horario;
            DominioSKD.Entidades.Modulo9.TipoEvento tipoEvento;
            FabricaEntidades laFabrica = new FabricaEntidades();
            try
            {
                //DominioSKD.Entidades.Modulo9.Horario horario;
                laConexion = new BDConexion();
                parametros = new List<Parametro>();
                Parametro parametro = new Parametro(RecursosDaoEvento.ParametroIdPersona, SqlDbType.Int, idPersona.ToString(), false);
                parametros.Add(parametro);
                DataTable dt = laConexion.EjecutarStoredProcedureTuplas(RecursosDaoEvento.ProcedimientoConsultarEventos, parametros);
                foreach (DataRow row in dt.Rows)
                {
                    evento = (DominioSKD.Entidades.Modulo9.Evento)laFabrica.ObtenerEvento();
                    horario = (DominioSKD.Entidades.Modulo9.Horario)laFabrica.ObtenerHorario();
                    tipoEvento = (DominioSKD.Entidades.Modulo9.TipoEvento)laFabrica.ObtenerTipoEvento();
                    evento.Id = int.Parse(row[RecursosDaoEvento.AliasIdEvento].ToString());
                    //Console.Out.WriteLine(evento.Id_evento);
                    evento.Nombre = row[RecursosDaoEvento.AliasNombreEvento].ToString();
                    evento.Descripcion = row[RecursosDaoEvento.AliasDescripcionEvento].ToString();
                    evento.Estado = Boolean.Parse(row[RecursosDaoEvento.AliasEstadoEvento].ToString());
                    evento.Costo = float.Parse(row[RecursosDaoEvento.AliasCostoEvento].ToString());
                    //Horario horario = new Horario();
                    horario.FechaInicio = DateTime.Parse(row[RecursosDaoEvento.AliasFechaInicio].ToString());
                    horario.FechaFin = DateTime.Parse(row[RecursosDaoEvento.AliasFechaFin].ToString());
                    horario.HoraInicio = int.Parse(row[RecursosDaoEvento.AliasHoraInicio].ToString());
                    horario.HoraFin = int.Parse(row[RecursosDaoEvento.AliasHoraFin].ToString());   
                    tipoEvento.Nombre = row[RecursosDaoEvento.AliasTipoEvento].ToString();
                    evento.Horario = horario;
                    evento.TipoEvento = tipoEvento;
                    listaEventos.Add(evento);
                }

            }
            catch (SqlException ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);

                throw new ExcepcionesSKD.ExceptionSKDConexionBD(RecursoGeneralBD.Codigo,
                    RecursoGeneralBD.Mensaje, ex);
            }
            catch (FormatException ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);

                throw new ExcepcionesSKD.Modulo12.FormatoIncorrectoException(RecursosDaoEvento.CodigoErrorFormato,
                     RecursosDaoEvento.MensajeErrorFormato, ex);
            }
            catch (ExcepcionesSKD.ExceptionSKDConexionBD ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);

                throw ex;
            }
            catch (Exception ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);

                throw new ExcepcionesSKD.ExceptionSKD(RecursoGeneralBD.Mensaje_Generico_Error, ex);
            }

            Logger.EscribirInfo(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, RecursosDaoEvento.MensajeFinInfoLogger, System.Reflection.MethodBase.GetCurrentMethod().Name);

            return listaEventos;

        }


        /// <summary>
        /// Metodo que trae de BD todos los tipos de eventos con sus ID
        /// </summary>
        /// <returns>Lista de TipoEvento</returns>


        public List<Entidad> ListarTiposEventos()
        {
            BDConexion laConexion;
            List<Entidad> listaTipos = new List<Entidad>();
            List<Parametro> parametros;
            Logger.EscribirInfo(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, RecursosDaoEvento.MensajeInicioInfoLogger, System.Reflection.MethodBase.GetCurrentMethod().Name);
            DominioSKD.Entidades.Modulo9.Evento evento;
            DominioSKD.Entidades.Modulo9.TipoEvento tipo;
            FabricaEntidades laFabrica = new FabricaEntidades();
            try
            {
                laConexion = new BDConexion();
                parametros = new List<Parametro>();
                DataTable dt = laConexion.EjecutarStoredProcedureTuplas(RecursosDaoEvento.ProcedimientoConsultarTiposEventos, parametros);
                foreach (DataRow row in dt.Rows)
                {
                    evento = (DominioSKD.Entidades.Modulo9.Evento)laFabrica.ObtenerEvento;
                    tipo = (DominioSKD.Entidades.Modulo9.TipoEvento)laFabrica.ObtenerTipoEvento();
                    tipo.Id = int.Parse(row[RecursosDaoEvento.AliasIDTipoEvento].ToString());
                    //Console.Out.WriteLine(evento.Id_evento);
                    tipo.Nombre = row[RecursosDaoEvento.AliasTipoEvento].ToString();
                    listaTipos.Add(tipo);
                }

            }
            catch (SqlException ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);

                throw new ExcepcionesSKD.ExceptionSKDConexionBD(RecursoGeneralBD.Codigo,
                    RecursoGeneralBD.Mensaje, ex);
            }
            catch (FormatException ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);

                throw new ExcepcionesSKD.Modulo12.FormatoIncorrectoException(RecursosDaoEvento.CodigoErrorFormato,
                     RecursosDaoEvento.MensajeErrorFormato, ex);
            }
            catch (ExcepcionesSKD.ExceptionSKDConexionBD ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);

                throw ex;
            }
            catch (Exception ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);

                throw new ExcepcionesSKD.ExceptionSKD(RecursoGeneralBD.Mensaje_Generico_Error, ex);
            }

            Logger.EscribirInfo(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, RecursosDaoEvento.MensajeFinInfoLogger, System.Reflection.MethodBase.GetCurrentMethod().Name);


            return listaTipos;

        }

        /// <summary>
        /// Metodo que permite Consultar un evento por id
        /// </summary>
        /// <param name="idEvento">Id del evento</param>
        /// <returns>Retorna un evento</returns>


        /// ConsultarEventoTerminado
        public Evento ConsultarEvento(String idEvento)
        {
            BDConexion laConexion;
            Logger.EscribirInfo(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, RecursosDaoEvento.MensajeInicioInfoLogger, System.Reflection.MethodBase.GetCurrentMethod().Name);
            FabricaEntidades laFabrica = new FabricaEntidades();
            try
            {
                Console.Out.WriteLine(idEvento);
                laConexion = new BDConexion();
                DominioSKD.Entidades.Modulo9.Evento evento;
                //evento = new Evento();
                List<Parametro> parametros = new List<Parametro>();
                Parametro parametro = new Parametro(RecursosDaoEvento.ParametroIdEvento, SqlDbType.Int, idEvento, false);
                /*Console.Out.WriteLine(parametro.valor);
                Console.Out.WriteLine(parametro.tipoDato);
                Console.Out.WriteLine(RecursosDaoEvento.ParametroIdEvento);*/
                parametros.Add(parametro);
                DataTable dt = laConexion.EjecutarStoredProcedureTuplas(RecursosDaoEvento.ProcedimentoConsultarEventoXID, parametros);

                foreach (DataRow row in dt.Rows)
                {
                    DominioSKD.Entidades.Modulo9.Horario horario;
                    DominioSKD.Entidades.Modulo9.TipoEvento tipoEvento;
                    evento.Nombre = row[RecursosDaoEvento.AliasNombreEvento].ToString(); ;
                    Console.Out.WriteLine(evento.Nombre);
                    evento.Descripcion = row[RecursosDaoEvento.AliasDescripcionEvento].ToString();
                    evento.Estado = Boolean.Parse(row[RecursosDaoEvento.AliasEstadoEvento].ToString());
                    evento.Costo = float.Parse(row[RecursosDaoEvento.AliasCostoEvento].ToString());
                    //Horario horario = new Horario();
                    horario.FechaInicio = DateTime.Parse(row[RecursosDaoEvento.AliasFechaInicio].ToString());
                    horario.FechaFin = DateTime.Parse(row[RecursosDaoEvento.AliasFechaFin].ToString());
                    horario.HoraInicio = int.Parse(row[RecursosDaoEvento.AliasHoraInicio].ToString());
                    horario.HoraFin = int.Parse(row[RecursosDaoEvento.AliasHoraFin].ToString());
                    //TipoEvento tipoEvento = new TipoEvento();
                    tipoEvento.Id = int.Parse(row[RecursosDaoEvento.AliasIDTipoEvento].ToString());
                    tipoEvento.Nombre = row[RecursosDaoEvento.AliasTipoEvento].ToString();
                    evento.Horario = horario;
                    evento.TipoEvento = tipoEvento;
                }


            }
            catch (SqlException ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);

                throw new ExcepcionesSKD.ExceptionSKDConexionBD(RecursoGeneralBD.Codigo,
                    RecursoGeneralBD.Mensaje, ex);
            }
            catch (FormatException ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);

                throw new ExcepcionesSKD.Modulo12.FormatoIncorrectoException(RecursosDaoEvento.CodigoErrorFormato,
                     RecursosDaoEvento.MensajeErrorFormato, ex);
            }
            catch (ExcepcionesSKD.ExceptionSKDConexionBD ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);

                throw ex;
            }
            catch (Exception ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);

                throw new ExcepcionesSKD.ExceptionSKD(RecursoGeneralBD.Mensaje_Generico_Error, ex);
            }
            Logger.EscribirInfo(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, RecursosDaoEvento.MensajeFinInfoLogger, System.Reflection.MethodBase.GetCurrentMethod().Name);

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
            Logger.EscribirInfo(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, RecursosDaoEvento.MensajeInicioInfoLogger, System.Reflection.MethodBase.GetCurrentMethod().Name);

            try
            {
                laConexion = new BDConexion();
                parametros = new List<Parametro>();
                DataTable dt = laConexion.EjecutarStoredProcedureTuplas(RecursosDaoEvento.ProcedimientoConsultarHorarios, parametros);
                foreach (DataRow row in dt.Rows)
                {

                    Horario horario = new Horario();
                    horario.FechaInicio = DateTime.Parse(row[RecursosDaoEvento.AliasFechaInicio].ToString());
                    horario.FechaFin = DateTime.Parse(row[RecursosDaoEvento.AliasFechaFin].ToString());
                    horario.HoraInicio = int.Parse(row[RecursosDaoEvento.AliasHoraInicio].ToString());
                    horario.HoraFin = int.Parse(row[RecursosDaoEvento.AliasHoraFin].ToString());
                    listaHorarios.Add(horario);
                }

            }
            catch (SqlException ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);

                throw new ExcepcionesSKD.ExceptionSKDConexionBD(RecursoGeneralBD.Codigo,
                    RecursoGeneralBD.Mensaje, ex);
            }
            catch (FormatException ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);

                throw new ExcepcionesSKD.Modulo12.FormatoIncorrectoException(RecursosDaoEvento.CodigoErrorFormato,
                     RecursosDaoEvento.MensajeErrorFormato, ex);
            }
            catch (ExcepcionesSKD.ExceptionSKDConexionBD ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);

                throw ex;
            }
            catch (Exception ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);

                throw new ExcepcionesSKD.ExceptionSKD(RecursoGeneralBD.Mensaje_Generico_Error, ex);
            }
            Logger.EscribirInfo(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, RecursosDaoEvento.MensajeFinInfoLogger, System.Reflection.MethodBase.GetCurrentMethod().Name);


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
            Parametro parametro = new Parametro(RecursosDaoEvento.ParametroFechaInicio, SqlDbType.Date, fechaInicio, false);
            parametros.Add(parametro);
            parametro = new Parametro(RecursosDaoEvento.ParametroFechaFin, SqlDbType.Date, fechaFin, false);
            parametros.Add(parametro);
            Logger.EscribirInfo(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, RecursosDaoEvento.MensajeInicioInfoLogger, System.Reflection.MethodBase.GetCurrentMethod().Name);

            try
            {
                laConexion = new BDConexion();
                DataTable dt = laConexion.EjecutarStoredProcedureTuplas(RecursosDaoEvento.ProcedimientoConsultarEventosRangoFecha, parametros);
                foreach (DataRow row in dt.Rows)
                {
                    Evento evento = new Evento();

                    evento.Id_evento = int.Parse(row[RecursosDaoEvento.AliasIdEvento].ToString());
                    Console.Out.WriteLine(evento.Id_evento);
                    evento.Nombre = row[RecursosDaoEvento.AliasNombreEvento].ToString();
                    evento.Descripcion = row[RecursosDaoEvento.AliasDescripcionEvento].ToString();
                    evento.Estado = Boolean.Parse(row[RecursosDaoEvento.AliasEstadoEvento].ToString());
                    Horario horario = new Horario();
                    horario.FechaInicio = DateTime.Parse(row[RecursosDaoEvento.AliasFechaInicio].ToString());
                    horario.FechaFin = DateTime.Parse(row[RecursosDaoEvento.AliasFechaFin].ToString());
                    horario.HoraInicio = int.Parse(row[RecursosDaoEvento.AliasHoraInicio].ToString());
                    horario.HoraFin = int.Parse(row[RecursosDaoEvento.AliasHoraFin].ToString());
                    TipoEvento tipoEvento = new TipoEvento();
                    tipoEvento.Nombre = row[RecursosDaoEvento.AliasTipoEvento].ToString();
                    evento.Horario = horario;
                    evento.TipoEvento = tipoEvento;
                    listaEventos.Add(evento);
                }

            }
            catch (SqlException ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);

                throw new ExcepcionesSKD.ExceptionSKDConexionBD(RecursoGeneralBD.Codigo,
                    RecursoGeneralBD.Mensaje, ex);
            }
            catch (FormatException ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);

                throw new ExcepcionesSKD.Modulo12.FormatoIncorrectoException(RecursosDaoEvento.CodigoErrorFormato,
                     RecursosDaoEvento.MensajeErrorFormato, ex);
            }
            catch (ExcepcionesSKD.ExceptionSKDConexionBD ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);

                throw ex;
            }
            catch (Exception ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);

                throw new ExcepcionesSKD.ExceptionSKD(RecursoGeneralBD.Mensaje_Generico_Error, ex);
            }
            Logger.EscribirInfo(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, RecursosDaoEvento.MensajeFinInfoLogger, System.Reflection.MethodBase.GetCurrentMethod().Name);


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
            Logger.EscribirInfo(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, RecursosDaoEvento.MensajeInicioInfoLogger, System.Reflection.MethodBase.GetCurrentMethod().Name);

            try
            {
                laConexion = new BDConexion();
                parametros = new List<Parametro>();
                DataTable dt = laConexion.EjecutarStoredProcedureTuplas(RecursosDaoEvento.ProcedimientoConsultarFechasAscensos, parametros);
                foreach (DataRow row in dt.Rows)
                {

                    Horario horario = new Horario();
                    horario.FechaInicio = DateTime.Parse(row[RecursosDaoEvento.AliasFechaInicio].ToString());
                    horario.FechaFin = DateTime.Parse(row[RecursosDaoEvento.AliasFechaFin].ToString());
                    horario.HoraInicio = int.Parse(row[RecursosDaoEvento.AliasHoraInicio].ToString());
                    horario.HoraFin = int.Parse(row[RecursosDaoEvento.AliasHoraFin].ToString());
                    listaHorarios.Add(horario);
                }

            }
            catch (SqlException ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);

                throw new ExcepcionesSKD.ExceptionSKDConexionBD(RecursoGeneralBD.Codigo,
                    RecursoGeneralBD.Mensaje, ex);
            }
            catch (FormatException ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);

                throw new ExcepcionesSKD.Modulo12.FormatoIncorrectoException(RecursosDaoEvento.CodigoErrorFormato,
                     RecursosDaoEvento.MensajeErrorFormato, ex);
            }
            catch (ExcepcionesSKD.ExceptionSKDConexionBD ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);

                throw ex;
            }
            catch (Exception ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);

                throw new ExcepcionesSKD.ExceptionSKD(RecursoGeneralBD.Mensaje_Generico_Error, ex);
            }
            Logger.EscribirInfo(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, RecursosDaoEvento.MensajeFinInfoLogger, System.Reflection.MethodBase.GetCurrentMethod().Name);


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
            Parametro parametro = new Parametro(RecursosDaoEvento.ParametroFechaInicio, SqlDbType.Date, fechaInicio, false);
            parametros.Add(parametro);
            parametro = new Parametro(RecursosDaoEvento.ParametroFechaFin, SqlDbType.Date, fechaFin, false);
            parametros.Add(parametro);
            Logger.EscribirInfo(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, RecursosDaoEvento.MensajeInicioInfoLogger, System.Reflection.MethodBase.GetCurrentMethod().Name);


            try
            {
                laConexion = new BDConexion();
                DataTable dt = laConexion.EjecutarStoredProcedureTuplas(RecursosDaoEvento.ProcedimientoConsultarAscensosRangoFecha, parametros);
                foreach (DataRow row in dt.Rows)
                {
                    Evento evento = new Evento();

                    evento.Id_evento = int.Parse(row[RecursosDaoEvento.AliasIdEvento].ToString());
                    Console.Out.WriteLine(evento.Id_evento);
                    evento.Nombre = row[RecursosDaoEvento.AliasNombreEvento].ToString();
                    evento.Descripcion = row[RecursosDaoEvento.AliasDescripcionEvento].ToString();
                    evento.Estado = Boolean.Parse(row[RecursosDaoEvento.AliasEstadoEvento].ToString());
                    Horario horario = new Horario();
                    horario.FechaInicio = DateTime.Parse(row[RecursosDaoEvento.AliasFechaInicio].ToString());
                    horario.FechaFin = DateTime.Parse(row[RecursosDaoEvento.AliasFechaFin].ToString());
                    horario.HoraInicio = int.Parse(row[RecursosDaoEvento.AliasHoraInicio].ToString());
                    horario.HoraFin = int.Parse(row[RecursosDaoEvento.AliasHoraFin].ToString());
                    TipoEvento tipoEvento = new TipoEvento();
                    tipoEvento.Nombre = row[RecursosDaoEvento.AliasTipoEvento].ToString();
                    evento.Horario = horario;
                    evento.TipoEvento = tipoEvento;
                    listaEventos.Add(evento);
                }

            }
            catch (SqlException ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);

                throw new ExcepcionesSKD.ExceptionSKDConexionBD(RecursoGeneralBD.Codigo,
                    RecursoGeneralBD.Mensaje, ex);
            }
            catch (FormatException ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);

                throw new ExcepcionesSKD.Modulo12.FormatoIncorrectoException(RecursosDaoEvento.CodigoErrorFormato,
                     RecursosDaoEvento.MensajeErrorFormato, ex);
            }
            catch (ExcepcionesSKD.ExceptionSKDConexionBD ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);

                throw ex;
            }
            catch (Exception ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);

                throw new ExcepcionesSKD.ExceptionSKD(RecursoGeneralBD.Mensaje_Generico_Error, ex);
            }
            Logger.EscribirInfo(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, RecursosDaoEvento.MensajeFinInfoLogger, System.Reflection.MethodBase.GetCurrentMethod().Name);


            return listaEventos;

        }
        #endregion

    }
}
