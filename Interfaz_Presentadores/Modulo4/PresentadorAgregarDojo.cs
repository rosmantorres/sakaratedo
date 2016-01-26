using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Interfaz_Contratos.Modulo4;
using LogicaNegociosSKD.Fabrica;
using LogicaNegociosSKD;
using DominioSKD.Fabrica;
using ExcepcionesSKD;

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
             public PresentadorAgregarDojo (IContratoAgregarDojo laVista)
            {
                this.vista = laVista;
            }
         #endregion

        /// <summary>
        /// Método para agregar un nuevo Dojo
        /// </summary>
             public void AgregarDojo_Click ()
             {
                 DominioSKD.Dojo elDojo = (DominioSKD.Dojo)FabricaEntidades.ObtenerDojo_M4();
                 DominioSKD.Organizacion org = (DominioSKD.Organizacion)FabricaEntidades.ObtenerOrganizacion_M4();
                 DominioSKD.Ubicacion ubi = (DominioSKD.Ubicacion)FabricaEntidades.ObtenerUbicacion_M4();

                 Random r = new Random();
                 string lat = (r.Next(0, 180000) / 1000).ToString();
                 string lon = (r.Next(-180000, 0) / 1000).ToString();

                 try
                 {
                     //Se cargan todos los valores tomados de la interfaz al objeto dojo
                     org.Id = vista.persona;
                     elDojo.Organizacion = org;
                     elDojo.Logo_dojo = vista.logo;
                     elDojo.Rif_dojo = vista.rif;
                     elDojo.Nombre_dojo = vista.nombre;
                     elDojo.Telefono_dojo = int.Parse(vista.telefono);
                     elDojo.Email_dojo = vista.email;
                     ubi.Latitud = lat;
                     ubi.Longitud = lon;
                     ubi.Ciudad = vista.ciudad;
                     ubi.Estado = vista.estado;
                     ubi.Direccion = vista.direccion;
                     elDojo.Ubicacion = ubi;
                     //Se verifica si se seleccionó activo o inactivo
                     if (vista.statusAct)
                         elDojo.Status_dojo = true;
                     if (vista.statusIn)
                         elDojo.Status_dojo = false;

                     Comando<bool> agregarDojo = FabricaComandos.CrearComandoAgregarDojo();
                     agregarDojo.LaEntidad = elDojo;
                     agregarDojo.Ejecutar();
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
