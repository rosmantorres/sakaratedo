using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DatosSKD.InterfazDAO.Modulo14;
using DominioSKD;
using DominioSKD.Fabrica;
using ExcepcionesSKD;
using ExcepcionesSKD.Modulo14;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Configuration;
using System.Globalization;
using System.IO;

namespace DatosSKD.DAO.Modulo14
{
    public class DaoDatos : DAOGeneral,IDaoDatos
    {

        #region IdaoDatos
        /// <summary>
        /// Método que consulta los datos de una Persona
        /// </summary>
        /// <param name="idPersona">id de la Persona a consultar</param>
        /// <returns>La clase Persona con sus datos</returns>
        public Persona ConsultarPersona(int idPersona)
        {
            Logger.EscribirInfo(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name,
                RecursosDAOModulo14.MsjDeEntrada, System.Reflection.MethodBase.GetCurrentMethod().Name);
            SqlConnection conect = Conectar();
            FabricaEntidades fabricaEntidad = new FabricaEntidades();
            Persona persona = (Persona)fabricaEntidad.ObtenerPersona();
            try
            {

                SqlCommand sqlcom = new SqlCommand(RecursosDAOModulo14.ProcedureConsultarPersonas, conect);

                sqlcom.CommandType = CommandType.StoredProcedure;
                sqlcom.Parameters.Add(new SqlParameter(RecursosDAOModulo14.ParametroPersona, idPersona));

                SqlDataReader leer;
                conect.Open();

                leer = sqlcom.ExecuteReader();
                if (leer != null)
                {
                    while (leer.Read())
                    {
                        DocumentoIdentidad doc = new DocumentoIdentidad();
                        persona.DocumentoID = doc;
                        persona.Nombre = leer[RecursosDAOModulo14.AtributoNombrePersona].ToString();
                        persona.Apellido = leer[RecursosDAOModulo14.AtributoApellidoPersona].ToString();
                        persona.DocumentoID.Numero = Convert.ToInt32(leer[RecursosDAOModulo14.AtributoNumDocPersona]);
                        persona.FechaNacimiento = Convert.ToDateTime(leer[RecursosDAOModulo14.AtributoFechaNacPersona]);
                        persona.Peso = Convert.ToDouble(leer[RecursosDAOModulo14.AtributoPesoPersona]);
                        persona.Estatura = Convert.ToDouble(leer[RecursosDAOModulo14.AtributoEstaturaPersona]);
                        persona.ID = Convert.ToInt32(leer[RecursosDAOModulo14.AtributoDojoPersona]);
                        persona.Direccion = leer[RecursosDAOModulo14.AtributoDireccionPersona].ToString();
                        persona.Nacionalidad = leer[RecursosDAOModulo14.AtributoNacionalidadPersona].ToString();
                        persona.Alergias = leer[RecursosDAOModulo14.AtributoImagenPersona].ToString();
                        return persona;
                    }
                    return null;
                }
                else
                {

                    return null;
                }
            }
            catch (SqlException ex)
            {
                BDDatosException excep = new BDDatosException(RecursoGeneralBD.Codigo,
                    RecursoGeneralBD.Mensaje, ex);
                Logger.EscribirError(RecursosDAOModulo14.ClaseBDDatos, excep);
                throw excep;
            }
            catch (IOException ex)
            {
                BDDatosException excep = new BDDatosException(RecursosDAOModulo14.CodigoIoException,
                    RecursosDAOModulo14.MsjExceptionIO, ex);
                Logger.EscribirError(RecursosDAOModulo14.ClaseBDDatos, excep);
                throw excep;
            }
            catch (NullReferenceException ex)
            {
                BDDatosException excep = new BDDatosException(RecursosDAOModulo14.CodigoNullReferencesExcep,
                    RecursosDAOModulo14.MsjNullException, ex);
                Logger.EscribirError(RecursosDAOModulo14.ClaseBDDatos, excep);
                throw excep;
            }
            catch (ObjectDisposedException ex)
            {
                BDDatosException excep = new BDDatosException(RecursosDAOModulo14.CodigoDisposedObject,
                    RecursosDAOModulo14.MensajeDisposedException, ex);
                Logger.EscribirError(RecursosDAOModulo14.ClaseBDDatos, excep);
                throw excep;
            }
            catch (ExcepcionesSKD.ExceptionSKDConexionBD ex)
            {
                Logger.EscribirError(RecursosDAOModulo14.ClaseBDDatos, ex);

                throw ex;
            }
            catch (FormatException ex)
            {
                BDDatosException excep = new BDDatosException(RecursosDAOModulo14.CodigoFormatExceptio,
                    RecursosDAOModulo14.MsjFormatException, ex);
                Logger.EscribirError(RecursosDAOModulo14.ClaseBDDatos, excep);
                throw excep;
            }
            catch (Exception ex)
            {
                BDDatosException excep = new BDDatosException(RecursosDAOModulo14.CodigoException,
                    RecursosDAOModulo14.MsjException, ex);
                Logger.EscribirError(RecursosDAOModulo14.ClaseBDDatos, excep);
                throw excep;
            }
            finally
            {
               Desconectar(conect);
            }
        }

