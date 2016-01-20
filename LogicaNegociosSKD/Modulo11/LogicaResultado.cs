using DatosSKD.Modulo11;
using DatosSKD.Modulo9;
using DominioSKD;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegociosSKD.Modulo11
{
    public class LogicaResultado
    {
        /// <summary>
        /// Metodo que retorna de la BD todos los eventos asistidos
        /// </summary>
        /// <returns>Lista de Eventos</returns>
        public static List<Evento> ListarResultadosEventosPasados()
        {
            List<Evento> listaEventos = BDResultado.ListarResultadosEventosPasados();
            return listaEventos;
        }

        /// <summary>
        /// Metodo que retorna de la BD todas las competencias asistidas
        /// </summary>
        /// <returns>Lista de Competencias</returns>
        public static List<Competencia> ListarCompetenciasAsistidas()
        {
            List<Competencia> listaCompetencias = BDResultado.ListarCompetenciasAsistidas();
            return listaCompetencias;
        }

        /// <summary>
        /// Metodo que retorna de la BD todas las categorias de un evento
        /// </summary>
        /// <param name="idEvento">id del evento</param>
        /// <returns>Lista de categorias</returns>
        public static List<Categoria> listaCategoriasEvento(string idEvento)
        {
            List<Categoria> lista = new List<Categoria>();
            Categoria categoria = new Categoria();
            categoria.Id_categoria = 0;
            lista.Add(categoria);
            List<Categoria> listaCategoria = BDResultado.listaCategoriasEvento(idEvento);
            foreach (Categoria cate in listaCategoria)
            {
                lista.Add(cate);
            }
            return lista;
        }

        /// <summary>
        /// Metodo que retorna de la BD todos los atletas que compiten en una categoria especifica en un evento de ascenso
        /// </summary>
        /// <param name="evento">id del evento</param>
        /// <returns>Lista de categorias</returns>
        public static List<Inscripcion> listaAtletasEnCategoriaYAscenso(Evento evento)
        {
            List<Inscripcion> listaInscripcion = BDResultado.listaAtletasEnCategoriaYAscenso(evento);
            return listaInscripcion;
        }

        /// <summary>
        /// Metodo que permite obtener de base de datos todas las categorias que participan en una competencia 
        /// </summary>
        /// <param name="idCompetencia">id de la competencia</param>
        /// <returns>Lista de categorias</returns>
        public static List<string> listaEspecialidadesCompetencia(string idCompetencia)
        {
            List<string> lista = BDResultado.listaEspecialidadesCompetencia(idCompetencia);
            return lista;
        }

        /// <summary>
        /// Metodo que permite obtener de base de datos todas las categorias que participan en una competencia 
        /// </summary>
        /// <param name="competencia">id de la competencia</param>
        /// <returns>Lista de categorias</returns>
        public static List<Categoria> listaCategoriasCompetencia(Competencia competencia)
        {
            List<Categoria> lista = new List<Categoria>();
            Categoria categoria = new Categoria();
            categoria.Id_categoria = 0;
            lista.Add(categoria);
            List<Categoria> listaCategoria = BDResultado.listaCategoriasCompetencia(competencia);
            foreach (Categoria cate in listaCategoria)
            {
                lista.Add(cate);
            }
            return lista;
        }

        /// <summary>
        /// Metodo que permite obtener de base de datos todos los atletas que participaran a una competencia por id de especialidad, competencia y categoria
        /// </summary>
        /// <param name="competencia">id de la categoria</param>
        /// <returns>lista de Inscripciones</returns>
        public static List<Inscripcion> listaAtletasParticipanCompetenciaKata(Competencia competencia)
        {
            List<Inscripcion> listaInscripcion = BDResultado.listaAtletasParticipanCompetenciaKata(competencia);
            return listaInscripcion;
        }

        /// <summary>
        /// Metodo que permite obtener de base de datos todos los atletas que participaran a una competencia por id de especialidad, competencia y categoria
        /// </summary>
        /// <param name="competencia">id de la categoria</param>
        /// <returns>lista de Inscripciones</returns>
        public static List<Inscripcion> listaAtletasParticipanCompetenciaKataAmbas(Competencia competencia)
        {
            List<Inscripcion> listaInscripcion = BDResultado.listaAtletasParticipanCompetenciaKataAmbas(competencia);
            return listaInscripcion;
        }

        /// <summary>
        /// Metodo que permite obtener de base de datos todos los atletas que participaran a una competencia por id de especialidad, competencia y categoria
        /// </summary>
        /// <param name="competencia">id de la categoria</param>
        /// <returns>lista de Resultado Kumite</returns>
        public static List<ResultadoKumite> listaAtletasParticipanCompetenciaKumite(Competencia competencia)
        {
            List<ResultadoKumite> listaKumite = BDResultado.listaAtletasParticipanCompetenciaKumite(competencia);
            return listaKumite;
        }

        /// <summary>
        /// Metodo que permite obtener de base de datos todos los atletas que participaran a una competencia por id de especialidad, competencia y categoria
        /// </summary>
        /// <param name="competencia">id de la categoria</param>
        /// <returns>lista de Resultado Kumite</returns>
        public static List<ResultadoKumite> listaAtletasParticipanCompetenciaKumiteAmbas(Competencia competencia)
        {
            List<ResultadoKumite> listaKumite = BDResultado.listaAtletasParticipanCompetenciaKumiteAmbas(competencia);
            return listaKumite;
        }

        /// <summary>
        /// Metodo que permite modificar de base de datos un resultado de un atleta en un examen de ascenso
        /// </summary>
        /// <param name="lista">lista de resultado ascenso</param>
        /// <returns>true si se pudo modificar</returns>
        public static bool ModificarResultadoAscenso(List<ResultadoAscenso> lista)
        {
            return BDResultado.ModificarResultadoAscenso(lista);
        }

        /// <summary>
        /// Metodo que permite modificar de base de datos un resultado de un atleta en una competencia de especialidad kata
        /// </summary>
        /// <param name="lista">lista de resultado kata</param>
        /// <returns>true si se pudo modificar</returns>
        public static bool ModificarResultadoKata(List<ResultadoKata> lista)
        {
            return BDResultado.ModificarResultadoKata(lista);
        }

        /// <summary>
        /// Metodo que permite modificar de base de datos un resultado de un atleta en una competencia de especialidad kumite
        /// </summary>
        /// <param name="lista">lista de resultado kumite</param>
        /// <returns>true si se pudo modificar</returns>
        public static bool ModificarResultadoKumite(List<ResultadoKumite> lista)
        {
            return BDResultado.ModificarResultadoKumite(lista);
        }

        /// <summary>
        /// Metodo que retorna de la BD todas las fechas donde hay eventos
        /// </summary>
        /// <returns>Lista de horarios</returns>
        public static List<Horario> ListarHorariosEventosAscensos()
        {
            BDEvento baseE = new BDEvento();
            List<Horario> listaHorario = baseE.ListarHorariosAscensos();
            return listaHorario;
        }

        /// <summary>
        /// Metodo que retorna de la BD todos los eventos de tipo ascenso por fecha
        /// </summary>
        /// <returns>Lista de eventos</returns>
        public static List<Evento> EventosPorFechaAscenso(String fechaInicio, String fechaFin)
        {
            BDEvento baseE = new BDEvento();
            List<Evento> lista = new List<Evento>();
            Evento evento = new Evento();
            evento.Id_evento = 0;
            evento.Nombre = RecursosLogicaModulo11.NombreEvento0;
            lista.Add(evento);
            List<Evento> listaEvento = baseE.AcsensosPorFecha(fechaInicio, fechaFin);
            foreach (Evento evento2 in listaEvento)
            {
                lista.Add(evento2);
            }
            return lista;
        }

        /// <summary>
        /// Metodo que retorna de la BD todos los atletas que compiten en una categoria especifica en un evento de ascenso
        /// </summary>
        /// <param name="evento">id del evento</param>
        /// <returns>Lista de inscripciones</returns>
        public static List<Inscripcion> listaInscritosExamenAscenso(Evento evento)
        {
            List<Inscripcion> listaInscripcion = BDResultado.listaInscritosExamenAscenso(evento);
            return listaInscripcion;
        }

        /// <summary>
        /// Metodo que permite obtener de base de datos todos los atletas que participaran a una competencia por id de especialidad, competencia y categoria
        /// </summary>
        /// <param name="evento">id del evento</param>
        /// <returns>Lista de inscripciones</returns>
        public static List<Inscripcion> listaInscritosCompetencia(Competencia competencia)
        {
            List<Inscripcion> listaInscripcion = BDResultado.listaInscritosCompetencia(competencia);
            return listaInscripcion;
        }

        /// <summary>
        /// Metodo que permite agregar en la base de datos una lista de resultados de examen de ascenso
        /// </summary>
        /// <param name="lista">lista de Resultados Ascensos</param>
        /// <returns>true si se pudo agregar</returns>
        public static bool agregarResultadoAscenso(List<ResultadoAscenso> lista)
        {
            return BDResultado.agregarResultadoAscenso(lista);
        }

        /// <summary>
        /// Metodo que permite agregar en la base de datos un resultado de un atleta en una competencia de especialidad kata
        /// </summary>
        /// <param name="lista">lista de resultado kata</param>
        /// <returns>true si se pudo agregar</returns>
        public static bool agregarResultadoKata(List<ResultadoKata> lista)
        {
            return BDResultado.agregarResultadoKata(lista);
        }

        /// <summary>
        /// Metodo que permite agregar en la base de datos un resultado de un atleta en una competencia de especialidad kumite
        /// </summary>
        /// <param name="lista">lista de resultado kumite</param>
        /// <returns>true si se pudo agregar</returns>
        public static bool agregarResultadoKumite(List<ResultadoKumite> lista)
        {
            return BDResultado.agregarResultadoKumite(lista);
        }

        /// <summary>
        /// Metodo que permite Consultar un evento por id
        /// </summary>
        /// <param name="idEvento">Id del evento</param>
        /// <returns>Retorna un evento</returns>
        public static Evento ConsultarEventoDetalle(String idEvento)
        {
            Evento evento = new Evento();
            evento = BDResultado.ConsultarEventoDetalle(idEvento);
            return evento;
        }
    }
}
