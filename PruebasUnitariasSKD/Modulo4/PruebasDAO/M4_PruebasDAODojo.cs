using DatosSKD.DAO.Modulo4;
using DatosSKD.Fabrica;
using DominioSKD;
using DominioSKD.Fabrica;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DominioSKD.Entidades.Modulo4;
using DatosSKD.InterfazDAO.Modulo4;

namespace PruebasUnitariasSKD.Modulo4.PruebasDAO
{
    /// <summary>
    /// Clase que contiene las pruebas unitarias para DaoDojo
    /// </summary>
    [TestFixture]
    public class M4_PruebasDAODojo
    {
        #region Atributos
        private DojoM4 idDojo;
        private IDaoDojo baseDeDatosDojo;
        #endregion

        #region SetUp & TearDown
        /// <summary>
        /// Método que se ejecuta antes de cada prueba
        /// </summary>
        [SetUp]
        public void Init()
        {
            baseDeDatosDojo = FabricaDAOSqlServer.ObtenerDAODojo();
            idDojo = (DojoM4)FabricaEntidades.ObtenerDojo_M4();
            idDojo.Id = 1;
        }

        /// <summary>
        /// Método que se ejecuta luego de cada prueba
        /// </summary>
        [TearDown]
        public void Clean()
        {
            idDojo = null;
            baseDeDatosDojo = null;
        }
        #endregion

        /// <summary>
        /// Método para probar que se detalla un dojo en DAO
        /// </summary>
        [Test]
        public void PruebaDetallarDojoXId()
        {
            DojoM4 dojo = (DojoM4)baseDeDatosDojo.ConsultarXId(idDojo);
            Assert.AreEqual("bushido", dojo.Nombre_dojo);
        }

        /// <summary>
        /// Método para probar que el dojo no es nulo en DAO
        /// </summary>
        [Test]
        public void PruebaDetallarDojoXIdNoNulo()
        {
            DojoM4 dojo = (DojoM4)baseDeDatosDojo.ConsultarXId(idDojo);
            Assert.IsNotNull(dojo);
        }


        /// Método de prueba para consultar todos los Dojos  en DAO
        /// </summary>
        [Test]
        public void PruebaConsultarTodoslosDojosDAO()
        {


            List<Entidad> listaDojos = baseDeDatosDojo.ConsultarTodos();
            Assert.GreaterOrEqual(listaDojos.Count, 0);
        }

        /// <summary>
        /// Método para probar que la lista obtenida de dojos sea distinto de  nulo 
        /// </summary>
        [Test]
        public void PruebaConsultarTodosLosDojos()
        {

            List<Entidad> listaDojos = baseDeDatosDojo.ConsultarTodos();
            Assert.NotNull(listaDojos);
        }

        /// Método de prueba para consultar todos los Dojos  en DAO
        /// </summary>
        [Test]
        public void PruebaConsultarTodosOrganizacionDAO()
        {


            List<Entidad> listaDojos = baseDeDatosDojo.ConsultarTodosOrganizacion(idDojo);
            Assert.GreaterOrEqual(listaDojos.Count, 0);
        }

        /// <summary>
        /// Método para probar que la lista obtenida de dojos sea distinto de  nulo 
        /// </summary>
        [Test]
        public void PruebaConsultarTodosOrganizacion()
        {

            List<Entidad> listaDojos = baseDeDatosDojo.ConsultarTodosOrganizacion(idDojo);
            Assert.NotNull(listaDojos);
        }

        [Test]
        public void PruebaAgregarDojo()
        {
            DojoM4 elDojo = (DojoM4)FabricaEntidades.ObtenerDojo_M4();
            Organizacion org = (Organizacion)FabricaEntidades.ObtenerOrganizacion_M4();
            Ubicacion ubi = (Ubicacion)FabricaEntidades.ObtenerUbicacion_M4();

            org.Id = 35;
            elDojo.Organizacion = org;
            elDojo.Logo_dojo = "Kaizen.jpg";
            elDojo.Rif_dojo = "J-124002790";
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
            Assert.IsTrue(baseDeDatosDojo.Agregar(elDojo));
        }
        [Test]
        public void PruebaModificarDojo()
        {
            DojoM4 elDojo = (DojoM4)FabricaEntidades.ObtenerDojo_M4();
            Ubicacion ubi = (Ubicacion)FabricaEntidades.ObtenerUbicacion_M4();

            elDojo.Id = 5010;
            elDojo.Logo_dojo = "Kaizen.jpg";
            elDojo.Rif_dojo = "J-124332790";
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
            Assert.IsTrue(baseDeDatosDojo.Modificar(elDojo));
        }
        [Test]
        public void PruebaEliminarDojo()
        {
            DojoM4 elDojo = (DojoM4)FabricaEntidades.ObtenerDojo_M4();
            elDojo.Id = 12;
            Assert.IsTrue(baseDeDatosDojo.EliminarDojo(elDojo));

        }
    }
}
