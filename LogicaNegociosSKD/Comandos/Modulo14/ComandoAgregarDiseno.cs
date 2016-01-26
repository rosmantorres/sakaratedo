using DatosSKD.DAO.Modulo14;
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
        public override Boolean Ejecutar()
        {
            FabricaDAOSqlServer fabrica = new FabricaDAOSqlServer();
            try
            {
                Logger.EscribirInfo(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, RecursosComandoModulo14.MsjLoggerInfo, System.Reflection.MethodBase.GetCurrentMethod().Name);
                FabricaEntidades fabricaEntidad = new FabricaEntidades();
                ((Diseño)Diseño).Base64Encode();
                DaoDiseno dao = (DaoDiseno)fabrica.ObtenerDAODiseno();
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
