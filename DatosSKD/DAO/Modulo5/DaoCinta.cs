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
using System.Globalization;
using DominioSKD.Fabrica;
using DatosSKD.InterfazDAO;
using DatosSKD.InterfazDAO.Modulo5;

namespace DatosSKD.DAO.Modulo5
{
    public class DaoCinta : DAOGeneral, IDaoCinta
    {
        #region IDAO
        /// <summary>
        /// Método Agrega una Cinta en la Base de Datos
        /// </summary>
        /// <param name="parametro">Cinta</param>
        /// <returns>True si lo agrega, False si no</returns>
        public bool Agregar(Entidad parametro)
        {
            Logger.EscribirInfo(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, RecursosDaoModulo5.MensajeInicioInfoLogger, System.Reflection.MethodBase.GetCurrentMethod().Name);

            try
            {
                DominioSKD.Entidades.Modulo5.Cinta laCinta = (DominioSKD.Entidades.Modulo5.Cinta)parametro;

               
                DominioSKD.Entidades.Modulo3.Organizacion laOrganizacion;

                laOrganizacion = (DominioSKD.Entidades.Modulo3.Organizacion)FabricaEntidades.ObtenerOrganizacion_M3(laCinta.Organizacion.Id_organizacion, laCinta.Organizacion.Nombre);


               if (ValidarOrganizacion(laOrganizacion)) 
                {
                    if (!ValidarNombreCinta(laCinta))
                    {
                        if (!ValidarOrdenCinta(laCinta))
                        { 
               
                        List<Parametro> parametros = new List<Parametro>(); 

                        Parametro elParametro = new Parametro(RecursosDaoModulo5.ParamColorCinta, SqlDbType.VarChar, laCinta.Color_nombre, false);
                        parametros.Add(elParametro);
                        elParametro = new Parametro(RecursosDaoModulo5.ParamRangoCinta, SqlDbType.VarChar, laCinta.Rango, false);
                        parametros.Add(elParametro);
                        elParametro = new Parametro(RecursosDaoModulo5.ParamClasiCinta, SqlDbType.VarChar, laCinta.Clasificacion, false);
                        parametros.Add(elParametro);
                        elParametro = new Parametro(RecursosDaoModulo5.ParamSignificadoCinta, SqlDbType.VarChar, laCinta.Significado, false);
                        parametros.Add(elParametro);
                        elParametro = new Parametro(RecursosDaoModulo5.ParamOrdenCinta, SqlDbType.Int, laCinta.Orden.ToString(), false);
                        parametros.Add(elParametro);
                        elParametro = new Parametro(RecursosDaoModulo5.ParamIdOrgCinta, SqlDbType.Int, laCinta.Organizacion.Id_organizacion.ToString(), false);
                        parametros.Add(elParametro);
                        elParametro = new Parametro(RecursosDaoModulo5.ParamNomOrg, SqlDbType.VarChar, laCinta.Organizacion.Nombre, false);
                        parametros.Add(elParametro);

                        string query = RecursosDaoModulo5.AgregarCinta;
                        List<Resultado> resultados = this.EjecutarStoredProcedure(query
                                        , parametros);
                        }
                        else
                        {
                            throw new ExcepcionesSKD.Modulo5.OrdenCintaRepetidoException(RecursosDaoModulo5.Codigo_Orden_Cinta_Repetida,
                                    RecursosDaoModulo5.Mensaje_Orden_Cinta_Repetida, new Exception());
                        }
                    }
                    else
                    {
                        throw new ExcepcionesSKD.Modulo5.CintaRepetidaException(RecursosDaoModulo5.Codigo_Cinta_Repetida,
                                RecursosDaoModulo5.Mensaje_Cinta_Repetida, new Exception());
                    }
                }// Fin if    
                else
                {
                    throw new ExcepcionesSKD.Modulo5.OrganizacionInexistenteException(RecursosDaoModulo5.Codigo_Organizacion_Inexistente,
                                    RecursosDaoModulo5.Mensaje_Organizacion_Inexistente, new Exception());
                }
            } // Fin Try
            catch (SqlException ex) 
            {
                throw new ExcepcionesSKD.ExceptionSKDConexionBD(RecursoGeneralBD.Codigo,
                    RecursoGeneralBD.Mensaje, ex);
            }
            catch (FormatException ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);

                throw new ExcepcionesSKD.Modulo5.FormatoIncorrectoException(RecursosDaoModulo5.Codigo_Error_Formato,
                     RecursosDaoModulo5.Mensaje_Error_Formato, ex);
            }
            catch (ExcepcionesSKD.ExceptionSKDConexionBD ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);

