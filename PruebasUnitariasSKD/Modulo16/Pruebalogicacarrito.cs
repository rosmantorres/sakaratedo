using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LogicaNegociosSKD.Modulo16;
using NUnit.Framework;

namespace PruebasUnitariasSKD.Modulo16
{
    /// <summary>
    /// Clase de pruebas unitarias que trabaja sobre la clase Logicacarrito
    /// </summary>
    /* AUN NO ESTA COMPLETADO */
    [TestFixture]
    public class Pruebalogicacarrito
    {
        #region Atributos
        //Atributos con los que trabajara la clase
        private Logicacarrito logica;
        #endregion

        #region Pruebas Unitarias
        /// <summary>
        /// Preparamos los atributos que vamos a utilizar con valores de prueba
        /// </summary>
        [SetUp]
        public void inicializar()
        {
            this.logica = new Logicacarrito();
        }

        /// <summary>
        /// Prueba unitaria que verifica que la clase no sea vacia
        /// </summary>
        [Test]
        public void pruebaVacio()
        {
            Assert.IsNotNull(this.logica);
        }

        /// <summary>
        /// Prueba unitaria que verifica que el metodo eliminarItem funcione
        /// </summary>
        [Test]
        public void pruebaEliminarItem()
        {
            Assert.IsTrue(this.logica.eliminarItem(1,1,1));
        }

        /// <summary>
        /// Prueba unitaria que verifica que el metodo registrarPago funcione
        /// </summary>
        [Test]
        public void pruebaRegistrarpago()
        {
            Assert.IsTrue(this.logica.registrarPago(1,null));
        }

        /// <summary>
        /// Limpiamos todos los atributos usados
        /// </summary>
        public void limpiar()
        {
            this.logica = null;
        }
        #endregion
    }
}
