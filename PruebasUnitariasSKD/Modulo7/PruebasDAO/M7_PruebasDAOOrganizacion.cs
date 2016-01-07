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

namespace PruebasUnitariasSKD.Modulo7.PruebasDAO
{
    /// <summary>
    /// Clase que contiene las pruebas unitarias para DaoOrganizacion
    /// </summary>
    [TestFixture]
    public class M7_PruebasDAOOrganizacion
    {
        #region Atributos
        private Organizacion idOrganizacion;
        private FabricaEntidades fabricaEntidades;
        private FabricaDAOSqlServer fabricaSql;
        private DaoOrganizacion baseDeDatosOrganizacion;
        #endregion

        #region SetUp & TearDown
        [SetUp]
        public void Init()
        {
            fabricaSql = new FabricaDAOSqlServer();
            baseDeDatosOrganizacion = fabricaSql.ObtenerDaoOrganizacionM7();
            fabricaEntidades = new FabricaEntidades();
            idOrganizacion = new Organizacion();//se debe sustituir por fabrica
            idOrganizacion.Id = 1;
        }

        [TearDown]
        public void Clean()
        {
            idOrganizacion = null;
            fabricaEntidades = null;
            fabricaSql = null;
            baseDeDatosOrganizacion = null;
        }
        #endregion

        /// <summary>
        /// Método para probar que se detalla una organizacion en DAO
        /// </summary>
        [Test]
        public void PruebaDetallarOrganizacionXId()
        {
            Organizacion organizacion = (Organizacion)baseDeDatosOrganizacion.ConsultarXId(idOrganizacion);
            Assert.AreEqual("Seito Karate-do", organizacion.Nombre);
        }

        /// <summary>
        /// Método para probar que la organizacion no es nula en DAO
        /// </summary>
        [Test]
        public void PruebaDetallarOrganizacionXIdNoNulo()
        {
            Organizacion organizacion = (Organizacion)baseDeDatosOrganizacion.ConsultarXId(idOrganizacion);
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
            Organizacion organizacion = (Organizacion)baseDeDatosOrganizacion.ConsultarXId(idOrganizacion);
        }
    }
}
