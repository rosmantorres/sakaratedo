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

namespace PruebasUnitariasSKD.Modulo7.PruebasDAO
{
    /// <summary>
    /// Clase que contiene las pruebas unitarias para DaoDojo
    /// </summary>
    [TestFixture]
    public class M7_PruebasDAODojo
    {
        #region Atributos
        private Dojo idDojo;
        private FabricaEntidades fabricaEntidades;
        private FabricaDAOSqlServer fabricaSql;
        private DaoDojo baseDeDatosDojo;
        #endregion

        #region SetUp & TearDown
        [SetUp]
        public void Init()
        {
            fabricaSql = new FabricaDAOSqlServer();
            baseDeDatosDojo = fabricaSql.ObtenerDaoDojoM7();
            fabricaEntidades = new FabricaEntidades();
            idDojo = new Dojo();//se debe sustituir por fabrica
            idDojo.Id = 1;
        }

        [TearDown]
        public void Clean()
        {
            idDojo = null;
            fabricaEntidades = null;
            fabricaSql = null;
            baseDeDatosDojo = null;
        }
        #endregion

        /// <summary>
        /// Método para probar que se detalla un dojo en DAO
        /// </summary>
        [Test]
        public void PruebaDetallarDojoXId()
        {
            Dojo dojo = (Dojo)baseDeDatosDojo.ConsultarXId(idDojo);
            Assert.AreEqual("bushido", dojo.Nombre_dojo);
        }

        /// <summary>
        /// Método para probar que el dojo no es nulo en DAO
        /// </summary>
        [Test]
        public void PruebaDetallarDojoXIdNoNulo()
        {
            Dojo dojo = (Dojo)baseDeDatosDojo.ConsultarXId(idDojo);
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
