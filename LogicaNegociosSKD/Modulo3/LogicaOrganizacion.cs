using DatosSKD.Modulo3;
using DominioSKD;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DatosSKD;
using DatosSKD.Modulo5;
using ExcepcionesSKD;

namespace LogicaNegociosSKD.Modulo3
{
    public class LogicaOrganizacion
    {
		#region Atributos
        private List<DominioSKD.Organizacion> ListaDeOrganizaciones;
        #endregion
		
		#region Get y Set
        public List<DominioSKD.Organizacion> listaDeOrganizaciones
        {
            get { return ListaDeOrganizaciones; }
            set { ListaDeOrganizaciones = value; }
        }
		#endregion
		
        public LogicaOrganizacion() { }

        public List<Organizacion> ListarOrganizacion()
        {
            
            try
            {
               return BDOrganizacion.ListarOrganizaciones();
			 } 
            catch (ExcepcionesSKD.ExceptionSKDConexionBD ex)
              {
                  throw ex;
              }
               catch (ExcepcionesSKD.ExceptionSKD ex)
              {
                 // Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);

                  throw ex;
              }
             

        } 


        public DominioSKD.Organizacion consultarOrganizacionXId(int idOrganizacion)
        {
            try
            {

                return BDOrganizacion.ConsultarOrganizacionXId(idOrganizacion);
            }
            catch (ExcepcionesSKD.ExceptionSKDConexionBD ex)
            {
                throw ex;
            }
            catch (ExcepcionesSKD.ExceptionSKD ex)
            {
                // Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);

                throw ex;
            }

        }

        public bool agregarOrganizacion(DominioSKD.Organizacion laOrganizacion)
        {
           // Logger.EscribirInfo(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, RecursosLogicaModulo12.MensajeInicioInfoLogger, System.Reflection.MethodBase.GetCurrentMethod().Name);
            try
            {

              //  Logger.EscribirInfo(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, RecursosLogicaModulo12.MensajeFinInfoLogger, System.Reflection.MethodBase.GetCurrentMethod().Name);

                return BDOrganizacion.AgregarOrganizacion(laOrganizacion);
            }
            catch (ExcepcionesSKD.ExceptionSKDConexionBD ex)
            {
              //  Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);

                throw ex;
            }
            catch (ExcepcionesSKD.ExceptionSKD ex)
            {
               // Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);

                throw ex;
            }
        }

        public bool modificarOrganizacion(DominioSKD.Organizacion laOrganizacion)
        {
            // Logger.EscribirInfo(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, RecursosLogicaModulo12.MensajeInicioInfoLogger, System.Reflection.MethodBase.GetCurrentMethod().Name);
            try
            {

                //  Logger.EscribirInfo(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, RecursosLogicaModulo12.MensajeFinInfoLogger, System.Reflection.MethodBase.GetCurrentMethod().Name);

                return BDOrganizacion.ModificarOrganizacion(laOrganizacion);
            }
            catch (ExcepcionesSKD.ExceptionSKDConexionBD ex)
            {
                //  Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);

                throw ex;
            }
            catch (ExcepcionesSKD.ExceptionSKD ex)
            {
                // Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);

                throw ex;
            }
        }

        public bool eliminarOrganizacion(int idOrganizacion)
        {
            // Logger.EscribirInfo(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, RecursosLogicaModulo12.MensajeInicioInfoLogger, System.Reflection.MethodBase.GetCurrentMethod().Name);
            try
            {

                //  Logger.EscribirInfo(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, RecursosLogicaModulo12.MensajeFinInfoLogger, System.Reflection.MethodBase.GetCurrentMethod().Name);

                return BDOrganizacion.EliminarOrganizacion(idOrganizacion);
            }
            catch (ExcepcionesSKD.ExceptionSKDConexionBD ex)
            {
                //  Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);

                throw ex;
            }
            
            catch (ExcepcionesSKD.ExceptionSKD ex)
            {
                // Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);

                throw ex;
            }
        }
    
    }
}
