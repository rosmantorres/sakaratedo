using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DominioSKD;
using DatosSKD.Modulo16;

namespace LogicaNegociosSKD.Modulo16
{
    public class Logicaevento
    {
        #region Atributos
        /// <summary>
        /// Atributos de la clase Logicaevento
        /// </summary>
        private BDEvento eventoBD;
        #endregion

        #region Constructores
        /// <summary>
        /// Constructor vacio de la clase Logicaevento que inicializa el atributo eventoBD
        /// </summary>
        public Logicaevento()
        {
            eventoBD = new BDEvento();
        }
        #endregion

        #region Propiedades

        #endregion

        #region Metodos
        /* Evento detallarEvento( int objetoDetallar , int idUsario)
          {  

            
           }
       */
        /// <summary>
        /// Metodo que obtiene todos los objetos que estan en el inventario de eventos
        /// </summary>
        /// <param name=NONE>Este metodo no posee paso de parametros</param>
        /// <returns>Todo lo que tiene actualmente el inventario de los eventos</returns>
        /*  public Evento consultarEvento()
        {         
            return List<Evento>;
        }*/

        #endregion
    }
}
