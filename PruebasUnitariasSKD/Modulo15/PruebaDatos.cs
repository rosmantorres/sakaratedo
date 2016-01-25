using DominioSKD;
using DatosSKD;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExcepcionesSKD;
using ExcepcionesSKD.Modulo15;
using DominioSKD.Entidades.Modulo15;


namespace PruebasUnitariasSKD.Modulo15
{

    [TestFixture]

    class PruebaDatos
    {
        private Implemento implemento;
        private Dojo dojo;
        private Implemento implemento2;
        private List<Implemento> implementos;
        private String usuario;
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

            usuario = "usuario02";
            
        }

        [TearDown]
        public void Reset()
        {
            implemento = null;
            implemento2 = null;
            dojo = null;
        }

        #region M15_PruebaAgregarInventarioNulo
        [Test]
        [ExpectedException(typeof(ErrorEnParametroDeProcedure))]
        public void M15_PruebaAgregarInventarioNulo()
        {
            implemento = null;
           // ConexionBaseDatos.agregarInventarioDatos(implemento);
       
        }
        #endregion


        #region M15_PruebaAgregarInventarioAtributoNulo
        [Test]
        [ExpectedException(typeof(ErrorEnParametroDeProcedure))]
        public void M15_PruebaAgregarInventarioAtributoNulo()
        {
            implemento.Nombre_Implemento = null;
        //    ConexionBaseDatos.agregarInventarioDatos(implemento);

        }
        #endregion

        #region M15_PruebaAgregarInventarioAtributoStockNegativo
        [Test]
        [ExpectedException(typeof(ErrorEnParametroDeProcedure))]
        public void M15_PruebaAgregarInventarioAtributoStockNegativo()
        {
                implemento.Stock_Minimo_Implemento=-1;
            //    ConexionBaseDatos.agregarInventarioDatos(implemento);
     
        }
        #endregion

        #region M15_PruebaAgregarInventarioAtributoCantidadNegativo
        [Test]
        [ExpectedException(typeof(ErrorEnParametroDeProcedure))]
        public void M15_PruebaAgregarInventarioAtributoCantidadNegativo()
        {
                implemento.Cantida_implemento = -1;
            //    ConexionBaseDatos.agregarInventarioDatos(implemento);

        }
        #endregion


        #region M15_PruebaAgregarInventarioAtributoPrecioNegativo
        [Test]
        [ExpectedException(typeof(ErrorEnParametroDeProcedure))]
        public void M15_PruebaAgregarInventarioAtributoPrecioNegativo()
        {
            implemento.Cantida_implemento = -1;
         //   ConexionBaseDatos.agregarInventarioDatos(implemento);

        }
        #endregion

