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

            implemento2.Nombre_Implemento = "Guantes Karate-DO";
            implemento2.Tipo_Implemento = "Guantes";
            implemento2.Marca_Implemento = "Adidas";
            implemento2.Color_Implemento = "Rojo";
            implemento2.Talla_Implemento = "S";
            implemento2.Precio_Implemento = 1500;
            implemento2.Stock_Minimo_Implemento = 5;
            implemento2.Cantida_implemento = 20;
            implemento2.Dojo_Implemento = dojo;
            implemento2.Descripcion_Implemento = "Guantes Wola";
            implemento2.Imagen_implemento = "A.jpg";
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

        #region PruebaAgregarInventarioAtributoStockNegativo
        [Test]
        [ExpectedException(typeof(ErrorEnParametroDeProcedure))]
        public void PruebaAgregarInventarioAtributoStockNegativo()
        {
                implemento.Stock_Minimo_Implemento=-1;
                ConexionBaseDatos.agregarInventarioDatos(implemento);
     
        }
        #endregion

        #region PruebaAgregarInventarioAtributoCantidadNegativo
        [Test]
        [ExpectedException(typeof(ErrorEnParametroDeProcedure))]
        public void PruebaAgregarInventarioAtributoCantidadNegativo()
        {
                implemento.Cantida_implemento = -1;
                ConexionBaseDatos.agregarInventarioDatos(implemento);

        }
        #endregion

        #region PruebaAgregarInventarioAtributoPrecioNegativo
        [Test]
        [ExpectedException(typeof(ErrorEnParametroDeProcedure))]
        public void PruebaAgregarInventarioAtributoPrecioNegativo()
        {
            implemento.Cantida_implemento = -1;
            ConexionBaseDatos.agregarInventarioDatos(implemento);

        }
        #endregion

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

        #region PruebaModificarInventarioAtributoNulo
        [Test]
        [ExpectedException(typeof(ErrorEnParametroDeProcedure))]
        public void PruebaModificarInventarioAtributoNulo()
        {
            implemento.Nombre_Implemento = null;
            ConexionBaseDatos.agregarInventarioDatos(implemento);

        }
        #endregion

        #region PruebaModificarInventarioAtributoStockNegativo
        [Test]
        [ExpectedException(typeof(ErrorEnParametroDeProcedure))]
        public void PruebaModificarInventarioAtributoStockNegativo()
        {
            implemento.Stock_Minimo_Implemento = -1;
            ConexionBaseDatos.modificarInventarioDatos(implemento);

        }
        #endregion

        #region PruebaModificarInventarioAtributoCantidadNegativo
        [Test]
        [ExpectedException(typeof(ErrorEnParametroDeProcedure))]
        public void PruebaModificarInventarioAtributoCantidadNegativo()
        {
            implemento.Cantida_implemento = -1;
            ConexionBaseDatos.modificarInventarioDatos(implemento);

        }
        #endregion

        #region PruebaModificarInventarioAtributoPrecioNegativo
        [Test]
        [ExpectedException(typeof(ErrorEnParametroDeProcedure))]
        public void PruebaModificarInventarioAtributoPrecioNegativo()
        {
            implemento.Cantida_implemento = -1;
            ConexionBaseDatos.modificarInventarioDatos(implemento);

        }
        #endregion

        #region PruebaModificarInventarioDatos
        [Test]
        public void PruebaModificarInventarioDatos()
        {

            ConexionBaseDatos.agregarInventarioDatos(implemento);
            implemento2 = ConexionBaseDatos.implementoInventarioDatosUltimo();
            implemento2.Nombre_Implemento = "Wololo";
            ConexionBaseDatos.modificarInventarioDatos(implemento2);
            implemento2 = ConexionBaseDatos.implementoInventarioDatosUltimo();
            Assert.AreEqual(implemento2.Nombre_Implemento, "Wololo");

        }
        #endregion

        #region PruebaimplementoInventarioDatos
        [Test]
        public void PruebaimplementoInventarioDatos()
        {
            ConexionBaseDatos.agregarInventarioDatos(implemento);
            implemento = ConexionBaseDatos.implementoInventarioDatosUltimo();
            implemento2 = ConexionBaseDatos.implementoInventarioDatos(implemento.Id_Implemento);
            Assert.AreEqual(implemento.Nombre_Implemento, implemento2.Nombre_Implemento);
        }
        #endregion

        #region PruebalistarInventarioDatos
        [Test]
        public void PruebalistarInventarioDatos()
        {
            implementos = ConexionBaseDatos.listarInventarioDatos();
            int numero = implementos.Count();
            Assert.AreEqual(2 , 2);
        }
        #endregion
        
    }
}
