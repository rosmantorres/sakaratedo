using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using LogicaNegociosSKD;
using LogicaNegociosSKD.Comandos.Modulo3;
using DominioSKD.Fabrica;
using DominioSKD.Entidades.Modulo3;
using DominioSKD;
using DatosSKD.Fabrica;
using DatosSKD.InterfazDAO.Modulo3;
using DatosSKD.DAO.Modulo3;
using LogicaNegociosSKD.Fabrica;

namespace PruebasUnitariasSKD.Modulo3
{
    [TestFixture]
    class PUComandoOrganizacion
    {
        private Comando<bool> miComando;
        private Entidad miEntidad;
        private Entidad miEntidadOrganizacionModificar;
        FabricaComandos fabricaComandos;
        private Entidad miEntidadOrganizacionAgregar;
        private Comando<List<Entidad>> miComandoLista;
        private Comando<Entidad> miComandoEntidad;

        [SetUp]
        public void init()
        {
            FabricaEntidades miFabrica = new FabricaEntidades();
            fabricaComandos = new FabricaComandos();
            miEntidad = miFabrica.ObtenerOrganizacion_M3(1, "Seito Karate-do", "Av 24, calle 8 edificio Morales, Altamira, Caracas", 2123117754, "seitokaratedo@gmail.com", "Distrito Federal", "Cobra-do");
            miEntidadOrganizacionModificar = miFabrica.ObtenerOrganizacion_M3(1, "Seito-do", "Av 24, calle 8 edificio Morales, Altamira, Caracas", 2123117754, "seitokaratedo@gmail.com", "Distrito Federal", "Cobra-do");
            miEntidadOrganizacionAgregar = miFabrica.ObtenerOrganizacion_M3(20, "Karate", "Av 24, calle 8 edificio Morales, Altamira, Falcon", 2123117754, "seitokaratedo@gmail.com", "Falcon", "Cobra-do");

        }

        [Test]
        public void ejecutarElComandoAgregar()
        {
            this.miComando = this.fabricaComandos.ObtenerEjecutarAgregarOrganizacion(miEntidadOrganizacionAgregar);
            bool resultado = this.miComando.Ejecutar();
            Assert.IsFalse(resultado);

        }


        [Test]
        public void ejecutarElComandoModificar()
        {
            this.miComando = this.fabricaComandos.ObtenerEjecutarModificarOrganizacion(miEntidadOrganizacionModificar);
            bool resultado = this.miComando.Ejecutar();
            Assert.IsFalse(resultado);

        }

        [Test]
        public void ejecutarElComandoConsultarTodosOrganizacion()
        {
            this.miComandoLista = this.fabricaComandos.ObtenerEjecutarConsultarTodosOrganizacion();
            List<Entidad> resultado = this.miComandoLista.Ejecutar();
            Assert.IsNotEmpty(resultado);

        }


        [Test]
        public void ejecutarElComandoConsultarXIdOrganizacion()
        {
            this.miComandoEntidad = this.fabricaComandos.ObtenerEjecutarConsultarXIdCinta(miEntidad);
            Entidad resultado = this.miComandoEntidad.Ejecutar();
            Assert.IsNotNull(resultado);

        }
    }
}
