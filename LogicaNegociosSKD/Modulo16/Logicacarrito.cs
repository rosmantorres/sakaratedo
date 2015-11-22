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
        private Carrito carritoUsuario;
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
            //Procedemos a eliminar el item de la Base de Datos
            bool respuesta = carritoBD.eliminarItem(tipoObjeto,objetoBorrar,idUsuario);

            //Si el proceso fue exitoso procedemos a eliminar de forma local
            if (respuesta)
                this.carritoUsuario.eliminarItem(tipoObjeto,objetoBorrar);

            //Retornamos la respuesta
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
            //Procedemos a procesar la compra de los productos que estan en el carrito
            bool respuesta = carritoBD.registrarPago("Transferencia",null,1);

            //Limpiamos el carrito del Usuario
            carritoUsuario.limpiar();

            //Retonarmos el exito o fallo del proceso
            return respuesta;
        }

        /// <summary>
        /// Metodo que agrega los eventos al Carrito
        /// </summary>
        /// <param name="idUsuario">Indica el identificador del Usuario</param>
        /// <param name="idEvento">Indica el identificador del Evento</param>
        /// <returns>Si la operacion fue exitosa o fallida</returns>

         public bool agregarEventoaCarrito(int idUsuario, int idEvento) 
        {

            bool respuesta = carritoBD.agregarEventoaCarrito(1, 1);
            return respuesta;
        }


         /// <summary>
         /// Metodo que agrega las Matriculas al Carrito
         /// </summary>
         /// <param name="idUsuario">Indica el identificador del Usuario</param>
         /// <param name="idMatricula">Indica el identificador del Evento</param>
         /// <returns>Si la operacion fue exitosa o fallida</returns>

         public bool agregarMatriculaaCarrito(int idUsuario, int idMatricula)
         {

             bool respuesta = carritoBD.agregarMatriculaaCarrito(1, 1);
             return respuesta;
         }


         /// <summary>
         /// Metodo que agrega los Inventarios al Carrito
         /// </summary>
         /// <param name="idUsuario">Indica el identificador del Usuario</param>
         /// <param name="idInventario">Indica el identificador del Inventario</param>
         /// <returns>Si la operacion fue exitosa o fallida</returns>

         public bool agregarInventarioaCarrito(int idUsuario, int idInventario)
         {

             bool respuesta = carritoBD.agregarInventarioaCarrito( 1, 1);
             return respuesta;
         }
        #endregion
    }
}
