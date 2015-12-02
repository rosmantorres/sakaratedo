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
using ExcepcionesSKD;
using ExcepcionesSKD.Modulo14;
using System.Globalization;
using System.IO;

namespace DatosSKD.Modulo14
{
    public class BDSolicitud
    {
        private BDConexion con = new BDConexion();

        /// <summary>
        /// Método que consulta las solicitudes que ha hecho una persona
        /// </summary>
        /// <param name="idPersona">id de la persona vinculada
        /// a las solicitudes</param>
        /// <returns>una lista de solicitudes</returns>
        public List<DominioSKD.SolicitudPlanilla> ConsultarSolicitudes(int idPersona)
        {
            Logger.EscribirInfo(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name,
                RecursosBDModulo14.MsjDeEntrada, System.Reflection.MethodBase.GetCurrentMethod().Name);
            SqlConnection conect = con.Conectar();
            List<DominioSKD.SolicitudPlanilla> lista = new List<DominioSKD.SolicitudPlanilla>();
            SolicitudPlanilla solicitud;

            try
            {

                SqlCommand sqlcom = new SqlCommand(RecursosBDModulo14.ProcedureConsultarSolicitudPlanilla, conect);
                sqlcom.CommandType = CommandType.StoredProcedure;
                sqlcom.Parameters.Add(new SqlParameter(RecursosBDModulo14.ParametroPersonaPerId, idPersona));

                SqlDataReader leer;
                conect.Open();

                leer = sqlcom.ExecuteReader();
                if (leer != null)
                {
                    while (leer.Read())
                    {
                        solicitud = new SolicitudPlanilla();
                        DominioSKD.Planilla planilla = new Planilla();
                        solicitud.Planilla = planilla;
                        solicitud.ID = Convert.ToInt32(leer[RecursosBDModulo14.AtributoIdSolicitud]);
                        solicitud.IdInscripcion = Convert.ToInt32(leer[RecursosBDModulo14.AtributoInscripcion]);
                        solicitud.FechaCreacion = Convert.ToDateTime(leer[RecursosBDModulo14.AtributoFechaCreacion]);
                        solicitud.FechaRetiro = Convert.ToDateTime(leer[RecursosBDModulo14.AtributoFechaRetiro]);
                        solicitud.FechaReincorporacion = Convert.ToDateTime(leer[RecursosBDModulo14.AtributoFechaReincorporacion]);
                        solicitud.Motivo = leer[RecursosBDModulo14.AtributoMotivo].ToString();
                        solicitud.Planilla.ID = Convert.ToInt32(leer[RecursosBDModulo14.AtributoIdPlanillaDatos]);
                        solicitud.Planilla.Nombre = leer[RecursosBDModulo14.AtributoNombrePlanilla].ToString();
                        solicitud.Planilla.TipoPlanilla = leer[RecursosBDModulo14.AtributoTipo].ToString();
                        if (leer[RecursosBDModulo14.AtributoEventoNombre].ToString() != "")
                            solicitud.Evento = leer[RecursosBDModulo14.AtributoEventoNombre].ToString();
                        else
                            solicitud.Evento = leer[RecursosBDModulo14.AtributoCompetenciaNombre].ToString();
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
                Logger.EscribirError(RecursosBDModulo14.ClaseBDSolicitud, excep);
                throw excep;
            }
            catch (IOException ex)
            {
                BDSolicitudException excep = new BDSolicitudException(RecursosBDModulo14.CodigoIoException,
                    RecursosBDModulo14.MsjExceptionIO, ex);
                Logger.EscribirError(RecursosBDModulo14.ClaseBDSolicitud, excep);
                throw excep;
            }
            catch (NullReferenceException ex)
            {
                BDSolicitudException excep = new BDSolicitudException(RecursosBDModulo14.CodigoNullReferencesExcep,
                    RecursosBDModulo14.MsjNullException, ex);
                Logger.EscribirError(RecursosBDModulo14.ClaseBDSolicitud, excep);
                throw excep;
            }
            catch (ObjectDisposedException ex)
            {
                BDSolicitudException excep = new BDSolicitudException(RecursosBDModulo14.CodigoDisposedObject,
                    RecursosBDModulo14.MensajeDisposedException, ex);
                Logger.EscribirError(RecursosBDModulo14.ClaseBDSolicitud, excep);
                throw excep;
            }
            catch (ExcepcionesSKD.ExceptionSKDConexionBD ex)
            {
                Logger.EscribirError(RecursosBDModulo14.ClaseBDSolicitud, ex);

                throw ex;
            }
            catch (FormatException ex)
            {
                BDSolicitudException excep = new BDSolicitudException(RecursosBDModulo14.CodigoFormatExceptio,
                    RecursosBDModulo14.MsjFormatException, ex);
                Logger.EscribirError(RecursosBDModulo14.ClaseBDSolicitud, excep);
                throw excep;
            }
            catch (Exception ex)
            {
                BDSolicitudException excep = new BDSolicitudException(RecursosBDModulo14.CodigoException,
                    RecursosBDModulo14.MsjException, ex);
                Logger.EscribirError(RecursosBDModulo14.ClaseBDSolicitud, excep);
                throw excep;
            }
            finally
            {
                con.Desconectar(conect);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="diseño"></param>
        /// <param name="planilla"></param>
        /// <returns></returns>
        public Boolean EliminarSolicitudBD(int idSolicitud)
        {
            Logger.EscribirInfo(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name,
                RecursosBDModulo14.MsjDeEntrada, System.Reflection.MethodBase.GetCurrentMethod().Name);
            SqlConnection conect = con.Conectar();
            try
            {
                    SqlCommand sqlcom = new SqlCommand(RecursosBDModulo14.ProcedureEliminarSolicitud, conect);
                    sqlcom.CommandType = CommandType.StoredProcedure;
                    sqlcom.Parameters.Add(new SqlParameter(RecursosBDModulo14.ParametroIdSolicitud,
                        SqlDbType.Int));

                    sqlcom.Parameters[RecursosBDModulo14.ParametroIdSolicitud].Value = idSolicitud;

                    SqlDataReader leer;
                    conect.Open();

                    leer = sqlcom.ExecuteReader();
                    return true;
            }
            catch (SqlException ex)
            {
                BDSolicitudException excep = new BDSolicitudException(RecursoGeneralBD.Codigo,
                    RecursoGeneralBD.Mensaje, ex);
                Logger.EscribirError(RecursosBDModulo14.ClaseBDSolicitud, excep);
                throw excep;
            }
            catch (IOException ex)
            {
                BDSolicitudException excep = new BDSolicitudException(RecursosBDModulo14.CodigoIoException,
                    RecursosBDModulo14.MsjExceptionIO, ex);
                Logger.EscribirError(RecursosBDModulo14.ClaseBDSolicitud, excep);
                throw excep;
            }
            catch (NullReferenceException ex)
            {
                BDSolicitudException excep = new BDSolicitudException(RecursosBDModulo14.CodigoNullReferencesExcep,
                    RecursosBDModulo14.MsjNullException, ex);
                Logger.EscribirError(RecursosBDModulo14.ClaseBDSolicitud, excep);
                throw excep;
            }
            catch (ObjectDisposedException ex)
            {
                BDSolicitudException excep = new BDSolicitudException(RecursosBDModulo14.CodigoDisposedObject,
                    RecursosBDModulo14.MensajeDisposedException, ex);
                Logger.EscribirError(RecursosBDModulo14.ClaseBDSolicitud, excep);
                throw excep;
            }
            catch (ExcepcionesSKD.ExceptionSKDConexionBD ex)
            {
                Logger.EscribirError(RecursosBDModulo14.ClaseBDSolicitud, ex);

                throw ex;
            }
            catch (FormatException ex)
            {
                BDSolicitudException excep = new BDSolicitudException(RecursosBDModulo14.CodigoFormatExceptio,
                    RecursosBDModulo14.MsjFormatException, ex);
                Logger.EscribirError(RecursosBDModulo14.ClaseBDSolicitud, excep);
                throw excep;
            }
            catch (Exception ex)
            {
                BDSolicitudException excep = new BDSolicitudException(RecursosBDModulo14.CodigoException,
                    RecursosBDModulo14.MsjException, ex);
                Logger.EscribirError(RecursosBDModulo14.ClaseBDSolicitud, excep);
                throw excep;
            }
            finally
            {
                con.Desconectar(conect);
            }
        }

        /// <summary>
        /// Método que consulta las planillas que una persona puede solicitar
        /// </summary>
        /// <param name="idPersona"></param>
        /// <returns></returns>
        public List<DominioSKD.Planilla> ConsultarPlanillasASolicitarBD()
        {
            Logger.EscribirInfo(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name,
                RecursosBDModulo14.MsjDeEntrada, System.Reflection.MethodBase.GetCurrentMethod().Name);
            SqlConnection conect = con.Conectar();
            List<DominioSKD.Planilla> lista = new List<DominioSKD.Planilla>();
             DominioSKD.Planilla planilla;

            try
            {

                SqlCommand sqlcom = new SqlCommand(RecursosBDModulo14.ProcedureConsultarPlanillasASolicitar, conect);
                sqlcom.CommandType = CommandType.StoredProcedure;

                SqlDataReader leer;
                conect.Open();

                leer = sqlcom.ExecuteReader();
                if (leer != null)
                {
                    while (leer.Read())
                    {
                        planilla = new Planilla();
                        Diseño diseño = new Diseño();
                        planilla.Diseño = diseño;
                        planilla.ID = Convert.ToInt32(leer[RecursosBDModulo14.AtributoIdPlanilla]);
                        planilla.Nombre = leer[RecursosBDModulo14.AtributoNombrePlanilla].ToString();
                        planilla.Diseño.ID = Convert.ToInt32(leer[RecursosBDModulo14.AtributoIdDiseño]);
                        planilla.TipoPlanilla = leer[RecursosBDModulo14.AtributoTipo].ToString();
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
                Logger.EscribirError(RecursosBDModulo14.ClaseBDSolicitud, excep);
                throw excep;
            }
            catch (IOException ex)
            {
                BDSolicitudException excep = new BDSolicitudException(RecursosBDModulo14.CodigoIoException,
                    RecursosBDModulo14.MsjExceptionIO, ex);
                Logger.EscribirError(RecursosBDModulo14.ClaseBDSolicitud, excep);
                throw excep;
            }
            catch (NullReferenceException ex)
            {
                BDSolicitudException excep = new BDSolicitudException(RecursosBDModulo14.CodigoNullReferencesExcep,
                    RecursosBDModulo14.MsjNullException, ex);
                Logger.EscribirError(RecursosBDModulo14.ClaseBDSolicitud, excep);
                throw excep;
            }
            catch (ObjectDisposedException ex)
            {
                BDSolicitudException excep = new BDSolicitudException(RecursosBDModulo14.CodigoDisposedObject,
                    RecursosBDModulo14.MensajeDisposedException, ex);
                Logger.EscribirError(RecursosBDModulo14.ClaseBDSolicitud, excep);
                throw excep;
            }
            catch (ExcepcionesSKD.ExceptionSKDConexionBD ex)
            {
                Logger.EscribirError(RecursosBDModulo14.ClaseBDSolicitud, ex);

                throw ex;
            }
            catch (FormatException ex)
            {
                BDSolicitudException excep = new BDSolicitudException(RecursosBDModulo14.CodigoFormatExceptio,
                    RecursosBDModulo14.MsjFormatException, ex);
                Logger.EscribirError(RecursosBDModulo14.ClaseBDSolicitud, excep);
                throw excep;
            }
            catch (Exception ex)
            {
                BDSolicitudException excep = new BDSolicitudException(RecursosBDModulo14.CodigoException,
                    RecursosBDModulo14.MsjException, ex);
                Logger.EscribirError(RecursosBDModulo14.ClaseBDSolicitud, excep);
                throw excep;
            }
            finally
            {
                con.Desconectar(conect);
            }
        }

        /// <summary>
        /// Registra una solicitud de planilla en la base de datos
        /// </summary>
        /// <param name="">La solicitud</param>
        /// <returns>returna true en caso de que se completara el registro, y false en caso de que no</returns>

        public Boolean RegistrarSolicitudPlanillaBD(SolicitudP laSolicitud)
        {
            Logger.EscribirInfo(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name,
                RecursosBDModulo14.MsjDeEntrada, System.Reflection.MethodBase.GetCurrentMethod().Name);
            BDConexion laConexion;
            List<Parametro> parametros;
            Parametro parametro = new Parametro();

            try
            {
                laConexion = new BDConexion();
                parametros = new List<Parametro>();
                parametro = new Parametro(RecursosBDModulo14.ParametroFechaRetiro,
                SqlDbType.VarChar, laSolicitud.FechaRetiro.ToString(), false);
                parametros.Add(parametro);

                parametro = new Parametro(RecursosBDModulo14.ParametroFechaReincorporacion,
                SqlDbType.VarChar, laSolicitud.FechaReincorporacion.ToString(), false);
                parametros.Add(parametro);

                parametro = new Parametro(RecursosBDModulo14.ParametroMotivo,
                SqlDbType.VarChar, laSolicitud.Motivo, false);
                parametros.Add(parametro);

                parametro = new Parametro(RecursosBDModulo14.ParametroPlanillaID,
                SqlDbType.VarChar, laSolicitud.Planilla.ID.ToString(), false);
                parametros.Add(parametro);

                parametro = new Parametro(RecursosBDModulo14.ParametroIdInscripcion,
               SqlDbType.VarChar, laSolicitud.ID.ToString(), false);
                parametros.Add(parametro);

                string query = RecursosBDModulo14.ProcedimientoAgregarSolicitud;
                List<Resultado> resultados = laConexion.EjecutarStoredProcedure(query, parametros);

            }
            catch (SqlException ex)
            {
                BDSolicitudException excep = new BDSolicitudException(RecursoGeneralBD.Codigo,
                    RecursoGeneralBD.Mensaje, ex);
                Logger.EscribirError(RecursosBDModulo14.ClaseBDSolicitud, excep);
                throw excep;
            }
            catch (IOException ex)
            {
                BDSolicitudException excep = new BDSolicitudException(RecursosBDModulo14.CodigoIoException,
                    RecursosBDModulo14.MsjExceptionIO, ex);
                Logger.EscribirError(RecursosBDModulo14.ClaseBDSolicitud, excep);
                throw excep;
            }
            catch (NullReferenceException ex)
            {
                BDSolicitudException excep = new BDSolicitudException(RecursosBDModulo14.CodigoNullReferencesExcep,
                    RecursosBDModulo14.MsjNullException, ex);
                Logger.EscribirError(RecursosBDModulo14.ClaseBDSolicitud, excep);
                throw excep;
            }
            catch (ObjectDisposedException ex)
            {
                BDSolicitudException excep = new BDSolicitudException(RecursosBDModulo14.CodigoDisposedObject,
                    RecursosBDModulo14.MensajeDisposedException, ex);
                Logger.EscribirError(RecursosBDModulo14.ClaseBDSolicitud, excep);
                throw excep;
            }
            catch (ExcepcionesSKD.ExceptionSKDConexionBD ex)
            {
                Logger.EscribirError(RecursosBDModulo14.ClaseBDSolicitud, ex);

                throw ex;
            }
            catch (FormatException ex)
            {
                BDSolicitudException excep = new BDSolicitudException(RecursosBDModulo14.CodigoFormatExceptio,
                    RecursosBDModulo14.MsjFormatException, ex);
                Logger.EscribirError(RecursosBDModulo14.ClaseBDSolicitud, excep);
                throw excep;
            }
            catch (Exception ex)
            {
                BDSolicitudException excep = new BDSolicitudException(RecursosBDModulo14.CodigoException,
                    RecursosBDModulo14.MsjException, ex);
                Logger.EscribirError(RecursosBDModulo14.ClaseBDSolicitud, excep);
                throw excep;
            }
            return true;
        }

        /// <summary>
        /// Registra una solicitud de planilla en la base de datos por el ID de persona
        /// </summary>
        /// <param name="">La solicitud</param>
        /// <returns>returna true en caso de que se completara el registro, y false en caso de que no</returns>
        public Boolean RegistrarSolicitudIDPersonaBD(SolicitudP laSolicitud)
        {
            Logger.EscribirInfo(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name,
                RecursosBDModulo14.MsjDeEntrada, System.Reflection.MethodBase.GetCurrentMethod().Name);
            BDConexion laConexion;
            List<Parametro> parametros;
            Parametro parametro = new Parametro();

            try
            {
                laConexion = new BDConexion();
                parametros = new List<Parametro>();
                parametro = new Parametro(RecursosBDModulo14.ParametroFechaRetiro,
                SqlDbType.VarChar, laSolicitud.FechaRetiro.ToString(), false);
                parametros.Add(parametro);

                parametro = new Parametro(RecursosBDModulo14.ParametroFechaReincorporacion,
                SqlDbType.VarChar, laSolicitud.FechaReincorporacion.ToString(), false);
                parametros.Add(parametro);

                parametro = new Parametro(RecursosBDModulo14.ParametroMotivo,
                SqlDbType.VarChar, laSolicitud.Motivo, false);
                parametros.Add(parametro);

                parametro = new Parametro(RecursosBDModulo14.ParametroPlanillaID,
                SqlDbType.VarChar, laSolicitud.Planilla.ID.ToString(), false);
                parametros.Add(parametro);

                parametro = new Parametro(RecursosBDModulo14.ParametroPersonaID,
               SqlDbType.VarChar, laSolicitud.ID.ToString(), false);
                parametros.Add(parametro);

                string query = RecursosBDModulo14.ProcedimientoAgregarSolicitudIdP;
                List<Resultado> resultados = laConexion.EjecutarStoredProcedure(query, parametros);

            }
            catch (SqlException ex)
            {
                BDSolicitudException excep = new BDSolicitudException(RecursoGeneralBD.Codigo,
                    RecursoGeneralBD.Mensaje, ex);
                Logger.EscribirError(RecursosBDModulo14.ClaseBDSolicitud, excep);
                throw excep;
            }
            catch (IOException ex)
            {
                BDSolicitudException excep = new BDSolicitudException(RecursosBDModulo14.CodigoIoException,
                    RecursosBDModulo14.MsjExceptionIO, ex);
                Logger.EscribirError(RecursosBDModulo14.ClaseBDSolicitud, excep);
                throw excep;
            }
            catch (NullReferenceException ex)
            {
                BDSolicitudException excep = new BDSolicitudException(RecursosBDModulo14.CodigoNullReferencesExcep,
                    RecursosBDModulo14.MsjNullException, ex);
                Logger.EscribirError(RecursosBDModulo14.ClaseBDSolicitud, excep);
                throw excep;
            }
            catch (ObjectDisposedException ex)
            {
                BDSolicitudException excep = new BDSolicitudException(RecursosBDModulo14.CodigoDisposedObject,
                    RecursosBDModulo14.MensajeDisposedException, ex);
                Logger.EscribirError(RecursosBDModulo14.ClaseBDSolicitud, excep);
                throw excep;
            }
            catch (ExcepcionesSKD.ExceptionSKDConexionBD ex)
            {
                Logger.EscribirError(RecursosBDModulo14.ClaseBDSolicitud, ex);

                throw ex;
            }
            catch (FormatException ex)
            {
                BDSolicitudException excep = new BDSolicitudException(RecursosBDModulo14.CodigoFormatExceptio,
                    RecursosBDModulo14.MsjFormatException, ex);
                Logger.EscribirError(RecursosBDModulo14.ClaseBDSolicitud, excep);
                throw excep;
            }
            catch (Exception ex)
            {
                BDSolicitudException excep = new BDSolicitudException(RecursosBDModulo14.CodigoException,
                    RecursosBDModulo14.MsjException, ex);
                Logger.EscribirError(RecursosBDModulo14.ClaseBDSolicitud, excep);
                throw excep;
            }
            return true;
        }

        /// <summary>
        /// Obtiene los eventos de una inscripcion
        /// </summary>
        /// /// <param name="">id persona</param>
        /// <returns>eventos de una inscripcion</returns>
        public List<SolicitudP> ObtenerEventosSolicitud(int idPersona)
        {
            Logger.EscribirInfo(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name,
                RecursosBDModulo14.MsjDeEntrada, System.Reflection.MethodBase.GetCurrentMethod().Name);
            BDConexion laConexion;
            List<Parametro> parametros;
            Parametro parametro = new Parametro();
            List<SolicitudP> eventos = new List<SolicitudP>();
            try
            {
                laConexion = new BDConexion();
                parametros = new List<Parametro>();

                parametro = new Parametro(RecursosBDModulo14.ParametroPersonaPerId,
                SqlDbType.VarChar, idPersona.ToString(), false);
                parametros.Add(parametro);

                DataTable resultadoConsulta = laConexion.EjecutarStoredProcedureTuplas(RecursosBDModulo14.ProcedureConsultarEventoSolicitud, parametros);

                foreach (DataRow row in resultadoConsulta.Rows)
                {
                    eventos.Add(new SolicitudP(Int32.Parse(row[RecursosBDModulo14.AtributoInscripcionID].ToString()), row[RecursosBDModulo14.AtributoEventoNombre].ToString()));

                }

            }
            catch (SqlException ex)
            {
                BDSolicitudException excep = new BDSolicitudException(RecursoGeneralBD.Codigo,
                    RecursoGeneralBD.Mensaje, ex);
                Logger.EscribirError(RecursosBDModulo14.ClaseBDSolicitud, excep);
                throw excep;
            }
            catch (IOException ex)
            {
                BDSolicitudException excep = new BDSolicitudException(RecursosBDModulo14.CodigoIoException,
                    RecursosBDModulo14.MsjExceptionIO, ex);
                Logger.EscribirError(RecursosBDModulo14.ClaseBDSolicitud, excep);
                throw excep;
            }
            catch (NullReferenceException ex)
            {
                BDSolicitudException excep = new BDSolicitudException(RecursosBDModulo14.CodigoNullReferencesExcep,
                    RecursosBDModulo14.MsjNullException, ex);
                Logger.EscribirError(RecursosBDModulo14.ClaseBDSolicitud, excep);
                throw excep;
            }
            catch (ObjectDisposedException ex)
            {
                BDSolicitudException excep = new BDSolicitudException(RecursosBDModulo14.CodigoDisposedObject,
                    RecursosBDModulo14.MensajeDisposedException, ex);
                Logger.EscribirError(RecursosBDModulo14.ClaseBDSolicitud, excep);
                throw excep;
            }
            catch (ExcepcionesSKD.ExceptionSKDConexionBD ex)
            {
                Logger.EscribirError(RecursosBDModulo14.ClaseBDSolicitud, ex);

                throw ex;
            }
            catch (FormatException ex)
            {
                BDSolicitudException excep = new BDSolicitudException(RecursosBDModulo14.CodigoFormatExceptio,
                    RecursosBDModulo14.MsjFormatException, ex);
                Logger.EscribirError(RecursosBDModulo14.ClaseBDSolicitud, excep);
                throw excep;
            }
            catch (Exception ex)
            {
                BDSolicitudException excep = new BDSolicitudException(RecursosBDModulo14.CodigoException,
                    RecursosBDModulo14.MsjException, ex);
                Logger.EscribirError(RecursosBDModulo14.ClaseBDSolicitud, excep);
                throw excep;
            }

            return eventos;
        }

        /// <summary>
        /// Obtiene los eventos de una inscripcion
        /// </summary>
        /// /// <param name="">id persona</param>
        /// <returns>eventos de una inscripcion</returns>
        public List<SolicitudP> ObtenerCompetenciaSolicitud(int idPersona)
        {
            Logger.EscribirInfo(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name,
                RecursosBDModulo14.MsjDeEntrada, System.Reflection.MethodBase.GetCurrentMethod().Name);
            BDConexion laConexion;
            List<Parametro> parametros;
            Parametro parametro = new Parametro();
            List<SolicitudP> competencias = new List<SolicitudP>();
            try
            {
                laConexion = new BDConexion();
                parametros = new List<Parametro>();

                parametro = new Parametro(RecursosBDModulo14.ParametroPersonaPerId,
                SqlDbType.VarChar, idPersona.ToString(), false);
                parametros.Add(parametro);

                DataTable resultadoConsulta = laConexion.EjecutarStoredProcedureTuplas(RecursosBDModulo14.ProcedimientoConsultarCompeteniaSolicitud, parametros);

                foreach (DataRow row in resultadoConsulta.Rows)
                {
                    competencias.Add(new SolicitudP(Int32.Parse(row[RecursosBDModulo14.AtributoInscripcionID].ToString()), row[RecursosBDModulo14.AtributoCompetenciaNombre].ToString()));

                }

            }
            catch (SqlException ex)
            {
                BDSolicitudException excep = new BDSolicitudException(RecursoGeneralBD.Codigo,
                    RecursoGeneralBD.Mensaje, ex);
                Logger.EscribirError(RecursosBDModulo14.ClaseBDSolicitud, excep);
                throw excep;
            }
            catch (IOException ex)
            {
                BDSolicitudException excep = new BDSolicitudException(RecursosBDModulo14.CodigoIoException,
                    RecursosBDModulo14.MsjExceptionIO, ex);
                Logger.EscribirError(RecursosBDModulo14.ClaseBDSolicitud, excep);
                throw excep;
            }
            catch (NullReferenceException ex)
            {
                BDSolicitudException excep = new BDSolicitudException(RecursosBDModulo14.CodigoNullReferencesExcep,
                    RecursosBDModulo14.MsjNullException, ex);
                Logger.EscribirError(RecursosBDModulo14.ClaseBDSolicitud, excep);
                throw excep;
            }
            catch (ObjectDisposedException ex)
            {
                BDSolicitudException excep = new BDSolicitudException(RecursosBDModulo14.CodigoDisposedObject,
                    RecursosBDModulo14.MensajeDisposedException, ex);
                Logger.EscribirError(RecursosBDModulo14.ClaseBDSolicitud, excep);
                throw excep;
            }
            catch (ExcepcionesSKD.ExceptionSKDConexionBD ex)
            {
                Logger.EscribirError(RecursosBDModulo14.ClaseBDSolicitud, ex);

                throw ex;
            }
            catch (FormatException ex)
            {
                BDSolicitudException excep = new BDSolicitudException(RecursosBDModulo14.CodigoFormatExceptio,
                    RecursosBDModulo14.MsjFormatException, ex);
                Logger.EscribirError(RecursosBDModulo14.ClaseBDSolicitud, excep);
                throw excep;
            }
            catch (Exception ex)
            {
                BDSolicitudException excep = new BDSolicitudException(RecursosBDModulo14.CodigoException,
                    RecursosBDModulo14.MsjException, ex);
                Logger.EscribirError(RecursosBDModulo14.ClaseBDSolicitud, excep);
                throw excep;
            }

            return competencias;
        }

        /// <summary>
        /// Obtiene una solicitud por el ID
        /// </summary>
        /// /// <param name="idSolicitud">id solicitud</param>
        /// <returns>Planilla con nombre, status y tipo de planilla</returns>
        public SolicitudPlanilla ObtenerSolicitudID(int idSolicitud)
        {
            Logger.EscribirInfo(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name,
                RecursosBDModulo14.MsjDeEntrada, System.Reflection.MethodBase.GetCurrentMethod().Name);
            BDConexion laConexion;
            SolicitudPlanilla solicitud = null;
            List<Parametro> parametros;
            Parametro parametro = new Parametro();

            try
            {
                laConexion = new BDConexion();
                Planilla planilla = null;
                parametros = new List<Parametro>();
                parametro = new Parametro(RecursosBDModulo14.ParametroIdSolicitud,
                SqlDbType.VarChar, idSolicitud.ToString(), false);
                parametros.Add(parametro);

                DataTable resultadoConsulta = laConexion.EjecutarStoredProcedureTuplas(RecursosBDModulo14.ProcedureConsultarSolicitudID1, parametros);

                foreach (DataRow row in resultadoConsulta.Rows)
                {
                    DateTime fechaRetiro = Convert.ToDateTime(row[RecursosBDModulo14.AtributoFechaRetiro].ToString());
                    DateTime fechaReincorporacion = Convert.ToDateTime(row[RecursosBDModulo14.AtributoFechaReincorporacion].ToString());
                    String motivo = row[RecursosBDModulo14.AtributoMotivo].ToString();
                    int idPlanilla = Int32.Parse(row[RecursosBDModulo14.AtributoIdPlanillaDatos].ToString());
                    planilla = new Planilla();
                    planilla.ID = idPlanilla;
                    solicitud = new SolicitudPlanilla(fechaRetiro, fechaReincorporacion, motivo, planilla);
                }

            }
            catch (SqlException ex)
            {
                BDSolicitudException excep = new BDSolicitudException(RecursoGeneralBD.Codigo,
                    RecursoGeneralBD.Mensaje, ex);
                Logger.EscribirError(RecursosBDModulo14.ClaseBDSolicitud, excep);
                throw excep;
            }
            catch (IOException ex)
            {
                BDSolicitudException excep = new BDSolicitudException(RecursosBDModulo14.CodigoIoException,
                    RecursosBDModulo14.MsjExceptionIO, ex);
                Logger.EscribirError(RecursosBDModulo14.ClaseBDSolicitud, excep);
                throw excep;
            }
            catch (NullReferenceException ex)
            {
                BDSolicitudException excep = new BDSolicitudException(RecursosBDModulo14.CodigoNullReferencesExcep,
                    RecursosBDModulo14.MsjNullException, ex);
                Logger.EscribirError(RecursosBDModulo14.ClaseBDSolicitud, excep);
                throw excep;
            }
            catch (ObjectDisposedException ex)
            {
                BDSolicitudException excep = new BDSolicitudException(RecursosBDModulo14.CodigoDisposedObject,
                    RecursosBDModulo14.MensajeDisposedException, ex);
                Logger.EscribirError(RecursosBDModulo14.ClaseBDSolicitud, excep);
                throw excep;
            }
            catch (ExcepcionesSKD.ExceptionSKDConexionBD ex)
            {
                Logger.EscribirError(RecursosBDModulo14.ClaseBDSolicitud, ex);

                throw ex;
            }
            catch (FormatException ex)
            {
                BDSolicitudException excep = new BDSolicitudException(RecursosBDModulo14.CodigoFormatExceptio,
                    RecursosBDModulo14.MsjFormatException, ex);
                Logger.EscribirError(RecursosBDModulo14.ClaseBDSolicitud, excep);
                throw excep;
            }
            catch (Exception ex)
            {
                BDSolicitudException excep = new BDSolicitudException(RecursosBDModulo14.CodigoException,
                    RecursosBDModulo14.MsjException, ex);
                Logger.EscribirError(RecursosBDModulo14.ClaseBDSolicitud, excep);
                throw excep;
            }

            return solicitud;
        }


        /// <summary>
        /// Modifica una solicitud en la base de datos
        /// </summary>
        /// <param name="laSolicitud">La solicitud</param>
        /// <returns>returna true en caso de que se completara el registro, y false en caso de que no</returns>
        public Boolean ModificarSolicitudBD(SolicitudP laSolicitud)
        {
            Logger.EscribirInfo(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name,
                RecursosBDModulo14.MsjDeEntrada, System.Reflection.MethodBase.GetCurrentMethod().Name);
            BDConexion laConexion;
            List<Parametro> parametros;
            Parametro parametro = new Parametro();

            try
            {
                laConexion = new BDConexion();
                parametros = new List<Parametro>();
                parametro = new Parametro(RecursosBDModulo14.ParametroIdSolicitud,
                SqlDbType.VarChar, laSolicitud.ID.ToString(), false);
                parametros.Add(parametro);

                parametro = new Parametro(RecursosBDModulo14.ParametroFechaRetiro,
                SqlDbType.VarChar, laSolicitud.FechaRetiro.ToString(), false);
                parametros.Add(parametro);

                parametro = new Parametro(RecursosBDModulo14.ParametroFechaReincorporacion,
                SqlDbType.VarChar, laSolicitud.FechaReincorporacion.ToString(), false);
                parametros.Add(parametro);

                parametro = new Parametro(RecursosBDModulo14.ParametroMotivo,
                SqlDbType.VarChar, laSolicitud.Motivo, false);
                parametros.Add(parametro);

                parametro = new Parametro(RecursosBDModulo14.ParametroPlanillaID,
                SqlDbType.VarChar, laSolicitud.Planilla.ID.ToString(), false);
                parametros.Add(parametro);

                parametro = new Parametro(RecursosBDModulo14.ParametroIdInscripcion,
                SqlDbType.VarChar, laSolicitud.IDInscripcion.ToString(), false);
                parametros.Add(parametro);

                string query = RecursosBDModulo14.ProcedureModificarSolicitud;
                List<Resultado> resultados = laConexion.EjecutarStoredProcedure(query, parametros);

            }
            catch (SqlException ex)
            {
                BDSolicitudException excep = new BDSolicitudException(RecursoGeneralBD.Codigo,
                    RecursoGeneralBD.Mensaje, ex);
                Logger.EscribirError(RecursosBDModulo14.ClaseBDSolicitud, excep);
                throw excep;
            }
            catch (IOException ex)
            {
                BDSolicitudException excep = new BDSolicitudException(RecursosBDModulo14.CodigoIoException,
                    RecursosBDModulo14.MsjExceptionIO, ex);
                Logger.EscribirError(RecursosBDModulo14.ClaseBDSolicitud, excep);
                throw excep;
            }
            catch (NullReferenceException ex)
            {
                BDSolicitudException excep = new BDSolicitudException(RecursosBDModulo14.CodigoNullReferencesExcep,
                    RecursosBDModulo14.MsjNullException, ex);
                Logger.EscribirError(RecursosBDModulo14.ClaseBDSolicitud, excep);
                throw excep;
            }
            catch (ObjectDisposedException ex)
            {
                BDSolicitudException excep = new BDSolicitudException(RecursosBDModulo14.CodigoDisposedObject,
                    RecursosBDModulo14.MensajeDisposedException, ex);
                Logger.EscribirError(RecursosBDModulo14.ClaseBDSolicitud, excep);
                throw excep;
            }
            catch (ExcepcionesSKD.ExceptionSKDConexionBD ex)
            {
                Logger.EscribirError(RecursosBDModulo14.ClaseBDSolicitud, ex);

                throw ex;
            }
            catch (FormatException ex)
            {
                BDSolicitudException excep = new BDSolicitudException(RecursosBDModulo14.CodigoFormatExceptio,
                    RecursosBDModulo14.MsjFormatException, ex);
                Logger.EscribirError(RecursosBDModulo14.ClaseBDSolicitud, excep);
                throw excep;
            }
            catch (Exception ex)
            {
                BDSolicitudException excep = new BDSolicitudException(RecursosBDModulo14.CodigoException,
                    RecursosBDModulo14.MsjException, ex);
                Logger.EscribirError(RecursosBDModulo14.ClaseBDSolicitud, excep);
                throw excep;
            }
            return true;
        }
    }
}
