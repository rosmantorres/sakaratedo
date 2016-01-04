using DominioSKD;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatosSKD.InterfazDAO.Modulo7
{
    public interface IDaoEvento : IDao<Entidad, bool, Entidad>
    {
        List<Entidad> ListarCompetenciasAsistidas(Entidad persona);

        List<Entidad> ListarCompetenciasInscritas(Entidad persona);

        List<Entidad> ListarEventosAsistidos(Entidad persona);

        DateTime FechaPagoEvento(Entidad persona, Entidad evento);

        DateTime FechaInscripcionEvento(Entidad persona, Entidad evento);

        DateTime FechaInscripcionCompetencia(Entidad persona, Entidad competencia);

        List<Entidad> ListarEventosInscritos(Entidad persona);

        float MontoPagoEvento(Entidad persona, Entidad evento);

        List<Entidad> ListarEventosPagos(Entidad persona);

        List<Entidad> ListarCompetenciasPaga(Entidad persona);

        List<Entidad> ListarHorarioPracticaa(Entidad persona);       
    }
}
