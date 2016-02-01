using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using DominioSKD.Entidades.Modulo4;
using DominioSKD.Fabrica;
using LogicaNegociosSKD;
using LogicaNegociosSKD.Fabrica;
using DominioSKD;

namespace PruebasUnitariasSKD.Modulo4.PruebasComando
{
    /// <summary>
    /// Clase que contiene las pruebas unitarias para ComandoDOjo
    /// </summary>
    [TestFixture]
    public class M4_PruebasComandoDojo
    {
        #region Atributos
        private DojoM4 elDojo;
        #endregion

        #region SetUp & TearDown
        /// <summary>
        /// Método que se ejecuta antes de cada prueba
        /// </summary>
        [SetUp]
        public void Init()
        {
            elDojo = (DojoM4)FabricaEntidades.ObtenerDojo_M4();
            elDojo.Id = 1;
        }

        /// <summary>
        /// Método que se ejecuta luego de cada prueba
        /// </summary>
        [TearDown]
        public void Clean()
        {
            elDojo = null;
        }
        #endregion

        /// <summary>
        /// Método  para probar que el Dojo existe en ComandoDetallarDojo
        /// </summary>
        [Test]
        public void PruebaDetallarDojoXId()
        {
            Comando<Entidad> detallarDojo = FabricaComandos.CrearComandoDetallarDojo();
            detallarDojo.LaEntidad = elDojo;
            DojoM4 dojo = (DojoM4)detallarDojo.Ejecutar();
            Assert.AreEqual("bushido", dojo.Nombre_dojo);
        }

        /// <summary>
        /// Método para probar que el dojo no es nulo en ComandoDetallarDojo
        /// </summary>
        [Test]
        public void PruebaDetallarDojoXIdNoNulo()
        {
            Comando<Entidad> detallarDojo = FabricaComandos.CrearComandoDetallarDojo();
            detallarDojo.LaEntidad = elDojo;
            DojoM4 dojo = (DojoM4)detallarDojo.Ejecutar();
            Assert.IsNotNull(dojo);
        }

        /// <summary>
        /// Método de prueba para consultar todos los Dojos  en ComandoListarDojo
        /// </summary>
        [Test]
        public void PruebaConsultarTodoslosDojosCom()
        {
            Comando<List<Entidad>> laListaDojo = FabricaComandos.CrearComandoListarDojos();
            List<Entidad> laLista = FabricaEntidades.ObtenerListaEntidad_M4();
            laLista = laListaDojo.Ejecutar();
            Assert.GreaterOrEqual(laLista.Count, 0);
        }

        /// <summary>
        /// Método para probar que la lista obtenida de dojos sea distinto de  nulo 
        /// </summary>
        [Test]
        public void PruebaConsultarTodosLosDojos()
        {
            Comando<List<Entidad>> laListaDojo = FabricaComandos.CrearComandoListarDojos();
            List<Entidad> laLista = FabricaEntidades.ObtenerListaEntidad_M4();
            laLista = laListaDojo.Ejecutar();
            Assert.NotNull(laLista);
        }

        /// Método de prueba para consultar todos los Dojos  en Comando
        /// </summary>
        [Test]
        public void PruebaConsultarTodosOrganizacionCom()
        {
            Comando<List<Entidad>> laListaDojo = FabricaComandos.CrearComandoListarDojos();
            laListaDojo.LaEntidad = FabricaEntidades.ObtenerDojo_M4();
            laListaDojo.LaEntidad.Id = 1;
            List<Entidad> laLista = FabricaEntidades.ObtenerListaEntidad_M4();
            laLista = laListaDojo.Ejecutar();
            Assert.GreaterOrEqual(laLista.Count, 0);
        }

        /// <summary>
        /// Método para probar que la lista obtenida de dojos sea distinto de  nulo 
        /// </summary>
        [Test]
        public void PruebaConsultarTodosOrganizacionNotNull()
        {
            Comando<List<Entidad>> laListaDojo = FabricaComandos.CrearComandoListarDojos();
            laListaDojo.LaEntidad = FabricaEntidades.ObtenerDojo_M4();
            laListaDojo.LaEntidad.Id = 1;
            List<Entidad> laLista = FabricaEntidades.ObtenerListaEntidad_M4();
            laLista = laListaDojo.Ejecutar();
            Assert.NotNull(laLista);
        }
        /// <summary>
        /// Método para probar que se Agrega Un Dojo 
        /// </summary>
        [Test]
        public void PruebaComandoAgregarDojoTrue()
        {
            Organizacion org = (Organizacion)FabricaEntidades.ObtenerOrganizacion_M4();
            Ubicacion ubi = (Ubicacion)FabricaEntidades.ObtenerUbicacion_M4();

            org.Id = 35;
            elDojo.Organizacion = org;
            elDojo.Logo_dojo = "Kaizen.jpg";
            elDojo.Rif_dojo = "J-112322790";
            elDojo.Nombre_dojo = "zenDo 6";
            elDojo.Telefono_dojo = 2126634892;
            elDojo.Email_dojo = "zendo6@gmail.com";
            ubi.Latitud = "10.23456";
            ubi.Longitud = "-2.7890";
            ubi.Ciudad = "Caracas";
            ubi.Estado = "Distrito Capital";
            ubi.Direccion = "La Candelaria";
            elDojo.Ubicacion = ubi;
            elDojo.Status_dojo = true;
            Comando<bool> agregarDojo = FabricaComandos.CrearComandoAgregarDojo();
            agregarDojo.LaEntidad = elDojo;
            Assert.IsTrue(agregarDojo.Ejecutar());
        }
        /// <summary>
        /// Método para probrar que se modifica un Dojo
        /// </summary>
        [Test]
        public void PruebaComandoModificarDojoTrue()
        {
            Ubicacion ubi = (Ubicacion)FabricaEntidades.ObtenerUbicacion_M4();

            elDojo.Id = 10;
            elDojo.Logo_dojo = "Kaizen.jpg";
            elDojo.Rif_dojo = "J-124772790";
            elDojo.Nombre_dojo = "KaizenDo 2";
            elDojo.Telefono_dojo = 2126774892;
            elDojo.Email_dojo = "kaizendo2@gmail.com";
            ubi.Latitud = "10.23456";
            ubi.Longitud = "-2.7890";
            ubi.Ciudad = "Caracas";
            ubi.Estado = "Distrito Capital";
            ubi.Direccion = "La Candelaria";
            elDojo.Ubicacion = ubi;
            elDojo.Status_dojo = true;
            Comando<bool> modificarDojo = FabricaComandos.CrearComandoModificarDojo();
            modificarDojo.LaEntidad = elDojo;
            Assert.IsTrue(modificarDojo.Ejecutar());
        }
        /// <summary>
        /// Método para probar que se elimina un Dojo
        /// </summary>
        [Test]
        public void PruebaEliminarDojo()
        {
            DojoM4 elDojo = (DojoM4)FabricaEntidades.ObtenerDojo_M4();
            elDojo.Id = 1012;
            Comando<bool> eliminarDojo = FabricaComandos.CrearComandoEliminarDojo();
            eliminarDojo.LaEntidad = elDojo;
            Assert.IsTrue(eliminarDojo.Ejecutar());

        }

        
    }

}
