using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DominioSKD;

namespace DatosSKD.InterfazDAO.Modulo8
{
    public interface IDaoRestriccionEvento : IDao<DominioSKD.Entidad, Boolean, DominioSKD.Entidad>
    {
        /// <summary>
        /// Firma Metodo para agregar una restriccion de evento a la base de datos.
        /// </summary>
        /// <param name="parametro">objeto de tipo RestriccionEvento para agregar en bd</param>
        /// <returns>true si fue eliminado</returns>
        Boolean AgregarRestriccionEvento(DominioSKD.Entidad parametro);

        /// <summary>
        /// Firma Metodo para modificar una restriccion de evento a la base de datos.
        /// </summary>
        /// <param name="parametro"> objeto RestriccionEvento para modificar en bd</param>
        /// <returns>true si fue modificado</returns>
        Boolean ModificarRestriccionEvento(DominioSKD.Entidad parametro);

        /// <summary>
        /// Firma Metodo para eliminar una restriccion de evento en la base de datos.
        /// </summary>
        /// <param name="parametro"> int id de la RestriccioEvento para ser eliminado en bd</param>
        /// <returns>true si fue eliminado</returns>
        Boolean EliminarRestriccionEvento(DominioSKD.Entidad parametro);

        /// <summary>
        /// Firma Metodo para consultar la RestriccionEvento de un evento especifico en la base de datos.
        /// </summary>
        /// <param name="parametro">EventoSimple a consultar restriccion con su id</param>
        /// <returns>Objeto de tipo RestriccionEvento con todos los datos</returns>
        DominioSKD.Entidad ConsultarRestriccionEvento(int parametro);

        /// <summary>
        /// Firma Metodo para consultar todas las Restricciones de Eventos.
        /// </summary>
        /// <returns>Lista de todas las RestriccionesEventos que existen</returns>
        List<DominioSKD.Entidad> ConsultarEventosConRestriccion();

        /// <summary>
        /// Firma Metodo para consultar los eventos que no tienen restricciones aun.
        /// </summary>
        /// <returns>Lista de EventoSimple que no tienen Restriccion</returns>
        List<Entidad> ConsultarEventosSinRestriccion();

        /// <summary>
        /// Firma Metodo para consultar eventos que puede asistir un atleta.
        /// </summary>
        /// <param name="parametro">int id de la persona a consultar eventos que puede asistir</param>
        /// <returns>Lista de EventoSimple a los que puede asistir</returns>
        List<Entidad> EventosQuePuedeAsistirAtleta(int parametro);
    }
}
