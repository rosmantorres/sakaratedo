using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace DatosSKD.Modulo6
{
    class BDUtils
    {
        public static DataTable getTable(string query, List<Parametro> parametros)
        {
            DataTable ret;
            BDConexion con = new BDConexion();
            try
            {
                ret = con.EjecutarStoredProcedureTuplas(query, parametros);
            }
            catch (ExcepcionesSKD.ExceptionSKDConexionBD e)
            {
                throw e;
            }
            catch (ExcepcionesSKD.ParametroInvalidoException e)
            {
                throw e;
            }
            return ret;
        }

        public static List<Resultado> getValues(string query, List<Parametro> parametros)
        {
            List<Resultado> ret;
            BDConexion con = new BDConexion();
            try
            {
                ret = con.EjecutarStoredProcedure(query, parametros);
            }
            catch (ExcepcionesSKD.ExceptionSKDConexionBD e)
            {
                throw e;
            }
            catch (ExcepcionesSKD.ParametroInvalidoException e)
            {
                throw e;
            }
            return ret;
        }

    }
}
