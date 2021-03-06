﻿using DatosSKD.DAO.Modulo14;
using DatosSKD.InterfazDAO.Modulo14;
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
   public class ComandoObtenerPlanillaID : Comando<Entidad>
    {

        private int idPlanilla;

        public int IdPlanilla
        {
            get { return idPlanilla; }
            set { idPlanilla = value; }
        }
        /// <summary>Obtener una planilla por ID</summary>
        /// <param name="idPlanilla"></param>
        /// <returns>Regresa la planilla con su nombre, status y tipo planilla</returns>
        /// 
        public override Entidad Ejecutar()
        {
            DominioSKD.Entidades.Modulo14.Planilla planilla =
                (DominioSKD.Entidades.Modulo14.Planilla)FabricaEntidades.ObtenerPlanilla();
            try
            {

                IDaoPlanilla BaseDeDatoPlanilla =FabricaDAOSqlServer.ObtenerDAOPlanilla();
                
                planilla.ID = this.idPlanilla;
                Entidad entidad = BaseDeDatoPlanilla.ConsultarXId(planilla);
                planilla.Nombre = ((DominioSKD.Entidades.Modulo14.Planilla)entidad).Nombre;
                planilla.Dato = BaseDeDatoPlanilla.ObtenerDatosPlanillaID(idPlanilla);
               
            }
            catch (ExcepcionesSKD.ExceptionSKDConexionBD ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);

                throw ex;
            }
            catch (ExcepcionesSKD.Modulo14.BDPLanillaException ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                throw ex;
            }
            catch (Exception ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                throw ex;
            }
            return planilla;
        }
    }
}
