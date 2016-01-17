using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DominioSKD;


namespace DatosSKD.InterfazDAO.Modulo16
{
    /// <summary>
    /// Interface con la firma de metodos para el DAO de matricula
    /// </summary>
    public interface IdaoMensualidad : IDao<Entidad, bool, Entidad>
    {
        /// <summary>
        /// Metodo que obtiene todas las mensualidades morosas de la persona logueada
        /// </summary>
        /// <param name="entidad">el id del usuario que esta logueado</param>
        /// <returns>Lista con todos las mensualidades de acuerdo al usuario logueado</returns>
        new Entidad ConsultarXId(Entidad entidad);

        /// <summary>
        /// Metodo que obtiene todas las mensualidades
        /// </summary>
        /// <param name="NONE">Este metodo no posee paso de parametros</param>
        /// <returns>Lista con todos las mensualidades</returns>
        List<Entidad> ListarMensualidad();

        /// <summary>
        /// Metodo que obtiene el detalle de la matricula
        /// </summary>
        /// <param name="entidad">la matricula al que se desee saber el detalle</param>
        /// <returns>Lista con todos los atributos de la matricula en especifico</returns>
        Entidad DetallarMensualidad(Entidad entidad);
    }
}
