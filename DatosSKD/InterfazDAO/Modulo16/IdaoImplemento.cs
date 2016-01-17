using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DominioSKD;

namespace DatosSKD.InterfazDAO.Modulo16
{
    /// <summary>
    /// Interface con la firma de metodos para el DAO de implemento
    /// </summary>
    public interface IdaoImplemento : IDao<Entidad, bool, Entidad>
    {
        /// <summary>
        /// Metodo que obtiene todos los implementos
        /// </summary>
        /// <param name="NONE">Este metodo no posee paso de parametros</param>
        /// <returns>Lista con todos los implementos</returns>
        new List<Entidad> ConsultarTodos();

        /// <summary>
        /// Metodo que obtiene todos los implementos
        /// </summary>
        /// <param name="NONE">Este metodo no posee paso de parametros</param>
        /// <returns>Lista con todos los implementos</returns>
        List<Entidad> ListarImplemento();

        /// <summary>
        /// Metodo que obtiene el detalle del implemento
        /// </summary>
        /// <param name="entidad">el implemento al que se desee saber el detalle</param>
        /// <returns>Lista con todos los atributos del implemento en especifico</returns>
        Entidad DetallarImplemento(Entidad entidad);

        /// <summary>
        /// Metodo que obtiene los implementos del dojo de acuerdo al usuario logueado
        /// </summary>
        /// <param name="entidad">el id del usuario que esta logueado</param>
        /// <returns>Lista con todos los implementos de acuerdo al dojo que pertenece el usuario logueado</returns>
        new Entidad ConsultarXId(Entidad entidad);
    }
}
