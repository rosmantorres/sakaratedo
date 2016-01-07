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
    /// Clase que contiene las pruebas unitarias para DaoUbicacion
    /// </summary>
    [TestFixture]
    public class M7_PruebasDAOUbicacion
    {
        #region Atributos
        private Ubicacion idUbicacion;
        private FabricaEntidades fabricaEntidades;
        private FabricaDAOSqlServer fabricaSql;
        private DaoUbicacion baseDeDatosUbicacion;
        #endregion

        #region SetUp & TearDown
        [SetUp]
        public void Init()
        {
            idUbicacion = new Ubicacion();          
            fabricaSql = new FabricaDAOSqlServer();
            baseDeDatosUbicacion = fabricaSql.ObtenerDaoUbicacionM7();
            fabricaEntidades = new FabricaEntidades();//se debe sustituir por fabrica
            idUbicacion.Id = 6;
        }

        [TearDown]
        public void Clean()
        {
            idUbicacion = null;
            fabricaEntidades = null;
            fabricaSql = null;
            baseDeDatosUbicacion = null;
        }
        #endregion

        /// <summary>
        /// Método para probar que se detalla una ubicación en DAO
        /// </summary>
        [Test]
        public void PruebaDetallarUbicacionXId()
        {
            Ubicacion ubicacion = (Ubicacion)baseDeDatosUbicacion.ConsultarXId(idUbicacion);
            Assert.AreEqual("Caracas", ubicacion.Ciudad);
        }

        /// <summary>
        /// Método para probar que la ubicacion no sea nula en DAO
        /// </summary>
        [Test]
        public void PruebaDetallarUbicacionXIdNoNula()
        {
            Ubicacion ubicacion = (Ubicacion)baseDeDatosUbicacion.ConsultarXId(idUbicacion);
            Assert.IsNotNull(ubicacion);
        }

        /// <summary>
        /// Método para probar la exception de número entero invalido de detallar persona en DAO
        /// </summary>
        [Test]
        [ExpectedException(typeof(NumeroEnteroInvalidoException))]
        public void DetallarUbicacionNumeroEnteroException()
        {
            idUbicacion.Id = -1;
            Ubicacion ubicacion = (Ubicacion)baseDeDatosUbicacion.ConsultarXId(idUbicacion);
        }
    }
}
