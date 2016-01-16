﻿using DatosSKD.DAO.Modulo14;
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
   public class ComandoModificarSolicitudID : Comando<Entidad>
    {
       public override Entidad Ejecutar()
        {
        

            FabricaDAOSqlServer fabrica = new FabricaDAOSqlServer();
            DaoSolicitud BaseDeDatoSolicitud = (DaoSolicitud)fabrica.ObtenerDAOSolicitud();
            SolicitudP laSolicitud = (SolicitudP)this.LaEntidad;

            try
            {
                BaseDeDatoSolicitud.Modificar(laSolicitud);

               
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
            return laSolicitud;
        }
    }
}
