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
        private FabricaComandos fabricaComandos;
        private Entidad miEntidadOrganizacionAgregar;
        private Comando<List<Entidad>> miComandoLista;
        private Comando<Entidad> miComandoEntidad;
        private FabricaEntidades miFabrica;
        #endregion

        #region SetUp & TearDown
        /// <summary>
        /// Método que se ejecuta antes de cada prueba
        /// </summary>
        [SetUp]
        public void init()
        {
            miFabrica = new FabricaEntidades();
            fabricaComandos = new FabricaComandos();
            miEntidad = miFabrica.ObtenerOrganizacion_M3(1, "Seito Karate-do", "Av 24, calle 8 edificio Morales, Altamira, Caracas", 2123117754, "seitokaratedo@gmail.com", "Distrito Federal", "Cobra-do");
            miEntidadOrganizacionModificar = miFabrica.ObtenerOrganizacion_M3(1, "Seito-do", "Av 24, calle 8 edificio Morales, Altamira, Caracas", 2123117754, "seitokaratedo@gmail.com", "Distrito Federal", "Cobra-do");
            miEntidadOrganizacionAgregar = miFabrica.ObtenerOrganizacion_M3(20, "Karate", "Av 24, calle 8 edificio Morales, Altamira, Falcon", 2123117754, "seitokaratedo@gmail.com", "Falcon", "Cobra-do");

        }

        /// <summary>
        /// Método que se ejecuta luego de cada prueba
        /// </summary>
        [TearDown]
        public void Clean()
        {
            miComando = null;
            fabricaComandos = null;
            miEntidad = null;
            miEntidadOrganizacionModificar = null;
            miEntidadOrganizacionAgregar = null;
            miFabrica = null;
            miComandoLista = null;
            miComandoEntidad = null;

        }
        #endregion

        #region Test
        /// <summary>
        /// Método de prueba para Ejecutar el comando Agregar una Organizacion
        /// </summary>
        [Test]
        public void ejecutarElComandoAgregar()
        {
            this.miComando = this.fabricaComandos.ObtenerEjecutarAgregarOrganizacion(miEntidadOrganizacionAgregar);
            bool resultado = this.miComando.Ejecutar();
            Assert.IsFalse(resultado);

        }

        /// <summary>
        /// Método de prueba para Ejecutar el comando Modificar una Organizacion
        /// </summary>
        [Test]
        public void ejecutarElComandoModificar()
        {
            this.miComando = this.fabricaComandos.ObtenerEjecutarModificarOrganizacion(miEntidadOrganizacionModificar);
            bool resultado = this.miComando.Ejecutar();
            Assert.IsFalse(resultado);

        }
        /// <summary>
        /// Método de prueba para Ejecutar el comando Consultar todas las Organizaciones
        /// </summary>
        [Test]
        public void ejecutarElComandoConsultarTodosOrganizacion()
        {
            this.miComandoLista = this.fabricaComandos.ObtenerEjecutarConsultarTodosOrganizacion();
            List<Entidad> resultado = this.miComandoLista.Ejecutar();
            Assert.IsNotEmpty(resultado);

        }

        /// <summary>
        /// Método de prueba para Ejecutar el comando Consultar Organizacion por ID
        /// </summary>
        [Test]
        public void ejecutarElComandoConsultarXIdOrganizacion()
        {
            this.miComandoEntidad = this.fabricaComandos.ObtenerEjecutarConsultarXIdCinta(miEntidad);
            Entidad resultado = this.miComandoEntidad.Ejecutar();
            Assert.IsNotNull(resultado);

        }
        #endregion
    }
}
