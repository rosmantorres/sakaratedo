using DatosSKD.Modulo10;
using DominioSKD;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegociosSKD.Modulo10
{
    public class LogicaAsistencia
    {
        /// <summary>
        /// Metodo que retorna de la BD todos los eventos asistidos
        /// </summary>
        /// <returns>Lista de Eventos</returns>
        public static List<Evento> ListarEventosAsistidos()
        {
            List<Evento> listaEventos = BDAsistencia.ListarEventosAsistidos();
            return listaEventos;
        }

        /// <summary>
        /// Metodo que retorna de la BD todas las competencias asistidas
        /// </summary>
        /// <returns>Lista de Competencias</returns>
        public static List<Competencia> ListarCompetenciasAsistidas()
        {
            List<Competencia> listaCompetencias = BDAsistencia.ListarCompetenciasAsistidas();
            return listaCompetencias;
        }

        /// <summary>
        /// Metodo que retorna de la BD un evento dado el ID
        /// </summary>
        /// <param name="idEvento">Id del evento</param>
        /// <returns>Objeto de tipo evento</returns>

        public static List<Persona> listaAsistentes(String idEvento)
        {
            List<Persona> listaAtletas = BDAsistencia.listaAsistentes(idEvento);
            return listaAtletas;
        }
    }
}
