using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DominioSKD;

namespace DatosSKD.InterfazDAO.Modulo1
{
    public interface IDaoLogin : IDao<Entidad, bool, Entidad>
    {

        Entidad ObtenerUsuario(string nombre_usuario);
       
        String ValidarCorreoUsuario(string correo_usuario);
        

    }
}
