using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;
using DominioSKD;
using DatosSKD.Modulo1;

namespace DatosSKD.Modulo6
{
    public class BDListarUsuarios
    {
        public List<Cuenta> ListarUsuarios()
        {
            BDConexion laConexion;//COnsultar la persona
            BDConexion laConexion2;//Consultar los roles de la persona
            BDConexion laConexion3;//Crea el objeto PERSONA
            List<Parametro> parametros;
            List<Parametro> parametros2;
            Parametro elParametro = new Parametro();

            try
            {

                parametros = new List<Parametro>();
                laConexion = new BDConexion();
                List<Cuenta> lasCuentas = new List<Cuenta>();

                DataTable dt = laConexion.EjecutarStoredProcedureTuplas(
                                RecursosBDModulo1.listarUsuarios, parametros);





                foreach (DataRow row in dt.Rows)
                {
                    laConexion2 = new BDConexion();
                    laConexion3 = new BDConexion();
                    parametros2 = new List<Parametro>();
                    parametros = new List<Parametro>();
                    string idUsuario = RecursosBDModulo1.idInicial;
                    Cuenta laCuenta = new Cuenta();
                    laCuenta.Nombre_usuario = row[RecursosBDModulo1.AliasNombreUsuario].ToString();
                    laCuenta.Imagen = row[RecursosBDModulo1.AliasImagen].ToString();
                    idUsuario = row[RecursosBDModulo1.AliasIdUsuario].ToString();
                    elParametro = 
                        new Parametro(RecursosBDModulo1.AliasNombreUsuario, SqlDbType.VarChar, laCuenta.Nombre_usuario, false);
                    parametros.Add(elParametro);
                    DataTable dt1 = laConexion2.EjecutarStoredProcedureTuplas(
                RecursosBDModulo1.ConsultarRolesUsuario, parametros);
                    List<Rol> listaRol = new List<Rol>();
                    foreach (DataRow row2 in dt1.Rows)
                    {

                        Rol elRol = new Rol();
                        elRol.Id_rol = int.Parse(row2[RecursosBDModulo1.AliasIdRol].ToString());
                        elRol.Nombre = row2[RecursosBDModulo1.AliasNombreRol].ToString();
                        elRol.Descripcion = row2[RecursosBDModulo1.AliasDescripcionRol].ToString();
                        elRol.Fecha_creacion = (DateTime)row2[RecursosBDModulo1.AliasFechaCreacion];
                        listaRol.Add(elRol);
                    }
                    laCuenta.Roles = listaRol;

                    elParametro = new Parametro(RecursosBDModulo1.AliasIdUsuario, SqlDbType.Int, idUsuario, false);
                    parametros2.Add(elParametro);
                    DataTable dt2 = laConexion3.EjecutarStoredProcedureTuplas(
                                    RecursosBDModulo1.consultarPersona, parametros2);

                    PersonaM1 laPersona = new PersonaM1();
                    foreach (DataRow row3 in dt2.Rows)
                    {

                        laPersona._Id = int.Parse(row3[RecursosBDModulo1.AliasIdUsuario].ToString());
                        laPersona._Nombre = row3[RecursosBDModulo1.AliasNombreUsuario].ToString();
                        laPersona._Apellido = row3[RecursosBDModulo1.aliasApellidoUsuario].ToString();
                        laPersona._DocumentoID = row3[RecursosBDModulo1.AliasDocumento].ToString();
                    }
                    laCuenta.PersonaUsuario = laPersona;

                    lasCuentas.Add(laCuenta);
                }



                //Llenar el usuario


               

                return lasCuentas;

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
