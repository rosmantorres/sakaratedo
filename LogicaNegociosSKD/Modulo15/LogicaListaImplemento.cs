using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExcepcionesSKD.Modulo15;

using ExcepcionesSKD;
using DatosSKD.Modulo15;
using DominioSKD;

namespace LogicaNegociosSKD.Modulo15
{
    public class LogicaImplemento
    {

        #region atributos
        private List<Implemento> listaImplementos;
        #endregion

        #region constructor
        public  LogicaImplemento() {
            this.listaImplementos = null;
        }
        #endregion

        #region agregarInventarioLogica
        public void agregarInventarioLogica(Implemento implemento) {
            try
            {

                ConexionBaseDatos.agregarInventarioDatos(implemento);

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
        
        }
        #endregion


        #region listarInventarioLogica
        public List<Implemento> listarInventarioLogica(Dojo dojo)
        {
            try
            {
                listaImplementos = ConexionBaseDatos.listarInventarioDatos(dojo);
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


        #region listarInventarioLogica2
        public List<Implemento> listarInventarioLogica2(Dojo dojo)
        {
            try
            {
                listaImplementos = ConexionBaseDatos.listarInventarioDatos2(dojo);
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


        #region implementoInventarioLogica
        public Implemento implementoInventarioLogica(int idImplemento)
        {
            Implemento implemento=null;
            try
            {
                implemento= ConexionBaseDatos.implementoInventarioDatos(idImplemento);
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
            
            return implemento;
        }
        #endregion



        #region eliminarInventarioLogica
        public void eliminarInventarioLogica(int idInventario) {

            try {

                ConexionBaseDatos.eliminarInventarioDatos(idInventario);
              
            }

            catch (ExceptionSKDConexionBD ex)
            {
                throw ex;
            }
            catch (ImplementoSinIDException ex)
            {

                throw ex;

            }
            catch (Exception ex)
            {

                throw ex;
            }
            
        
        
        
        }

        
       


        #endregion

        #region modificarInventarioLogica
        public void modificarInventarioLogica(Implemento implemento)
        {
            try
            {

                ConexionBaseDatos.modificarInventarioDatos(implemento);

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
            
        }
        #endregion
    }
}
