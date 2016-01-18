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
    public class EjecutarModificarCinta : Comando<bool>
    {
        public EjecutarModificarCinta(Entidad nuevaEntidad)
            : base()
        {
            this.LaEntidad = nuevaEntidad;
        }

        public override bool Ejecutar()
        {
            Logger.EscribirInfo(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, RecursosDaoModulo5.MensajeInicioInfoLogger, System.Reflection.MethodBase.GetCurrentMethod().Name);

            try
            { 
            FabricaDAOSqlServer fabrica = new FabricaDAOSqlServer();
            IDaoCinta miDaoCinta = fabrica.ObtenerDaoCinta(); 
            miDaoCinta.Modificar(this.LaEntidad);

            Logger.EscribirInfo(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, RecursosDaoModulo5.MensajeFinInfoLogger, System.Reflection.MethodBase.GetCurrentMethod().Name);
           
            return false;
            

            }
            catch (ExcepcionesSKD.ExceptionSKDConexionBD ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);

                throw ex;
            }
            catch (ExcepcionesSKD.Modulo3.FormatoIncorrectoException ex)
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
