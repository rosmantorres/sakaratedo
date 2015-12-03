using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DominioSKD;
using NUnit.Framework;
using DatosSKD.Modulo16;

namespace PruebasUnitariasSKD.Modulo16
{
    /// <summary>
    /// Clase de pruebas unitarias que trabaja sobre la clase Carrito
    /// </summary>
    /* AUN NO ESTA COMPLETADO */
    [TestFixture]
    public class PruebaBDCompra
    {
        #region Atributos
        //Atributos con los que trabajara la clase
        private List<DominioSKD.Compra> miCom;
        private List<DominioSKD.Compra> l;
        private List<DominioSKD.Compra> l2;
        #endregion

        #region Pruebas Unitarias
        /// <summary>
        /// Preparamos los atributos que vamos a utilizar con valores de prueba
        /// </summary>
        [SetUp]
        public void inicializar()
        {
            List<DominioSKD.Compra> miCom = new List<Compra>();
            List<DominioSKD.Compra> l = DatosSKD.Modulo16.BDCompra.ListarCompra(1);
            List<DominioSKD.Compra> l2 = DatosSKD.Modulo16.BDCompra.ListarCompra(1);

        }

        /// <summary>
        /// Prueba unitaria que verifica que el objeto que instancia a logicaComra no es vacia
        /// </summary>
        [Test]
        public void pruebaVacio()
        {
            miCom = DatosSKD.Modulo16.BDCompra.ListarCompra(1);
            Assert.IsNotNull(miCom);
        }

        /// <summary>
        /// Prueba unitaria que verifica que se obtiene la lista de compra
        /// </summary>
        [Test]
        public void pruebaBDmatriculasPagadas()
        {

            /// Prueba unitaria que verifica que el objeto que instancia a logicaComra no es vacia
            Assert.IsNotNull(DatosSKD.Modulo16.BDMatricula.mostrarMensualidadesmorosas(1));

            /// Prueba unitaria que verifica que obtener lista de compra es igual que el otro objeto que se compara con el mismo usuario

            List<DominioSKD.Matricula> l = DatosSKD.Modulo16.BDMatricula.mostrarMensualidadesmorosas(1);
            List<DominioSKD.Matricula> l2 = DatosSKD.Modulo16.BDMatricula.mostrarMensualidadesmorosas(1);

            Assert.AreEqual(l, l2);

        }



        /// <summary>
        /// Prueba unitaria que verifica la lista de compras asociadas a un usuario
        /// </summary>
        [Test]
        public void pruebaBDobtenerListadeCompra()
        {

            /// Prueba unitaria que verifica que el objeto que instancia a logicaComra no es vacia
            Assert.IsNotNull(DatosSKD.Modulo16.BDCompra.ListarCompra(1));

            /// Prueba unitaria que verifica que obtener lista de compra es igual que el otro objeto que se compara con el mismo usuario



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

            miCom = null;
            l = null;
            l2 = null;
        }
        #endregion
    }
}