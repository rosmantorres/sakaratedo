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
    public class ComandoEliminarSolicitud :Comando<Boolean>
    {
        private int idSolicitud;

        public int iDSolicitud
        {
            get { return idSolicitud; }
            set { idSolicitud = value; }
        }

        public override Boolean Ejecutar()
        {
            try
            {
                DaoSolicitud daoSolicitud = (DaoSolicitud)FabricaDAOSqlServer.ObtenerDAOSolicitud();
                return daoSolicitud.EliminarSolicitudBD(this.idSolicitud);
            }
            catch (ExcepcionesSKD.ExceptionSKDConexionBD ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);

                throw ex;
            }
            catch (ExcepcionesSKD.Modulo14.BDSolicitudException ex)
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
