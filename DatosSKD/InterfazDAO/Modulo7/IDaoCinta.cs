using DominioSKD;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatosSKD.InterfazDAO.Modulo7
{
    public interface IDaoCinta : IDao<Entidad, bool, Entidad>
    {
        List<Entidad> ListarCintasObtenidas(Entidad persona);

        Entidad UltimaCinta(Entidad persona);

        DateTime FechaCinta(Entidad persona, Entidad cinta);
    }
}
