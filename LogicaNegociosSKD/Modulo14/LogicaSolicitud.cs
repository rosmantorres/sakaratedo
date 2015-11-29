using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DominioSKD;
using DatosSKD.Modulo14;
namespace LogicaNegociosSKD.Modulo14
{
    public class LogicaSolicitud
    {
        private BDSolicitud datos = new BDSolicitud();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="idPersona"></param>
        /// <returns></returns>
        public List<DominioSKD.SolicitudPlanilla> ListarPlanillasSolicitadas(int idPersona)
        {
            return datos.ConsultarSolicitudes(idPersona);
        }
    }
}
