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
        private List<DominioSKD.Evento> laListaDeEvento;
        #endregion

        #region Constructores
        /// <summary>
        /// Constructor que devuelve una lista de tipo evento
        /// </summary>
        public Logicaevento()
        {
            laListaDeEvento = obtenerListaDeEvento();
        }
        #endregion

        #region Propiedades

        #endregion

        #region Metodos
        /// <summary>
        /// Metodo que obtiene todos los objetos que estan en el inventario de eventos
        /// </summary>
        /// <param name=NONE>Este metodo no posee paso de parametros</param>
        /// <returns>Todo lo que tiene actualmente el inventario de los eventos (filtrado por usuario logeado)</returns>
        public List<DominioSKD.Evento> obtenerListaDeEvento()
        {
            try
            {
                return BDEvento.ListarEvento();
            }
            catch (Exception e)
            {
                throw e;
            }

        }


        /// <summary>
        /// Metodo que devueve el detalle completo de un implemento en especifico recibiendo como parametro su id.
        /// </summary>
        /// <param name="Id_implemento">Indica el objeto a detallar</param>
        /// <returns>Retorna un implemento en especifico</returns>
        public DominioSKD.Evento detalleEventoXId(int Id_evento)
        {
            try
            {
                return BDEvento.DetallarEvento(Id_evento);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        #endregion
    }
}
