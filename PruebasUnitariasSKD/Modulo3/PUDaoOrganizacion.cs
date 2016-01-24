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
using ExcepcionesSKD.Modulo3;


namespace PruebasUnitariasSKD.Modulo3
{
    /// <summary>
    /// Clase que contiene las pruebas unitarias para DaoOrganizacion
    /// </summary>
    [TestFixture]
    class PUDaoOrganizacion
    {
        #region Atributos
        private Entidad miEntidad;
        private Entidad miEntidadModificar;
        private Entidad miEntidadAgregar;
        #endregion

        #region SetUp & TearDown
        /// <summary>
        /// Método que se ejecuta antes de cada prueba
        /// </summary>
        [SetUp]
        public void init()
        {
            miEntidad = FabricaEntidades.ObtenerOrganizacion_M3(1, "Seito Karate-do", "Av 24, calle 8 edificio Morales, Altamira, Caracas", 2123117754, "seitokaratedo@gmail.com", "Distrito Federal", "Cobra-do");
            miEntidadModificar = FabricaEntidades.ObtenerOrganizacion_M3(1, "Seito", "Av 24, calle 8 edificio Morales, Altamira, Caracas", 2123117754, "seitokaratedo@gmail.com", "Distrito Federal", "Cobra-do");
            miEntidadAgregar = FabricaEntidades.ObtenerOrganizacion_M3(19, "Karate-do", "Av 24, calle 8 edificio Morales, Altamira, Falcon", 2123117754, "seitokaratedo@gmail.com", "Falcon", "Cobra-do");       
            
        }

        /// <summary>
        /// Método que se ejecuta luego de cada prueba
        /// </summary>
        [TearDown]
        public void Clean()
        {
            miEntidad = null;
            miEntidadModificar = null;
            miEntidadAgregar = null;

        }
        #endregion

        #region Test
        /// <summary>
        /// Método para probar la exception de Organizacion existente para Agregar y Modificar en DAO
        /// </summary>
        [Test]
       // [ExpectedException(typeof(OrganizacionExistenteException))]
        public void PruebaValidarNombreOrganizacion()
        {
            bool resultado;
            IDaoOrganizacion miDaoOrganizacion = FabricaDAOSqlServer.ObtenerDaoOrganizacion();
            resultado = miDaoOrganizacion.ValidarNombreOrganizacion(miEntidad);
            Assert.IsTrue(resultado);

        }
        /// <summary>
        /// Método para probar la exception de Organizacion solo puede tener un estilo para Agregar y Modificar en DAO
        /// </summary>
        [Test]
        //[ExpectedException(typeof(EstiloInexistenteException))]
        public void PruebaValidarEstilo()
        {
            bool resultado;
            IDaoOrganizacion miDaoOrganizacion = FabricaDAOSqlServer.ObtenerDaoOrganizacion();
            resultado = miDaoOrganizacion.ValidarEstilo(miEntidad);
            Assert.IsTrue(resultado);

        }
        /// <summary>
        /// Método de prueba para ListarOrganizaciones sol el id y el nombre en DAO
        /// </summary>
        [Test]
        public void PruebaComboOrganizaciones()
        {
            List<Entidad> resultado;
            IDaoOrganizacion miDaoOrganizacion = FabricaDAOSqlServer.ObtenerDaoOrganizacion();
            resultado = miDaoOrganizacion.ComboOrganizaciones();
            Assert.IsNotEmpty(resultado);

        }
        /// <summary>
        /// Método de prueba para Agregar organizaciones en DAO
        /// </summary>
        [Test]
        public void PruebaAgregarOrganizacion()
        {
            bool resultado;
            IDaoOrganizacion miDaoOrganizacion = FabricaDAOSqlServer.ObtenerDaoOrganizacion();
            resultado = miDaoOrganizacion.Agregar(miEntidadAgregar);
            Assert.IsTrue(resultado);

        }
        /// <summary>
        /// Método de prueba para Modificar organizaciones en DAO
        /// </summary>
        [Test]
        public void PruebaModificarOrganizacion()
        {
            bool resultado;
            IDaoOrganizacion miDaoOrganizacion = FabricaDAOSqlServer.ObtenerDaoOrganizacion();
            resultado = miDaoOrganizacion.Modificar(miEntidadModificar);
            Assert.IsTrue(resultado);

        }
        /// <summary>
        /// Método de prueba para Listar Todas las Organizaciones 
        /// </summary>
        [Test]
        public void PruebaConsultarTodos()
        {
            List<Entidad> resultado;
            IDaoOrganizacion miDaoOrganizacion = FabricaDAOSqlServer.ObtenerDaoOrganizacion();
            resultado = miDaoOrganizacion.ConsultarTodos();
            Assert.IsNotEmpty(resultado);

        }
        /// <summary>
        /// Método de prueba para Consultar una organizacion en especifico
        /// </summary>
        [Test]
        public void PruebaConsultarXId()
        {
            Entidad resultado;
            IDaoOrganizacion miDaoOrganizacion = FabricaDAOSqlServer.ObtenerDaoOrganizacion();
            resultado = miDaoOrganizacion.ConsultarXId(miEntidad);
            Assert.IsNotNull(resultado);

        }
        #endregion
    }
}
