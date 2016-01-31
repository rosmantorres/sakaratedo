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
    /// Clase que contiene las pruebas unitarias para DaoPersona
    /// </summary>
    [TestFixture]
    public class M7_PruebasDAOPersona
    {
        #region Atributos
        private PersonaM7 idPersona;
        private DaoPersona baseDeDatosPersona;
        #endregion

        #region SetUp & TearDown
        /// <summary>
        /// Método que se ejecuta antes de cada prueba
        /// </summary>
        [SetUp]
        public void Init()
        {
            baseDeDatosPersona = FabricaDAOSqlServer.ObtenerDaoPersonaM7();
            idPersona = (PersonaM7)FabricaEntidades.ObtenerPersonaM7();
            idPersona.Id = 6;
        }

        /// <summary>
        /// Método que se ejecuta luego de cada prueba
        /// </summary>
        [TearDown]
        public void Clean()
        {
            idPersona = null;
            baseDeDatosPersona = null;
        }
        #endregion

        /// <summary>
        /// Método para probar que se detalla una Persona en DAO
        /// </summary>
        [Test]
        public void PruebaDetallarPersonaXId()
        {
            PersonaM7 persona = (PersonaM7)baseDeDatosPersona.ConsultarXId(idPersona);
            Assert.AreEqual("Maria Isabel", persona.Nombre);
        }

        /// <summary>
        /// Método para probar que la Persona no es nula en DAO
        /// </summary>
        [Test]
        public void PruebaDetallarPersonaXIdNoNulo()
        {
            PersonaM7 persona = (PersonaM7)baseDeDatosPersona.ConsultarXId(idPersona);
            Assert.IsNotNull(persona);
        }

        /// <summary>
        /// Método para probar la exception de número entero invalido de detallar persona en DAO
        /// </summary>
        [Test]
        [ExpectedException(typeof(NumeroEnteroInvalidoException))]
        public void DetallarPersonaNumeroEnteroException()
        {
            idPersona.Id = -1;
            PersonaM7 persona = (PersonaM7)baseDeDatosPersona.ConsultarXId(idPersona);
        }
    }
}
