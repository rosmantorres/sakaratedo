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
         }

         #region Métodos
      /// <summary>
      /// Metodo que devuelve la lista de competencias inscritas
      /// </summary>
      /// <param name="idPersona"></param>
      /// <returns>Lista de competencias</returns>
         public List<DominioSKD.Competencia> obtenerListaDeCompetencias(int idPersona)
         {
             try
             {
                BDEvento baseDeDatosEvento = new BDEvento();
                return baseDeDatosEvento.ListarCompetenciasInscritas(idPersona);
             }
             catch (Exception e)
             {
                 throw e;
             }
         }

         /// <summary>
         /// Metodo que devuelve la lista de eventos inscritos
         /// </summary>
         /// <param name="idPersona"></param>
         /// <returns>Lista de eventos</returns>
         public List<DominioSKD.Evento> obtenerListaDeEventos(int idPersona)
         {
             try
             {
                BDEvento baseDeDatosEvento = new BDEvento();
                return baseDeDatosEvento.ListarEventosInscritos(idPersona);
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
                BDEvento baseDeDatosEvento = new BDEvento();
                return baseDeDatosEvento.DetallarEvento(idEvento);
             }
             catch (Exception e)
             {
                 throw e;
             }
         }
        /// <summary>
        /// Metodo que devuelve detalle de competencia
        /// </summary>
        /// <param name="idCompetencia"></param>
        /// <returns></returns>
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
