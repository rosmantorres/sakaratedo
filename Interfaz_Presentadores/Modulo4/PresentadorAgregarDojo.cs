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
    public class PresentadorAgregarDojo
    {
        private IContratoAgregarDojo vista;

        #region Constructor
        /// <summary>
        /// Constructor del Presentador
        /// </summary>
        /// <param name="laVista">la vista es la interfaz principal</param>
        public PresentadorAgregarDojo(IContratoAgregarDojo laVista)
        {
            this.vista = laVista;
        }
        #endregion

        /// <summary>
        /// Método para agregar un nuevo Dojo
        /// </summary>
        public void AgregarDojo_Click()
        {
            DojoM4 elDojo = (DojoM4)FabricaEntidades.ObtenerDojo_M4();
            DominioSKD.Organizacion org = (DominioSKD.Organizacion)FabricaEntidades.ObtenerOrganizacion_M4();
            DominioSKD.Ubicacion ubi = (DominioSKD.Ubicacion)FabricaEntidades.ObtenerUbicacion_M4();

            Random r = new Random();
            string lat = (r.Next(0, 180000) / 1000).ToString();
            string lon = (r.Next(-180000, 0) / 1000).ToString();
            string tlf = "";
            tlf = vista.Telefono.Remove(0,1);
            tlf = tlf.Remove(4,1);
            tlf = tlf.Remove(7,1);
            try
            {
                //Se cargan todos los valores tomados de la interfaz al objeto dojo
                org.Id = vista.Persona;
                elDojo.Organizacion = org;
                elDojo.Logo_dojo = vista.Logo;
                elDojo.Rif_dojo = vista.Rif;
                elDojo.Nombre_dojo = vista.Nombre;
                elDojo.Telefono_dojo = int.Parse(tlf);
                elDojo.Email_dojo = vista.Email;
                ubi.Latitud = lat;
                ubi.Longitud = lon;
                ubi.Ciudad = vista.Ciudad;
                ubi.Estado = vista.Estado;
                ubi.Direccion = vista.Direccion;
                elDojo.Ubicacion = ubi;
                //Se verifica si se seleccionó activo o inactivo
                if (vista.StatusAct)
                    elDojo.Status_dojo = true;
                if (vista.StatusIn)
                    elDojo.Status_dojo = false;

                Comando<bool> agregarDojo = FabricaComandos.CrearComandoAgregarDojo();
                agregarDojo.LaEntidad = elDojo;
                agregarDojo.Ejecutar();
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
