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
        private Entidad miEntidadCinta;
        private Entidad miEntidadCintaModificar;
        private Entidad miEntidadCintaAgregar;
        #endregion

        #region SetUp & TearDown
        /// <summary>
        /// Método que se ejecuta antes de cada prueba
        /// </summary>
        [SetUp]
        public void init()
        {
           
          
            miEntidad = FabricaEntidades.ObtenerOrganizacion_M3(1, "Seito Karate-do");
            DominioSKD.Entidades.Modulo3.Organizacion org = (DominioSKD.Entidades.Modulo3.Organizacion)miEntidad; ;
            miEntidadCinta = FabricaEntidades.ObtenerCinta_M5(1, "Blanco", "1er Kyu", "Nivel inferior", 1, "Principiante", org, true);
            miEntidadCintaModificar = FabricaEntidades.ObtenerCinta_M5(1, "Naranja", "1er Kyu", "Nivel inferior", 3, "Principiante", org, true);
            miEntidadCintaAgregar = FabricaEntidades.ObtenerCinta_M5("Negro", "1er Kyu", "Nivel inferior", 5, "Principiante", org, true);
           
        }

        /// <summary>
        /// Método que se ejecuta luego de cada prueba
        /// </summary>
        [TearDown]
        public void Clean()
        {          
            miEntidad = null;
            miEntidadCinta = null;
            miEntidadCintaModificar = null;
            miEntidadCintaAgregar = null;

        }
        #endregion

        #region Test
        /// <summary>
        /// Método para probar la exception de Organizacion inexistente para Agregar y Modificar en DAO
        /// </summary>
        [Test]
        public void PruebaValidarOrganizacion()
        {
            bool resultado;
            IDaoCinta miDaoCinta = FabricaDAOSqlServer.ObtenerDaoCinta();
            resultado = miDaoCinta.ValidarOrganizacion(miEntidad);
            Assert.IsFalse(resultado);
           
        }
        /// <summary>
        /// Método para probar la exception de Orden de Cinta existente para Agregar y Modificar en DAO
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
        /// Método para probar la exception de Nombre de Cinta existente para Agregar y Modificar en DAO
        /// </summary>
        [Test]
        //[ExpectedException(typeof(CintaRepetidaException))]
        public void PruebaValidarNombreCinta()
        {
            bool resultado;
            IDaoCinta miDaoCinta = FabricaDAOSqlServer.ObtenerDaoCinta();
            resultado = miDaoCinta.ValidarNombreCinta(miEntidadCinta);
            Assert.IsFalse(resultado);

        }
        /// <summary>
        /// Método de prueba para ListarCintasXOrganizacion en DAO
        /// </summary>
        [Test]
        public void PruebaListarCintasXOrganizacion()
        {
            List<Entidad> resultado;
            IDaoCinta miDaoCinta = FabricaDAOSqlServer.ObtenerDaoCinta();
            resultado = miDaoCinta.ListarCintasXOrganizacion(miEntidad);
            Assert.IsEmpty(resultado);

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
        /// Método de prueba para Listar todas las Cintas en DAO
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
        /// Método de prueba para consultar detalles de una cinta en DAO
        /// </summary>
        [Test]
        public void PruebaConsultarXId()
        {
            Entidad resultado;
            IDaoCinta miDaoCinta = FabricaDAOSqlServer.ObtenerDaoCinta();
            resultado = miDaoCinta.ConsultarXId(miEntidadCinta);
            Assert.IsNotNull(resultado);

        }
        #endregion
        
    }

}
