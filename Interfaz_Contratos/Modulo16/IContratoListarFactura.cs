using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;


namespace Interfaz_Contratos.Modulo16
{
    /// <summary>
    /// Interface para el manejo de la vista listarFactura
    /// </summary>
    public interface IContratoListarFactura
    {
        /// <summary>
        /// Tabla donde se mostrara todas las facturas
        /// </summary>
        Table tablaFacturas { get; }

        Table tablaDetalleProductos { get; }

        Table tablaDetalleEventos { get; }

        Table tablaDetalleMatriculas { get; }

        /// <summary>
        /// Literal que permite imprimir los valores en el modal
        /// </summary>
        Literal LiteralDetallesFacturas { get; }

        /// <summary>
        /// //Metodo para ejecutar scripts en el cliente, desde el servidor.
        /// </summary>
        void ejecutarScript();
    }
}
