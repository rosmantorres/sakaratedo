using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using DominioSKD;
using ExcepcionesSKD.Modulo7;
using ExcepcionesSKD;
using LogicaNegociosSKD.Modulo7;
using DatosSKD.Modulo7;


namespace PruebasUnitariasSKD.Modulo7
{
    [TestFixture]
    class M7_PruebasLogicaOrganizacionYDojo
    {
        #region Atributos
        /// <summary>
        /// Atributo que representa el id de la persona o atleta
        /// </summary>
        private int idPersona;
        /// <summary>
        /// Atributo que representa el id de la organizacion
        /// </summary>
        private int idOrganizacion;
        /// <summary>
        /// Atributo que representa el id del dojo
        /// </summary>
        private int idDojo;
        /// <summary>
        /// Atributo que representa la clase LogicaCintas
        /// </summary>
        LogicaOrganizacionYDojo logicaOrgDojo;
        #endregion
        #region SetUp & TearDown
        [SetUp]
        public void Init()
        {
            logicaOrgDojo = new LogicaOrganizacionYDojo();
            idPersona = 6;
            idDojo = 1;
            idOrganizacion = 2;
        }

        [TearDown]
        public void Clean()
        {
            logicaOrgDojo = null;
            idPersona = 0;
            idDojo = 0;
            idOrganizacion = 0;
        }
        #endregion

        #region Test
        /// <summary>
        /// Método para probar que se detalla una organizacion
        /// </summary>
        [Test]
        public void PruebaObtenerDetalleOrganizacion()
        {
            Organizacion organizacion = logicaOrgDojo.obtenerDetalleOrganizacion(idOrganizacion);
            Assert.AreEqual("Clash Cobra-do", organizacion.Nombre);
        }

        /// <summary>
        /// Método para probar la excepcion de número entero invalido de detallar evento
        /// </summary>
        [Test]
        [ExpectedException(typeof(NumeroEnteroInvalidoException))]
        public void DetallarOrganizacionNumeroEnteroException()
        {
            Organizacion organizacion = logicaOrgDojo.obtenerDetalleOrganizacion(-1);
        }

        /// <summary>
        /// Método para probar que se detalla una organizacion
        /// </summary>
        [Test]
        public void PruebaObtenerDetalleDojo()
        {
            Dojo dojo = logicaOrgDojo.obtenerDetalleDojo(idDojo);
            Assert.AreEqual("bushido", dojo.Nombre_dojo);
        }

        /// <summary>
        /// Método para probar la excepcion de número entero invalido de detallar evento
        /// </summary>
        [Test]
        [ExpectedException(typeof(NumeroEnteroInvalidoException))]
        public void DetallarDojoNumeroEnteroException()
        {
            Dojo dojo = logicaOrgDojo.obtenerDetalleDojo(-1);
        }

        /// <summary>
        /// Método para probar que se detalla una organizacion
        /// </summary>
        [Test]
        public void PruebaObtenerDetallePersona()
        {
            Persona persona = logicaOrgDojo.obtenerDetallePersona(idPersona);
            Assert.AreEqual("Maria Isabel", persona.Nombre);
        }

        /// <summary>
        /// Método para probar la excepcion de número entero invalido de detallar evento
        /// </summary>
        [Test]
        [ExpectedException(typeof(NumeroEnteroInvalidoException))]
        public void DetallarPersonaNumeroEnteroException()
        {
            Persona persona = logicaOrgDojo.obtenerDetallePersona(-1);
        }
        #endregion

    }
}
