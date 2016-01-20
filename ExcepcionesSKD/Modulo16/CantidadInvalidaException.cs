using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExcepcionesSKD.Modulo16
{
    /// <summary>
    /// Clase que se encarga de controlar la excepcion cuando el usuario ingresa una cantidad
    /// que no sea entera, sea 0 o sea genativa
    /// </summary>
    public class CantidadInvalidaException: ExceptionSKD
    {
        /// <summary>
        /// Constructor vacio de la clase
        /// </summary>
        public CantidadInvalidaException():base()
        {

        }

        /// <summary>
        /// Constructor que obtiene el mensaje de la excepcion
        /// </summary>
        /// <param name="mensaje">El mensaje de error que se pasa al ocurrir la excepcion</param>
        public CantidadInvalidaException(String mensaje):base(mensaje)
        {

        }

        /// <summary>
        /// Constructor que obtiene el mensaje y la excepcion
        /// </summary>
        /// <param name="mensaje">El mensaje de error que se pasa al ocurrir la excepcion</param>
        /// <param name="excepcion">La excepcion como tal capturada</param>
        public CantidadInvalidaException(String mensaje, Exception e):base(mensaje, e)
        {

        }

        /// <summary>
        /// Constructor que obtiene el codigo del error, el mensaje y la excepcion
        /// </summary>
        /// <param name="codigo">Identificador especifico del error ocurrido</param>
        /// <param name="mensaje"><El mensaje de error que se pasa al ocurrir la excepcion/param>
        /// <param name="excepcion">La excepcion como tal capturada</param>
        public CantidadInvalidaException(String codigo, String mensaje, Exception e):base(codigo, mensaje, e)
        {

        }
    }
}
