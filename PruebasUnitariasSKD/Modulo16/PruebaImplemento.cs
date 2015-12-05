using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DominioSKD;
using NUnit.Framework;


namespace PruebasUnitariasSKD.Modulo16
{
    /// <summary>
    /// Prueba Unitaria que trabaja sobre la entidad Carrito
    /// </summary>
    [TestFixture]
    public class PruebaImplemento
    {
        //Los diferentes usuarios sobre los que probaremos.

        private Implemento miImplemento;


        /// <summary>
        /// Inicializa las clases que probaremos
        /// </summary>
        [SetUp]
        public void Init()
        {

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


        }

        /// <summary>
        /// Se prueba que los diferentes Usuarios no apunten a vacio
        /// </summary>
        [Test]
        public void PruebaVacio()
        {
            Assert.IsNotNull(miImplemento);


        }

        /// <summary>
        /// Se prueba que los diferentes actores tengan los valores correspondientes
        /// </summary>
        [Test]
        public void PruebaValores()
        {
            //Verificamos todos los valores carrito con respecto al implemento
            Assert.AreEqual(1, miImplemento.Id_Implemento);
            Assert.AreEqual("Guantines Karate-DO", miImplemento.Nombre_Implemento);
            Assert.AreEqual("~/GUI/Modulo15/Imagenes/guantes.jpg", miImplemento.Imagen_implemento);
            Assert.AreEqual("Kombate", miImplemento.Marca_Implemento);
            Assert.AreEqual(4500, miImplemento.Precio_Implemento);
            Assert.AreEqual(5, miImplemento.Stock_Minimo_Implemento);
            Assert.AreEqual("S", miImplemento.Talla_Implemento);
            Assert.AreEqual("Guantines", miImplemento.Tipo_Implemento);
            Assert.AreEqual("Azul", miImplemento.Color_Implemento);

        }



        /// <summary>
        /// Se deja en vacio los atributos creados para ser limpiados por el Garbage Collector
        /// </summary>
        [TearDown]
        public void Limpiar()
        {

            miImplemento = null;

        }
    }
}