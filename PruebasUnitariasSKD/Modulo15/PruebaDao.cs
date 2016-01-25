using System;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;
using DominioSKD;
using DominioSKD.Entidades.Modulo15;
using DatosSKD.Fabrica;
using ExcepcionesSKD.Modulo15.ExcepcionDao;
namespace PruebasUnitariasSKD.Modulo15
{
    /// <summary>
    /// Pruebas encargadas de supervisar el correcto funcionamiento de todos los metodos de DAO provenientes del inventario
    /// </summary>
    class PruebaDAO
    {
        private Implemento implemento;
        private Dojo dojo;
        private Dojo dojo2;
        private Implemento implemento2;
        private Implemento implemento3;
        private List<Entidad> lista;
        private List<Entidad> lista2;
        [SetUp]
        public void Init()
        {
            implemento = new Implemento();
            implemento2 = new Implemento();
            implemento3 = new Implemento();
            dojo = new Dojo(1);
            implemento.Nombre_Implemento = "Guantes Karate-DO";
            implemento.Tipo_Implemento = "Guantes";
            implemento.Marca_Implemento = "Adidas";
            implemento.Color_Implemento = "Azul";
            implemento.Talla_Implemento = "S";
            implemento.Estatus_Implemento = "Activo";
            implemento.Precio_Implemento = 1500;
            implemento.Stock_Minimo_Implemento = 5;
            implemento.Cantida_implemento = 20;
            implemento.Dojo_Implemento = dojo;
            implemento.Descripcion_Implemento = "Guantes Wola";
            implemento.Imagen_implemento = "A.jpg";

            implemento3.Nombre_Implemento = "Karategi Karate-DO";
            implemento3.Tipo_Implemento = "Karategi";
            implemento3.Marca_Implemento = "Kombate";
            implemento3.Color_Implemento = "Verde";
            implemento3.Talla_Implemento = "M";
            implemento3.Estatus_Implemento = "Activo";
            implemento3.Precio_Implemento = 1200;
            implemento3.Stock_Minimo_Implemento = 4;
            implemento3.Cantida_implemento = 10;
            implemento3.Dojo_Implemento = dojo;
            implemento3.Descripcion_Implemento = "Karategi Wololo";
            implemento3.Imagen_implemento = "B.jpg";

        }
        [TearDown]
        public void Reset()
        {
            implemento = null;
            implemento2 = null;
            lista = null;
            lista2 = null;
            dojo = null;
        }

        #region M15_PruebaAgregarInventario
        [Test]
        public void M15_PruebaAgregarInventarioDatos()
        {
            FabricaDAOSqlServer.ObtenerDAOImplemento().Agregar(implemento);
            implemento2 = (Implemento)FabricaDAOSqlServer.ObtenerDAOImplemento().implementoInventarioDatosUltimo();
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
        }
        #endregion

        #region M15_PruebaModificarInventario
        [Test]
        public void M15_PruebaModificarInventarioDatos()
        {
            FabricaDAOSqlServer.ObtenerDAOImplemento().Agregar(implemento);
            implemento.Nombre_Implemento = "Carton";
            FabricaDAOSqlServer.ObtenerDAOImplemento().modificarInventarioDatos(implemento);
            Assert.AreEqual(implemento.Nombre_Implemento, "Carton");
            Assert.AreEqual(implemento.Tipo_Implemento, implemento.Tipo_Implemento);
            Assert.AreEqual(implemento.Marca_Implemento, implemento.Marca_Implemento);
            Assert.AreEqual(implemento.Color_Implemento, implemento.Color_Implemento);
            Assert.AreEqual(implemento.Talla_Implemento, implemento.Talla_Implemento);
            Assert.AreEqual(implemento.Precio_Implemento, implemento.Precio_Implemento);
            Assert.AreEqual(implemento.Cantida_implemento, implemento.Cantida_implemento);
            Assert.AreEqual(implemento.Estatus_Implemento, implemento.Estatus_Implemento);
            Assert.AreEqual(implemento.Stock_Minimo_Implemento, implemento.Stock_Minimo_Implemento);
            Assert.AreEqual(implemento.Imagen_implemento, implemento.Imagen_implemento);
        }
        #endregion

        #region M15_PruebaModificarInventarioNulo
        [Test]
        [ExpectedException(typeof(ExcepcionmodificarInventarioDatos))]
        public void M15_PruebaModificarInventarioNulo()
        {
            FabricaDAOSqlServer.ObtenerDAOImplemento().modificarInventarioDatos(null);
        }
        #endregion

        #region M15_PruebaModificarInventarioParametroNulo
        [Test]
        [ExpectedException(typeof(ExcepcionmodificarInventarioDatos))]
        public void M15_PruebaModificarInventarioParametroNulo()
        {
            implemento.Nombre_Implemento = null;
            FabricaDAOSqlServer.ObtenerDAOImplemento().modificarInventarioDatos(implemento);
        }
        #endregion

