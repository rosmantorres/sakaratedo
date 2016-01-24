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
    public class ComandoConsultarDiseñoPuro : Comando<Entidad>
    {
        private Entidad planilla;

        public Entidad Planilla
        {
            get { return planilla; }
            set { planilla = value; }
        }

        /// <summary>
        /// Método que devuelve el diseño, tal cual se creo
        /// </summary>
        /// <param name="planilla">la planilla que contiene el diseño a consultar</param>
        /// <returns>Retorna la entidad a consultar</returns>
        public override Entidad Ejecutar()
        {
            try
            {
                IDaoDiseno dao = FabricaDAOSqlServer.ObtenerDAODiseno();
                return dao.ConsultarXId(this.planilla);
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
