﻿using DatosSKD.DAO.Modulo14;
using DatosSKD.Fabrica;
using DominioSKD;
using DominioSKD.Fabrica;
using ExcepcionesSKD;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegociosSKD.Comandos.Modulo14
{
   public class ComandoObtenerSolicitudID : Comando<Entidad>
    {
        private int idSolicitud;

        public int IDSolicitud
        {
            get { return idSolicitud; }
            set { idSolicitud = value; }
        }
        public override Entidad Ejecutar()
        {
            DaoSolicitud BaseDeDatoSolicitud = (DaoSolicitud)FabricaDAOSqlServer.ObtenerDAOSolicitud();
            DominioSKD.Entidades.Modulo14.SolicitudP solicitud =
                (DominioSKD.Entidades.Modulo14.SolicitudP)FabricaEntidades.ObtenerSolicitudP(); 
            try
            {
                solicitud.ID = idSolicitud;
                solicitud =
                    (DominioSKD.Entidades.Modulo14.SolicitudP
                    )BaseDeDatoSolicitud.ConsultarXId(solicitud);
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
            return solicitud;
        }
    }
}
