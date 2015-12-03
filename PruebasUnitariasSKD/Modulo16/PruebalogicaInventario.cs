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
    public class PruebalogicaInventario
    {
        #region Atributos
        //Atributos con los que trabajara la clase

        private    List<DominioSKD.Implemento> losImp
        #endregion

        #region Pruebas Unitarias
        /// <summary>
        /// Preparamos los atributos que vamos a utilizar con valores de prueba
        /// </summary>
        [SetUp]
        public void inicializar()
        {

            List<DominioSKD.Implemento> losImp = new List<Implemento>();

        }

        /// <summary>
        /// Prueba unitaria que verifica que se obtiene la lista de compra
        /// </summary>
        [Test]
        public void pruebaobtenerListaInventario()
        {

            /// Prueba unitaria que verifica que el objeto que instancia a logicaComra no es vacia
            Assert.IsNotNull(DatosSKD.Modulo16.BDInventario.ListarInventario());

            /// Prueba unitaria que verifica que obtener lista de compra es igual que el otro objeto que se compara

            List<DominioSKD.Implemento> l = DatosSKD.Modulo16.BDInventario.ListarInventario();
            List<DominioSKD.Implemento> l2 = DatosSKD.Modulo16.BDInventario.ListarInventario();


            Implemento elImplemento = new Implemento();
            elImplemento.Id_Implemento = 1;
            elImplemento.Nombre_Implemento = "Guantines Karate-DO";
            elImplemento.Color_Implemento = "Azul";
            elImplemento.Tipo_Implemento = "Guantines";

            Implemento elImplemento2 = new Implemento();
            elImplemento2.Id_Implemento = 1;
            elImplemento2.Nombre_Implemento = "Guantines Karate-DO";
            elImplemento2.Color_Implemento = "Azul";
            elImplemento2.Tipo_Implemento = "Guantines";

            l.Add(elImplemento);

            List<DominioSKD.Implemento> l12 = new List<DominioSKD.Implemento>();
            l2.Add(elImplemento2);

            /// Prueba unitaria que verifica que las istas de implemento contienen los mismo
            Assert.AreEqual(l, l2);

        }



        /// <summary>
        /// Prueba unitaria que verifica que se obtiene la lista de compra
        /// </summary>
        [Test]
        public void pruebadetallarInventario()
        {
            /// Prueba unitaria que verifica que el objeto que instancia a logicaInventario no es vacia
            Assert.IsNotNull(DatosSKD.Modulo16.BDInventario.DetallarImplemento(1));

            /// Prueba unitaria que verifica que el detalle del implemento da igual para el id 1

            Implemento miImplemento = new Implemento();
            miImplemento.Id_Implemento = 1;
            miImplemento.Nombre_Implemento = "Guantines Karate-DO";
            miImplemento.Imagen_implemento = "~/GUI/Modulo15/Imagenes/guantes.jpg";
            miImplemento.Marca_Implemento = "Kombate";
            miImplemento.Precio_Implemento = 4500;
            miImplemento.Stock_Minimo_Implemento = 5;
            miImplemento.Talla_Implemento = "S";
            miImplemento.Tipo_Implemento = "Guantines";
            miImplemento.Color_Implemento = "Azul";

            Implemento miImplemento2 = new Implemento();
            miImplemento2.Id_Implemento = 1;
            miImplemento2.Nombre_Implemento = "Guantines Karate-DO";
            miImplemento2.Imagen_implemento = "~/GUI/Modulo15/Imagenes/guantes.jpg";
            miImplemento2.Marca_Implemento = "Kombate";
            miImplemento2.Precio_Implemento = 4500;
            miImplemento2.Stock_Minimo_Implemento = 5;
            miImplemento2.Talla_Implemento = "S";
            miImplemento2.Tipo_Implemento = "Guantines";
            miImplemento2.Color_Implemento = "Azul";

            Assert.AreEqual(DatosSKD.Modulo16.BDInventario.DetallarImplemento(miImplemento2.Id_Implemento), DatosSKD.Modulo16.BDInventario.DetallarImplemento(miImplemento.Id_Implemento));

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

            losImp = null;
        }
        #endregion
    }
}