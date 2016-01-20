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

       
       public override bool Ejecutar()
       {

           FabricaDAOSqlServer fabrica = new FabricaDAOSqlServer();
           IDaoImplemento daoImplemeto = fabrica.ObtenerDAOImplemento();
           try
           {
               return daoImplemeto.Agregar(this.LaEntidad);
           
           }
           catch (Exception ex)
           {

               throw ex;
           }
       }


    }
}
