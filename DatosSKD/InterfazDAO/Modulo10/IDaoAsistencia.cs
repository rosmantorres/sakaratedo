using DominioSKD;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatosSKD.InterfazDAO.Modulo10
{
    public interface IDaoAsistencia : IDao<List<Entidad>, bool, Entidad>
    {
        List<Entidad> ListarEventosAsistidos();

        List<Entidad> ListarCompetenciasAsistidas();

        List<Entidad> ListaAsistentesEvento(string idEvento);

        List<Entidad> ListaNoAsistentesEvento(string idEvento);

        string ModificarFechas(string fecha);

        List<Entidad> ListaAsistentesCompetencia(string idCompetencia);

        List<Entidad> ListaNoAsistentesCompetencia(string idCompetencia);

        bool ModificarAsistenciaEvento(List<Entidad> listaEntidad);

        Entidad ConsultarCompetenciasXId(string idCompetencia);

        bool ModificarAsistenciaCompetencia(List<Entidad> listaEntidad);

        List<Entidad> ListaAtletasInscritosEvento(string idEvento);

        List<Entidad> ListaInasistentesPlanilla(string idEvento);

        bool AgregarAsistenciaEvento(List<Entidad> listaEntidad);

        bool AgregarAsistenciaCompetencia(List<Entidad> listaEntidad);

        List<Entidad> ListarHorariosCompetencia();

        List<Entidad> CompetenciasPorFecha(string fechaInicio);

        List<Entidad> ListaAtletasInscritosCompetencia(string idCompetencia);

        List<Entidad> ListaInasistentesPlanillaCompetencia(string idCompetencia);

        Entidad ConsultarCompetenciaXIdDetalle(string idCompetencia);

        Entidad ConsultarEventoXID(string idEvento);

        List<Entidad> TodasLasFechasEventoM10();

        List<Entidad> EventosPorRangosdeFechaM10(string fechaInicio);
    }
}