        #region M15_PruebaModificarInventarioNulo
        [Test]
        [ExpectedException(typeof(ExcepcionmodificarInventarioDatos))]
        public void M15_PruebaModificarInventarioParametroNegativo()
        {
            implemento.Precio_Implemento = -40;
            FabricaDAOSqlServer.ObtenerDAOImplemento().modificarInventarioDatos(implemento);
        }
        #endregion

        #region M15_PruebaEliminarInventario
        [Test]
        public void M15_PruebaEliminarInventarioDatos()
        {
            FabricaDAOSqlServer.ObtenerDAOImplemento().Agregar(implemento3);
            FabricaDAOSqlServer.ObtenerDAOImplemento().eliminarInventarioDatos(implemento3.Id_Implemento, dojo);
            implemento2 = (Implemento)FabricaDAOSqlServer.ObtenerDAOImplemento().implementoInventarioDatosUltimo();
            Assert.AreNotEqual(implemento.Marca_Implemento, implemento2.Marca_Implemento);
            Assert.AreNotEqual(implemento.Color_Implemento, implemento2.Color_Implemento);
            Assert.AreNotEqual(implemento.Talla_Implemento, implemento2.Talla_Implemento);
            Assert.AreNotEqual(implemento.Precio_Implemento, implemento2.Precio_Implemento);
            Assert.AreNotEqual(implemento.Cantida_implemento, implemento2.Cantida_implemento);
            Assert.AreNotEqual("Inactivo", implemento2.Estatus_Implemento);
            Assert.AreNotEqual(implemento.Stock_Minimo_Implemento, implemento2.Stock_Minimo_Implemento);
            Assert.AreNotEqual(implemento.Imagen_implemento, implemento2.Imagen_implemento);
        }
        #endregion

        #region M15_PruebaEliminarInventarioDojoNulo
        [Test]
        [ExpectedException(typeof(ExcepcioneliminarInventarioDatos))]
        public void M15_PruebaEliminarInventarioDojoNulo()
        {
            FabricaDAOSqlServer.ObtenerDAOImplemento().eliminarInventarioDatos(implemento.Id_Implemento, null);
        }
        #endregion

        #region M15_ListarInventarioDatos
        [Test]
        public void M15_ListarInventarioDatos()
        {
            FabricaDAOSqlServer.ObtenerDAOImplemento().Agregar(implemento);
            lista = FabricaDAOSqlServer.ObtenerDAOImplemento().listarInventarioDatos(dojo);
            lista2 = FabricaDAOSqlServer.ObtenerDAOImplemento().listarInventarioDatos(dojo);
            Assert.AreEqual(lista.Count(), lista2.Count());
        }
        #endregion

        #region M15_ListaInventarioDatosNulo
        [Test]
        [ExpectedException(typeof(ExcepcionListarInventarioDatos))]
        public void M15_ListaInventarioDatosNulo()
        {
            FabricaDAOSqlServer.ObtenerDAOImplemento().listarInventarioDatos(null);

        }
        #endregion

        #region M15_ListarInventarioDatos2
        [Test]
        public void M15_ListarInventarioDatos2()
        {
            FabricaDAOSqlServer.ObtenerDAOImplemento().Agregar(implemento);
            lista = FabricaDAOSqlServer.ObtenerDAOImplemento().listarInventarioDatos2(dojo);
            lista2 = FabricaDAOSqlServer.ObtenerDAOImplemento().listarInventarioDatos2(dojo);
            Assert.AreEqual(lista.Count(), lista2.Count());
        }
        #endregion

        #region M15_ListaInventarioDatos2Nulo
        [Test]
        [ExpectedException(typeof(ExcepcionlistaInventarioDatos2))]
        public void M15_ListarInventarioDatos2Nulo()
        {
            FabricaDAOSqlServer.ObtenerDAOImplemento().listarInventarioDatos2(null);

        }
        #endregion

        #region M15_DetallarDojo
        [Test]
        public void M15_DetallarDojo()
        {
            dojo2 = (Dojo)FabricaDAOSqlServer.ObtenerDAOImplemento().DetallarDojo(dojo);
            Assert.AreEqual(dojo.Id_dojo, dojo2.Id_dojo);
        }
        #endregion 

        #region M15_DetallarDojoNulo
        [Test]
        [ExpectedException(typeof(ExcepcionesSKD.ExceptionSKD))]
        public void M15_DetallarDojoNulo()
        {
            dojo = null;
            FabricaDAOSqlServer.ObtenerDAOImplemento().DetallarDojo(dojo);
        }
        #endregion 
    }
}
