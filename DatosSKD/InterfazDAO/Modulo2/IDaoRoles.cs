using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DominioSKD.Entidades.Modulo2;
using DominioSKD;
using DatosSKD;

namespace DatosSKD.InterfazDAO.Modulo2
{
    public interface IDaoRoles : IDao<Entidad, bool, Entidad>
    {
       
        bool EliminarRol(string idUsuario, string idRol);
       
        bool AgregarRol(string idUsuario, string idRol);
      
        List<Entidad> consultarRolesUsuario(string idUsuario);
       

    }
}
