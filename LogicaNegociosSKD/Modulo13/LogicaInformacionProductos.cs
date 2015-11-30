using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DominioSKD;
using DatosSKD;
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

        public List<Implemento> listarimplementos()
        {

            try
            {
                listaImplementos = BD.listarInventarioDatos(dojo);
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
            return listaImplementos;
        }
        
        
        #endregion

    }
}