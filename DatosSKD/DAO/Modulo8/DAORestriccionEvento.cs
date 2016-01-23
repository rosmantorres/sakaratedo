using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using DominioSKD;
using DominioSKD.Entidades.Modulo8;

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
        /// <param name="parametro"></param>
        /// <returns></returns>
        public Boolean AgregarRestriccionEvento(DominioSKD.Entidad parametro)
        {
            DominioSKD.Entidades.Modulo8.RestriccionEvento laRestriccionEvento =
                (DominioSKD.Entidades.Modulo8.RestriccionEvento)parametro;

            try
            {
                List<Parametro> parametros = new List<Parametro>(); //declaras lista de parametros

                Parametro elParametro = new Parametro(RecursosDAORestriccionEvento.ParamDescripcionRestricionEvento, SqlDbType.VarChar,
                    laRestriccionEvento.Descripcion, false);
                //parametro recibe: el alias de la accion (en este caso es la descripcion de mi restriccion de cinta que apunta a un atributo que se llama @DescripcionRestriccionCinta), SqlDbType es el tipo de dato que tiene ese atributo en la base de datos (en este caso es varchar), el elemento que se desea poner en ese lugar (aqui se usa la clase dominio), el false lo dejas asi
                parametros.Add(elParametro);
                //agregas eso que acabas de hacer a la lista de parametros.
                //repites hasta que tengas todos los parametros de tu stored procedure asociado
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

                BDConexion laConexion = new BDConexion();// abres la conexion
                laConexion.EjecutarStoredProcedure(RecursosDAORestriccionEvento.AgregarRestriccionEvento
                                             , parametros);//ejecutas el stored procedure que quieres pasandole la lista de parametros
            }

            catch (SqlException ex)
            {
                //Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                throw new ExcepcionesSKD.ExceptionSKDConexionBD(RecursoGeneralBD.Codigo,
                    RecursoGeneralBD.Mensaje, ex);
            }
            catch (ExcepcionesSKD.ExceptionSKDConexionBD ex)
            {
                //Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                throw ex;
            }
            catch (Exception ex)
            {
                //Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                throw new ExcepcionesSKD.ExceptionSKD(RecursoGeneralBD.Mensaje_Generico_Error, ex);
            }


            return true;
        }
        #endregion

        #region ModificarRestriccionEvento
        /// <summary>
        /// Metodo para modificar una restriccion de evento a la base de datos.
        /// </summary>
        /// <param name="parametro"> objeto RestriccionEvento</param>
        /// <returns></returns>
        public Boolean ModificarRestriccionEvento(DominioSKD.Entidad parametro)
        {
            DominioSKD.Entidades.Modulo8.RestriccionEvento laRestriccionEvento =
                    (DominioSKD.Entidades.Modulo8.RestriccionEvento)parametro;
            try
            {
                List<Parametro> parametros = new List<Parametro>(); //declaras lista de parametros

                Parametro elParametro = new Parametro(RecursosDAORestriccionEvento.ParamIdRestriccionEvento, SqlDbType.Int,
                    laRestriccionEvento.IdRestEvento.ToString(), false);
                //parametro recibe: el alias de la accion (en este caso es la descripcion de mi restriccion de cinta que apunta a un atributo que se llama @DescripcionRestriccionCinta), SqlDbType es el tipo de dato que tiene ese atributo en la base de datos (en este caso es varchar), el elemento que se desea poner en ese lugar (aqui se usa la clase dominio), el false lo dejas asi
                parametros.Add(elParametro);
                //agregas eso que acabas de hacer a la lista de parametros.
                //repites hasta que tengas todos los parametros de tu stored procedure asociado
                elParametro = new Parametro(RecursosDAORestriccionEvento.ParamDescripcionRestricionEvento, SqlDbType.VarChar,
                    laRestriccionEvento.Descripcion, false);

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


                BDConexion laConexion = new BDConexion();// abres la conexion
                laConexion.EjecutarStoredProcedure(RecursosDAORestriccionEvento.ModificarRestriccionEvento
                                             , parametros);//ejecutas el stored procedure que quieres pasandole la lista de parametros
            }

            catch (SqlException ex)
            {
                //Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                throw new ExcepcionesSKD.ExceptionSKDConexionBD(RecursoGeneralBD.Codigo,
                    RecursoGeneralBD.Mensaje, ex);
            }
            catch (ExcepcionesSKD.ExceptionSKDConexionBD ex)
            {
                //Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                throw ex;
            }
            catch (Exception ex)
            {
                //Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                throw new ExcepcionesSKD.ExceptionSKD(RecursoGeneralBD.Mensaje_Generico_Error, ex);
            }


            return true;
        }
        #endregion

        #region EliminarRestriccionEvento
        /// <summary>
        /// Metodo para eliminar una restriccion de evento en la base de datos.
        /// </summary>
        /// <param name="parametro"> objeto RestriccionEvento</param>
        /// <returns></returns>
        public Boolean EliminarRestriccionEvento(DominioSKD.Entidad parametro)
        {
            DominioSKD.Entidades.Modulo8.RestriccionEvento laRestriccionEvento =
                (DominioSKD.Entidades.Modulo8.RestriccionEvento)parametro;
            try
            {
                List<Parametro> parametros = new List<Parametro>(); //declaras lista de parametros

                Parametro elParametro = new Parametro(RecursosDAORestriccionEvento.ParamIdRestriccionEvento, SqlDbType.Int,
                    laRestriccionEvento.ToString(), false);
                //parametro recibe: el alias de la accion (en este caso es la descripcion de mi restriccion de cinta que apunta a un atributo que se llama @DescripcionRestriccionCinta), SqlDbType es el tipo de dato que tiene ese atributo en la base de datos (en este caso es varchar), el elemento que se desea poner en ese lugar (aqui se usa la clase dominio), el false lo dejas asi
                parametros.Add(elParametro);
                //agregas eso que acabas de hacer a la lista de parametros.
                //repites hasta que tengas todos los parametros de tu stored procedure asociado

                BDConexion laConexion = new BDConexion();// abres la conexion
                laConexion.EjecutarStoredProcedure(RecursosDAORestriccionEvento.EliminarRHCinta
                                             , parametros);

                laConexion = new BDConexion();// abres la conexion
                laConexion.EjecutarStoredProcedure(RecursosDAORestriccionEvento.EliminarRestriccionEvento
                                             , parametros);//ejecutas el stored procedure que quieres pasandole la lista de parametros
            }

            catch (SqlException ex)
            {
                //Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                throw new ExcepcionesSKD.ExceptionSKDConexionBD(RecursoGeneralBD.Codigo,
                    RecursoGeneralBD.Mensaje, ex);
            }
            catch (ExcepcionesSKD.ExceptionSKDConexionBD ex)
            {
                //Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                throw ex;
            }
            catch (Exception ex)
            {
                //Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                throw new ExcepcionesSKD.ExceptionSKD(RecursoGeneralBD.Mensaje_Generico_Error, ex);
            }


            return true;
        }
        #endregion

        

    }
}
