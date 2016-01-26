using DominioSKD;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatosSKD.InterfazDAO.Modulo11
{
    public interface IDaoResultadoKata : IDao<List<Entidad>, bool, Entidad>
    {
        List<Entidad> ListarCompetenciasAsistidas();

        List<string> ListaEspecialidadesCompetencia(string idCompetencia);

        List<Entidad> ListaCategoriaCompetencia(Entidad entidad);

        List<Entidad> ListaAtletasParticipanCompetenciaKata(Entidad entidad);

        List<Entidad> ListaAtletasParticipanCompetenciaKataAmbos(Entidad entidad);

    }
}
