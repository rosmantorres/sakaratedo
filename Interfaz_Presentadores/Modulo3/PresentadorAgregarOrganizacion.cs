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
    public class PresentadorAgregarOrganizacion
    {
        private IContratoAgregarOrganizacion vista;

        public PresentadorAgregarOrganizacion(IContratoAgregarOrganizacion vista)
        {
            this.vista = vista;
        }

        /// <summary>
        /// Método para obtener los valores de la vista y ejecutar el comando para agregar la organizacion
        /// </summary>
        public void agregarValoresOrganizacion()
        {
            DominioSKD.Entidades.Modulo3.Organizacion laOrganizacion = (DominioSKD.Entidades.Modulo3.Organizacion)FabricaEntidades.ObtenerOrganizacion_M3();

            //Se llena una lista de todos los valores que se piden por pantalla para validar si estan vacios
            List<String> laListaDeInputs = new List<String>();
            laListaDeInputs.Add(this.vista.obtenerNombreOrg());
            laListaDeInputs.Add(this.vista.obtenerEmail());
            laListaDeInputs.Add(this.vista.obtenerTelefono().ToString());
            laListaDeInputs.Add(this.vista.obtenerDireccion());
            laListaDeInputs.Add(this.vista.obtenerEstado());
            laListaDeInputs.Add(this.vista.obtenerTecnica());

            if (Validaciones.ValidarCamposVacios(laListaDeInputs))
            {

                try
                {
                     laOrganizacion.Nombre = this.vista.obtenerNombreOrg();
                     laOrganizacion.Email = this.vista.obtenerEmail();
                     laOrganizacion.Telefono = Int32.Parse(this.vista.obtenerTelefono());
                     laOrganizacion.Direccion = this.vista.obtenerDireccion();
                     laOrganizacion.Estado = this.vista.obtenerEstado();
                     laOrganizacion.Estilo = this.vista.obtenerTecnica();

                     Comando<bool> _comando = FabricaComandos.ObtenerEjecutarAgregarOrganizacion(laOrganizacion);
                     bool resultado = _comando.Ejecutar();
                        if (resultado)
                             this.vista.Respuesta();
                }
                catch (ExcepcionesSKD.Modulo3.OrganizacionExistenteException ex)
                {
                    this.vista.alertaAgregarFallidoNombreOrg(ex);
                }
                catch (ExcepcionesSKD.Modulo3.EstiloInexistenteException ex)
                {
                    this.vista.alertaAgregarFallidoEstiloOrg(ex);
                }
            }
            else
            {
                this.vista.alertaCamposVacios();

            }
        }
    }
}
