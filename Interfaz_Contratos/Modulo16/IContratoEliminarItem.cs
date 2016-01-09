using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;

namespace Interfaz_Contratos.Modulo16
{
    public interface IContratoEliminarItem
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

    }
}
