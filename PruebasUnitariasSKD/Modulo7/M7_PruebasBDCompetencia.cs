using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using DominioSKD;
using DatosSKD;
using DatosSKD.Modulo7;

namespace PruebasUnitariasSKD.Modulo7
{
    /// <summary>
    /// Clase de prueba para la clase BDCompetencia
    /// </summary>
    [TestFixture]
    public class M7_PruebasBDCompetencia
    {
        #region Atributos
        /// <summary>
        /// Atributo que representa el id de la competencia
        /// </summary>
        private int idCompetencia;
        #endregion

        #region SetUp & TearDown
        [SetUp]
        public void Init()
        {
            idCompetencia = 8;
        }

        [TearDown]
        public void Clean()
        {
            idCompetencia = 0;
        }
        #endregion

        /// <summary>
        /// Método para probar que se detalla una competencia
        /// </summary>
        [Test]
        public void PruebaDetallarHorarioXId()
        {
            BDCompetencia baseDeDatosCompetencia = new BDCompetencia();
            Competencia competencia = baseDeDatosCompetencia.DetallarCompetencia(idCompetencia);
            Assert.AreEqual("Shoosei Kai", competencia.Nombre);
        }

        /// <summary>
        /// Método para probar que la competencia no es nula
        /// </summary>
        [Test]
        public void PruebaDetallarHorarioXIdNoNulo()
        {
            BDCompetencia baseDeDatosCompetencia = new BDCompetencia();
            Competencia competencia = baseDeDatosCompetencia.DetallarCompetencia(idCompetencia);
            Assert.IsNotNull(competencia);
        }
    }
}
