using DominioSKD;
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
    public class PresentadorModificarHistorialM
    {
        private IContratoModificarHistorialM vista;

        #region Constructor
        /// <summary>
        /// Constructor del Presentador
        /// </summary>
        /// <param name="laVista">la vista es la interfaz principal</param>
        public PresentadorModificarHistorialM(IContratoModificarHistorialM laVista)
        {
            this.vista = laVista;
        }
        #endregion

        /// <summary>
        /// Método para modificar un Dojo
        /// </summary>
        public void ModificarHistorialMClick()
        {
            HistorialM elHistM = (HistorialM)FabricaEntidades.ObtenerHistorialMatricula();

            try
            {
                //Se cargan todos los valores tomados de la interfaz al objeto Historial Matricula

                elHistM.Id_historial_matricula = vista.IdHistM;
                elHistM.Modalidad_historial_matricula = vista.Modalidad;
                elHistM.Fecha_historial_matricula = DateTime.Parse(vista.Fecha);
                elHistM.Monto_historial_matricula = float.Parse(vista.Monto);

                Comando<bool> modificarHistM = FabricaComandos.CrearComandoModificarHistorialM();
                modificarHistM.LaEntidad = elHistM;
                modificarHistM.Ejecutar();
            }
            catch (ExcepcionesSKD.ExceptionSKDConexionBD ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                vista.AlertaClase = M4_RecursosPresentador.alertaError;
                vista.AlertaRol = M4_RecursosPresentador.tipoAlerta;
                vista.Alerta = M4_RecursosPresentador.alertaHtml
                    + ex.Mensaje + M4_RecursosPresentador.alertaHtmlFinal;
            }
            catch (ExcepcionesSKD.ExceptionSKD ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                vista.AlertaClase = M4_RecursosPresentador.alertaError;
                vista.AlertaRol = M4_RecursosPresentador.tipoAlerta;
                vista.Alerta = M4_RecursosPresentador.alertaHtml
                    + ex.Mensaje + M4_RecursosPresentador.alertaHtmlFinal;
            }
            
        }

        /// <summary>
        /// Método para mostrar los datos de un dojo
        /// </summary>
        public void MostrarHistorialM()
        {
            try
            {
                HistorialM histM= (HistorialM)FabricaEntidades.ObtenerHistorialMatricula();
                HistorialM elHistM = (HistorialM)FabricaEntidades.ObtenerHistorialMatricula();
                histM.Id = vista.IdHistM;
                Comando<Entidad> detallarHistM = FabricaComandos.CrearComandoDetallarHistorialM();
                detallarHistM.LaEntidad = histM;
                elHistM = (HistorialM)detallarHistM.Ejecutar();
                vista.Fecha = elHistM.Fecha_historial_matricula.Date.ToString();
                vista.Modalidad = elHistM.Modalidad_historial_matricula;
                vista.Monto = elHistM.Monto_historial_matricula.ToString();
               
            }
            catch (ExcepcionesSKD.ExceptionSKDConexionBD ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                vista.AlertaClase = M4_RecursosPresentador.alertaError;
                vista.AlertaRol = M4_RecursosPresentador.tipoAlerta;
                vista.Alerta = M4_RecursosPresentador.alertaHtml
                    + ex.Mensaje + M4_RecursosPresentador.alertaHtmlFinal;
            }
            catch (ExcepcionesSKD.ExceptionSKD ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                vista.AlertaClase = M4_RecursosPresentador.alertaError;
                vista.AlertaRol = M4_RecursosPresentador.tipoAlerta;
                vista.Alerta = M4_RecursosPresentador.alertaHtml
                    + ex.Mensaje + M4_RecursosPresentador.alertaHtmlFinal;
            }
        }
    }
}
