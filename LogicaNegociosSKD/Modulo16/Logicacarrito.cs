using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DominioSKD;
using DatosSKD.Modulo16;
using ExcepcionesSKD.Modulo16.ExcepcionesDeDatos;
using ExcepcionesSKD.Modulo16;
using ExcepcionesSKD;

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
            //Obtengo los datos de las tres tablas
            List<Implemento> listaImplemento = carritoBD.getImplemento(idUsuario);
         //   List<Matricula> listaMatricula = carritoBD.getMatricula(idUsuario);
            List<Evento> listaEvento = carritoBD.getEvento(idUsuario);

            //Creo el carrito y anexo la informacion
            Carrito elCarrito = new Carrito();
            elCarrito.ListaImplemento = listaImplemento;
            elCarrito.Listaevento = listaEvento;

            //Retorno el carrito del usuario
            return elCarrito;
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
        public bool registrarPago(int tipoPago, List<int> datos, int idUsuario)
        {
            //Preparamos la respuesta del proceso
            bool respuesta;

            //Procedemos a procesar la compra de los productos que estan en el carrito
            if (tipoPago == 1)
                respuesta = carritoBD.registrarPago("Tarjeta",null,idUsuario);
            else if (tipoPago == 2)
                respuesta = carritoBD.registrarPago("Deposito",null,idUsuario);
            else
                respuesta = carritoBD.registrarPago("Transferencia",null,idUsuario);

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

            try
            {
                return BDCarrito.agregarEventoaCarrito(idUsuario, idEvento);
            }


            catch (ParametroIncorrectoException ex)
            {
                throw new ParametroIncorrectoException(RecursosLogicaModulo16.Codigo_ExcepcionParametro,
                    RecursosLogicaModulo16.Mensaje__ExcepcionParametro, ex);
            }
            catch (AtributoIncorrectoException ex)
            {
                throw new AtributoIncorrectoException(RecursosLogicaModulo16.Codigo_ExcepcionAtributo,
                    RecursosLogicaModulo16.Mensaje_ExcepcionAtributo, ex);
            }
            catch (Exception ex)
            {
                throw new AtributoIncorrectoException(RecursosLogicaModulo16.Codigo_ExcepcionAtributo,
                 RecursosLogicaModulo16.Mensaje_ExcepcionAtributo, ex);

            }



        }





        /// <summary>
        /// Metodo que agrega las Matriculas al Carrito
        /// </summary>
        /// <param name="idUsuario">Indica el identificador del Usuario</param>
        /// <param name="idMatricula">Indica el identificador del Evento</param>
        /// <returns>Si la operacion fue exitosa o fallida</returns>

        public bool agregarMatriculaaCarrito(int idUsuario, int idMatricula)
        {

            try
            {
                return BDCarrito.agregarMatriculaaCarrito(idUsuario, idMatricula);
            }


            catch (ParametroIncorrectoException ex)
            {
                throw new ParametroIncorrectoException(RecursosLogicaModulo16.Codigo_ExcepcionParametro,
                    RecursosLogicaModulo16.Mensaje__ExcepcionParametro, ex);
            }
            catch (AtributoIncorrectoException ex)
            {
                throw new AtributoIncorrectoException(RecursosLogicaModulo16.Codigo_ExcepcionAtributo,
                    RecursosLogicaModulo16.Mensaje_ExcepcionAtributo, ex);
            }
            catch (Exception ex)
            {
                throw new AtributoIncorrectoException(RecursosLogicaModulo16.Codigo_ExcepcionAtributo,
                 RecursosLogicaModulo16.Mensaje_ExcepcionAtributo, ex);

            }


        }





        /// <summary>
        /// Metodo que agrega los Inventarios al Carrito
        /// </summary>
        /// <param name="idUsuario">Indica el identificador del Usuario</param>
        /// <param name="idInventario">Indica el identificador del Inventario</param>
        /// <returns>Si la operacion fue exitosa o fallida</returns>

        public bool agregarInventarioaCarrito(int idUsuario, int idInventario)
        {

            try
            {
                return BDCarrito.agregarInventarioaCarrito(idUsuario, idInventario);
            }


            catch (ParametroIncorrectoException ex)
            {
                throw new ParametroIncorrectoException(RecursosLogicaModulo16.Codigo_ExcepcionParametro,
                    RecursosLogicaModulo16.Mensaje__ExcepcionParametro, ex);
            }
            catch (AtributoIncorrectoException ex)
            {
                throw new AtributoIncorrectoException(RecursosLogicaModulo16.Codigo_ExcepcionAtributo,
                    RecursosLogicaModulo16.Mensaje_ExcepcionAtributo, ex);
            }
            catch (Exception ex)
            {
                throw new AtributoIncorrectoException(RecursosLogicaModulo16.Codigo_ExcepcionAtributo,
                 RecursosLogicaModulo16.Mensaje_ExcepcionAtributo, ex);

            }
        }
        #endregion
    }
}
