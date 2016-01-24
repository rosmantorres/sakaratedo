using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DominioSKD;

namespace DatosSKD.InterfazDAO.Modulo14
{
    public interface IDaoDiseno : IDao<Entidad, bool, Entidad>
    {
        Boolean GuardarDiseñoBD(Entidad elDiseño, Entidad laPlanilla);
        Entidad ConsultarDisenoID(Entidad solicitud);
    }
}
