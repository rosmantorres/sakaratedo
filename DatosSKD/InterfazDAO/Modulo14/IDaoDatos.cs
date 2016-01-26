using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DominioSKD;

namespace DatosSKD.InterfazDAO.Modulo14
{
    public interface IDaoDatos : IDao<Entidad, bool, Entidad>
    {
        DominioSKD.Persona ConsultarPersona(int idPersona);
        DominioSKD.Dojo ConsultarDojo(int idDojo);
        List<string> ConsultarMatricula(int idDojo, int idPersona);
        Entidad ConsultarOrganizacion(int idOrganizacion);
        DominioSKD.Evento ConsultarEvento(int idIns);
        Entidad ConsultarCompetencia(int idIns);
        Entidad ConsultarSolicitud(int idSolicitud);
    }
}
