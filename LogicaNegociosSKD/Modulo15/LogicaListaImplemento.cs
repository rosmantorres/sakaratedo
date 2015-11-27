using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        public void agregarInventarioLogica(String nombre_implemento,
                                             String tipo_implemento,
                                             String marca_implemento,
                                             String color_implemento,
                                             String talla_implemento,
                                             int dojo, int cantidad,
                                             int stock_minimo,
                                             String estatus_implemento,
                                             double precio_implemento) {
            try {

                ConexionBaseDatos.agregarInventarioDatos(nombre_implemento,
                                                      tipo_implemento,
                                                      marca_implemento,
                                                      color_implemento,
                                                      talla_implemento,
                                                      dojo, cantidad,
                                                      stock_minimo,
                                                      estatus_implemento,
                                                      precio_implemento);
            
            }catch(Exception ex){
                throw ex;
            }
        
        }
        #endregion


        #region listarInventarioLogica
        public List<Implemento> listarInventarioLogica()
        {
                try
                {
                    listaImplementos = ConexionBaseDatos.listarInventarioDatos();
                }
                catch (Exception ex) {

                    throw ex;
                }
                return listaImplementos;
        }
        #endregion


        #region listarInventarioLogica2
        public List<Implemento> listarInventarioLogica2()
        {
            try
            {
                listaImplementos = ConexionBaseDatos.listarInventarioDatos2();
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
            catch(Exception ex){

                throw ex;
            
            }
        
        
        
        }

        
       


        #endregion

        #region modificarInventarioLogica
        public void modificarInventarioLogica(
                                              int id_implemento,
                                             String nombre_implemento,
                                             String tipo_implemento,
                                             String marca_implemento,
                                             String color_implemento,
                                             String talla_implemento,
                                             int dojo, int cantidad,
                                             int stock_minimo,
                                             String estatus_implemento,
                                             double precio_implemento)
        {
            try
            {

                ConexionBaseDatos.modificarInventarioDatos(
                                                     id_implemento,
                                                     nombre_implemento,
                                                      tipo_implemento,
                                                      marca_implemento,
                                                      color_implemento,
                                                      talla_implemento,
                                                      dojo, cantidad,
                                                      stock_minimo,
                                                      estatus_implemento,
                                                      precio_implemento);

            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        #endregion
    }
}
