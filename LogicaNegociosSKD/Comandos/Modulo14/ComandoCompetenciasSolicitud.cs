using DatosSKD.DAO.Modulo14;
using DatosSKD.InterfazDAO.Modulo14;
using DatosSKD.Fabrica;
using DominioSKD;
using ExcepcionesSKD;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegociosSKD.Comandos.Modulo14
{
    public class ComandoCompetenciasSolicitud : Comando<List<Entidad>>
    {
        private int idPersona;

        public int IDPersona
        {
            get { return idPersona; }
            set { idPersona = value; }
        }
        /// <summary>Obtener una solicitud por ID</summary>
        /// <param name="idPlanilla"></param>
        /// <returns>Regresa la solicitud con su fechar, fecharei y motivo</returns>
        /// 
        public override List<Entidad> Ejecutar()
        {
            IDaoSolicitud BaseDeDatoSolicitud = FabricaDAOSqlServer.ObtenerDAOSolicitud();
            List<Entidad> eventos = new List<Entidad>();

            try
            {
                eventos = BaseDeDatoSolicitud.ObtenerCompetenciaSolicitud(this.idPersona);
               
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
            return eventos;
        }
    }
}
