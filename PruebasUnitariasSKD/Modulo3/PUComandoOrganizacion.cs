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
using ExcepcionesSKD.Modulo3;

namespace PruebasUnitariasSKD.Modulo3
{
    /// <summary>
    /// Clase que contiene las pruebas unitarias para Comandos Organizacion
    /// </summary>
    [TestFixture]
    class PUComandoOrganizacion
    {
        #region Atributos
        private Comando<bool> miComando;
        private Entidad miEntidad;
        private Entidad miEntidadOrganizacionModificar;
        private Entidad miEntidadOrganizacionAgregar;
        private Comando<List<Entidad>> miComandoLista;
        private Comando<Entidad> miComandoEntidad;
        private Entidad miEntidadValidarOrg;
        private Entidad miEntidadValidarEstilo;
        #endregion

        #region SetUp & TearDown
        /// <summary>
        /// Método que se ejecuta antes de cada prueba
        /// </summary>
        [SetUp]
        public void init()
        {
            miEntidad = FabricaEntidades.ObtenerOrganizacion_M3(1, "Seito Karate-do", "Av 24, calle 8 edificio Morales, Altamira, Caracas", 2123117754, "seitokaratedo@gmail.com", "Distrito Federal", "Cobra-do");
            miEntidadOrganizacionModificar = FabricaEntidades.ObtenerOrganizacion_M3(1, "Seito-do", "Av 24, calle 8 edificio Morales, Altamira, Caracas", 2123117754, "seitokaratedo@gmail.com", "Distrito Federal", "Cobra-do");
            miEntidadOrganizacionAgregar = FabricaEntidades.ObtenerOrganizacion_M3("Ryu Karate", "Av 24, calle 8 edificio Morales, Altamira, Falcon", 2123117754, "seitokaratedo@gmail.com", "Falcon", "Cobra-do");
            miEntidadValidarEstilo = FabricaEntidades.ObtenerOrganizacion_M3(1, "Seito Karate-do", "Av 24, calle 8 edificio Morales, Altamira, Caracas", 2123117754, "seitokaratedo@gmail.com", "Distrito Federal", "Goju Ryu");
            miEntidadValidarOrg = FabricaEntidades.ObtenerOrganizacion_M3("Seito Karate-do", "Av 24, calle 8 edificio Morales, Altamira, Caracas", 2123117754, "seitokaratedo@gmail.com", "Distrito Federal", "Cobra-do");
            
        }

        /// <summary>
        /// Método que se ejecuta luego de cada prueba
        /// </summary>
        [TearDown]
        public void Clean()
        {
            miComando = null;
            miEntidad = null;
            miEntidadOrganizacionModificar = null;
            miEntidadOrganizacionAgregar = null;
            miComandoLista = null;
            miComandoEntidad = null;
            miEntidadValidarEstilo = null;
            miEntidadValidarOrg = null;
        }
        #endregion

        #region Test
        /// <summary>
        /// Método de prueba para Ejecutar el comando Agregar una Organizacion
        /// </summary>
        [Test]
        public void ejecutarElComandoAgregar()
        {
            this.miComando = FabricaComandos.ObtenerEjecutarAgregarOrganizacion(miEntidadOrganizacionAgregar);
            bool resultado = this.miComando.Ejecutar();
            Assert.IsTrue(resultado);

        }

        /// <summary>
        /// Método para probar la exception de Organizacion existente para Agregar y Modificar en comando
        /// </summary>
        [Test]
        [ExpectedException(typeof(OrganizacionExistenteException))]
        public void PruebaValidarNombreOrganizacionExcepcion()
        {
            this.miComando = FabricaComandos.ObtenerEjecutarAgregarOrganizacion(miEntidadValidarOrg);
            bool resultado = this.miComando.Ejecutar();

        }

        /// <summary>
        /// Método de prueba para Ejecutar el comando Modificar una Organizacion
        /// </summary>
        [Test]
        public void ejecutarElComandoModificar()
        {
            this.miComando = FabricaComandos.ObtenerEjecutarModificarOrganizacion(miEntidadOrganizacionModificar);
            bool resultado = this.miComando.Ejecutar();
            Assert.IsTrue(resultado);

        }

        /// <summary>
        /// Método para probar la exception de Organizacion solo puede tener un estilo para Agregar y Modificar en comando
        /// </summary>
        [Test]
        [ExpectedException(typeof(EstiloInexistenteException))]
        public void PruebaValidarEstiloExcepcion()
        {
            this.miComando = FabricaComandos.ObtenerEjecutarModificarOrganizacion(miEntidadValidarEstilo);
            bool resultado = this.miComando.Ejecutar();

        }
        /// <summary>
        /// Método de prueba para Ejecutar el comando Consultar todas las Organizaciones
        /// </summary>
        [Test]
        public void ejecutarElComandoConsultarTodosOrganizacion()
        {
            this.miComandoLista = FabricaComandos.ObtenerEjecutarConsultarTodosOrganizacion();
            List<Entidad> resultado = this.miComandoLista.Ejecutar();
            Assert.IsNotEmpty(resultado);

        }

        /// <summary>
        /// Método de prueba para Ejecutar el comando Consultar Organizacion por ID
        /// </summary>
        [Test]
        public void ejecutarElComandoConsultarXIdOrganizacion()
        {
            this.miComandoEntidad = FabricaComandos.ObtenerEjecutarConsultarXIdCinta(miEntidad);
            Entidad resultado = this.miComandoEntidad.Ejecutar();
            Assert.IsNotNull(resultado);

        }
        #endregion
    }
}
