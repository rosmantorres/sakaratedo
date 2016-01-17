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
    /// Clase que contiene las pruebas unitarias para DaoPersona
    /// </summary>
    [TestFixture]
    public class M7_PruebasDAOPersona
    {
        #region Atributos
        private Persona idPersona;
        private FabricaEntidades fabricaEntidades;
        private FabricaDAOSqlServer fabricaSql;
        private DaoPersona baseDeDatosPersona;
        #endregion

        #region SetUp & TearDown
        /// <summary>
        /// Método que se ejecuta antes de cada prueba
        /// </summary>
        [SetUp]
        public void Init()
        {
            fabricaSql = new FabricaDAOSqlServer();
            baseDeDatosPersona = fabricaSql.ObtenerDaoPersonaM7();
            fabricaEntidades = new FabricaEntidades();
            idPersona = new Persona();//se debe sustituir por fabrica
            idPersona.Id = 6;
        }

        /// <summary>
        /// Método que se ejecuta luego de cada prueba
        /// </summary>
        [TearDown]
        public void Clean()
        {
            idPersona = null;
            fabricaEntidades = null;
            fabricaSql = null;
            baseDeDatosPersona = null;
        }
        #endregion

        /// <summary>
        /// Método para probar que se detalla una Persona en DAO
        /// </summary>
        [Test]
        public void PruebaDetallarPersonaXId()
        {
            Persona persona = (Persona)baseDeDatosPersona.ConsultarXId(idPersona);
            Assert.AreEqual("Maria Isabel", persona.Nombre);
        }

        /// <summary>
        /// Método para probar que la Persona no es nula en DAO
        /// </summary>
        [Test]
        public void PruebaDetallarPersonaXIdNoNulo()
        {
            Persona persona = (Persona)baseDeDatosPersona.ConsultarXId(idPersona);
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
            Persona persona = (Persona)baseDeDatosPersona.ConsultarXId(idPersona);
        }
    }
}
