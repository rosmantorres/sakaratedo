﻿using DatosSKD.DAO.Modulo14;
using DatosSKD.InterfazDAO.Modulo14;
using DatosSKD.Fabrica;
using DominioSKD;
using DominioSKD.Entidades.Modulo14;
using ExcepcionesSKD;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegociosSKD.Comandos.Modulo14
{
   public class ComandoEventosSolicitud : Comando<List<Entidad>>
    {
        private int idPersona;

        public int IDPersona
        {
            get { return idPersona; }
            set { idPersona = value; }
        }
        /// <summary>Para determinar que datos son requeridos en la solicitud</summary>
        /// <param name="idPlanilla"> id de la planilla solicitada</param>
        /// <returns>Regresa una lista de bool para determinar que datos son requeridos</returns>
        public override List<Entidad> Ejecutar()
        {
            IDaoSolicitud BaseDeDatoSolicitud = FabricaDAOSqlServer.ObtenerDAOSolicitud();
            List<Entidad> eventos = new List<Entidad>();
            try
            {
                eventos = BaseDeDatoSolicitud.ObtenerEventosSolicitud(this.idPersona);
                
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
            return eventos;
        }
    }
}
