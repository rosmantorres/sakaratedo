using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DominioSKD;

namespace DatosSKD.InterfazDAO.Modulo1
{
    public interface IDaoRestablecer : IDao<Entidad, bool, Entidad>
    {
         bool RestablecerContrasena(string usuarioId, string contraseña);
    }
}
