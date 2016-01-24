using DominioSKD;
using DominioSKD.Fabrica;
using ExcepcionesSKD.Modulo7;
using LogicaNegociosSKD.Comandos.Modulo7;
using LogicaNegociosSKD.Fabrica;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using DominioSKD.Entidades.Modulo7;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebasUnitariasSKD.Modulo7.PruebasComando
{
    /// <summary>
    /// Clase que contiene las pruebas unitarias para el comando listar cintas de atleta
    /// </summary>
    [TestFixture]
    public class M7_PruebasComandoListarCintas
    {
        #region Atributos
        private PersonaM7 idPersona;
        private FabricaComandos fabricaComandos;
        private ComandoConsultarListaCinta cintas;
        #endregion

        #region SetUp & TearDown
        /// <summary>
        /// Método que se ejecuta antes de cada prueba
        /// </summary>
        [SetUp]
        public void Init()
        {
            fabricaComandos = new FabricaComandos();
            cintas = (ComandoConsultarListaCinta)fabricaComandos.ObtenerComandoConsultarListaCinta();
            idPersona = (PersonaM7)FabricaEntidades.ObtenerPersonaM7();
            idPersona.Id = 6;
            cintas.LaEntidad = idPersona;
        }

        /// <summary>
        /// Método que se ejecuta luego de cada prueba
        /// </summary>
        [TearDown]
        public void Clean()
        {
            fabricaComandos = null;
            cintas = null;
            idPersona = null;
        }
        #endregion

        #region Test
        /// <summary>
        /// Método para probar que la tupla obtenida no es nula en cintas obtenidas
        /// </summary>
        [Test]
        public void PruebaObtenerTuplaCintasObtenidas()
        {
            Tuple<List<Entidad>, List<DateTime>> tupla = cintas.Ejecutar();
            Assert.IsNotNull(tupla);
        }

        /// <summary>
        /// Método para probar la excepcion de número entero invalido en obtener lista cintas obtenidas
        /// </summary>
        [Test]
        [ExpectedException(typeof(NumeroEnteroInvalidoException))]
        public void ListaCintasNumeroEnteroException()
        {
            idPersona.Id = -1;
            Tuple<List<Entidad>, List<DateTime>> tupla = cintas.Ejecutar();
        }

        /// <summary>
        /// Método para probar que la lista obtenida de cintas puede tener uno o mas cintas
        /// </summary>
        [Test]
        public void PruebaObtenerListaCintasObtenidas()
        {
            Tuple<List<Entidad>, List<DateTime>> tupla = cintas.Ejecutar();
            List<Entidad> listaCintas = tupla.Item1;
            Assert.GreaterOrEqual(listaCintas.Count, 1);
        }


        /// <summary>
        /// Método para probar que la lista obtenida de fechas sobre cintas puede tener uno o mas fechas
        /// </summary>
        [Test]
        public void PruebaObtenerListaFechaCintasObtenidas()
        {
            Tuple<List<Entidad>, List<DateTime>> tupla = cintas.Ejecutar();
            List<DateTime> listaFechaCinta = tupla.Item2;
            Assert.GreaterOrEqual(listaFechaCinta.Count, 1);
        }

        #endregion
    }
}
