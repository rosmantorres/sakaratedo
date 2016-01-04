using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DominioSKD;

namespace DatosSKD.InterfazDAO.Modulo12
{
    public interface IDaoCompetencia : IDao<Entidad, bool, Entidad>
    {
        bool BuscarNombreCompetencia(Entidad parametro);

        bool BuscarIDCompetencia(Entidad parametro);

        List<Entidad> M12ListarOrganizaciones();

        List<Entidad> M12ListarCintas();

        String ModificarFechas(String fecha);

        bool BuscarNombreCompetenciaAgregar(Entidad parametro);
    }
}
