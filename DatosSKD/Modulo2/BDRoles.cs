using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DominioSKD;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Configuration;

namespace DatosSKD.Modulo2
{
    public class BDRoles
    {
       public static List<Rol> ObtenerRolesDeSistema()
        {
            BDConexion laConexion;
            List<Parametro> parametros;
            Parametro elParametro = new Parametro();

            try
            {
                laConexion = new BDConexion();
                parametros = new List<Parametro>();
                List<Rol> losRoles=new List<Rol>();

                DataTable dt = laConexion.EjecutarStoredProcedureTuplas(
                               RecursosBDModulo2.ConsultarRolesSistema, parametros);

                foreach (DataRow row in dt.Rows)
                {
                    Rol elRol = new Rol();
                    elRol.Id_rol = int.Parse(row[RecursosBDModulo2.AliasIdRol].ToString());
                    elRol.Nombre = row[RecursosBDModulo2.AliasNombreRol].ToString();
                    elRol.Descripcion = row[RecursosBDModulo2.AliasDescripcionRol].ToString();
                    losRoles.Add(elRol);
                }
               
                return losRoles;

            }
            catch (Exception e)
            {
                throw e;
            }
        }

       public static bool EliminarRol(string idUsuario, string idRol)
       {
           BDConexion laConexion;
           List<Parametro> parametros;
           Parametro elParametro = new Parametro();

           try
           {
               laConexion = new BDConexion();
               parametros = new List<Parametro>();
               elParametro = new Parametro(RecursosBDModulo2.AliasIdRol, SqlDbType.VarChar, idRol, false);
               parametros.Add(elParametro); 
               elParametro = new Parametro(RecursosBDModulo2.aliasIdUsuario, SqlDbType.VarChar, idUsuario, false);
               parametros.Add(elParametro);
               laConexion.EjecutarStoredProcedureTuplas( RecursosBDModulo2.EliminarRolProcedure, parametros);
               return true;

           }
           catch (Exception e)
           {
               throw e;
           }

       }
      
        public static bool AgregarRol(string idUsuario, string idRol)
       {
           BDConexion laConexion;
           List<Parametro> parametros;
           Parametro elParametro = new Parametro();

           try
           {
               laConexion = new BDConexion();
               parametros = new List<Parametro>();
               elParametro = new Parametro(RecursosBDModulo2.AliasIdRol, SqlDbType.VarChar, idRol, false);
               parametros.Add(elParametro);
               elParametro = new Parametro(RecursosBDModulo2.aliasIdUsuario, SqlDbType.VarChar, idUsuario, false);
               parametros.Add(elParametro);
               laConexion.EjecutarStoredProcedureTuplas(RecursosBDModulo2.AgregarRolProcedure, parametros);
               return true;

           }
           catch (Exception e)
           {
               throw e;
           }

       }

        public static List<Rol> consultarRolesUsuario(string idUsuario)
        {
            BDConexion laConexion;
            List<Parametro> parametros;
            Parametro elParametro = new Parametro();

            try
            {
                laConexion = new BDConexion();
                parametros = new List<Parametro>();
                List<Rol> losRoles = new List<Rol>();
                elParametro = new Parametro(RecursosBDModulo2.aliasIdUsuario, SqlDbType.VarChar, idUsuario, false);
                parametros.Add(elParametro);
                DataTable dt= laConexion.EjecutarStoredProcedureTuplas(RecursosBDModulo2.ConsultarRolesUsuario, parametros);
                foreach (DataRow row in dt.Rows)
                {
                    Rol rol = new Rol();
                    rol.Id_rol = int.Parse(row[RecursosBDModulo2.AliasIdRol].ToString());
                    rol.Descripcion = row[RecursosBDModulo2.AliasDescripcionRol].ToString();
                    rol.Nombre = row[RecursosBDModulo2.AliasNombreRol].ToString();
                    rol.Fecha_creacion = (DateTime)row[RecursosBDModulo2.aliasFechaCreacion];
                    losRoles.Add(rol);

                }

                
                return losRoles;

            }
            catch (Exception e)
            {
                throw e;
            }

        }
    }
}
