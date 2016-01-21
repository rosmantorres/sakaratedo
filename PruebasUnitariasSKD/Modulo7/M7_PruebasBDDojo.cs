using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using DominioSKD;
using DatosSKD;
using DatosSKD.Modulo7;
using ExcepcionesSKD.Modulo7;

namespace PruebasUnitariasSKD.Modulo7
{
    /// <summary>
    /// Clase de pruebas para la clase BDDojo
    /// </summary>
    [TestFixture]
    public class M7_PruebasBDDojo
    {
        #region Atributos
        /// <summary>
        /// Atributo que representa el id del dojo
        /// </summary>
        private int idDojo;
        #endregion

        #region SetUp & TearDown
        [SetUp]
        public void Init()
        {
            idDojo = 1;
        }

        [TearDown]
        public void Clean()
        {
            idDojo = 0;
        }
        #endregion

        /// <summary>
        /// Método para probar que se detalla un dojo
        /// </summary>
        [Test]
        public void PruebaDetallarDojoXId()
        {
            BDDojo baseDeDatosDojo = new BDDojo();
            Dojo dojo = baseDeDatosDojo.DetallarDojo(idDojo);
            Assert.AreEqual("bushido", dojo.Nombre_dojo);
        }

        /// <summary>
        /// Método para probar que el dojo no es nulo
        /// </summary>
        [Test]
        public void PruebaDetallarDojoXIdNoNulo()
        {
            BDDojo baseDeDatosDojo = new BDDojo();
            Dojo dojo = baseDeDatosDojo.DetallarDojo(idDojo);
            Assert.IsNotNull(dojo);
        }

        /// <summary>
        /// Método para probar la exception de número entero invalido de detalle dojo

        [Test]
        [ExpectedException(typeof(NumeroEnteroInvalidoException))]
        public void DetalleDojoNumeroEnteroException()
        {
            BDDojo baseDeDatosDojo = new BDDojo();
            baseDeDatosDojo.DetallarDojo(-1);
        }
    }
}
