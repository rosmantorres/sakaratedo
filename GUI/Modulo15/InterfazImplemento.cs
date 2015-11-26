using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DominioSKD;
using LogicaNegociosSKD.Modulo15;

namespace templateApp.GUI.Modulo15
{
    public class InterfazImplemento
    {

        #region agregarInventarioInterfaz
        public void agregarInventarioInterfaz(String nombre_implemento,
                                          String tipo_implemento,
                                          String marca_implemento,
                                          String color_implemento,
                                          String talla_implemento,
                                          int dojo, int cantidad,
                                          int stock_minimo,
                                          String estatus_implemento,
                                          double precio_implemento)
        {

            LogicaImplemento logicaImplemento=null;
            try
            {
                logicaImplemento = new LogicaImplemento();
                logicaImplemento.agregarInventarioLogica(nombre_implemento,
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

        #region listarInventarioInterfaz
        public List<Implemento> listarInventarioInterfaz()
        {
            List<Implemento> listaImplementos = null;
            LogicaImplemento logicaImplemento = null;

            try
            {
                logicaImplemento = new LogicaImplemento();
                listaImplementos = logicaImplemento.listarInventarioLogica();
            }
            catch (Exception ex)
            {

                throw ex;
            }
            return listaImplementos;
        }
        #endregion


        #region listarInventarioInterfaz2
        public List<Implemento> listarInventarioInterfaz2()
        {
            List<Implemento> listaImplementos = null;
            LogicaImplemento logicaImplemento = null;

            try
            {
                logicaImplemento = new LogicaImplemento();
                listaImplementos = logicaImplemento.listarInventarioLogica2();
            }
            catch (Exception ex)
            {

                throw ex;
            }
            return listaImplementos;
        }
        #endregion


        #region implementoInventarioInterfaz
        public Implemento implementoInventarioInterfaz(int idImplemento)
        {
            Implemento implemento = null;
            LogicaImplemento logicaImplemento = null;

            try
            {
                logicaImplemento = new LogicaImplemento();
                implemento = logicaImplemento.implementoInventarioLogica(idImplemento);
            }
            catch (Exception ex)
            {

                throw ex;
            }
            return implemento;
        }
        #endregion


        #region eliminarInventarioInterfaz
        public void eliminarInventarioInterfaz(int idInventario) {
            LogicaImplemento logicaImplemento = null;

            try
            {
                logicaImplemento = new LogicaImplemento();
                logicaImplemento.eliminarInventarioLogica(idInventario);

            }
            catch (Exception ex)
            {

                throw ex;

            }
        
        
        }
        #endregion

        #region modificarInventarioInterfaz 

        public void modificarInventarioInterfaz(String nombre_implemento,
                                         String tipo_implemento,
                                         String marca_implemento,
                                         String color_implemento,
                                         String talla_implemento,
                                         int dojo, int cantidad,
                                         int stock_minimo,
                                         String estatus_implemento,
                                         double precio_implemento)
        {

            LogicaImplemento logicaImplemento=null;
            try
            {
                logicaImplemento = new LogicaImplemento();
                logicaImplemento.modificarInventarioLogica(nombre_implemento,
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