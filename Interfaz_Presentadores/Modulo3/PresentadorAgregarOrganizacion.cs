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

namespace Interfaz_Presentadores.Modulo3
{
    public class PresentadorAgregarOrganizacion
    {
        private IContratoAgregarOrganizacion vista;

        public PresentadorAgregarOrganizacion(IContratoAgregarOrganizacion vista)
        {
            this.vista = vista;
        }

        public void agregarValoresOrganizacion()
        {
            DominioSKD.Entidades.Modulo3.Organizacion laOrganizacion = new DominioSKD.Entidades.Modulo3.Organizacion();

            laOrganizacion.Nombre = this.vista.obtenerNombreOrg();
            laOrganizacion.Email = this.vista.obtenerEmail();
            laOrganizacion.Telefono = Int32.Parse(this.vista.obtenerTelefono());
            laOrganizacion.Direccion = this.vista.obtenerDireccion();
            laOrganizacion.Estado = this.vista.obtenerEstado();
            laOrganizacion.Estilo = this.vista.obtenerTecnica();

            FabricaComandos _fabrica = new FabricaComandos();
            Comando<bool> _comando = _fabrica.ObtenerEjecutarAgregarOrganizacion(laOrganizacion);
            bool resultado = _comando.Ejecutar();
        }
    }
}
