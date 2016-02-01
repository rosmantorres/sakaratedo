using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DominioSKD;

namespace DatosSKD.InterfazDAO.Modulo5
{
    public interface IDaoCinta : IDao<Entidad, bool, Entidad>
    {
        
        bool ValidarOrganizacion(Entidad parametro);
        
        bool ValidarOrdenCinta(Entidad parametro);

        bool ValidarNombreCinta(Entidad parametro);

        List<Entidad> ListarCintasXOrganizacion(Entidad parametro);

        bool ModificarStatus(Entidad parametro);
    }
}
