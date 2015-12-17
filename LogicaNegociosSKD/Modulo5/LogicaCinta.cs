using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DatosSKD;
using DatosSKD.Modulo5;
using ExcepcionesSKD;
using DominioSKD;

namespace LogicaNegociosSKD.Modulo5
{
    public class LogicaCinta
    {
        #region Atributos
        private List<DominioSKD.Cinta> ListaDeCintas;
        #endregion

        #region Get y Set
        public List<DominioSKD.Cinta> listaDeCintas
        {
            get { return ListaDeCintas; }
            set { ListaDeCintas = value; }
        }
        #endregion

        #region constructores
          public LogicaCinta()
        {
        }
        #endregion

        #region metodos
        public List<DominioSKD.Cinta> obtenerListaDeCinta()
          {
              try
              {

                  return BDCinta.ListarCintas();
              }
              catch (ExcepcionesSKD.ExceptionSKDConexionBD ex)
              {
                  throw ex;
              }
              catch (ExcepcionesSKD.Modulo5.FormatoIncorrectoException ex)
              {
                 // Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);

                  throw ex;
              }
              catch (ExcepcionesSKD.ExceptionSKD ex)
              {
                 // Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);

                  throw ex;
              }

          }

        public List<DominioSKD.Cinta> obtenerListaDeCintaXOrganizacion(int idOrganizacion)
        {
            try
            {   
                List<Cinta> listaCintas = new List<Cinta>();

                listaCintas = BDCinta.ListarCintasXOrganizacion(idOrganizacion);

                return listaCintas;
            }
            catch (ExcepcionesSKD.ExceptionSKDConexionBD ex)
            {
                throw ex;
            }
            catch (ExcepcionesSKD.Modulo5.FormatoIncorrectoException ex)
            {
                // Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);

                throw ex;
            }
            catch (ExcepcionesSKD.ExceptionSKD ex)
            {
                // Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);

                throw ex;
            }

        }

        public DominioSKD.Cinta detalleDeCinta(int idCinta)
        {
            try
            {

                return BDCinta.DetallarCinta(idCinta);
            }
            catch (ExcepcionesSKD.ExceptionSKDConexionBD ex)
            {
                throw ex;
            }
            catch (ExcepcionesSKD.Modulo5.FormatoIncorrectoException ex)
            {
                // Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);

                throw ex;
            }
            catch (ExcepcionesSKD.ExceptionSKD ex)
            {
                // Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);

                throw ex;
            }

        }

        public bool agregarCinta(DominioSKD.Cinta laCinta)
        {
           // Logger.EscribirInfo(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, RecursosLogicaModulo12.MensajeInicioInfoLogger, System.Reflection.MethodBase.GetCurrentMethod().Name);
            try
            {

              //  Logger.EscribirInfo(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, RecursosLogicaModulo12.MensajeFinInfoLogger, System.Reflection.MethodBase.GetCurrentMethod().Name);

                return BDCinta.AgregarCinta(laCinta);
            }
            catch (ExcepcionesSKD.ExceptionSKDConexionBD ex)
            {
              //  Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);

                throw ex;
            }
             catch (ExcepcionesSKD.Modulo5.FormatoIncorrectoException ex)
            {
                //Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);

                throw ex;
            }
            catch (ExcepcionesSKD.ExceptionSKD ex)
            {
               // Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);

                throw ex;
            }
        }

        public bool modificarCinta(DominioSKD.Cinta laCinta)
        {
            // Logger.EscribirInfo(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, RecursosLogicaModulo12.MensajeInicioInfoLogger, System.Reflection.MethodBase.GetCurrentMethod().Name);
            try
            {

                //  Logger.EscribirInfo(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, RecursosLogicaModulo12.MensajeFinInfoLogger, System.Reflection.MethodBase.GetCurrentMethod().Name);

                return BDCinta.ModificarCinta(laCinta);
            }
            catch (ExcepcionesSKD.ExceptionSKDConexionBD ex)
            {
                //  Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);

                throw ex;
            }
            catch (ExcepcionesSKD.Modulo5.FormatoIncorrectoException ex)
            {
                //Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);

                throw ex;
            }
            catch (ExcepcionesSKD.ExceptionSKD ex)
            {
                // Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);

                throw ex;
            }
        }

        public bool eliminarCinta(int idCinta)
        {
            // Logger.EscribirInfo(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, RecursosLogicaModulo12.MensajeInicioInfoLogger, System.Reflection.MethodBase.GetCurrentMethod().Name);
            try
            {

                //  Logger.EscribirInfo(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, RecursosLogicaModulo12.MensajeFinInfoLogger, System.Reflection.MethodBase.GetCurrentMethod().Name);

                return BDCinta.EliminarCinta(idCinta);
            }
            catch (ExcepcionesSKD.ExceptionSKDConexionBD ex)
            {
                //  Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);

                throw ex;
            }
            catch (ExcepcionesSKD.Modulo5.FormatoIncorrectoException ex)
            {
                //Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);

                throw ex;
            }
            catch (ExcepcionesSKD.ExceptionSKD ex)
            {
                // Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);

                throw ex;
            }
        }
        #endregion

    }
}
