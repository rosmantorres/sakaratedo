using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Configuration;
using DominioSKD;

namespace DatosSKD.Modulo1
{
    class BDLogin
    {
        public static Cuenta ValidarUsuario(string nombre_usuario, string contrasena)
        {
            BDConexion laConexion;
            List<Parametro> parametros;
            Parametro elParametro1 = new Parametro();
            Parametro elParametro2 = new Parametro();

            try
            {
                laConexion = new BDConexion();
                parametros = new List<Parametro>();
                Cuenta laCuenta = new Cuenta();

                elParametro1 = new Parametro(RecursosBDModulo1.AliasNombreUsuario,SqlDbType.Text,nombre_usuario,false);
                elParametro2 = new Parametro(RecursosBDModulo1.AliasContrasena,SqlDbType.Text,contrasena,false);

                parametros.Add(elParametro1);
                parametros.Add(elParametro2);

                DataTable dt = laConexion.EjecutarStoredProcedureTuplas(
                               RecursosBDModulo1.ConsultarNombreUsuarioContrasena, parametros);

                foreach (DataRow row in dt.Rows)
                {
                    laCuenta.Nombre_usuario = row[RecursosBDModulo1.AliasNombreUsuario].ToString();
                    laCuenta.Contrasena = row[RecursosBDModulo1.AliasContrasena].ToString();          
                }
                return laCuenta;

            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
