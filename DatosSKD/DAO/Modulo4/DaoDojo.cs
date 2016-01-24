using DatosSKD.DAO;
using DatosSKD.InterfazDAO;
using DatosSKD.InterfazDAO.Modulo4;
using DominioSKD;
using DominioSKD.Fabrica;
using ExcepcionesSKD;
using ExcepcionesSKD.Modulo4;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatosSKD.DAO.Modulo4
{
    public class DaoDojo : DAOGeneral, IDaoDojo 
    {
        #region IDAO
        /// <summary>
        /// Método que agrega el dojo a la base de datos
        /// </summary>
        /// <param name="parametro">el dojo a insertar</param>
        /// <returns>true si se insertó y false en el caso contrario</returns>
        public bool Agregar(Entidad parametro)
        {
            Logger.EscribirInfo(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, RecursosDAOModulo4.MensajeInicioInfoLogger, System.Reflection.MethodBase.GetCurrentMethod().Name);

            try
            {
                DominioSKD.Dojo elDojo = (DominioSKD.Dojo)FabricaEntidades.ObtenerDojo_M4();
                    elDojo = (DominioSKD.Dojo)parametro;

                  
             if (!BuscarRifDojo(elDojo))
                { 
                   ///Se listan todos los parametros para crear el nuevo dojo
                    List<Parametro> parametros = new List<Parametro>();
                    Parametro elParametro = new Parametro(RecursosDAOModulo4.ParametroRifDojo, SqlDbType.VarChar, elDojo.Rif_dojo, false);
                    parametros.Add(elParametro);

                    elParametro = new Parametro(RecursosDAOModulo4.ParametroNombreDojo, SqlDbType.VarChar, elDojo.Nombre_dojo, false);
                    parametros.Add(elParametro);

                    elParametro = new Parametro(RecursosDAOModulo4.ParametroTelefonoDojo, SqlDbType.Int,
                       elDojo.Telefono_dojo.ToString(), false);
                    parametros.Add(elParametro);

                    elParametro = new Parametro(RecursosDAOModulo4.ParametroEmailDojo, SqlDbType.VarChar,
                        elDojo.Email_dojo, false);
                    parametros.Add(elParametro);

                    elParametro = new Parametro(RecursosDAOModulo4.ParametroLogoDojo, SqlDbType.VarChar,
                        elDojo.Logo_dojo, false);
                    parametros.Add(elParametro);

                    elParametro = new Parametro(RecursosDAOModulo4.ParametroStatusDojo, SqlDbType.Bit,
                        elDojo.Status_dojo.ToString(), false);
                    parametros.Add(elParametro);

                    elParametro = new Parametro(RecursosDAOModulo4.ParametroNombreEstado, SqlDbType.VarChar,
                        elDojo.Ubicacion.Estado, false);
                    parametros.Add(elParametro);

                    elParametro = new Parametro(RecursosDAOModulo4.ParametroNombreCiudad, SqlDbType.VarChar,
                        elDojo.Ubicacion.Ciudad, false);
                    parametros.Add(elParametro);

                    elParametro = new Parametro(RecursosDAOModulo4.ParametroLatitud, SqlDbType.VarChar,
                        elDojo.Ubicacion.Latitud, false);
                    parametros.Add(elParametro);

                    elParametro = new Parametro(RecursosDAOModulo4.ParametroLongitud, SqlDbType.VarChar,
                        elDojo.Ubicacion.Longitud, false);
                    parametros.Add(elParametro);

                    elParametro = new Parametro(RecursosDAOModulo4.ParametroDireccion, SqlDbType.VarChar,
                        elDojo.Ubicacion.Direccion, false);
                    parametros.Add(elParametro);
                    elParametro = new Parametro(RecursosDAOModulo4.ParamIdOrganizacion, SqlDbType.Int, elDojo.Organizacion.Id.ToString(), false);
                    parametros.Add(elParametro);
                    BDConexion laConexion = new BDConexion();
                    laConexion.EjecutarStoredProcedure(RecursosDAOModulo4.AgregarDojo, parametros);
                    Logger.EscribirInfo(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, RecursosDAOModulo4.MensajeFinInfoLogger, System.Reflection.MethodBase.GetCurrentMethod().Name);
            
                    return true;
                }
                else
                {
                    Logger.EscribirWarning(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, RecursosDAOModulo4.Mensaje_Dojo_Existente, System.Reflection.MethodBase.GetCurrentMethod().Name);

                    throw new ExcepcionesSKD.Modulo4.DojoInexistenteException(RecursosDAOModulo4.Codigo_Dojo_Existente,
                                RecursosDAOModulo4.Mensaje_Dojo_Existente, new Exception());
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

                throw new ExcepcionesSKD.Modulo4.FormatoIncorrectoException(RecursosDAOModulo4.Codigo_Error_Formato,
                     RecursosDAOModulo4.Mensaje_Error_Formato, ex);
            }
            catch (ExcepcionesSKD.Modulo4.DojoInexistenteException ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);

                throw ex;
            }
            catch (ExcepcionesSKD.ExceptionSKDConexionBD ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);

                throw ex;
            }
            catch (Exception ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);

                //throw new ExcepcionesSKD.ExceptionSKD(RecursoGeneralBD.Mensaje_Generico_Error, ex);
            }

            Logger.EscribirInfo(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, RecursosDAOModulo4.MensajeFinInfoLogger, System.Reflection.MethodBase.GetCurrentMethod().Name);
            
            return false;
        }
        public bool Modificar(Entidad parametro) { return true; }
        public Entidad ConsultarXId(Entidad parametro)
        {
            BDConexion laConexion;
            List<Parametro> parametros;
            Parametro elParametro = new Parametro();

           Logger.EscribirInfo(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, RecursosDAOModulo4.MensajeInicioInfoLogger, System.Reflection.MethodBase.GetCurrentMethod().Name);
          
            DominioSKD.Dojo elDojo = (DominioSKD.Dojo)FabricaEntidades.ObtenerDojo_M4();
            elDojo = (DominioSKD.Dojo)parametro;

            try
            {
               
                        laConexion = new BDConexion();
                        parametros = new List<Parametro>();


                        elParametro = new Parametro(RecursosDAOModulo4.ParamIdDojo, SqlDbType.Int, elDojo.Id.ToString(),
                                                    false);
                        parametros.Add(elParametro);

                        DataTable dt = laConexion.EjecutarStoredProcedureTuplas(
                                       RecursosDAOModulo4.ConsultarDojoXId, parametros);

                        foreach (DataRow row in dt.Rows)
                        {

                            Organizacion org = (Organizacion)FabricaEntidades.ObtenerOrganizacion_M4();
                            Ubicacion ubi = (Ubicacion)FabricaEntidades.ObtenerUbicacion_M4();

                            elDojo.Id_dojo = int.Parse(row[RecursosDAOModulo4.AliasIdDojo].ToString());
                            elDojo.Rif_dojo = row[RecursosDAOModulo4.AliasRifDojo].ToString();
                            elDojo.Nombre_dojo = row[RecursosDAOModulo4.AliasNombreDojo].ToString();
                            elDojo.Telefono_dojo = int.Parse(row[RecursosDAOModulo4.AliasTelefonoDojo].ToString());
                            elDojo.Email_dojo = row[RecursosDAOModulo4.AliasEmailDojo].ToString();
                            elDojo.Logo_dojo = row[RecursosDAOModulo4.AliasLogoDojo].ToString();
                            elDojo.Status_dojo = bool.Parse(row[RecursosDAOModulo4.AliasStatusDojo].ToString());
                            elDojo.Estilo_dojo = row[RecursosDAOModulo4.AliasEstiloDojo].ToString();
                            elDojo.Registro_dojo = DateTime.Parse(row[RecursosDAOModulo4.AliasFechaDojo].ToString());
                            org.Id = int.Parse(row[RecursosDAOModulo4.AliasIdOrganizacion].ToString());
                            org.Nombre = row[RecursosDAOModulo4.AliasNombreOrganizacion].ToString();
                            elDojo.Organizacion = org;
                            ubi.Id = int.Parse(row[RecursosDAOModulo4.AliasIdUbicacion].ToString());
                            ubi.Ciudad = row[RecursosDAOModulo4.AliasNombreCiudad].ToString();
                            ubi.Estado = row[RecursosDAOModulo4.AliasNombreEstado].ToString();
                            elDojo.Ubicacion = ubi;


                        }
                        
                    

            }
            catch (SqlException ex)
            {
                throw new ExcepcionesSKD.ExceptionSKDConexionBD(RecursoGeneralBD.Codigo,
                    RecursoGeneralBD.Mensaje, ex);
            }
            catch (FormatException ex)
            {
                throw new ExcepcionesSKD.Modulo4.FormatoIncorrectoException(RecursosDAOModulo4.Codigo_Error_Formato,
                     RecursosDAOModulo4.Mensaje_Error_Formato, ex);
            }
            catch (ExcepcionesSKD.Modulo4.DojoInexistenteException ex)
            {
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

            return elDojo;
        }
        public List<Entidad> ConsultarTodos()
        {
            BDConexion laConexion;
            List<Entidad> laListaDeDojos = new List<Entidad>();
            List<Parametro> parametros;

            try
            {
                laConexion = new BDConexion();
                parametros = new List<Parametro>();


                DataTable dt = laConexion.EjecutarStoredProcedureTuplas(
                               RecursosDAOModulo4.ConsultarDojos, parametros);
                foreach (DataRow row in dt.Rows)
                {

                    Dojo elDojo = (Dojo)FabricaEntidades.ObtenerDojo_M4();
                    Organizacion org = (Organizacion)FabricaEntidades.ObtenerOrganizacion_M4();
                    Ubicacion ubi = (Ubicacion)FabricaEntidades.ObtenerUbicacion_M4();

                    elDojo.Id_dojo = int.Parse(row[RecursosDAOModulo4.AliasIdDojo].ToString());
                    elDojo.Rif_dojo = row[RecursosDAOModulo4.AliasRifDojo].ToString();
                    elDojo.Nombre_dojo = row[RecursosDAOModulo4.AliasNombreDojo].ToString();
                    elDojo.Telefono_dojo = int.Parse(row[RecursosDAOModulo4.AliasTelefonoDojo].ToString());
                    elDojo.Email_dojo = row[RecursosDAOModulo4.AliasEmailDojo].ToString();
                    elDojo.Logo_dojo = row[RecursosDAOModulo4.AliasLogoDojo].ToString();
                    elDojo.Status_dojo = bool.Parse(row[RecursosDAOModulo4.AliasStatusDojo].ToString());
                    org.Nombre= row[RecursosDAOModulo4.AliasNombreOrganizacion].ToString();
                    elDojo.Registro_dojo = DateTime.Parse(row[RecursosDAOModulo4.AliasFechaDojo].ToString());
                    org.Id = int.Parse(row[RecursosDAOModulo4.AliasIdOrganizacion].ToString());
                    elDojo.Organizacion = org;
                    ubi.Id = int.Parse(row[RecursosDAOModulo4.AliasIdUbicacion].ToString());
                    ubi.Ciudad = row[RecursosDAOModulo4.AliasNombreCiudad].ToString();
                    ubi.Estado =row[RecursosDAOModulo4.AliasNombreEstado].ToString();
                    elDojo.Ubicacion = ubi;

                    laListaDeDojos.Add(elDojo);

                }

            }
            catch (SqlException ex)
            {
                throw new ExcepcionesSKD.ExceptionSKDConexionBD(RecursoGeneralBD.Codigo,
                    RecursoGeneralBD.Mensaje, ex);
            }
            catch (FormatException ex)
            {
                throw new ExcepcionesSKD.Modulo4.FormatoIncorrectoException(RecursosDAOModulo4.Codigo_Error_Formato,
                     RecursosDAOModulo4.Mensaje_Error_Formato, ex);
            }
            catch (ExcepcionesSKD.ExceptionSKDConexionBD ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw new ExcepcionesSKD.ExceptionSKD(RecursoGeneralBD.Mensaje_Generico_Error, ex);
            }

            return laListaDeDojos;
        }
        public bool EliminarDojo(Entidad parametro)
        {
            Logger.EscribirInfo(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, RecursosDAOModulo4.MensajeInicioInfoLogger, System.Reflection.MethodBase.GetCurrentMethod().Name);

            BDConexion laConexion;
            List<Parametro> parametros;
            Parametro elParametro = new Parametro();

           
            try
            {
                DominioSKD.Dojo elDojo = (DominioSKD.Dojo)FabricaEntidades.ObtenerDojo_M4();
                elDojo = (DominioSKD.Dojo)parametro;

                laConexion = new BDConexion();
                parametros = new List<Parametro>();
                elParametro = new Parametro(RecursosDAOModulo4.ParamIdDojo, SqlDbType.Int, elDojo.Id.ToString(),
                                               false);
                parametros.Add(elParametro);

                laConexion.EjecutarStoredProcedure(RecursosDAOModulo4.EliminarDojo, parametros);
               
                return true;

            }
            catch (SqlException ex)
            {
                throw new ExcepcionesSKD.ExceptionSKDConexionBD(RecursoGeneralBD.Codigo,
                    RecursoGeneralBD.Mensaje, ex);
            }
            catch (FormatException ex)
            {
                throw new ExcepcionesSKD.Modulo4.FormatoIncorrectoException(RecursosDAOModulo4.Codigo_Error_Formato,
                     RecursosDAOModulo4.Mensaje_Error_Formato, ex);
            }
            catch (ExcepcionesSKD.ExceptionSKDConexionBD ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw new ExcepcionesSKD.ExceptionSKD(RecursoGeneralBD.Mensaje_Generico_Error, ex);
            }
            return false;
        }
        public List<Entidad> ConsultarTodosOrganizacion(Entidad parametro)
        {
            BDConexion laConexion;
            List<Entidad> laListaDeDojos = new List<Entidad>();
            List<Parametro> parametros;

            try
            {
                int idOrg = BuscarIdOrganizacion(parametro);
                if (idOrg != 0)
                {
                    laConexion = new BDConexion();
                    parametros = new List<Parametro>();

                    Parametro elParametro = new Parametro(RecursosDAOModulo4.ParamIdOrganizacion, SqlDbType.Int, idOrg.ToString(),
                                                  false);
                    parametros.Add(elParametro);

                    DataTable dt = laConexion.EjecutarStoredProcedureTuplas(
                                   RecursosDAOModulo4.ConsultarDojosXOrg, parametros);
                    foreach (DataRow row in dt.Rows)
                    {

                        Dojo elDojo = (Dojo)FabricaEntidades.ObtenerDojo_M4();
                        Organizacion org = (Organizacion)FabricaEntidades.ObtenerOrganizacion_M4();
                        Ubicacion ubi = (Ubicacion)FabricaEntidades.ObtenerUbicacion_M4();

                        elDojo.Id_dojo = int.Parse(row[RecursosDAOModulo4.AliasIdDojo].ToString());
                        elDojo.Rif_dojo = row[RecursosDAOModulo4.AliasRifDojo].ToString();
                        elDojo.Nombre_dojo = row[RecursosDAOModulo4.AliasNombreDojo].ToString();
                        elDojo.Telefono_dojo = int.Parse(row[RecursosDAOModulo4.AliasTelefonoDojo].ToString());
                        elDojo.Email_dojo = row[RecursosDAOModulo4.AliasEmailDojo].ToString();
                        elDojo.Logo_dojo = row[RecursosDAOModulo4.AliasLogoDojo].ToString();
                        elDojo.Status_dojo = bool.Parse(row[RecursosDAOModulo4.AliasStatusDojo].ToString());
                        org.Nombre = row[RecursosDAOModulo4.AliasNombreOrganizacion].ToString();
                        elDojo.Registro_dojo = DateTime.Parse(row[RecursosDAOModulo4.AliasFechaDojo].ToString());
                        org.Id = int.Parse(row[RecursosDAOModulo4.AliasIdOrganizacion].ToString());
                        elDojo.Organizacion = org;
                        ubi.Id = int.Parse(row[RecursosDAOModulo4.AliasIdUbicacion].ToString());
                        ubi.Ciudad = row[RecursosDAOModulo4.AliasNombreCiudad].ToString();
                        ubi.Estado = row[RecursosDAOModulo4.AliasNombreEstado].ToString();
                        elDojo.Ubicacion = ubi;

                        laListaDeDojos.Add(elDojo);

                    }
                }
            }
            catch (SqlException ex)
            {
                throw new ExcepcionesSKD.ExceptionSKDConexionBD(RecursoGeneralBD.Codigo,
                    RecursoGeneralBD.Mensaje, ex);
            }
            catch (FormatException ex)
            {
                throw new ExcepcionesSKD.Modulo4.FormatoIncorrectoException(RecursosDAOModulo4.Codigo_Error_Formato,
                     RecursosDAOModulo4.Mensaje_Error_Formato, ex);
            }
            catch (ExcepcionesSKD.ExceptionSKDConexionBD ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw new ExcepcionesSKD.ExceptionSKD(RecursoGeneralBD.Mensaje_Generico_Error, ex);
            }

            return laListaDeDojos;
        }
        #endregion

        #region IDaoDojo
        public bool BuscarRifDojo(Entidad parametro)
        {
            bool retorno = false;
            BDConexion laConexion;
            List<Parametro> parametros;

            try
            {
                DominioSKD.Dojo elDojo = (DominioSKD.Dojo)FabricaEntidades.ObtenerDojo_M4();
                elDojo = (DominioSKD.Dojo)parametro;

                laConexion = new BDConexion();
                parametros = new List<Parametro>();

                Parametro elParametro = new Parametro(RecursosDAOModulo4.ParamRifDojo, SqlDbType.VarChar, elDojo.Rif_dojo.ToString(),
                                               false);
                parametros.Add(elParametro);
                DataTable dt = laConexion.EjecutarStoredProcedureTuplas(RecursosDAOModulo4.BuscarRifDojo, parametros);

                if (dt != null)
                {
                    foreach (DataRow row in dt.Rows)
                    {

                        if (String.Equals(elDojo.Rif_dojo, row[RecursosDAOModulo4.ParametroRifDojo].ToString()))
                        {
                            retorno = true;
                            break;
                        }
                        else retorno = false;
                    }
                }
                else return false;
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
                throw new ExcepcionesSKD.Modulo12.FormatoIncorrectoException(RecursosDAOModulo4.Codigo_Error_Formato,
                     RecursosDAOModulo4.Mensaje_Error_Formato, ex);
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


            Logger.EscribirInfo(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, RecursosDAOModulo4.MensajeFinInfoLogger, System.Reflection.MethodBase.GetCurrentMethod().Name);

            return retorno;

        }

        public int BuscarIdOrganizacion(Entidad parametro)
        {
            BDConexion laConexion;
            List<Parametro> parametros;

            try
            {

                laConexion = new BDConexion();
                parametros = new List<Parametro>();

                Parametro elParametro = new Parametro(RecursosDAOModulo4.ParamIdOrganizacion, SqlDbType.Int, parametro.Id.ToString(),
                                               false);
                parametros.Add(elParametro);
                DataTable dt = laConexion.EjecutarStoredProcedureTuplas(RecursosDAOModulo4.BuscarIdOrganizacion, parametros);

                if (dt != null)
                {
                    foreach (DataRow row in dt.Rows)
                    {
                        int id = int.Parse(row[RecursosDAOModulo4.AliasIdOrganizacion].ToString());
                            return id;
                    }
                }
                else return 0;
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
                throw new ExcepcionesSKD.Modulo12.FormatoIncorrectoException(RecursosDAOModulo4.Codigo_Error_Formato,
                     RecursosDAOModulo4.Mensaje_Error_Formato, ex);
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


            Logger.EscribirInfo(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, RecursosDAOModulo4.MensajeFinInfoLogger, System.Reflection.MethodBase.GetCurrentMethod().Name);

            return 0;
        }
        #endregion
    }
}
