using DominioSKD;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatosSKD.InterfazDAO.Modulo11
{
    public interface IDaoResultadoKumite : IDao<List<Entidad>, bool, Entidad>
    {
        List<Entidad> ListaAtletasParticipanCompetenciaKumite(Entidad entidad);

        List<Entidad> ListaAtletasParticipanCompetenciaKumiteAmbos(Entidad entidad);

        List<Entidad> ListaInscritosCompetencia(Entidad entidad);
    }
}
