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
        Boolean AgregarRestriccionCinta(DominioSKD.Entidad parametro);

        /// <summary>
        /// Firma de metodo que Modificar una restriccion de cinta
        /// dada una configuracion de parametros especifica.
        /// </summary>
        /// <param name="parametro">Tipo: RestriccionCinta,
        /// objeto con la informacion de una restriccion para cintas</param>
        /// <returns>Retorna un Boolean una vez realizada la operacion</returns>
        Boolean ModificarRestriccionCinta(DominioSKD.Entidad parametro);

        /// <summary>
        /// Firma de metodo que Consulta una restriccion de cinta
        /// dada una configuracion de parametros especifica.
        /// </summary>
        /// <param name="parametro">Tipo: RestriccionCinta,
        /// objeto con la informacion de una restriccion para cintas</param>
        /// <returns>Retorna un Boolean una vez realizada la operacion</returns>
        //Boolean ConsultarRestriccionCinta(DominioSKD.Entidad parametro);

        /// <summary>
        /// Firma de metodo que Consulta todas las restricciones de cinta
        /// dada una configuracion de parametros especifica.
        /// </summary>
        /// <param name="parametro">Tipo: RestriccionCinta,
        /// objeto con la informacion de una restriccion para cintas</param>
        /// <returns>Retorna un Boolean una vez realizada la operacion</returns>
        List<DominioSKD.Entidad> ConsultarCintaTodas();

        /// <summary>
        /// Firma de metodo que Consulta una restriccion de cinta
        /// dada una configuracion de parametros especifica.
        /// </summary>
        /// <param name="parametro">Tipo: RestriccionCinta,
        /// objeto con la informacion de una restriccion para cintas</param>
        /// <returns>Retorna un Boolean una vez realizada la operacion</returns>
        List<DominioSKD.Entidad> ConsultarRestriccionCintaDT();

        /// <summary>
        /// Firma de metodo que cambia una restriccion de cinta
        /// de status activado a dsactivado.
        /// </summary>
        /// <param name="parametro">Tipo: RestriccionCinta,
        /// objeto con la informacion de una restriccion para cintas</param>
        /// <returns>Retorna un Boolean una vez realizada la operacion</returns>
        Boolean StatusRestriccionCinta(DominioSKD.Entidad parametro);
    }
}
