﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DatosSKD.Fabrica;
using DatosSKD.InterfazDAO.Modulo5;
using DominioSKD;
using ExcepcionesSKD;

namespace LogicaNegociosSKD.Comandos.Modulo5
{
    public class EjecutarAgregarCinta : Comando<bool>
    {

        public EjecutarAgregarCinta(Entidad nuevaEntidad)
            : base()
        {
            this.LaEntidad = nuevaEntidad;
        }

        /// <summary>
        /// Método Ejecutar el Agregar una Cinta en la Base de Datos
        /// </summary>
        /// <returns>True si lo agrega, False si no</returns>
        public override bool Ejecutar()
        {
            Logger.EscribirInfo(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, RecursosComandosModulo5.MensajeInicioInfoLogger, System.Reflection.MethodBase.GetCurrentMethod().Name);

            try 
            { 

            IDaoCinta miDaoCinta = FabricaDAOSqlServer.ObtenerDaoCinta();

            miDaoCinta.Agregar(this.LaEntidad);
            Logger.EscribirInfo(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, RecursosComandosModulo5.MensajeFinInfoLogger, System.Reflection.MethodBase.GetCurrentMethod().Name);
           
            return true;
            
            }
            catch (ExcepcionesSKD.ExceptionSKDConexionBD ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);

                throw ex;
            }
            catch (ExcepcionesSKD.Modulo5.FormatoIncorrectoException ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);

                throw ex;
            }
            catch (ExcepcionesSKD.Modulo5.OrdenCintaRepetidoException ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);

                throw ex;
            }
            catch (ExcepcionesSKD.Modulo5.CintaRepetidaException ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);

                throw ex;
            }           
            catch (ExcepcionesSKD.ExceptionSKD ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);

                throw ex;
            }
                   
        }
 

    }
}
