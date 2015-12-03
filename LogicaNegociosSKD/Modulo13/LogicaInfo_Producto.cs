using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DominioSKD;
using DatosSKD.Modulo13;
using System.Data;
using ExcepcionesSKD.Modulo15;
using ExcepcionesSKD;
using System.Data.SqlClient;

namespace LogicaNegociosSKD.Modulo13
{
     public class LogicaInfo_Producto
    {

        #region
        private List<Implemento> listaImplementos;
        #endregion

         #region constructor
        public LogicaInfo_Producto()
        {
         
        }
        #endregion


        #region Inventario

        public static SqlDataReader L_Info_Producto(String dojo)
        {
            try
            {
                             
                return (DatosSKD.Modulo13.BDimplementos.D_Info_producto(dojo));
                   
            }

            catch (ExceptionSKDConexionBD ex)
            {
                throw ex;
            }

            catch (ErrorEnParametroDeProcedure ex)
            {

                throw ex;

            }
            catch (Exception ex)
            {

                throw ex;
            }
            return resultado;
        }
        
        
        #endregion

    }
}