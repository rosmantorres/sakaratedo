using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DominioSKD;

namespace DatosSKD.InterfazDAO.Modulo3
{
    public interface IDaoOrganizacion : IDao<Entidad, bool, Entidad>
    {
        bool ValidarNombreOrganizacion(Entidad parametro);

        bool ValidarEstilo(Entidad parametro);

        List<Entidad> ComboOrganizaciones();

        
    }
}
