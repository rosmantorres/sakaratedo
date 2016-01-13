using DatosSKD.DAO.Modulo14;
using DatosSKD.Fabrica;
using DominioSKD;
using ExcepcionesSKD;
using LogicaNegociosSKD.Fabrica;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegociosSKD.Comandos.Modulo14
{
    public class ComandoRegistrarPlanillaTipo : Comando<bool>
    {
        private String nombreTipo;

        public String NombreTipo
        {
            get { return nombreTipo; }
            set { nombreTipo = value; }
        }

        public override bool Ejecutar()
        {


            FabricaDAOSqlServer fabrica = new FabricaDAOSqlServer();
            FabricaComandos fabricaComandos = new FabricaComandos();
            Planilla laPlanilla = (Planilla)this.LaEntidad;
            ComandoRegistrarPlanilla registrar = (ComandoRegistrarPlanilla)fabricaComandos.ObtenerComandoRegistrarPlanilla();
            bool resultPlanilla = true;
            try
            {
                DaoPlanilla BaseDeDatoPlanilla = (DaoPlanilla)fabrica.ObtenerDAOPlanilla();
                int idTipoPlanilla = BaseDeDatoPlanilla.ObtenerIdTipoPlanilla(this.nombreTipo);
                laPlanilla.IDtipoPlanilla = idTipoPlanilla;
                registrar.LaEntidad = (Entidad)laPlanilla;
                registrar.Ejecutar();
            }
            catch (ExcepcionesSKD.ExceptionSKDConexionBD ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);

                throw ex;
            }
            catch (ExcepcionesSKD.Modulo14.BDPLanillaException ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                throw ex;
            }
            catch (Exception ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                throw ex;
            }
            return resultPlanilla;
        }
    }
}
