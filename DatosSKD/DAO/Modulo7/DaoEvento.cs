using DatosSKD.InterfazDAO.Modulo7;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DominioSKD;

namespace DatosSKD.DAO.Modulo7
{
    public class DaoEvento : DAOGeneral, IDaoEvento
    {
        public bool Agregar(Entidad parametro)
        {
            throw new NotImplementedException();
        }

        public List<Entidad> ConsultarTodos()
        {
            throw new NotImplementedException();
        }

        public Entidad ConsultarXId(Entidad parametro)
        {
            throw new NotImplementedException();
        }

        public DateTime FechaInscripcionCompetencia(Entidad persona, Entidad competencia)
        {
            throw new NotImplementedException();
        }

        public DateTime FechaInscripcionEvento(Entidad persona, Entidad evento)
        {
            throw new NotImplementedException();
        }

        public DateTime FechaPagoEvento(Entidad persona, Entidad evento)
        {
            throw new NotImplementedException();
        }

        public List<Entidad> ListarCompetenciasAsistidas(Entidad persona)
        {
            throw new NotImplementedException();
        }

        public List<Entidad> ListarCompetenciasInscritas(Entidad persona)
        {
            throw new NotImplementedException();
        }

        public List<Entidad> ListarCompetenciasPaga(Entidad persona)
        {
            throw new NotImplementedException();
        }

        public List<Entidad> ListarEventosAsistidos(Entidad persona)
        {
            throw new NotImplementedException();
        }

        public List<Entidad> ListarEventosInscritos(Entidad persona)
        {
            throw new NotImplementedException();
        }

        public List<Entidad> ListarEventosPagos(Entidad persona)
        {
            throw new NotImplementedException();
        }

        public List<Entidad> ListarHorarioPracticaa(Entidad persona)
        {
            throw new NotImplementedException();
        }

        public bool Modificar(Entidad parametro)
        {
            throw new NotImplementedException();
        }

        public float MontoPagoEvento(Entidad persona, Entidad evento)
        {
            throw new NotImplementedException();
        }
    }
}
