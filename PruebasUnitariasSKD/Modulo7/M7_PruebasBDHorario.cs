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
    /// Clase de pruebas para la clase BDHorario
    /// </summary>
    ///
    [TestFixture]
    public class M7_PruebasBDHorario
    {
        #region Atributos
        /// <summary>
        /// Atributo que representa el id del horario
        /// </summary>
        private int idHorario;
        #endregion

        #region SetUp & TearDown
        [SetUp]
        public void Init()
        {
            idHorario = 6;
        }

        [TearDown]
        public void Clean()
        {
            idHorario = 0;
        }
        #endregion

        /// <summary>
        /// Método para probar que se detalla un horario
        /// </summary>
        [Test]
        public void PruebaDetallarHorarioXId()
        {
            BDHorario baseDeDatosHorario = new BDHorario();
            Horario horario = baseDeDatosHorario.DetallarHorario(idHorario);
            Assert.AreEqual("03/10/2015", horario.FechaFin.ToString("MM/dd/yyyy"));
        }

        /// <summary>
        /// Método para probar que el horario no es nulo
        /// </summary>
        [Test]
        public void PruebaDetallarHorarioXIdNoNulo()
        {
            BDHorario baseDeDatosHorario = new BDHorario();
            Horario horario = baseDeDatosHorario.DetallarHorario(idHorario);
            Assert.IsNotNull(horario);
        }
    }
}
