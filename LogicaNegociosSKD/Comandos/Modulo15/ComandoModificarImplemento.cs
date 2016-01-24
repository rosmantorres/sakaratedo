using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DatosSKD.Fabrica;
using DominioSKD;
using ExcepcionesSKD.Modulo15.ExcepcionComando;
using ExcepcionesSKD;

namespace LogicaNegociosSKD.Comandos.Modulo15
{

   public class ComandoModificarImplemento:Comando<bool>
    {
        /// <summary>
        /// Comando Modificar un Implemento
        /// </summary>
        /// <param name=""> id del Implemento</param>
       private Entidad implemento;
       private Entidad dojo;
       public override bool Ejecutar()
       {

           try
           {
               return FabricaDAOSqlServer.ObtenerDAOImplemento().modificarInventarioDatos(this.LaEntidad);

           }
           catch (ExcepcionComandoModificarImplemento ex)
           {
               ex = new ExcepcionComandoModificarImplemento("Error en Comando modificar implemento", new Exception());
               Logger.EscribirError("Error en Comando modificar implemento", ex);
               throw ex;

           }

           catch (ExceptionSKD ex)
           {
               ex = new ExcepcionesSKD.ExceptionSKD("No se pudo completar la operacion", new Exception());
               Logger.EscribirError("Error en Comando modificar implemento", ex);
               throw ex;
           }

           catch (Exception ex)
           {

               Logger.EscribirError("Error de en Comando modificar implemento", ex);
               throw ex;
           }
       }

    }
}
