using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegociosSKD.Modulo14
{
    public class LogicaPlanilla
    {
        private DatosSKD.Modulo14.BDPlanilla datos = new DatosSKD.Modulo14.BDPlanilla();

        public List<DominioSKD.Planilla> ConsultarPlanillas()
        {
            return datos.ConsultarPlanillasCreadas();
        }
    }
}
