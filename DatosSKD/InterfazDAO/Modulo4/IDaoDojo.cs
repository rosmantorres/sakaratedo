using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DominioSKD;

namespace DatosSKD.InterfazDAO.Modulo4
{
    public interface IDaoDojo : IDao<Entidad, bool, Entidad>
    {
        bool BuscarRifDojoo(Entidad parametro);

       // bool BuscarIDCompetencia(Entidad parametro);

        //List<Entidad> M12ListarOrganizaciones();

        //List<Entidad> M12ListarCintas();

        //String ModificarFechas(String fecha);

        //bool BuscarNombreCompetenciaAgregar(Entidad parametro);
    }
}
