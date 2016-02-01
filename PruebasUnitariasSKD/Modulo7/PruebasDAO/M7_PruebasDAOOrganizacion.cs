using DatosSKD.DAO.Modulo7;
using DatosSKD.Fabrica;
using DominioSKD;
using DominioSKD.Fabrica;
using ExcepcionesSKD.Modulo7;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DominioSKD.Entidades.Modulo7;

namespace PruebasUnitariasSKD.Modulo7.PruebasDAO
{
    /// <summary>
    /// Clase que contiene las pruebas unitarias para DaoOrganizacion
    /// </summary>
    [TestFixture]
    public class M7_PruebasDAOOrganizacion
    {
        #region Atributos
        private OrganizacionM7 idOrganizacion;
        private DaoOrganizacion baseDeDatosOrganizacion;
        #endregion

        #region SetUp & TearDown
        /// <summary>
        /// Método que se ejecuta antes de cada prueba
        /// </summary>
        [SetUp]
        public void Init()
        {
            baseDeDatosOrganizacion = FabricaDAOSqlServer.ObtenerDaoOrganizacionM7();
            idOrganizacion = (OrganizacionM7)FabricaEntidades.ObtenerOrganizacionM7();
            idOrganizacion.Id = 1;
        }

        /// <summary>
        /// Método que se ejecuta luego de cada prueba
        /// </summary>
        [TearDown]
        public void Clean()
        {
            idOrganizacion = null;
            baseDeDatosOrganizacion = null;
        }
        #endregion

        /// <summary>
        /// Método para probar que se detalla una organizacion en DAO
        /// </summary>
        [Test]
        public void PruebaDetallarOrganizacionXId()
        {
            OrganizacionM7 organizacion = (OrganizacionM7)baseDeDatosOrganizacion.ConsultarXId(idOrganizacion);
            Assert.AreEqual("Seito Karate-do", organizacion.Nombre);
        }

        /// <summary>
        /// Método para probar que la organizacion no es nula en DAO
        /// </summary>
        [Test]
        public void PruebaDetallarOrganizacionXIdNoNulo()
        {
            OrganizacionM7 organizacion = (OrganizacionM7)baseDeDatosOrganizacion.ConsultarXId(idOrganizacion);
            Assert.IsNotNull(organizacion);
        }

        /// <summary>
        /// Método para probar la exception de número entero invalido de detallar organizacion en DAO
        /// </summary>
        [Test]
        [ExpectedException(typeof(NumeroEnteroInvalidoException))]
        public void DetallarOrganizacionNumeroEnteroException()
        {
            idOrganizacion.Id = -1;
            OrganizacionM7 organizacion = (OrganizacionM7)baseDeDatosOrganizacion.ConsultarXId(idOrganizacion);
        }
    }
}
