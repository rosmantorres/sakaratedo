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
    public class BDDatos
    {
        #region atributos

        private BDConexion con = new BDConexion();

        #endregion

        /// <summary>
        /// Método que consulta los datos de una Persona
        /// </summary>
        /// <param name="idPersona">id de la Persona a consultar</param>
        /// <returns>La clase Persona con sus datos</returns>
        public DominioSKD.Persona ConsultarPersona(int idPersona)
        {
            Logger.EscribirInfo(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name,
                RecursosBDModulo14.MsjDeEntrada, System.Reflection.MethodBase.GetCurrentMethod().Name);
            SqlConnection conect = con.Conectar();
            DominioSKD.Persona persona = new DominioSKD.Persona();
            try
            {

                SqlCommand sqlcom = new SqlCommand(RecursosBDModulo14.ProcedureConsultarPersonas, conect);

                sqlcom.CommandType = CommandType.StoredProcedure;
                sqlcom.Parameters.Add(new SqlParameter(RecursosBDModulo14.ParametroPersona, idPersona));

                SqlDataReader leer;
                conect.Open();

                leer = sqlcom.ExecuteReader();
                if (leer != null)
                {
                    while (leer.Read())
                    {
                        DominioSKD.DocumentoIdentidad doc = new DominioSKD.DocumentoIdentidad();
                        persona.DocumentoID = doc;
                        persona.Nombre = leer[RecursosBDModulo14.AtributoNombrePersona].ToString();
                        persona.Apellido = leer[RecursosBDModulo14.AtributoApellidoPersona].ToString();
                        persona.DocumentoID.Numero = Convert.ToInt32(leer[RecursosBDModulo14.AtributoNumDocPersona]);
                        persona.FechaNacimiento = Convert.ToDateTime(leer[RecursosBDModulo14.AtributoFechaNacPersona]);
                        persona.Peso = Convert.ToDouble(leer[RecursosBDModulo14.AtributoPesoPersona]);
                        persona.Estatura = Convert.ToDouble(leer[RecursosBDModulo14.AtributoEstaturaPersona]);
                        persona.ID = Convert.ToInt32(leer[RecursosBDModulo14.AtributoDojoPersona]);
                        persona.Direccion = leer[RecursosBDModulo14.AtributoDireccionPersona].ToString();
                        persona.Nacionalidad = leer[RecursosBDModulo14.AtributoNacionalidadPersona].ToString();
                        persona.Alergias = leer[RecursosBDModulo14.AtributoImagenPersona].ToString();
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
                Logger.EscribirError(RecursosBDModulo14.ClaseBDDatos, excep);
                throw excep;
            }
            catch (IOException ex)
            {
                BDDatosException excep = new BDDatosException(RecursosBDModulo14.CodigoIoException,
                    RecursosBDModulo14.MsjExceptionIO, ex);
                Logger.EscribirError(RecursosBDModulo14.ClaseBDDatos, excep);
                throw excep;
            }
            catch (NullReferenceException ex)
            {
                BDDatosException excep = new BDDatosException(RecursosBDModulo14.CodigoNullReferencesExcep,
                    RecursosBDModulo14.MsjNullException, ex);
                Logger.EscribirError(RecursosBDModulo14.ClaseBDDatos, excep);
                throw excep;
            }
            catch (ObjectDisposedException ex)
            {
                BDDatosException excep = new BDDatosException(RecursosBDModulo14.CodigoDisposedObject,
                    RecursosBDModulo14.MensajeDisposedException, ex);
                Logger.EscribirError(RecursosBDModulo14.ClaseBDDatos, excep);
                throw excep;
            }
            catch (ExcepcionesSKD.ExceptionSKDConexionBD ex)
            {
                Logger.EscribirError(RecursosBDModulo14.ClaseBDDatos, ex);

                throw ex;
            }
            catch (FormatException ex)
            {
                BDDatosException excep = new BDDatosException(RecursosBDModulo14.CodigoFormatExceptio,
                    RecursosBDModulo14.MsjFormatException, ex);
                Logger.EscribirError(RecursosBDModulo14.ClaseBDDatos, excep);
                throw excep;
            }
            catch (Exception ex)
            {
                BDDatosException excep = new BDDatosException(RecursosBDModulo14.CodigoException,
                    RecursosBDModulo14.MsjException, ex);
                Logger.EscribirError(RecursosBDModulo14.ClaseBDDatos, excep);
                throw excep;
            }
                finally
                {
                    con.Desconectar(conect);
                }
            }

        /// <summary>
        /// Método que consulta los datos de un dojo
        /// </summary>
        /// <param name="">Id del Dojo a consultar</param>
        /// <returns>La clase Dojo</returns>
        public DominioSKD.Dojo ConsultarDojo(int idDojo)
        {
            Logger.EscribirInfo(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name,
                RecursosBDModulo14.MsjDeEntrada, System.Reflection.MethodBase.GetCurrentMethod().Name);
            SqlConnection conect = con.Conectar();
            DominioSKD.Dojo dojo = new DominioSKD.Dojo();
            try
            {

                SqlCommand sqlcom = new SqlCommand(RecursosBDModulo14.ProcedureDojoPersonas, conect);
                sqlcom.CommandType = CommandType.StoredProcedure;
                sqlcom.Parameters.Add(new SqlParameter(RecursosBDModulo14.ParametroDojoId, idDojo));

                SqlDataReader leer;
                conect.Open();

                leer = sqlcom.ExecuteReader();
                if (leer != null)
                {
                    while (leer.Read())
                    {

                        dojo.Nombre_dojo = leer[RecursosBDModulo14.AtributoNombreDojo].ToString();
                        dojo.Rif_dojo = leer[RecursosBDModulo14.AtributoRifDojo].ToString();
                        dojo.Telefono_dojo = Convert.ToInt32(leer[RecursosBDModulo14.AtributoTelefonoDojo]);
                        dojo.Email_dojo = leer[RecursosBDModulo14.AtributoEmailDojo].ToString();
                        dojo.Logo_dojo = leer[RecursosBDModulo14.AtributoLogoDojo].ToString();
                        dojo.Organizacion_dojo = Convert.ToInt32(leer[RecursosBDModulo14.AtributoOrgDojo]);
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
                Logger.EscribirError(RecursosBDModulo14.ClaseBDDatos, excep);
                throw excep;
            }
            catch (IOException ex)
            {
                BDDatosException excep = new BDDatosException(RecursosBDModulo14.CodigoIoException,
                    RecursosBDModulo14.MsjExceptionIO, ex);
                Logger.EscribirError(RecursosBDModulo14.ClaseBDDatos, excep);
                throw excep;
            }
            catch (NullReferenceException ex)
            {
                BDDatosException excep = new BDDatosException(RecursosBDModulo14.CodigoNullReferencesExcep,
                    RecursosBDModulo14.MsjNullException, ex);
                Logger.EscribirError(RecursosBDModulo14.ClaseBDDatos, excep);
                throw excep;
            }
            catch (ObjectDisposedException ex)
            {
                BDDatosException excep = new BDDatosException(RecursosBDModulo14.CodigoDisposedObject,
                    RecursosBDModulo14.MensajeDisposedException, ex);
                Logger.EscribirError(RecursosBDModulo14.ClaseBDDatos, excep);
                throw excep;
            }
            catch (ExcepcionesSKD.ExceptionSKDConexionBD ex)
            {
                Logger.EscribirError(RecursosBDModulo14.ClaseBDDatos, ex);

                throw ex;
            }
            catch (FormatException ex)
            {
                BDDatosException excep = new BDDatosException(RecursosBDModulo14.CodigoFormatExceptio,
                    RecursosBDModulo14.MsjFormatException, ex);
                Logger.EscribirError(RecursosBDModulo14.ClaseBDDatos, excep);
                throw excep;
            }
            catch (Exception ex)
            {
                BDDatosException excep = new BDDatosException(RecursosBDModulo14.CodigoException,
                    RecursosBDModulo14.MsjException, ex);
                Logger.EscribirError(RecursosBDModulo14.ClaseBDDatos, excep);
                throw excep;
            }
            finally
            {
                con.Desconectar(conect);
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
                RecursosBDModulo14.MsjDeEntrada, System.Reflection.MethodBase.GetCurrentMethod().Name);
            SqlConnection conect = con.Conectar();
            List<string> matricula = new List<string>();
            try
            {

                SqlCommand sqlcom = new SqlCommand(RecursosBDModulo14.ProcedureMatriculaPersona, conect);
                sqlcom.CommandType = CommandType.StoredProcedure;
                sqlcom.Parameters.Add(new SqlParameter(RecursosBDModulo14.ParametroDojo, idDojo));
                sqlcom.Parameters.Add(new SqlParameter(RecursosBDModulo14.ParametroPersona, idPersona));

                SqlDataReader leer;
                conect.Open();

                leer = sqlcom.ExecuteReader();
                if (leer != null)
                {
                    while (leer.Read())
                    {
                        matricula.Add(leer[RecursosBDModulo14.AtributoIdentificadorMatricula].ToString());
                        matricula.Add(leer[RecursosBDModulo14.AtributoFechaMatricula].ToString());
                        matricula.Add(leer[RecursosBDModulo14.AtributoPagoMatricula].ToString());
                        matricula.Add(leer[RecursosBDModulo14.AtributoActivaMatricula].ToString());
                        matricula.Add(leer[RecursosBDModulo14.AtributoPrecioMatricula].ToString());
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
                Logger.EscribirError(RecursosBDModulo14.ClaseBDDatos, excep);
                throw excep;
            }
            catch (IOException ex)
            {
                BDDatosException excep = new BDDatosException(RecursosBDModulo14.CodigoIoException,
                    RecursosBDModulo14.MsjExceptionIO, ex);
                Logger.EscribirError(RecursosBDModulo14.ClaseBDDatos, excep);
                throw excep;
            }
            catch (NullReferenceException ex)
            {
                BDDatosException excep = new BDDatosException(RecursosBDModulo14.CodigoNullReferencesExcep,
                    RecursosBDModulo14.MsjNullException, ex);
                Logger.EscribirError(RecursosBDModulo14.ClaseBDDatos, excep);
                throw excep;
            }
            catch (ObjectDisposedException ex)
            {
                BDDatosException excep = new BDDatosException(RecursosBDModulo14.CodigoDisposedObject,
                    RecursosBDModulo14.MensajeDisposedException, ex);
                Logger.EscribirError(RecursosBDModulo14.ClaseBDDatos, excep);
                throw excep;
            }
            catch (ExcepcionesSKD.ExceptionSKDConexionBD ex)
            {
                Logger.EscribirError(RecursosBDModulo14.ClaseBDDatos, ex);

                throw ex;
            }
            catch (FormatException ex)
            {
                BDDatosException excep = new BDDatosException(RecursosBDModulo14.CodigoFormatExceptio,
                    RecursosBDModulo14.MsjFormatException, ex);
                Logger.EscribirError(RecursosBDModulo14.ClaseBDDatos, excep);
                throw excep;
            }
            catch (Exception ex)
            {
                BDDatosException excep = new BDDatosException(RecursosBDModulo14.CodigoException,
                    RecursosBDModulo14.MsjException, ex);
                Logger.EscribirError(RecursosBDModulo14.ClaseBDDatos, excep);
                throw excep;
            }
            finally
            {
                con.Desconectar(conect);
            }
        }

        /// <summary>
        /// Método que devuelve los datos de una organización
        /// </summary>
        /// <param name="idOrganizacion">id de la organización que se
        /// desea consultar</param>
        /// <returns>La clase Organizacion</returns>
        public DominioSKD.Organizacion ConsultarOrganizacion(int idOrganizacion)
        {
            Logger.EscribirInfo(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name,
                RecursosBDModulo14.MsjDeEntrada, System.Reflection.MethodBase.GetCurrentMethod().Name);
            SqlConnection conect = con.Conectar();
            DominioSKD.Organizacion organizacion = new DominioSKD.Organizacion();
            try
            {

                SqlCommand sqlcom = new SqlCommand(RecursosBDModulo14.ProcedureConsultarOrganizacion, conect);
                sqlcom.CommandType = CommandType.StoredProcedure;
                sqlcom.Parameters.Add(new SqlParameter(RecursosBDModulo14.ParametroOrgId, idOrganizacion));

                SqlDataReader leer;
                conect.Open();

                leer = sqlcom.ExecuteReader();
                if (leer != null)
                {
                    while (leer.Read())
                    {
                        organizacion.Nombre = leer[RecursosBDModulo14.AtributoNombreOrganizacion].ToString();
                        organizacion.Direccion = leer[RecursosBDModulo14.AtributoDireccionOrganizacion].ToString();
                        organizacion.Telefono = Convert.ToInt32(leer[RecursosBDModulo14.AtributoTelefonoOrganizacion].ToString());
                        organizacion.Email = leer[RecursosBDModulo14.AtributoEmailOrganizacion].ToString();
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
                Logger.EscribirError(RecursosBDModulo14.ClaseBDDatos, excep);
                throw excep;
            }
            catch (IOException ex)
            {
                BDDatosException excep = new BDDatosException(RecursosBDModulo14.CodigoIoException,
                    RecursosBDModulo14.MsjExceptionIO, ex);
                Logger.EscribirError(RecursosBDModulo14.ClaseBDDatos, excep);
                throw excep;
            }
            catch (NullReferenceException ex)
            {
                BDDatosException excep = new BDDatosException(RecursosBDModulo14.CodigoNullReferencesExcep,
                    RecursosBDModulo14.MsjNullException, ex);
                Logger.EscribirError(RecursosBDModulo14.ClaseBDDatos, excep);
                throw excep;
            }
            catch (ObjectDisposedException ex)
            {
                BDDatosException excep = new BDDatosException(RecursosBDModulo14.CodigoDisposedObject,
                    RecursosBDModulo14.MensajeDisposedException, ex);
                Logger.EscribirError(RecursosBDModulo14.ClaseBDDatos, excep);
                throw excep;
            }
            catch (ExcepcionesSKD.ExceptionSKDConexionBD ex)
            {
                Logger.EscribirError(RecursosBDModulo14.ClaseBDDatos, ex);

                throw ex;
            }
            catch (FormatException ex)
            {
                BDDatosException excep = new BDDatosException(RecursosBDModulo14.CodigoFormatExceptio,
                    RecursosBDModulo14.MsjFormatException, ex);
                Logger.EscribirError(RecursosBDModulo14.ClaseBDDatos, excep);
                throw excep;
            }
            catch (Exception ex)
            {
                BDDatosException excep = new BDDatosException(RecursosBDModulo14.CodigoException,
                    RecursosBDModulo14.MsjException, ex);
                Logger.EscribirError(RecursosBDModulo14.ClaseBDDatos, excep);
                throw excep;
            }
            finally
            {
                con.Desconectar(conect);
            }
        }

        /// <summary>
        /// Método que consulta los datos del eventos segun, el id de inscripcion
        /// </summary>
        /// <param name="idIns">Id de inscripcion relacionado con el evento</param>
        /// <returns>La clase evento</returns>
        public DominioSKD.Evento ConsultarEvento(int idIns)
        {
            Logger.EscribirInfo(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name,
                RecursosBDModulo14.MsjDeEntrada, System.Reflection.MethodBase.GetCurrentMethod().Name);
            SqlConnection conect = con.Conectar();
            DominioSKD.Evento evento = new DominioSKD.Evento();
            try
            {

                SqlCommand sqlcom = new SqlCommand(RecursosBDModulo14.ProcedureConsultarPersonaEvento, conect);
                sqlcom.CommandType = CommandType.StoredProcedure;
                sqlcom.Parameters.Add(new SqlParameter(RecursosBDModulo14.ParametroInsId, idIns));

                SqlDataReader leer;
                conect.Open();

                leer = sqlcom.ExecuteReader();
                if (leer != null)
                {
                    while (leer.Read())
                    {
                        DominioSKD.Categoria cat = new DominioSKD.Categoria();
                        DominioSKD.Horario hor = new DominioSKD.Horario();
                        DominioSKD.TipoEvento tip = new DominioSKD.TipoEvento();
                        evento.Categoria = cat;
                        evento.Horario = hor;
                        evento.TipoEvento = tip;
                        evento.Nombre = leer[RecursosBDModulo14.AtributoEventoNombre].ToString();
                        evento.Descripcion= leer[RecursosBDModulo14.AtributoDescripcionEvento].ToString();
                        evento.Categoria.Sexo = leer[RecursosBDModulo14.AtributoSexoCategoria].ToString();
                        evento.Categoria.Cinta_final = leer[RecursosBDModulo14.AtributoCintaFinCategoria].ToString();
                        evento.Categoria.Cinta_inicial = leer[RecursosBDModulo14.AtributoCintaIniCategoria].ToString();
                        evento.Categoria.Edad_final =Convert.ToInt32(leer[RecursosBDModulo14.AtributoEdadFinCategoria]);
                        evento.Categoria.Edad_inicial = Convert.ToInt32(leer[RecursosBDModulo14.AtributoEdadIniCategoria]);
                        evento.TipoEvento.Nombre = leer[RecursosBDModulo14.AtributoTipo].ToString();
                        evento.Horario.FechaFin = Convert.ToDateTime(leer[RecursosBDModulo14.AtributoFechaFinHora]);
                        evento.Horario.FechaInicio = Convert.ToDateTime(leer[RecursosBDModulo14.AtributoFechaIniHora]);
                        evento.Horario.HoraFin = Convert.ToInt32(leer[RecursosBDModulo14.AtributoHoraFinHora]);
                        evento.Horario.HoraInicio = Convert.ToInt32(leer[RecursosBDModulo14.AtributoHoraIniHora]);
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
                Logger.EscribirError(RecursosBDModulo14.ClaseBDDatos, excep);
                throw excep;
            }
            catch (IOException ex)
            {
                BDDatosException excep = new BDDatosException(RecursosBDModulo14.CodigoIoException,
                    RecursosBDModulo14.MsjExceptionIO, ex);
                Logger.EscribirError(RecursosBDModulo14.ClaseBDDatos, excep);
                throw excep;
            }
            catch (NullReferenceException ex)
            {
                BDDatosException excep = new BDDatosException(RecursosBDModulo14.CodigoNullReferencesExcep,
                    RecursosBDModulo14.MsjNullException, ex);
                Logger.EscribirError(RecursosBDModulo14.ClaseBDDatos, excep);
                throw excep;
            }
            catch (ObjectDisposedException ex)
            {
                BDDatosException excep = new BDDatosException(RecursosBDModulo14.CodigoDisposedObject,
                    RecursosBDModulo14.MensajeDisposedException, ex);
                Logger.EscribirError(RecursosBDModulo14.ClaseBDDatos, excep);
                throw excep;
            }
            catch (ExcepcionesSKD.ExceptionSKDConexionBD ex)
            {
                Logger.EscribirError(RecursosBDModulo14.ClaseBDDatos, ex);

                throw ex;
            }
            catch (FormatException ex)
            {
                BDDatosException excep = new BDDatosException(RecursosBDModulo14.CodigoFormatExceptio,
                    RecursosBDModulo14.MsjFormatException, ex);
                Logger.EscribirError(RecursosBDModulo14.ClaseBDDatos, excep);
                throw excep;
            }
            catch (Exception ex)
            {
                BDDatosException excep = new BDDatosException(RecursosBDModulo14.CodigoException,
                    RecursosBDModulo14.MsjException, ex);
                Logger.EscribirError(RecursosBDModulo14.ClaseBDDatos, excep);
                throw excep;
            }
            finally
            {
                con.Desconectar(conect);
            }
        }

        /// <summary>
        /// Método que consulta los datos de una competencia, segun el id
        /// de inscripcion
        /// </summary>
        /// <param name="idIns">Id de la inscripcion relacionada con la
        /// competencia</param>
        /// <returns></returns>
        public DominioSKD.Competencia ConsultarCompetencia(int idIns)
        {
            Logger.EscribirInfo(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name,
                RecursosBDModulo14.MsjDeEntrada, System.Reflection.MethodBase.GetCurrentMethod().Name);
            SqlConnection conect = con.Conectar();
            DominioSKD.Competencia competencia = new DominioSKD.Competencia();
            try
            {

                SqlCommand sqlcom = new SqlCommand(RecursosBDModulo14.ProcedurePersonaCompetencia, conect);
                sqlcom.CommandType = CommandType.StoredProcedure;
                sqlcom.Parameters.Add(new SqlParameter(RecursosBDModulo14.ParametroInsId, idIns));

                SqlDataReader leer;
                conect.Open();

                leer = sqlcom.ExecuteReader();
                if (leer != null)
                {
                    while (leer.Read())
                    {
                        DominioSKD.Categoria cat = new DominioSKD.Categoria();
                        competencia.Categoria = cat;
                        competencia.Nombre = leer[RecursosBDModulo14.AtributoCompetenciaNombre].ToString();
                        competencia.FechaFin = Convert.ToDateTime(leer[RecursosBDModulo14.AtributoFechaFinCompetencia]);
                        competencia.FechaInicio = Convert.ToDateTime(leer[RecursosBDModulo14.AtributoFechaIniCompetencia]);
                        competencia.TipoCompetencia = leer[RecursosBDModulo14.AtributoTipoCompetencia].ToString();
                        competencia.Categoria.Sexo = leer[RecursosBDModulo14.AtributoSexoCategoria].ToString();
                        competencia.Categoria.Cinta_final = leer[RecursosBDModulo14.AtributoCintaFinCategoria].ToString();
                        competencia.Categoria.Cinta_inicial = leer[RecursosBDModulo14.AtributoCintaIniCategoria].ToString();
                        competencia.Categoria.Edad_final = Convert.ToInt32(leer[RecursosBDModulo14.AtributoEdadFinCategoria]);
                        competencia.Categoria.Edad_inicial = Convert.ToInt32(leer[RecursosBDModulo14.AtributoEdadIniCategoria]);
                        competencia.Costo = Convert.ToInt32( leer[RecursosBDModulo14.AtributoCostoCompetencia]);
                         

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
                Logger.EscribirError(RecursosBDModulo14.ClaseBDDatos, excep);
                throw excep;
            }
            catch (IOException ex)
            {
                BDDatosException excep = new BDDatosException(RecursosBDModulo14.CodigoIoException,
                    RecursosBDModulo14.MsjExceptionIO, ex);
                Logger.EscribirError(RecursosBDModulo14.ClaseBDDatos, excep);
                throw excep;
            }
            catch (NullReferenceException ex)
            {
                BDDatosException excep = new BDDatosException(RecursosBDModulo14.CodigoNullReferencesExcep,
                    RecursosBDModulo14.MsjNullException, ex);
                Logger.EscribirError(RecursosBDModulo14.ClaseBDDatos, excep);
                throw excep;
            }
            catch (ObjectDisposedException ex)
            {
                BDDatosException excep = new BDDatosException(RecursosBDModulo14.CodigoDisposedObject,
                    RecursosBDModulo14.MensajeDisposedException, ex);
                Logger.EscribirError(RecursosBDModulo14.ClaseBDDatos, excep);
                throw excep;
            }
            catch (ExcepcionesSKD.ExceptionSKDConexionBD ex)
            {
                Logger.EscribirError(RecursosBDModulo14.ClaseBDDatos, ex);

                throw ex;
            }
            catch (FormatException ex)
            {
                BDDatosException excep = new BDDatosException(RecursosBDModulo14.CodigoFormatExceptio,
                    RecursosBDModulo14.MsjFormatException, ex);
                Logger.EscribirError(RecursosBDModulo14.ClaseBDDatos, excep);
                throw excep;
            }
            catch (Exception ex)
            {
                BDDatosException excep = new BDDatosException(RecursosBDModulo14.CodigoException,
                    RecursosBDModulo14.MsjException, ex);
                Logger.EscribirError(RecursosBDModulo14.ClaseBDDatos, excep);
                throw excep;
            }
            finally
            {
                con.Desconectar(conect);
            }
        }

        /// <summary>
        /// Método que consulta los datos de una solicitud
        /// </summary>
        /// <param name="idSolicitud">Id de la solicitud a consultar</param>
        /// <returns>La clase solicitud</returns>
        public DominioSKD.SolicitudPlanilla ConsultarSolicitud(int idSolicitud)
        {
            Logger.EscribirInfo(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name,
                RecursosBDModulo14.MsjDeEntrada, System.Reflection.MethodBase.GetCurrentMethod().Name);
            SqlConnection conect = con.Conectar();
            DominioSKD.SolicitudPlanilla solicitud = new DominioSKD.SolicitudPlanilla();
            try
            {

                SqlCommand sqlcom = new SqlCommand(RecursosBDModulo14.ProcedureConsultarSolicitudId, conect);
                sqlcom.CommandType = CommandType.StoredProcedure;
                sqlcom.Parameters.Add(new SqlParameter(RecursosBDModulo14.ParametroIDSolici, idSolicitud));

                SqlDataReader leer;
                conect.Open();

                leer = sqlcom.ExecuteReader();
                if (leer != null)
                {
                    while (leer.Read())
                    {
                        solicitud.FechaCreacion = Convert.ToDateTime(leer[RecursosBDModulo14.AtributoFechaCreacion]);
                        solicitud.FechaReincorporacion = Convert.ToDateTime(leer[RecursosBDModulo14.AtributoFechaReincorporacion]);
                        solicitud.FechaRetiro = Convert.ToDateTime(leer[RecursosBDModulo14.AtributoFechaRetiro]);
                        solicitud.Motivo = leer[RecursosBDModulo14.AtributoMotivo].ToString();
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
                Logger.EscribirError(RecursosBDModulo14.ClaseBDDatos, excep);
                throw excep;
            }
            catch (IOException ex)
            {
                BDDatosException excep = new BDDatosException(RecursosBDModulo14.CodigoIoException,
                    RecursosBDModulo14.MsjExceptionIO, ex);
                Logger.EscribirError(RecursosBDModulo14.ClaseBDDatos, excep);
                throw excep;
            }
            catch (NullReferenceException ex)
            {
                BDDatosException excep = new BDDatosException(RecursosBDModulo14.CodigoNullReferencesExcep,
                    RecursosBDModulo14.MsjNullException, ex);
                Logger.EscribirError(RecursosBDModulo14.ClaseBDDatos, excep);
                throw excep;
            }
            catch (ObjectDisposedException ex)
            {
                BDDatosException excep = new BDDatosException(RecursosBDModulo14.CodigoDisposedObject,
                    RecursosBDModulo14.MensajeDisposedException, ex);
                Logger.EscribirError(RecursosBDModulo14.ClaseBDDatos, excep);
                throw excep;
            }
            catch (ExcepcionesSKD.ExceptionSKDConexionBD ex)
            {
                Logger.EscribirError(RecursosBDModulo14.ClaseBDDatos, ex);

                throw ex;
            }
            catch (FormatException ex)
            {
                BDDatosException excep = new BDDatosException(RecursosBDModulo14.CodigoFormatExceptio,
                    RecursosBDModulo14.MsjFormatException, ex);
                Logger.EscribirError(RecursosBDModulo14.ClaseBDDatos, excep);
                throw excep;
            }
            catch (Exception ex)
            {
                BDDatosException excep = new BDDatosException(RecursosBDModulo14.CodigoException,
                    RecursosBDModulo14.MsjException, ex);
                Logger.EscribirError(RecursosBDModulo14.ClaseBDDatos, excep);
                throw excep;
            }
            finally
            {
                con.Desconectar(conect);
            }
        }
        
    }
}
