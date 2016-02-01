using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExcepcionesSKD.Modulo16
{
    /// <summary>
    /// Clase que controla la excepcion cuando un carrito esta completamente vacio y se desea realizar una operacion
    /// que inplique tener algo en el carrito
    /// </summary>
    public class CarritoVacioException: ExceptionSKD
    {
        /// <summary>
        /// Constructor vacio de la clase
        /// </summary>
        public CarritoVacioException():base()
        {

        }

        /// <summary>
        /// Constructor que obtiene el mensaje de la excepcion
        /// </summary>
        /// <param name="mensaje">El mensaje de error que se pasa al ocurrir la excepcion</param>
        public CarritoVacioException(String mensaje):base(mensaje)
        {

        }

        /// <summary>
        /// Constructor que obtiene el mensaje y la excepcion
        /// </summary>
        /// <param name="mensaje">El mensaje de error que se pasa al ocurrir la excepcion</param>
        /// <param name="excepcion">La excepcion como tal capturada</param>
        public CarritoVacioException(String mensaje, Exception e):base(mensaje, e)
        {

        }

        /// <summary>
        /// Constructor que obtiene el codigo del error, el mensaje y la excepcion
        /// </summary>
        /// <param name="codigo">Identificador especifico del error ocurrido</param>
        /// <param name="mensaje"><El mensaje de error que se pasa al ocurrir la excepcion/param>
        /// <param name="excepcion">La excepcion como tal capturada</param>
        public CarritoVacioException(String codigo, String mensaje, Exception e):base(codigo, mensaje, e)
        {

        }
    }
}
