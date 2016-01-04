using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DominioSKD;

namespace DatosSKD.InterfazDAO.Modulo16
{
    public interface IdaoImplemento : IDao<Entidad, bool, Entidad>
    {
        new List<Entidad> ConsultarTodos();
        List<Entidad> ListarImplemento();
        Entidad DetallarImplemento(int Id_implemento);
    }
}
