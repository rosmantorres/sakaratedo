using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DominioSKD;


namespace DatosSKD.InterfazDAO.Modulo16
{
    public interface IdaoMensualidad : IDao<Entidad, bool, Entidad>
    {
        new Entidad ConsultarXId(Entidad entidad);
        List<Entidad> ListarMensualidad();
        Entidad DetallarMensualidad(Entidad entidad);
    }
}
