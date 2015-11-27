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
    /// Clase para obtener la lista de eventos inscritos y el detalle de los mismos
    /// </summary>
    public class LogicaEventosInscritos
    {
        #region Atributos

        private List<DominioSKD.Evento> laListaDeEventoInscrito;

       #endregion

        /// <summary>
        /// Constructor
        /// </summary>
        #region Gets & Sets
         public List<DominioSKD.Evento> LaListaDeEventoInscrito
        {
            get { return laListaDeEventoInscrito; }
            set { laListaDeEventoInscrito = value; }
        }
        #endregion

        /// <summary>
        /// Constructor
        /// </summary>
         public LogicaEventosInscritos()
         {
             laListaDeEventoInscrito = obtenerListaDeEventos(); 
         }

         #region Métodos
         /// <summary>
        /// Método que obtiene la lista de eventos inscritos
        /// </summary>
        /// <returns>
        /// Lista de objetos tipo Evento
        /// </returns>
         public List<DominioSKD.Evento> obtenerListaDeEventos()
         {
             try
             {
                 return BDEvento.ListarEventosInscritos();
             }
             catch (Exception e)
             {
                 throw e; 
             }
         }
        /// <summary>
        /// Método que devuelve el detalle del evento inscrito
        /// </summary>
        /// <param name="idEvento"></param>
        /// <returns>
        /// Objeto de tipo evento
        /// </returns>
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
