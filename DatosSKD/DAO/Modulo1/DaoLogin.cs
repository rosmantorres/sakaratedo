using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DominioSKD;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;
using DominioSKD.Fabrica;
using DatosSKD.InterfazDAO.Modulo1;
using DatosSKD;

namespace DatosSKD.DAO.Modulo1
{
    public class DaoLogin : DAOGeneral, IDaoLogin
    {

        #region IDAO
        public Boolean Agregar(Entidad e)
        {
            return false;
        }
        public Boolean Modificar(Entidad e)
        {
            return false;
        }
        public Entidad ConsultarXId(Entidad e)
        {
            return null;
        }
        public List<Entidad> ConsultarTodos()
        {
            return null;
        }
        #endregion

        #region DaoLogin
        /// <summary>
        /// Se hace la conexion a la base de datos para obtener los datos del usuario y llenar el objeto Cuenta
        /// </summary>
        /// <param name="nombre_usuario">Nombre de usuario</param>
        /// <returns>retorna un objeto tipo Cuenta</returns>
        public Entidad ObtenerUsuario(string nombre_usuario)
        {
            BDConexion laConexion;//COnsultar la persona
            BDConexion laConexion2;//Consultar los roles de la persona
            BDConexion laConexion3;//Crea el objeto PERSONA
            List<Parametro> parametros;
            List<Parametro> parametros2;
            Parametro elParametro = new Parametro();

            try
            {
                laConexion = new BDConexion();
                laConexion2 = new BDConexion();
                laConexion3 = new BDConexion();
                parametros = new List<Parametro>();
                parametros2 = new List<Parametro>();
                string idUsuario = RecursosBDModulo1.idInicial;
                FabricaEntidades laFabrica = new FabricaEntidades();
                Cuenta laCuenta =(Cuenta) laFabrica.ObtenerCuenta_M1();


                elParametro = new Parametro(RecursosBDModulo1.AliasNombreUsuario, SqlDbType.VarChar, nombre_usuario, false);
                parametros.Add(elParametro);
                DataTable dt = laConexion.EjecutarStoredProcedureTuplas(
                                RecursosBDModulo1.ConsultarNombreUsuarioContrasena, parametros);





                foreach (DataRow row in dt.Rows)
                {
                    laCuenta.Nombre_usuario = row[RecursosBDModulo1.AliasNombreUsuario].ToString();
                    laCuenta.Contrasena = row[RecursosBDModulo1.AliasContrasena].ToString();
                    laCuenta.Imagen = row[RecursosBDModulo1.AliasImagen].ToString();
                    idUsuario = row[RecursosBDModulo1.AliasIdUsuario].ToString();

                }



                //Llenar el usuario

                DataTable dt1 = laConexion2.EjecutarStoredProcedureTuplas(
                RecursosBDModulo1.ConsultarRolesUsuario, parametros);
                List<Rol> listaRol = new List<Rol>();
                foreach (DataRow row in dt1.Rows)
                {

                    Rol elRol = new Rol();
                    elRol.Id_rol = int.Parse(row[RecursosBDModulo1.AliasIdRol].ToString());
                    elRol.Nombre = row[RecursosBDModulo1.AliasNombreRol].ToString();
                    elRol.Descripcion = row[RecursosBDModulo1.AliasDescripcionRol].ToString();
                    elRol.Fecha_creacion = (DateTime)row[RecursosBDModulo1.AliasFechaCreacion];
                    listaRol.Add(elRol);
                }

                laCuenta.Roles = listaRol;


                elParametro = new Parametro(RecursosBDModulo1.AliasIdUsuario, SqlDbType.Int, idUsuario, false);
                parametros2.Add(elParametro);
                DataTable dt2 = laConexion3.EjecutarStoredProcedureTuplas(
                                RecursosBDModulo1.consultarPersona, parametros2);

                PersonaM1 laPersona = new PersonaM1();
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
        /// Se hace la conexion a la base de datos para validar si el correo se encuentra asociado a mas usuarios del sistema
        /// </summary>
        /// <param name="correo_usuario">Correo del usuario</param>
        /// <returns>retorna un objeto tipo Cuenta</returns>
        public String ValidarCorreoUsuario(string correo_usuario)
        {

            BDConexion laConexion;
            List<Parametro> parametros;
            Parametro elParametro = new Parametro();

            try
            {
                laConexion = new BDConexion();
                parametros = new List<Parametro>();
                List<String> elCorreo = new List<String>();

                elParametro = new Parametro(RecursosBDModulo1.aliasCorreoUsuario, SqlDbType.VarChar, correo_usuario, false);
                parametros.Add(elParametro);
                DataTable dt = laConexion.EjecutarStoredProcedureTuplas(
                               RecursosBDModulo1.ValidarCorreo, parametros);

                foreach (DataRow row in dt.Rows)
                {

                    elCorreo.Add(row[RecursosBDModulo1.aliasCorreoUsuario].ToString());
                }
                Console.WriteLine(elCorreo.Count.ToString());
                if (elCorreo.Count == 0)
                    return null;
                else if (elCorreo.Count > 1)
                    throw new Exception(RecursosBDModulo1.exceptionCorreoMasUno);

                return elCorreo[0];

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

        #endregion
    }
}
