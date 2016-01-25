using DominioSKD;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatosSKD.InterfazDAO.Modulo4
{
    public interface IDaoHistorialM : IDao<Entidad, bool, Entidad>
    {
        List<Entidad> ConsultarTodosDojo(Entidad parametro);
    }
}
