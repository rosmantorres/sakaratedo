using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DominioSKD;
using ExcepcionesSKD.Modulo15;
using ExcepcionesSKD;
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


        #region eliminarInventarioInterfaz
        public void eliminarInventarioInterfaz(int idInventario) {
            LogicaImplemento logicaImplemento = null;

            try
            {
                logicaImplemento = new LogicaImplemento();
                logicaImplemento.eliminarInventarioLogica(idInventario);

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

        #region modificarInventarioInterfaz 

        public void modificarInventarioInterfaz(Implemento implemento)
        {

            LogicaImplemento logicaImplemento=null;
            try
            {
                logicaImplemento = new LogicaImplemento();
                logicaImplemento.modificarInventarioLogica(implemento);

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