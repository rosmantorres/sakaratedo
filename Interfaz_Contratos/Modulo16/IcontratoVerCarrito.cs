using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;

namespace Interfaz_Contratos.Modulo16
{
    /// <summary>
    /// Interface para el manejo de la vista VerCarrito
    /// </summary>
    public interface IcontratoVerCarrito
    {
        /// <summary>
        /// Tabla donde se mostraran todos los implementos que hay en el carrito del usuario
        /// </summary>
        Table tablaImplemento { get; }

        /// <summary>
        /// Tabla donde se mostraran todos los eventos que hay en el carrito del usuario
        /// </summary>
        Table tablaEvento { get; }

        /// <summary>
        /// Tabla donde se mostraran todas las matriculas que hay en el carrito del usuario
        /// </summary>
        Table tablaMatricula { get; }

        /// <summary>
        /// Literal que permite imprimir los valores en el modal de Eventos
        /// </summary>
        Literal LiteralDetallesEventos { get; }

        /// <summary>
        /// Literal que permite imprimir los valores en el modal de Mensualidades
        /// </summary>
        Literal LiteralDetallesMensualidades { get; }

        /// <summary>
        /// Literal que permite imprimir los valores en el modal de Productos
        /// </summary>
        Literal LiteralDetallesProductos { get; }

        /// <summary>
        /// Metodo para ejecutar scripts en el cliente, desde el servidor.
        /// </summary>
        void ejecutarScriptImplemento();

        /// <summary>
        /// Metodo para ejecutar scripts en el cliente, desde el servidor.
        /// </summary>
        void ejecutarScriptEvento();

        /// <summary>
        /// Metodo para ejecutar scripts en el cliente, desde el servidor.
        /// </summary>
        void ejecutarScriptMensualidad();

        /// <summary>
        /// Literal que permite imprimir el precio total de la compra
        /// </summary>
        Literal PrecioFinal { get; set; }

        /// <summary>
        /// Input que recibe el dato del tipo de pago con el que se realiza la transaccion
        /// </summary>
        HtmlInputText Datospago {get; set; }

        /// <summary>
        /// Input que recibe el monto del pago con el que se realiza la transaccion
        /// </summary>
        HtmlInputText MontoPago { get; set; }
        
    }
}
