using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DominioSKD;

namespace DatosSKD.InterfazDAO.Modulo14

{
    public interface IDaoSolicitud : IDao<Entidad, bool, Entidad>
    {
         Boolean RegistrarSolicitudIDPersonaBD(Entidad laSolicitud);

         List<Entidad> ObtenerEventosSolicitud(int idPersona);

         List<Entidad> ObtenerCompetenciaSolicitud(int idPersona);

         List<Entidad> ConsultarPlanillasASolicitarBD();

         Boolean EliminarSolicitudBD(int idSolicitud);

         List<Entidad> ConsultarSolicitudes(int idPersona);
    }
}
