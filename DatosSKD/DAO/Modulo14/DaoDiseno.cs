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
    public class DaoDiseno : DAOGeneral, IDaoDiseno
    {
        

        #region IDAO
        /// <summary>
        /// Metodo que consulta el diseño de una planilla
        /// </summary>
        /// <param name="planilla">Id de la planilla a la cual se desea consultar
        /// el diseño</param>
        /// <returns>Retorna el diseño de la planilla</returns>
        public Entidad ConsultarXId(Entidad laPlanilla)
        {
            Logger.EscribirInfo(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name,
                RecursosDAOModulo14.MsjDeEntrada, System.Reflection.MethodBase.GetCurrentMethod().Name);
            SqlConnection conect = Conectar();
            FabricaEntidades fabricaEntidad = new FabricaEntidades();
            DominioSKD.Entidades.Modulo14.Diseño diseño;
            DominioSKD.Entidades.Modulo14.Planilla planilla =
                (DominioSKD.Entidades.Modulo14.Planilla)laPlanilla;

            if (planilla != null)
            {
                try
                {

                    SqlCommand sqlcom = new SqlCommand(RecursosDAOModulo14.ProcedureConsultarDiseño, conect);
                    sqlcom.CommandType = CommandType.StoredProcedure;
                    sqlcom.Parameters.Add(new SqlParameter(RecursosDAOModulo14.ParametroDiseñoPlanilla, planilla.ID));

                    SqlDataReader leer;
                    conect.Open();
                    List<DominioSKD.Entidades.Modulo14.Diseño> lista = new List<DominioSKD.Entidades.Modulo14.Diseño>();
                    leer = sqlcom.ExecuteReader();
                    if (leer != null)
                    {
                      //  if (leer.Read())
                      //  {
                            while (leer.Read())
                            {
                                diseño =
                       (DominioSKD.Entidades.Modulo14.Diseño)fabricaEntidad.obtenerDiseño();
                                diseño.ID = Convert.ToInt32(leer[RecursosDAOModulo14.AtributoIdDiseño]);
                                diseño.Contenido = leer[RecursosDAOModulo14.AtributocontenidoDiseño].ToString();
                                diseño.Base64Decode();
                                lista.Add(diseño);
                                diseño = null;
                            }
                            int items = lista.Count;
                            return lista[items - 1];
                      //  }
                      //  else
                      //      return null;
                    }
                    else
                    {

                        return null;
                    }
                }
                catch (ArgumentOutOfRangeException ex)
                {
                    return null;
                }
                catch (SqlException ex)
                {
                    BDDiseñoException excep = new BDDiseñoException(RecursoGeneralBD.Codigo,
                        RecursoGeneralBD.Mensaje, ex);
                    Logger.EscribirError(RecursosDAOModulo14.ClaseBDDis, excep);
                    throw excep;
                }
                catch (IOException ex)
                {
                    BDDiseñoException excep = new BDDiseñoException(RecursosDAOModulo14.CodigoIoException,
                        RecursosDAOModulo14.MsjExceptionIO, ex);
                    Logger.EscribirError(RecursosDAOModulo14.ClaseBDDis, excep);
                    throw excep;
                }
                catch (NullReferenceException ex)
                {
                    BDDiseñoException excep = new BDDiseñoException(RecursosDAOModulo14.CodigoNullReferencesExcep,
                        RecursosDAOModulo14.MsjNullException, ex);
                    Logger.EscribirError(RecursosDAOModulo14.ClaseBDDis, excep);
                    throw excep;
                }
                catch (ObjectDisposedException ex)
                {
                    BDDiseñoException excep = new BDDiseñoException(RecursosDAOModulo14.CodigoDisposedObject,
                        RecursosDAOModulo14.MensajeDisposedException, ex);
                    Logger.EscribirError(RecursosDAOModulo14.ClaseBDDis, excep);
                    throw excep;
                }
                catch (ExcepcionesSKD.ExceptionSKDConexionBD ex)
                {
                    Logger.EscribirError(RecursosDAOModulo14.ClaseBDDis, ex);

                    throw ex;
                }
                catch (FormatException ex)
                {
                    BDDiseñoException excep = new BDDiseñoException(RecursosDAOModulo14.CodigoFormatExceptio,
                        RecursosDAOModulo14.MsjFormatException, ex);
                    Logger.EscribirError(RecursosDAOModulo14.ClaseBDDis, excep);
                    throw excep;
                }
                catch (Exception ex)
                {
                    BDDiseñoException excep = new BDDiseñoException(RecursosDAOModulo14.CodigoException,
                        RecursosDAOModulo14.MsjException, ex);
                    Logger.EscribirError(RecursosDAOModulo14.ClaseBDDis, excep);
                    throw excep;
                }
                finally
                {
                   Desconectar(conect);
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
        public Boolean Modificar(Entidad elDiseño)
        {
            Logger.EscribirInfo(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name,
                RecursosDAOModulo14.MsjDeEntrada, System.Reflection.MethodBase.GetCurrentMethod().Name);
            SqlConnection conect = Conectar();
            FabricaEntidades fabricaEntidad = new FabricaEntidades();
            DominioSKD.Entidades.Modulo14.Diseño diseño = 
                (DominioSKD.Entidades.Modulo14.Diseño)elDiseño;

            if (diseño != null)
            {
                try
                {

                    SqlCommand sqlcom = new SqlCommand(RecursosDAOModulo14.ProcedureModificarDiseño, conect);
                    sqlcom.CommandType = CommandType.StoredProcedure;
                    sqlcom.Parameters.Add(new SqlParameter(RecursosDAOModulo14.ParametroID,
                                SqlDbType.Int));
                    sqlcom.Parameters.Add(new SqlParameter(RecursosDAOModulo14.ParametroContenido,
                        SqlDbType.VarChar));

                    sqlcom.Parameters[RecursosDAOModulo14.ParametroID].Value = diseño.ID;
                    sqlcom.Parameters[RecursosDAOModulo14.ParametroContenido].Value = diseño.Contenido;

                    SqlDataReader leer;
                    conect.Open();

                    leer = sqlcom.ExecuteReader();
                    return true;
                }
                catch (SqlException ex)
                {
                    BDDiseñoException excep = new BDDiseñoException(RecursoGeneralBD.Codigo,
                        RecursoGeneralBD.Mensaje, ex);
                    Logger.EscribirError(RecursosDAOModulo14.ClaseBDDis, excep);
                    throw excep;
                }
                catch (IOException ex)
                {
                    BDDiseñoException excep = new BDDiseñoException(RecursosDAOModulo14.CodigoIoException,
                        RecursosDAOModulo14.MsjExceptionIO, ex);
                    Logger.EscribirError(RecursosDAOModulo14.ClaseBDDis, excep);
                    throw excep;
                }
                catch (NullReferenceException ex)
                {
                    BDDiseñoException excep = new BDDiseñoException(RecursosDAOModulo14.CodigoNullReferencesExcep,
                        RecursosDAOModulo14.MsjNullException, ex);
                    Logger.EscribirError(RecursosDAOModulo14.ClaseBDDis, excep);
                    throw excep;
                }
                catch (ObjectDisposedException ex)
                {
                    BDDiseñoException excep = new BDDiseñoException(RecursosDAOModulo14.CodigoDisposedObject,
                        RecursosDAOModulo14.MensajeDisposedException, ex);
                    Logger.EscribirError(RecursosDAOModulo14.ClaseBDDis, excep);
                    throw excep;
                }
                catch (ExcepcionesSKD.ExceptionSKDConexionBD ex)
                {
                    Logger.EscribirError(RecursosDAOModulo14.ClaseBDDis, ex);

                    throw ex;
                }
                catch (FormatException ex)
                {
                    BDDiseñoException excep = new BDDiseñoException(RecursosDAOModulo14.CodigoFormatExceptio,
                        RecursosDAOModulo14.MsjFormatException, ex);
                    Logger.EscribirError(RecursosDAOModulo14.ClaseBDDis, excep);
                    throw excep;
                }
                catch (Exception ex)
                {
                    BDDiseñoException excep = new BDDiseñoException(RecursosDAOModulo14.CodigoException,
                        RecursosDAOModulo14.MsjException, ex);
                    Logger.EscribirError(RecursosDAOModulo14.ClaseBDDis, excep);
                    throw excep;
                }
                finally
                {
                   Desconectar(conect);
                }

            }
            else
            {
                return false;
            }

        }

        public Boolean Agregar(Entidad elDiseño)
        {
            return false;
        }

        public List<Entidad> ConsultarTodos()
        {
            return null;
        }
        #endregion

        #region IdaoDiseño
        public Entidad ConsultarDisenoID(Entidad laPlanilla)
        {
            Logger.EscribirInfo(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name,
                RecursosDAOModulo14.MsjDeEntrada, System.Reflection.MethodBase.GetCurrentMethod().Name);
            SqlConnection conect = Conectar();
            FabricaEntidades fabricaEntidad = new FabricaEntidades();
            DominioSKD.Entidades.Modulo14.Diseño diseño;
            DominioSKD.Entidades.Modulo14.SolicitudPlanilla planilla =
                (DominioSKD.Entidades.Modulo14.SolicitudPlanilla)laPlanilla;

            if (planilla != null)
            {
                try
                {

                    SqlCommand sqlcom = new SqlCommand("M14_ConsultarDiseñoID", conect);
                    sqlcom.CommandType = CommandType.StoredProcedure;
                    sqlcom.Parameters.Add(new SqlParameter(RecursosDAOModulo14.ParametroDiseñoPlanilla, planilla.Diseno.ID));

                    SqlDataReader leer;
                    conect.Open();
                    List<DominioSKD.Entidades.Modulo14.Diseño> lista = new List<DominioSKD.Entidades.Modulo14.Diseño>();
                    leer = sqlcom.ExecuteReader();
                    if (leer != null)
                    {
                        while (leer.Read())
                        {
                            diseño =
                   (DominioSKD.Entidades.Modulo14.Diseño)fabricaEntidad.obtenerDiseño();
                            diseño.ID = Convert.ToInt32(leer[RecursosDAOModulo14.AtributoIdDiseño]);
                            diseño.Contenido = leer[RecursosDAOModulo14.AtributocontenidoDiseño].ToString();
                            diseño.Base64Decode();
                            lista.Add(diseño);
                            diseño = null;
                        }
                        int items = lista.Count;
                        return lista[items - 1];
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
                    Logger.EscribirError(RecursosDAOModulo14.ClaseBDDis, excep);
                    throw excep;
                }
                catch (IOException ex)
                {
                    BDDiseñoException excep = new BDDiseñoException(RecursosDAOModulo14.CodigoIoException,
                        RecursosDAOModulo14.MsjExceptionIO, ex);
                    Logger.EscribirError(RecursosDAOModulo14.ClaseBDDis, excep);
                    throw excep;
                }
                catch (NullReferenceException ex)
                {
                    BDDiseñoException excep = new BDDiseñoException(RecursosDAOModulo14.CodigoNullReferencesExcep,
                        RecursosDAOModulo14.MsjNullException, ex);
                    Logger.EscribirError(RecursosDAOModulo14.ClaseBDDis, excep);
                    throw excep;
                }
                catch (ObjectDisposedException ex)
                {
                    BDDiseñoException excep = new BDDiseñoException(RecursosDAOModulo14.CodigoDisposedObject,
                        RecursosDAOModulo14.MensajeDisposedException, ex);
                    Logger.EscribirError(RecursosDAOModulo14.ClaseBDDis, excep);
                    throw excep;
                }
                catch (ExcepcionesSKD.ExceptionSKDConexionBD ex)
                {
                    Logger.EscribirError(RecursosDAOModulo14.ClaseBDDis, ex);

                    throw ex;
                }
                catch (FormatException ex)
                {
                    BDDiseñoException excep = new BDDiseñoException(RecursosDAOModulo14.CodigoFormatExceptio,
                        RecursosDAOModulo14.MsjFormatException, ex);
                    Logger.EscribirError(RecursosDAOModulo14.ClaseBDDis, excep);
                    throw excep;
                }
                catch (Exception ex)
                {
                    BDDiseñoException excep = new BDDiseñoException(RecursosDAOModulo14.CodigoException,
                        RecursosDAOModulo14.MsjException, ex);
                    Logger.EscribirError(RecursosDAOModulo14.ClaseBDDis, excep);
                    throw excep;
                }
                finally
                {
                    Desconectar(conect);
                }
            }
            else
            {
                return null;
            }
        }


        /// <summary>
        /// Método que guarda un diseño en la bd
        /// </summary>
        /// <param name="elDiseño">Clase diseño a guardar</param>
        /// <param name="laPlanilla">Clase Planilla a la cual le pertenece el diseño</param>
        /// <returns>True si se realizo con exito la operación.
        /// De lo contrario devuelve false</returns>
        public Boolean GuardarDiseñoBD(Entidad elDiseño, Entidad laPlanilla)
        {
            Logger.EscribirInfo(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name,
                RecursosDAOModulo14.MsjDeEntrada, System.Reflection.MethodBase.GetCurrentMethod().Name);
            SqlConnection conect = Conectar();
            DominioSKD.Entidades.Modulo14.Diseño diseño =
                (DominioSKD.Entidades.Modulo14.Diseño)elDiseño;
            DominioSKD.Entidades.Modulo14.Planilla planilla =
                (DominioSKD.Entidades.Modulo14.Planilla)laPlanilla;
            try
            {
                if (diseño != null && planilla != null)
                {

                    SqlCommand sqlcom = new SqlCommand(RecursosDAOModulo14.ProcedureGuardarDiseño, conect);
                    sqlcom.CommandType = CommandType.StoredProcedure;
                    sqlcom.Parameters.Add(new SqlParameter(RecursosDAOModulo14.ParametroContenido,
                        SqlDbType.VarChar));
                    sqlcom.Parameters.Add(new SqlParameter(RecursosDAOModulo14.ParametroPlanilla,
                        SqlDbType.Int));

                    sqlcom.Parameters[RecursosDAOModulo14.ParametroContenido].Value = diseño.Contenido;
                    sqlcom.Parameters[RecursosDAOModulo14.ParametroPlanilla].Value = planilla.ID;

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
                Logger.EscribirError(RecursosDAOModulo14.ClaseBDDis, excep);
                throw excep;
            }
            catch (IOException ex)
            {
                BDDiseñoException excep = new BDDiseñoException(RecursosDAOModulo14.CodigoIoException,
                    RecursosDAOModulo14.MsjExceptionIO, ex);
                Logger.EscribirError(RecursosDAOModulo14.ClaseBDDis, excep);
                throw excep;
            }
            catch (NullReferenceException ex)
            {
                BDDiseñoException excep = new BDDiseñoException(RecursosDAOModulo14.CodigoNullReferencesExcep,
                    RecursosDAOModulo14.MsjNullException, ex);
                Logger.EscribirError(RecursosDAOModulo14.ClaseBDDis, excep);
                throw excep;
            }
            catch (ObjectDisposedException ex)
            {
                BDDiseñoException excep = new BDDiseñoException(RecursosDAOModulo14.CodigoDisposedObject,
                    RecursosDAOModulo14.MensajeDisposedException, ex);
                Logger.EscribirError(RecursosDAOModulo14.ClaseBDDis, excep);
                throw excep;
            }
            catch (ExcepcionesSKD.ExceptionSKDConexionBD ex)
            {
                Logger.EscribirError(RecursosDAOModulo14.ClaseBDDis, ex);

                throw ex;
            }
            catch (FormatException ex)
            {
                BDDiseñoException excep = new BDDiseñoException(RecursosDAOModulo14.CodigoFormatExceptio,
                    RecursosDAOModulo14.MsjFormatException, ex);
                Logger.EscribirError(RecursosDAOModulo14.ClaseBDDis, excep);
                throw excep;
            }
            catch (Exception ex)
            {
                BDDiseñoException excep = new BDDiseñoException(RecursosDAOModulo14.CodigoException,
                    RecursosDAOModulo14.MsjException, ex);
                Logger.EscribirError(RecursosDAOModulo14.ClaseBDDis, excep);
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
