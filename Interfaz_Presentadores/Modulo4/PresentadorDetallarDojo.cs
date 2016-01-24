using DominioSKD;
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
             public PresentadorDetallarDojo (IContratoDetalleDojo laVista)
            {
                this.vista = laVista;
            }
         #endregion
        public void DetalleDojo (int idDojo)
        {
            try
            {

                DominioSKD.Dojo dojo = (DominioSKD.Dojo)FabricaEntidades.ObtenerDojo_M4();
                DominioSKD.Dojo elDojo = (DominioSKD.Dojo)FabricaEntidades.ObtenerDojo_M4();
                dojo.Id = idDojo;
                Comando<Entidad> detallarDojo = FabricaComandos.CrearComandoDetallarDojo();
                detallarDojo.LaEntidad = dojo;
                elDojo = (DominioSKD.Dojo)detallarDojo.Ejecutar();
                vista.logo = "Imagenes/" + elDojo.Logo_dojo;
                vista.rif = elDojo.Rif_dojo;
                vista.nombre = elDojo.Nombre_dojo;
                vista.telefono = elDojo.Telefono_dojo.ToString();
                vista.email = elDojo.Email_dojo;
                vista.estilo = elDojo.Estilo_dojo;
                vista.nombreOrg = elDojo.Organizacion.Nombre;
                if (elDojo.Status_dojo)
                    vista.statusAct = "Activo";
                else
                    vista.statusIn = "Bloqueado";
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
