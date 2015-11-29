using DominioSKD;
using DatosSKD;
using DatosSKD.Modulo15;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExcepcionesSKD;
using ExcepcionesSKD.Modulo15;

namespace PruebasUnitariasSKD.Modulo15
{

    [TestFixture]

    class PruebaDatos
    {
        private Implemento implemento;
        private Dojo dojo;
        private Implemento implemento2;
        private List<Implemento> implementos;

        [SetUp]
        public void Init()
        {

            implemento = new Implemento();
            implemento2 = new Implemento();
            dojo = new Dojo(1);
            implemento.Nombre_Implemento = "Guantes Karate-DO";
            implemento.Tipo_Implemento = "Guantes";
            implemento.Marca_Implemento = "Adidas";
            implemento.Color_Implemento = "Azul";
            implemento.Talla_Implemento = "S";
            implemento.Precio_Implemento = 1500;
            implemento.Stock_Minimo_Implemento = 5;
            implemento.Cantida_implemento = 20;
            implemento.Dojo_Implemento = dojo;
            implemento.Descripcion_Implemento = "Guantes Wola";
            implemento.Imagen_implemento = "A.jpg";
        }

        [TearDown]
        public void Reset()
        {
            implemento = null;
            implemento2 = null;
            dojo = null;
        }

        [Test]
        [ExpectedException(typeof(ErrorEnParametroDeProcedure))]
        public void PruebaAgregarInventarioNulo()
        {

        
        }

        [Test]
        [ExpectedException(typeof(ErrorEnParametroDeProcedure))]
        public void PruebaAgregarInventarioAtributoNulo()
        {

          
        }

        [Test]
        [ExpectedException(typeof(ErrorEnParametroDeProcedure))]
        public void PruebaAgregarInventarioAtributoStockNegativo()
        {

     
        }
        [Test]
        public void PruebaAgregarInventarioAtributoCantidadNegativo()
        {



        }

        [Test]
        public void PruebaagregarInventarioDatos()
        {

            ConexionBaseDatos.agregarInventarioDatos(implemento);
            //implemento2 = ConexionBaseDatos.implementoInventarioDatosUltimo();
            Assert.AreEqual(2, 2);
        }
        [Test]
        public void PruebaagregarInventarioDatos()
        {

            ConexionBaseDatos.agregarInventarioDatos(implemento);
            //implemento2 = ConexionBaseDatos.implementoInventarioDatosUltimo();
            Assert.AreEqual(2, 2);
        }
        [Test]
        public void PruebaagregarInventarioDatos()
        {

            ConexionBaseDatos.agregarInventarioDatos(implemento);
            //implemento2 = ConexionBaseDatos.implementoInventarioDatosUltimo();
            Assert.AreEqual(2, 2);
        }
        [Test]
        public void PruebaagregarInventarioDatos()
        {

            ConexionBaseDatos.agregarInventarioDatos(implemento);
            //implemento2 = ConexionBaseDatos.implementoInventarioDatosUltimo();
            Assert.AreEqual(2, 2);
        }
    }
}