                throw ex;
            }
            Logger.EscribirInfo(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, RecursosDaoModulo5.MensajeFinInfoLogger, System.Reflection.MethodBase.GetCurrentMethod().Name);
           
            return true;
        }
        /// <summary>
        /// Método Modificar una Cinta especifica en la Base de Datos 
        /// </summary>
        /// <param name="parametro">Cinta</param>
        /// <returns>True si lo agrega, False si no</returns>
        public bool Modificar(Entidad parametro)
        {
            Logger.EscribirInfo(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, RecursosDaoModulo5.MensajeInicioInfoLogger, System.Reflection.MethodBase.GetCurrentMethod().Name);

            try
            {
                DominioSKD.Entidades.Modulo5.Cinta laCinta = (DominioSKD.Entidades.Modulo5.Cinta)parametro;

                DominioSKD.Entidades.Modulo3.Organizacion laOrganizacion;

                laOrganizacion = (DominioSKD.Entidades.Modulo3.Organizacion)FabricaEntidades.ObtenerOrganizacion_M3(laCinta.Organizacion.Id_organizacion, laCinta.Organizacion.Nombre);

            if (ValidarOrganizacion(laOrganizacion))
               {  
                       if (!ValidarOrdenCinta(laCinta))
                       {

                            List<Parametro> parametros = new List<Parametro>(); 


                Parametro elParametro = new Parametro(RecursosDaoModulo5.ParamModificarCinta, SqlDbType.Int, laCinta.Id_cinta.ToString(), false);
                parametros.Add(elParametro);
                elParametro = new Parametro(RecursosDaoModulo5.ParamColorCinta, SqlDbType.VarChar, laCinta.Color_nombre, false);
                parametros.Add(elParametro);
                elParametro = new Parametro(RecursosDaoModulo5.ParamRangoCinta, SqlDbType.VarChar, laCinta.Rango, false);
                parametros.Add(elParametro);
                elParametro = new Parametro(RecursosDaoModulo5.ParamClasiCinta, SqlDbType.VarChar, laCinta.Clasificacion, false);
                parametros.Add(elParametro);
                elParametro = new Parametro(RecursosDaoModulo5.ParamSignificadoCinta, SqlDbType.VarChar, laCinta.Significado, false);
                parametros.Add(elParametro);
                elParametro = new Parametro(RecursosDaoModulo5.ParamOrdenCinta, SqlDbType.Int, laCinta.Orden.ToString(), false);
                parametros.Add(elParametro);
                elParametro = new Parametro(RecursosDaoModulo5.ParamIdOrgCinta, SqlDbType.Int, laCinta.Organizacion.Id_organizacion.ToString(), false);
                parametros.Add(elParametro);
                elParametro = new Parametro(RecursosDaoModulo5.ParamNomOrg, SqlDbType.VarChar, laCinta.Organizacion.Nombre, false);
                parametros.Add(elParametro);


                
                string query = RecursosDaoModulo5.ModificarCinta;
                List<Resultado> resultados = this.EjecutarStoredProcedure(query, parametros);
                     }
                     else
                     {
                         throw new ExcepcionesSKD.Modulo5.OrdenCintaRepetidoException(RecursosDaoModulo5.Codigo_Orden_Cinta_Repetida,
                                 RecursosDaoModulo5.Mensaje_Orden_Cinta_Repetida, new Exception());
                     }

               } // Fin if
          else
             {
                 throw new ExcepcionesSKD.Modulo5.OrganizacionInexistenteException(RecursosDaoModulo5.Codigo_Organizacion_Inexistente,
                                RecursosDaoModulo5.Mensaje_Organizacion_Inexistente, new Exception());
             }
            } // Fin Try
            catch (SqlException ex) 
            {
                throw new ExcepcionesSKD.ExceptionSKDConexionBD(RecursoGeneralBD.Codigo,
                    RecursoGeneralBD.Mensaje, ex);
            }
            catch (FormatException ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);

                throw new ExcepcionesSKD.Modulo5.FormatoIncorrectoException(RecursosDaoModulo5.Codigo_Error_Formato,
                    RecursosDaoModulo5.Mensaje_Error_Formato, ex);
            }
            catch (ExcepcionesSKD.ExceptionSKDConexionBD ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);

                throw ex;
            }

            Logger.EscribirInfo(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, RecursosDaoModulo5.MensajeFinInfoLogger, System.Reflection.MethodBase.GetCurrentMethod().Name);
           
            return true;
        }
        /// <summary>
        /// Método Consultar los Detalles de una Cinta en especifico
        /// </summary>
        /// <param name="parametro">Id de la Cinta a consultar</param>
        /// <returns>LaCinta</returns>
        public Entidad ConsultarXId(Entidad parametro)
        {
            Logger.EscribirInfo(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, RecursosDaoModulo5.MensajeInicioInfoLogger, System.Reflection.MethodBase.GetCurrentMethod().Name);

            List<Parametro> parametros;
            Parametro elParametro = new Parametro();
          
            DominioSKD.Entidades.Modulo5.Cinta laCinta;

            laCinta = (DominioSKD.Entidades.Modulo5.Cinta)parametro;

            try
            {

                parametros = new List<Parametro>();

                elParametro = new Parametro(RecursosDaoModulo5.ParamIdCinta, SqlDbType.Int, laCinta.Id_cinta.ToString(),
                                            false);
                parametros.Add(elParametro);

                DataTable dt = this.EjecutarStoredProcedureTuplas(
                               RecursosDaoModulo5.ConsultarCintasXId, parametros);

                foreach (DataRow row in dt.Rows)
                {

                    laCinta.Id_cinta = int.Parse(row[RecursosDaoModulo5.AliasIdCinta].ToString());
                    laCinta.Color_nombre = row[RecursosDaoModulo5.AliasColorCinta].ToString();
                    laCinta.Rango = row[RecursosDaoModulo5.AliasRangoCinta].ToString();
                    laCinta.Clasificacion = row[RecursosDaoModulo5.AliasClasificacionCint].ToString();
                    laCinta.Significado = row[RecursosDaoModulo5.AliasSignificadoCinta].ToString();
                    laCinta.Orden = int.Parse(row[RecursosDaoModulo5.AliasOrdenCinta].ToString());
                    laCinta.Organizacion = (DominioSKD.Entidades.Modulo3.Organizacion)FabricaEntidades.ObtenerOrganizacion_M3(int.Parse(row[RecursosDaoModulo5.AliasIdOrganizacion].ToString())
                                                                         , row[RecursosDaoModulo5.AliasNombreOrg].ToString());


                }
                
                Logger.EscribirInfo(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, RecursosDaoModulo5.MensajeFinInfoLogger, System.Reflection.MethodBase.GetCurrentMethod().Name);

                return laCinta;

            }
            catch (SqlException ex) 
            {
                throw new ExcepcionesSKD.ExceptionSKDConexionBD(RecursoGeneralBD.Codigo,
                    RecursoGeneralBD.Mensaje, ex);
            }
            catch (FormatException ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);

                throw new ExcepcionesSKD.Modulo5.FormatoIncorrectoException(RecursosDaoModulo5.Codigo_Error_Formato,
                    RecursosDaoModulo5.Mensaje_Error_Formato, ex);
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
        /// Método Consulta la Lista de Todas las Cintas en la Base de Datos
        /// </summary>
        /// <returns>Lista de Cintas</returns>
        public List<Entidad> ConsultarTodos()
        {
            Logger.EscribirInfo(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, RecursosDaoModulo5.MensajeInicioInfoLogger, System.Reflection.MethodBase.GetCurrentMethod().Name);


            List<Entidad> laListaCintas = new List<Entidad>();
            List<Parametro> parametros;
            string status;
            DominioSKD.Entidades.Modulo5.Cinta laCinta;

            try
            {

                parametros = new List<Parametro>();


                DataTable dt = EjecutarStoredProcedureTuplas(
                               RecursosDaoModulo5.ConsultarTodasLasCintas, parametros);

                foreach (DataRow row in dt.Rows)
                {
                    laCinta = (DominioSKD.Entidades.Modulo5.Cinta)FabricaEntidades.ObtenerCinta_M5();

                    laCinta.Id_cinta = int.Parse(row[RecursosDaoModulo5.AliasIdCinta].ToString());
                    laCinta.Color_nombre = row[RecursosDaoModulo5.AliasColorCinta].ToString();
                    laCinta.Rango = row[RecursosDaoModulo5.AliasRangoCinta].ToString();
                    laCinta.Clasificacion = row[RecursosDaoModulo5.AliasClasificacionCint].ToString();
                    laCinta.Significado = row[RecursosDaoModulo5.AliasSignificadoCinta].ToString();
                    laCinta.Orden = int.Parse(row[RecursosDaoModulo5.AliasOrdenCinta].ToString());                
                    laCinta.Organizacion = (DominioSKD.Entidades.Modulo3.Organizacion)FabricaEntidades.ObtenerOrganizacion_M3(int.Parse(row[RecursosDaoModulo5.AliasIdOrganizacion].ToString())
                                                                        , row[RecursosDaoModulo5.AliasNombreOrg].ToString());
                    laCinta.Status = bool.Parse(row[RecursosDaoModulo5.AliasStatusCinta].ToString());


                    laListaCintas.Add(laCinta);

                }

            }
            catch (SqlException ex) 
            {
                throw new ExcepcionesSKD.ExceptionSKDConexionBD(RecursoGeneralBD.Codigo,
                    RecursoGeneralBD.Mensaje, ex);
            }
            catch (FormatException ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);

                throw new ExcepcionesSKD.Modulo5.FormatoIncorrectoException(RecursosDaoModulo5.Codigo_Error_Formato,
                    RecursosDaoModulo5.Mensaje_Error_Formato, ex);
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

            Logger.EscribirInfo(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, RecursosDaoModulo5.MensajeFinInfoLogger, System.Reflection.MethodBase.GetCurrentMethod().Name);

            return laListaCintas;
        }
        #endregion

        #region IDaoCinta
        /// <summary>
        /// Método que busca si existe la Organizacion
        /// </summary>
        /// <param name="parametro">id de la Organizacion a consultar</param>
        /// <returns>True si Existe, False si no</returns>
        public bool ValidarOrganizacion(Entidad parametro)
        {
            Logger.EscribirInfo(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, RecursosDaoModulo5.MensajeInicioInfoLogger, System.Reflection.MethodBase.GetCurrentMethod().Name);
 
            bool retorno = false;
            List<Parametro> parametros;
            SqlConnection conect = Conectar();
            try
            {
                DominioSKD.Entidades.Modulo3.Organizacion laOrganizacion = (DominioSKD.Entidades.Modulo3.Organizacion)parametro;

                
                parametros = new List<Parametro>();

                Parametro elParametro = new Parametro(RecursosDaoModulo5.ParamIdOrgCinta, SqlDbType.Int
                                                      , laOrganizacion.Id_organizacion.ToString(), false);
                parametros.Add(elParametro);

                elParametro = new Parametro(RecursosDaoModulo5.ParamSalidaNumOrganizacion, SqlDbType.Int, true);
                parametros.Add(elParametro);

                string query = RecursosDaoModulo5.BuscarIDOrganiacion;
                List<Resultado> resultados = EjecutarStoredProcedure(query, parametros);

                foreach (Resultado elResultado in resultados)
                {
                    if (elResultado.etiqueta == RecursosDaoModulo5.ParamSalidaNumOrganizacion)
                        if (int.Parse(elResultado.valor) == 1){
                            retorno = true;
                            return retorno;
                        }                            
                        else
                        {
                            Logger.EscribirWarning(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, RecursosDaoModulo5.Mensaje_Organizacion_Inexistente, System.Reflection.MethodBase.GetCurrentMethod().Name);

                            throw new ExcepcionesSKD.Modulo5.OrganizacionInexistenteException(RecursosDaoModulo5.Codigo_Organizacion_Inexistente,
                                RecursosDaoModulo5.Mensaje_Organizacion_Inexistente, new Exception());
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
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);

                throw new ExcepcionesSKD.Modulo5.FormatoIncorrectoException(RecursosDaoModulo5.Codigo_Error_Formato,
                    RecursosDaoModulo5.Mensaje_Error_Formato, ex);
            }
            catch (ExcepcionesSKD.ExceptionSKDConexionBD ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);

                throw ex;
            }
            finally
            {
                LimpiarSQLConnection();
            }
            
            Logger.EscribirInfo(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, RecursosDaoModulo5.MensajeFinInfoLogger, System.Reflection.MethodBase.GetCurrentMethod().Name);

            return retorno;


        }
        /// <summary>
        /// Método que busca el Orden de la Cinta si ya existe en una Organizacion
        /// </summary>
        /// <param name="parametro">Cinta a consultar</param>
        /// <returns>True si Existe, False si no</returns>
        public bool ValidarOrdenCinta(Entidad parametro)
        {
            Logger.EscribirInfo(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, RecursosDaoModulo5.MensajeInicioInfoLogger, System.Reflection.MethodBase.GetCurrentMethod().Name);

            bool retorno = false;
            List<Parametro> parametros;

            try
            {
                DominioSKD.Entidades.Modulo5.Cinta laCinta = (DominioSKD.Entidades.Modulo5.Cinta)parametro;

                parametros = new List<Parametro>();

                Parametro elParametro = new Parametro(RecursosDaoModulo5.ParamOrdenCinta, SqlDbType.Int
                                                      , laCinta.Orden.ToString(), false);
                parametros.Add(elParametro);

                elParametro = new Parametro(RecursosDaoModulo5.ParamIdOrgCinta, SqlDbType.Int
                                                      , laCinta.Organizacion.Id_organizacion.ToString(), false);
                parametros.Add(elParametro);

                elParametro = new Parametro(RecursosDaoModulo5.ParamSalidaNumCinta, SqlDbType.Int, true);
                parametros.Add(elParametro);

                List<Resultado> resultados = EjecutarStoredProcedure(RecursosDaoModulo5.BuscarOrdenCinta
                                             , parametros);

                foreach (Resultado elResultado in resultados)
                {
                    if (elResultado.etiqueta == RecursosDaoModulo5.ParamSalidaNumCinta)
                        if (int.Parse(elResultado.valor) == 1) // Significa q el orden si esta repetido
                            retorno = true;
                        else
                        {
                            retorno = false;
                        }
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
                throw new ExcepcionesSKD.Modulo5.FormatoIncorrectoException(RecursosDaoModulo5.Codigo_Error_Formato,
                     RecursosDaoModulo5.Mensaje_Error_Formato, ex);
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
            finally
            {
                LimpiarSQLConnection();
            }
            Logger.EscribirInfo(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, RecursosDaoModulo5.MensajeFinInfoLogger, System.Reflection.MethodBase.GetCurrentMethod().Name);

            return retorno;


        }
        /// <summary>
        /// Método que busca si existe la Cinta en una Organizacion
        /// </summary>
        /// <param name="parametro">Cinta a consultar</param>
        /// <returns>True si Existe, False si no</returns>
        public bool ValidarNombreCinta(Entidad parametro)
        {
            Logger.EscribirInfo(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, RecursosDaoModulo5.MensajeInicioInfoLogger, System.Reflection.MethodBase.GetCurrentMethod().Name);

            bool retorno = false;
            List<Parametro> parametros;

            try
            {
                DominioSKD.Entidades.Modulo5.Cinta laCinta = (DominioSKD.Entidades.Modulo5.Cinta)parametro;

                parametros = new List<Parametro>();

                Parametro elParametro = new Parametro(RecursosDaoModulo5.ParamColorCinta, SqlDbType.VarChar
                                                      , laCinta.Color_nombre, false);
                parametros.Add(elParametro);

                elParametro = new Parametro(RecursosDaoModulo5.ParamIdOrgCinta, SqlDbType.Int
                                                      , laCinta.Organizacion.Id_organizacion.ToString(), false);
                parametros.Add(elParametro);

                elParametro = new Parametro(RecursosDaoModulo5.ParamSalidaNumCinta, SqlDbType.Int, true);
                parametros.Add(elParametro);

                List<Resultado> resultados = EjecutarStoredProcedure(RecursosDaoModulo5.BuscarNombreCinta
                                             , parametros);

                foreach (Resultado elResultado in resultados)
                {
                    if (elResultado.etiqueta == RecursosDaoModulo5.ParamSalidaNumCinta)
                        if (int.Parse(elResultado.valor) == 1) // Significa q el nombre en esa organizacion esta repetido si esta repetido
                            retorno = true;
                        else
                        {
                            retorno = false;
                        }
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
                throw new ExcepcionesSKD.Modulo5.FormatoIncorrectoException(RecursosDaoModulo5.Codigo_Error_Formato,
                     RecursosDaoModulo5.Mensaje_Error_Formato, ex);
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
            finally
            {
                LimpiarSQLConnection();
            }
            Logger.EscribirInfo(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, RecursosDaoModulo5.MensajeFinInfoLogger, System.Reflection.MethodBase.GetCurrentMethod().Name);

            return retorno;


        }
        /// <summary>
        /// Método que Consulta la lista de Cinstas Dada una Organizacion
        /// </summary>
        /// <param name="parametro">id de la Organizacion a consultar</param>
        /// <returns>Lista de Entidades que son una Lista de De Cintas</returns>
        public List<Entidad> ListarCintasXOrganizacion(Entidad parametro)
        {
            Logger.EscribirInfo(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, RecursosDaoModulo5.MensajeInicioInfoLogger, System.Reflection.MethodBase.GetCurrentMethod().Name);

            List<Entidad> laListaCintas = new List<Entidad>();
            List<Parametro> parametros;
            Parametro elParametro = new Parametro();
            DominioSKD.Entidades.Modulo3.Organizacion laOrganizacion;

            laOrganizacion = (DominioSKD.Entidades.Modulo3.Organizacion)parametro;
          

            try
            {

                parametros = new List<Parametro>();

                elParametro = new Parametro(RecursosDaoModulo5.ParamIdOrg, SqlDbType.Int, laOrganizacion.Id_organizacion.ToString(), false);
                parametros.Add(elParametro);

                DataTable dt = EjecutarStoredProcedureTuplas(
                               RecursosDaoModulo5.ConsultarCintasXOrganizacionId, parametros);

                foreach (DataRow row in dt.Rows)
                {
                    DominioSKD.Entidades.Modulo5.Cinta laCinta = new DominioSKD.Entidades.Modulo5.Cinta();

                    laCinta.Id_cinta = int.Parse(row[RecursosDaoModulo5.AliasIdCinta].ToString());
                    laCinta.Color_nombre = row[RecursosDaoModulo5.AliasColorCinta].ToString();
                    laCinta.Rango = row[RecursosDaoModulo5.AliasRangoCinta].ToString();
                    laCinta.Clasificacion = row[RecursosDaoModulo5.AliasClasificacionCint].ToString();
                    laCinta.Significado = row[RecursosDaoModulo5.AliasSignificadoCinta].ToString();
                    laCinta.Orden = int.Parse(row[RecursosDaoModulo5.AliasOrdenCinta].ToString());
                    laCinta.Status = bool.Parse(row[RecursosDaoModulo5.AliasStatusCinta].ToString());
                    laCinta.Organizacion = (DominioSKD.Entidades.Modulo3.Organizacion)FabricaEntidades.ObtenerOrganizacion_M3(int.Parse(row[RecursosDaoModulo5.AliasIdOrganizacion].ToString())
                                                                         , row[RecursosDaoModulo5.AliasNombreOrg].ToString());
                    laListaCintas.Add(laCinta);

                }

            }
            catch (SqlException ex) 
            {
                throw new ExcepcionesSKD.ExceptionSKDConexionBD(RecursoGeneralBD.Codigo,
                    RecursoGeneralBD.Mensaje, ex);
            }
            catch (FormatException ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);

                throw new ExcepcionesSKD.Modulo5.FormatoIncorrectoException(RecursosDaoModulo5.Codigo_Error_Formato,
                    RecursosDaoModulo5.Mensaje_Error_Formato, ex);
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
            finally
            {
                LimpiarSQLConnection();
            }
            Logger.EscribirInfo(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, RecursosDaoModulo5.MensajeFinInfoLogger, System.Reflection.MethodBase.GetCurrentMethod().Name);

            return laListaCintas;
        }
        /// Método Modificar el Status de una Cinta especifica en la Base de Datos 
        /// </summary>
        /// <param name="parametro">Cinta</param>
        /// <returns>True si hace el cambio, False si no</returns>
        public bool ModificarStatus(Entidad parametro)
        {
            Logger.EscribirInfo(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, RecursosDaoModulo5.MensajeInicioInfoLogger, System.Reflection.MethodBase.GetCurrentMethod().Name);

            try
            {
                DominioSKD.Entidades.Modulo5.Cinta laCinta = (DominioSKD.Entidades.Modulo5.Cinta)parametro;

                        List<Parametro> parametros = new List<Parametro>(); 


                        Parametro elParametro = new Parametro(RecursosDaoModulo5.ParamModificarCinta, SqlDbType.Int, laCinta.Id_cinta.ToString(), false);
                        parametros.Add(elParametro);
                        elParametro = new Parametro(RecursosDaoModulo5.ParamNomOrg, SqlDbType.VarChar, laCinta.Organizacion.Nombre, false);
                        parametros.Add(elParametro);

                        

                        string query = RecursosDaoModulo5.ModificarStatusCinta;
                        List<Resultado> resultados = this.EjecutarStoredProcedure(query, parametros);

            } // Fin Try
            catch (SqlException ex) 
            {
                throw new ExcepcionesSKD.ExceptionSKDConexionBD(RecursoGeneralBD.Codigo,
                    RecursoGeneralBD.Mensaje, ex);
            }
            catch (ExcepcionesSKD.ExceptionSKDConexionBD ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);

                throw ex;
            }

            Logger.EscribirInfo(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, RecursosDaoModulo5.MensajeFinInfoLogger, System.Reflection.MethodBase.GetCurrentMethod().Name);

            return true;
        }

        #endregion
    }
}
