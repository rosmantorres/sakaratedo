using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using DominioSKD;
using DominioSKD.Entidades.Modulo8;
using ExcepcionesSKD;

namespace DatosSKD.DAO.Modulo8
{
    public class DAORestriccionEvento : DAOGeneral, InterfazDAO.Modulo8.IDaoRestriccionEvento
    {

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

        #region AgregarRestriccionEvento
        /// <summary>
        /// Metodo para agregar una restriccion de evento a la base de datos.
        /// </summary>
        /// <param name="parametro">objeto de tipo RestriccionEvento para agregar en bd</param>
        /// <returns>true si fue eliminado</returns>
        public Boolean AgregarRestriccionEvento(DominioSKD.Entidad parametro)
        {
            DominioSKD.Entidades.Modulo8.RestriccionEvento laRestriccionEvento =
                (DominioSKD.Entidades.Modulo8.RestriccionEvento)parametro;

            try
            {
                List<Parametro> parametros = new List<Parametro>();

                Parametro elParametro = new Parametro(RecursosDAORestriccionEvento.ParamDescripcionRestricionEvento, SqlDbType.VarChar,
                        laRestriccionEvento.Descripcion, false);
                parametros.Add(elParametro);

                elParametro = new Parametro(RecursosDAORestriccionEvento.ParamEdadMinimaRestricionEvento, SqlDbType.Int,
                        laRestriccionEvento.EdadMinima.ToString(), false);
                parametros.Add(elParametro);

                elParametro = new Parametro(RecursosDAORestriccionEvento.ParamEdadMaximaRestricionEvento, SqlDbType.Int,
                        laRestriccionEvento.EdadMaxima.ToString(), false);
                parametros.Add(elParametro);

                elParametro = new Parametro(RecursosDAORestriccionEvento.ParamSexoRestricionEvento, SqlDbType.VarChar,
                        laRestriccionEvento.Sexo.ToString(), false);
                parametros.Add(elParametro);

                elParametro = new Parametro(RecursosDAORestriccionEvento.ParamIdEvento, SqlDbType.Int,
                        laRestriccionEvento.IdEvento.ToString(), false);
                parametros.Add(elParametro);

                List<Resultado> resultados = this.EjecutarStoredProcedure(RecursosDAORestriccionEvento.AgregarRestriccionEvento
                                             , parametros);
            }

            catch (SqlException ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                Console.Out.WriteLine("1" + " " + ex.Message);
                throw new ExcepcionesSKD.ExceptionSKDConexionBD(RecursoGeneralBD.Codigo,
                    RecursoGeneralBD.Mensaje, ex);
            }
            catch (FormatException ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                Console.Out.WriteLine("1" + " " + ex.Message);
                throw new ExcepcionesSKD.Modulo8.FormatoIncorrectoException(RecursosDAORestriccionEvento.CodigoErrorFormato,
                     RecursosDAORestriccionEvento.MensajeErrorFormato, ex);
            }
            catch (ExcepcionesSKD.ExceptionSKDConexionBD ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                Console.Out.WriteLine("1" + " " + ex.Message);
                throw ex;
            }
            catch (Exception ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                Console.Out.WriteLine("1" + " " + ex.Message);
                throw new ExcepcionesSKD.ExceptionSKD(RecursoGeneralBD.Mensaje_Generico_Error, ex);
            }


            return true;
        }
        #endregion