        /// <summary>
        /// Método que consulta los datos de un dojo
        /// </summary>
        /// <param name="">Id del Dojo a consultar</param>
        /// <returns>La clase Dojo</returns>
        public Dojo ConsultarDojo(int idDojo)
        {
            Logger.EscribirInfo(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name,
                RecursosDAOModulo14.MsjDeEntrada, System.Reflection.MethodBase.GetCurrentMethod().Name);
            SqlConnection conect = Conectar();
            FabricaEntidades fabricaEntidad = new FabricaEntidades();
            Dojo dojo = (Dojo)fabricaEntidad.ObtenerDojo();
            try
            {

                SqlCommand sqlcom = new SqlCommand(RecursosDAOModulo14.ProcedureDojoPersonas, conect);
                sqlcom.CommandType = CommandType.StoredProcedure;
                sqlcom.Parameters.Add(new SqlParameter(RecursosDAOModulo14.ParametroDojoId, idDojo));

                SqlDataReader leer;
                conect.Open();

                leer = sqlcom.ExecuteReader();
                if (leer != null)
                {
                    while (leer.Read())
                    {

                        dojo.Nombre_dojo = leer[RecursosDAOModulo14.AtributoNombreDojo].ToString();
                        dojo.Rif_dojo = leer[RecursosDAOModulo14.AtributoRifDojo].ToString();
                        dojo.Telefono_dojo = Convert.ToInt32(leer[RecursosDAOModulo14.AtributoTelefonoDojo]);
                        dojo.Email_dojo = leer[RecursosDAOModulo14.AtributoEmailDojo].ToString();
                        dojo.Logo_dojo = leer[RecursosDAOModulo14.AtributoLogoDojo].ToString();
                        dojo.Organizacion_dojo = Convert.ToInt32(leer[RecursosDAOModulo14.AtributoOrgDojo]);
                        return dojo;
                    }

                    return null;
                }
                else
                {

                    return null;
                }
            }
            catch (SqlException ex)
            {
                BDDatosException excep = new BDDatosException(RecursoGeneralBD.Codigo,
                    RecursoGeneralBD.Mensaje, ex);
                Logger.EscribirError(RecursosDAOModulo14.ClaseBDDatos, excep);
                throw excep;
            }
            catch (IOException ex)
            {
                BDDatosException excep = new BDDatosException(RecursosDAOModulo14.CodigoIoException,
                    RecursosDAOModulo14.MsjExceptionIO, ex);
                Logger.EscribirError(RecursosDAOModulo14.ClaseBDDatos, excep);
                throw excep;
            }
            catch (NullReferenceException ex)
            {
                BDDatosException excep = new BDDatosException(RecursosDAOModulo14.CodigoNullReferencesExcep,
                    RecursosDAOModulo14.MsjNullException, ex);
                Logger.EscribirError(RecursosDAOModulo14.ClaseBDDatos, excep);
                throw excep;
            }
            catch (ObjectDisposedException ex)
            {
                BDDatosException excep = new BDDatosException(RecursosDAOModulo14.CodigoDisposedObject,
                    RecursosDAOModulo14.MensajeDisposedException, ex);
                Logger.EscribirError(RecursosDAOModulo14.ClaseBDDatos, excep);
                throw excep;
            }
            catch (ExcepcionesSKD.ExceptionSKDConexionBD ex)
            {
                Logger.EscribirError(RecursosDAOModulo14.ClaseBDDatos, ex);

                throw ex;
            }
            catch (FormatException ex)
            {
                BDDatosException excep = new BDDatosException(RecursosDAOModulo14.CodigoFormatExceptio,
                    RecursosDAOModulo14.MsjFormatException, ex);
                Logger.EscribirError(RecursosDAOModulo14.ClaseBDDatos, excep);
                throw excep;
            }
            catch (Exception ex)
            {
                BDDatosException excep = new BDDatosException(RecursosDAOModulo14.CodigoException,
                    RecursosDAOModulo14.MsjException, ex);
                Logger.EscribirError(RecursosDAOModulo14.ClaseBDDatos, excep);
                throw excep;
            }
            finally
            {
               Desconectar(conect);
            }
        }

