﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DatosSKD.Fabrica;
using DominioSKD;
using DominioSKD.Entidades.Modulo15;
using ExcepcionesSKD.Modulo15.ExcepcionComando;
using ExcepcionesSKD;

namespace LogicaNegociosSKD.Comandos.Modulo15
{    
    public class ComandoImplementoXId:Comando<Entidad>
    {
        /// <summary>
        /// Comando Consultar implemento por ID
        /// </summary>
        private Entidad dojo;
        private Entidad implemento;

        public override Entidad Ejecutar()
        {

            try
            {
                return FabricaDAOSqlServer.ObtenerDAOImplemento().implementoInventarioDatos(((Implemento)this.LaEntidad).Id_Implemento);


            }
            catch (ExcepcionComandoImplementoXId ex)
            {
                ex = new ExcepcionComandoImplementoXId(RecursosComandoModulo15.ErrorCIXI, new Exception());
                Logger.EscribirError(RecursosComandoModulo15.ErrorCIXI, ex);
                throw ex;

            }

            catch (ExceptionSKD ex)
            {
                ex = new ExcepcionesSKD.ExceptionSKD(RecursosComandoModulo15.ErrorOperacion, new Exception());
                Logger.EscribirError(RecursosComandoModulo15.ErrorCIXI, ex);
                throw ex;
            }

            catch (Exception ex)
            {

                Logger.EscribirError(RecursosComandoModulo15.ErrorCIXI, ex);
                throw ex;
            }
        }


    }
}
