using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DatosSKD.Modulo16;
using NUnit.Framework;

namespace PruebasUnitariasSKD.Modulo16
{
    /// <summary>
    /// Clase de pruebas unitarias que trabaja sobre la clase BDCarrito
    /// </summary>
    /* AUN NO ESTA COMPLETADO */
    [TestFixture]
    public class PruebaBDCarrito
    {
        #region Atributos
        //Atributos con los que trabajara la clase
        private BDCarrito carritoBD;
        #endregion

        #region Pruebas Unitarias
        /// <summary>
        /// Preparamos los atributos que vamos a utilizar con valores de prueba
        /// </summary>
        [SetUp]
        public void inicializar()
        {
            this.carritoBD = new BDCarrito();
        }

        /// <summary>
        /// Prueba unitaria que verifica que la clase no sea vacia
        /// </summary>
        [Test]
        public void pruebaVacio()
        {
            Assert.IsNotNull(this.carritoBD);
        }

        /// <summary>
        /// Prueba unitaria que verifica que el metodo eliminarItem funcione
        /// </summary>
        [Test]
        public void pruebaEliminarItem()
        {
            Assert.IsTrue(this.carritoBD.eliminarItem(1, 1, 1));
        }

        /// <summary>
        /// Prueba unitaria que verifica que el metodo registrarPago funcione
        /// </summary>
        [Test]
        public void pruebaRegistrarpago()
        {
            Assert.IsTrue(this.carritoBD.registrarPago("1",null,1));
        }

        /// <summary>
        /// Limpiamos todos los atributos usados
        /// </summary>
        [TearDown]
        public void limpiar()
        {
            this.carritoBD = null;
        }
        #endregion
    }
}
