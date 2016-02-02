using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DominioSKD.Entidades.Modulo1;
using DominioSKD.Entidades.Modulo2;
using DominioSKD;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;
using DominioSKD.Fabrica;
using DatosSKD.InterfazDAO.Modulo1;
using DatosSKD;
using DominioSKD.Entidades.Modulo1;

namespace DatosSKD.DAO.Modulo1
{
    public class DaoLogin : DAOGeneral, IDaoLogin
    {

        FabricaEntidades laFabrica=new FabricaEntidades();
        #region IDAO
        public Boolean Agregar(Entidad e)
        {
            throw new NotImplementedException();
        }
        public Boolean Modificar(Entidad e)
        {
            throw new NotImplementedException();
        }
        public Entidad ConsultarXId(Entidad e)
        {
            throw new NotImplementedException();
        }
        public List<Entidad> ConsultarTodos()
        {
            throw new NotImplementedException();
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
                //laConexion = new BDConexion();
                //laConexion2 = new BDConexion();
                //laConexion3 = new BDConexion();
                parametros = new List<Parametro>();
                parametros2 = new List<Parametro>();
                string idUsuario = RecursosBDM1.idInicial;
                Cuenta laCuenta =(Cuenta) laFabrica.ObtenerCuenta_M1();


                elParametro = new Parametro(RecursosBDM1.AliasNombreUsuario, SqlDbType.VarChar, nombre_usuario, false);
                parametros.Add(elParametro);
                DataTable dt = this.EjecutarStoredProcedureTuplas(
                                RecursosBDM1.ConsultarNombreUsuarioContrasena, parametros);

                foreach (DataRow row in dt.Rows)
                {
                    laCuenta.Nombre_usuario = row[RecursosBDM1.AliasNombreUsuario].ToString();
                    laCuenta.Contrasena = row[RecursosBDM1.AliasContrasena].ToString();
                    laCuenta.Imagen = row[RecursosBDM1.AliasImagen].ToString();
                    idUsuario = row[RecursosBDM1.AliasIdUsuario].ToString();

                }



                //Llenar el usuario

                DataTable dt1 = this.EjecutarStoredProcedureTuplas(
                RecursosBDM1.ConsultarRolesUsuario, parametros);
                List<Rol> listaRol = new List<Rol>();
                foreach (DataRow row in dt1.Rows)
                {

                    Rol elRol = new Rol();
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
        /// Se hace la conexion a la base de datos para validar si el correo se encuentra asociado a mas usuarios del sistema
        /// </summary>
        /// <param name="correo_usuario">Correo del usuario</param>
        /// <returns>retorna un objeto tipo Cuenta</returns>
        public String ValidarCorreoUsuario(string correo_usuario)
        {
            List<Parametro> parametros;
            Parametro elParametro = new Parametro();

            try
            {
                parametros = new List<Parametro>();
                List<String> elCorreo = new List<String>();

                elParametro = new Parametro(RecursosBDM1.aliasCorreoUsuario, SqlDbType.VarChar, correo_usuario, false);
                parametros.Add(elParametro);
                DataTable dt = this.EjecutarStoredProcedureTuplas(
                               RecursosBDM1.ValidarCorreo, parametros);

                foreach (DataRow row in dt.Rows)
                {

                    elCorreo.Add(row[RecursosBDM1.aliasCorreoUsuario].ToString());
                }
                Console.WriteLine(elCorreo.Count.ToString());
                if (elCorreo.Count == 0)
                    return null;
                else if (elCorreo.Count > 1)
                    throw new Exception(RecursosBDM1.exceptionCorreoMasUno);

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
