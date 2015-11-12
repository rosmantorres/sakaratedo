using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DominioSKD;
using DatosSKD.Modulo16;

namespace LogicaNegociosSKD.Modulo16
{
    /// <summary>
    /// Clase que gestiona toda la logica del Carrito del usuario
    /// </summary>
    public class Logicacarrito
    {
        #region Atributos
        /// <summary>
        /// Atributos de la clase Logicacarrito
        /// </summary>
        private BDCarrito carritoBD;
        #endregion

        #region Constructores
        /// <summary>
        /// Constructor vacio de la clase Logicacarrito que inicializa el atributo carritoBD
        /// </summary>
        public Logicacarrito()
        {
            carritoBD = new BDCarrito();
        }
        #endregion

        #region Propiedades

        #endregion

        #region Metodos
        /// <summary>
        /// Metodo que obtiene todos los objetos que estan en el carrito del usuario
        /// </summary>
        /// <param name="idUsuario">El usuario el cual se desea ver su carrito</param>
        /// <returns>Todo lo que tiene actualmente en su carrito</returns>
        public Carrito verCarrito(int idUsuario)
        {
            /*
            List<Inventario> listaInventario = carritoBD.getInventario(1);
            List<Matricula> listaMatricula = carritoBD.getMatricula(1);
            List<Evento> listaEvento = carritoBD.getEvento(1);*/
            return null;
        }

        /// <summary>
        /// Metodo que elimina un objeto que haya en el carrito del usuario
        /// </summary>
        /// <param name="tipoObjeto">Especifica si se borrara una matricula, un inventario o evento</param>
        /// <param name="objetoBorrar">El objeto en especifico a borrar</param>
        /// <param name="idUsuario">El usuario al que se alterara su carrito</param>
        /// <returns>Si la operacion fue exitosa o fallida</returns>
        public bool eliminarItem(int tipoObjeto, int objetoBorrar, int idUsuario)
        {
            bool respuesta = carritoBD.eliminarItem("Evento",1,1);
            return respuesta;
        }

        /// <summary>
        /// Metodo que registra el pago de los productos existentes en el carrito
        /// </summary>
        /// <param name="tipoPago">Indica cual de las formas se eligio para pagar</param>
        /// <param name="datos">Todos los datos pertinentes de ese tipo de pago</param>
        /// <returns>Si la operacion fue exitosa o fallida</returns>
        public bool registrarPago(int tipoPago, List<int> datos)
        {
            bool respuesta = carritoBD.registrarPago("Transferencia",null,1);
            return respuesta;
        }
        #endregion
    }
}