        /// <summary>
        /// Método que consulta los datos de una matricula,
        /// segun la persona y el dojo en el que se encuentre inscrito
        /// </summary>
        /// <param name="idDojo">Id del dojo relacionado con la
        /// matricula</param>
        /// <param name="idPersona">Id de la Persona relacionada
        /// con la matricula</param>
        /// <returns></returns>
        public List<string> ConsultarMatricula(int idDojo, int idPersona)
        {
            Logger.EscribirInfo(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name,
                RecursosDAOModulo14.MsjDeEntrada, System.Reflection.MethodBase.GetCurrentMethod().Name);
            SqlConnection conect = Conectar();
            List<string> matricula = new List<string>();
            try
            {

                SqlCommand sqlcom = new SqlCommand(RecursosDAOModulo14.ProcedureMatriculaPersona, conect);
                sqlcom.CommandType = CommandType.StoredProcedure;
                sqlcom.Parameters.Add(new SqlParameter(RecursosDAOModulo14.ParametroDojo, idDojo));
                sqlcom.Parameters.Add(new SqlParameter(RecursosDAOModulo14.ParametroPersona, idPersona));

                SqlDataReader leer;
                conect.Open();

                leer = sqlcom.ExecuteReader();
                if (leer != null)
                {
                    while (leer.Read())
                    {
                        matricula.Add(leer[RecursosDAOModulo14.AtributoIdentificadorMatricula].ToString());
                        matricula.Add(leer[RecursosDAOModulo14.AtributoFechaMatricula].ToString());
                        matricula.Add(leer[RecursosDAOModulo14.AtributoPagoMatricula].ToString());
                        matricula.Add(leer[RecursosDAOModulo14.AtributoActivaMatricula].ToString());
                        matricula.Add(leer[RecursosDAOModulo14.AtributoPrecioMatricula].ToString());
                        return matricula;
                    }

                    return null;
                }
                else
                {

                    return null;
                }
            }
            catch (SqlException ex)
            {
                BDDatosException excep = new BDDatosException(RecursoGeneralBD.Codigo,
                    RecursoGeneralBD.Mensaje, ex);
                Logger.EscribirError(RecursosDAOModulo14.ClaseBDDatos, excep);
                throw excep;
            }
            catch (IOException ex)
            {
                BDDatosException excep = new BDDatosException(RecursosDAOModulo14.CodigoIoException,
                    RecursosDAOModulo14.MsjExceptionIO, ex);
                Logger.EscribirError(RecursosDAOModulo14.ClaseBDDatos, excep);
                throw excep;
            }
            catch (NullReferenceException ex)
            {
                BDDatosException excep = new BDDatosException(RecursosDAOModulo14.CodigoNullReferencesExcep,
                    RecursosDAOModulo14.MsjNullException, ex);
                Logger.EscribirError(RecursosDAOModulo14.ClaseBDDatos, excep);
                throw excep;
            }
            catch (ObjectDisposedException ex)
            {
                BDDatosException excep = new BDDatosException(RecursosDAOModulo14.CodigoDisposedObject,
                    RecursosDAOModulo14.MensajeDisposedException, ex);
                Logger.EscribirError(RecursosDAOModulo14.ClaseBDDatos, excep);
                throw excep;
            }
            catch (ExcepcionesSKD.ExceptionSKDConexionBD ex)
            {
                Logger.EscribirError(RecursosDAOModulo14.ClaseBDDatos, ex);

                throw ex;
            }
            catch (FormatException ex)
            {
                BDDatosException excep = new BDDatosException(RecursosDAOModulo14.CodigoFormatExceptio,
                    RecursosDAOModulo14.MsjFormatException, ex);
                Logger.EscribirError(RecursosDAOModulo14.ClaseBDDatos, excep);
                throw excep;
            }
            catch (Exception ex)
            {
                BDDatosException excep = new BDDatosException(RecursosDAOModulo14.CodigoException,
                    RecursosDAOModulo14.MsjException, ex);
                Logger.EscribirError(RecursosDAOModulo14.ClaseBDDatos, excep);
                throw excep;
            }
            finally
            {
               Desconectar(conect);
            }
        }

