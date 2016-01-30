using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DominioSKD.Entidades.Modulo2;
using DominioSKD.Entidades.Modulo1;
using DominioSKD;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Configuration;
using DatosSKD.DAO.Modulo1;
using DatosSKD.InterfazDAO.Modulo2;
using DominioSKD.Fabrica;

namespace DatosSKD.DAO.Modulo2
{
    public class DaoRoles: DAOGeneral, IDaoRoles
    {

        private FabricaEntidades laFabrica=new FabricaEntidades();

        public Boolean Agregar(Entidad ent)
        {
            return false;
        }
        public Boolean Modificar(Entidad ent)
        {
            return false;
        }

        /// <summary>
        /// Se hace la conexion a la base de datos para obtener la lista de roles del sistema con sus respectivos atributos
        /// </summary>
        /// <returns> lista de roles del sistema con sus respectivos atributos</returns>
        public List<Entidad> ConsultarTodos()
        {
            List<Parametro> parametros;
            Parametro elParametro = new Parametro();

            try
            {
                parametros = new List<Parametro>();
                List<Entidad> losRoles = new List<Entidad>();

                DataTable dt = this.EjecutarStoredProcedureTuplas(
                               RecursosBDM2.ConsultarRolesSistema, parametros);

                foreach (DataRow row in dt.Rows)
                {
                    Rol elRol =(Rol) laFabrica.ObtenerRol_M2();
                    elRol.Id_rol = int.Parse(row[RecursosBDM2.AliasIdRol].ToString());
                    elRol.Nombre = row[RecursosBDM2.AliasNombreRol].ToString();
                    elRol.Descripcion = row[RecursosBDM2.AliasDescripcionRol].ToString();
                    losRoles.Add(elRol);
                }

                return losRoles;

            }
            catch (SqlException e)
            {
                throw new ExcepcionesSKD.ExceptionSKDConexionBD(RecursoGeneralBD.Codigo,
                    RecursoGeneralBD.Mensaje, e);
            }
            catch (FormatException e)
            {
                throw new ExcepcionesSKD.Modulo12.FormatoIncorrectoException(RecursosBDM1.Codigo_Error_Formato,
                     RecursosBDM1.Mensaje_Error_Formato, e);
            }
            catch (ExcepcionesSKD.ExceptionSKDConexionBD e)
            {
                throw e;
            }
            catch (Exception e)
            {
                throw new ExcepcionesSKD.ExceptionSKD(RecursoGeneralBD.Mensaje_Generico_Error, e);
            }
        }

