using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Interfaz_Contratos.Modulo4;
using LogicaNegociosSKD.Fabrica;
using LogicaNegociosSKD;
using DominioSKD.Fabrica;

namespace Interfaz_Presentadores.Modulo4
{
    public class PresentadorAgregarDojo
    {
         private IContratoAgregarDojo vista;

         #region Constructor
             public PresentadorAgregarDojo (IContratoAgregarDojo laVista)
            {
                this.vista = laVista;
            }
         #endregion

             public void agregarDojo_Click ()
             {
                 DominioSKD.Dojo elDojo = (DominioSKD.Dojo)FabricaEntidades.ObtenerDojo_M4();
                 DominioSKD.Organizacion org = (DominioSKD.Organizacion)FabricaEntidades.ObtenerOrganizacion_M4();
                 DominioSKD.Ubicacion ubi = (DominioSKD.Ubicacion)FabricaEntidades.ObtenerUbicacion_M4();

                 Random r = new Random();
                 string lat = (r.Next(0, 180000) / 1000).ToString();
                 string lon = (r.Next(-180000, 0) / 1000).ToString();

                 try
                 {
                     org.Id = vista.persona;
                     elDojo.Organizacion = org;
                     elDojo.Logo_dojo = vista.logo;
                     elDojo.Rif_dojo = vista.rif;
                     elDojo.Nombre_dojo = vista.nombre;
                     elDojo.Telefono_dojo = int.Parse(vista.telefono);
                     elDojo.Email_dojo = vista.email;
                     // laUbicacion.Latitud = txtLAT.Value.ToString();
                     //  laUbicacion.Longitud = txtLONG.Value.ToString();
                     ubi.Latitud = lat;
                     ubi.Longitud = lon;
                     ubi.Ciudad = vista.ciudad;
                     ubi.Estado = vista.estado;
                     ubi.Direccion = vista.direccion;
                     elDojo.Ubicacion = ubi;

                     if (vista.statusAct)
                         elDojo.Status_dojo = true;
                     if (vista.statusIn)
                         elDojo.Status_dojo = false;

                     Comando<bool> agregarDojo = FabricaComandos.CrearComandoAgregarDojo();
                     agregarDojo.LaEntidad = elDojo;
                     agregarDojo.Ejecutar();
                 }
                 catch
                 {

                 }
             }

    }
}
