using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DatosSKD;
using DatosSKD.Modulo7;

namespace LogicaNegociosSKD.Modulo7
{
    /// <summary>
    /// Clase para obtener la lista de eventos pagados de los atletas y la descripción de un evento
    /// </summary>
    public class LogicaEventosPagos
    {
        #region Atributos
        private List<DominioSKD.Evento> laListaDeEventos;
        #endregion

        #region Get y Set
        public List<DominioSKD.Evento> LaListaDeEventos
        {
            get { return laListaDeEventos; }
            set { laListaDeEventos = value; }
        }
        #endregion

        #region Métodos
        /// <summary>
        /// Constructor
        /// </summary>
        public LogicaEventosPagos()
        {
        }

        /// <summary>
        /// Método que obtiene la lista de eventos asistidos
        /// </summary>
        /// <returns>Lista de objetos tipo Evento</returns>
        public List<DominioSKD.Evento> obtenerListaDeEventos(int idPersona)
        {
            try
            {
                BDEvento baseDeDatosEvento = new BDEvento();
                return baseDeDatosEvento.ListarEventosPagos(idPersona);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        /// <summary>
        /// Método que obtiene la lista de competencias asistidas
        /// </summary>
        /// <returns>Lista de objetos tipo Competencia</returns>
        public List<DominioSKD.Competencia> obtenerListaDeCompetencias(int idPersona)
        {
            try
            {
                BDEvento baseDeDatosEvento = new BDEvento();
                return baseDeDatosEvento.ListarCompetenciasPagas(idPersona);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        /// <summary>
        /// Método que obtiene el detalle de cada evento por su ID
        /// </summary>
        /// <param name="idEvento">Número entero que representa el ID del evento</param>
        /// <returns>Objeto de tipo Evento</returns>
        public DominioSKD.Evento detalleEventoID(int idEvento)
        {
            try
            {
                BDEvento baseDeDatosEvento = new BDEvento();
                return baseDeDatosEvento.DetallarEvento(idEvento);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        /// <summary>
        /// Método que obtiene la fecha de inscripción de una persona en un evento
        /// </summary>
        /// <param name="idPersona">Número entero que representa el ID de la persona</param>
        /// <param name="idEvento">Número entero que representa el ID del evento</param>
        /// <returns>DateTime con la fecha de inscripción</returns>
        public DateTime obtenerFechaInscripcion(int idPersona, int idEvento)
        {
            try
            {
                BDEvento baseDeDatosEvento = new BDEvento();
                return baseDeDatosEvento.fechaInscripcion(idPersona, idEvento);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        /// <summary>
        /// Método que obtiene el detalle de cada competencia por su ID
        /// </summary>
        /// <param name="idCompetencia">Número entero que representa el ID de la competencia</param>
        /// <returns>Objeto de tipo Competencia</returns>
        public DominioSKD.Competencia detalleCompetenciaID(int idCompetencia)
        {
            try
            {
                BDCompetencia baseDeDatosCompetencia = new BDCompetencia();
                return baseDeDatosCompetencia.DetallarCompetencia(idCompetencia);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        #endregion

    }
}