        /// <summary>
        /// Método que devuelve los datos de una organización
        /// </summary>
        /// <param name="idOrganizacion">id de la organización que se
        /// desea consultar</param>
        /// <returns>La clase Organizacion</returns>
        public Entidad ConsultarOrganizacion(int idOrganizacion)
        {
            Logger.EscribirInfo(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name,
                RecursosDAOModulo14.MsjDeEntrada, System.Reflection.MethodBase.GetCurrentMethod().Name);
            SqlConnection conect = Conectar();
            FabricaEntidades fabricaEntidad = new FabricaEntidades();
            Organizacion organizacion = (Organizacion)fabricaEntidad.ObtenerOrganizacion();
            try
            {

                SqlCommand sqlcom = new SqlCommand(RecursosDAOModulo14.ProcedureConsultarOrganizacion, conect);
                sqlcom.CommandType = CommandType.StoredProcedure;
                sqlcom.Parameters.Add(new SqlParameter(RecursosDAOModulo14.ParametroOrgId, idOrganizacion));

                SqlDataReader leer;
                conect.Open();

                leer = sqlcom.ExecuteReader();
                if (leer != null)
                {
                    while (leer.Read())
                    {
                        organizacion.Nombre = leer[RecursosDAOModulo14.AtributoNombreOrganizacion].ToString();
                        organizacion.Direccion = leer[RecursosDAOModulo14.AtributoDireccionOrganizacion].ToString();
                        organizacion.Telefono = Convert.ToInt32(leer[RecursosDAOModulo14.AtributoTelefonoOrganizacion].ToString());
                        organizacion.Email = leer[RecursosDAOModulo14.AtributoEmailOrganizacion].ToString();
                        return organizacion;
                    }

                    return null;
                }
                else
                {

                    return null;
                }
            }
            catch (SqlException ex)
            {
                BDDatosException excep = new BDDatosException(RecursoGeneralBD.Codigo,
                    RecursoGeneralBD.Mensaje, ex);
                Logger.EscribirError(RecursosDAOModulo14.ClaseBDDatos, excep);
                throw excep;
            }
            catch (IOException ex)
            {
                BDDatosException excep = new BDDatosException(RecursosDAOModulo14.CodigoIoException,
                    RecursosDAOModulo14.MsjExceptionIO, ex);
                Logger.EscribirError(RecursosDAOModulo14.ClaseBDDatos, excep);
                throw excep;
            }
            catch (NullReferenceException ex)
            {
                BDDatosException excep = new BDDatosException(RecursosDAOModulo14.CodigoNullReferencesExcep,
                    RecursosDAOModulo14.MsjNullException, ex);
                Logger.EscribirError(RecursosDAOModulo14.ClaseBDDatos, excep);
                throw excep;
            }
            catch (ObjectDisposedException ex)
            {
                BDDatosException excep = new BDDatosException(RecursosDAOModulo14.CodigoDisposedObject,
                    RecursosDAOModulo14.MensajeDisposedException, ex);
                Logger.EscribirError(RecursosDAOModulo14.ClaseBDDatos, excep);
                throw excep;
            }
            catch (ExcepcionesSKD.ExceptionSKDConexionBD ex)
            {
                Logger.EscribirError(RecursosDAOModulo14.ClaseBDDatos, ex);

                throw ex;
            }
            catch (FormatException ex)
            {
                BDDatosException excep = new BDDatosException(RecursosDAOModulo14.CodigoFormatExceptio,
                    RecursosDAOModulo14.MsjFormatException, ex);
                Logger.EscribirError(RecursosDAOModulo14.ClaseBDDatos, excep);
                throw excep;
            }
            catch (Exception ex)
            {
                BDDatosException excep = new BDDatosException(RecursosDAOModulo14.CodigoException,
                    RecursosDAOModulo14.MsjException, ex);
                Logger.EscribirError(RecursosDAOModulo14.ClaseBDDatos, excep);
                throw excep;
            }
            finally
            {
              Desconectar(conect);
            }
        }

