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
    /// Clase que contiene las pruebas unitarias para DaoCompetencia
    /// </summary>
    [TestFixture]
    public class M7_PruebasDAOCompetencia
    {
        #region Atributos
        private CompetenciaM7 idCompetencia;
        private DaoCompetencia baseDeDatosCompetencia;
        #endregion

        #region SetUp & TearDown
        /// <summary>
        /// Método que se ejecuta antes de cada prueba
        /// </summary>
        [SetUp]
        public void Init()
        {
            baseDeDatosCompetencia = FabricaDAOSqlServer.ObtenerDaoCompetenciaM7();
            idCompetencia = (CompetenciaM7)FabricaEntidades.ObtenerCompetenciaM7();
            idCompetencia.Id = 8;
        }

        /// <summary>
        /// Método que se ejecuta luego de cada prueba
        /// </summary>
        [TearDown]
        public void Clean()
        {
            idCompetencia = null;
            baseDeDatosCompetencia = null;
        }
        #endregion

        /// <summary>
        /// Método para probar que se detalla una competencia en DAO
        /// </summary>
        [Test]
        public void PruebaDetallarCompetenciaXId()
        {
            CompetenciaM7 competencia = (CompetenciaM7)baseDeDatosCompetencia.ConsultarXId(idCompetencia);
            Assert.AreEqual("Shoosei Kai", competencia.Nombre);
        }

        /// <summary>
        /// Método para probar que la competencia no es nula en DAO
        /// </summary>
        [Test]
        public void PruebaDetallarCompetenciaXIdNoNulo()
        {
            CompetenciaM7 competencia = (CompetenciaM7)baseDeDatosCompetencia.ConsultarXId(idCompetencia);
            Assert.IsNotNull(competencia);
        }

        /// <summary>
        /// Método para probar la exception de número entero invalido de prueba detallar competencia en DAO
        /// </summary>

        [Test]
        [ExpectedException(typeof(NumeroEnteroInvalidoException))]
        public void DetalleCompetenciaNumeroEnteroException()
        {
            idCompetencia.Id = -1;
            baseDeDatosCompetencia.ConsultarXId(idCompetencia);
        }
    }
}
