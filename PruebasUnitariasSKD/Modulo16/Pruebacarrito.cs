using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DominioSKD;
using NUnit.Framework;

namespace PruebasUnitariasSKD.Modulo16
{
    /// <summary>
    /// Clase de pruebas unitarias que trabaja sobre la clase Carrito
    /// </summary>
    /* AUN NO ESTA COMPLETADO */
    [TestFixture]
    public class Pruebacarrito
    {
        #region Atributos
        //Atributos con los que trabajara la clase
        private Carrito carritoPrueba;
        #endregion

        #region Pruebas Unitarias
        /// <summary>
        /// Preparamos los atributos que vamos a utilizar con valores de prueba
        /// </summary>
        [SetUp]
        public void inicializar()
        {
            this.carritoPrueba = new Carrito();
        }

        /// <summary>
        /// Prueba unitaria que verifica que la clase no sea vacia
        /// </summary>
        public void pruebaVacio()
        {
            Assert.IsNotNull(this.carritoPrueba);
        }

        /// <summary>
        /// Prueba unitaria que verifica que el metodo limpiar funcione
        /// </summary>
        public void pruebaLimpiar()
        {
            Assert.IsTrue(this.carritoPrueba.limpiar());
        }

        /// <summary>
        /// Prueba unitaria que verifica que el metodo eliminarItem funcione
        /// </summary>
        public void pruebaEliminaritem()
        {
            Assert.IsTrue(this.carritoPrueba.eliminarItem(1,1));
        }

        /// <summary>
        /// Limpiamos todos los atributos usados
        /// </summary>
        [TearDown]
        public void limpiar()
        {
            this.carritoPrueba = null;
        }
        #endregion
    }
}