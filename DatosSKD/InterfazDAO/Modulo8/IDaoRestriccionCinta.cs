using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatosSKD.InterfazDAO.Modulo8
{
    public interface IDaoRestriccionCinta : IDao<DominioSKD.Entidad, Boolean, DominioSKD.Entidad>
    {
        /// <summary>
        /// Firma de metodo que agrega una restriccion de cinta
        /// dada una configuracion de parametros especifica.
        /// </summary>
        /// <param name="parametro">Tipo: RestriccionCinta,
        /// objeto con la informacion de una restriccion para cintas</param>
        /// <returns>Retorna un Boolean una vez realizada la operacion</returns>
        Boolean Agregar(DominioSKD.Entidad parametro);

        /// <summary>
        /// Firma de metodo que Modificar una restriccion de cinta
        /// dada una configuracion de parametros especifica.
        /// </summary>
        /// <param name="parametro">Tipo: RestriccionCinta,
        /// objeto con la informacion de una restriccion para cintas</param>
        /// <returns>Retorna un Boolean una vez realizada la operacion</returns>

        /// <summary>
        /// Firma de metodo que Consulta una restriccion de cinta
        /// dada una configuracion de parametros especifica.
        /// </summary>
        /// <param name="parametro">Tipo: RestriccionCinta,
        /// objeto con la informacion de una restriccion para cintas</param>
        /// <returns>Retorna un Boolean una vez realizada la operacion</returns>
    }
}
