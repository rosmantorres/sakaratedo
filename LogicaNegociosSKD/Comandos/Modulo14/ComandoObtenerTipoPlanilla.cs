﻿using DatosSKD.Fabrica;
using DominioSKD;
using ExcepcionesSKD;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DatosSKD.DAO.Modulo14;

namespace LogicaNegociosSKD.Comandos.Modulo14
{
  public class ComandoObtenerTipoPlanilla : Comando<List<Entidad>>
    {
      public override List<Entidad> Ejecutar()
        {
            FabricaDAOSqlServer fabrica = new FabricaDAOSqlServer();
            List<Entidad> listaTipoPlanilla = new List<Entidad>();
            try
            {
                
                DaoPlanilla BaseDeDatoPlanilla = (DaoPlanilla)fabrica.ObtenerDAOPlanilla();
                listaTipoPlanilla = BaseDeDatoPlanilla.ObtenerTipoPlanilla();

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
            return listaTipoPlanilla;


        }


    }
}