        /// <summary>
        /// Método que consulta los datos del eventos segun, el id de inscripcion
        /// </summary>
        /// <param name="idIns">Id de inscripcion relacionado con el evento</param>
        /// <returns>La clase evento</returns>
        public Evento ConsultarEvento(int idIns)
        {
            Logger.EscribirInfo(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name,
                RecursosDAOModulo14.MsjDeEntrada, System.Reflection.MethodBase.GetCurrentMethod().Name);
            SqlConnection conect = Conectar();
            FabricaEntidades fabricaEntidad = new FabricaEntidades();
            //Evento evento = (DominioSKD.Evento)fabricaEntidad.ObtenerEvento();
            Evento evento =  new Evento();
            try
            {

                SqlCommand sqlcom = new SqlCommand(RecursosDAOModulo14.ProcedureConsultarPersonaEvento, conect);
                sqlcom.CommandType = CommandType.StoredProcedure;
                sqlcom.Parameters.Add(new SqlParameter(RecursosDAOModulo14.ParametroInsId, idIns));

                SqlDataReader leer;
                conect.Open();

                leer = sqlcom.ExecuteReader();
                if (leer != null)
                {
                    while (leer.Read())
                    {
                        Categoria cat = new Categoria();
                        Horario hor = new Horario();
                        TipoEvento tip = new TipoEvento();
                        evento.Categoria = cat;
                        evento.Horario = hor;
                        evento.TipoEvento = tip;
                        evento.Nombre = leer[RecursosDAOModulo14.AtributoEventoNombre].ToString();
                        evento.Descripcion = leer[RecursosDAOModulo14.AtributoDescripcionEvento].ToString();
                        evento.Categoria.Sexo = leer[RecursosDAOModulo14.AtributoSexoCategoria].ToString();
                        evento.Categoria.Cinta_final = leer[RecursosDAOModulo14.AtributoCintaFinCategoria].ToString();
                        evento.Categoria.Cinta_inicial = leer[RecursosDAOModulo14.AtributoCintaIniCategoria].ToString();
                        evento.Categoria.Edad_final = Convert.ToInt32(leer[RecursosDAOModulo14.AtributoEdadFinCategoria]);
                        evento.Categoria.Edad_inicial = Convert.ToInt32(leer[RecursosDAOModulo14.AtributoEdadIniCategoria]);
                        evento.TipoEvento.Nombre = leer[RecursosDAOModulo14.AtributoTipo].ToString();
                        evento.Horario.FechaFin = Convert.ToDateTime(leer[RecursosDAOModulo14.AtributoFechaFinHora]);
                        evento.Horario.FechaInicio = Convert.ToDateTime(leer[RecursosDAOModulo14.AtributoFechaIniHora]);
                        evento.Horario.HoraFin = Convert.ToInt32(leer[RecursosDAOModulo14.AtributoHoraFinHora]);
                        evento.Horario.HoraInicio = Convert.ToInt32(leer[RecursosDAOModulo14.AtributoHoraIniHora]);
                        return evento;
                    }

                    return null;
                }
                else
                {

                    return null;
                }
            }
            catch (SqlException ex)
            {
                BDDatosException excep = new BDDatosException(RecursoGeneralBD.Codigo,
                    RecursoGeneralBD.Mensaje, ex);
                Logger.EscribirError(RecursosDAOModulo14.ClaseBDDatos, excep);
                throw excep;
            }
            catch (IOException ex)
            {
                BDDatosException excep = new BDDatosException(RecursosDAOModulo14.CodigoIoException,
                    RecursosDAOModulo14.MsjExceptionIO, ex);
                Logger.EscribirError(RecursosDAOModulo14.ClaseBDDatos, excep);
                throw excep;
            }
            catch (NullReferenceException ex)
            {
                BDDatosException excep = new BDDatosException(RecursosDAOModulo14.CodigoNullReferencesExcep,
                    RecursosDAOModulo14.MsjNullException, ex);
                Logger.EscribirError(RecursosDAOModulo14.ClaseBDDatos, excep);
                throw excep;
            }
            catch (ObjectDisposedException ex)
            {
                BDDatosException excep = new BDDatosException(RecursosDAOModulo14.CodigoDisposedObject,
                    RecursosDAOModulo14.MensajeDisposedException, ex);
                Logger.EscribirError(RecursosDAOModulo14.ClaseBDDatos, excep);
                throw excep;
            }
            catch (ExcepcionesSKD.ExceptionSKDConexionBD ex)
            {
                Logger.EscribirError(RecursosDAOModulo14.ClaseBDDatos, ex);

                throw ex;
            }
            catch (FormatException ex)
            {
                BDDatosException excep = new BDDatosException(RecursosDAOModulo14.CodigoFormatExceptio,
                    RecursosDAOModulo14.MsjFormatException, ex);
                Logger.EscribirError(RecursosDAOModulo14.ClaseBDDatos, excep);
                throw excep;
            }
            catch (Exception ex)
            {
                BDDatosException excep = new BDDatosException(RecursosDAOModulo14.CodigoException,
                    RecursosDAOModulo14.MsjException, ex);
                Logger.EscribirError(RecursosDAOModulo14.ClaseBDDatos, excep);
                throw excep;
            }
            finally
            {
               Desconectar(conect);
            }
        }

