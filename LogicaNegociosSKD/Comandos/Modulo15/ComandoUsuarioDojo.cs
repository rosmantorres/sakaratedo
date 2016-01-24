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
    public class ComandoUsuarioDojo : Comando<int>
    {

        

        public override int Ejecutar()
        {

            IDaoImplemento daoImplemeto = FabricaDAOSqlServer.ObtenerDAOImplemento();
            try
            {
               return daoImplemeto.usuarioImplementoDatos(((Usuario)this.LaEntidad)._Nombre);
            }
            catch (ExcepcionComandoUsuarioDojo ex)
            {
                ex = new ExcepcionComandoUsuarioDojo("Error en Comando usuario Dojo", new Exception());
                Logger.EscribirError("Error en Comando usuario Dojo", ex);
                throw ex;

            }

            catch (ExceptionSKD ex)
            {
                ex = new ExcepcionesSKD.ExceptionSKD("No se pudo completar la operacion", new Exception());
                Logger.EscribirError("Error en Comando usuario Dojo", ex);
                throw ex;
            }
        }
    }
}