        #region ConsultarEventosConRestriccion
        /// <summary>
        /// Metodo para consultar todas las Restricciones de Eventos.
        /// </summary>
        /// <returns>Lista de todas las RestriccionesEventos que existen</returns>
        public List<DominioSKD.Entidad> ConsultarEventosConRestriccion()
        {
            List<Parametro> parametros = new List<Parametro>();

            List<DominioSKD.Entidad> laListaRestriccionesEvento = new List<DominioSKD.Entidad>();
            DominioSKD.Fabrica.FabricaEntidades fabricaEntidad = new DominioSKD.Fabrica.FabricaEntidades();

            try
            {
                this.Conectar();

                DataTable dt = this.EjecutarStoredProcedureTuplas(
                               RecursosDAORestriccionEvento.ConsultarEventosConRestriccion, parametros);

                foreach (DataRow row in dt.Rows)
                {
                    int IdRestEvento = int.Parse(row[RecursosDAORestriccionEvento.AliasIdRestriccionEvento].ToString());
                    String Descripcion = row[RecursosDAORestriccionEvento.AliasResDescripcion].ToString();
                    int EdadMinima = int.Parse(row[RecursosDAORestriccionEvento.AliasEdadMin].ToString());
                    int EdadMaxima = int.Parse(row[RecursosDAORestriccionEvento.AliasEdadMax].ToString());
                    String Sexo = row[RecursosDAORestriccionEvento.AliasSexo].ToString();
                    int IdEvento = int.Parse(row[RecursosDAORestriccionEvento.AliasIdEvento].ToString());
                    String NombreEvento = row[RecursosDAORestriccionEvento.AliasNombreEve].ToString();
                    int statusResEvento = int.Parse(row[RecursosDAORestriccionEvento.AliasStatus].ToString());

                    Entidad laRestriccionEvento = DominioSKD.Fabrica.FabricaEntidades.ObtenerRestriccionEvento(IdRestEvento, Descripcion, EdadMinima, EdadMaxima, Sexo, IdEvento, NombreEvento, statusResEvento);
                    laListaRestriccionesEvento.Add(laRestriccionEvento);
                }

            }
            catch (SqlException ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                Console.Out.WriteLine("1" + " " + ex.Message);
                throw new ExcepcionesSKD.ExceptionSKDConexionBD(RecursoGeneralBD.Codigo,
                    RecursoGeneralBD.Mensaje, ex);
            }
            catch (FormatException ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                Console.Out.WriteLine("1" + " " + ex.Message);
                throw new ExcepcionesSKD.Modulo8.FormatoIncorrectoException(RecursosDAORestriccionEvento.CodigoErrorFormato,
                     RecursosDAORestriccionEvento.MensajeErrorFormato, ex);
            }
            catch (ExcepcionesSKD.ExceptionSKDConexionBD ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                Console.Out.WriteLine("1" + " " + ex.Message);
                throw ex;
            }
            catch (Exception ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                Console.Out.WriteLine("1" + " " + ex.Message);
                throw new ExcepcionesSKD.ExceptionSKD(RecursoGeneralBD.Mensaje_Generico_Error, ex);
            }

            return laListaRestriccionesEvento;
        }
        #endregion

        #region ConsultarEventosSinsRestriccion
        /// <summary>
        /// Metodo para consultar los eventos que no tienen restricciones aun.
        /// </summary>
        /// <returns>Lista de EventoSimple que no tienen Restriccion</returns>
        public List<Entidad> ConsultarEventosSinRestriccion()
        {
            List<Parametro> parametros = new List<Parametro>();

            List<Entidad> losEventosSimple = new List<Entidad>();
            DominioSKD.Fabrica.FabricaEntidades fabricaEntidad = new DominioSKD.Fabrica.FabricaEntidades();
            try
            {
                this.Conectar();
                DataTable dt = this.EjecutarStoredProcedureTuplas(
                               RecursosDAORestriccionEvento.ConsultarEventosSinRestriccion, parametros);

                foreach (DataRow row in dt.Rows)
                {
                    int IdEvento = int.Parse(row[RecursosDAORestriccionEvento.AliasIdEvento].ToString());
                    String NombreEvento = row[RecursosDAORestriccionEvento.AliasNombreEvento].ToString();

                    Entidad elEvento = DominioSKD.Fabrica.FabricaEntidades.ObtenerEventoSimple(IdEvento, NombreEvento);

                    losEventosSimple.Add(elEvento);
                }

            }
            catch (SqlException ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                Console.Out.WriteLine("1" + " " + ex.Message);
                throw new ExcepcionesSKD.ExceptionSKDConexionBD(RecursoGeneralBD.Codigo,
                    RecursoGeneralBD.Mensaje, ex);
            }
            catch (FormatException ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                Console.Out.WriteLine("1" + " " + ex.Message);
                throw new ExcepcionesSKD.Modulo8.FormatoIncorrectoException(RecursosDAORestriccionEvento.CodigoErrorFormato,
                     RecursosDAORestriccionEvento.MensajeErrorFormato, ex);
            }
            catch (ExcepcionesSKD.ExceptionSKDConexionBD ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                Console.Out.WriteLine("1" + " " + ex.Message);
                throw ex;
            }
            catch (Exception ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                Console.Out.WriteLine("1" + " " + ex.Message);
                throw new ExcepcionesSKD.ExceptionSKD(RecursoGeneralBD.Mensaje_Generico_Error, ex);
            }

            return losEventosSimple;
        }
        #endregion