        /// <summary>
        /// Método que consulta los datos de una competencia, segun el id
        /// de inscripcion
        /// </summary>
        /// <param name="idIns">Id de la inscripcion relacionada con la
        /// competencia</param>
        /// <returns></returns>
        public Entidad ConsultarCompetencia(int idIns)
        {
            Logger.EscribirInfo(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name,
                RecursosDAOModulo14.MsjDeEntrada, System.Reflection.MethodBase.GetCurrentMethod().Name);
            SqlConnection conect = Conectar();
            FabricaEntidades fabricaEntidad = new FabricaEntidades();
            Competencia competencia = (Competencia)fabricaEntidad.ObtenerCompetencia();
            try
            {

                SqlCommand sqlcom = new SqlCommand(RecursosDAOModulo14.ProcedurePersonaCompetencia, conect);
                sqlcom.CommandType = CommandType.StoredProcedure;
                sqlcom.Parameters.Add(new SqlParameter(RecursosDAOModulo14.ParametroInsId, idIns));

                SqlDataReader leer;
                conect.Open();

                leer = sqlcom.ExecuteReader();
                if (leer != null)
                {
                    while (leer.Read())
                    {
                        FabricaEntidades fabricaEntidad1 = new FabricaEntidades();
                        Categoria cat = (Categoria)fabricaEntidad1.ObtenerCategoria();
                        competencia.Categoria = cat;
                        competencia.Nombre = leer[RecursosDAOModulo14.AtributoCompetenciaNombre].ToString();
                        competencia.FechaFin = Convert.ToDateTime(leer[RecursosDAOModulo14.AtributoFechaFinCompetencia]);
                        competencia.FechaInicio = Convert.ToDateTime(leer[RecursosDAOModulo14.AtributoFechaIniCompetencia]);
                        competencia.TipoCompetencia = leer[RecursosDAOModulo14.AtributoTipoCompetencia].ToString();
                        competencia.Categoria.Sexo = leer[RecursosDAOModulo14.AtributoSexoCategoria].ToString();
                        competencia.Categoria.Cinta_final = leer[RecursosDAOModulo14.AtributoCintaFinCategoria].ToString();
                        competencia.Categoria.Cinta_inicial = leer[RecursosDAOModulo14.AtributoCintaIniCategoria].ToString();
                        competencia.Categoria.Edad_final = Convert.ToInt32(leer[RecursosDAOModulo14.AtributoEdadFinCategoria]);
                        competencia.Categoria.Edad_inicial = Convert.ToInt32(leer[RecursosDAOModulo14.AtributoEdadIniCategoria]);
                        competencia.Costo = Convert.ToInt32(leer[RecursosDAOModulo14.AtributoCostoCompetencia]);


                        return competencia;
                    }

                    return null;
                }
                else
                {

                    return null;
                }
            }
            catch (SqlException ex)
            {
                BDDatosException excep = new BDDatosException(RecursoGeneralBD.Codigo,
                    RecursoGeneralBD.Mensaje, ex);
                Logger.EscribirError(RecursosDAOModulo14.ClaseBDDatos, excep);
                throw excep;
            }
            catch (IOException ex)
            {
                BDDatosException excep = new BDDatosException(RecursosDAOModulo14.CodigoIoException,
                    RecursosDAOModulo14.MsjExceptionIO, ex);
                Logger.EscribirError(RecursosDAOModulo14.ClaseBDDatos, excep);
                throw excep;
            }
            catch (NullReferenceException ex)
            {
                BDDatosException excep = new BDDatosException(RecursosDAOModulo14.CodigoNullReferencesExcep,
                    RecursosDAOModulo14.MsjNullException, ex);
                Logger.EscribirError(RecursosDAOModulo14.ClaseBDDatos, excep);
                throw excep;
            }
            catch (ObjectDisposedException ex)
            {
                BDDatosException excep = new BDDatosException(RecursosDAOModulo14.CodigoDisposedObject,
                    RecursosDAOModulo14.MensajeDisposedException, ex);
                Logger.EscribirError(RecursosDAOModulo14.ClaseBDDatos, excep);
                throw excep;
            }
            catch (ExcepcionesSKD.ExceptionSKDConexionBD ex)
            {
                Logger.EscribirError(RecursosDAOModulo14.ClaseBDDatos, ex);

                throw ex;
            }
            catch (FormatException ex)
            {
                BDDatosException excep = new BDDatosException(RecursosDAOModulo14.CodigoFormatExceptio,
                    RecursosDAOModulo14.MsjFormatException, ex);
                Logger.EscribirError(RecursosDAOModulo14.ClaseBDDatos, excep);
                throw excep;
            }
            catch (Exception ex)
            {
                BDDatosException excep = new BDDatosException(RecursosDAOModulo14.CodigoException,
                    RecursosDAOModulo14.MsjException, ex);
                Logger.EscribirError(RecursosDAOModulo14.ClaseBDDatos, excep);
                throw excep;
            }
            finally
            {
               Desconectar(conect);
            }
        }

