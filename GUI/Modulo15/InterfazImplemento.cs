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
        public void agregarInventarioInterfaz(Implemento implemento)
        {

            LogicaImplemento logicaImplemento=null;
            try
            {
                logicaImplemento = new LogicaImplemento();
                logicaImplemento.agregarInventarioLogica(implemento);

            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        #endregion

        #region listarInventarioInterfaz
        public List<Implemento> listarInventarioInterfaz(Dojo dojo)
        {
            List<Implemento> listaImplementos = null;
            LogicaImplemento logicaImplemento = null;

            try
            {
                logicaImplemento = new LogicaImplemento();
                listaImplementos = logicaImplemento.listarInventarioLogica(dojo);
            }
            catch (Exception ex)
            {

                throw ex;
            }
            return listaImplementos;
        }
        #endregion


        #region listarInventarioInterfaz2
        public List<Implemento> listarInventarioInterfaz2(Dojo dojo)
        {
            List<Implemento> listaImplementos = null;
            LogicaImplemento logicaImplemento = null;

            try
            {
                logicaImplemento = new LogicaImplemento();
                listaImplementos = logicaImplemento.listarInventarioLogica2(dojo);
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

        public void modificarInventarioInterfaz(Implemento implemento)
        {

            LogicaImplemento logicaImplemento=null;
            try
            {
                logicaImplemento = new LogicaImplemento();
                logicaImplemento.modificarInventarioLogica(implemento);

            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        #endregion
    
    }
}