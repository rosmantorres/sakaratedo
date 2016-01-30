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
    public class PresentadorModificarDojo
    {
        private IContratoModificarDojo vista;

        #region Constructor
        /// <summary>
        /// Constructor del Presentador
        /// </summary>
        /// <param name="laVista">la vista es la interfaz principal</param>
        public PresentadorModificarDojo(IContratoModificarDojo laVista)
        {
            this.vista = laVista;
        }
        #endregion

        /// <summary>
        /// Método para modificar un Dojo
        /// </summary>
        public bool ModificarDojo_Click()
        {
            DojoM4 elDojo = (DojoM4)FabricaEntidades.ObtenerDojo_M4();
            DominioSKD.Organizacion org = (DominioSKD.Organizacion)FabricaEntidades.ObtenerOrganizacion_M4();
            DominioSKD.Ubicacion ubi = (DominioSKD.Ubicacion)FabricaEntidades.ObtenerUbicacion_M4();

            Random r = new Random();
            string lat = (r.Next(0, 180000) / 1000).ToString();
            string lon = (r.Next(-180000, 0) / 1000).ToString();

            try
            {
                //Se cargan todos los valores tomados de la interfaz al objeto dojo
                elDojo.Id = vista.IdDojo;
                elDojo.Logo_dojo = vista.Logo;
                elDojo.Rif_dojo = vista.Rif;
                elDojo.Nombre_dojo = vista.Nombre;
                elDojo.Telefono_dojo = int.Parse(vista.Telefono);
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
                DojoM4 dojo = (DojoM4)FabricaEntidades.ObtenerDojo_M4();
                DojoM4 elDojo = (DojoM4)FabricaEntidades.ObtenerDojo_M4();
                dojo.Id = vista.IdDojo;
                Comando<Entidad> detallarDojo = FabricaComandos.CrearComandoDetallarDojo();
                detallarDojo.LaEntidad = dojo;
                elDojo = (DojoM4)detallarDojo.Ejecutar();
                vista.IdDojo = elDojo.Dojo_Id;
                vista.Logo = elDojo.Logo_dojo;
                vista.Imglogo = "Imagenes/" + elDojo.Logo_dojo;
                vista.Nombre = elDojo.Nombre_dojo;
                vista.Rif = elDojo.Rif_dojo;
                vista.Telefono = elDojo.Telefono_dojo.ToString();
                vista.Email = elDojo.Email_dojo;
                vista.Estado = elDojo.Ubicacion.Estado;
                vista.Ciudad = elDojo.Ubicacion.Ciudad;
                vista.Direccion = elDojo.Ubicacion.Direccion;
                if (elDojo.Status_dojo)
                {
                    vista.StatusAct = true;
                    vista.StatusIn = false;
                }
                else
                {
                    vista.StatusAct = false;
                    vista.StatusIn = true;
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
