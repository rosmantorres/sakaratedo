using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DominioSKD;
using DatosSKD.Fabrica;
using DatosSKD.InterfazDAO.Modulo16;
using DatosSKD.InterfazDAO;

namespace LogicaNegociosSKD.Comandos.Modulo16
{
    /// <summary>
    /// Comando para consultar la lista de todas las mensualidades
    /// </summary>
   public class ComandoConsultarTodasMensualidades : Comando<Entidad>
    {
        /// <summary>
        /// Metodo que ejecuta el comando
        /// </summary>
        /// <param name="parametro">id de persona</param>
        /// <returns>lista de Mensualidades</returns>

       public override Entidad Ejecutar()
       {
           try
           {
               FabricaDAOSqlServer laFabrica = new FabricaDAOSqlServer();
               IdaoMensualidad daoMensualidades = laFabrica.ObtenerDaoMensualidades();
               PersonaM1 p = (PersonaM1)this.LaEntidad;

               return daoMensualidades.ConsultarXId(p);
           }
           #region catches
           catch (Exception ex)
           {
               throw ex;
           }

           #endregion
       }
    }
}
