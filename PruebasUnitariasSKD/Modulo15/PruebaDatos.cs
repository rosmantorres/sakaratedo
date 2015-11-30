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

        #region PruebaAgregarInventarioNulo
        [Test]
        [ExpectedException(typeof(ErrorEnParametroDeProcedure))]
        public void PruebaAgregarInventarioNulo()
        {
            implemento = null;
            ConexionBaseDatos.agregarInventarioDatos(implemento);

       
        }
        #endregion

        #region PruebaAgregarInventarioAtributoNulo
        [Test]
        [ExpectedException(typeof(ErrorEnParametroDeProcedure))]
        public void PruebaAgregarInventarioAtributoNulo()
        {
            implemento.Nombre_Implemento = null;
            ConexionBaseDatos.agregarInventarioDatos(implemento);

        }
        #endregion

        [Test]
        [ExpectedException(typeof(ErrorEnParametroDeProcedure))]
        public void PruebaAgregarInventarioAtributoStockNegativo()
        {

     
        }
        [Test]
        public void PruebaAgregarInventarioAtributoCantidadNegativo()
        {



        }

        #region PruebaAgregarInventarioDatos
        [Test]
        public void PruebaAgregarInventarioDatos()
        {

            ConexionBaseDatos.agregarInventarioDatos(implemento);
            implemento2 = ConexionBaseDatos.implementoInventarioDatosUltimo();
            Assert.AreEqual(implemento.Nombre_Implemento, implemento2.Nombre_Implemento);
            Assert.AreEqual(implemento.Tipo_Implemento, implemento2.Tipo_Implemento);
            Assert.AreEqual(implemento.Marca_Implemento, implemento2.Marca_Implemento);
            Assert.AreEqual(implemento.Color_Implemento, implemento2.Color_Implemento);
            Assert.AreEqual(implemento.Talla_Implemento, implemento2.Talla_Implemento);
            Assert.AreEqual(implemento.Precio_Implemento, implemento2.Precio_Implemento);
            Assert.AreEqual(implemento.Cantida_implemento, implemento2.Cantida_implemento);
            Assert.AreEqual("Activo", implemento2.Estatus_Implemento);
            Assert.AreEqual(implemento.Stock_Minimo_Implemento, implemento2.Stock_Minimo_Implemento);
            Assert.AreEqual(implemento.Imagen_implemento, implemento2.Imagen_implemento);
            Assert.AreEqual(implemento.Descripcion_Implemento, implemento2.Descripcion_Implemento);

        }
        #endregion


    }
}
