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
    public class ComandoListarPlanillasSolicitadas : Comando<List<Entidad>>
    {
        private int idPersona;

        public int IDPersona
        {
            get { return idPersona; }
            set { idPersona = value; }
        }
        /// <summary>
        /// Metodo que lista todas las planillas que ha solicitado una persona
        /// </summary>
        /// <param name="idPersona">Id de la Persona </param>
        /// <returns>Retorna una lista de solicitudes</returns>
        public override List<Entidad> Ejecutar()
        {
            try
            {
                IDaoSolicitud daoSolicitud = FabricaDAOSqlServer.ObtenerDAOSolicitud();
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
