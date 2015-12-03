using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DominioSKD;
using NUnit.Framework;
using LogicaNegociosSKD.Modulo16;

namespace PruebasUnitariasSKD.Modulo16
{
    /// <summary>
    /// Clase de pruebas unitarias que trabaja sobre la clase Carrito
    /// </summary>
    /* AUN NO ESTA COMPLETADO */
    [TestFixture]
    public class PruebalogicaCompra
    {
        #region Atributos
        //Atributos con los que trabajara la clase
        private List<DominioSKD.Matricula> l;
        private List<DominioSKD.Matricula> l2;


        #endregion

        #region Pruebas Unitarias
        /// <summary>
        /// Preparamos los atributos que vamos a utilizar con valores de prueba
        /// </summary>
        [SetUp]
        public void inicializar()
        {
            List<DominioSKD.Matricula> l = Logicacompra.MatriculasPagadas(1);
            List<DominioSKD.Matricula> l2 = Logicacompra.MatriculasPagadas(1);
        }

        /// <summary>
        /// Prueba unitaria que verifica que el objeto que instancia a logicaComra no es vacia
        /// </summary>
        [Test]
        public void pruebaVacio()
        {
            Assert.IsNotNull(Logicacompra.obtenerListaDeCompra(1));
        }

        /// <summary>
        /// Prueba unitaria que verifica que se obtiene la lista de compra
        /// </summary>
        [Test]
        public void pruebaObtenerlistaDecompra()
        {

            /// Prueba unitaria que verifica que el objeto que instancia a logicaComra no es vacia
            Assert.IsNotNull(Logicacompra.obtenerListaDeCompra(1));

            /// Prueba unitaria que verifica que obtener lista de compra es igual que el otro objeto que se compara


            Assert.AreEqual(l, l2);

        }



        /// <summary>
        /// Prueba unitaria que verifica las matriculas pagadas
        /// </summary>
        [Test]
        public void pruebaListaDematriculasPagadas()
        {

            /// Prueba unitaria que verifica que el objeto que instancia a logicaComra no es vacia
            Assert.IsNotNull(l);

            /// Prueba unitaria que verifica que obtener lista de compra es igual que el otro objeto que se compara

            Assert.AreEqual(l, l2);

        }












        /// <summary>
        /// Limpiamos todos los atributos usados
        /// </summary>
        /// <summary>
        /// Limpiamos todos los atributos usados
        /// </summary>
        [TearDown]
        public void limpiar()
        {

            l = null;
        }
        #endregion
    }
}