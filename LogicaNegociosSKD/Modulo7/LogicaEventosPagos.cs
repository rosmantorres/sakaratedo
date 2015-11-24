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
    /// Clase para obtener la lista de eventos pagados y la descripción de un evento
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
            laListaDeEventos = obtenerListaDeEventos();
        }

        /// <summary>
        /// Método que obtiene la lista de eventos asistidos
        /// </summary>
        /// <returns>Lista de objetos tipo Evento</returns>
        public List<DominioSKD.Evento> obtenerListaDeEventos() 
        {
            try 
            {
                return BDEvento.ListarEventosPagos();
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
        /// <returns>un objeto de tipo Evento</returns>
        public DominioSKD.Evento detalleEventoID(int idEvento)
        {
            try
            {
                return BDEvento.DetallarEvento(idEvento);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        #endregion

    }
}
