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
               ex = new ExcepcionComandoAgregarImplemento("Error en Comando Agregar Implemento", new Exception());
               Logger.EscribirError("Error en Comando Agregar Implemento", ex);
               throw ex;

           }

           catch (ExceptionSKD ex)
           {
               ex = new ExcepcionesSKD.ExceptionSKD("No se pudo completar la operacion", new Exception());
               Logger.EscribirError("Error en Comando Agregar Implemento", ex);
               throw ex;
           }

           catch (Exception ex)
           {

               Logger.EscribirError("Error de en Comando Agregar implemento datos ", ex);
               throw ex;
           }
       }


    }
}
