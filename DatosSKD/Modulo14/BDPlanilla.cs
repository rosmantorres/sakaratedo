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
using ExcepcionesSKD.Modulo14;
using System.Globalization;
using System.IO;

namespace DatosSKD.Modulo14
{
    public class BDPlanilla
    {
        #region atributos

        private BDConexion con = new BDConexion();

        #endregion


        #region metodos
        /// <summary>
        /// Método que consulta todas las planillas creadas
        /// </summary>
        /// <returns>Lista de planillas creadas</returns>
        public List<DominioSKD.Planilla> ConsultarPlanillasCreadas()
        {
            Logger.EscribirInfo(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name,
                RecursosBDModulo14.MsjDeEntrada, System.Reflection.MethodBase.GetCurrentMethod().Name);
            SqlConnection conect = con.Conectar();
            List<DominioSKD.Planilla> lista = new List<DominioSKD.Planilla>();
            DominioSKD.Planilla planilla;

                try
                {

                    SqlCommand sqlcom = new SqlCommand(RecursosBDModulo14.ProcedureConsultarPlanillasCreadas, conect);
                    sqlcom.CommandType = CommandType.StoredProcedure;

                    SqlDataReader leer;
                    conect.Open();

                    leer = sqlcom.ExecuteReader();
                    if (leer != null)
                    {
                        while (leer.Read())
                        {
                            planilla = new DominioSKD.Planilla();
                            planilla.ID = Convert.ToInt32(leer[RecursosBDModulo14.AtributoIdPlanilla]);
                            planilla.Nombre = leer[RecursosBDModulo14.AtributoNombrePlanilla].ToString();
                            planilla.Status = Convert.ToBoolean(leer[RecursosBDModulo14.AtributoStatusPlanilla]);
                            planilla.TipoPlanilla= leer[RecursosBDModulo14.AtributoNombreTipoPlanilla].ToString();
                            lista.Add(planilla);
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
                    BDPLanillaException excep = new BDPLanillaException(RecursoGeneralBD.Codigo,
                        RecursoGeneralBD.Mensaje, ex);
                    Logger.EscribirError(RecursosBDModulo14.ClaseBDPlanilla, excep);
                    throw excep;
                }
                catch (IOException ex)
                {
                    BDPLanillaException excep = new BDPLanillaException(RecursosBDModulo14.CodigoIoException,
                        RecursosBDModulo14.MsjExceptionIO, ex);
                    Logger.EscribirError(RecursosBDModulo14.ClaseBDPlanilla, excep);
                    throw excep;
                }
                catch (NullReferenceException ex)
                {
                    BDPLanillaException excep = new BDPLanillaException(RecursosBDModulo14.CodigoNullReferencesExcep,
                        RecursosBDModulo14.MsjNullException, ex);
                    Logger.EscribirError(RecursosBDModulo14.ClaseBDPlanilla, excep);
                    throw excep;
                }
                catch (ObjectDisposedException ex)
                {
                    BDPLanillaException excep = new BDPLanillaException(RecursosBDModulo14.CodigoDisposedObject,
                        RecursosBDModulo14.MensajeDisposedException, ex);
                    Logger.EscribirError(RecursosBDModulo14.ClaseBDPlanilla, excep);
                    throw excep;
                }
                catch (ExcepcionesSKD.ExceptionSKDConexionBD ex)
                {
                    Logger.EscribirError(RecursosBDModulo14.ClaseBDPlanilla, ex);

                    throw ex;
                }
                catch (FormatException ex)
                {
                    BDPLanillaException excep = new BDPLanillaException(RecursosBDModulo14.CodigoFormatExceptio,
                        RecursosBDModulo14.MsjFormatException, ex);
                    Logger.EscribirError(RecursosBDModulo14.ClaseBDPlanilla, excep);
                    throw excep;
                }
                catch (Exception ex)
                {
                    BDPLanillaException excep = new BDPLanillaException(RecursosBDModulo14.CodigoException,
                        RecursosBDModulo14.MsjException, ex);
                    Logger.EscribirError(RecursosBDModulo14.ClaseBDPlanilla, excep);
                    throw excep;
                }
                finally
                {
                    con.Desconectar(conect);
                }

        }

        /// <summary>
        /// Método cambia el status de una planilla
        /// </summary>
        /// <param name="idPlanilla">id de la planilla a cambiar</param>
        public Boolean CambiarStatus(int idPlanilla)
        {
            Logger.EscribirInfo(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name,
                RecursosBDModulo14.MsjDeEntrada, System.Reflection.MethodBase.GetCurrentMethod().Name);
            SqlConnection conect = con.Conectar();
                try
                {

                    SqlCommand sqlcom = new SqlCommand(RecursosBDModulo14.ProcedureCambiarStatusPlanilla, conect);
                    sqlcom.CommandType = CommandType.StoredProcedure;
                    sqlcom.Parameters.Add(new SqlParameter(RecursosBDModulo14.ParametroIdPlanilla,
                                SqlDbType.Int));
                    sqlcom.Parameters[RecursosBDModulo14.ParametroIdPlanilla].Value = idPlanilla;
                    SqlDataReader leer;
                    conect.Open();

                    leer = sqlcom.ExecuteReader();
                    return true;
                }
                catch (SqlException ex)
                {
                    BDPLanillaException excep = new BDPLanillaException(RecursoGeneralBD.Codigo,
                        RecursoGeneralBD.Mensaje, ex);
                    Logger.EscribirError(RecursosBDModulo14.ClaseBDPlanilla, excep);
                    throw excep;
                }
                catch (IOException ex)
                {
                    BDPLanillaException excep = new BDPLanillaException(RecursosBDModulo14.CodigoIoException,
                        RecursosBDModulo14.MsjExceptionIO, ex);
                    Logger.EscribirError(RecursosBDModulo14.ClaseBDPlanilla, excep);
                    throw excep;
                }
                catch (NullReferenceException ex)
                {
                    BDPLanillaException excep = new BDPLanillaException(RecursosBDModulo14.CodigoNullReferencesExcep,
                        RecursosBDModulo14.MsjNullException, ex);
                    Logger.EscribirError(RecursosBDModulo14.ClaseBDPlanilla, excep);
                    throw excep;
                }
                catch (ObjectDisposedException ex)
                {
                    BDPLanillaException excep = new BDPLanillaException(RecursosBDModulo14.CodigoDisposedObject,
                        RecursosBDModulo14.MensajeDisposedException, ex);
                    Logger.EscribirError(RecursosBDModulo14.ClaseBDPlanilla, excep);
                    throw excep;
                }
                catch (ExcepcionesSKD.ExceptionSKDConexionBD ex)
                {
                    Logger.EscribirError(RecursosBDModulo14.ClaseBDPlanilla, ex);

                    throw ex;
                }
                catch (FormatException ex)
                {
                    BDPLanillaException excep = new BDPLanillaException(RecursosBDModulo14.CodigoFormatExceptio,
                        RecursosBDModulo14.MsjFormatException, ex);
                    Logger.EscribirError(RecursosBDModulo14.ClaseBDPlanilla, excep);
                    throw excep;
                }
                catch (Exception ex)
                {
                    BDPLanillaException excep = new BDPLanillaException(RecursosBDModulo14.CodigoException,
                        RecursosBDModulo14.MsjException, ex);
                    Logger.EscribirError(RecursosBDModulo14.ClaseBDPlanilla, excep);
                    throw excep;
                }
                finally
                {
                    con.Desconectar(conect);
                }

        }
        /// <summary>
        /// Obtiene la lista de los tipo de planillas
        /// </summary>
        /// <returns>Lista de los tipos de planillas</returns>
        public  List<Planilla> ObtenerTipoPlanilla()
        {
            Logger.EscribirInfo(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name,
                RecursosBDModulo14.MsjDeEntrada, System.Reflection.MethodBase.GetCurrentMethod().Name);
            BDConexion laConexion;
            List<Planilla> listaTipoPlanilla = new List<Planilla>();
            List<Parametro> parametros;

            try
            {
                laConexion = new BDConexion();
                parametros = new List<Parametro>();
                DataTable resultadoConsulta = laConexion.EjecutarStoredProcedureTuplas(RecursosBDModulo14.ProcedureListaTipoPlanilla, parametros);

                foreach (DataRow row in resultadoConsulta.Rows)
                {
                    listaTipoPlanilla.Add(new Planilla(Int32.Parse(row[RecursosBDModulo14.AtributoIdTipoPlanilla].ToString()), row[RecursosBDModulo14.AtributoNombreTipoPlanilla].ToString()));
                }

            }
            catch (SqlException ex)
            {
                BDPLanillaException excep = new BDPLanillaException(RecursoGeneralBD.Codigo,
                    RecursoGeneralBD.Mensaje, ex);
                Logger.EscribirError(RecursosBDModulo14.ClaseBDPlanilla, excep);
                throw excep;
            }
            catch (IOException ex)
            {
                BDPLanillaException excep = new BDPLanillaException(RecursosBDModulo14.CodigoIoException,
                    RecursosBDModulo14.MsjExceptionIO, ex);
                Logger.EscribirError(RecursosBDModulo14.ClaseBDPlanilla, excep);
                throw excep;
            }
            catch (NullReferenceException ex)
            {
                BDPLanillaException excep = new BDPLanillaException(RecursosBDModulo14.CodigoNullReferencesExcep,
                    RecursosBDModulo14.MsjNullException, ex);
                Logger.EscribirError(RecursosBDModulo14.ClaseBDPlanilla, excep);
                throw excep;
            }
            catch (ObjectDisposedException ex)
            {
                BDPLanillaException excep = new BDPLanillaException(RecursosBDModulo14.CodigoDisposedObject,
                    RecursosBDModulo14.MensajeDisposedException, ex);
                Logger.EscribirError(RecursosBDModulo14.ClaseBDPlanilla, excep);
                throw excep;
            }
            catch (ExcepcionesSKD.ExceptionSKDConexionBD ex)
            {
                Logger.EscribirError(RecursosBDModulo14.ClaseBDPlanilla, ex);

                throw ex;
            }
            catch (FormatException ex)
            {
                BDPLanillaException excep = new BDPLanillaException(RecursosBDModulo14.CodigoFormatExceptio,
                    RecursosBDModulo14.MsjFormatException, ex);
                Logger.EscribirError(RecursosBDModulo14.ClaseBDPlanilla, excep);
                throw excep;
            }
            catch (Exception ex)
            {
                BDPLanillaException excep = new BDPLanillaException(RecursosBDModulo14.CodigoException,
                    RecursosBDModulo14.MsjException, ex);
                Logger.EscribirError(RecursosBDModulo14.ClaseBDPlanilla, excep);
                throw excep;
            }

            return listaTipoPlanilla;
        }

        /// <summary>
        /// Obtiene la lista de los datos
        /// </summary>
        /// <returns>Lista de los datos que se encuentran</returns>
        public  List<String> ObtenerDatosBD()
        {
            Logger.EscribirInfo(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name,
                RecursosBDModulo14.MsjDeEntrada, System.Reflection.MethodBase.GetCurrentMethod().Name);
            BDConexion laConexion;
            List<String> listaDatos = new List<String>();
            List<Parametro> parametros;
            //List<Resultado> resultadoConsulta;

            try
            {
                laConexion = new BDConexion();
                parametros = new List<Parametro>();
                DataTable resultadoConsulta = laConexion.EjecutarStoredProcedureTuplas(RecursosBDModulo14.ProcedureConsultarListaDatos, parametros);

                foreach (DataRow row in resultadoConsulta.Rows)
                {
                    listaDatos.Add(row[RecursosBDModulo14.AtributoNombre_Dato].ToString());
                }

            }
            catch (SqlException ex)
            {
                BDPLanillaException excep = new BDPLanillaException(RecursoGeneralBD.Codigo,
                    RecursoGeneralBD.Mensaje, ex);
                Logger.EscribirError(RecursosBDModulo14.ClaseBDPlanilla, excep);
                throw excep;
            }
            catch (IOException ex)
            {
                BDPLanillaException excep = new BDPLanillaException(RecursosBDModulo14.CodigoIoException,
                    RecursosBDModulo14.MsjExceptionIO, ex);
                Logger.EscribirError(RecursosBDModulo14.ClaseBDPlanilla, excep);
                throw excep;
            }
            catch (NullReferenceException ex)
            {
                BDPLanillaException excep = new BDPLanillaException(RecursosBDModulo14.CodigoNullReferencesExcep,
                    RecursosBDModulo14.MsjNullException, ex);
                Logger.EscribirError(RecursosBDModulo14.ClaseBDPlanilla, excep);
                throw excep;
            }
            catch (ObjectDisposedException ex)
            {
                BDPLanillaException excep = new BDPLanillaException(RecursosBDModulo14.CodigoDisposedObject,
                    RecursosBDModulo14.MensajeDisposedException, ex);
                Logger.EscribirError(RecursosBDModulo14.ClaseBDPlanilla, excep);
                throw excep;
            }
            catch (ExcepcionesSKD.ExceptionSKDConexionBD ex)
            {
                Logger.EscribirError(RecursosBDModulo14.ClaseBDPlanilla, ex);

                throw ex;
            }
            catch (FormatException ex)
            {
                BDPLanillaException excep = new BDPLanillaException(RecursosBDModulo14.CodigoFormatExceptio,
                    RecursosBDModulo14.MsjFormatException, ex);
                Logger.EscribirError(RecursosBDModulo14.ClaseBDPlanilla, excep);
                throw excep;
            }
            catch (Exception ex)
            {
                BDPLanillaException excep = new BDPLanillaException(RecursosBDModulo14.CodigoException,
                    RecursosBDModulo14.MsjException, ex);
                Logger.EscribirError(RecursosBDModulo14.ClaseBDPlanilla, excep);
                throw excep;
            }

            return listaDatos;
        }


        /// <summary>
        /// Registra una planilla en la base de datos
        /// </summary>
        /// <param name="laPlanilla">La planilla</param>
        /// <returns>returna true en caso de que se completara el registro, y false en caso de que no</returns>
        public Boolean RegistrarPlanillaBD(Planilla laPlanilla)
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
                parametro = new Parametro(RecursosBDModulo14.ParametroNombrePlanilla,
                SqlDbType.VarChar, laPlanilla.Nombre, false);
                parametros.Add(parametro);

                parametro = new Parametro(RecursosBDModulo14.ParametroSatusPlanilla,
                SqlDbType.VarChar, laPlanilla.Status.ToString(), false);
                parametros.Add(parametro);

                parametro = new Parametro(RecursosBDModulo14.ParametroTipoPlanillaFK,
                SqlDbType.VarChar, laPlanilla.IDtipoPlanilla.ToString(), false);
                parametros.Add(parametro);
                string query = RecursosBDModulo14.ProcedureAgregarPlanilla;
                List<Resultado> resultados = laConexion.EjecutarStoredProcedure(query, parametros);

            }
            catch (SqlException ex)
            {
                BDPLanillaException excep = new BDPLanillaException(RecursoGeneralBD.Codigo,
                    RecursoGeneralBD.Mensaje, ex);
                Logger.EscribirError(RecursosBDModulo14.ClaseBDPlanilla, excep);
                throw excep;
            }
            catch (IOException ex)
            {
                BDPLanillaException excep = new BDPLanillaException(RecursosBDModulo14.CodigoIoException,
                    RecursosBDModulo14.MsjExceptionIO, ex);
                Logger.EscribirError(RecursosBDModulo14.ClaseBDPlanilla, excep);
                throw excep;
            }
            catch (NullReferenceException ex)
            {
                BDPLanillaException excep = new BDPLanillaException(RecursosBDModulo14.CodigoNullReferencesExcep,
                    RecursosBDModulo14.MsjNullException, ex);
                Logger.EscribirError(RecursosBDModulo14.ClaseBDPlanilla, excep);
                throw excep;
            }
            catch (ObjectDisposedException ex)
            {
                BDPLanillaException excep = new BDPLanillaException(RecursosBDModulo14.CodigoDisposedObject,
                    RecursosBDModulo14.MensajeDisposedException, ex);
                Logger.EscribirError(RecursosBDModulo14.ClaseBDPlanilla, excep);
                throw excep;
            }
            catch (ExcepcionesSKD.ExceptionSKDConexionBD ex)
            {
                Logger.EscribirError(RecursosBDModulo14.ClaseBDPlanilla, ex);

                throw ex;
            }
            catch (FormatException ex)
            {
                BDPLanillaException excep = new BDPLanillaException(RecursosBDModulo14.CodigoFormatExceptio,
                    RecursosBDModulo14.MsjFormatException, ex);
                Logger.EscribirError(RecursosBDModulo14.ClaseBDPlanilla, excep);
                throw excep;
            }
            catch (Exception ex)
            {
                BDPLanillaException excep = new BDPLanillaException(RecursosBDModulo14.CodigoException,
                    RecursosBDModulo14.MsjException, ex);
                Logger.EscribirError(RecursosBDModulo14.ClaseBDPlanilla, excep);
                throw excep;
            }
            return true;
        }

