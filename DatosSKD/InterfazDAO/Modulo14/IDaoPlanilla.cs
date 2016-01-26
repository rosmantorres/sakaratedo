using DominioSKD;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatosSKD.InterfazDAO.Modulo14
{
    public interface IDaoPlanilla : IDao<Entidad, bool, Entidad>
    {
         List<Entidad> ObtenerTipoPlanilla();

         List<String> ObtenerDatosBD();

         Boolean RegistrarDatosPlanillaBD(String nombrePlanilla, String datoPlanilla);

         Boolean RegistrarTipoPlanilla(String nombreTipoPlanilla);

         int ObtenerIdTipoPlanilla(String nombreTipo);

         List<String> ObtenerDatosPlanillaID(int idPlanilla);

         List<String> ObtenerDatosPlanillaID1(int idPlanilla);

         Boolean EliminarDatosPlanillaBD(int idPlanilla);

         Boolean RegistrarDatosPlanillaIdBD(int idPlanilla, String datoPlanilla);

    }
}