        #region ConsultarRestriccionEvento
        /// <summary>
        /// Metodo para consultar la RestriccionEvento de un evento especifico en la base de datos.
        /// </summary>
        /// <param name="parametro">EventoSimple a consultar restriccion con su id</param>
        /// <returns>Objeto de tipo RestriccionEvento con todos los datos</returns>
        public DominioSKD.Entidad ConsultarRestriccionEvento(DominioSKD.Entidad parametro)
        {
            DominioSKD.Entidades.Modulo8.EventoSimple elEventoSimple =
                (DominioSKD.Entidades.Modulo8.EventoSimple)parametro;

            DominioSKD.Fabrica.FabricaEntidades fabricaEntidad = new DominioSKD.Fabrica.FabricaEntidades();
            Entidad laRestriccionEvento = DominioSKD.Fabrica.FabricaEntidades.ObtenerRestriccionEvento();

            try
            {
                List<Parametro> parametros = new List<Parametro>();
                Parametro elParametro = new Parametro(RecursosDAORestriccionEvento.ParamIdEvento, SqlDbType.Int,
                    elEventoSimple.IdEvento.ToString(), false);

                parametros.Add(elParametro);


                this.Conectar();

                DataTable dt = this.EjecutarStoredProcedureTuplas(
                               RecursosDAORestriccionEvento.ConsultarRestriccionEvento, parametros);

                foreach (DataRow row in dt.Rows)
                {
                    int IdRestEvento = int.Parse(row[RecursosDAORestriccionEvento.AliasIdRestriccionEvento].ToString());
                    String Descripcion = row[RecursosDAORestriccionEvento.AliasResDescripcion].ToString();
                    int EdadMinima = int.Parse(row[RecursosDAORestriccionEvento.AliasEdadMin].ToString());
                    int EdadMaxima = int.Parse(row[RecursosDAORestriccionEvento.AliasEdadMax].ToString());
                    String Sexo = row[RecursosDAORestriccionEvento.AliasSexo].ToString();
                    int IdEvento = int.Parse(row[RecursosDAORestriccionEvento.AliasIdEvento].ToString());
                    String NombreEvento = row[RecursosDAORestriccionEvento.AliasNombreEve].ToString();
                    int statusResEvento = int.Parse(row[RecursosDAORestriccionEvento.AliasStatus].ToString());

                    laRestriccionEvento = DominioSKD.Fabrica.FabricaEntidades.ObtenerRestriccionEvento(IdRestEvento, Descripcion, EdadMinima, EdadMaxima, Sexo, IdEvento, NombreEvento, statusResEvento);
                }
            }
            catch (SqlException ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                Console.Out.WriteLine("1" + " " + ex.Message);
                throw new ExcepcionesSKD.ExceptionSKDConexionBD(RecursoGeneralBD.Codigo,
                    RecursoGeneralBD.Mensaje, ex);
            }
            catch (FormatException ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                Console.Out.WriteLine("1" + " " + ex.Message);
                throw new ExcepcionesSKD.Modulo8.FormatoIncorrectoException(RecursosDAORestriccionEvento.CodigoErrorFormato,
                     RecursosDAORestriccionEvento.MensajeErrorFormato, ex);
            }
            catch (ExcepcionesSKD.ExceptionSKDConexionBD ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                Console.Out.WriteLine("1" + " " + ex.Message);
                throw ex;
            }
            catch (Exception ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                Console.Out.WriteLine("1" + " " + ex.Message);
                throw new ExcepcionesSKD.ExceptionSKD(RecursoGeneralBD.Mensaje_Generico_Error, ex);
            }

            return laRestriccionEvento;
        }
        #endregion