        /// <summary>
        /// Retorna un usuario por su ID sin su contraseña
        /// </summary>
        /// <param name="id_usuario">ID del usuario a consultar</param> 
        /// <returns>Cuenta de usuario sin contraseña</returns>
        public Entidad ConsultarXId(Entidad ent)
        {
            int id_usuario = ent.Id;
            BDConexion laConexion;//COnsultar la persona
            BDConexion laConexion2;//Consultar los roles de la persona
            BDConexion laConexion3;//Consultar la persona
            List<Parametro> parametros;
            Parametro elParametro = new Parametro();

            List<Parametro> parametros2;

            try
            {
               // laConexion = new BDConexion();
               // laConexion2 = new BDConexion();
               // laConexion3 = new BDConexion();
                parametros = new List<Parametro>();
                parametros2 = new List<Parametro>();
                Cuenta laCuenta = (Cuenta) laFabrica.ObtenerCuenta_M1();

                string idUsuario = "0";

                elParametro = new Parametro(RecursosBDM1.AliasIdUsuario, SqlDbType.Int, id_usuario.ToString(), false);
                parametros.Add(elParametro);
                DataTable dt = this.EjecutarStoredProcedureTuplas(
                               RecursosBDM2.ConsultarNombreUsuarioContrasena_ID, parametros);


                foreach (DataRow row in dt.Rows)
                {

                    idUsuario = (row[RecursosBDM1.AliasIdUsuario].ToString());
                    laCuenta.Nombre_usuario = row[RecursosBDM1.AliasNombreUsuario].ToString();
                    laCuenta.Imagen = row[RecursosBDM1.AliasImagen].ToString();

                }

                DataTable dt1 = this.EjecutarStoredProcedureTuplas(
                RecursosBDM2.ConsultarRolesUsuario, parametros);
                List<Rol> listaRol = new List<Rol>();
                foreach (DataRow row in dt1.Rows)
                {

                    Rol elRol = (Rol) laFabrica.ObtenerRol_M2();
                    elRol.Id_rol = int.Parse(row[RecursosBDM1.AliasIdRol].ToString());
                    elRol.Nombre = row[RecursosBDM1.AliasNombreRol].ToString();
                    elRol.Descripcion = row[RecursosBDM1.AliasDescripcionRol].ToString();
                    elRol.Fecha_creacion = (DateTime)row[RecursosBDM1.AliasFechaCreacion];
                    listaRol.Add(elRol);
                }

                laCuenta.Roles = listaRol;

                elParametro = new Parametro(RecursosBDM1.AliasIdUsuario, SqlDbType.Int, idUsuario, false);
                parametros2.Add(elParametro);
                DataTable dt2 = this.EjecutarStoredProcedureTuplas(
                                RecursosBDM1.consultarPersona, parametros2);

                PersonaM1 laPersona = (PersonaM1) laFabrica.ObtenerPersona_M1();
                foreach (DataRow row in dt2.Rows)
                {

                    laPersona._Id = int.Parse(row[RecursosBDM1.AliasIdUsuario].ToString());
                    laPersona._Nombre = row[RecursosBDM1.AliasNombreUsuario].ToString();
                    laPersona._Apellido = row[RecursosBDM1.aliasApellidoUsuario].ToString();
                }
                laCuenta.PersonaUsuario = laPersona;
                return laCuenta;

            }
            catch (SqlException e)
            {
                throw new ExcepcionesSKD.ExceptionSKDConexionBD(RecursoGeneralBD.Codigo,
                    RecursoGeneralBD.Mensaje, e);
            }
            catch (FormatException e)
            {
                throw new ExcepcionesSKD.Modulo12.FormatoIncorrectoException(RecursosBDM1.Codigo_Error_Formato,
                     RecursosBDM1.Mensaje_Error_Formato, e);
            }
            catch (ExcepcionesSKD.ExceptionSKDConexionBD e)
            {
                throw e;
            }
            catch (Exception e)
            {
                throw new ExcepcionesSKD.ExceptionSKD(RecursoGeneralBD.Mensaje_Generico_Error, e);
            }

        }


