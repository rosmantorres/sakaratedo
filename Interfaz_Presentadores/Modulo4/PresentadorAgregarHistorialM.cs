using DominioSKD.Entidades.Modulo4;
using DominioSKD.Fabrica;
using ExcepcionesSKD;
using Interfaz_Contratos.Modulo4;
using LogicaNegociosSKD;
using LogicaNegociosSKD.Fabrica;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfaz_Presentadores.Modulo4
{
    public class PresentadorAgregarHistorialM
    {
        private IContratoAgregarHistorialM vista;

        #region Constructor
        /// <summary>
        /// Constructor del Presentador
        /// </summary>
        /// <param name="laVista">la vista es la interfaz principal</param>
        public PresentadorAgregarHistorialM(IContratoAgregarHistorialM laVista)
        {
            this.vista = laVista;
        }
        #endregion

        /// <summary>
        /// Método para agregar un nuevo Historial Matricula
        /// </summary>
        public void AgregarHistorialM_Click()
        {
            HistorialM elHistM = (HistorialM)FabricaEntidades.ObtenerHistorialMatricula();

            try
            {
                //Se cargan todos los valores tomados de la interfaz al objeto Historial Matricula

                elHistM.Id_historial_matricula = vista.Persona;
                elHistM.Modalidad_historial_matricula = vista.Modalidad;
                elHistM.Fecha_historial_matricula = DateTime.Parse(vista.Fecha);
                elHistM.Monto_historial_matricula = float.Parse(vista.Monto);

                Comando<bool> agregarHistM= FabricaComandos.CrearComandoAgregaHistorialM();
                agregarHistM.LaEntidad = elHistM;
                agregarHistM.Ejecutar();
            }
            catch (ExcepcionesSKD.ExceptionSKDConexionBD ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);

                throw ex;
            }
            catch (ExcepcionesSKD.ExceptionSKD ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);

                throw ex;
            }
        }
    }
}
