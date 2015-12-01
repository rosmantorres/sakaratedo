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
    /// Clase de pruebas para la clase BDPersona
    /// </summary>
    [TestFixture]
    public class M7_PruebasBDPersona
    {
        #region Atributos
        /// <summary>
        /// Atributo que representa el id de la persona
        /// </summary>
        private int idPersona;
        #endregion

        #region SetUp & TearDown
        [SetUp]
        public void Init()
        {
            idPersona = 35;
        }

        [TearDown]
        public void Clean()
        {
            idPersona = 0;
        }
        #endregion

        /// <summary>
        /// Método para probar que se detalla una Persona
        /// </summary>
        [Test]
        public void PruebaDetallarPersonaXId()
        {
            BDPersona baseDeDatosPersona = new BDPersona();
            Persona persona = baseDeDatosPersona.DetallarPersona(idPersona);
            Assert.AreEqual("Carlo", persona.Nombre);
        }

        /// <summary>
        /// Método para probar que la Persona no es nula
        /// </summary>
        [Test]
        public void PruebaDetallarPersonaXIdNoNulo()
        {
            BDPersona baseDeDatosPersona = new BDPersona();
            Persona persona = baseDeDatosPersona.DetallarPersona(idPersona);
            Assert.IsNotNull(persona);
        }
    }
}
