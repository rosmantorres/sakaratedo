using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DominioSKD;
using DatosSKD;
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

        public DataTable L_Inventario()
        {
            DataTable tabla;

            try
            {
                
               tabla = new DataTable();
                   
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
            return tabla;
        }
        
        
        #endregion

    }
}