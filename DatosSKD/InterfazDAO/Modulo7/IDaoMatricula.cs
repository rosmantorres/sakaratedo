using DominioSKD;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatosSKD.InterfazDAO.Modulo7
{
    public interface IDaoMatricula : IDao<Entidad, bool, Entidad>
    {
        int MatriculaID(Entidad persona);

        float MontoPagoMatricula(Entidad persona, Entidad matricula);

        Boolean EstadoMatricula(Entidad persona);

        List<Entidad> ListarMatriculasPagas(Entidad persona);

        
    }
}
