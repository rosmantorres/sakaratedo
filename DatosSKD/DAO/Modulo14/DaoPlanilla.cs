using DatosSKD.InterfazDAO.Modulo14;
using DominioSKD;
using DominioSKD.Fabrica;
using ExcepcionesSKD;
using ExcepcionesSKD.Modulo14;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatosSKD.DAO.Modulo14
{
    public class DaoPlanilla : DAOGeneral, IDaoPlanilla
    {

        #region IDAO
        /// <summary>
        /// Registra una planilla en la base de datos
        /// </summary>
        /// <param name="laPlanilla">La planilla</param>
        /// <returns>returna true en caso de que se completara el registro, y false en caso de que no</returns>
        public bool Agregar(Entidad laPlanilla)
        {
            Logger.EscribirInfo(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name,
                RecursosDAOModulo14.MsjDeEntrada, System.Reflection.MethodBase.GetCurrentMethod().Name);
            // BDConexion laConexion;
            List<Parametro> parametros;
            Parametro parametro = new Parametro();
            DominioSKD.Entidades.Modulo14.Planilla planilla =
                (DominioSKD.Entidades.Modulo14.Planilla)laPlanilla;

            try
            {
                //   laConexion = new BDConexion();
                this.Conectar();
                parametros = new List<Parametro>();
                parametro = new Parametro(RecursosDAOModulo14.ParametroNombrePlanilla,
                SqlDbType.VarChar, planilla.Nombre, false);
                parametros.Add(parametro);

                parametro = new Parametro(RecursosDAOModulo14.ParametroSatusPlanilla,
                SqlDbType.VarChar, planilla.Status.ToString(), false);
                parametros.Add(parametro);

                parametro = new Parametro(RecursosDAOModulo14.ParametroTipoPlanillaFK,
                SqlDbType.VarChar, planilla.IDtipoPlanilla.ToString(), false);
                parametros.Add(parametro);
                string query = RecursosDAOModulo14.ProcedureAgregarPlanilla;
                List<Resultado> resultados = this.EjecutarStoredProcedure(query, parametros);

            }
            catch (SqlException ex)
            {
                BDPLanillaException excep = new BDPLanillaException(RecursoGeneralBD.Codigo,
                    RecursoGeneralBD.Mensaje, ex);
                Logger.EscribirError(RecursosDAOModulo14.ClaseBDPlanilla, excep);
                throw excep;
            }
            catch (IOException ex)
            {
                BDPLanillaException excep = new BDPLanillaException(RecursosDAOModulo14.CodigoIoException,
                    RecursosDAOModulo14.MsjExceptionIO, ex);
                Logger.EscribirError(RecursosDAOModulo14.ClaseBDPlanilla, excep);
                throw excep;
            }
            catch (NullReferenceException ex)
            {
                BDPLanillaException excep = new BDPLanillaException(RecursosDAOModulo14.CodigoNullReferencesExcep,
                    RecursosDAOModulo14.MsjNullException, ex);
                Logger.EscribirError(RecursosDAOModulo14.ClaseBDPlanilla, excep);
                throw excep;
            }
            catch (ObjectDisposedException ex)
            {
                BDPLanillaException excep = new BDPLanillaException(RecursosDAOModulo14.CodigoDisposedObject,
                    RecursosDAOModulo14.MensajeDisposedException, ex);
                Logger.EscribirError(RecursosDAOModulo14.ClaseBDPlanilla, excep);
                throw excep;
            }
            catch (ExcepcionesSKD.ExceptionSKDConexionBD ex)
            {
                Logger.EscribirError(RecursosDAOModulo14.ClaseBDPlanilla, ex);

                throw ex;
            }
            catch (FormatException ex)
            {
                BDPLanillaException excep = new BDPLanillaException(RecursosDAOModulo14.CodigoFormatExceptio,
                    RecursosDAOModulo14.MsjFormatException, ex);
                Logger.EscribirError(RecursosDAOModulo14.ClaseBDPlanilla, excep);
                throw excep;
            }
            catch (Exception ex)
            {
                BDPLanillaException excep = new BDPLanillaException(RecursosDAOModulo14.CodigoException,
                    RecursosDAOModulo14.MsjException, ex);
                Logger.EscribirError(RecursosDAOModulo14.ClaseBDPlanilla, excep);
                throw excep;
            }
            return true;
        }

        /// <summary>
        /// Modifica una planilla en la base de datos
        /// </summary>
        /// <param name="laPlanilla">La planilla</param>
        /// <returns>returna true en caso de que se completara el registro, y false en caso de que no</returns>           
        public bool Modificar(Entidad laPlanilla)
        {
            Logger.EscribirInfo(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name,
                RecursosDAOModulo14.MsjDeEntrada, System.Reflection.MethodBase.GetCurrentMethod().Name);
            //BDConexion laConexion;
            List<Parametro> parametros;
            Parametro parametro = new Parametro();
            DominioSKD.Entidades.Modulo14.Planilla planilla =
                (DominioSKD.Entidades.Modulo14.Planilla)laPlanilla;
            try
            {
                //  laConexion = new BDConexion();
                this.Conectar();
                parametros = new List<Parametro>();
                parametro = new Parametro(RecursosDAOModulo14.ParametroIdPlanilla,
                SqlDbType.VarChar, planilla.ID.ToString(), false);
                parametros.Add(parametro);

                parametro = new Parametro(RecursosDAOModulo14.ParametroNombrePlanilla,
                SqlDbType.VarChar, planilla.Nombre, false);
                parametros.Add(parametro);

                parametro = new Parametro(RecursosDAOModulo14.ParametroTipoPlanillaFK,
                SqlDbType.VarChar, planilla.IDtipoPlanilla.ToString(), false);
                parametros.Add(parametro);

                string query = RecursosDAOModulo14.ProcedureModificarPlanilla;
                List<Resultado> resultados = this.EjecutarStoredProcedure(query, parametros);

            }
            catch (SqlException ex)
            {
                BDPLanillaException excep = new BDPLanillaException(RecursoGeneralBD.Codigo,
                    RecursoGeneralBD.Mensaje, ex);
                Logger.EscribirError(RecursosDAOModulo14.ClaseBDPlanilla, excep);
                throw excep;
            }
            catch (IOException ex)
            {
                BDPLanillaException excep = new BDPLanillaException(RecursosDAOModulo14.CodigoIoException,
                    RecursosDAOModulo14.MsjExceptionIO, ex);
                Logger.EscribirError(RecursosDAOModulo14.ClaseBDPlanilla, excep);
                throw excep;
            }
            catch (NullReferenceException ex)
            {
                BDPLanillaException excep = new BDPLanillaException(RecursosDAOModulo14.CodigoNullReferencesExcep,
                    RecursosDAOModulo14.MsjNullException, ex);
                Logger.EscribirError(RecursosDAOModulo14.ClaseBDPlanilla, excep);
                throw excep;
            }
            catch (ObjectDisposedException ex)
            {
                BDPLanillaException excep = new BDPLanillaException(RecursosDAOModulo14.CodigoDisposedObject,
                    RecursosDAOModulo14.MensajeDisposedException, ex);
                Logger.EscribirError(RecursosDAOModulo14.ClaseBDPlanilla, excep);
                throw excep;
            }
            catch (ExcepcionesSKD.ExceptionSKDConexionBD ex)
            {
                Logger.EscribirError(RecursosDAOModulo14.ClaseBDPlanilla, ex);

                throw ex;
            }
            catch (FormatException ex)
            {
                BDPLanillaException excep = new BDPLanillaException(RecursosDAOModulo14.CodigoFormatExceptio,
                    RecursosDAOModulo14.MsjFormatException, ex);
                Logger.EscribirError(RecursosDAOModulo14.ClaseBDPlanilla, excep);
                throw excep;
            }
            catch (Exception ex)
            {
                BDPLanillaException excep = new BDPLanillaException(RecursosDAOModulo14.CodigoException,
                    RecursosDAOModulo14.MsjException, ex);
                Logger.EscribirError(RecursosDAOModulo14.ClaseBDPlanilla, excep);
                throw excep;
            }
            return true;
        }

        /// <summary>
        /// Obtiene una planilla por el ID
        /// </summary>
        /// /// <param name="idPlanilla">id planilla</param>
        /// <returns>Planilla con nombre, status y tipo de planilla</returns>
        public Entidad ConsultarXId(Entidad laPlanilla)
        {
            Logger.EscribirInfo(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name,
                RecursosDAOModulo14.MsjDeEntrada, System.Reflection.MethodBase.GetCurrentMethod().Name);
            //  BDConexion laConexion;
            int idPlanilla = ((DominioSKD.Entidades.Modulo14.Planilla)laPlanilla).ID;
            DominioSKD.Entidades.Modulo14.Planilla planilla = null;
            List<Parametro> parametros;
            Parametro parametro = new Parametro();

            try
            {
                //  laConexion = new BDConexion();
                this.Conectar();
                parametros = new List<Parametro>();
                parametro = new Parametro(RecursosDAOModulo14.ParametroIdPlanilla,
                SqlDbType.VarChar, idPlanilla.ToString(), false);
                parametros.Add(parametro);

                DataTable resultadoConsulta = this.EjecutarStoredProcedureTuplas(RecursosDAOModulo14.ProcedureConsultatPlanillaID, parametros);

                foreach (DataRow row in resultadoConsulta.Rows)
                {
                    String tipoPlanilla = row[RecursosDAOModulo14.AtributoNombreTipoPlanilla].ToString();
                    String nombrePlanilla = row[RecursosDAOModulo14.AtributoNombrePlanilla].ToString();
                    bool statusPlanilla = (bool)row[RecursosDAOModulo14.AtributoStatusPlanilla];
                    planilla =
                        (DominioSKD.Entidades.Modulo14.Planilla)FabricaEntidades.ObtenerPlanilla(nombrePlanilla, statusPlanilla, tipoPlanilla);
                }

            }
            catch (SqlException ex)
            {
                BDPLanillaException excep = new BDPLanillaException(RecursoGeneralBD.Codigo,
                    RecursoGeneralBD.Mensaje, ex);
                Logger.EscribirError(RecursosDAOModulo14.ClaseBDPlanilla, excep);
                throw excep;
            }
            catch (IOException ex)
            {
                BDPLanillaException excep = new BDPLanillaException(RecursosDAOModulo14.CodigoIoException,
                    RecursosDAOModulo14.MsjExceptionIO, ex);
                Logger.EscribirError(RecursosDAOModulo14.ClaseBDPlanilla, excep);
                throw excep;
            }
            catch (NullReferenceException ex)
            {
                BDPLanillaException excep = new BDPLanillaException(RecursosDAOModulo14.CodigoNullReferencesExcep,
                    RecursosDAOModulo14.MsjNullException, ex);
                Logger.EscribirError(RecursosDAOModulo14.ClaseBDPlanilla, excep);
                throw excep;
            }
            catch (ObjectDisposedException ex)
            {
                BDPLanillaException excep = new BDPLanillaException(RecursosDAOModulo14.CodigoDisposedObject,
                    RecursosDAOModulo14.MensajeDisposedException, ex);
                Logger.EscribirError(RecursosDAOModulo14.ClaseBDPlanilla, excep);
                throw excep;
            }
            catch (ExcepcionesSKD.ExceptionSKDConexionBD ex)
            {
                Logger.EscribirError(RecursosDAOModulo14.ClaseBDPlanilla, ex);

                throw ex;
            }
            catch (FormatException ex)
            {
                BDPLanillaException excep = new BDPLanillaException(RecursosDAOModulo14.CodigoFormatExceptio,
                    RecursosDAOModulo14.MsjFormatException, ex);
                Logger.EscribirError(RecursosDAOModulo14.ClaseBDPlanilla, excep);
                throw excep;
            }
            catch (Exception ex)
            {
                BDPLanillaException excep = new BDPLanillaException(RecursosDAOModulo14.CodigoException,
                    RecursosDAOModulo14.MsjException, ex);
                Logger.EscribirError(RecursosDAOModulo14.ClaseBDPlanilla, excep);
                throw excep;
            }

            return planilla;
        }

        public List<Entidad> ConsultarTodos()
        {
            return null;
        }

        #endregion

        #region IDAOPlanilla

        /// <summary>
        /// Obtiene la lista de los tipo de planillas
        /// </summary>
        /// <returns>Lista de los tipos de planillas</returns>
        public List<Entidad> ObtenerTipoPlanilla()
        {


            Logger.EscribirInfo(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name,
                RecursosDAOModulo14.MsjDeEntrada, System.Reflection.MethodBase.GetCurrentMethod().Name);
            //BDConexion laConexion;
            List<Entidad> listaTipoPlanilla = new List<Entidad>();
            List<Parametro> parametros;

            try
            {
             //   laConexion = new BDConexion();
                this.Conectar();
                parametros = new List<Parametro>();
                DataTable resultadoConsulta = this.EjecutarStoredProcedureTuplas(RecursosDAOModulo14.ProcedureListaTipoPlanilla, parametros);

                foreach (DataRow row in resultadoConsulta.Rows)
                {
                    Entidad laPlanilla = FabricaEntidades.ObtenerPlanilla(Int32.Parse(row[RecursosDAOModulo14.AtributoIdTipoPlanilla].ToString()), row[RecursosDAOModulo14.AtributoNombreTipoPlanilla].ToString());
                    listaTipoPlanilla.Add(laPlanilla);
                }

            }
            catch (SqlException ex)
            {
                BDPLanillaException excep = new BDPLanillaException(RecursoGeneralBD.Codigo,
                   RecursoGeneralBD.Mensaje, ex);
                Logger.EscribirError(RecursosDAOModulo14.ClaseBDPlanilla, excep);
                throw excep;
            }
            catch (IOException ex)
            {
                BDPLanillaException excep = new BDPLanillaException(RecursosDAOModulo14.CodigoIoException,
                    RecursosDAOModulo14.MsjExceptionIO, ex);
                Logger.EscribirError(RecursosDAOModulo14.ClaseBDPlanilla, excep);
                throw excep;
            }
            catch (NullReferenceException ex)
            {
                BDPLanillaException excep = new BDPLanillaException(RecursosDAOModulo14.CodigoNullReferencesExcep,
                    RecursosDAOModulo14.MsjNullException, ex);
                Logger.EscribirError(RecursosDAOModulo14.ClaseBDPlanilla, excep);
                throw excep;
            }
            catch (ObjectDisposedException ex)
            {
                BDPLanillaException excep = new BDPLanillaException(RecursosDAOModulo14.CodigoDisposedObject,
                    RecursosDAOModulo14.MensajeDisposedException, ex);
                Logger.EscribirError(RecursosDAOModulo14.ClaseBDPlanilla, excep);
                throw excep;
            }
            catch (ExcepcionesSKD.ExceptionSKDConexionBD ex)
            {
                Logger.EscribirError(RecursosDAOModulo14.ClaseBDPlanilla, ex);

                throw ex;
            }
            catch (FormatException ex)
            {
                BDPLanillaException excep = new BDPLanillaException(RecursosDAOModulo14.CodigoFormatExceptio,
                    RecursosDAOModulo14.MsjFormatException, ex);
                Logger.EscribirError(RecursosDAOModulo14.ClaseBDPlanilla, excep);
                throw excep;
            }
            catch (Exception ex)
            {
                BDPLanillaException excep = new BDPLanillaException(RecursosDAOModulo14.CodigoException,
                    RecursosDAOModulo14.MsjException, ex);
                Logger.EscribirError(RecursosDAOModulo14.ClaseBDPlanilla, excep);
                throw excep;
            }

            return listaTipoPlanilla;
        }

        /// <summary>
        /// Obtiene la lista de los datos
        /// </summary>
        /// <returns>Lista de los datos que se encuentran</returns>
        public List<String> ObtenerDatosBD()
        {
            Logger.EscribirInfo(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name,
                RecursosDAOModulo14.MsjDeEntrada, System.Reflection.MethodBase.GetCurrentMethod().Name);
         //   BDConexion laConexion;
            List<String> listaDatos = new List<String>();
            List<Parametro> parametros;
            //List<Resultado> resultadoConsulta;

            try
            {
             //   laConexion = new BDConexion();
                this.Conectar();
                parametros = new List<Parametro>();
                DataTable resultadoConsulta = this.EjecutarStoredProcedureTuplas(RecursosDAOModulo14.ProcedureConsultarListaDatos, parametros);

                foreach (DataRow row in resultadoConsulta.Rows)
                {
                    listaDatos.Add(row[RecursosDAOModulo14.AtributoNombre_Dato].ToString());
                }

            }
            catch (SqlException ex)
            {
                BDPLanillaException excep = new BDPLanillaException(RecursoGeneralBD.Codigo,
                    RecursoGeneralBD.Mensaje, ex);
                Logger.EscribirError(RecursosDAOModulo14.ClaseBDPlanilla, excep);
                throw excep;
            }
            catch (IOException ex)
            {
                BDPLanillaException excep = new BDPLanillaException(RecursosDAOModulo14.CodigoIoException,
                    RecursosDAOModulo14.MsjExceptionIO, ex);
                Logger.EscribirError(RecursosDAOModulo14.ClaseBDPlanilla, excep);
                throw excep;
            }
            catch (NullReferenceException ex)
            {
                BDPLanillaException excep = new BDPLanillaException(RecursosDAOModulo14.CodigoNullReferencesExcep,
                    RecursosDAOModulo14.MsjNullException, ex);
                Logger.EscribirError(RecursosDAOModulo14.ClaseBDPlanilla, excep);
                throw excep;
            }
            catch (ObjectDisposedException ex)
            {
                BDPLanillaException excep = new BDPLanillaException(RecursosDAOModulo14.CodigoDisposedObject,
                    RecursosDAOModulo14.MensajeDisposedException, ex);
                Logger.EscribirError(RecursosDAOModulo14.ClaseBDPlanilla, excep);
                throw excep;
            }
            catch (ExcepcionesSKD.ExceptionSKDConexionBD ex)
            {
                Logger.EscribirError(RecursosDAOModulo14.ClaseBDPlanilla, ex);

                throw ex;
            }
            catch (FormatException ex)
            {
                BDPLanillaException excep = new BDPLanillaException(RecursosDAOModulo14.CodigoFormatExceptio,
                    RecursosDAOModulo14.MsjFormatException, ex);
                Logger.EscribirError(RecursosDAOModulo14.ClaseBDPlanilla, excep);
                throw excep;
            }
            catch (Exception ex)
            {
                BDPLanillaException excep = new BDPLanillaException(RecursosDAOModulo14.CodigoException,
                    RecursosDAOModulo14.MsjException, ex);
                Logger.EscribirError(RecursosDAOModulo14.ClaseBDPlanilla, excep);
                throw excep;
            }

            return listaDatos;
        }

        /// <summary>
        /// Registra los datos de una planilla en la BD
        /// </summary>
        /// <param name="">La planilla</param>
        /// <returns>returna true en caso de que se completara el registro, y false en caso de que no</returns>
        public Boolean RegistrarDatosPlanillaBD(String nombrePlanilla, String datoPlanilla)
        {
            Logger.EscribirInfo(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name,
                RecursosDAOModulo14.MsjDeEntrada, System.Reflection.MethodBase.GetCurrentMethod().Name);
           // BDConexion laConexion;
            List<Parametro> parametros;
            Parametro parametro = new Parametro();

            try
            {
             //   laConexion = new BDConexion();
                //this.Conectar();
                parametros = new List<Parametro>();

                parametro = new Parametro(RecursosDAOModulo14.ParametroNombrePlanilla,
                          SqlDbType.VarChar, nombrePlanilla, false);
                parametros.Add(parametro);
                parametro = new Parametro(RecursosDAOModulo14.ParametroNombreDato,
                                          SqlDbType.VarChar, datoPlanilla, false);
                parametros.Add(parametro);

                string query = RecursosDAOModulo14.ProcedureAgregarDatoPlanilla;
                List<Resultado> resultados = this.EjecutarStoredProcedure(query, parametros);
            }
            catch (SqlException ex)
            {
                BDPLanillaException excep = new BDPLanillaException(RecursoGeneralBD.Codigo,
                    RecursoGeneralBD.Mensaje, ex);
                Logger.EscribirError(RecursosDAOModulo14.ClaseBDPlanilla, excep);
                throw excep;
            }
            catch (IOException ex)
            {
                BDPLanillaException excep = new BDPLanillaException(RecursosDAOModulo14.CodigoIoException,
                    RecursosDAOModulo14.MsjExceptionIO, ex);
                Logger.EscribirError(RecursosDAOModulo14.ClaseBDPlanilla, excep);
                throw excep;
            }
            catch (NullReferenceException ex)
            {
                BDPLanillaException excep = new BDPLanillaException(RecursosDAOModulo14.CodigoNullReferencesExcep,
                    RecursosDAOModulo14.MsjNullException, ex);
                Logger.EscribirError(RecursosDAOModulo14.ClaseBDPlanilla, excep);
                throw excep;
            }
            catch (ObjectDisposedException ex)
            {
                BDPLanillaException excep = new BDPLanillaException(RecursosDAOModulo14.CodigoDisposedObject,
                    RecursosDAOModulo14.MensajeDisposedException, ex);
                Logger.EscribirError(RecursosDAOModulo14.ClaseBDPlanilla, excep);
                throw excep;
            }
            catch (ExcepcionesSKD.ExceptionSKDConexionBD ex)
            {
                Logger.EscribirError(RecursosDAOModulo14.ClaseBDPlanilla, ex);

                throw ex;
            }
            catch (FormatException ex)
            {
                BDPLanillaException excep = new BDPLanillaException(RecursosDAOModulo14.CodigoFormatExceptio,
                    RecursosDAOModulo14.MsjFormatException, ex);
                Logger.EscribirError(RecursosDAOModulo14.ClaseBDPlanilla, excep);
                throw excep;
            }
            catch (Exception ex)
            {
                BDPLanillaException excep = new BDPLanillaException(RecursosDAOModulo14.CodigoException,
                    RecursosDAOModulo14.MsjException, ex);
                Logger.EscribirError(RecursosDAOModulo14.ClaseBDPlanilla, excep);
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
                RecursosDAOModulo14.MsjDeEntrada, System.Reflection.MethodBase.GetCurrentMethod().Name);
          //  BDConexion laConexion;
            List<Parametro> parametros;
            Parametro parametro = new Parametro();

            try
            {
               // laConexion = new BDConexion();
                this.Conectar();
                parametros = new List<Parametro>();

                parametro = new Parametro(RecursosDAOModulo14.ParametroTipoPlanilla,
                          SqlDbType.VarChar, nombreTipoPlanilla, false);
                parametros.Add(parametro);


                string query = RecursosDAOModulo14.ProcedimientoAgregarTipoPlanilla;
                List<Resultado> resultados = this.EjecutarStoredProcedure(query, parametros);


            }
            catch (SqlException ex)
            {
                BDPLanillaException excep = new BDPLanillaException(RecursoGeneralBD.Codigo,
                    RecursoGeneralBD.Mensaje, ex);
                Logger.EscribirError(RecursosDAOModulo14.ClaseBDPlanilla, excep);
                throw excep;
            }
            catch (IOException ex)
            {
                BDPLanillaException excep = new BDPLanillaException(RecursosDAOModulo14.CodigoIoException,
                    RecursosDAOModulo14.MsjExceptionIO, ex);
                Logger.EscribirError(RecursosDAOModulo14.ClaseBDPlanilla, excep);
                throw excep;
            }
            catch (NullReferenceException ex)
            {
                BDPLanillaException excep = new BDPLanillaException(RecursosDAOModulo14.CodigoNullReferencesExcep,
                    RecursosDAOModulo14.MsjNullException, ex);
                Logger.EscribirError(RecursosDAOModulo14.ClaseBDPlanilla, excep);
                throw excep;
            }
            catch (ObjectDisposedException ex)
            {
                BDPLanillaException excep = new BDPLanillaException(RecursosDAOModulo14.CodigoDisposedObject,
                    RecursosDAOModulo14.MensajeDisposedException, ex);
                Logger.EscribirError(RecursosDAOModulo14.ClaseBDPlanilla, excep);
                throw excep;
            }
            catch (ExcepcionesSKD.ExceptionSKDConexionBD ex)
            {
                Logger.EscribirError(RecursosDAOModulo14.ClaseBDPlanilla, ex);

                throw ex;
            }
            catch (FormatException ex)
            {
                BDPLanillaException excep = new BDPLanillaException(RecursosDAOModulo14.CodigoFormatExceptio,
                    RecursosDAOModulo14.MsjFormatException, ex);
                Logger.EscribirError(RecursosDAOModulo14.ClaseBDPlanilla, excep);
                throw excep;
            }
            catch (Exception ex)
            {
                BDPLanillaException excep = new BDPLanillaException(RecursosDAOModulo14.CodigoException,
                    RecursosDAOModulo14.MsjException, ex);
                Logger.EscribirError(RecursosDAOModulo14.ClaseBDPlanilla, excep);
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
                RecursosDAOModulo14.MsjDeEntrada, System.Reflection.MethodBase.GetCurrentMethod().Name);
           // BDConexion laConexion;
            int idTipolanilla;
            List<Parametro> parametros;
            Parametro parametro = new Parametro();

            try
            {
               // laConexion = new BDConexion();
                this.Conectar();
                parametros = new List<Parametro>();
                parametro = new Parametro(RecursosDAOModulo14.ParametroTipoPlanilla,
                        SqlDbType.VarChar, nombreTipo, false);
                parametros.Add(parametro);

                parametro = new Parametro(RecursosDAOModulo14.ParametroIdTipoPlanilla,
                      SqlDbType.VarChar, true);
                parametros.Add(parametro);

                string query = RecursosDAOModulo14.ProcedimientoObtenerIdTipoPlanilla;
                List<Resultado> resultados = this.EjecutarStoredProcedure(query, parametros);
                if (resultados[0].valor == "")
                    idTipolanilla = -1;
                else
                    idTipolanilla = Int32.Parse(resultados[0].valor.ToString());

            }
            catch (SqlException ex)
            {
                BDPLanillaException excep = new BDPLanillaException(RecursoGeneralBD.Codigo,
                    RecursoGeneralBD.Mensaje, ex);
                Logger.EscribirError(RecursosDAOModulo14.ClaseBDPlanilla, excep);
                throw excep;
            }
            catch (IOException ex)
            {
                BDPLanillaException excep = new BDPLanillaException(RecursosDAOModulo14.CodigoIoException,
                    RecursosDAOModulo14.MsjExceptionIO, ex);
                Logger.EscribirError(RecursosDAOModulo14.ClaseBDPlanilla, excep);
                throw excep;
            }
            catch (NullReferenceException ex)
            {
                BDPLanillaException excep = new BDPLanillaException(RecursosDAOModulo14.CodigoNullReferencesExcep,
                    RecursosDAOModulo14.MsjNullException, ex);
                Logger.EscribirError(RecursosDAOModulo14.ClaseBDPlanilla, excep);
                throw excep;
            }
            catch (ObjectDisposedException ex)
            {
                BDPLanillaException excep = new BDPLanillaException(RecursosDAOModulo14.CodigoDisposedObject,
                    RecursosDAOModulo14.MensajeDisposedException, ex);
                Logger.EscribirError(RecursosDAOModulo14.ClaseBDPlanilla, excep);
                throw excep;
            }
            catch (ExcepcionesSKD.ExceptionSKDConexionBD ex)
            {
                Logger.EscribirError(RecursosDAOModulo14.ClaseBDPlanilla, ex);

                throw ex;
            }
            catch (FormatException ex)
            {
                BDPLanillaException excep = new BDPLanillaException(RecursosDAOModulo14.CodigoFormatExceptio,
                    RecursosDAOModulo14.MsjFormatException, ex);
                Logger.EscribirError(RecursosDAOModulo14.ClaseBDPlanilla, excep);
                throw excep;
            }
            catch (Exception ex)
            {
                BDPLanillaException excep = new BDPLanillaException(RecursosDAOModulo14.CodigoException,
                    RecursosDAOModulo14.MsjException, ex);
                Logger.EscribirError(RecursosDAOModulo14.ClaseBDPlanilla, excep);
                throw excep;
            }

            return idTipolanilla;
        }

       

        /// <summary>
        /// Obtiene los datos de una planilla id
        /// </summary>
        /// /// <param name="idPlanilla">id planilla</param>
        /// <returns>datos de una planilla</returns>
        public List<String> ObtenerDatosPlanillaID(int idPlanilla)
        {
            Logger.EscribirInfo(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name,
                RecursosDAOModulo14.MsjDeEntrada, System.Reflection.MethodBase.GetCurrentMethod().Name);
          //  BDConexion laConexion;
            List<Parametro> parametros;
            Parametro parametro = new Parametro();
            List<String> listDatos = new List<String>();
            try
            {
            //    laConexion = new BDConexion();
                this.Conectar();
                parametros = new List<Parametro>();
                parametro = new Parametro(RecursosDAOModulo14.ParametroIdPlanilla,
                SqlDbType.VarChar, idPlanilla.ToString(), false);
                parametros.Add(parametro);

                DataTable resultadoConsulta = this.EjecutarStoredProcedureTuplas(RecursosDAOModulo14.ProcedureConsultarDatosPlanillaId, parametros);

                foreach (DataRow row in resultadoConsulta.Rows)
                {
                    listDatos.Add(row[RecursosDAOModulo14.AtributoNombre_Dato].ToString());

                }

            }
            catch (SqlException ex)
            {
                BDPLanillaException excep = new BDPLanillaException(RecursoGeneralBD.Codigo,
                    RecursoGeneralBD.Mensaje, ex);
                Logger.EscribirError(RecursosDAOModulo14.ClaseBDPlanilla, excep);
                throw excep;
            }
            catch (IOException ex)
            {
                BDPLanillaException excep = new BDPLanillaException(RecursosDAOModulo14.CodigoIoException,
                    RecursosDAOModulo14.MsjExceptionIO, ex);
                Logger.EscribirError(RecursosDAOModulo14.ClaseBDPlanilla, excep);
                throw excep;
            }
            catch (NullReferenceException ex)
            {
                BDPLanillaException excep = new BDPLanillaException(RecursosDAOModulo14.CodigoNullReferencesExcep,
                    RecursosDAOModulo14.MsjNullException, ex);
                Logger.EscribirError(RecursosDAOModulo14.ClaseBDPlanilla, excep);
                throw excep;
            }
            catch (ObjectDisposedException ex)
            {
                BDPLanillaException excep = new BDPLanillaException(RecursosDAOModulo14.CodigoDisposedObject,
                    RecursosDAOModulo14.MensajeDisposedException, ex);
                Logger.EscribirError(RecursosDAOModulo14.ClaseBDPlanilla, excep);
                throw excep;
            }
            catch (ExcepcionesSKD.ExceptionSKDConexionBD ex)
            {
                Logger.EscribirError(RecursosDAOModulo14.ClaseBDPlanilla, ex);

                throw ex;
            }
            catch (FormatException ex)
            {
                BDPLanillaException excep = new BDPLanillaException(RecursosDAOModulo14.CodigoFormatExceptio,
                    RecursosDAOModulo14.MsjFormatException, ex);
                Logger.EscribirError(RecursosDAOModulo14.ClaseBDPlanilla, excep);
                throw excep;
            }
            catch (Exception ex)
            {
                BDPLanillaException excep = new BDPLanillaException(RecursosDAOModulo14.CodigoException,
                    RecursosDAOModulo14.MsjException, ex);
                Logger.EscribirError(RecursosDAOModulo14.ClaseBDPlanilla, excep);
                throw excep;
            }

            return listDatos;
        }

        /// <summary>
        /// Obtiene los datos de una planilla id
        /// </summary>
        /// /// <param name="idPlanilla">id planilla</param>
        /// <returns>datos de una planilla</returns>
        public List<String> ObtenerDatosPlanillaID1(int idPlanilla)
        {
            Logger.EscribirInfo(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name,
                RecursosDAOModulo14.MsjDeEntrada, System.Reflection.MethodBase.GetCurrentMethod().Name);
          //  BDConexion laConexion;
            List<Parametro> parametros;
            Parametro parametro = new Parametro();
            List<String> listDatos = new List<String>();
            try
            {
              //  laConexion = new BDConexion();
                this.Conectar();
                parametros = new List<Parametro>();
                parametro = new Parametro(RecursosDAOModulo14.ParametroIdPlanilla,
                SqlDbType.VarChar, idPlanilla.ToString(), false);
                parametros.Add(parametro);

                DataTable resultadoConsulta = this.EjecutarStoredProcedureTuplas(RecursosDAOModulo14.ProcedureConsultarDatosPlanillaId, parametros);

                foreach (DataRow row in resultadoConsulta.Rows)
                {
                    listDatos.Add(row[RecursosDAOModulo14.AtributoNombre_Dato].ToString());

                }

            }
            catch (SqlException ex)
            {
                BDPLanillaException excep = new BDPLanillaException(RecursoGeneralBD.Codigo,
                    RecursoGeneralBD.Mensaje, ex);
                Logger.EscribirError(RecursosDAOModulo14.ClaseBDPlanilla, excep);
                throw excep;
            }
            catch (IOException ex)
            {
                BDPLanillaException excep = new BDPLanillaException(RecursosDAOModulo14.CodigoIoException,
                    RecursosDAOModulo14.MsjExceptionIO, ex);
                Logger.EscribirError(RecursosDAOModulo14.ClaseBDPlanilla, excep);
                throw excep;
            }
            catch (NullReferenceException ex)
            {
                BDPLanillaException excep = new BDPLanillaException(RecursosDAOModulo14.CodigoNullReferencesExcep,
                    RecursosDAOModulo14.MsjNullException, ex);
                Logger.EscribirError(RecursosDAOModulo14.ClaseBDPlanilla, excep);
                throw excep;
            }
            catch (ObjectDisposedException ex)
            {
                BDPLanillaException excep = new BDPLanillaException(RecursosDAOModulo14.CodigoDisposedObject,
                    RecursosDAOModulo14.MensajeDisposedException, ex);
                Logger.EscribirError(RecursosDAOModulo14.ClaseBDPlanilla, excep);
                throw excep;
            }
            catch (ExcepcionesSKD.ExceptionSKDConexionBD ex)
            {
                Logger.EscribirError(RecursosDAOModulo14.ClaseBDPlanilla, ex);

                throw ex;
            }
            catch (FormatException ex)
            {
                BDPLanillaException excep = new BDPLanillaException(RecursosDAOModulo14.CodigoFormatExceptio,
                    RecursosDAOModulo14.MsjFormatException, ex);
                Logger.EscribirError(RecursosDAOModulo14.ClaseBDPlanilla, excep);
                throw excep;
            }
            catch (Exception ex)
            {
                BDPLanillaException excep = new BDPLanillaException(RecursosDAOModulo14.CodigoException,
                    RecursosDAOModulo14.MsjException, ex);
                Logger.EscribirError(RecursosDAOModulo14.ClaseBDPlanilla, excep);
                throw excep;
            }

            return listDatos;
        }


        /// <summary>
        /// Modifica una planilla en la base de datos
        /// </summary>
        /// <param name="idPlanilla">La planilla</param>
        /// <returns>returna true en caso de que se completara el registro, y false en caso de que no</returns>
        public Boolean EliminarDatosPlanillaBD(int idPlanilla)
        {
            Logger.EscribirInfo(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name,
                RecursosDAOModulo14.MsjDeEntrada, System.Reflection.MethodBase.GetCurrentMethod().Name);
            //BDConexion laConexion;
            List<Parametro> parametros;
            Parametro parametro = new Parametro();

            try
            {
                //laConexion = new BDConexion();
                this.Conectar();
                parametros = new List<Parametro>();
                parametro = new Parametro(RecursosDAOModulo14.ParametroIdPlanilla,
                SqlDbType.VarChar, idPlanilla.ToString(), false);
                parametros.Add(parametro);


                string query = RecursosDAOModulo14.ProcedureEliminarDatosPlanilla;
                List<Resultado> resultados = this.EjecutarStoredProcedure(query, parametros);

            }
            catch (SqlException ex)
            {
                BDPLanillaException excep = new BDPLanillaException(RecursoGeneralBD.Codigo,
                    RecursoGeneralBD.Mensaje, ex);
                Logger.EscribirError(RecursosDAOModulo14.ClaseBDPlanilla, excep);
                throw excep;
            }
            catch (IOException ex)
            {
                BDPLanillaException excep = new BDPLanillaException(RecursosDAOModulo14.CodigoIoException,
                    RecursosDAOModulo14.MsjExceptionIO, ex);
                Logger.EscribirError(RecursosDAOModulo14.ClaseBDPlanilla, excep);
                throw excep;
            }
            catch (NullReferenceException ex)
            {
                BDPLanillaException excep = new BDPLanillaException(RecursosDAOModulo14.CodigoNullReferencesExcep,
                    RecursosDAOModulo14.MsjNullException, ex);
                Logger.EscribirError(RecursosDAOModulo14.ClaseBDPlanilla, excep);
                throw excep;
            }
            catch (ObjectDisposedException ex)
            {
                BDPLanillaException excep = new BDPLanillaException(RecursosDAOModulo14.CodigoDisposedObject,
                    RecursosDAOModulo14.MensajeDisposedException, ex);
                Logger.EscribirError(RecursosDAOModulo14.ClaseBDPlanilla, excep);
                throw excep;
            }
            catch (ExcepcionesSKD.ExceptionSKDConexionBD ex)
            {
                Logger.EscribirError(RecursosDAOModulo14.ClaseBDPlanilla, ex);

                throw ex;
            }
            catch (FormatException ex)
            {
                BDPLanillaException excep = new BDPLanillaException(RecursosDAOModulo14.CodigoFormatExceptio,
                    RecursosDAOModulo14.MsjFormatException, ex);
                Logger.EscribirError(RecursosDAOModulo14.ClaseBDPlanilla, excep);
                throw excep;
            }
            catch (Exception ex)
            {
                BDPLanillaException excep = new BDPLanillaException(RecursosDAOModulo14.CodigoException,
                    RecursosDAOModulo14.MsjException, ex);
                Logger.EscribirError(RecursosDAOModulo14.ClaseBDPlanilla, excep);
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
                RecursosDAOModulo14.MsjDeEntrada, System.Reflection.MethodBase.GetCurrentMethod().Name);
            //BDConexion laConexion;
            List<Parametro> parametros;
            Parametro parametro = new Parametro();

            try
            {
              //  laConexion = new BDConexion();
                parametros = new List<Parametro>();
                this.Conectar();
                parametro = new Parametro(RecursosDAOModulo14.ParametroIdPlanilla,
                          SqlDbType.VarChar, idPlanilla.ToString(), false);
                parametros.Add(parametro);
                parametro = new Parametro(RecursosDAOModulo14.ParametroNombreDato,
                                          SqlDbType.VarChar, datoPlanilla, false);
                parametros.Add(parametro);

                string query = RecursosDAOModulo14.ProcedureAgregarDatoPlanillaID;
                List<Resultado> resultados = this.EjecutarStoredProcedure(query, parametros);
            }
            catch (SqlException ex)
            {
                BDPLanillaException excep = new BDPLanillaException(RecursoGeneralBD.Codigo,
                    RecursoGeneralBD.Mensaje, ex);
                Logger.EscribirError(RecursosDAOModulo14.ClaseBDPlanilla, excep);
                throw excep;
            }
            catch (IOException ex)
            {
                BDPLanillaException excep = new BDPLanillaException(RecursosDAOModulo14.CodigoIoException,
                    RecursosDAOModulo14.MsjExceptionIO, ex);
                Logger.EscribirError(RecursosDAOModulo14.ClaseBDPlanilla, excep);
                throw excep;
            }
            catch (NullReferenceException ex)
            {
                BDPLanillaException excep = new BDPLanillaException(RecursosDAOModulo14.CodigoNullReferencesExcep,
                    RecursosDAOModulo14.MsjNullException, ex);
                Logger.EscribirError(RecursosDAOModulo14.ClaseBDPlanilla, excep);
                throw excep;
            }
            catch (ObjectDisposedException ex)
            {
                BDPLanillaException excep = new BDPLanillaException(RecursosDAOModulo14.CodigoDisposedObject,
                    RecursosDAOModulo14.MensajeDisposedException, ex);
                Logger.EscribirError(RecursosDAOModulo14.ClaseBDPlanilla, excep);
                throw excep;
            }
            catch (ExcepcionesSKD.ExceptionSKDConexionBD ex)
            {
                Logger.EscribirError(RecursosDAOModulo14.ClaseBDPlanilla, ex);

                throw ex;
            }
            catch (FormatException ex)
            {
                BDPLanillaException excep = new BDPLanillaException(RecursosDAOModulo14.CodigoFormatExceptio,
                    RecursosDAOModulo14.MsjFormatException, ex);
                Logger.EscribirError(RecursosDAOModulo14.ClaseBDPlanilla, excep);
                throw excep;
            }
            catch (Exception ex)
            {
                BDPLanillaException excep = new BDPLanillaException(RecursosDAOModulo14.CodigoException,
                    RecursosDAOModulo14.MsjException, ex);
                Logger.EscribirError(RecursosDAOModulo14.ClaseBDPlanilla, excep);
                throw excep;
            }
            return true;
        }

        /// <summary>
        /// Método que consulta todas las planillas creadas
        /// </summary>
        /// <returns>Lista de planillas creadas</returns>
        public List<Entidad> ConsultarPlanillasCreadas()
        {
            Logger.EscribirInfo(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name,
                RecursosDAOModulo14.MsjDeEntrada, System.Reflection.MethodBase.GetCurrentMethod().Name);
            SqlConnection conect = Conectar();
            List<Entidad> lista = new List<Entidad>();
            FabricaEntidades fabrica = new FabricaEntidades();
            DominioSKD.Entidades.Modulo14.Planilla planilla;
            try
            {

                SqlCommand sqlcom = new SqlCommand(RecursosDAOModulo14.ProcedureConsultarPlanillasCreadas, conect);
                sqlcom.CommandType = CommandType.StoredProcedure;

                SqlDataReader leer;
                conect.Open();

                leer = sqlcom.ExecuteReader();
                if (leer != null)
                {
                    while (leer.Read())
                    {
                        planilla = new DominioSKD.Entidades.Modulo14.Planilla();
                        planilla.ID = Convert.ToInt32(leer[RecursosDAOModulo14.AtributoIdPlanilla]);
                        planilla.Nombre = leer[RecursosDAOModulo14.AtributoNombrePlanilla].ToString();
                        planilla.Status = Convert.ToBoolean(leer[RecursosDAOModulo14.AtributoStatusPlanilla]);
                        planilla.TipoPlanilla = leer[RecursosDAOModulo14.AtributoNombreTipoPlanilla].ToString();
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
                Logger.EscribirError(RecursosDAOModulo14.ClaseBDPlanilla, excep);
                throw excep;
            }
            catch (IOException ex)
            {
                BDPLanillaException excep = new BDPLanillaException(RecursosDAOModulo14.CodigoIoException,
                    RecursosDAOModulo14.MsjExceptionIO, ex);
                Logger.EscribirError(RecursosDAOModulo14.ClaseBDPlanilla, excep);
                throw excep;
            }
            catch (NullReferenceException ex)
            {
                BDPLanillaException excep = new BDPLanillaException(RecursosDAOModulo14.CodigoNullReferencesExcep,
                    RecursosDAOModulo14.MsjNullException, ex);
                Logger.EscribirError(RecursosDAOModulo14.ClaseBDPlanilla, excep);
                throw excep;
            }
            catch (ObjectDisposedException ex)
            {
                BDPLanillaException excep = new BDPLanillaException(RecursosDAOModulo14.CodigoDisposedObject,
                    RecursosDAOModulo14.MensajeDisposedException, ex);
                Logger.EscribirError(RecursosDAOModulo14.ClaseBDPlanilla, excep);
                throw excep;
            }
            catch (ExcepcionesSKD.ExceptionSKDConexionBD ex)
            {
                Logger.EscribirError(RecursosDAOModulo14.ClaseBDPlanilla, ex);

                throw ex;
            }
            catch (FormatException ex)
            {
                BDPLanillaException excep = new BDPLanillaException(RecursosDAOModulo14.CodigoFormatExceptio,
                    RecursosDAOModulo14.MsjFormatException, ex);
                Logger.EscribirError(RecursosDAOModulo14.ClaseBDPlanilla, excep);
                throw excep;
            }
            catch (Exception ex)
            {
                BDPLanillaException excep = new BDPLanillaException(RecursosDAOModulo14.CodigoException,
                    RecursosDAOModulo14.MsjException, ex);
                Logger.EscribirError(RecursosDAOModulo14.ClaseBDPlanilla, excep);
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
