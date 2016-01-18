using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DatosSKD.Fabrica;
using DatosSKD.InterfazDAO.Modulo15;
using DominioSKD;

namespace LogicaNegociosSKD.Comandos.Modulo15
{
   public  class ComandoAgregarImplemento:Comando<Boolean>
    {

       private Entidad implemento;
       public override bool Ejecutar()
       {

           FabricaDAOSqlServer fabrica = new FabricaDAOSqlServer();
           IDaoImplemento daoImplemeto = fabrica.ObtenerDAOImplemento();
           try
           {
               daoImplemeto.Agregar(this.LaEntidad);
               return true;
           }
           catch (Exception ex)
           {

               throw ex;
           }
           return false;
       }


    }
}