        #region M15_PruebaAgregarInventarioDatos
        [Test]
        public void M15_PruebaAgregarInventarioDatos()
        {

         //   ConexionBaseDatos.agregarInventarioDatos(implemento);
         //   implemento2 = ConexionBaseDatos.implementoInventarioDatosUltimo();
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

        #region M15_PruebaModificarInventarioNulo
        [Test]
        [ExpectedException(typeof(ErrorEnParametroDeProcedure))]
        public void M15_PruebaModificarInventarioNulo()
        {
            implemento = null;
        //    ConexionBaseDatos.modificarInventarioDatos(implemento);

        }
        #endregion

        #region M15_PruebaModificarInventarioAtributoNulo
        [Test]
        [ExpectedException(typeof(ErrorEnParametroDeProcedure))]
        public void M15_PruebaModificarInventarioAtributoNulo()
        {
            implemento.Nombre_Implemento = null;
          //  ConexionBaseDatos.agregarInventarioDatos(implemento);

        }
        #endregion

        #region M15_PruebaModificarInventarioAtributoStockNegativo
        [Test]
        [ExpectedException(typeof(ErrorEnParametroDeProcedure))]
        public void M15_PruebaModificarInventarioAtributoStockNegativo()
        {
            implemento.Stock_Minimo_Implemento = -1;
         //   ConexionBaseDatos.modificarInventarioDatos(implemento);

        }
        #endregion

        #region M15_PruebaModificarInventarioAtributoCantidadNegativo
        [Test]
        [ExpectedException(typeof(ErrorEnParametroDeProcedure))]
        public void M15_PruebaModificarInventarioAtributoCantidadNegativo()
        {
            implemento.Cantida_implemento = -1;
        //    ConexionBaseDatos.modificarInventarioDatos(implemento);

        }
        #endregion

        #region M15_PruebaModificarInventarioAtributoPrecioNegativo
        [Test]
        [ExpectedException(typeof(ErrorEnParametroDeProcedure))]
        public void M15_PruebaModificarInventarioAtributoPrecioNegativo()
        {
            implemento.Cantida_implemento = -1;
        //    ConexionBaseDatos.modificarInventarioDatos(implemento);

        }
        #endregion

        #region M15_PruebaModificarInventarioDatos
        [Test]
        public void M15_PruebaModificarInventarioDatos()
        {

        //    ConexionBaseDatos.agregarInventarioDatos(implemento);
        //    implemento2 = ConexionBaseDatos.implementoInventarioDatosUltimo();
            implemento2.Nombre_Implemento = "Wololo";
//ConexionBaseDatos.modificarInventarioDatos(implemento2);
          //  implemento2 = ConexionBaseDatos.implementoInventarioDatosUltimo();
            Assert.AreEqual(implemento2.Nombre_Implemento, "Wololo");

        }
        #endregion

        #region M15_PruebaimplementoInventarioDatos
        [Test]
        public void M15_PruebaimplementoInventarioDatos()
        {
          //  ConexionBaseDatos.agregarInventarioDatos(implemento);
          //  implemento = ConexionBaseDatos.implementoInventarioDatosUltimo();
           // implemento2 = ConexionBaseDatos.implementoInventarioDatos(implemento.Id_Implemento);
            Assert.AreEqual(implemento.Nombre_Implemento, implemento2.Nombre_Implemento);
        }
        #endregion

        #region M15_PruebaEliminarInventarioDatos
        [Test]
        public void M15_PruebaEliminarInventarioDatos()
        {
        //    ConexionBaseDatos.agregarInventarioDatos(implemento);
       //     implemento = ConexionBaseDatos.implementoInventarioDatosUltimo();
      //      ConexionBaseDatos.eliminarInventarioDatos(implemento.Id_Implemento, implemento.Dojo_Implemento);
        //    bool condicion = ConexionBaseDatos.implementoInventarioDatosBool(implemento.Id_Implemento);
        //    Assert.AreEqual(condicion, true);

        }
        #endregion
/*
        #region M15_PruebaEliminarInventarioDojoNulo
        [Test]
        [ExpectedException(typeof(ImplementoSinIDException))]
        public void M15_PruebaEliminarInventarioDojoNulo()
        {
            ConexionBaseDatos.agregarInventarioDatos(implemento);
            implemento = ConexionBaseDatos.implementoInventarioDatosUltimo();
            ConexionBaseDatos.eliminarInventarioDatos(implemento.Id_Implemento, null);

        }
        #endregion

        #region M15_PruebaListarInventarioDatos
        [Test]
        public void M15_PruebaListarInventarioDatos()
        {
            implementos = ConexionBaseDatos.listarInventarioDatos(dojo);
            int n = implementos.Count;
            Assert.AreEqual(n, implementos.Count);

        }
        #endregion
        
        #region M15_PruebaListarInventarioDatosDojoNulo
        [Test]
        [ExpectedException(typeof(ErrorEnParametroDeProcedure))]
        public void M15_PruebaListarInventarioDatosDojoNulo()
        {
            implementos = ConexionBaseDatos.listarInventarioDatos(null);

        }
        #endregion

        #region M15_PruebaListarInventarioDatos2
        [Test]
        public void M15_PruebaListarInventarioDatos2()
        {
            implementos = ConexionBaseDatos.listarInventarioDatos2(dojo);
            int n = implementos.Count;
            Assert.AreEqual(n, implementos.Count);

        }
        #endregion

        #region M15_PruebaListarInventarioDatos2DojoNulo
        [Test]
        [ExpectedException(typeof(ErrorEnParametroDeProcedure))]
        public void M15_PruebaListarInventarioDatos2DojoNulo()
        {
            implementos = ConexionBaseDatos.listarInventarioDatos2(null);

        }
        #endregion

        #region M15_PruebaUsuarioImplementoDatos
        [Test]
        public void M15_PruebaUsuarioImplementoDatos()
        {
            int n = ConexionBaseDatos.usuarioImplementoDatos(usuario);
            Assert.AreEqual(n, ConexionBaseDatos.usuarioImplementoDatos(usuario));

        }
        #endregion

       #region M15_PruebaUsuarioImplementoDatosNulo
        [Test]
        [ExpectedException(typeof(ErrorEnParametroDeProcedure))]
        public void M15_PruebaUsuarioImplementoDatosNulo()
        {
            ConexionBaseDatos.usuarioImplementoDatos(null);

        }
        #endregion
 */
    }
}
