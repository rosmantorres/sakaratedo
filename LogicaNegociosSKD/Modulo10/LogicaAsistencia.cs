using DatosSKD.Modulo10;
using DatosSKD.Modulo9;
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

        public static List<Persona> listaNoAsistentes(String idEvento)
        {
            List<Persona> listaAtletas = BDAsistencia.listaNoAsistentes(idEvento);
            return listaAtletas;
        }

        public static void ModificarAsistenciaEvento(int ins, int eve, string asistio)
        {
            BDAsistencia.ModificarAsistenciaE(ins, eve, asistio);
        }

        public static void ModificarAsistenciaCompetencia(int ins, int com, string asistio)
        {
            BDAsistencia.ModificarAsistenciaC(ins, com, asistio);
        }

        public static Competencia consultarCompetenciasXID(String idCompetencia)
        {
            Competencia competencia = BDAsistencia.consultarCompetenciasXID(idCompetencia);
            return competencia;
        }

        /// <summary>
        /// Metodo que retorna de la BD un evento dado el ID
        /// </summary>
        /// <param name="idEvento">Id del evento</param>
        /// <returns>Objeto de tipo evento</returns>
        public static List<Persona> listaAsistentesCompetencia(String idEvento)
        {
            List<Persona> listaAtletas = BDAsistencia.listaAsistentesCompetencia(idEvento);
            return listaAtletas;
        }

        public static List<Persona> listaNoAsistentesCompetencia(String idEvento)
        {
            List<Persona> listaAtletas = BDAsistencia.listaNoAsistentesCompetencia(idEvento);
            return listaAtletas;
        }

        /// <summary>
        /// Metodo que retorna de la BD todas las fechas donde hay eventos
        /// </summary>
        /// <returns>Lista de Competencias</returns>
        public static List<Horario> ListarHorariosEventos()
        {
            BDEvento baseE = new BDEvento();
            List<Horario> listaHorario = baseE.ListarHorarios();
            return listaHorario;
        }

        /// <summary>
        /// Metodo que retorna de la BD todos los eventos por fecha
        /// </summary>
        /// <returns>Lista de Competencias</returns>
        public static List<Evento> EventosPorFecha(String fechaInicio, String fechaFin)
        {
            BDEvento baseE = new BDEvento();
            List<Evento> lista = new List<Evento>();
            Evento evento = new Evento();
            evento.Id_evento = 0;
            evento.Nombre = RecursosLogicaModulo10.NombreEvento0;
            lista.Add(evento);
            List<Evento> listaEvento = baseE.EventosPorFecha(fechaInicio, fechaFin);
            foreach (Evento evento2 in listaEvento)
            {
                lista.Add(evento2);
            }
            return lista;
        }

        /// <summary>
        /// Metodo que retorna de la BD una lista de atletas inscritos a un evento
        /// </summary>
        /// <param name="idEvento">Id del evento</param>
        /// <returns>Objeto de tipo evento</returns>

        public static List<Persona> inscritosAlEvento(String idEvento)
        {
            List<Persona> listaAtletas = BDAsistencia.listaAtletasInscritosEvento(idEvento);
            return listaAtletas;
        }

        public static List<Inscripcion> listaAtletasInasistentesPlanilla(String idEvento)
        {
            List<Inscripcion> listaInscritos = BDAsistencia.listaInasistentesPlanilla(idEvento);
            return listaInscritos;
        }
    }
}
