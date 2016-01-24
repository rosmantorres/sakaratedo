using DominioSKD;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatosSKD.InterfazDAO.Modulo11
{
    public interface IDaoResultadoAscenso : IDao<List<Entidad>, bool, Entidad>
    {
        List<Entidad> ListarResultadosEventosPasados();

        List<Entidad> ListaCategoriaEvento(string idEvento);

        List<Entidad> ListaAtletasEnCategoriaYAscenso(Entidad entidad);

        List<Entidad> ListaInscritosExamenAscenso(Entidad entidad);

        Entidad ConsultarEventoDetalle(string idEvento);
    }
}
