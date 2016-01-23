﻿using DatosSKD.DAO.Modulo14;
using DatosSKD.InterfazDAO.Modulo14;
using DatosSKD.Fabrica;
using DominioSKD;
using ExcepcionesSKD;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegociosSKD.Comandos.Modulo14
{
    public class ComandoRegistrarSolicitudPlanilla : Comando<bool>
    {
        public override bool Ejecutar()
        {
            IDaoSolicitud BaseDeDatoSolicitud = FabricaDAOSqlServer.ObtenerDAOSolicitud();
            DominioSKD.Entidades.Modulo14.SolicitudP laSolicitud =
                (DominioSKD.Entidades.Modulo14.SolicitudP)this.LaEntidad;
            bool result = false;
            try
            {
                result = BaseDeDatoSolicitud.Agregar(laSolicitud);
            }
            catch (ExcepcionesSKD.ExceptionSKDConexionBD ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);

                throw ex;
            }
            catch (ExcepcionesSKD.Modulo14.BDSolicitudException ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                throw ex;
            }
            catch (Exception ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                throw ex;
            }
            return result;
        }
    }
}
