using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using DominioSKD;
using DatosSKD;
using DatosSKD.Modulo7;

namespace PruebasUnitariasSKD.Modulo7
{
    /// <summary>
    /// Clase de pruebas para la clase BDOrganizacion
    /// </summary>
    [TestFixture]
    public class M7_PruebasBDOrganizacion
    {
        #region Atributos
        /// <summary>
        /// Atributo que representa el id de la organizacion
        /// </summary>
        private int idOrganizacion;
        #endregion

        #region SetUp & TearDown
        [SetUp]
        public void Init()
        {
            idOrganizacion = 1;
        }

        [TearDown]
        public void Clean()
        {
            idOrganizacion = 0;
        }
        #endregion

        /// <summary>
        /// Método para probar que se detalla una organizacion
        /// </summary>
        [Test]
        public void PruebaDetallarOrganizacionXId()
        {
            BDOrganizacion baseDeDatosOrganizacion = new BDOrganizacion();
            Organizacion organizacion = baseDeDatosOrganizacion.DetallarOrganizacion(idOrganizacion);
            Assert.AreEqual("Seito Karate-do", organizacion.Nombre);
        }

        /// <summary>
        /// Método para probar que la organizacion no es nula
        /// </summary>
        [Test]
        public void PruebaDetallarOrganizacionXIdNoNulo()
        {
            BDOrganizacion baseDeDatosOrganizacion = new BDOrganizacion();
            Organizacion organizacion = baseDeDatosOrganizacion.DetallarOrganizacion(idOrganizacion);
            Assert.IsNotNull(organizacion);
        }

        /// <summary>
        /// Método para probar la exception de número entero invalido de detallar organizacion
        /// </summary>
        [Test]
        [ExpectedException(typeof(NumeroEnteroInvalidoException))]
        public void DetallarOrganizacionNumeroEnteroException()
        {
            BDOrganizacion baseDeDatosOrganizacion = new BDOrganizacion();
            Organizacion organizacion = baseDeDatosOrganizacion.DetallarOrganizacion(-1);
        }

    }
}
