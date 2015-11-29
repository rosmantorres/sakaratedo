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

namespace DatosSKD.Modulo1
{
    public class BDRestablecer
    {
        public static bool RestablecerContrasena(string usuarioId,string contraseña)
        {
            BDConexion laConexion;
            List<Parametro> parametros;
            Parametro elParametro = new Parametro();

            try
            {
                laConexion = new BDConexion();
                parametros = new List<Parametro>();
                Cuenta laCuenta = new Cuenta();
                elParametro = new Parametro(RecursosBDModulo1.AliasIdUsuario, SqlDbType.Int, usuarioId, false);
                parametros.Add(elParametro);
                elParametro = new Parametro(RecursosBDModulo1.AliasContrasena, SqlDbType.VarChar,contraseña, false);
                parametros.Add(elParametro);

                laConexion.EjecutarStoredProcedureTuplas(
                      RecursosBDModulo1.CambiarContraseña, parametros);
                return true;
            }
            catch (SqlException ex)
            {
                throw new ExcepcionesSKD.ExceptionSKDConexionBD(RecursoGeneralBD.Codigo,
                    RecursoGeneralBD.Mensaje, ex);
            }
            catch (ExcepcionesSKD.ExceptionSKDConexionBD ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw new ExcepcionesSKD.ExceptionSKD(RecursoGeneralBD.Mensaje_Generico_Error, ex);
            }

        }
   
    
    }
}