             /// <summary>
        /// Se hace la conexion a la base de datos para Agregar un rol  al usuario
        /// </summary>
        /// <param name="idUsuario">id del usuario que se le Agregar el rol</param>
        /// <param name="idRol">id del rol a Agregar</param>
        /// <returns> true si  se pudo Agregar false si no se pudo Agregar el rol</returns>
        public bool AgregarRol(string idUsuario, string idRol)
        {
            List<Parametro> parametros;
            Parametro elParametro = new Parametro();

            try
            {
                parametros = new List<Parametro>();
                elParametro = new Parametro(RecursosBDM2.AliasIdRol, SqlDbType.VarChar, idRol, false);
                parametros.Add(elParametro);
                elParametro = new Parametro(RecursosBDM2.aliasIdUsuario, SqlDbType.VarChar, idUsuario, false);
                parametros.Add(elParametro);
                this.EjecutarStoredProcedureTuplas(RecursosBDM2.AgregarRolProcedure, parametros);
                return true;

            }
            catch (SqlException e)
            {
                throw new ExcepcionesSKD.ExceptionSKDConexionBD(RecursoGeneralBD.Codigo,
                    RecursoGeneralBD.Mensaje, e);
            }
            catch (ExcepcionesSKD.ExceptionSKDConexionBD e)
            {
                throw e;
            }
            catch (Exception e)
            {
                throw new ExcepcionesSKD.ExceptionSKD(RecursoGeneralBD.Mensaje_Generico_Error, e);
            }

        }

        
        /// <summary>
        /// Se hace la conexion a la base de datos para eliminar un rol  del usuario
        /// </summary>
        /// <param name="idUsuario">id del usuario que se le eliminara el rol</param>
        /// <param name="idRol">id del rol a eliminar</param>
        /// <returns> true si  se pudo eliminar false si no se pudo eliminar el rol</returns>
        public bool EliminarRol(string idUsuario, string idRol)
        {
            List<Parametro> parametros;
            Parametro elParametro = new Parametro();

            try
            {
                parametros = new List<Parametro>();
                elParametro = new Parametro(RecursosBDM2.AliasIdRol, SqlDbType.VarChar, idRol, false);
                parametros.Add(elParametro);
                elParametro = new Parametro(RecursosBDM2.aliasIdUsuario, SqlDbType.VarChar, idUsuario, false);
                parametros.Add(elParametro);
                this.EjecutarStoredProcedureTuplas(RecursosBDM2.EliminarRolProcedure, parametros);
                return true;

            }
            catch (SqlException e)
            {
                throw new ExcepcionesSKD.ExceptionSKDConexionBD(RecursoGeneralBD.Codigo,
                    RecursoGeneralBD.Mensaje, e);
            }
            catch (ExcepcionesSKD.ExceptionSKDConexionBD e)
            {
                throw e;
            }
            catch (Exception e)
            {
                throw new ExcepcionesSKD.ExceptionSKD(RecursoGeneralBD.Mensaje_Generico_Error, e);
            }
        }
   
        /// <summary>
        /// Se hace la conexion a la base de datos para obtener la lista de roles del usuario con sus respectivos atributos
        /// </summary>
        /// <param name="idUsuario">id del usuario que leconsultaran los roles</param>
        /// <returns> lista de roles del usuario con sus respectivos atributos</returns>
        public List<Entidad> consultarRolesUsuario(string idUsuario)
        {
            List<Parametro> parametros;
            Parametro elParametro = new Parametro();

            try
            {
                parametros = new List<Parametro>();
                List<Entidad> losRoles = new List<Entidad>();
                elParametro = new Parametro(RecursosBDM2.aliasIdUsuario, SqlDbType.VarChar, idUsuario, false);
                parametros.Add(elParametro);
                DataTable dt = this.EjecutarStoredProcedureTuplas(RecursosBDM2.ConsultarRolesUsuario, parametros);
                foreach (DataRow row in dt.Rows)
                {
                    Rol rol = (Rol)laFabrica.ObtenerRol_M2();
                    rol.Id_rol = int.Parse(row[RecursosBDM2.AliasIdRol].ToString());
                    rol.Descripcion = row[RecursosBDM2.AliasDescripcionRol].ToString();
                    rol.Nombre = row[RecursosBDM2.AliasNombreRol].ToString();
                    rol.Fecha_creacion = (DateTime)row[RecursosBDM2.aliasFechaCreacion];
                    losRoles.Add(rol);

                }


                return losRoles;

            }
            catch (SqlException e)
            {
                throw new ExcepcionesSKD.ExceptionSKDConexionBD(RecursoGeneralBD.Codigo,
                    RecursoGeneralBD.Mensaje, e);
            }
            catch (FormatException e)
            {
                throw new ExcepcionesSKD.Modulo12.FormatoIncorrectoException(RecursosBDM1.Codigo_Error_Formato,
                     RecursosBDM1.Mensaje_Error_Formato, e);
            }
            catch (ExcepcionesSKD.ExceptionSKDConexionBD e)
            {
                throw e;
            }
            catch (Exception e)
            {
                throw new ExcepcionesSKD.ExceptionSKD(RecursoGeneralBD.Mensaje_Generico_Error, e);
            }

        }

     

    }
}
