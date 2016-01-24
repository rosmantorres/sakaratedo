using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DatosSKD.Fabrica;
using DatosSKD.InterfazDAO.Modulo15;
using DominioSKD;
using ExcepcionesSKD.Modulo15.ExcepcionComando;
using ExcepcionesSKD;

namespace LogicaNegociosSKD.Comandos.Modulo15
{
    public class ComandoDojoId :Comando<Entidad>
    /// <summary>
    /// Comando ID Dojo
    /// </summary>
    {
        public override Entidad Ejecutar()
        {

            IDaoImplemento daoImplemeto = FabricaDAOSqlServer.ObtenerDAOImplemento();
            try
            {
                return daoImplemeto.DetallarDojo(this.LaEntidad);
            }
            catch (ExcepcionComandoDojoId ex)
            {
                ex = new ExcepcionComandoDojoId("Error en Comando dojo Id", new Exception());
                Logger.EscribirError("Error en Comando dojo Id", ex);
                throw ex;

            }

            catch (ExceptionSKD ex)
            {
                ex = new ExcepcionesSKD.ExceptionSKD("No se pudo completar la operacion", new Exception());
                Logger.EscribirError("Error en Comando dojo Id", ex);
                throw ex;
            }
            catch (Exception ex)
            {
                
                Logger.EscribirError("Error comando dojo id", ex);
                throw ex;
            }


    }

    }
}