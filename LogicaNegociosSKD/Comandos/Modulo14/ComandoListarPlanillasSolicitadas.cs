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
    public class ComandoListarPlanillasSolicitadas : Comando<List<Entidad>>
    {
        private int idPersona;

        public int IDPersona
        {
            get { return idPersona; }
            set { idPersona = value; }
        }
        public override List<Entidad> Ejecutar()
        {
            try
            {
                DaoSolicitud daoSolicitud = (DaoSolicitud)FabricaDAOSqlServer.ObtenerDAOSolicitud();
                return daoSolicitud.ConsultarSolicitudes(this.idPersona);
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
