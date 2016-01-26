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
using DominioSKD;

namespace Interfaz_Presentadores.Modulo4
{
    public class PresentadorModificarDojo
    {
        private IContratoModificarDojo vista;

        #region Constructor
        /// <summary>
        /// Constructor del Presentador
        /// </summary>
        /// <param name="laVista">la vista es la interfaz principal</param>
             public PresentadorModificarDojo (IContratoModificarDojo laVista)
            {
                this.vista = laVista;
            }
         #endregion

        /// <summary>
        /// Método para modificar un Dojo
        /// </summary>
        public bool ModificarDojo_Click()
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
                     elDojo.Id = vista.idDojo;
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

                     Comando<bool> ModificarDojo = FabricaComandos.CrearComandoModificarDojo();
                     ModificarDojo.LaEntidad = elDojo;
                     return ModificarDojo.Ejecutar();
                 }
                 catch (ExcepcionesSKD.ExceptionSKDConexionBD ex)
                 {
                     Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);

                     throw ex;
                 }
                 catch (ExcepcionesSKD.Modulo4.DojoInexistenteException ex)
                 {
                     Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);

                     throw ex;
                 }
                 catch (ExcepcionesSKD.Modulo4.FormatoIncorrectoException ex)
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

        /// <summary>
        /// Método para mostrar los datos de un dojo
        /// </summary>
        public void MostrarDojo()
             {
                 try
                 {
                     DominioSKD.Dojo dojo = (DominioSKD.Dojo)FabricaEntidades.ObtenerDojo_M4();
                     DominioSKD.Dojo elDojo = (DominioSKD.Dojo)FabricaEntidades.ObtenerDojo_M4();
                     dojo.Id = vista.idDojo;
                     Comando<Entidad> detallarDojo = FabricaComandos.CrearComandoDetallarDojo();
                     detallarDojo.LaEntidad = dojo;
                     elDojo = (DominioSKD.Dojo)detallarDojo.Ejecutar();
                     vista.idDojo = elDojo.Dojo_Id;
                     vista.logo = elDojo.Logo_dojo;
                     vista.imglogo = "Imagenes/" + elDojo.Logo_dojo;
                     vista.nombre = elDojo.Nombre_dojo;
                     vista.rif = elDojo.Rif_dojo;
                     vista.telefono = elDojo.Telefono_dojo.ToString();
                     vista.email = elDojo.Email_dojo;
                     vista.estado = elDojo.Ubicacion.Estado;
                     vista.ciudad = elDojo.Ubicacion.Ciudad;
                     vista.direccion = elDojo.Ubicacion.Direccion;
                     if (elDojo.Status_dojo)
                     {
                         vista.statusAct = true;
                         vista.statusIn = false;
                     }
                     else
                     {
                         vista.statusAct = false;
                         vista.statusIn = true;
                     }
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
