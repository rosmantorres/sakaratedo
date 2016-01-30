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
    public class ComandoAgregarDiseno : Comando<Boolean>
    {
        private Entidad diseño;
        private Entidad planilla;

        public Entidad Diseño
        {
            get { return diseño; }
            set { diseño= value; }
        }

        public Entidad Planilla
        {
            get { return planilla; }
            set { planilla= value; }
        }
        /// <summary>
        /// Metodo que comunica con la Bd para agregar un diseño nuevo
        /// </summary>
        /// <param name="diseño">diseño</param>
        /// <param name="planilla">para unir con el diseño en la BD</param>
        /// <returns>Retorna True, si se realizo la operación satisfactoriamente.
        /// De lo contrario devuelve false</returns>
        public override Boolean Ejecutar()
        {
            try
            {

                Logger.EscribirInfo(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, RecursosComandoModulo14.MsjLoggerInfo, System.Reflection.MethodBase.GetCurrentMethod().Name);
                ((DominioSKD.Entidades.Modulo14.Diseño)Diseño).Base64Encode();
                IDaoDiseno dao = FabricaDAOSqlServer.ObtenerDAODiseno();
                return dao.GuardarDiseñoBD(this.diseño, this.planilla); 
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
