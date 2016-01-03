using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatosSKD.InterfazDAO.Modulo8
{
    public interface IDaoRestriccionCompetencia : IDao< DominioSKD.Entidad, Boolean, DominioSKD.Entidad>
    {
        #region Firma existeCompetencia
       /// <summary>
       ///Firma metodo para comprobar si existe una restriccion similar en la base de datos.
       /// </summary>
       /// <param name="laRestriccionCompetencia">Tipo: RestriccionCompetencia,
       /// objeto con la informacion de una restriccion para competencias</param>
       /// <returns>True si existe la restriccion con esos parametros, false si no exite.</returns>
        Boolean ExisteRestriccionCompetenciaSimilar(DominioSKD.Entidad parametro);
        #endregion
        /// <summary>
        /// Firma de metodo que retorna el id de una restriccion de competencia
        /// dada una configuracion de parametros especifica.
        /// </summary>
        /// <param name="parametro">Tipo: RestriccionCompetencia,
        /// objeto con la informacion de una restriccion para competencias</param>
        /// <returns>Retorna null si no existe una restriccion con dicha configuracion
        /// retorna un entero correspondiente al id en caso de existir la restriccion</returns>
        int traerIdRestriccionCompetencia(DominioSKD.Entidad parametro);

        /// <summary>
        /// Firma de metodo para crear relaciones entre Restricciones y Competencias.
        /// </summary>
        /// <param name="parametro1">Tipo: objeto RestriccionCompetencia</param>
        /// <param name="parametro2">Tipo: objeto Competencia</param>
        /// <returns>True si se crea la relacion exitosamente, False si ya existe o falla la creacion</returns>
        Boolean AgregarCompetenciaRestriccionCompetencia(DominioSKD.Entidad parametro1, DominioSKD.Entidad parametro2);

        /// <summary>
        /// Firma de metodo que dado un objeto RestriccionCompetencia, retorna una lista
        /// de objetos Competencia los cuales no estan relacionados con la RestriccionCompetencia provista
        /// </summary>
        /// <param name="parametro">Tipo: Objeto RestriccionCompetencia</param>
        /// <returns>Lista de objetos: Competencia</returns>
        List<DominioSKD.Entidad> ConsultarTodasLasCompetenciasNoAsociadas(DominioSKD.Entidad parametro);

        /// <summary>
        /// Firma de metodo que dado un objeto RestriccionCompetencia, retorna una lista
        /// de objetos Competencia los cuales estan relacionados con la RestriccionCompetencia provista
        /// </summary>
        /// <param name="parametro">Tipo: Objeto RestriccionCompetencia</param>
        /// <returns>Lista de objetos: Competencia</returns>
        List<DominioSKD.Entidad> ConsultarTodasLasCompetenciasAsociadas(DominioSKD.Entidad parametro);

        /// <summary>
        /// Firma de metodo para eliminar relaciones entre Restricciones y Competencias.
        /// </summary>
        /// <param name="parametro1">Tipo: objeto RestriccionCompetencia</param>
        /// <param name="parametro2">Tipo: objeto Competencia</param>
        /// <returns>True si se elimina la relacion exitosamente, False si no existe o falla la eliminacion</returns>
        Boolean EliminarCompetenciaRestriccionCompetencia(DominioSKD.Entidad parametro1, DominioSKD.Entidad parametro2);


       /// <summary>
       /// Firma del metodo que retorna el id de una relacion entre RestriccionCompetencia y
       /// una competencia
       /// </summary>
       /// <param name="parametro1">objeto tipo: RestriccionCompetencia</param>
       /// <param name="parametro2">objeto tipo: Competencia</param>
       /// <returns>Entero correspondiente al id de la relacion</returns>
        int RetornarIdCompetenciaRestriccionCompetencia(DominioSKD.Entidad parametro1, DominioSKD.Entidad parametro2);

        /// <summary>
        /// Firma del metodo que retorna si existe una relacion entre una RestriccionCompetencia y una Competencia dadas
        /// </summary>
        /// <param name="parametro1">objeto tipo: RestriccionCompetencia</param>
        /// <param name="parametro2">objeto tipo: Competencia</param>
        /// <returns>retorna true si existe false si no existe</returns>
        Boolean ExisteCompetenciaRestriccionCompetencia(DominioSKD.Entidad parametro1, DominioSKD.Entidad parametro2);
    }
}
