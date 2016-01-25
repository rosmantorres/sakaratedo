using System;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;
using LogicaNegociosSKD.Comandos.Modulo15;
using DominioSKD;
using DominioSKD.Entidades.Modulo15;
using ExcepcionesSKD.Modulo15.ExcepcionComando;
namespace PruebasUnitariasSKD.Modulo15
{
    /// <summary>
    /// Pruebas encargadas de supervisar el correcto funcionamiento de todos los comandos provenientes del inventario
    /// </summary>
    [TestFixture]
    class PruebaComando
    {
        private Implemento implemento;
        private Implemento implemento2;
        private Dojo dojo;
        private Dojo dojo2;
        ComandoAgregarImplemento cai;
        ComandoEliminarImplemento cei;
        ComandoConsultarTodosImplementos ccti;
        ComandoConsultarTodosImplementos2 ccti2;
        ComandoDojoId cdi;
        ComandoImplementoXId cixi;
        ComandoModificarImplemento cmi;
        ComandoUsuarioDojo cud;
        private List<Entidad> lista;
        private List<Entidad> lista2;
        private Usuario usuario;
        [SetUp]
        public void Init()
        {
            cai = new ComandoAgregarImplemento();
            cei = new ComandoEliminarImplemento();
            ccti = new ComandoConsultarTodosImplementos();
            ccti2 = new ComandoConsultarTodosImplementos2();
            cmi = new ComandoModificarImplemento();
            cdi = new ComandoDojoId();
            implemento = new Implemento();
            implemento2 = new Implemento();
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
            cai.LaEntidad = implemento;
            cei.LaEntidad = implemento;
            cei.Dojo = dojo;
            ccti.LaEntidad = dojo;
            ccti2.LaEntidad = dojo;
            cmi.LaEntidad = implemento;
        }
        [TearDown]
        public void Reset()
        {
            implemento = null;
            dojo = null;
            lista = null;
            lista2 = null;
        }

        #region M15_ComandoAgregarImplemento
        [Test]
        public void M15_ComandoAgregarImplemento()
        {
            Assert.True(cai.Ejecutar());

        }
        #endregion

        #region M15_ComandoConsultarTodosImplementos
        [Test]
        public void M15_ComandoConsultarTodosImplementos()
        {
            cai.Ejecutar();
            lista = ccti.Ejecutar();
            lista2 = ccti.Ejecutar();
            Assert.AreEqual(lista.Count(), lista2.Count());
        }
        #endregion

        #region M15_ComandoConsultarTodosImplementosEntidadNulo
        [Test]
        [ExpectedException(typeof(ExcepcionesSKD.ExceptionSKD))]
        public void M15_ComandoConsultarTodosImplementosEntidadNulo()
        {
            ccti.LaEntidad = null;
            ccti.Ejecutar();
            
        }
        #endregion

        #region M15_ComandoConsultarTodosImplementos2
        [Test]
        public void M15_ComandoConsultarTodosImplementos2()
        {
            cai.Ejecutar();
            lista = ccti2.Ejecutar();
            lista2 = ccti2.Ejecutar();
            Assert.AreEqual(lista.Count(), lista2.Count());

        }
        #endregion

        #region M15_ComandoConsultarTodosImplementos2EntidadNulo
        [Test]
        [ExpectedException(typeof(ExcepcionesSKD.ExceptionSKD))]
        public void M15_ComandoConsultarTodosImplementos2EntidadNulo()
        {
            ccti2.LaEntidad = null;
            ccti2.Ejecutar();

        }
        #endregion

        #region M15_ComandoEliminarImplemento
        [Test]
        public void M15_ComandoEliminarImplemento()
        {
            cai.Ejecutar();     
            Assert.True(cei.Ejecutar());
        }
        #endregion

        #region M15_ComandoEliminarImplementoDojoNulo
        [Test]
        [ExpectedException(typeof(ExcepcionesSKD.ExceptionSKD))]
        public void M15_ComandoEliminarImplementoDojoNulo()
        {
            cei.Dojo = null;
            cei.Ejecutar();
        }
        #endregion

        #region M15_ComandoEliminarImplementoEntidadNulo
        [Test]
        [ExpectedException(typeof(NullReferenceException))]
        public void M15_ComandoEliminarImplementoEntidadNulo()
        {
            cei.LaEntidad = null;
            cei.Ejecutar();
        }
        #endregion

        #region M15_ComandoModificarImplemento
        [Test]
        public void M15_ComandoModificarImplemento()
        {
            cai.Ejecutar();
            Assert.True(cmi.Ejecutar());

        }
        #endregion

        #region M15_ComandoModificarImplementoNulo
        [Test]
        [ExpectedException(typeof(ExcepcionesSKD.ExceptionSKD))]
        public void M15_ComandoModificarImplementoNulo()
        {
            cmi.LaEntidad = null;
            cmi.Ejecutar();

        }
        #endregion

        #region M15_ComandoDojoId
        [Test]
        public void M15_ComandoDojoId()
        {
            cdi.LaEntidad= dojo;
            dojo2 = (Dojo)cdi.Ejecutar();
            Assert.AreEqual(dojo.Id_dojo, dojo2.Id_dojo);

        }
        #endregion

        #region M15_ComandoDojoIdNulo
        [Test]
        [ExpectedException(typeof(ExcepcionesSKD.ExceptionSKD))]
        public void M15_ComandoDojoIdNulo()
        {
            cdi.LaEntidad = null;
            cdi.Ejecutar();

        }
        #endregion
    }
}