using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using DominioSKD;

namespace DatosSKD.Modulo14
{
    public class BDPlanilla
    {
        #region atributos

        private BDConexion con = new BDConexion();

        #endregion


        #region metodos
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public List<DominioSKD.Planilla> ConsultarPlanillasCreadas()
        {
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
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    con.Desconectar(conect);
                }

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="idPlanilla"></param>
        public Boolean CambiarStatus(int idPlanilla)
        {
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
                catch (Exception ex)
                {
                    throw ex;
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
        public static List<Planilla> ObtenerTipoPlanilla()
        {
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
            catch (Exception e)
            {
                throw e;
            }

            return listaTipoPlanilla;
        }

        /// <summary>
        /// Obtiene la lista de los datos
        /// </summary>
        /// <returns>Lista de los datos que se encuentran</returns>
        public static List<String> ObtenerDatosBD()
        {
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
            catch (Exception e)
            {
                throw e;
            }

            return listaDatos;
        }


        /// <summary>
        /// Registra una planilla en la base de datos
        /// </summary>
        /// <param name="elUsuario">La planilla</param>
        /// <returns>returna true en caso de que se completara el registro, y false en caso de que no</returns>

        public static Boolean RegistrarPlanillaBD(Planilla laPlanilla)
        {


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
            catch (SqlException)
            {
                return false;
            }
            return true;
        }

        /// <summary>
        /// Registra los datos de una planilla en la BD
        /// </summary>
        /// <param name="elUsuario">La planilla</param>
        /// <returns>returna true en caso de que se completara el registro, y false en caso de que no</returns>
        public static Boolean RegistrarDatosPlanillaBD(String nombrePlanilla, String datoPlanilla)
        {


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
            catch (SqlException)
            {
                return false;
            }
            return true;
        }

        /// <summary>
        /// Registra el Tipo de una planilla en la BD
        /// </summary>
        /// <param name="elUsuario">La planilla</param>
        /// <returns>returna true en caso de que se completara el registro, y false en caso de que no</returns>
        public static Boolean RegistrarTipoPlanilla(String nombreTipoPlanilla)
        {


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
            catch (SqlException)
            {
                return false;
            }
            return true;
        }

        /// <summary>
        /// Obtiene la lista de los tipo de planillas
        /// </summary>
        /// <returns>Lista de los tipos de planillas</returns>
        public static int ObtenerIdTipoPlanilla(String nombreTipo)
        {
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
            catch (Exception e)
            {
                throw e;
            }

            return idTipolanilla;
        }

        /// <summary>
        /// Obtiene una planilla por el ID
        /// </summary>
        /// /// <param name="elUsuario">id planilla</param>
        /// <returns>Planilla con nombre, status y tipo de planilla</returns>
        public static Planilla ObtenerPlanillaID(int idPlanilla)
        {
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
            catch (Exception e)
            {
                throw e;
            }

            return planilla;
        }

        /// <summary>
        /// Obtiene los datos de una planilla id
        /// </summary>
        /// /// <param name="elUsuario">id planilla</param>
        /// <returns>datos de una planilla</returns>
        public static List<String> ObtenerDatosPlanillaID(int idPlanilla)
        {
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
            catch (Exception e)
            {
                throw e;
            }

            return listDatos;
        }


        /// <summary>
        /// Modifica una planilla en la base de datos
        /// </summary>
        /// <param name="elUsuario">La planilla</param>
        /// <returns>returna true en caso de que se completara el registro, y false en caso de que no</returns>

        public static Boolean ModificarPlanillaBD(Planilla laPlanilla)
        {


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
            catch (SqlException)
            {
                return false;
            }
            return true;
        }


        /// <summary>
        /// Modifica una planilla en la base de datos
        /// </summary>
        /// <param name="elUsuario">La planilla</param>
        /// <returns>returna true en caso de que se completara el registro, y false en caso de que no</returns>

        public static Boolean EliminarDatosPlanillaBD(int idPlanilla)
        {


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
            catch (SqlException)
            {
                return false;
            }
            return true;
        }

        /// <summary>
        /// Registra los datos de una planilla en la BD por id de la planilla
        /// </summary>
        /// <param name="">idPlanilla y dato de la planilla</param>
        /// <returns>returna true en caso de que se completara el registro, y false en caso de que no</returns>
        public static Boolean RegistrarDatosPlanillaIdBD(int idPlanilla, String datoPlanilla)
        {


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
            catch (SqlException)
            {
                return false;
            }
            return true;
        }

        #endregion
    }
}
