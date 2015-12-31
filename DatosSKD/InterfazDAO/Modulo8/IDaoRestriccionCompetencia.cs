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
       /// Dado un objeto con la informacion de una restriccion  de competencia 
       /// el metodo devuelve verdadero de encontrar otra restriccion con
       /// la misma configuracion.
       /// </summary>
       /// <param name="laRestriccionCompetencia">Tipo: RestriccionCompetencia,
       /// objeto con la informacion de una restriccion para competencias</param>
       /// <returns></returns>
        bool ExisteRestriccionCompetenciasSimilar(DominioSKD.Entidad laRestriccionCompetencia);
        #endregion

    }
}
