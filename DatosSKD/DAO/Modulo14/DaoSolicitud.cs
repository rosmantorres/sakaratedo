using DatosSKD.InterfazDAO.Modulo14;
using DominioSKD;
using DominioSKD.Fabrica;
using ExcepcionesSKD;
using ExcepcionesSKD.Modulo14;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatosSKD.DAO.Modulo14
{
    public class DaoSolicitud : DAOGeneral, IDaoSolicitud
    {

        #region IDao

        /// <summary>
        /// Registra una solicitud de planilla en la base de datos
        /// </summary>
        /// <param name="">La solicitud</param>
        /// <returns>returna true en caso de que se completara el registro, y false en caso de que no</returns>
        public bool Agregar(Entidad laSolicitud)
        {
            Logger.EscribirInfo(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name,
                RecursosDAOModulo14.MsjDeEntrada, System.Reflection.MethodBase.GetCurrentMethod().Name);
            //BDConexion laConexion;
            List<Parametro> parametros;
            Parametro parametro = new Parametro();
            DominioSKD.Entidades.Modulo14.SolicitudP solicitud = (DominioSKD.Entidades.Modulo14.SolicitudP)laSolicitud;

            try
            {
                //laConexion = new BDConexion();
                this.Conectar();
                parametros = new List<Parametro>();
                parametro = new Parametro(RecursosDAOModulo14.ParametroFechaRetiro,
                SqlDbType.VarChar, solicitud.FechaRetiro.ToString(), false);
                parametros.Add(parametro);

                parametro = new Parametro(RecursosDAOModulo14.ParametroFechaReincorporacion,
                SqlDbType.VarChar, solicitud.FechaReincorporacion.ToString(), false);
                parametros.Add(parametro);

                parametro = new Parametro(RecursosDAOModulo14.ParametroMotivo,
                SqlDbType.VarChar, solicitud.Motivo, false);
                parametros.Add(parametro);

                parametro = new Parametro(RecursosDAOModulo14.ParametroPlanillaID,
                SqlDbType.VarChar, solicitud.Planilla.ID.ToString(), false);
                parametros.Add(parametro);

                parametro = new Parametro(RecursosDAOModulo14.ParametroIdInscripcion,
               SqlDbType.VarChar, solicitud.ID.ToString(), false);
                parametros.Add(parametro);

                string query = RecursosDAOModulo14.ProcedimientoAgregarSolicitud;
                List<Resultado> resultados = this.EjecutarStoredProcedure(query, parametros);

            }
            catch (SqlException ex)
            {
                BDSolicitudException excep = new BDSolicitudException(RecursoGeneralBD.Codigo,
                    RecursoGeneralBD.Mensaje, ex);
                Logger.EscribirError(RecursosDAOModulo14.ClaseBDSolicitud, excep);
                throw excep;
            }
            catch (IOException ex)
            {
                BDSolicitudException excep = new BDSolicitudException(RecursosDAOModulo14.CodigoIoException,
                    RecursosDAOModulo14.MsjExceptionIO, ex);
                Logger.EscribirError(RecursosDAOModulo14.ClaseBDSolicitud, excep);
                throw excep;
            }
            catch (NullReferenceException ex)
            {
                BDSolicitudException excep = new BDSolicitudException(RecursosDAOModulo14.CodigoNullReferencesExcep,
                    RecursosDAOModulo14.MsjNullException, ex);
                Logger.EscribirError(RecursosDAOModulo14.ClaseBDSolicitud, excep);
                throw excep;
            }
            catch (ObjectDisposedException ex)
            {
                BDSolicitudException excep = new BDSolicitudException(RecursosDAOModulo14.CodigoDisposedObject,
                    RecursosDAOModulo14.MensajeDisposedException, ex);
                Logger.EscribirError(RecursosDAOModulo14.ClaseBDSolicitud, excep);
                throw excep;
            }
            catch (ExcepcionesSKD.ExceptionSKDConexionBD ex)
            {
                Logger.EscribirError(RecursosDAOModulo14.ClaseBDSolicitud, ex);

                throw ex;
            }
            catch (FormatException ex)
            {
                BDSolicitudException excep = new BDSolicitudException(RecursosDAOModulo14.CodigoFormatExceptio,
                    RecursosDAOModulo14.MsjFormatException, ex);
                Logger.EscribirError(RecursosDAOModulo14.ClaseBDSolicitud, excep);
                throw excep;
            }
            catch (Exception ex)
            {
                BDSolicitudException excep = new BDSolicitudException(RecursosDAOModulo14.CodigoException,
                    RecursosDAOModulo14.MsjException, ex);
                Logger.EscribirError(RecursosDAOModulo14.ClaseBDSolicitud, excep);
                throw excep;
            }
            return true;
        }


        /// <summary>
        /// Modifica una solicitud en la base de datos
        /// </summary>
        /// <param name="laSolicitud">La solicitud</param>
        /// <returns>returna true en caso de que se completara el registro, y false en caso de que no</returns>
        public bool Modificar(Entidad laSolicitud)
        {
            Logger.EscribirInfo(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name,
                RecursosDAOModulo14.MsjDeEntrada, System.Reflection.MethodBase.GetCurrentMethod().Name);
            // BDConexion laConexion;
            List<Parametro> parametros;
            Parametro parametro = new Parametro();
            DominioSKD.Entidades.Modulo14.SolicitudP solicitud = (
                DominioSKD.Entidades.Modulo14.SolicitudP)laSolicitud;
            try
            {
                //   laConexion = new BDConexion();
                this.Conectar();
                parametros = new List<Parametro>();
                parametro = new Parametro(RecursosDAOModulo14.ParametroIDSolici,
                SqlDbType.VarChar, solicitud.ID.ToString(), false);
                parametros.Add(parametro);

                parametro = new Parametro(RecursosDAOModulo14.ParametroFechaRetiro,
                SqlDbType.VarChar, solicitud.FechaRetiro.ToString(), false);
                parametros.Add(parametro);

                parametro = new Parametro(RecursosDAOModulo14.ParametroFechaReincorporacion,
                SqlDbType.VarChar, solicitud.FechaReincorporacion.ToString(), false);
                parametros.Add(parametro);

                parametro = new Parametro(RecursosDAOModulo14.ParametroMotivo,
                SqlDbType.VarChar, solicitud.Motivo, false);
                parametros.Add(parametro);

                parametro = new Parametro(RecursosDAOModulo14.ParametroIdInscripcion,
                SqlDbType.VarChar, solicitud.IDInscripcion.ToString(), false);
                parametros.Add(parametro);

                string query = RecursosDAOModulo14.ProcedureModificarSolicitud;
                List<Resultado> resultados = this.EjecutarStoredProcedure(query, parametros);

            }
            catch (SqlException ex)
            {
                BDSolicitudException excep = new BDSolicitudException(RecursoGeneralBD.Codigo,
                    RecursoGeneralBD.Mensaje, ex);
                Logger.EscribirError(RecursosDAOModulo14.ClaseBDSolicitud, excep);
                throw excep;
            }
            catch (IOException ex)
            {
                BDSolicitudException excep = new BDSolicitudException(RecursosDAOModulo14.CodigoIoException,
                    RecursosDAOModulo14.MsjExceptionIO, ex);
                Logger.EscribirError(RecursosDAOModulo14.ClaseBDSolicitud, excep);
                throw excep;
            }
            catch (NullReferenceException ex)
            {
                BDSolicitudException excep = new BDSolicitudException(RecursosDAOModulo14.CodigoNullReferencesExcep,
                    RecursosDAOModulo14.MsjNullException, ex);
                Logger.EscribirError(RecursosDAOModulo14.ClaseBDSolicitud, excep);
                throw excep;
            }
            catch (ObjectDisposedException ex)
            {
                BDSolicitudException excep = new BDSolicitudException(RecursosDAOModulo14.CodigoDisposedObject,
                    RecursosDAOModulo14.MensajeDisposedException, ex);
                Logger.EscribirError(RecursosDAOModulo14.ClaseBDSolicitud, excep);
                throw excep;
            }
            catch (ExcepcionesSKD.ExceptionSKDConexionBD ex)
            {
                Logger.EscribirError(RecursosDAOModulo14.ClaseBDSolicitud, ex);

                throw ex;
            }
            catch (FormatException ex)
            {
                BDSolicitudException excep = new BDSolicitudException(RecursosDAOModulo14.CodigoFormatExceptio,
                    RecursosDAOModulo14.MsjFormatException, ex);
                Logger.EscribirError(RecursosDAOModulo14.ClaseBDSolicitud, excep);
                throw excep;
            }
            catch (Exception ex)
            {
                BDSolicitudException excep = new BDSolicitudException(RecursosDAOModulo14.CodigoException,
                    RecursosDAOModulo14.MsjException, ex);
                Logger.EscribirError(RecursosDAOModulo14.ClaseBDSolicitud, excep);
                throw excep;
            }
            return true;
        }

        /// <summary>
        /// Obtiene una solicitud por el ID
        /// </summary>
        /// /// <param name="idSolicitud">id solicitud</param>
        /// <returns>Planilla con nombre, status y tipo de planilla</returns>
        public Entidad ConsultarXId(Entidad idSolicitud)
        {
            Logger.EscribirInfo(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name,
                RecursosDAOModulo14.MsjDeEntrada, System.Reflection.MethodBase.GetCurrentMethod().Name);
            //BDConexion laConexion;
            Entidad solicitud = null;
            List<Parametro> parametros;
            Parametro parametro = new Parametro();
            FabricaEntidades fabricaEntidad = new FabricaEntidades();

            try
            {
                //  laConexion = new BDConexion();
                this.Conectar();
                //    Planilla planilla = null;
                parametros = new List<Parametro>();
                parametro = new Parametro(RecursosDAOModulo14.ParametroIDSolici,
                SqlDbType.VarChar, 
                ((DominioSKD.Entidades.Modulo14.SolicitudP)idSolicitud).ID.ToString(), false);
                parametros.Add(parametro);

                DataTable resultadoConsulta = this.EjecutarStoredProcedureTuplas(RecursosDAOModulo14.ProcedureConsultarSolicitudID1, parametros);

                foreach (DataRow row in resultadoConsulta.Rows)
                {
                    String fechaRetiro = row[RecursosDAOModulo14.AtributoFechaRetiro].ToString();
                    String fechaReincorporacion = row[RecursosDAOModulo14.AtributoFechaReincorporacion].ToString();
                    String motivo = row[RecursosDAOModulo14.AtributoMotivo].ToString();
                    int idPlanilla = Int32.Parse(row[RecursosDAOModulo14.AtributoIdPlanillaDatos].ToString());
                    int idInscripcion = Int32.Parse(row[RecursosDAOModulo14.AtributoInscripcion].ToString());

                    solicitud = fabricaEntidad.ObtenerSolicitudP(fechaRetiro, fechaReincorporacion, motivo, idPlanilla, idInscripcion);
                }

            }
            catch (SqlException ex)
            {
                BDSolicitudException excep = new BDSolicitudException(RecursoGeneralBD.Codigo,
                    RecursoGeneralBD.Mensaje, ex);
                Logger.EscribirError(RecursosDAOModulo14.ClaseBDSolicitud, excep);
                throw excep;
            }
            catch (IOException ex)
            {
                BDSolicitudException excep = new BDSolicitudException(RecursosDAOModulo14.CodigoIoException,
                    RecursosDAOModulo14.MsjExceptionIO, ex);
                Logger.EscribirError(RecursosDAOModulo14.ClaseBDSolicitud, excep);
                throw excep;
            }
            catch (NullReferenceException ex)
            {
                BDSolicitudException excep = new BDSolicitudException(RecursosDAOModulo14.CodigoNullReferencesExcep,
                    RecursosDAOModulo14.MsjNullException, ex);
                Logger.EscribirError(RecursosDAOModulo14.ClaseBDSolicitud, excep);
                throw excep;
            }
            catch (ObjectDisposedException ex)
            {
                BDSolicitudException excep = new BDSolicitudException(RecursosDAOModulo14.CodigoDisposedObject,
                    RecursosDAOModulo14.MensajeDisposedException, ex);
                Logger.EscribirError(RecursosDAOModulo14.ClaseBDSolicitud, excep);
                throw excep;
            }
            catch (ExcepcionesSKD.ExceptionSKDConexionBD ex)
            {
                Logger.EscribirError(RecursosDAOModulo14.ClaseBDSolicitud, ex);

                throw ex;
            }
            catch (FormatException ex)
            {
                BDSolicitudException excep = new BDSolicitudException(RecursosDAOModulo14.CodigoFormatExceptio,
                    RecursosDAOModulo14.MsjFormatException, ex);
                Logger.EscribirError(RecursosDAOModulo14.ClaseBDSolicitud, excep);
                throw excep;
            }
            catch (Exception ex)
            {
                BDSolicitudException excep = new BDSolicitudException(RecursosDAOModulo14.CodigoException,
                    RecursosDAOModulo14.MsjException, ex);
                Logger.EscribirError(RecursosDAOModulo14.ClaseBDSolicitud, excep);
                throw excep;
            }

            return solicitud;
        }

        public List<Entidad> ConsultarTodos()
        {
            return null;
        }

        #endregion 

        #region IDaoSolicitud
    

        /// <summary>
        /// Registra una solicitud de planilla en la base de datos por el ID de persona
        /// </summary>
        /// <param name="">La solicitud</param>
        /// <returns>returna true en caso de que se completara el registro, y false en caso de que no</returns>
        public Boolean RegistrarSolicitudIDPersonaBD(Entidad laSolicitud)
        {
            Logger.EscribirInfo(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name,
                RecursosDAOModulo14.MsjDeEntrada, System.Reflection.MethodBase.GetCurrentMethod().Name);
          //  BDConexion laConexion;
            List<Parametro> parametros;
            Parametro parametro = new Parametro();
            DominioSKD.Entidades.Modulo14.SolicitudP solicitud =
                (DominioSKD.Entidades.Modulo14.SolicitudP)laSolicitud;
            try
            {
               // laConexion = new BDConexion();
                this.Conectar();
                parametros = new List<Parametro>();
                parametro = new Parametro(RecursosDAOModulo14.ParametroFechaRetiro,
                SqlDbType.VarChar, solicitud.FechaRetiro.ToString(), false);
                parametros.Add(parametro);

                parametro = new Parametro(RecursosDAOModulo14.ParametroFechaReincorporacion,
                SqlDbType.VarChar, solicitud.FechaReincorporacion.ToString(), false);
                parametros.Add(parametro);

                parametro = new Parametro(RecursosDAOModulo14.ParametroMotivo,
                SqlDbType.VarChar, solicitud.Motivo, false);
                parametros.Add(parametro);

                parametro = new Parametro(RecursosDAOModulo14.ParametroPlanillaID,
                SqlDbType.VarChar, solicitud.Planilla.ID.ToString(), false);
                parametros.Add(parametro);

                parametro = new Parametro(RecursosDAOModulo14.ParametroPersonaID,
               SqlDbType.VarChar, solicitud.ID.ToString(), false);
                parametros.Add(parametro);

                string query = RecursosDAOModulo14.ProcedimientoAgregarSolicitudIdP;
                List<Resultado> resultados = this.EjecutarStoredProcedure(query, parametros);

            }
            catch (SqlException ex)
            {
                BDSolicitudException excep = new BDSolicitudException(RecursoGeneralBD.Codigo,
                    RecursoGeneralBD.Mensaje, ex);
                Logger.EscribirError(RecursosDAOModulo14.ClaseBDSolicitud, excep);
                throw excep;
            }
            catch (IOException ex)
            {
                BDSolicitudException excep = new BDSolicitudException(RecursosDAOModulo14.CodigoIoException,
                    RecursosDAOModulo14.MsjExceptionIO, ex);
                Logger.EscribirError(RecursosDAOModulo14.ClaseBDSolicitud, excep);
                throw excep;
            }
            catch (NullReferenceException ex)
            {
                BDSolicitudException excep = new BDSolicitudException(RecursosDAOModulo14.CodigoNullReferencesExcep,
                    RecursosDAOModulo14.MsjNullException, ex);
                Logger.EscribirError(RecursosDAOModulo14.ClaseBDSolicitud, excep);
                throw excep;
            }
            catch (ObjectDisposedException ex)
            {
                BDSolicitudException excep = new BDSolicitudException(RecursosDAOModulo14.CodigoDisposedObject,
                    RecursosDAOModulo14.MensajeDisposedException, ex);
                Logger.EscribirError(RecursosDAOModulo14.ClaseBDSolicitud, excep);
                throw excep;
            }
            catch (ExcepcionesSKD.ExceptionSKDConexionBD ex)
            {
                Logger.EscribirError(RecursosDAOModulo14.ClaseBDSolicitud, ex);

                throw ex;
            }
            catch (FormatException ex)
            {
                BDSolicitudException excep = new BDSolicitudException(RecursosDAOModulo14.CodigoFormatExceptio,
                    RecursosDAOModulo14.MsjFormatException, ex);
                Logger.EscribirError(RecursosDAOModulo14.ClaseBDSolicitud, excep);
                throw excep;
            }
            catch (Exception ex)
            {
                BDSolicitudException excep = new BDSolicitudException(RecursosDAOModulo14.CodigoException,
                    RecursosDAOModulo14.MsjException, ex);
                Logger.EscribirError(RecursosDAOModulo14.ClaseBDSolicitud, excep);
                throw excep;
            }
            return true;
        }

        /// <summary>
        /// Obtiene los eventos de una inscripcion
        /// </summary>
        /// /// <param name="">id persona</param>
        /// <returns>eventos de una inscripcion</returns>
        public List<Entidad> ObtenerEventosSolicitud(int idPersona)
        {
            Logger.EscribirInfo(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name,
                RecursosDAOModulo14.MsjDeEntrada, System.Reflection.MethodBase.GetCurrentMethod().Name);
           // BDConexion laConexion;
            List<Parametro> parametros;
            Parametro parametro = new Parametro();
            List<Entidad> eventos = new List<Entidad>();
            FabricaEntidades fabricaEntidad = new FabricaEntidades();
            try
            {
              //  laConexion = new BDConexion();
                this.Conectar();
                parametros = new List<Parametro>();

                parametro = new Parametro(RecursosDAOModulo14.ParametroPersonaPerId,
                SqlDbType.VarChar, idPersona.ToString(), false);
                parametros.Add(parametro);

                DataTable resultadoConsulta = this.EjecutarStoredProcedureTuplas(RecursosDAOModulo14.ProcedureConsultarEventoSolicitud, parametros);

                foreach (DataRow row in resultadoConsulta.Rows)
                {
                    Entidad laSolicitud = fabricaEntidad.ObtenerSolicitudP(Int32.Parse(row[RecursosDAOModulo14.AtributoInscripcionID].ToString()), row[RecursosDAOModulo14.AtributoEventoNombre].ToString());
                    eventos.Add(laSolicitud);

                }

            }
            catch (SqlException ex)
            {
                BDSolicitudException excep = new BDSolicitudException(RecursoGeneralBD.Codigo,
                    RecursoGeneralBD.Mensaje, ex);
                Logger.EscribirError(RecursosDAOModulo14.ClaseBDSolicitud, excep);
                throw excep;
            }
            catch (IOException ex)
            {
                BDSolicitudException excep = new BDSolicitudException(RecursosDAOModulo14.CodigoIoException,
                    RecursosDAOModulo14.MsjExceptionIO, ex);
                Logger.EscribirError(RecursosDAOModulo14.ClaseBDSolicitud, excep);
                throw excep;
            }
            catch (NullReferenceException ex)
            {
                BDSolicitudException excep = new BDSolicitudException(RecursosDAOModulo14.CodigoNullReferencesExcep,
                    RecursosDAOModulo14.MsjNullException, ex);
                Logger.EscribirError(RecursosDAOModulo14.ClaseBDSolicitud, excep);
                throw excep;
            }
            catch (ObjectDisposedException ex)
            {
                BDSolicitudException excep = new BDSolicitudException(RecursosDAOModulo14.CodigoDisposedObject,
                    RecursosDAOModulo14.MensajeDisposedException, ex);
                Logger.EscribirError(RecursosDAOModulo14.ClaseBDSolicitud, excep);
                throw excep;
            }
            catch (ExcepcionesSKD.ExceptionSKDConexionBD ex)
            {
                Logger.EscribirError(RecursosDAOModulo14.ClaseBDSolicitud, ex);

                throw ex;
            }
            catch (FormatException ex)
            {
                BDSolicitudException excep = new BDSolicitudException(RecursosDAOModulo14.CodigoFormatExceptio,
                    RecursosDAOModulo14.MsjFormatException, ex);
                Logger.EscribirError(RecursosDAOModulo14.ClaseBDSolicitud, excep);
                throw excep;
            }
            catch (Exception ex)
            {
                BDSolicitudException excep = new BDSolicitudException(RecursosDAOModulo14.CodigoException,
                    RecursosDAOModulo14.MsjException, ex);
                Logger.EscribirError(RecursosDAOModulo14.ClaseBDSolicitud, excep);
                throw excep;
            }

            return eventos;
        }

        /// <summary>
        /// Obtiene los eventos de una inscripcion
        /// </summary>
        /// /// <param name="">id persona</param>
        /// <returns>eventos de una inscripcion</returns>
        public List<Entidad> ObtenerCompetenciaSolicitud(int idPersona)
        {
            Logger.EscribirInfo(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name,
                RecursosDAOModulo14.MsjDeEntrada, System.Reflection.MethodBase.GetCurrentMethod().Name);
            //BDConexion laConexion;
            List<Parametro> parametros;
            Parametro parametro = new Parametro();
            List<Entidad> competencias = new List<Entidad>();
            FabricaEntidades fabricaEntidad = new FabricaEntidades();
            try
            {
                //laConexion = new BDConexion();
                this.Conectar();
                parametros = new List<Parametro>();

                parametro = new Parametro(RecursosDAOModulo14.ParametroPersonaPerId,
                SqlDbType.VarChar, idPersona.ToString(), false);
                parametros.Add(parametro);

                DataTable resultadoConsulta = this.EjecutarStoredProcedureTuplas(RecursosDAOModulo14.ProcedimientoConsultarCompeteniaSolicitud, parametros);

                foreach (DataRow row in resultadoConsulta.Rows)
                {
                    Entidad laSolicitud = fabricaEntidad.ObtenerSolicitudP(Int32.Parse(row[RecursosDAOModulo14.AtributoInscripcionID].ToString()), row[RecursosDAOModulo14.AtributoCompetenciaNombre].ToString());
                    competencias.Add(laSolicitud);

                }

            }
            catch (SqlException ex)
            {
                BDSolicitudException excep = new BDSolicitudException(RecursoGeneralBD.Codigo,
                    RecursoGeneralBD.Mensaje, ex);
                Logger.EscribirError(RecursosDAOModulo14.ClaseBDSolicitud, excep);
                throw excep;
            }
            catch (IOException ex)
            {
                BDSolicitudException excep = new BDSolicitudException(RecursosDAOModulo14.CodigoIoException,
                    RecursosDAOModulo14.MsjExceptionIO, ex);
                Logger.EscribirError(RecursosDAOModulo14.ClaseBDSolicitud, excep);
                throw excep;
            }
            catch (NullReferenceException ex)
            {
                BDSolicitudException excep = new BDSolicitudException(RecursosDAOModulo14.CodigoNullReferencesExcep,
                    RecursosDAOModulo14.MsjNullException, ex);
                Logger.EscribirError(RecursosDAOModulo14.ClaseBDSolicitud, excep);
                throw excep;
            }
            catch (ObjectDisposedException ex)
            {
                BDSolicitudException excep = new BDSolicitudException(RecursosDAOModulo14.CodigoDisposedObject,
                    RecursosDAOModulo14.MensajeDisposedException, ex);
                Logger.EscribirError(RecursosDAOModulo14.ClaseBDSolicitud, excep);
                throw excep;
            }
            catch (ExcepcionesSKD.ExceptionSKDConexionBD ex)
            {
                Logger.EscribirError(RecursosDAOModulo14.ClaseBDSolicitud, ex);

                throw ex;
            }
            catch (FormatException ex)
            {
                BDSolicitudException excep = new BDSolicitudException(RecursosDAOModulo14.CodigoFormatExceptio,
                    RecursosDAOModulo14.MsjFormatException, ex);
                Logger.EscribirError(RecursosDAOModulo14.ClaseBDSolicitud, excep);
                throw excep;
            }
            catch (Exception ex)
            {
                BDSolicitudException excep = new BDSolicitudException(RecursosDAOModulo14.CodigoException,
                    RecursosDAOModulo14.MsjException, ex);
                Logger.EscribirError(RecursosDAOModulo14.ClaseBDSolicitud, excep);
                throw excep;
            }

            return competencias;
        }

        /// <summary>
        /// Método que consulta las planillas que una persona puede solicitar
        /// </summary>
        /// <returns>Retorna una lista planillas habilitadas para solicitar</returns>
        public List<Entidad> ConsultarPlanillasASolicitarBD()
        {
            Logger.EscribirInfo(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name,
                RecursosDAOModulo14.MsjDeEntrada, System.Reflection.MethodBase.GetCurrentMethod().Name);
            SqlConnection conect = Conectar();
            FabricaEntidades fabricaEntidad = new FabricaEntidades();
            List<Entidad> lista = new List<Entidad>();
            DominioSKD.Entidades.Modulo14.Planilla planilla =
                (DominioSKD.Entidades.Modulo14.Planilla)fabricaEntidad.ObtenerPlanilla();

            try
            {

                SqlCommand sqlcom = new SqlCommand(RecursosDAOModulo14.ProcedureConsultarPlanillasASolicitar, conect);
                sqlcom.CommandType = CommandType.StoredProcedure;

                SqlDataReader leer;
                conect.Open();

                leer = sqlcom.ExecuteReader();
                if (leer != null)
                {
                    while (leer.Read())
                    {
                        planilla = new DominioSKD.Entidades.Modulo14.Planilla();
                        DominioSKD.Entidades.Modulo14.Diseño diseño =
                            new DominioSKD.Entidades.Modulo14.Diseño();
                        planilla.Diseño = diseño;
                        planilla.ID = Convert.ToInt32(leer[RecursosDAOModulo14.AtributoIdPlanilla]);
                        planilla.Nombre = leer[RecursosDAOModulo14.AtributoNombrePlanilla].ToString();
                        planilla.Diseño.ID = Convert.ToInt32(leer[RecursosDAOModulo14.AtributoIdDiseño]);
                        planilla.TipoPlanilla = leer[RecursosDAOModulo14.AtributoTipo].ToString();
                        lista.Add(planilla);
                        diseño = null;
                        planilla = null;

                    }

                    return lista;
                }
                else
                {
                    return null;
                }
            }
            catch (SqlException ex)
            {
                BDSolicitudException excep = new BDSolicitudException(RecursoGeneralBD.Codigo,
                    RecursoGeneralBD.Mensaje, ex);
                Logger.EscribirError(RecursosDAOModulo14.ClaseBDSolicitud, excep);
                throw excep;
            }
            catch (IOException ex)
            {
                BDSolicitudException excep = new BDSolicitudException(RecursosDAOModulo14.CodigoIoException,
                    RecursosDAOModulo14.MsjExceptionIO, ex);
                Logger.EscribirError(RecursosDAOModulo14.ClaseBDSolicitud, excep);
                throw excep;
            }
            catch (NullReferenceException ex)
            {
                BDSolicitudException excep = new BDSolicitudException(RecursosDAOModulo14.CodigoNullReferencesExcep,
                    RecursosDAOModulo14.MsjNullException, ex);
                Logger.EscribirError(RecursosDAOModulo14.ClaseBDSolicitud, excep);
                throw excep;
            }
            catch (ObjectDisposedException ex)
            {
                BDSolicitudException excep = new BDSolicitudException(RecursosDAOModulo14.CodigoDisposedObject,
                    RecursosDAOModulo14.MensajeDisposedException, ex);
                Logger.EscribirError(RecursosDAOModulo14.ClaseBDSolicitud, excep);
                throw excep;
            }
            catch (ExcepcionesSKD.ExceptionSKDConexionBD ex)
            {
                Logger.EscribirError(RecursosDAOModulo14.ClaseBDSolicitud, ex);

                throw ex;
            }
            catch (FormatException ex)
            {
                BDSolicitudException excep = new BDSolicitudException(RecursosDAOModulo14.CodigoFormatExceptio,
                    RecursosDAOModulo14.MsjFormatException, ex);
                Logger.EscribirError(RecursosDAOModulo14.ClaseBDSolicitud, excep);
                throw excep;
            }
            catch (Exception ex)
            {
                BDSolicitudException excep = new BDSolicitudException(RecursosDAOModulo14.CodigoException,
                    RecursosDAOModulo14.MsjException, ex);
                Logger.EscribirError(RecursosDAOModulo14.ClaseBDSolicitud, excep);
                throw excep;
            }
            finally
            {
                Desconectar(conect);
            }
        }

        /// <summary>
        /// Elimina una solicitud que se haya procesado
        /// </summary>
        /// <param name="idSolicitud">Es el id de la solicitud que se desea eliminar</param>
        /// <returns>Verdadero si se realizó con éxito la operación 
        /// de lo contrario devuelve falso</returns>
        public Boolean EliminarSolicitudBD(int idSolicitud)
        {
            Logger.EscribirInfo(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name,
                RecursosDAOModulo14.MsjDeEntrada, System.Reflection.MethodBase.GetCurrentMethod().Name);
            SqlConnection conect = Conectar();
            try
            {
                SqlCommand sqlcom = new SqlCommand(RecursosDAOModulo14.ProcedureEliminarSolicitud, conect);
                sqlcom.CommandType = CommandType.StoredProcedure;
                sqlcom.Parameters.Add(new SqlParameter(RecursosDAOModulo14.ParametroIdSolicitud,
                    SqlDbType.Int));

                sqlcom.Parameters[RecursosDAOModulo14.ParametroIdSolicitud].Value = idSolicitud;

                SqlDataReader leer;
                conect.Open();

                leer = sqlcom.ExecuteReader();
                return true;
            }
            catch (SqlException ex)
            {
                BDSolicitudException excep = new BDSolicitudException(RecursoGeneralBD.Codigo,
                    RecursoGeneralBD.Mensaje, ex);
                Logger.EscribirError(RecursosDAOModulo14.ClaseBDSolicitud, excep);
                throw excep;
            }
            catch (IOException ex)
            {
                BDSolicitudException excep = new BDSolicitudException(RecursosDAOModulo14.CodigoIoException,
                    RecursosDAOModulo14.MsjExceptionIO, ex);
                Logger.EscribirError(RecursosDAOModulo14.ClaseBDSolicitud, excep);
                throw excep;
            }
            catch (NullReferenceException ex)
            {
                BDSolicitudException excep = new BDSolicitudException(RecursosDAOModulo14.CodigoNullReferencesExcep,
                    RecursosDAOModulo14.MsjNullException, ex);
                Logger.EscribirError(RecursosDAOModulo14.ClaseBDSolicitud, excep);
                throw excep;
            }
            catch (ObjectDisposedException ex)
            {
                BDSolicitudException excep = new BDSolicitudException(RecursosDAOModulo14.CodigoDisposedObject,
                    RecursosDAOModulo14.MensajeDisposedException, ex);
                Logger.EscribirError(RecursosDAOModulo14.ClaseBDSolicitud, excep);
                throw excep;
            }
            catch (ExcepcionesSKD.ExceptionSKDConexionBD ex)
            {
                Logger.EscribirError(RecursosDAOModulo14.ClaseBDSolicitud, ex);

                throw ex;
            }
            catch (FormatException ex)
            {
                BDSolicitudException excep = new BDSolicitudException(RecursosDAOModulo14.CodigoFormatExceptio,
                    RecursosDAOModulo14.MsjFormatException, ex);
                Logger.EscribirError(RecursosDAOModulo14.ClaseBDSolicitud, excep);
                throw excep;
            }
            catch (Exception ex)
            {
                BDSolicitudException excep = new BDSolicitudException(RecursosDAOModulo14.CodigoException,
                    RecursosDAOModulo14.MsjException, ex);
                Logger.EscribirError(RecursosDAOModulo14.ClaseBDSolicitud, excep);
                throw excep;
            }
            finally
            {
                Desconectar(conect);
            }
        }

        /// <summary>
        /// Método que consulta las solicitudes de planilla que ha hecho una persona
        /// </summary>
        /// <param name="idPersona">id de la persona vinculada
        /// a las solicitudes</param>
        /// <returns>Devuelve una lista de solicitudes</returns>
        public List<Entidad> ConsultarSolicitudes(int idPersona)
        {
            Logger.EscribirInfo(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name,
                RecursosDAOModulo14.MsjDeEntrada, System.Reflection.MethodBase.GetCurrentMethod().Name);
            SqlConnection conect = Conectar();
            List<Entidad> lista = new List<Entidad>();
            FabricaEntidades fabricaEntidad = new FabricaEntidades();
            DominioSKD.Entidades.Modulo14.SolicitudPlanilla solicitud;

            try
            {

                SqlCommand sqlcom = new SqlCommand(RecursosDAOModulo14.ProcedureConsultarSolicitudPlanilla, conect);
                sqlcom.CommandType = CommandType.StoredProcedure;
                sqlcom.Parameters.Add(new SqlParameter(RecursosDAOModulo14.ParametroPersonaPerId, idPersona));

                SqlDataReader leer;
                conect.Open();

                leer = sqlcom.ExecuteReader();
                if (leer != null)
                {
                    while (leer.Read())
                    {
                        solicitud = 
                            (DominioSKD.Entidades.Modulo14.SolicitudPlanilla)fabricaEntidad.ObtenerSolicitudPlanilla();
                        DominioSKD.Entidades.Modulo14.Planilla planilla = new DominioSKD.Entidades.Modulo14.Planilla();
                        solicitud.Planilla = planilla;
                        solicitud.ID = Convert.ToInt32(leer[RecursosDAOModulo14.AtributoIdSolicitud]);
                        solicitud.IdInscripcion = Convert.ToInt32(leer[RecursosDAOModulo14.AtributoInscripcion]);
                        solicitud.FechaCreacion = Convert.ToDateTime(leer[RecursosDAOModulo14.AtributoFechaCreacion]);
                        solicitud.FechaRetiro = Convert.ToDateTime(leer[RecursosDAOModulo14.AtributoFechaRetiro]);
                        solicitud.FechaReincorporacion = Convert.ToDateTime(leer[RecursosDAOModulo14.AtributoFechaReincorporacion]);
                        solicitud.Motivo = leer[RecursosDAOModulo14.AtributoMotivo].ToString();
                        solicitud.Planilla.ID = Convert.ToInt32(leer[RecursosDAOModulo14.AtributoIdPlanillaDatos]);
                        solicitud.Planilla.Nombre = leer[RecursosDAOModulo14.AtributoNombrePlanilla].ToString();
                        solicitud.Planilla.TipoPlanilla = leer[RecursosDAOModulo14.AtributoTipo].ToString();
                        if (leer[RecursosDAOModulo14.AtributoEventoNombre].ToString() != "")
                            solicitud.Evento = leer[RecursosDAOModulo14.AtributoEventoNombre].ToString();
                        else
                            solicitud.Evento = leer[RecursosDAOModulo14.AtributoCompetenciaNombre].ToString();
                        lista.Add(solicitud);
                        planilla = null;
                        solicitud = null;

                    }

                    return lista;
                }
                else
                {
                    return null;
                }
            }
            catch (SqlException ex)
            {
                BDSolicitudException excep = new BDSolicitudException(RecursoGeneralBD.Codigo,
                    RecursoGeneralBD.Mensaje, ex);
                Logger.EscribirError(RecursosDAOModulo14.ClaseBDSolicitud, excep);
                throw excep;
            }
            catch (IOException ex)
            {
                BDSolicitudException excep = new BDSolicitudException(RecursosDAOModulo14.CodigoIoException,
                    RecursosDAOModulo14.MsjExceptionIO, ex);
                Logger.EscribirError(RecursosDAOModulo14.ClaseBDSolicitud, excep);
                throw excep;
            }
            catch (NullReferenceException ex)
            {
                BDSolicitudException excep = new BDSolicitudException(RecursosDAOModulo14.CodigoNullReferencesExcep,
                    RecursosDAOModulo14.MsjNullException, ex);
                Logger.EscribirError(RecursosDAOModulo14.ClaseBDSolicitud, excep);
                throw excep;
            }
            catch (ObjectDisposedException ex)
            {
                BDSolicitudException excep = new BDSolicitudException(RecursosDAOModulo14.CodigoDisposedObject,
                    RecursosDAOModulo14.MensajeDisposedException, ex);
                Logger.EscribirError(RecursosDAOModulo14.ClaseBDSolicitud, excep);
                throw excep;
            }
            catch (ExcepcionesSKD.ExceptionSKDConexionBD ex)
            {
                Logger.EscribirError(RecursosDAOModulo14.ClaseBDSolicitud, ex);

                throw ex;
            }
            catch (FormatException ex)
            {
                BDSolicitudException excep = new BDSolicitudException(RecursosDAOModulo14.CodigoFormatExceptio,
                    RecursosDAOModulo14.MsjFormatException, ex);
                Logger.EscribirError(RecursosDAOModulo14.ClaseBDSolicitud, excep);
                throw excep;
            }
            catch (Exception ex)
            {
                BDSolicitudException excep = new BDSolicitudException(RecursosDAOModulo14.CodigoException,
                    RecursosDAOModulo14.MsjException, ex);
                Logger.EscribirError(RecursosDAOModulo14.ClaseBDSolicitud, excep);
                throw excep;
            }
            finally
            {
                Desconectar(conect);
            }
        }
       


        #endregion
    }
}
