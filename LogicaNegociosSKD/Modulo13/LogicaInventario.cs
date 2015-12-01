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

namespace LogicaNegociosSKD.Modulo13
{
     public class LogicaInventario
    {

        #region
        private List<Implemento> listaImplementos;
        #endregion

         #region constructor
        public LogicaInventario()
        {
            this.listaImplementos = null;
        }
        #endregion


        #region listarimplementos

        public static List<Reporte_Inventario> L_Inventario()
        {
            List<Reporte_Inventario> listainventario= new List<Reporte_Inventario>();
    

            try
            {

                listainventario = DatosSKD.Modulo13.BDimplementos.D_Inventario();
                   
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
            return listainventario;
        }
        
        
        #endregion

    }
}