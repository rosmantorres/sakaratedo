using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;

namespace Interfaz_Contratos.Modulo16
{
    public interface IContratoListarEvento
    {
        /// <summary>
        /// Tabla donde se mostrara todos los implementos del carrito
        /// </summary>
        Table tablaEventos { get; }

        /// <summary>
        /// Literal que permite imprimir los valores en el modal
        /// </summary>
        Literal LiteralDetallesEventos { get; }
      
        /// <summary>
        /// //Metodo para ejecutar scripts en el cliente, desde el servidor.
        /// </summary>
        void ejecutarScript();

    }
}