        #region EliminarRestriccionEvento
        /// <summary>
        /// Metodo para eliminar una restriccion de evento en la base de datos.
        /// </summary>
        /// <param name="parametro"> int id de la RestriccioEvento para ser modificado en bd</param>
        /// <returns>true si fue eliminado</returns>
        public Boolean EliminarRestriccionEvento(DominioSKD.Entidad parametro)
        {
            DominioSKD.Entidades.Modulo8.RestriccionEvento laRestriccionEvento =
                (DominioSKD.Entidades.Modulo8.RestriccionEvento)parametro;

            try
            {
                List<Parametro> parametros = new List<Parametro>();

                Parametro elParametro = new Parametro(RecursosDAORestriccionEvento.ParamIdRestriccionEvento, SqlDbType.Int,
                    laRestriccionEvento.IdRestEvento.ToString(), false);

                parametros.Add(elParametro);

                elParametro = new Parametro(RecursosDAORestriccionEvento.ParamStatus, SqlDbType.Int,
                            laRestriccionEvento.Status.ToString(), false);
                parametros.Add(elParametro);

                List<Resultado> resultados = this.EjecutarStoredProcedure(RecursosDAORestriccionEvento.EliminarRestriccionEvento
                                             , parametros);
            }

            catch (SqlException ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                Console.Out.WriteLine("1" + " " + ex.Message);
                throw new ExcepcionesSKD.ExceptionSKDConexionBD(RecursoGeneralBD.Codigo,
                    RecursoGeneralBD.Mensaje, ex);
            }
            catch (FormatException ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                Console.Out.WriteLine("1" + " " + ex.Message);
                throw new ExcepcionesSKD.Modulo8.FormatoIncorrectoException(RecursosDAORestriccionEvento.CodigoErrorFormato,
                     RecursosDAORestriccionEvento.MensajeErrorFormato, ex);
            }
            catch (ExcepcionesSKD.ExceptionSKDConexionBD ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                Console.Out.WriteLine("1" + " " + ex.Message);
                throw ex;
            }
            catch (Exception ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                Console.Out.WriteLine("1" + " " + ex.Message);
                throw new ExcepcionesSKD.ExceptionSKD(RecursoGeneralBD.Mensaje_Generico_Error, ex);
            }


            return true;
        }
        #endregion

        #region EventosQuePuedeAsistirAtleta
        /// <summary>
        /// Metodo para consultar eventos que puede asistir un atleta.
        /// </summary>
        /// <param name="parametro">int id de la persona a consultar eventos que puede asistir</param>
        /// <returns>Lista de EventoSimple a los que puede asistir</returns>
        public List<Entidad> EventosQuePuedeAsistirAtleta(int parametro)
        {
            List<Parametro> parametros = new List<Parametro>();

            List<Entidad> laListaEventosSimple = new List<Entidad>();
            DominioSKD.Fabrica.FabricaEntidades fabricaEntidad = new DominioSKD.Fabrica.FabricaEntidades();

            Parametro elParametro = new Parametro(RecursosDAORestriccionEvento.ParamIdPersona, SqlDbType.Int,
                    parametro.ToString(), false);

            parametros.Add(elParametro);

            try
            {
                this.Conectar();

                DataTable dt = this.EjecutarStoredProcedureTuplas(
                               RecursosDAORestriccionEvento.ConsultarEventosCumplaREAtleta, parametros);

                foreach (DataRow row in dt.Rows)
                {
                    EventoSimple elEvento = new EventoSimple();

                    int IdEvento = int.Parse(row[RecursosDAORestriccionEvento.AliasIdEvento].ToString());
                    String NombreEvento = row[RecursosDAORestriccionEvento.AliasNombreEvento].ToString();

                    Entidad elEventoSimple = DominioSKD.Fabrica.FabricaEntidades.ObtenerEventoSimple(IdEvento, NombreEvento);
                    laListaEventosSimple.Add(elEventoSimple);

                }

            }
            catch (SqlException ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                Console.Out.WriteLine("1" + " " + ex.Message);
                throw new ExcepcionesSKD.ExceptionSKDConexionBD(RecursoGeneralBD.Codigo,
                    RecursoGeneralBD.Mensaje, ex);
            }
            catch (FormatException ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                Console.Out.WriteLine("1" + " " + ex.Message);
                throw new ExcepcionesSKD.Modulo8.FormatoIncorrectoException(RecursosDAORestriccionEvento.CodigoErrorFormato,
                     RecursosDAORestriccionEvento.MensajeErrorFormato, ex);
            }
            catch (ExcepcionesSKD.ExceptionSKDConexionBD ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                Console.Out.WriteLine("1" + " " + ex.Message);
                throw ex;
            }
            catch (Exception ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                Console.Out.WriteLine("1" + " " + ex.Message);
                throw new ExcepcionesSKD.ExceptionSKD(RecursoGeneralBD.Mensaje_Generico_Error, ex);
            }

            return laListaEventosSimple;
        }
        #endregion
    
