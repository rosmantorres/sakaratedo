﻿using System;
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
using DatosSKD.InterfazDAO.Modulo3;

namespace DatosSKD.DAO.Modulo3
{
    public class DaoOrganizacion : DAOGeneral, IDaoOrganizacion
    {
        #region IDAO
        /// <summary>
        /// Método Agrega una Organizacion en la Base de Datos
        /// </summary>
        /// <param name="parametro">Organizacion</param>
        /// <returns>True si lo agrega, False si no</returns>
        public bool Agregar(Entidad parametro)
        {
            Logger.EscribirInfo(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, RecursosDaoModulo3.MensajeInicioInfoLogger, System.Reflection.MethodBase.GetCurrentMethod().Name);

            try
            {
                DominioSKD.Entidades.Modulo3.Organizacion laOrganizacion = (DominioSKD.Entidades.Modulo3.Organizacion)parametro;

                if (!ValidarNombreOrganizacion(laOrganizacion))
                {
                    if (ValidarEstilo(laOrganizacion))
                    {
                List<Parametro> parametros = new List<Parametro>(); 

                Parametro elParametro = new Parametro(RecursosDaoModulo3.ParamNombreOrg, SqlDbType.VarChar, laOrganizacion.Nombre,false);
                parametros.Add(elParametro);
                elParametro = new Parametro(RecursosDaoModulo3.ParamNombreDirOrg, SqlDbType.VarChar, laOrganizacion.Direccion, false);
                parametros.Add(elParametro);
                elParametro = new Parametro(RecursosDaoModulo3.ParamTelOrg, SqlDbType.Int, laOrganizacion.Telefono.ToString(), false);
                parametros.Add(elParametro);
                elParametro = new Parametro(RecursosDaoModulo3.ParamEmailOrg, SqlDbType.VarChar, laOrganizacion.Email, false);
                parametros.Add(elParametro);
                elParametro = new Parametro(RecursosDaoModulo3.ParamEstadoOrg, SqlDbType.VarChar, laOrganizacion.Estado, false);
                parametros.Add(elParametro);
                elParametro = new Parametro(RecursosDaoModulo3.ParamEstiloOrg, SqlDbType.VarChar, laOrganizacion.Estilo, false);
                parametros.Add(elParametro);


                this.EjecutarStoredProcedure(RecursosDaoModulo3.AgregarOrganizacion
                                             , parametros);
                    }// Fin if    
                    else
                    {
                        throw new ExcepcionesSKD.Modulo3.EstiloInexistenteException(RecursosDaoModulo3.Codigo_Estilo_Inexistente,
                                       RecursosDaoModulo3.Mensaje_Estilo_Inexistente, new Exception());
                    }

                }// Fin if    
                else
                {
                    throw new ExcepcionesSKD.Modulo3.OrganizacionExistenteException(RecursosDaoModulo3.Codigo_Organizacion_Existente,
                                   RecursosDaoModulo3.Mensaje_Organizacion_Existente, new Exception());
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

                throw new ExcepcionesSKD.Modulo3.FormatoIncorrectoException(RecursosDaoModulo3.Codigo_Error_Formato,
                    RecursosDaoModulo3.Mensaje_Error_Formato, ex);
            }
            catch (ExcepcionesSKD.ExceptionSKDConexionBD ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);

                throw ex;
            }
            Logger.EscribirInfo(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, RecursosDaoModulo3.MensajeFinInfoLogger, System.Reflection.MethodBase.GetCurrentMethod().Name);

            return true;
        }
        /// <summary>
        /// Método Modificar una Organizacion especifica en la Base de Datos 
        /// </summary>
        /// <param name="parametro">Organizacion</param>
        /// <returns>True si lo agrega, False si no</returns>
        public bool Modificar(Entidad parametro)
        {
            Logger.EscribirInfo(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, RecursosDaoModulo3.MensajeInicioInfoLogger, System.Reflection.MethodBase.GetCurrentMethod().Name);

            try
            {
                DominioSKD.Entidades.Modulo3.Organizacion laOrganizacion = (DominioSKD.Entidades.Modulo3.Organizacion)parametro;

                    if (ValidarEstilo(laOrganizacion))
                    {
                List<Parametro> parametros = new List<Parametro>(); 

                Parametro elParametro = new Parametro(RecursosDaoModulo3.ParamIdOrg, SqlDbType.Int, laOrganizacion.Id_organizacion.ToString(), false);
                parametros.Add(elParametro);
                elParametro = new Parametro(RecursosDaoModulo3.ParamNombreOrg, SqlDbType.VarChar, laOrganizacion.Nombre, false);
                parametros.Add(elParametro);
                elParametro = new Parametro(RecursosDaoModulo3.ParamNombreDirOrg, SqlDbType.VarChar, laOrganizacion.Direccion, false);
                parametros.Add(elParametro);
                elParametro = new Parametro(RecursosDaoModulo3.ParamTelOrg, SqlDbType.Int, laOrganizacion.Telefono.ToString(), false);
                parametros.Add(elParametro);
                elParametro = new Parametro(RecursosDaoModulo3.ParamEmailOrg, SqlDbType.VarChar, laOrganizacion.Email, false);
                parametros.Add(elParametro);
                elParametro = new Parametro(RecursosDaoModulo3.ParamEstadoOrg, SqlDbType.VarChar, laOrganizacion.Estado, false);
                parametros.Add(elParametro);
                elParametro = new Parametro(RecursosDaoModulo3.ParamEstiloOrg, SqlDbType.VarChar, laOrganizacion.Estilo, false);
                parametros.Add(elParametro);


                this.EjecutarStoredProcedure(RecursosDaoModulo3.ModificarOrganizacion
                                             , parametros);
                    
                    }// Fin if    
                     else
                     {
                         throw new ExcepcionesSKD.Modulo3.EstiloInexistenteException(RecursosDaoModulo3.Codigo_Estilo_Inexistente,
                                        RecursosDaoModulo3.Mensaje_Estilo_Inexistente, new Exception());
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

                throw new ExcepcionesSKD.Modulo3.FormatoIncorrectoException(RecursosDaoModulo3.Codigo_Error_Formato,
                    RecursosDaoModulo3.Mensaje_Error_Formato, ex);
            }
            catch (ExcepcionesSKD.ExceptionSKDConexionBD ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);

                throw ex;
            }
            Logger.EscribirInfo(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, RecursosDaoModulo3.MensajeFinInfoLogger, System.Reflection.MethodBase.GetCurrentMethod().Name);

            return true;
        }
        /// <summary>
        /// Método Consultar los Detalles de una Organizacion en especifico
        /// </summary>
        /// <param name="parametro">Id de la Organizacion a consultar</param>
        /// <returns>LaOrganizacion</returns>
        public Entidad ConsultarXId(Entidad parametro)
        {
            Logger.EscribirInfo(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, RecursosDaoModulo3.MensajeInicioInfoLogger, System.Reflection.MethodBase.GetCurrentMethod().Name);

            List<Parametro> parametros;
            Parametro elParametro = new Parametro();

            DominioSKD.Entidades.Modulo3.Organizacion laOrganizacion;

            laOrganizacion = (DominioSKD.Entidades.Modulo3.Organizacion)parametro;

            try
            {
                parametros = new List<Parametro>();

                elParametro = new Parametro(RecursosDaoModulo3.ParamIdEliminarOrg, SqlDbType.Int, laOrganizacion.Id_organizacion.ToString(),
                                            false);
                parametros.Add(elParametro);

                DataTable dt = EjecutarStoredProcedureTuplas(
                               RecursosDaoModulo3.ConsultarOrganizacionXId, parametros);

                foreach (DataRow row in dt.Rows)
                {


                    laOrganizacion.Id_organizacion = int.Parse(row[RecursosDaoModulo3.AliasIdOrg].ToString());
                    laOrganizacion.Nombre = row[RecursosDaoModulo3.AliasNombreOrg].ToString();
                    laOrganizacion.Direccion = row[RecursosDaoModulo3.AliasDireccionOrg].ToString();
                    laOrganizacion.Telefono = int.Parse(row[RecursosDaoModulo3.AliasTelefonoOrg].ToString());
                    laOrganizacion.Email = row[RecursosDaoModulo3.AliasEmailOrg].ToString();
                    laOrganizacion.Estado = row[RecursosDaoModulo3.AliasEstadoOrg].ToString();
                    laOrganizacion.Estilo = row[RecursosDaoModulo3.AliasNombreEstilo].ToString();

                }

                Logger.EscribirInfo(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, RecursosDaoModulo3.MensajeFinInfoLogger, System.Reflection.MethodBase.GetCurrentMethod().Name);

                return laOrganizacion;
            }
            catch (FormatException ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);

                throw new ExcepcionesSKD.Modulo3.FormatoIncorrectoException(RecursosDaoModulo3.Codigo_Error_Formato,
                    RecursosDaoModulo3.Mensaje_Error_Formato, ex);
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
        /// Método Consulta la Lista de Todas las Organizaciones en la Base de Datos
        /// </summary>
        /// <returns>Lista de Organizaciones</returns>
        public List<Entidad> ConsultarTodos()
        {
            Logger.EscribirInfo(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, RecursosDaoModulo3.MensajeInicioInfoLogger, System.Reflection.MethodBase.GetCurrentMethod().Name);

            List<Entidad> laListaOrganizaciones = new List<Entidad>();
            List<Parametro> parametros;

            DominioSKD.Entidades.Modulo3.Organizacion laOrganizacion;

            try
            {

                parametros = new List<Parametro>();


                DataTable dt = EjecutarStoredProcedureTuplas(RecursosDaoModulo3.ConsultarOrganizacion, parametros);

                foreach (DataRow row in dt.Rows)
                {
                    laOrganizacion = (DominioSKD.Entidades.Modulo3.Organizacion)FabricaEntidades.ObtenerOrganizacion_M3();

                    laOrganizacion.Id_organizacion = int.Parse(row[RecursosDaoModulo3.AliasIdOrg].ToString());
                    laOrganizacion.Nombre = row[RecursosDaoModulo3.AliasNombreOrg].ToString();
                    laOrganizacion.Telefono = int.Parse(row[RecursosDaoModulo3.AliasTelefonoOrg].ToString());
                    laOrganizacion.Email = row[RecursosDaoModulo3.AliasEmailOrg].ToString();
                    laOrganizacion.Direccion = row[RecursosDaoModulo3.AliasDireccionOrg].ToString();
                    laOrganizacion.Estado = row[RecursosDaoModulo3.AliasEstadoOrg].ToString();
                    laOrganizacion.Estilo = row[RecursosDaoModulo3.AliasNombreEstilo].ToString();
                    laOrganizacion.Status = bool.Parse(row[RecursosDaoModulo3.AliasStatusOrg].ToString());

                    laListaOrganizaciones.Add(laOrganizacion);

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

                throw new ExcepcionesSKD.Modulo3.FormatoIncorrectoException(RecursosDaoModulo3.Codigo_Error_Formato,
                    RecursosDaoModulo3.Mensaje_Error_Formato, ex);
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
            Logger.EscribirInfo(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, RecursosDaoModulo3.MensajeFinInfoLogger, System.Reflection.MethodBase.GetCurrentMethod().Name);

            return laListaOrganizaciones;
        }        
        
        #endregion

        #region IDaoOrganizacion
        /// <summary>
        /// Método que Consulta la lista de Organizaciones
        /// </summary>
        /// <returns>Lista de Entidades que son una Lista de De Organizaciones</returns>
        public List<Entidad> ComboOrganizaciones()
        {
            Logger.EscribirInfo(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, RecursosDaoModulo3.MensajeInicioInfoLogger, System.Reflection.MethodBase.GetCurrentMethod().Name);

            List<Parametro> parametros;

            List<Entidad> laListaOrganizaciones = new List<Entidad>();
            DominioSKD.Entidades.Modulo3.Organizacion laOrganizacion;
            try
            {

                parametros = new List<Parametro>();


                DataTable dt = EjecutarStoredProcedureTuplas(RecursosDaoModulo3.ConsultarComboORG, parametros);

                foreach (DataRow row in dt.Rows)
                {
                     
                    laOrganizacion = (DominioSKD.Entidades.Modulo3.Organizacion)FabricaEntidades.ObtenerOrganizacion_M3();

                    laOrganizacion.Id_organizacion = int.Parse(row[RecursosDaoModulo3.AliasIdOrg].ToString());
                    laOrganizacion.Nombre = row[RecursosDaoModulo3.AliasNombreOrg].ToString();

                    laListaOrganizaciones.Add(laOrganizacion);
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

                throw new ExcepcionesSKD.Modulo3.FormatoIncorrectoException(RecursosDaoModulo3.Codigo_Error_Formato,
                    RecursosDaoModulo3.Mensaje_Error_Formato, ex);
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
            Logger.EscribirInfo(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, RecursosDaoModulo3.MensajeFinInfoLogger, System.Reflection.MethodBase.GetCurrentMethod().Name);

            return laListaOrganizaciones;
        }
        /// <summary>
        /// Método que busca si existe el nombre de la Organizacion 
        /// </summary>
        /// <param name="parametro">la Organizacion a consultar</param>
        /// <returns>True si Existe, False si no</returns>
        public bool ValidarNombreOrganizacion(Entidad parametro)
        {
            Logger.EscribirInfo(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, RecursosDaoModulo3.MensajeInicioInfoLogger, System.Reflection.MethodBase.GetCurrentMethod().Name);

            bool retorno = false;
            List<Parametro> parametros;

            try
            {
                DominioSKD.Entidades.Modulo3.Organizacion laOrganizacion = (DominioSKD.Entidades.Modulo3.Organizacion)parametro;

                parametros = new List<Parametro>();

                Parametro elParametro = new Parametro(RecursosDaoModulo3.ParamNombreOrg, SqlDbType.VarChar
                                                      , laOrganizacion.Nombre, false);
                parametros.Add(elParametro);

                elParametro = new Parametro(RecursosDaoModulo3.ParamSalidaNumOrganizacion, SqlDbType.Int, true);
                parametros.Add(elParametro);

                List<Resultado> resultados = EjecutarStoredProcedure(RecursosDaoModulo3.BuscarNombreOrganizacion
                                             , parametros);

                foreach (Resultado elResultado in resultados)
                {
                    if (elResultado.etiqueta == RecursosDaoModulo3.ParamSalidaNumOrganizacion)
                        if (int.Parse(elResultado.valor) == 1) 
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
                throw new ExcepcionesSKD.Modulo3.FormatoIncorrectoException(RecursosDaoModulo3.Codigo_Error_Formato,
                     RecursosDaoModulo3.Mensaje_Error_Formato, ex);
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
            Logger.EscribirInfo(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, RecursosDaoModulo3.MensajeFinInfoLogger, System.Reflection.MethodBase.GetCurrentMethod().Name);

            return retorno;


        }
        /// <summary>
        /// Método que busca si existe el Estilo de la Organizacion 
        /// </summary>
        /// <param name="parametro">la Organizacion a consultar</param>
        /// <returns>True si Existe, False si no</returns>
        public bool ValidarEstilo(Entidad parametro)
        {
            Logger.EscribirInfo(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, RecursosDaoModulo3.MensajeInicioInfoLogger, System.Reflection.MethodBase.GetCurrentMethod().Name);

            bool retorno = false;
            List<Parametro> parametros;

            try
            {
                DominioSKD.Entidades.Modulo3.Organizacion laOrganizacion = (DominioSKD.Entidades.Modulo3.Organizacion)parametro;

                parametros = new List<Parametro>();

                Parametro elParametro = new Parametro(RecursosDaoModulo3.ParamEstiloOrg, SqlDbType.VarChar
                                                      , laOrganizacion.Estilo, false);
                parametros.Add(elParametro);

                elParametro = new Parametro(RecursosDaoModulo3.ParamSalidaNumEstilo, SqlDbType.Int, true);
                parametros.Add(elParametro);

                List<Resultado> resultados = EjecutarStoredProcedure(RecursosDaoModulo3.BuscarEstilo
                                             , parametros);

                foreach (Resultado elResultado in resultados)
                {
                    if (elResultado.etiqueta == RecursosDaoModulo3.ParamSalidaNumEstilo)
                        if (int.Parse(elResultado.valor) == 1)
                            retorno = true;
                        else
                        {
                            Logger.EscribirWarning(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, RecursosDaoModulo3.Mensaje_Estilo_Inexistente, System.Reflection.MethodBase.GetCurrentMethod().Name);

                            throw new ExcepcionesSKD.Modulo3.EstiloInexistenteException(RecursosDaoModulo3.Codigo_Estilo_Inexistente,
                                RecursosDaoModulo3.Mensaje_Estilo_Inexistente, new Exception());
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
                throw new ExcepcionesSKD.Modulo3.FormatoIncorrectoException(RecursosDaoModulo3.Codigo_Error_Formato,
                     RecursosDaoModulo3.Mensaje_Error_Formato, ex);
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
            Logger.EscribirInfo(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, RecursosDaoModulo3.MensajeFinInfoLogger, System.Reflection.MethodBase.GetCurrentMethod().Name);

            return retorno;


        }

        /// <summary>
        /// Método Modificar el status de una Organizacion especifica en la Base de Datos 
        /// </summary>
        /// <param name="parametro">Organizacion</param>
        /// <returns>True si lo modifica, False si no</returns>
        public bool ModificarStatus(Entidad parametro)
        {
            Logger.EscribirInfo(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, RecursosDaoModulo3.MensajeInicioInfoLogger, System.Reflection.MethodBase.GetCurrentMethod().Name);

            try
            {
                DominioSKD.Entidades.Modulo3.Organizacion laOrganizacion = (DominioSKD.Entidades.Modulo3.Organizacion)parametro;


                    List<Parametro> parametros = new List<Parametro>(); 

                    Parametro elParametro = new Parametro(RecursosDaoModulo3.ParamIdOrg, SqlDbType.Int, laOrganizacion.Id_organizacion.ToString(), false);
                    parametros.Add(elParametro);

                    this.EjecutarStoredProcedure(RecursosDaoModulo3.ModificarStatusOrganizacion
                                                 , parametros);

                    Logger.EscribirInfo(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, RecursosDaoModulo3.MensajeFinInfoLogger, System.Reflection.MethodBase.GetCurrentMethod().Name);

                    return true;
            }
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
           
        }
        #endregion
    }





    }

