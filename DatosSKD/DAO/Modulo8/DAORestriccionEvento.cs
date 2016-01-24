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
        //asd
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
        /// <param name="parametro"> objeto RestriccionEvento para modificar en bd</param>
        /// <returns>true si fue modificado</returns>
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
        /// <param name="parametro"> int id de la RestriccioEvento para ser eliminado en bd</param>
        /// <returns>true si fue eliminado</returns>
        public Boolean EliminarRestriccionEvento(DominioSKD.Entidad parametro)
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

        #region AgregarRH_Cinta
        /// <summary>
        /// Metodo para agregar las cintas de una RestriccionEvento en la base de datos.
        /// </summary>
        /// <param name="parametro1"> objeto RestriccionEvento para agregar su id en RH_Cinta</param>
        /// <param name="parametro2"> int del Id de la Cinta para ser agregado su id a la RestriccionEvento</param>
        /// <returns>true si fue agregado</returns>
        public Boolean AgregarRh_Cinta(DominioSKD.Entidad parametro1, DominioSKD.Entidad parametro2)
        {
            DominioSKD.Entidades.Modulo8.RestriccionEvento laRestriccionEvento =
                (DominioSKD.Entidades.Modulo8.RestriccionEvento)parametro1;

            DominioSKD.Entidades.Modulo5.Cinta laCinta =
                (DominioSKD.Entidades.Modulo5.Cinta)parametro1;

            try
            {
                List<Parametro> parametros = new List<Parametro>(); //declaras lista de parametros

                Parametro elParametro = new Parametro(RecursosDAORestriccionEvento.ParamIdCinta, SqlDbType.Int,
                    laCinta.Id_cinta.ToString(), false);
                //parametro recibe: el alias de la accion (en este caso es la descripcion de mi restriccion de cinta que apunta a un atributo que se llama @DescripcionRestriccionCinta), SqlDbType es el tipo de dato que tiene ese atributo en la base de datos (en este caso es varchar), el elemento que se desea poner en ese lugar (aqui se usa la clase dominio), el false lo dejas asi
                parametros.Add(elParametro);
                //agregas eso que acabas de hacer a la lista de parametros.
                //repites hasta que tengas todos los parametros de tu stored procedure asociado
                elParametro = new Parametro(RecursosDAORestriccionEvento.ParamIdRestriccionEvento, SqlDbType.Int,
                    laRestriccionEvento.IdRestEvento.ToString(), false);
                parametros.Add(elParametro);

                BDConexion laConexion = new BDConexion();// abres la conexion
                laConexion.EjecutarStoredProcedure(RecursosDAORestriccionEvento.AgregarRH_Cinta
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

        #region EliminarRH_Cinta
        /// <summary>
        /// Metodo para eliminar las cintas de RestriccionEvento en la base de datos en RH_Cinta.
        /// </summary>
        /// <param name="parametro"> objeto RestriccionEvento para eliminar sus cintas relacionadas en bd</param>
        /// <returns>true si fue eliminado</returns>
        public Boolean EliminarRh_Cinta(DominioSKD.Entidad parametro)
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

                BDConexion laConexion = new BDConexion();// abres la conexion
                laConexion.EjecutarStoredProcedure(RecursosDAORestriccionEvento.EliminarRHCinta
                                             , parametros);
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

            DominioSKD.Entidad laRestriccionEvento = null;
            DominioSKD.Fabrica.FabricaEntidades fabricaEntidad = new DominioSKD.Fabrica.FabricaEntidades();
            
            try
            {
                BDConexion laConexion;
                List<Parametro> parametros = new List<Parametro>();
                Parametro elParametro = new Parametro(RecursosDAORestriccionEvento.ParamIdEvento, SqlDbType.Int,
                    elEventoSimple.IdEvento.ToString(), false);

                parametros.Add(elParametro);
                
            
                laConexion = new BDConexion();

                DataTable dt = laConexion.EjecutarStoredProcedureTuplas(
                               RecursosDAORestriccionEvento.ConsultarRestriccionEvento, parametros);

                int IdRestEvento = int.Parse(RecursosDAORestriccionEvento.AliasIdRestriccionEvento.ToString());
                String Descripcion = RecursosDAORestriccionEvento.AliasResDescripcion.ToString();
                int EdadMinima = int.Parse(RecursosDAORestriccionEvento.AliasEdadMin.ToString());
                int EdadMaxima = int.Parse(RecursosDAORestriccionEvento.AliasEdadMax.ToString());
                String Sexo = RecursosDAORestriccionEvento.AliasSexo.ToString();
                int IdEvento = int.Parse(RecursosDAORestriccionEvento.AliasIdEvento.ToString());
                String NombreEvento = RecursosDAORestriccionEvento.AliasNombreEve.ToString();

                laRestriccionEvento = fabricaEntidad.ObtenerRestriccionEvento(IdRestEvento, Descripcion, EdadMinima, EdadMaxima, Sexo, IdEvento, NombreEvento);
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

            return laRestriccionEvento;
        }
        #endregion

        #region ConsultarEventosConRestriccion
        /// <summary>
        /// Metodo para consultar todas las Restricciones de Eventos.
        /// </summary>
        /// <returns>Lista de todas las RestriccionesEventos que existen</returns>
        public List<DominioSKD.Entidad> ConsultarEventosConRestriccion()
        {
            BDConexion laConexion;
            List<Parametro> parametros = new List<Parametro>();

            List<DominioSKD.Entidad> laListaRestriccionesEvento = new List<DominioSKD.Entidad>();
            DominioSKD.Fabrica.FabricaEntidades fabricaEntidad = new DominioSKD.Fabrica.FabricaEntidades();

            try
            {
                laConexion = new BDConexion();

                DataTable dt = laConexion.EjecutarStoredProcedureTuplas(
                               RecursosDAORestriccionEvento.ConsultarEventosConRestriccion, parametros);

                foreach (DataRow row in dt.Rows)
                {
                    int IdRestEvento = int.Parse(RecursosDAORestriccionEvento.AliasIdRestriccionEvento.ToString());
                    String Descripcion = RecursosDAORestriccionEvento.AliasResDescripcion.ToString();
                    int EdadMinima = int.Parse(RecursosDAORestriccionEvento.AliasEdadMin.ToString());
                    int EdadMaxima = int.Parse(RecursosDAORestriccionEvento.AliasEdadMax.ToString());
                    String Sexo = RecursosDAORestriccionEvento.AliasSexo.ToString();
                    int IdEvento = int.Parse(RecursosDAORestriccionEvento.AliasIdEvento.ToString());
                    String NombreEvento = RecursosDAORestriccionEvento.AliasNombreEve.ToString();

                    Entidad laRestriccionEvento = fabricaEntidad.ObtenerRestriccionEvento(IdRestEvento, Descripcion, EdadMinima, EdadMaxima, Sexo, IdEvento, NombreEvento);
                    laListaRestriccionesEvento.Add(laRestriccionEvento);
                }

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
            BDConexion laConexion;
            List<Parametro> parametros = new List<Parametro>();

            List<Entidad> losEventosSimple = new List<Entidad>();
            DominioSKD.Fabrica.FabricaEntidades fabricaEntidad = new DominioSKD.Fabrica.FabricaEntidades();
            try
            {
                laConexion = new BDConexion();

                DataTable dt = laConexion.EjecutarStoredProcedureTuplas(
                               RecursosDAORestriccionEvento.ConsultarEventosSinRestriccion, parametros);

                foreach (DataRow row in dt.Rows)
                {
                    int IdEvento = int.Parse(row[RecursosDAORestriccionEvento.AliasIdEvento].ToString());
                    String NombreEvento = row[RecursosDAORestriccionEvento.AliasNombreEvento].ToString();

                    Entidad elEvento = fabricaEntidad.ObtenerEventoSimple(IdEvento, NombreEvento);
                    losEventosSimple.Add(elEvento);
                }

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

            return losEventosSimple;
        }
        #endregion

        #region ConsultarCintasDeRestriccionEvento
        /// <summary>
        /// Metodo para consultar la RestriccionEvento de un evento especifico en la base de datos.
        /// </summary>
        /// <param name="parametro">RestriccionEvento para buscar con su id las cintas que tiene</param>
        /// <returns>Lista de CintaSimple relacionadas a la restriccionEvento</returns>
        public List<Entidad> ConsultarCintasRestriccionEvento(DominioSKD.Entidad parametro)
        {
            DominioSKD.Entidades.Modulo8.RestriccionEvento laRestriccionEvento =
                (DominioSKD.Entidades.Modulo8.RestriccionEvento)parametro;


            BDConexion laConexion;
            List<Parametro> parametros = new List<Parametro>();

            List<Entidad> laListaCintasSimple = new List<Entidad>();
            DominioSKD.Fabrica.FabricaEntidades fabricaEntidad = new DominioSKD.Fabrica.FabricaEntidades();



            Parametro elParametro = new Parametro(RecursosDAORestriccionEvento.ParamIdRestriccionEvento, SqlDbType.Int,
                    laRestriccionEvento.IdRestEvento.ToString(), false);

            parametros.Add(elParametro);

            try
            {
                laConexion = new BDConexion();

                DataTable dt = laConexion.EjecutarStoredProcedureTuplas(
                               RecursosDAORestriccionEvento.ConsultarCintasDeRestriccionEvento, parametros);

                foreach (DataRow row in dt.Rows)
                {
                    int IdCinta = int.Parse(row[RecursosDAORestriccionEvento.AliasIdCinta].ToString());
                    String ColorCinta = row[RecursosDAORestriccionEvento.AliasCintaColorNombre].ToString();

                    Entidad laCinta = fabricaEntidad.ObtenerCintaSimple(IdCinta, ColorCinta);
                    laListaCintasSimple.Add(laCinta);

                }

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

            return laListaCintasSimple;
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
            BDConexion laConexion;
            List<Parametro> parametros = new List<Parametro>();

            List<Entidad> laListaEventosSimple = new List<Entidad>();
            DominioSKD.Fabrica.FabricaEntidades fabricaEntidad = new DominioSKD.Fabrica.FabricaEntidades();

            Parametro elParametro = new Parametro(RecursosDAORestriccionEvento.ParamIdPersona, SqlDbType.Int,
                    parametro.ToString(), false);

            parametros.Add(elParametro);

            try
            {
                laConexion = new BDConexion();

                DataTable dt = laConexion.EjecutarStoredProcedureTuplas(
                               RecursosDAORestriccionEvento.ConsultarEventosCumplaREAtleta, parametros);

                foreach (DataRow row in dt.Rows)
                {
                    EventoSimple elEvento = new EventoSimple();

                    int IdEvento = int.Parse(row[RecursosDAORestriccionEvento.AliasIdEvento].ToString());
                    String NombreEvento = row[RecursosDAORestriccionEvento.AliasNombreEvento].ToString();

                    Entidad elEventoSimple = fabricaEntidad.ObtenerEventoSimple(IdEvento, NombreEvento);
                    laListaEventosSimple.Add(elEventoSimple);

                }

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

            return laListaEventosSimple;
        }
        #endregion
    }
}
