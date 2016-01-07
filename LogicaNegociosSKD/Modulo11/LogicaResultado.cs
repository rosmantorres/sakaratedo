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
            List<Categoria> listaCategoria = BDResultado.listaCategoriasEvento(idEvento);
            return listaCategoria;
        }
    }
}
