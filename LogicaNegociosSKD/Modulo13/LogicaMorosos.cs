using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DominioSKD;
using DatosSKD;
using DatosSKD.Modulo13;
namespace LogicaNegociosSKD.Modulo13
{

   public class LogicaMorosos
    {
       private DatosSKD.Modulo13.BDMoroso datos = new DatosSKD.Modulo13.BDMoroso();

       public List<DominioSKD.Morosidad> ConsultarLosMorosos()
       {
           return datos.ConsultarMorosos();
       }

    }
}
