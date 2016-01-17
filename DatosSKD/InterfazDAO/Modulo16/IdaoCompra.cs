using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DominioSKD;

namespace DatosSKD.InterfazDAO.Modulo16
{
    /// <summary>
    /// Interface con la firma de metodos para el DAO de compra
    /// </summary>
    public interface IdaoCompra : IDao<Entidad, bool, Entidad>
    {
        /// <summary>
        /// Metodo que obtiene todas las facturas de el usuario logueado
        /// </summary>
        /// <param name="entidad">La persona a la que se desea saber todas sus facturas</param>
        /// <returns>Lista cont todos las facturas de la persona</returns>
        new Entidad ConsultarXId(Entidad entidad);

        /// <summary>
        /// Metodo que obtiene todas las facturas
        /// </summary>
        /// <param name="NONE">Este metodo no posee paso de parametros</param>
        /// <returns>Lista con todos las facturas</returns>
        List<Entidad> ListarFactura();

        /// <summary>
        /// Metodo que obtiene el detalle de la factura
        /// </summary>
        /// <param name="Id_Factura">El id de la factura que desea detallar</param>
        /// <returns>El objeto con todos sus atributos en especifico</returns>
        Entidad DetallarFactura(int Id_factura);
    }
}
