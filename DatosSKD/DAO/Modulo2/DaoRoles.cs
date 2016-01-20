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
using DatosSKD.Modulo1;
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
                               RecursosBDModulo2.ConsultarRolesSistema, parametros);

                foreach (DataRow row in dt.Rows)
                {
                    Rol elRol =(Rol) laFabrica.ObtenerRol_M2();
                    elRol.Id_rol = int.Parse(row[RecursosBDModulo2.AliasIdRol].ToString());
                    elRol.Nombre = row[RecursosBDModulo2.AliasNombreRol].ToString();
                    elRol.Descripcion = row[RecursosBDModulo2.AliasDescripcionRol].ToString();
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
                throw new ExcepcionesSKD.Modulo12.FormatoIncorrectoException(RecursosBDModulo1.Codigo_Error_Formato,
                     RecursosBDModulo1.Mensaje_Error_Formato, e);
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

                elParametro = new Parametro(RecursosBDModulo1.AliasIdUsuario, SqlDbType.Int, id_usuario.ToString(), false);
                parametros.Add(elParametro);
                DataTable dt = this.EjecutarStoredProcedureTuplas(
                               RecursosBDModulo2.ConsultarNombreUsuarioContrasena_ID, parametros);


                foreach (DataRow row in dt.Rows)
                {

                    idUsuario = (row[RecursosBDModulo1.AliasIdUsuario].ToString());
                    laCuenta.Nombre_usuario = row[RecursosBDModulo1.AliasNombreUsuario].ToString();
                    laCuenta.Imagen = row[RecursosBDModulo1.AliasImagen].ToString();

                }

                DataTable dt1 = this.EjecutarStoredProcedureTuplas(
                RecursosBDModulo2.ConsultarRolesUsuario, parametros);
                List<Rol> listaRol = new List<Rol>();
                foreach (DataRow row in dt1.Rows)
                {

                    Rol elRol = (Rol) laFabrica.ObtenerRol_M2();
                    elRol.Id_rol = int.Parse(row[RecursosBDModulo1.AliasIdRol].ToString());
                    elRol.Nombre = row[RecursosBDModulo1.AliasNombreRol].ToString();
                    elRol.Descripcion = row[RecursosBDModulo1.AliasDescripcionRol].ToString();
                    elRol.Fecha_creacion = (DateTime)row[RecursosBDModulo1.AliasFechaCreacion];
                    listaRol.Add(elRol);
                }

                laCuenta.Roles = listaRol;

                elParametro = new Parametro(RecursosBDModulo1.AliasIdUsuario, SqlDbType.Int, idUsuario, false);
                parametros2.Add(elParametro);
                DataTable dt2 = this.EjecutarStoredProcedureTuplas(
                                RecursosBDModulo1.consultarPersona, parametros2);

                PersonaM1 laPersona = (PersonaM1) laFabrica.ObtenerPersona_M1();
                foreach (DataRow row in dt2.Rows)
                {

                    laPersona._Id = int.Parse(row[RecursosBDModulo1.AliasIdUsuario].ToString());
                    laPersona._Nombre = row[RecursosBDModulo1.AliasNombreUsuario].ToString();
                    laPersona._Apellido = row[RecursosBDModulo1.aliasApellidoUsuario].ToString();
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
                throw new ExcepcionesSKD.Modulo12.FormatoIncorrectoException(RecursosBDModulo1.Codigo_Error_Formato,
                     RecursosBDModulo1.Mensaje_Error_Formato, e);
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
                elParametro = new Parametro(RecursosBDModulo2.AliasIdRol, SqlDbType.VarChar, idRol, false);
                parametros.Add(elParametro);
                elParametro = new Parametro(RecursosBDModulo2.aliasIdUsuario, SqlDbType.VarChar, idUsuario, false);
                parametros.Add(elParametro);
                this.EjecutarStoredProcedureTuplas(RecursosBDModulo2.AgregarRolProcedure, parametros);
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
                elParametro = new Parametro(RecursosBDModulo2.AliasIdRol, SqlDbType.VarChar, idRol, false);
                parametros.Add(elParametro);
                elParametro = new Parametro(RecursosBDModulo2.aliasIdUsuario, SqlDbType.VarChar, idUsuario, false);
                parametros.Add(elParametro);
                this.EjecutarStoredProcedureTuplas(RecursosBDModulo2.EliminarRolProcedure, parametros);
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
        public List<Rol> consultarRolesUsuario(string idUsuario)
        {
            List<Parametro> parametros;
            Parametro elParametro = new Parametro();

            try
            {
                parametros = new List<Parametro>();
                List<Rol> losRoles = new List<Rol>();
                elParametro = new Parametro(RecursosBDModulo2.aliasIdUsuario, SqlDbType.VarChar, idUsuario, false);
                parametros.Add(elParametro);
                DataTable dt = this.EjecutarStoredProcedureTuplas(RecursosBDModulo2.ConsultarRolesUsuario, parametros);
                foreach (DataRow row in dt.Rows)
                {
                    Rol rol = (Rol)laFabrica.ObtenerRol_M2();
                    rol.Id_rol = int.Parse(row[RecursosBDModulo2.AliasIdRol].ToString());
                    rol.Descripcion = row[RecursosBDModulo2.AliasDescripcionRol].ToString();
                    rol.Nombre = row[RecursosBDModulo2.AliasNombreRol].ToString();
                    rol.Fecha_creacion = (DateTime)row[RecursosBDModulo2.aliasFechaCreacion];
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
                throw new ExcepcionesSKD.Modulo12.FormatoIncorrectoException(RecursosBDModulo1.Codigo_Error_Formato,
                     RecursosBDModulo1.Mensaje_Error_Formato, e);
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
