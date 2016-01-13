﻿using DatosSKD.DAO.Modulo14;
using DatosSKD.Fabrica;
using DominioSKD;
using ExcepcionesSKD;
using LogicaNegociosSKD.Fabrica;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegociosSKD.Comandos.Modulo14
{
    public class ComandoModificarPlanillaIDTipo : Comando<Entidad>
    {
        private String tipoPlanilla;

        public  String TipoPlanilla
        {
            get { return tipoPlanilla; }
            set { tipoPlanilla = value; }
        }
        public override Entidad Ejecutar()
        {
            FabricaDAOSqlServer fabrica = new FabricaDAOSqlServer();
            FabricaComandos fabricaComandos = new FabricaComandos();
            Planilla laPlanilla = (Planilla)this.LaEntidad;
            ComandoModificarPlanillaID modificar = (ComandoModificarPlanillaID)fabricaComandos.ObtenerComandoModificarPlanillaID();
            
            try
            {
                DaoPlanilla BaseDeDatoPlanilla = (DaoPlanilla)fabrica.ObtenerDAOPlanilla();
                int idTipoPlanilla = BaseDeDatoPlanilla.ObtenerIdTipoPlanilla(this.tipoPlanilla);
                laPlanilla.IDtipoPlanilla = idTipoPlanilla;
                modificar.LaEntidad = (Entidad)modificar.LaEntidad;
                modificar.Ejecutar();
                
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
            return laPlanilla;
        }
    }
}
