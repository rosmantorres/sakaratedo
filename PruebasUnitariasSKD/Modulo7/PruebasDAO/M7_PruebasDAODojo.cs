using DatosSKD.DAO.Modulo7;
using DatosSKD.Fabrica;
using DominioSKD;
using DominioSKD.Fabrica;
using ExcepcionesSKD.Modulo7;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DominioSKD.Entidades.Modulo7;

namespace PruebasUnitariasSKD.Modulo7.PruebasDAO
{
    /// <summary>
    /// Clase que contiene las pruebas unitarias para DaoDojo
    /// </summary>
    [TestFixture]
    public class M7_PruebasDAODojo
    {
        #region Atributos
        private DojoM7 idDojo;
        private DaoDojo baseDeDatosDojo;
        #endregion

        #region SetUp & TearDown
        /// <summary>
        /// Método que se ejecuta antes de cada prueba
        /// </summary>
        [SetUp]
        public void Init()
        {
            baseDeDatosDojo = FabricaDAOSqlServer.ObtenerDaoDojoM7();
            idDojo = (DojoM7)FabricaEntidades.ObtenerDojoM7();
            idDojo.Id = 1;
        }

        /// <summary>
        /// Método que se ejecuta luego de cada prueba
        /// </summary>
        [TearDown]
        public void Clean()
        {
            idDojo = null;
            baseDeDatosDojo = null;
        }
        #endregion

        /// <summary>
        /// Método para probar que se detalla un dojo en DAO
        /// </summary>
        [Test]
        public void PruebaDetallarDojoXId()
        {
            DojoM7 dojo = (DojoM7)baseDeDatosDojo.ConsultarXId(idDojo);
            Assert.AreEqual("bushido", dojo.Nombre_dojo);
        }

        /// <summary>
        /// Método para probar que el dojo no es nulo en DAO
        /// </summary>
        [Test]
        public void PruebaDetallarDojoXIdNoNulo()
        {
            DojoM7 dojo = (DojoM7)baseDeDatosDojo.ConsultarXId(idDojo);
            Assert.IsNotNull(dojo);
        }

        /// <summary>
        /// Método para probar la exception de número entero invalido de detalle dojo en DAO
        /// </summary>
        [Test]
        [ExpectedException(typeof(NumeroEnteroInvalidoException))]
        public void DetalleDojoNumeroEnteroException()
        {
            idDojo.Id = -1;
            baseDeDatosDojo.ConsultarXId(idDojo);
        }
    }
}
