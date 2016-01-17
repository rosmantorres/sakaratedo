using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DominioSKD;

namespace DatosSKD.InterfazDAO.Modulo16
{
    /// <summary>
    /// Interface con la firma de metodos para el DAO de evento
    /// </summary>
    public interface IdaoEvento : IDao<Entidad, bool, Entidad>
    {
        /// <summary>
        /// Metodo que obtiene todos los eventos
        /// </summary>
        /// <param name="NONE">Este metodo no posee paso de parametros</param>
        /// <returns>Lista con todos los eventos</returns>
        new List<Entidad> ConsultarTodos();

        /// <summary>
        /// Metodo que obtiene todos los eventos
        /// </summary>
        /// <param name="NONE">Este metodo no posee paso de parametros</param>
        /// <returns>Lista con todos los eventos</returns>
        List<Entidad> ListarEvento();

        /// <summary>
        /// Metodo que obtiene el detalle del evento
        /// </summary>
        /// <param name="Id_evento">el evento al que se desee saber el detalle</param>
        /// <returns>Lista con todos los atributos del evento en especifico</returns>
        Entidad DetallarEvento(int Id_evento);

        /// <summary>
        /// Metodo que obtiene el detalle del evento
        /// </summary>
        /// <param name="entidad">el evento al que se desee saber el detalle</param>
        /// <returns>Lista con todos los atributos del evento en especifico</returns>
        new Entidad ConsultarXId(Entidad entidad);

    }
}
