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
    public class PresentadorDetallarDojo
    {
        private IContratoDetalleDojo vista;

        #region Constructor
        /// <summary>
        /// Constructor del Presentador
        /// </summary>
        /// <param name="laVista">la vista es la interfaz principal</param>
        public PresentadorDetallarDojo(IContratoDetalleDojo laVista)
        {
            this.vista = laVista;
        }
        #endregion

        /// <summary>
        /// Metodo que muestra explicitamente un dojo
        /// </summary>
        /// <param name="idDojo">id del dojo</param>
        public void DetalleDojo(int idDojo)
        {
            try
            {

                DojoM4 dojo = (DojoM4)FabricaEntidades.ObtenerDojo_M4();
                DojoM4 elDojo = (DojoM4)FabricaEntidades.ObtenerDojo_M4();
                dojo.Id = idDojo;
                Comando<Entidad> detallarDojo = FabricaComandos.CrearComandoDetallarDojo();
                detallarDojo.LaEntidad = dojo;
                elDojo = (DojoM4)detallarDojo.Ejecutar();
                vista.Logo = "Imagenes/" + elDojo.Logo_dojo;
                vista.Rif = elDojo.Rif_dojo;
                vista.Nombre = elDojo.Nombre_dojo;
                vista.Telefono = elDojo.Telefono_dojo.ToString();
                vista.Email = elDojo.Email_dojo;
                vista.Estilo = elDojo.Estilo_dojo;
                vista.NombreOrg = elDojo.Organizacion.Nombre;
                if (elDojo.Status_dojo)
                    vista.StatusAct = "Activo";
                else
                    vista.StatusIn = "Bloqueado";
            }
            catch (System.NullReferenceException ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                vista.AlertaClase = M4_RecursosPresentador.alertaError;
                vista.AlertaRol = M4_RecursosPresentador.tipoAlerta;
                vista.Alerta = M4_RecursosPresentador.alertaHtml
                    + "Dojo Inexistente" + M4_RecursosPresentador.alertaHtmlFinal;
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
