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
        bool BuscarRifDojo(Entidad parametro);

        List<Entidad> ConsultarTodosOrganizacion(Entidad parametro);

        int BuscarIdOrganizacion(Entidad parametro);

        bool EliminarDojo(Entidad parametro);
    }
}