        /// <summary>
        /// Método que consulta los datos de una solicitud
        /// </summary>
        /// <param name="idSolicitud">Id de la solicitud a consultar</param>
        /// <returns>La clase solicitud</returns>
        public Entidad ConsultarSolicitud(int idSolicitud)
        {
            Logger.EscribirInfo(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name,
                RecursosDAOModulo14.MsjDeEntrada, System.Reflection.MethodBase.GetCurrentMethod().Name);
            SqlConnection conect = Conectar();
            FabricaEntidades fabricaEntidad = new FabricaEntidades();
            SolicitudPlanilla solicitud = (SolicitudPlanilla)fabricaEntidad.ObtenerSolicitudPlanilla();
            try
            {

                SqlCommand sqlcom = new SqlCommand(RecursosDAOModulo14.ProcedureConsultarSolicitudId, conect);
                sqlcom.CommandType = CommandType.StoredProcedure;
                sqlcom.Parameters.Add(new SqlParameter(RecursosDAOModulo14.ParametroIDSolici, idSolicitud));

                SqlDataReader leer;
                conect.Open();

                leer = sqlcom.ExecuteReader();
                if (leer != null)
                {
                    while (leer.Read())
                    {
                        solicitud.FechaCreacion = Convert.ToDateTime(leer[RecursosDAOModulo14.AtributoFechaCreacion]);
                        solicitud.FechaReincorporacion = Convert.ToDateTime(leer[RecursosDAOModulo14.AtributoFechaReincorporacion]);
                        solicitud.FechaRetiro = Convert.ToDateTime(leer[RecursosDAOModulo14.AtributoFechaRetiro]);
                        solicitud.Motivo = leer[RecursosDAOModulo14.AtributoMotivo].ToString();
                        return solicitud;
                    }

                    return null;
                }
                else
                {

                    return null;
                }
            }
            catch (SqlException ex)
            {
                BDDatosException excep = new BDDatosException(RecursoGeneralBD.Codigo,
                    RecursoGeneralBD.Mensaje, ex);
                Logger.EscribirError(RecursosDAOModulo14.ClaseBDDatos, excep);
                throw excep;
            }
            catch (IOException ex)
            {
                BDDatosException excep = new BDDatosException(RecursosDAOModulo14.CodigoIoException,
                    RecursosDAOModulo14.MsjExceptionIO, ex);
                Logger.EscribirError(RecursosDAOModulo14.ClaseBDDatos, excep);
                throw excep;
            }
            catch (NullReferenceException ex)
            {
                BDDatosException excep = new BDDatosException(RecursosDAOModulo14.CodigoNullReferencesExcep,
                    RecursosDAOModulo14.MsjNullException, ex);
                Logger.EscribirError(RecursosDAOModulo14.ClaseBDDatos, excep);
                throw excep;
            }
            catch (ObjectDisposedException ex)
            {
                BDDatosException excep = new BDDatosException(RecursosDAOModulo14.CodigoDisposedObject,
                    RecursosDAOModulo14.MensajeDisposedException, ex);
                Logger.EscribirError(RecursosDAOModulo14.ClaseBDDatos, excep);
                throw excep;
            }
            catch (ExcepcionesSKD.ExceptionSKDConexionBD ex)
            {
                Logger.EscribirError(RecursosDAOModulo14.ClaseBDDatos, ex);

                throw ex;
            }
            catch (FormatException ex)
            {
                BDDatosException excep = new BDDatosException(RecursosDAOModulo14.CodigoFormatExceptio,
                    RecursosDAOModulo14.MsjFormatException, ex);
                Logger.EscribirError(RecursosDAOModulo14.ClaseBDDatos, excep);
                throw excep;
            }
            catch (Exception ex)
            {
                BDDatosException excep = new BDDatosException(RecursosDAOModulo14.CodigoException,
                    RecursosDAOModulo14.MsjException, ex);
                Logger.EscribirError(RecursosDAOModulo14.ClaseBDDatos, excep);
                throw excep;
            }
            finally
            {
                Desconectar(conect);
            }
        }
        #endregion

        #region IDAO
        public Boolean Agregar(Entidad parametro)
        {
            return false;
        }

        public Boolean Modificar(Entidad parametro)
        {
            return false;
        }

        public Entidad ConsultarXId(Entidad parametro)
        {
            return null;
        }

        public List<Entidad> ConsultarTodos()
        {
            return null;
        }
        #endregion
    }
}
