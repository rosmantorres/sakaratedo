using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;

namespace Interfaz_Contratos.Modulo16
{
    /// <summary>
    /// Interface para el manejo de la vista listarProducto
    /// </summary>
    public interface IContratoListarProducto
    {
        /// <summary>
        /// Tabla donde se mostrara todos los productos del carrito
        /// </summary>
        Table tablaProductos { get; }

        /// <summary>
        /// Literal que permite imprimir los valores en el modal
        /// </summary>
        Literal LiteralDetallesProductos { get; }

        /// <summary>
        /// //Metodo para ejecutar scripts en el cliente, desde el servidor.
        /// </summary>
        void ejecutarScript();
    }
}
