using DatosSKD.Modulo11;
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
            List<Categoria> listaCategoria = BDResultado.listaCategoriasCompetencia(competencia);
            return listaCategoria;
        }

        /// <summary>
        /// Metodo que permite obtener de base de datos todos los atletas que participaran a una competencia por id de especialidad, competencia y categoria
        /// </summary>
        /// <param name="competencia">id de la categoria</param>
        /// <returns>lista de atletas</returns>
        public static List<Persona> listaAtletasParticipanCompetencia(Competencia competencia)
        {
            List<Persona> listaPersona = BDResultado.listaAtletasParticipanCompetencia(competencia);
            return listaPersona;
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
    }
}
