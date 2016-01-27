using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using LogicaNegociosSKD;
using LogicaNegociosSKD.Comandos.Modulo5;
using DominioSKD.Fabrica;
using DominioSKD.Entidades.Modulo5;
using DominioSKD.Entidades.Modulo3;
using DominioSKD;
using DatosSKD.Fabrica;
using DatosSKD.InterfazDAO.Modulo5;
using DatosSKD.DAO.Modulo5;
using ExcepcionesSKD.Modulo5;

namespace PruebasUnitariasSKD.Modulo5
{
	/// <summary>
    /// Clase que contiene las pruebas unitarias para DaoCinta
    /// </summary>
    [TestFixture]
    class PUDaoCintas
    {

        #region Atributos
        private Entidad miEntidad;
        private Entidad miEntidadOrg;
        private Entidad miEntidadCinta;
        private Entidad miEntidadCintaModificar;
        private Entidad miEntidadCintaAgregar;
        private Entidad miEntidadValidarCinta;
        private Entidad miEntidadCintaXId;
        #endregion

        #region SetUp & TearDown
        /// <summary>
        /// Método que se ejecuta antes de cada prueba
        /// </summary>
        [SetUp]
        public void init()
        {

            miEntidadOrg = FabricaEntidades.ObtenerOrganizacion_M3(20, "Seito-Ka");
            miEntidad = FabricaEntidades.ObtenerOrganizacion_M3(1, "Seito Karate-do");
            DominioSKD.Entidades.Modulo3.Organizacion org = (DominioSKD.Entidades.Modulo3.Organizacion)miEntidad; ;
            miEntidadCinta = FabricaEntidades.ObtenerCinta_M5(1, "Blanco", "1er Kyu", "Nivel inferior", 1, "Principiante", org, true);
            miEntidadValidarCinta = FabricaEntidades.ObtenerCinta_M5("Blanco", "1er Kyu", "Nivel inferior", 6, "Principiante", org, true);
            miEntidadCintaModificar = FabricaEntidades.ObtenerCinta_M5(1, "Naranja", "1er Kyu", "Nivel inferior", 3, "Principiante", org, true);
            miEntidadCintaAgregar = FabricaEntidades.ObtenerCinta_M5("Negro", "1er Kyu", "Nivel inferior", 5, "Principiante", org, true);
            miEntidadCintaXId = FabricaEntidades.ObtenerCinta_M5(1, "Blanco");
        }

        /// <summary>
        /// Método que se ejecuta luego de cada prueba
        /// </summary>
        [TearDown]
        public void Clean()
        {
            miEntidadOrg = null;
            miEntidad = null;
            miEntidadCinta = null;
            miEntidadCintaModificar = null;
            miEntidadCintaAgregar = null;
            miEntidadValidarCinta = null;

        }
        #endregion

