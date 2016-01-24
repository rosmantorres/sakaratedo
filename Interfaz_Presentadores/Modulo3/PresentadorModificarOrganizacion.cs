using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Interfaz_Contratos.Modulo3;
using LogicaNegociosSKD.Fabrica;
using LogicaNegociosSKD.Comandos.Modulo3;
using LogicaNegociosSKD;
using DominioSKD;
using DominioSKD.Fabrica;

namespace Interfaz_Presentadores.Modulo3
{
    public class PresentadorModificarOrganizacion
    {
        private IContratoModificarOrganizacion vista;

        public PresentadorModificarOrganizacion(IContratoModificarOrganizacion vista)
        {
            this.vista = vista;
        }


        /// <summary>
        /// Método para obtener los valores de la vista y ejecutar el comando para modificar la organizacion
        /// </summary>
        public void modificarValoresOrganizacion()
        {
            DominioSKD.Entidades.Modulo3.Organizacion laOrganizacion = (DominioSKD.Entidades.Modulo3.Organizacion)FabricaEntidades.ObtenerOrganizacion_M3();

          try
            {

            laOrganizacion.Id_organizacion = this.vista.obtenerIdOrg();
            laOrganizacion.Nombre = this.vista.obtenerNombreOrg();
            laOrganizacion.Email = this.vista.obtenerEmail();
            laOrganizacion.Telefono = Int32.Parse(this.vista.obtenerTelefono());
            laOrganizacion.Direccion = this.vista.obtenerDireccion();
            laOrganizacion.Estado = this.vista.obtenerEstado();
            laOrganizacion.Estilo = this.vista.obtenerTecnica();

            Comando<bool> _comando = FabricaComandos.ObtenerEjecutarModificarOrganizacion(laOrganizacion);
            bool resultado = _comando.Ejecutar();

            if (resultado)
                this.vista.Respuesta();

            }
          catch (ExcepcionesSKD.Modulo3.EstiloInexistenteException ex)
          {
              this.vista.alertaModificarFallidoEstiloOrg(ex);
          }
        }
    }
}