        /// <summary>
        /// Registra los datos de una planilla en la BD
        /// </summary>
        /// <param name="">La planilla</param>
        /// <returns>returna true en caso de que se completara el registro, y false en caso de que no</returns>
        public  Boolean RegistrarDatosPlanillaBD(String nombrePlanilla, String datoPlanilla)
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

                parametro = new Parametro(RecursosBDModulo14.ParametroNombrePlanilla,
                          SqlDbType.VarChar, nombrePlanilla, false);
                parametros.Add(parametro);
                parametro = new Parametro(RecursosBDModulo14.ParametroNombreDato,
                                          SqlDbType.VarChar, datoPlanilla, false);
                parametros.Add(parametro);

                string query = RecursosBDModulo14.ProcedureAgregarDatoPlanilla;
                List<Resultado> resultados = laConexion.EjecutarStoredProcedure(query, parametros);
            }
            catch (SqlException ex)
            {
                BDPLanillaException excep = new BDPLanillaException(RecursoGeneralBD.Codigo,
                    RecursoGeneralBD.Mensaje, ex);
                Logger.EscribirError(RecursosBDModulo14.ClaseBDPlanilla, excep);
                throw excep;
            }
            catch (IOException ex)
            {
                BDPLanillaException excep = new BDPLanillaException(RecursosBDModulo14.CodigoIoException,
                    RecursosBDModulo14.MsjExceptionIO, ex);
                Logger.EscribirError(RecursosBDModulo14.ClaseBDPlanilla, excep);
                throw excep;
            }
            catch (NullReferenceException ex)
            {
                BDPLanillaException excep = new BDPLanillaException(RecursosBDModulo14.CodigoNullReferencesExcep,
                    RecursosBDModulo14.MsjNullException, ex);
                Logger.EscribirError(RecursosBDModulo14.ClaseBDPlanilla, excep);
                throw excep;
            }
            catch (ObjectDisposedException ex)
            {
                BDPLanillaException excep = new BDPLanillaException(RecursosBDModulo14.CodigoDisposedObject,
                    RecursosBDModulo14.MensajeDisposedException, ex);
                Logger.EscribirError(RecursosBDModulo14.ClaseBDPlanilla, excep);
                throw excep;
            }
            catch (ExcepcionesSKD.ExceptionSKDConexionBD ex)
            {
                Logger.EscribirError(RecursosBDModulo14.ClaseBDPlanilla, ex);

                throw ex;
            }
            catch (FormatException ex)
            {
                BDPLanillaException excep = new BDPLanillaException(RecursosBDModulo14.CodigoFormatExceptio,
                    RecursosBDModulo14.MsjFormatException, ex);
                Logger.EscribirError(RecursosBDModulo14.ClaseBDPlanilla, excep);
                throw excep;
            }
            catch (Exception ex)
            {
                BDPLanillaException excep = new BDPLanillaException(RecursosBDModulo14.CodigoException,
                    RecursosBDModulo14.MsjException, ex);
                Logger.EscribirError(RecursosBDModulo14.ClaseBDPlanilla, excep);
                throw excep;
            }
            return true;
        }

        /// <summary>
        /// Registra el Tipo de una planilla en la BD
        /// </summary>
        /// <param name="nombreTipoPlanilla">La planilla</param>
        /// <returns>returna true en caso de que se completara el registro, y false en caso de que no</returns>
        public Boolean RegistrarTipoPlanilla(String nombreTipoPlanilla)
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

                parametro = new Parametro(RecursosBDModulo14.ParametroTipoPlanilla,
                          SqlDbType.VarChar, nombreTipoPlanilla, false);
                parametros.Add(parametro);


                string query = RecursosBDModulo14.ProcedimientoAgregarTipoPlanilla;
                List<Resultado> resultados = laConexion.EjecutarStoredProcedure(query, parametros);


            }
            catch (SqlException ex)
            {
                BDPLanillaException excep = new BDPLanillaException(RecursoGeneralBD.Codigo,
                    RecursoGeneralBD.Mensaje, ex);
                Logger.EscribirError(RecursosBDModulo14.ClaseBDPlanilla, excep);
                throw excep;
            }
            catch (IOException ex)
            {
                BDPLanillaException excep = new BDPLanillaException(RecursosBDModulo14.CodigoIoException,
                    RecursosBDModulo14.MsjExceptionIO, ex);
                Logger.EscribirError(RecursosBDModulo14.ClaseBDPlanilla, excep);
                throw excep;
            }
            catch (NullReferenceException ex)
            {
                BDPLanillaException excep = new BDPLanillaException(RecursosBDModulo14.CodigoNullReferencesExcep,
                    RecursosBDModulo14.MsjNullException, ex);
                Logger.EscribirError(RecursosBDModulo14.ClaseBDPlanilla, excep);
                throw excep;
            }
            catch (ObjectDisposedException ex)
            {
                BDPLanillaException excep = new BDPLanillaException(RecursosBDModulo14.CodigoDisposedObject,
                    RecursosBDModulo14.MensajeDisposedException, ex);
                Logger.EscribirError(RecursosBDModulo14.ClaseBDPlanilla, excep);
                throw excep;
            }
            catch (ExcepcionesSKD.ExceptionSKDConexionBD ex)
            {
                Logger.EscribirError(RecursosBDModulo14.ClaseBDPlanilla, ex);

                throw ex;
            }
            catch (FormatException ex)
            {
                BDPLanillaException excep = new BDPLanillaException(RecursosBDModulo14.CodigoFormatExceptio,
                    RecursosBDModulo14.MsjFormatException, ex);
                Logger.EscribirError(RecursosBDModulo14.ClaseBDPlanilla, excep);
                throw excep;
            }
            catch (Exception ex)
            {
                BDPLanillaException excep = new BDPLanillaException(RecursosBDModulo14.CodigoException,
                    RecursosBDModulo14.MsjException, ex);
                Logger.EscribirError(RecursosBDModulo14.ClaseBDPlanilla, excep);
                throw excep;
            }
            return true;
        }

        /// <summary>
        /// Obtiene la lista de los tipo de planillas
        /// </summary>
        /// <returns>Lista de los tipos de planillas</returns>
        public int ObtenerIdTipoPlanilla(String nombreTipo)
        {
            Logger.EscribirInfo(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name,
                RecursosBDModulo14.MsjDeEntrada, System.Reflection.MethodBase.GetCurrentMethod().Name);
            BDConexion laConexion;
            int idTipolanilla;
            List<Parametro> parametros;
            Parametro parametro = new Parametro();

            try
            {
                laConexion = new BDConexion();
                parametros = new List<Parametro>();
                parametro = new Parametro(RecursosBDModulo14.ParametroTipoPlanilla,
                        SqlDbType.VarChar, nombreTipo, false);
                parametros.Add(parametro);

                parametro = new Parametro(RecursosBDModulo14.ParametroIdTipoPlanilla,
                      SqlDbType.VarChar, true);
                parametros.Add(parametro);

                string query = RecursosBDModulo14.ProcedimientoObtenerIdTipoPlanilla;
                List<Resultado> resultados = laConexion.EjecutarStoredProcedure(query, parametros);
                if (resultados[0].valor == "")
                    idTipolanilla = -1;
                else
                    idTipolanilla = Int32.Parse(resultados[0].valor.ToString());

            }
            catch (SqlException ex)
            {
                BDPLanillaException excep = new BDPLanillaException(RecursoGeneralBD.Codigo,
                    RecursoGeneralBD.Mensaje, ex);
                Logger.EscribirError(RecursosBDModulo14.ClaseBDPlanilla, excep);
                throw excep;
            }
            catch (IOException ex)
            {
                BDPLanillaException excep = new BDPLanillaException(RecursosBDModulo14.CodigoIoException,
                    RecursosBDModulo14.MsjExceptionIO, ex);
                Logger.EscribirError(RecursosBDModulo14.ClaseBDPlanilla, excep);
                throw excep;
            }
            catch (NullReferenceException ex)
            {
                BDPLanillaException excep = new BDPLanillaException(RecursosBDModulo14.CodigoNullReferencesExcep,
                    RecursosBDModulo14.MsjNullException, ex);
                Logger.EscribirError(RecursosBDModulo14.ClaseBDPlanilla, excep);
                throw excep;
            }
            catch (ObjectDisposedException ex)
            {
                BDPLanillaException excep = new BDPLanillaException(RecursosBDModulo14.CodigoDisposedObject,
                    RecursosBDModulo14.MensajeDisposedException, ex);
                Logger.EscribirError(RecursosBDModulo14.ClaseBDPlanilla, excep);
                throw excep;
            }
            catch (ExcepcionesSKD.ExceptionSKDConexionBD ex)
            {
                Logger.EscribirError(RecursosBDModulo14.ClaseBDPlanilla, ex);

                throw ex;
            }
            catch (FormatException ex)
            {
                BDPLanillaException excep = new BDPLanillaException(RecursosBDModulo14.CodigoFormatExceptio,
                    RecursosBDModulo14.MsjFormatException, ex);
                Logger.EscribirError(RecursosBDModulo14.ClaseBDPlanilla, excep);
                throw excep;
            }
            catch (Exception ex)
            {
                BDPLanillaException excep = new BDPLanillaException(RecursosBDModulo14.CodigoException,
                    RecursosBDModulo14.MsjException, ex);
                Logger.EscribirError(RecursosBDModulo14.ClaseBDPlanilla, excep);
                throw excep;
            }

            return idTipolanilla;
        }

        /// <summary>
        /// Obtiene una planilla por el ID
        /// </summary>
        /// /// <param name="idPlanilla">id planilla</param>
        /// <returns>Planilla con nombre, status y tipo de planilla</returns>
        public Planilla ObtenerPlanillaID(int idPlanilla)
        {
            Logger.EscribirInfo(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name,
                RecursosBDModulo14.MsjDeEntrada, System.Reflection.MethodBase.GetCurrentMethod().Name);
            BDConexion laConexion;
            Planilla planilla = null;
            List<Parametro> parametros;
            Parametro parametro = new Parametro();

            try
            {
                laConexion = new BDConexion();
                parametros = new List<Parametro>();
                parametro = new Parametro(RecursosBDModulo14.ParametroIdPlanilla,
                SqlDbType.VarChar, idPlanilla.ToString(), false);
                parametros.Add(parametro);

                DataTable resultadoConsulta = laConexion.EjecutarStoredProcedureTuplas(RecursosBDModulo14.ProcedureConsultatPlanillaID, parametros);

                foreach (DataRow row in resultadoConsulta.Rows)
                {
                    String tipoPlanilla = row[RecursosBDModulo14.AtributoNombreTipoPlanilla].ToString();
                    String nombrePlanilla = row[RecursosBDModulo14.AtributoNombrePlanilla].ToString();
                    bool statusPlanilla = (bool)row[RecursosBDModulo14.AtributoStatusPlanilla];
                    planilla = new Planilla(nombrePlanilla,statusPlanilla ,tipoPlanilla);
                }

            }
            catch (SqlException ex)
            {
                BDPLanillaException excep = new BDPLanillaException(RecursoGeneralBD.Codigo,
                    RecursoGeneralBD.Mensaje, ex);
                Logger.EscribirError(RecursosBDModulo14.ClaseBDPlanilla, excep);
                throw excep;
            }
            catch (IOException ex)
            {
                BDPLanillaException excep = new BDPLanillaException(RecursosBDModulo14.CodigoIoException,
                    RecursosBDModulo14.MsjExceptionIO, ex);
                Logger.EscribirError(RecursosBDModulo14.ClaseBDPlanilla, excep);
                throw excep;
            }
            catch (NullReferenceException ex)
            {
                BDPLanillaException excep = new BDPLanillaException(RecursosBDModulo14.CodigoNullReferencesExcep,
                    RecursosBDModulo14.MsjNullException, ex);
                Logger.EscribirError(RecursosBDModulo14.ClaseBDPlanilla, excep);
                throw excep;
            }
            catch (ObjectDisposedException ex)
            {
                BDPLanillaException excep = new BDPLanillaException(RecursosBDModulo14.CodigoDisposedObject,
                    RecursosBDModulo14.MensajeDisposedException, ex);
                Logger.EscribirError(RecursosBDModulo14.ClaseBDPlanilla, excep);
                throw excep;
            }
            catch (ExcepcionesSKD.ExceptionSKDConexionBD ex)
            {
                Logger.EscribirError(RecursosBDModulo14.ClaseBDPlanilla, ex);

                throw ex;
            }
            catch (FormatException ex)
            {
                BDPLanillaException excep = new BDPLanillaException(RecursosBDModulo14.CodigoFormatExceptio,
                    RecursosBDModulo14.MsjFormatException, ex);
                Logger.EscribirError(RecursosBDModulo14.ClaseBDPlanilla, excep);
                throw excep;
            }
            catch (Exception ex)
            {
                BDPLanillaException excep = new BDPLanillaException(RecursosBDModulo14.CodigoException,
                    RecursosBDModulo14.MsjException, ex);
                Logger.EscribirError(RecursosBDModulo14.ClaseBDPlanilla, excep);
                throw excep;
            }

            return planilla;
        }

        /// <summary>
        /// Obtiene los datos de una planilla id
        /// </summary>
        /// /// <param name="idPlanilla">id planilla</param>
        /// <returns>datos de una planilla</returns>
        public List<String> ObtenerDatosPlanillaID(int idPlanilla)
        {
            Logger.EscribirInfo(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name,
                RecursosBDModulo14.MsjDeEntrada, System.Reflection.MethodBase.GetCurrentMethod().Name);
            BDConexion laConexion;
            List<Parametro> parametros;
            Parametro parametro = new Parametro();
            List<String> listDatos = new List<String>();
            try
            {
                laConexion = new BDConexion();
                parametros = new List<Parametro>();
                parametro = new Parametro(RecursosBDModulo14.ParametroIdPlanilla,
                SqlDbType.VarChar, idPlanilla.ToString(), false);
                parametros.Add(parametro);

                DataTable resultadoConsulta = laConexion.EjecutarStoredProcedureTuplas(RecursosBDModulo14.ProcedureConsultarDatosPlanillaId, parametros);

                foreach (DataRow row in resultadoConsulta.Rows)
                {
                    listDatos.Add(row[RecursosBDModulo14.AtributoNombre_Dato].ToString());
                    
                }

            }
            catch (SqlException ex)
            {
                BDPLanillaException excep = new BDPLanillaException(RecursoGeneralBD.Codigo,
                    RecursoGeneralBD.Mensaje, ex);
                Logger.EscribirError(RecursosBDModulo14.ClaseBDPlanilla, excep);
                throw excep;
            }
            catch (IOException ex)
            {
                BDPLanillaException excep = new BDPLanillaException(RecursosBDModulo14.CodigoIoException,
                    RecursosBDModulo14.MsjExceptionIO, ex);
                Logger.EscribirError(RecursosBDModulo14.ClaseBDPlanilla, excep);
                throw excep;
            }
            catch (NullReferenceException ex)
            {
                BDPLanillaException excep = new BDPLanillaException(RecursosBDModulo14.CodigoNullReferencesExcep,
                    RecursosBDModulo14.MsjNullException, ex);
                Logger.EscribirError(RecursosBDModulo14.ClaseBDPlanilla, excep);
                throw excep;
            }
            catch (ObjectDisposedException ex)
            {
                BDPLanillaException excep = new BDPLanillaException(RecursosBDModulo14.CodigoDisposedObject,
                    RecursosBDModulo14.MensajeDisposedException, ex);
                Logger.EscribirError(RecursosBDModulo14.ClaseBDPlanilla, excep);
                throw excep;
            }
            catch (ExcepcionesSKD.ExceptionSKDConexionBD ex)
            {
                Logger.EscribirError(RecursosBDModulo14.ClaseBDPlanilla, ex);

                throw ex;
            }
            catch (FormatException ex)
            {
                BDPLanillaException excep = new BDPLanillaException(RecursosBDModulo14.CodigoFormatExceptio,
                    RecursosBDModulo14.MsjFormatException, ex);
                Logger.EscribirError(RecursosBDModulo14.ClaseBDPlanilla, excep);
                throw excep;
            }
            catch (Exception ex)
            {
                BDPLanillaException excep = new BDPLanillaException(RecursosBDModulo14.CodigoException,
                    RecursosBDModulo14.MsjException, ex);
                Logger.EscribirError(RecursosBDModulo14.ClaseBDPlanilla, excep);
                throw excep;
            }

            return listDatos;
        }

        /// <summary>
        /// Obtiene los datos de una planilla id
        /// </summary>
        /// /// <param name="idPlanilla">id planilla</param>
        /// <returns>datos de una planilla</returns>
        public static List<String> ObtenerDatosPlanillaID1(int idPlanilla)
        {
            Logger.EscribirInfo(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name,
                RecursosBDModulo14.MsjDeEntrada, System.Reflection.MethodBase.GetCurrentMethod().Name);
            BDConexion laConexion;
            List<Parametro> parametros;
            Parametro parametro = new Parametro();
            List<String> listDatos = new List<String>();
            try
            {
                laConexion = new BDConexion();
                parametros = new List<Parametro>();
                parametro = new Parametro(RecursosBDModulo14.ParametroIdPlanilla,
                SqlDbType.VarChar, idPlanilla.ToString(), false);
                parametros.Add(parametro);

                DataTable resultadoConsulta = laConexion.EjecutarStoredProcedureTuplas(RecursosBDModulo14.ProcedureConsultarDatosPlanillaId, parametros);

                foreach (DataRow row in resultadoConsulta.Rows)
                {
                    listDatos.Add(row[RecursosBDModulo14.AtributoNombre_Dato].ToString());

                }

            }
            catch (SqlException ex)
            {
                BDPLanillaException excep = new BDPLanillaException(RecursoGeneralBD.Codigo,
                    RecursoGeneralBD.Mensaje, ex);
                Logger.EscribirError(RecursosBDModulo14.ClaseBDPlanilla, excep);
                throw excep;
            }
            catch (IOException ex)
            {
                BDPLanillaException excep = new BDPLanillaException(RecursosBDModulo14.CodigoIoException,
                    RecursosBDModulo14.MsjExceptionIO, ex);
                Logger.EscribirError(RecursosBDModulo14.ClaseBDPlanilla, excep);
                throw excep;
            }
            catch (NullReferenceException ex)
            {
                BDPLanillaException excep = new BDPLanillaException(RecursosBDModulo14.CodigoNullReferencesExcep,
                    RecursosBDModulo14.MsjNullException, ex);
                Logger.EscribirError(RecursosBDModulo14.ClaseBDPlanilla, excep);
                throw excep;
            }
            catch (ObjectDisposedException ex)
            {
                BDPLanillaException excep = new BDPLanillaException(RecursosBDModulo14.CodigoDisposedObject,
                    RecursosBDModulo14.MensajeDisposedException, ex);
                Logger.EscribirError(RecursosBDModulo14.ClaseBDPlanilla, excep);
                throw excep;
            }
            catch (ExcepcionesSKD.ExceptionSKDConexionBD ex)
            {
                Logger.EscribirError(RecursosBDModulo14.ClaseBDPlanilla, ex);

                throw ex;
            }
            catch (FormatException ex)
            {
                BDPLanillaException excep = new BDPLanillaException(RecursosBDModulo14.CodigoFormatExceptio,
                    RecursosBDModulo14.MsjFormatException, ex);
                Logger.EscribirError(RecursosBDModulo14.ClaseBDPlanilla, excep);
                throw excep;
            }
            catch (Exception ex)
            {
                BDPLanillaException excep = new BDPLanillaException(RecursosBDModulo14.CodigoException,
                    RecursosBDModulo14.MsjException, ex);
                Logger.EscribirError(RecursosBDModulo14.ClaseBDPlanilla, excep);
                throw excep;
            }

            return listDatos;
        }
        
        /// <summary>
        /// Modifica una planilla en la base de datos
        /// </summary>
        /// <param name="laPlanilla">La planilla</param>
        /// <returns>returna true en caso de que se completara el registro, y false en caso de que no</returns>           
        public Boolean ModificarPlanillaBD(Planilla laPlanilla)
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
                parametro = new Parametro(RecursosBDModulo14.ParametroIdPlanilla,
                SqlDbType.VarChar, laPlanilla.ID.ToString(), false);
                parametros.Add(parametro);

                parametro = new Parametro(RecursosBDModulo14.ParametroNombrePlanilla,
                SqlDbType.VarChar,laPlanilla.Nombre , false);
                parametros.Add(parametro);

                parametro = new Parametro(RecursosBDModulo14.ParametroTipoPlanillaFK,
                SqlDbType.VarChar, laPlanilla.IDtipoPlanilla.ToString(), false);
                parametros.Add(parametro);

                string query = RecursosBDModulo14.ProcedureModificarPlanilla;
                List<Resultado> resultados = laConexion.EjecutarStoredProcedure(query, parametros);

            }
            catch (SqlException ex)
            {
                BDPLanillaException excep = new BDPLanillaException(RecursoGeneralBD.Codigo,
                    RecursoGeneralBD.Mensaje, ex);
                Logger.EscribirError(RecursosBDModulo14.ClaseBDPlanilla, excep);
                throw excep;
            }
            catch (IOException ex)
            {
                BDPLanillaException excep = new BDPLanillaException(RecursosBDModulo14.CodigoIoException,
                    RecursosBDModulo14.MsjExceptionIO, ex);
                Logger.EscribirError(RecursosBDModulo14.ClaseBDPlanilla, excep);
                throw excep;
            }
            catch (NullReferenceException ex)
            {
                BDPLanillaException excep = new BDPLanillaException(RecursosBDModulo14.CodigoNullReferencesExcep,
                    RecursosBDModulo14.MsjNullException, ex);
                Logger.EscribirError(RecursosBDModulo14.ClaseBDPlanilla, excep);
                throw excep;
            }
            catch (ObjectDisposedException ex)
            {
                BDPLanillaException excep = new BDPLanillaException(RecursosBDModulo14.CodigoDisposedObject,
                    RecursosBDModulo14.MensajeDisposedException, ex);
                Logger.EscribirError(RecursosBDModulo14.ClaseBDPlanilla, excep);
                throw excep;
            }
            catch (ExcepcionesSKD.ExceptionSKDConexionBD ex)
            {
                Logger.EscribirError(RecursosBDModulo14.ClaseBDPlanilla, ex);

                throw ex;
            }
            catch (FormatException ex)
            {
                BDPLanillaException excep = new BDPLanillaException(RecursosBDModulo14.CodigoFormatExceptio,
                    RecursosBDModulo14.MsjFormatException, ex);
                Logger.EscribirError(RecursosBDModulo14.ClaseBDPlanilla, excep);
                throw excep;
            }
            catch (Exception ex)
            {
                BDPLanillaException excep = new BDPLanillaException(RecursosBDModulo14.CodigoException,
                    RecursosBDModulo14.MsjException, ex);
                Logger.EscribirError(RecursosBDModulo14.ClaseBDPlanilla, excep);
                throw excep;
            }
            return true;
        }

        /// <summary>
        /// Modifica una planilla en la base de datos
        /// </summary>
        /// <param name="idPlanilla">La planilla</param>
        /// <returns>returna true en caso de que se completara el registro, y false en caso de que no</returns>
        public Boolean EliminarDatosPlanillaBD(int idPlanilla)
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
                parametro = new Parametro(RecursosBDModulo14.ParametroIdPlanilla,
                SqlDbType.VarChar, idPlanilla.ToString(), false);
                parametros.Add(parametro);


                string query = RecursosBDModulo14.ProcedureEliminarDatosPlanilla;
                List<Resultado> resultados = laConexion.EjecutarStoredProcedure(query, parametros);

            }
            catch (SqlException ex)
            {
                BDPLanillaException excep = new BDPLanillaException(RecursoGeneralBD.Codigo,
                    RecursoGeneralBD.Mensaje, ex);
                Logger.EscribirError(RecursosBDModulo14.ClaseBDPlanilla, excep);
                throw excep;
            }
            catch (IOException ex)
            {
                BDPLanillaException excep = new BDPLanillaException(RecursosBDModulo14.CodigoIoException,
                    RecursosBDModulo14.MsjExceptionIO, ex);
                Logger.EscribirError(RecursosBDModulo14.ClaseBDPlanilla, excep);
                throw excep;
            }
            catch (NullReferenceException ex)
            {
                BDPLanillaException excep = new BDPLanillaException(RecursosBDModulo14.CodigoNullReferencesExcep,
                    RecursosBDModulo14.MsjNullException, ex);
                Logger.EscribirError(RecursosBDModulo14.ClaseBDPlanilla, excep);
                throw excep;
            }
            catch (ObjectDisposedException ex)
            {
                BDPLanillaException excep = new BDPLanillaException(RecursosBDModulo14.CodigoDisposedObject,
                    RecursosBDModulo14.MensajeDisposedException, ex);
                Logger.EscribirError(RecursosBDModulo14.ClaseBDPlanilla, excep);
                throw excep;
            }
            catch (ExcepcionesSKD.ExceptionSKDConexionBD ex)
            {
                Logger.EscribirError(RecursosBDModulo14.ClaseBDPlanilla, ex);

                throw ex;
            }
            catch (FormatException ex)
            {
                BDPLanillaException excep = new BDPLanillaException(RecursosBDModulo14.CodigoFormatExceptio,
                    RecursosBDModulo14.MsjFormatException, ex);
                Logger.EscribirError(RecursosBDModulo14.ClaseBDPlanilla, excep);
                throw excep;
            }
            catch (Exception ex)
            {
                BDPLanillaException excep = new BDPLanillaException(RecursosBDModulo14.CodigoException,
                    RecursosBDModulo14.MsjException, ex);
                Logger.EscribirError(RecursosBDModulo14.ClaseBDPlanilla, excep);
                throw excep;
            }
            return true;
        }

        /// <summary>
        /// Registra los datos de una planilla en la BD por id de la planilla
        /// </summary>
        /// <param name="">idPlanilla y dato de la planilla</param>
        /// <returns>returna true en caso de que se completara el registro, y false en caso de que no</returns>
        public Boolean RegistrarDatosPlanillaIdBD(int idPlanilla, String datoPlanilla)
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

                parametro = new Parametro(RecursosBDModulo14.ParametroIdPlanilla,
                          SqlDbType.VarChar, idPlanilla.ToString(), false);
                parametros.Add(parametro);
                parametro = new Parametro(RecursosBDModulo14.ParametroNombreDato,
                                          SqlDbType.VarChar, datoPlanilla, false);
                parametros.Add(parametro);

                string query = RecursosBDModulo14.ProcedureAgregarDatoPlanillaID;
                List<Resultado> resultados = laConexion.EjecutarStoredProcedure(query, parametros);
            }
            catch (SqlException ex)
            {
                BDPLanillaException excep = new BDPLanillaException(RecursoGeneralBD.Codigo,
                    RecursoGeneralBD.Mensaje, ex);
                Logger.EscribirError(RecursosBDModulo14.ClaseBDPlanilla, excep);
                throw excep;
            }
            catch (IOException ex)
            {
                BDPLanillaException excep = new BDPLanillaException(RecursosBDModulo14.CodigoIoException,
                    RecursosBDModulo14.MsjExceptionIO, ex);
                Logger.EscribirError(RecursosBDModulo14.ClaseBDPlanilla, excep);
                throw excep;
            }
            catch (NullReferenceException ex)
            {
                BDPLanillaException excep = new BDPLanillaException(RecursosBDModulo14.CodigoNullReferencesExcep,
                    RecursosBDModulo14.MsjNullException, ex);
                Logger.EscribirError(RecursosBDModulo14.ClaseBDPlanilla, excep);
                throw excep;
            }
            catch (ObjectDisposedException ex)
            {
                BDPLanillaException excep = new BDPLanillaException(RecursosBDModulo14.CodigoDisposedObject,
                    RecursosBDModulo14.MensajeDisposedException, ex);
                Logger.EscribirError(RecursosBDModulo14.ClaseBDPlanilla, excep);
                throw excep;
            }
            catch (ExcepcionesSKD.ExceptionSKDConexionBD ex)
            {
                Logger.EscribirError(RecursosBDModulo14.ClaseBDPlanilla, ex);

                throw ex;
            }
            catch (FormatException ex)
            {
                BDPLanillaException excep = new BDPLanillaException(RecursosBDModulo14.CodigoFormatExceptio,
                    RecursosBDModulo14.MsjFormatException, ex);
                Logger.EscribirError(RecursosBDModulo14.ClaseBDPlanilla, excep);
                throw excep;
            }
            catch (Exception ex)
            {
                BDPLanillaException excep = new BDPLanillaException(RecursosBDModulo14.CodigoException,
                    RecursosBDModulo14.MsjException, ex);
                Logger.EscribirError(RecursosBDModulo14.ClaseBDPlanilla, excep);
                throw excep;
            }
            return true;
        }

        #endregion
    }
}
