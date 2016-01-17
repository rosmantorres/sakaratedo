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

namespace PruebasUnitariasSKD.Modulo7.PruebasComando
{
    [TestFixture]
    class M7_PruebasComandoConsultarPerfil
    {
        #region Atributos
        private Persona idPersona;
        private FabricaComandos fabricaComandos;
        private ComandoConsultarPerfil perfil;
        private FabricaEntidades fabricaEntidades;
        #endregion

        #region SetUp & TearDown
        [SetUp]
        public void Init()
        {
            fabricaComandos = new FabricaComandos();
            perfil = (ComandoConsultarPerfil)fabricaComandos.ObtenerComandoConsultarPerfil();
            fabricaEntidades = new FabricaEntidades();
            idPersona = new Persona();//cambiar por fabrica
            idPersona.Id = 6;
            perfil.LaEntidad = idPersona;
        }

        [TearDown]
        public void Clean()
        {
            fabricaComandos = null;
            perfil = null;
            fabricaEntidades = null;
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
            Persona persona = (Persona)tupla.Item1;
            Assert.GreaterOrEqual("Maria Isabel", persona.Nombre);
        }

        /// <summary>
        /// Método para probar que el dojo obtenido no esta vacio
        /// </summary>
        [Test]
        public void PruebaObtenerDojo()
        {
            Tuple<Entidad, Entidad, Entidad, Entidad, String, Entidad> tupla = perfil.Ejecutar();
            Dojo dojo = (Dojo)tupla.Item2;
            Assert.GreaterOrEqual("Dai-Fu", dojo.Nombre_dojo);
        }

        /// <summary>
        /// Método para probar que la ubicacion de dojo obtenida no esta vacio
        /// </summary>
        [Test]
        public void PruebaObtenerUbicacionDojo()
        {
            Tuple<Entidad, Entidad, Entidad, Entidad, String, Entidad> tupla = perfil.Ejecutar();
            Ubicacion ubicacionDojo = (Ubicacion)tupla.Item3;
            Assert.GreaterOrEqual("Maracay",ubicacionDojo.Ciudad);
        }

        /// <summary>
        /// Método para probar que la organizacion obtenida no esta vacia
        /// </summary>
        [Test]
        public void PruebaObtenerOrganizacion()
        {
            Tuple<Entidad, Entidad, Entidad, Entidad, String, Entidad> tupla = perfil.Ejecutar();
            Organizacion organizacion = (Organizacion)tupla.Item4;
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
            Cinta ultimaCinta = (Cinta)tupla.Item6;
            Assert.GreaterOrEqual("Amarillo", ultimaCinta.Color_nombre);
        }
        #endregion
    }
}
