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
    public class BDDiseño
    {
        #region atributos

        private BDConexion con = new BDConexion();

        #endregion

        #region metodos
        /// <summary>
        /// Método que guarda un diseño en la bd
        /// </summary>
        /// <param name="diseño">Clase diseño a guardar</param>
        /// <param name="planilla">Clase Planilla a la cual le pertenece el diseño</param>
        /// <returns>True si se realizo con exito la operación.
        /// De lo contrario devuelve false</returns>
        public Boolean GuardarDiseñoBD(DominioSKD.Diseño diseño, DominioSKD.Planilla planilla)
        {
            Logger.EscribirInfo(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name,
                RecursosBDModulo14.MsjDeEntrada, System.Reflection.MethodBase.GetCurrentMethod().Name);
            SqlConnection conect = con.Conectar();
            try
            {
                if (diseño != null && planilla != null)
                {

                    SqlCommand sqlcom = new SqlCommand(RecursosBDModulo14.ProcedureGuardarDiseño, conect);
                    sqlcom.CommandType = CommandType.StoredProcedure;
                    sqlcom.Parameters.Add(new SqlParameter(RecursosBDModulo14.ParametroContenido,
                        SqlDbType.VarChar));
                    sqlcom.Parameters.Add(new SqlParameter(RecursosBDModulo14.ParametroPlanilla,
                        SqlDbType.Int));

                    sqlcom.Parameters[RecursosBDModulo14.ParametroContenido].Value = diseño.Contenido;
                    sqlcom.Parameters[RecursosBDModulo14.ParametroPlanilla].Value = planilla.ID;

                    SqlDataReader leer;
                    conect.Open();

                    leer = sqlcom.ExecuteReader();
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (SqlException ex)
            {
                BDDiseñoException excep = new BDDiseñoException(RecursoGeneralBD.Codigo,
                    RecursoGeneralBD.Mensaje, ex);
                Logger.EscribirError(RecursosBDModulo14.ClaseBDDis, excep);
                throw excep;
            }
            catch (IOException ex)
            {
                BDDiseñoException excep = new BDDiseñoException(RecursosBDModulo14.CodigoIoException,
                    RecursosBDModulo14.MsjExceptionIO, ex);
                Logger.EscribirError(RecursosBDModulo14.ClaseBDDis, excep);
                throw excep;
            }
            catch (NullReferenceException ex)
            {
                BDDiseñoException excep = new BDDiseñoException(RecursosBDModulo14.CodigoNullReferencesExcep,
                    RecursosBDModulo14.MsjNullException, ex);
                Logger.EscribirError(RecursosBDModulo14.ClaseBDDis, excep);
                throw excep;
            }
            catch (ObjectDisposedException ex)
            {
                BDDiseñoException excep = new BDDiseñoException(RecursosBDModulo14.CodigoDisposedObject,
                    RecursosBDModulo14.MensajeDisposedException, ex);
                Logger.EscribirError(RecursosBDModulo14.ClaseBDDis, excep);
                throw excep;
            }
            catch (ExcepcionesSKD.ExceptionSKDConexionBD ex)
            {
                Logger.EscribirError(RecursosBDModulo14.ClaseBDDis, ex);

                throw ex;
            }
            catch (FormatException ex)
            {
                BDDiseñoException excep = new BDDiseñoException(RecursosBDModulo14.CodigoFormatExceptio,
                    RecursosBDModulo14.MsjFormatException, ex);
                Logger.EscribirError(RecursosBDModulo14.ClaseBDDis, excep);
                throw excep;
            }
            catch (Exception ex)
            {
                BDDiseñoException excep = new BDDiseñoException(RecursosBDModulo14.CodigoException,
                    RecursosBDModulo14.MsjException, ex);
                Logger.EscribirError(RecursosBDModulo14.ClaseBDDis, excep);
                throw excep;
            }
            finally
            {
                con.Desconectar(conect);
            }
        }

        /// <summary>
        /// Metodo que consulta el diseño de una planilla
        /// </summary>
        /// <param name="planilla">Id de la planilla a la cual se desea consultar
        /// el diseño</param>
        /// <returns>Retorna el diseño de la planilla</returns>
        public DominioSKD.Diseño ConsultarDiseño(int planilla)
        {
            Logger.EscribirInfo(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name,
                RecursosBDModulo14.MsjDeEntrada, System.Reflection.MethodBase.GetCurrentMethod().Name);
            SqlConnection conect = con.Conectar();
            DominioSKD.Diseño diseño = new DominioSKD.Diseño();
            
            if (planilla!=0)
            {
                try
                {

                    SqlCommand sqlcom = new SqlCommand(RecursosBDModulo14.ProcedureConsultarDiseño, conect);
                    sqlcom.CommandType = CommandType.StoredProcedure;
                    sqlcom.Parameters.Add(new SqlParameter(RecursosBDModulo14.ParametroDiseñoPlanilla, planilla));

                    SqlDataReader leer;
                    conect.Open();

                    leer = sqlcom.ExecuteReader();
                    if (leer != null)
                    {
                        while (leer.Read())
                        {
                            diseño.ID = Convert.ToInt32(leer[RecursosBDModulo14.AtributoIdDiseño]);
                            diseño.Contenido = leer[RecursosBDModulo14.AtributocontenidoDiseño].ToString();
                            diseño.Base64Decode();
                            return diseño;
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
                    BDDiseñoException excep = new BDDiseñoException(RecursoGeneralBD.Codigo,
                        RecursoGeneralBD.Mensaje, ex);
                    Logger.EscribirError(RecursosBDModulo14.ClaseBDDis, excep);
                    throw excep;
                }
                catch (IOException ex)
                {
                    BDDiseñoException excep = new BDDiseñoException(RecursosBDModulo14.CodigoIoException,
                        RecursosBDModulo14.MsjExceptionIO, ex);
                    Logger.EscribirError(RecursosBDModulo14.ClaseBDDis, excep);
                    throw excep;
                }
                catch (NullReferenceException ex)
                {
                    BDDiseñoException excep = new BDDiseñoException(RecursosBDModulo14.CodigoNullReferencesExcep,
                        RecursosBDModulo14.MsjNullException, ex);
                    Logger.EscribirError(RecursosBDModulo14.ClaseBDDis, excep);
                    throw excep;
                }
                catch (ObjectDisposedException ex)
                {
                    BDDiseñoException excep = new BDDiseñoException(RecursosBDModulo14.CodigoDisposedObject,
                        RecursosBDModulo14.MensajeDisposedException, ex);
                    Logger.EscribirError(RecursosBDModulo14.ClaseBDDis, excep);
                    throw excep;
                }
                catch (ExcepcionesSKD.ExceptionSKDConexionBD ex)
                {
                    Logger.EscribirError(RecursosBDModulo14.ClaseBDDis, ex);

                    throw ex;
                }
                catch (FormatException ex)
                {
                    BDDiseñoException excep = new BDDiseñoException(RecursosBDModulo14.CodigoFormatExceptio,
                        RecursosBDModulo14.MsjFormatException, ex);
                    Logger.EscribirError(RecursosBDModulo14.ClaseBDDis, excep);
                    throw excep;
                }
                catch (Exception ex)
                {
                    BDDiseñoException excep = new BDDiseñoException(RecursosBDModulo14.CodigoException,
                        RecursosBDModulo14.MsjException, ex);
                    Logger.EscribirError(RecursosBDModulo14.ClaseBDDis, excep);
                    throw excep;
                }
                finally
                {
                    con.Desconectar(conect);
                }
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// Método que modifica el diseño de una planilla
        /// </summary>
        /// <param name="diseño">Clase diseño que se desea modificar</param>
        /// <returns>True si el diseño se modifico con exito.
        /// De lo contrario devueleve false</returns>
        public Boolean ModificarDiseño(DominioSKD.Diseño diseño)
        {
            Logger.EscribirInfo(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name,
                RecursosBDModulo14.MsjDeEntrada, System.Reflection.MethodBase.GetCurrentMethod().Name);
            SqlConnection conect = con.Conectar();

            if (diseño != null)
            {
                try
                {

                    SqlCommand sqlcom = new SqlCommand(RecursosBDModulo14.ProcedureModificarDiseño, conect);
                    sqlcom.CommandType = CommandType.StoredProcedure;
                    sqlcom.Parameters.Add(new SqlParameter(RecursosBDModulo14.ParametroID,
                                SqlDbType.Int));
                    sqlcom.Parameters.Add(new SqlParameter(RecursosBDModulo14.ParametroContenido,
                        SqlDbType.VarChar));

                    sqlcom.Parameters[RecursosBDModulo14.ParametroID].Value = diseño.ID;
                    sqlcom.Parameters[RecursosBDModulo14.ParametroContenido].Value = diseño.Contenido;

                    SqlDataReader leer;
                    conect.Open();

                    leer = sqlcom.ExecuteReader();
                    return true;
                }
                catch (SqlException ex)
                {
                    BDDiseñoException excep = new BDDiseñoException(RecursoGeneralBD.Codigo,
                        RecursoGeneralBD.Mensaje, ex);
                    Logger.EscribirError(RecursosBDModulo14.ClaseBDDis, excep);
                    throw excep;
                }
                catch (IOException ex)
                {
                    BDDiseñoException excep = new BDDiseñoException(RecursosBDModulo14.CodigoIoException,
                        RecursosBDModulo14.MsjExceptionIO, ex);
                    Logger.EscribirError(RecursosBDModulo14.ClaseBDDis, excep);
                    throw excep;
                }
                catch (NullReferenceException ex)
                {
                    BDDiseñoException excep = new BDDiseñoException(RecursosBDModulo14.CodigoNullReferencesExcep,
                        RecursosBDModulo14.MsjNullException, ex);
                    Logger.EscribirError(RecursosBDModulo14.ClaseBDDis, excep);
                    throw excep;
                }
                catch (ObjectDisposedException ex)
                {
                    BDDiseñoException excep = new BDDiseñoException(RecursosBDModulo14.CodigoDisposedObject,
                        RecursosBDModulo14.MensajeDisposedException, ex);
                    Logger.EscribirError(RecursosBDModulo14.ClaseBDDis, excep);
                    throw excep;
                }
                catch (ExcepcionesSKD.ExceptionSKDConexionBD ex)
                {
                    Logger.EscribirError(RecursosBDModulo14.ClaseBDDis, ex);

                    throw ex;
                }
                catch (FormatException ex)
                {
                    BDDiseñoException excep = new BDDiseñoException(RecursosBDModulo14.CodigoFormatExceptio,
                        RecursosBDModulo14.MsjFormatException, ex);
                    Logger.EscribirError(RecursosBDModulo14.ClaseBDDis, excep);
                    throw excep;
                }
                catch (Exception ex)
                {
                    BDDiseñoException excep = new BDDiseñoException(RecursosBDModulo14.CodigoException,
                        RecursosBDModulo14.MsjException, ex);
                    Logger.EscribirError(RecursosBDModulo14.ClaseBDDis, excep);
                    throw excep;
                }
                finally
                {
                    con.Desconectar(conect);
                }
                
              }
            else
            {
                return false;
           }

        }
        #endregion
    }
}
