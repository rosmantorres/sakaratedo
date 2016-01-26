using DominioSKD;
using DominioSKD.Fabrica;
using ExcepcionesSKD.Modulo7;
using LogicaNegociosSKD.Comandos.Modulo7;
using LogicaNegociosSKD.Fabrica;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DominioSKD.Entidades.Modulo7;

namespace PruebasUnitariasSKD.Modulo7.PruebasComando
{
    /// <summary>
    /// Clase que contiene las pruebas unitarias para el comando consultar perfil de atleta
    /// </summary>
    [TestFixture]
    class M7_PruebasComandoConsultarPerfil
    {
        #region Atributos
        private PersonaM7 idPersona;
        private FabricaComandos fabricaComandos;
        private ComandoConsultarPerfil perfil;
        #endregion

        #region SetUp & TearDown
        /// <summary>
        /// Método que se ejecuta antes de cada prueba
        /// </summary>
        [SetUp]
        public void Init()
        {
            fabricaComandos = new FabricaComandos();
            perfil = (ComandoConsultarPerfil)fabricaComandos.ObtenerComandoConsultarPerfil();
            idPersona = (PersonaM7)FabricaEntidades.ObtenerPersonaM7();
            idPersona.Id = 6;
            perfil.LaEntidad = idPersona;
        }

        /// <summary>
        /// Método que se ejecuta luego de cada prueba
        /// </summary>
        [TearDown]
        public void Clean()
        {
            fabricaComandos = null;
            perfil = null;
            idPersona = null;
        }
        #endregion

        #region Test
        /// <summary>
        /// Método para probar que la tupla obtenida no es nula en eventos asistidos
        /// </summary>
        [Test]
        public void PruebaObtenerTuplaPerfil()
        {
            Tuple<Entidad, Entidad, Entidad, Entidad, String, Entidad> tupla = perfil.Ejecutar();
            Assert.IsNotNull(tupla);
        }

        /// <summary>
        /// Método para probar la excepcion de número entero invalido en obtener perfil
        [Test]
        [ExpectedException(typeof(NumeroEnteroInvalidoException))]
        public void PerfilNumeroEnteroException()
        {
            idPersona.Id = -1;
            Tuple<Entidad, Entidad, Entidad, Entidad, String, Entidad> tupla = perfil.Ejecutar();
        }

        /// <summary>
        /// Método para probar que la persona obtenida no esta vacia
        /// </summary>
        [Test]
        public void PruebaObtenerPerfil()
        {
            Tuple<Entidad, Entidad, Entidad, Entidad, String, Entidad> tupla = perfil.Ejecutar();
            PersonaM7 persona = (PersonaM7)tupla.Item1;
            Assert.GreaterOrEqual("Maria Isabel", persona.Nombre);
        }

        /// <summary>
        /// Método para probar que el dojo obtenido no esta vacio
        /// </summary>
        [Test]
        public void PruebaObtenerDojo()
        {
            Tuple<Entidad, Entidad, Entidad, Entidad, String, Entidad> tupla = perfil.Ejecutar();
            DojoM7 dojo = (DojoM7)tupla.Item2;
            Assert.GreaterOrEqual("Dai-Fu", dojo.Nombre_dojo);
        }

        /// <summary>
        /// Método para probar que la ubicacion de dojo obtenida no esta vacio
        /// </summary>
        [Test]
        public void PruebaObtenerUbicacionDojo()
        {
            Tuple<Entidad, Entidad, Entidad, Entidad, String, Entidad> tupla = perfil.Ejecutar();
            UbicacionM7 ubicacionDojo = (UbicacionM7)tupla.Item3;
            Assert.GreaterOrEqual("Maracay",ubicacionDojo.Ciudad);
        }

        /// <summary>
        /// Método para probar que la organizacion obtenida no esta vacia
        /// </summary>
        [Test]
        public void PruebaObtenerOrganizacion()
        {
            Tuple<Entidad, Entidad, Entidad, Entidad, String, Entidad> tupla = perfil.Ejecutar();
            OrganizacionM7 organizacion = (OrganizacionM7)tupla.Item4;
            Assert.GreaterOrEqual("Shotokan Org", organizacion.Nombre);
        }

        /// <summary>
        /// Método para probar que la ubicacion de Organizacion obtenida no esta vacio
        /// </summary>
        [Test]
        public void PruebaObtenerUbicacionOrganizacion()
        {
            Tuple<Entidad, Entidad, Entidad, Entidad, String, Entidad> tupla = perfil.Ejecutar();
            String ubicacionOrganizacion = tupla.Item5;
            Assert.GreaterOrEqual("Av 8, calle 8 local numero 12", ubicacionOrganizacion);
        }

        /// <summary>
        /// Método para probar que la ultima cinta obtenida no esta vacio
        /// </summary>
        [Test]
        public void PruebaObtenerUltimaCinta()
        {
            Tuple<Entidad, Entidad, Entidad, Entidad, String, Entidad> tupla = perfil.Ejecutar();
            CintaM7 ultimaCinta = (CintaM7)tupla.Item6;
            Assert.GreaterOrEqual("Amarillo", ultimaCinta.Color_nombre);
        }
        #endregion
    }
}
