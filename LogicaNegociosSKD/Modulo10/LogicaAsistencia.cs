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

        public static bool ModificarAsistenciaEvento(List<Asistencia> asistencias)
        {
            return BDAsistencia.ModificarAsistenciaE(asistencias);
        }

        public static bool ModificarAsistenciaCompetencia(List<Asistencia> asistencias)
        {
            return BDAsistencia.ModificarAsistenciaC(asistencias);
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
        /// <returns>Lista de personas</returns>
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
        /// <returns>Lista de horarios</returns>
        public static List<Horario> ListarHorariosEventos()
        {
            BDEvento baseE = new BDEvento();
            List<Horario> listaHorario = baseE.ListarHorarios();
            return listaHorario;
        }

        /// <summary>
        /// Metodo que retorna de la BD todas las fechas donde hay competencias
        /// </summary>
        /// <returns>Lista de horarios</returns>
        public static List<Horario> ListarHorariosCompetencias()
        {
            return BDAsistencia.ListarHorariosCompetencias();
        }

        /// <summary>
        /// Metodo que retorna de la BD todos los eventos por fecha
        /// </summary>
        /// <returns>Lista de eventos</returns>
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
        /// Metodo que retorna de la BD todas las competencias por una fecha
        /// </summary>
        /// <returns>Lista de Competencias</returns>
        public static List<Competencia> competenciasPorFecha(string fechaInicio)
        {
            return BDAsistencia.competenciasPorFecha(fechaInicio);
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

        /// <summary>
        /// Metodo que retorna de la BD una lista de atletas inscritos a una competencia
        /// </summary>
        /// <param name="idCompetencia">Id de la competencia</param>
        /// <returns>Objeto de tipo competencia</returns>

        public static List<Persona> inscritosCompetencias(String idCompetencia)
        {
            List<Persona> listaAtletas = BDAsistencia.listaAtletasInscritosCompetencia(idCompetencia);
            return listaAtletas;
        }

        public static List<Inscripcion> listaAtletasInasistentesPlanilla(String idEvento)
        {
            List<Inscripcion> listaInscritos = BDAsistencia.listaInasistentesPlanilla(idEvento);
            return listaInscritos;
        }

        public static List<Inscripcion> listaAtletasInasistentesPlanillaCompetencia(String idCompetencia)
        {
            List<Inscripcion> listaInscritos = BDAsistencia.listaInasistentesPlanillaCompetencia(idCompetencia);
            return listaInscritos;
        }

        public static bool agregarAsistenciaEvento(List<Asistencia> asistencia)
        {
            return BDAsistencia.agregarAsistenciaEvento(asistencia);
        }

        public static bool agregarAsistenciaCompetencia(List<Asistencia> asistencia)
        {
            return BDAsistencia.agregarAsistenciaCompetencia(asistencia);
        }

        /// <summary>
        /// Metodo que permite obtener de base de datos una competencia por id
        /// </summary>
        /// <param name="idCompetencia">id de la competencia</param>
        /// <returns>Una Competencia</returns>
        public static Competencia consultarCompetenciasXIDDetalle(string idCompetencia)
        {
            Competencia competencia = BDAsistencia.consultarCompetenciasXIDDetalle(idCompetencia);
            return competencia;
        }

        /// <summary>
        /// Metodo que retorna de la BD un evento dado el ID
        /// </summary>
        /// <param name="idEvento">Id del evento</param>
        /// <returns>Objeto de tipo evento</returns>

        public static Evento ConsultarEvento(String idEvento)
        {
            //Logger.EscribirInfo(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, RecursosLogicaModulo9.MensajeInicioInfoLogger, System.Reflection.MethodBase.GetCurrentMethod().Name);
            Evento evento = new Evento();
            try
            {
                BDEvento baseDeDatosEvento = new BDEvento();
                evento = baseDeDatosEvento.ConsultarEvento(idEvento);
            }
            catch (ExcepcionesSKD.ExceptionSKDConexionBD ex)
            {

                //Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);

                throw ex;
            }
            catch (ExcepcionesSKD.Modulo12.FormatoIncorrectoException ex)
            {
                //Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);

                throw ex;
            }
            catch (ExcepcionesSKD.ExceptionSKD ex)
            {
                //Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);

                throw ex;
            }

            //Logger.EscribirInfo(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, RecursosLogicaModulo9.MensajeFinInfoLogger, System.Reflection.MethodBase.GetCurrentMethod().Name);
            return evento;
        }
    }
}
