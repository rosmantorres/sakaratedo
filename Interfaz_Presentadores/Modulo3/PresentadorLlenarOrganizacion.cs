using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Interfaz_Contratos.Modulo3;
using LogicaNegociosSKD.Fabrica;
using LogicaNegociosSKD.Comandos.Modulo3;
using DominioSKD;
using LogicaNegociosSKD;

namespace Interfaz_Presentadores.Modulo3
{
    public class PresentadorLlenarOrganizacion
    {
        private IContratoConsultarOrganizacion vista;

        public PresentadorLlenarOrganizacion(IContratoConsultarOrganizacion vista)
        {
            this.vista = vista;
        }

        /// <summary>
        /// Método para ejecutar el comando ConsultarTodasCinta y obtener la lista de organizaciones
        /// </summary>
        public void LlenarInformacion()
        {

            try
            {
                Comando<List<Entidad>> _comando = FabricaComandos.ObtenerEjecutarConsultarTodosOrganizacion();
                List<Entidad> _miLista = _comando.Ejecutar();
                this.llenarVista(_miLista);
            }
            catch (ExcepcionesSKD.Modulo3.ListaVaciaExcepcion ex)
            {
                throw ex;
            }
            
        }

        /// <summary>
        /// Método para llenar la vista (tabla) con la lista de organizaciones
        /// </summary>
        private void llenarVista(List<Entidad> lista)
        {
            foreach (Entidad entidad in lista)
            {
                DominioSKD.Entidades.Modulo3.Organizacion organizacion = (DominioSKD.Entidades.Modulo3.Organizacion)entidad;
                this.vista.llenarIdOrg(organizacion.Id_organizacion.ToString());
                this.vista.llenarNombreOrg(organizacion.Nombre);
                this.vista.llenarEmailOrg(organizacion.Email);
                this.vista.llenarTelefonoOrg(organizacion.Telefono.ToString());
                this.vista.llenarEstiloOrg(organizacion.Estilo);
                this.vista.llenarDireccionOrg(organizacion.Direccion);
                this.vista.llenarEstadoOrg(organizacion.Estado);
                this.vista.llenarBotones(organizacion.Id_organizacion);
                if (organizacion.Status)
                    this.vista.llenarStatusActivo(organizacion.Id_organizacion);
                else
                    this.vista.llenarStatusInactivo(organizacion.Id_organizacion);

            }
        }
    }
}
