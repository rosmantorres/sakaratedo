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
    /// <summary>
    /// Comando Agregar Implemento
    /// </summary>
    /// <param name="">La Entidad Implemento que se va a agregar </param>
    /// <returns>un true si agrego el implemento, false si no lo agrego</returns>
   public  class ComandoAgregarImplemento:Comando<Boolean>
    {

       
       public override bool Ejecutar()
       {

           IDaoImplemento daoImplemeto = FabricaDAOSqlServer.ObtenerDAOImplemento();
           try
           {
               return daoImplemeto.Agregar(this.LaEntidad);
           
           }
           catch (ExcepcionComandoAgregarImplemento ex)
           {
               ex = new ExcepcionComandoAgregarImplemento(RecursosComandoModulo15.ErrorCAgregar, new Exception());
               Logger.EscribirError(RecursosComandoModulo15.ErrorCAgregar, ex);
               throw ex;

           }

           catch (ExceptionSKD ex)
           {
               ex = new ExcepcionesSKD.ExceptionSKD(RecursosComandoModulo15.ErrorOperacion, new Exception());
               Logger.EscribirError(RecursosComandoModulo15.ErrorCAgregar, ex);
               throw ex;
           }

           catch (Exception ex)
           {

               Logger.EscribirError(RecursosComandoModulo15.ErrorCAgregar, ex);
               throw ex;
           }
       }


    }
}
