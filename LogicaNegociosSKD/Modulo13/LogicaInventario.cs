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
     class LogicaInformacionProducto
    {

        #region
        private List<Implemento> listaImplementos;
        #endregion

         #region constructor
        public LogicaInformacionProducto()
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
                
               tabla = DatosSKD.Modulo13.BDimplementos.D_Inventario;
                   
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