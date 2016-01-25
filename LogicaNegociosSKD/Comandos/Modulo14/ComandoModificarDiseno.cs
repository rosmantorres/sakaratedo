using DatosSKD.DAO.Modulo14;
using DatosSKD.InterfazDAO.Modulo14;
using DatosSKD.Fabrica;
using DominioSKD;
using DominioSKD.Fabrica;
using ExcepcionesSKD;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegociosSKD.Comandos.Modulo14
{
    public class ComandoModificarDiseno : Comando<Boolean>
    {
        private Entidad diseño;
        public Entidad Diseño
        {
            get { return diseño; }
            set { diseño = value; }
        }
        /// <summary>
        /// Método que modifica un diseño
        /// </summary>
        /// <param name="diseño">diseño que se desea modificar</param>
        /// <returns>Retorna True si se realizo satisfactoriamente la modificación.
        /// De lo contrario devuelve False</returns>
        public override Boolean Ejecutar()
        {
            try
            {
                ((DominioSKD.Entidades.Modulo14.Diseño)Diseño).Base64Encode();
                IDaoDiseno dao = FabricaDAOSqlServer.ObtenerDAODiseno();
                return dao.Modificar(this.diseño);
            }
            catch (ExcepcionesSKD.ExceptionSKDConexionBD ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);

                throw ex;
            }
            catch (ExcepcionesSKD.Modulo14.BDDiseñoException ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                throw ex;
            }
            catch (ExcepcionesSKD.Modulo14.BDDatosException ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                throw ex;
            }
            catch (Exception ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                throw ex;
            }
        }
    }
}