        #region ModificarRestriccionEvento
        /// <summary>
        /// Metodo para modificar una restriccion de evento a la base de datos.
        /// </summary>
        /// <param name="parametro"> objeto RestriccionEvento para modificar en bd</param>
        /// <returns>true si fue modificado</returns>
        public Boolean ModificarRestriccionEvento(DominioSKD.Entidad parametro)
        {
            DominioSKD.Entidades.Modulo8.RestriccionEvento laRestriccionEvento =
                    (DominioSKD.Entidades.Modulo8.RestriccionEvento)parametro;
            try
            {
                List<Parametro> parametros = new List<Parametro>();

                Parametro elParametro = new Parametro(RecursosDAORestriccionEvento.ParamIdRestriccionEvento, SqlDbType.Int,
                        laRestriccionEvento.IdRestEvento.ToString(), false);
                parametros.Add(elParametro);

                elParametro = new Parametro(RecursosDAORestriccionEvento.ParamDescripcionRestricionEvento, SqlDbType.VarChar,
                        laRestriccionEvento.Descripcion, false);
                parametros.Add(elParametro);

                elParametro = new Parametro(RecursosDAORestriccionEvento.ParamEdadMinimaRestricionEvento, SqlDbType.Int,
                        laRestriccionEvento.EdadMinima.ToString(), false);
                parametros.Add(elParametro);

                elParametro = new Parametro(RecursosDAORestriccionEvento.ParamEdadMaximaRestricionEvento, SqlDbType.Int,
                        laRestriccionEvento.EdadMaxima.ToString(), false);
                parametros.Add(elParametro);

                elParametro = new Parametro(RecursosDAORestriccionEvento.ParamSexoRestricionEvento, SqlDbType.VarChar,
                        laRestriccionEvento.Sexo.ToString(), false);
                parametros.Add(elParametro);

                elParametro = new Parametro(RecursosDAORestriccionEvento.ParamIdEvento, SqlDbType.Int,
                        laRestriccionEvento.IdEvento.ToString(), false);
                parametros.Add(elParametro);

                List<Resultado> resultados = this.EjecutarStoredProcedure(RecursosDAORestriccionEvento.ModificarRestriccionEvento
                                             , parametros);
            }

            catch (SqlException ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                Console.Out.WriteLine("1" + " " + ex.Message);
                throw new ExcepcionesSKD.ExceptionSKDConexionBD(RecursoGeneralBD.Codigo,
                    RecursoGeneralBD.Mensaje, ex);
            }
            catch (FormatException ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                Console.Out.WriteLine("1" + " " + ex.Message);
                throw new ExcepcionesSKD.Modulo8.FormatoIncorrectoException(RecursosDAORestriccionEvento.CodigoErrorFormato,
                     RecursosDAORestriccionEvento.MensajeErrorFormato, ex);
            }
            catch (ExcepcionesSKD.ExceptionSKDConexionBD ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                Console.Out.WriteLine("1" + " " + ex.Message);
                throw ex;
            }
            catch (Exception ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                Console.Out.WriteLine("1" + " " + ex.Message);
                throw new ExcepcionesSKD.ExceptionSKD(RecursoGeneralBD.Mensaje_Generico_Error, ex);
            }


            return true;
        }
        #endregion

    }
}
