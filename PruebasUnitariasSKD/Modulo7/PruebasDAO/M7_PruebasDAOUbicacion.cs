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
    /// Clase que contiene las pruebas unitarias para DaoUbicacion
    /// </summary>
    [TestFixture]
    public class M7_PruebasDAOUbicacion
    {
        #region Atributos
        private UbicacionM7 idUbicacion;
        private DaoUbicacion baseDeDatosUbicacion;
        #endregion

        #region SetUp & TearDown
        /// <summary>
        /// Método que se ejecuta antes de cada prueba
        /// </summary>
        [SetUp]
        public void Init()
        {
            idUbicacion = (UbicacionM7)FabricaEntidades.ObtenerUbicacionM7();        
            baseDeDatosUbicacion = FabricaDAOSqlServer.ObtenerDaoUbicacionM7();
            idUbicacion.Id = 6;
        }

        /// <summary>
        /// Método que se ejecuta luego de cada prueba
        /// </summary>
        [TearDown]
        public void Clean()
        {
            idUbicacion = null;
            baseDeDatosUbicacion = null;
        }
        #endregion

        /// <summary>
        /// Método para probar que se detalla una ubicación en DAO
        /// </summary>
        [Test]
        public void PruebaDetallarUbicacionXId()
        {
            UbicacionM7 ubicacion = (UbicacionM7)baseDeDatosUbicacion.ConsultarXId(idUbicacion);
            Assert.AreEqual("Caracas", ubicacion.Ciudad);
        }

        /// <summary>
        /// Método para probar que la ubicacion no sea nula en DAO
        /// </summary>
        [Test]
        public void PruebaDetallarUbicacionXIdNoNula()
        {
            UbicacionM7 ubicacion = (UbicacionM7)baseDeDatosUbicacion.ConsultarXId(idUbicacion);
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
            UbicacionM7 ubicacion = (UbicacionM7)baseDeDatosUbicacion.ConsultarXId(idUbicacion);
        }
    }
}