        #region Test
        /// <summary>   
        /// Método para probar si existe o no una Organizacion para Agregar y Modificar en DAO
        /// </summary>
        [Test]
        public void PruebaValidarOrganizacion()
        {
            bool resultado;
            IDaoCinta miDaoCinta = FabricaDAOSqlServer.ObtenerDaoCinta();
            resultado = miDaoCinta.ValidarOrganizacion(miEntidad);
            Assert.IsTrue(resultado);
           
        }
        /// <summary>
        /// Método para probar la exception de Organizacion inexistente para Agregar y Modificar en DAO
        /// </summary>
        [Test]
        [ExpectedException(typeof(OrganizacionInexistenteException))]
        public void PruebaValidarOrganizacionExcepcion()
        {
            bool resultado;
            IDaoCinta miDaoCinta = FabricaDAOSqlServer.ObtenerDaoCinta();
            resultado = miDaoCinta.ValidarOrganizacion(miEntidadOrg);

        }
        /// <summary>
        /// Método para probar el Orden de Cinta existente para Agregar y Modificar en DAO
        /// </summary>
        [Test]
        public void PruebaValidarOrdenCinta()
        {
            bool resultado;
            IDaoCinta miDaoCinta = FabricaDAOSqlServer.ObtenerDaoCinta();
            resultado = miDaoCinta.ValidarOrdenCinta(miEntidadCinta);
            Assert.IsTrue(resultado);

        }
        /// <summary>
        /// Método para probar la exception de Orden de Cinta existente para Agregar y Modificar en DAO
        /// </summary>
        [Test]
        [ExpectedException(typeof(OrdenCintaRepetidoException))]
        public void PruebaValidarOrdenCintaExcepcion()
        {
            bool resultado;
            IDaoCinta miDaoCinta = FabricaDAOSqlServer.ObtenerDaoCinta();
            resultado = miDaoCinta.Modificar(miEntidadCinta);
        }
        /// <summary>
        /// Método para probar si el Nombre de Cinta existente para Agregar y Modificar en DAO
        /// </summary>
        [Test]
        public void PruebaValidarNombreCinta()
        {
            bool resultado;
            IDaoCinta miDaoCinta = FabricaDAOSqlServer.ObtenerDaoCinta();
            resultado = miDaoCinta.ValidarNombreCinta(miEntidadCinta);
            Assert.IsTrue(resultado);

        }
        /// <summary>
        /// Método para probar la exception de Nombre de Cinta existente para Agregar y Modificar en DAO
        /// </summary>
        [Test]
        [ExpectedException(typeof(CintaRepetidaException))]
        public void PruebaValidarNombreCintaExcepcion()
        {
            bool resultado;
            IDaoCinta miDaoCinta = FabricaDAOSqlServer.ObtenerDaoCinta();
            resultado = miDaoCinta.Agregar(miEntidadValidarCinta);
        }
        /// <summary>
        /// Método de prueba para ListarCintasXOrganizacion en DAO, para verificar que no este vacia
        /// </summary>
        [Test]
        public void PruebaListarCintasXOrganizacion()
        {
            List<Entidad> resultado;
            IDaoCinta miDaoCinta = FabricaDAOSqlServer.ObtenerDaoCinta();
            resultado = miDaoCinta.ListarCintasXOrganizacion(miEntidad);
            Assert.IsNotEmpty(resultado);

        }
        /// <summary>
        /// Método de prueba para Agregar una Cinta en DAO
        /// </summary>
        [Test]
        public void PruebaAgregarCinta()
        {
            bool resultado;
            IDaoCinta miDaoCinta = FabricaDAOSqlServer.ObtenerDaoCinta();
            resultado = miDaoCinta.Agregar(miEntidadCintaAgregar);
            Assert.IsTrue(resultado);

        }
        /// <summary>
        /// Método de prueba para modificar una Cinta en DAO
        /// </summary>
        [Test]
        public void PruebaModificarCinta()
        {
            bool resultado;
            IDaoCinta miDaoCinta = FabricaDAOSqlServer.ObtenerDaoCinta();
            resultado = miDaoCinta.Modificar(miEntidadCintaModificar);
            Assert.IsTrue(resultado);

        }
        /// <summary>
        /// Método de prueba para Listar todas las Cintas en DAO, que no este vacia
        /// </summary>
        [Test]
        public void PruebaConsultarTodos()
        {
            List<Entidad> resultado;
            IDaoCinta miDaoCinta = FabricaDAOSqlServer.ObtenerDaoCinta();
            resultado = miDaoCinta.ConsultarTodos();
            Assert.IsNotEmpty(resultado);

        }
        /// <summary>
        /// Método de prueba para consultar detalles de una cinta en DAO, que no sea nula
        /// </summary>
        [Test]
        public void PruebaConsultarXIdNoNula()
        {
            Entidad resultado;
            IDaoCinta miDaoCinta = FabricaDAOSqlServer.ObtenerDaoCinta();
            resultado = miDaoCinta.ConsultarXId(miEntidadCinta);
            Assert.IsNotNull(resultado);

        }

        /// <summary>
        /// Método de prueba para modificar el status de una Cinta en DAO
        /// </summary>
        [Test]
        public void PruebaModificarStatusCinta()
        {
            bool resultado;
            IDaoCinta miDaoCinta = FabricaDAOSqlServer.ObtenerDaoCinta();
            resultado = miDaoCinta.ModificarStatus(miEntidadCintaModificar);
            Assert.IsTrue(resultado);

        }

        #endregion
        
    }

}
