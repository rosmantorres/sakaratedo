using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DatosSKD.Fabrica;
using DominioSKD;

namespace LogicaNegociosSKD.Comandos.Modulo15
{
   public class ComandoModificarImplemento:Comando<bool>
    {
       private Entidad implemento;
       private Entidad dojo;
       public override bool Ejecutar()
       {

           try
           {
               FabricaDAOSqlServer fabrica = new FabricaDAOSqlServer();
               return fabrica.ObtenerDAOImplemento().modificarInventarioDatos(this.LaEntidad);

           }
           catch (Exception ex)
           {

               throw ex;
           }
       }

    }
}
