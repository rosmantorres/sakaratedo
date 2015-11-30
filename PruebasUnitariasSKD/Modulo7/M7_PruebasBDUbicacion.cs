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
    /// Clase de pruebas para la clase BDUBicacion
    /// </summary>
    [TestFixture]
    public class M7_PruebasBDUbicacion
    {
        #region Atributos
        /// <summary>
        /// Atributo que representa el id de la ubicación
        /// </summary>
        private int idUbicacion;
        #endregion

        #region SetUp & TearDown
        [SetUp]
        public void Init()
        {
            idUbicacion = 6;
        }

        [TearDown]
        public void Clean()
        {
            idUbicacion = 0;
        }
        #endregion

        /// <summary>
        /// Método para probar que se detalla una ubicación
        /// </summary>
        [Test]
        public void PruebaDetallarUbicacionXId()
        {
            BDUbicacion baseDeDatosUbicacion = new BDUbicacion();
            Ubicacion ubicacion = baseDeDatosUbicacion.DetallarUbicacion(idUbicacion);
            Assert.AreEqual("Caracas", ubicacion.Ciudad);
        }

        /// <summary>
        /// Método para probar que la ubicacion no sea nula
        /// </summary>
        [Test]
        public void PruebaDetallarUbicacionXIdNoNula()
        {
            BDUbicacion baseDeDatosUbicacion = new BDUbicacion();
            Ubicacion ubicacion = baseDeDatosUbicacion.DetallarUbicacion(idUbicacion);
            Assert.IsNotNull(ubicacion);
        }


    }
}
