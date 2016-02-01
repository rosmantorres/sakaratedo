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
    /// Clase que contiene las pruebas unitarias para el comando matriculas pagas de atleta
    /// </summary>
    [TestFixture]
    public class M7_PruebasComandoMatriculas
    {
        #region Atributos
        private PersonaM7 idPersona;
        private ComandoConsultarListaMatriculasPagas matriculasPagas;
        #endregion

        #region SetUp & TearDown
        /// <summary>
        /// Método que se ejecuta antes de cada prueba
        /// </summary>
        [SetUp]
        public void Init()
        {
            matriculasPagas = (ComandoConsultarListaMatriculasPagas)FabricaComandos.ObtenerComandoConsultarListaMatriculasPagas();
            idPersona = (PersonaM7)FabricaEntidades.ObtenerPersonaM7();
            idPersona.Id = 6;
            matriculasPagas.LaEntidad = idPersona;
        }

        /// <summary>
        /// Método que se ejecuta luego de cada prueba
        /// </summary>
        [TearDown]
        public void Clean()
        {
            matriculasPagas = null;
            idPersona = null;
        }
        #endregion

        #region Test

        /// <summary>
        /// Método para probar que la tupla obtenida no es nula en matriculas pagas
        /// </summary>
        [Test]
        public void PruebaObtenerTuplaMatriculasPagas()
        {
            Tuple<List<Entidad>, List<Boolean>, List<float>> tupla = matriculasPagas.Ejecutar();
            Assert.IsNotNull(tupla);
        }

        /// <summary>
        /// Método para probar la excepcion de número entero invalido en obtener lista de matriculas pagas
        /// </summary>
        [Test]
        [ExpectedException(typeof(NumeroEnteroInvalidoException))]
        public void ListaMatriculasNumeroEnteroException()
        {
            idPersona.Id = -1;
            Tuple<List<Entidad>, List<Boolean>, List<float>> tupla = matriculasPagas.Ejecutar();
        }

        /// <summary>
        /// Método para probar que la lista obtenida de matriculas puede tener una o mas matriculas
        /// </summary>
        [Test]
        public void PruebaObtenerListaMatriculasPagas()
        {
            Tuple<List<Entidad>, List<Boolean>, List<float>> tupla = matriculasPagas.Ejecutar();
            List<Entidad> listaEvento = tupla.Item1;
            Assert.GreaterOrEqual(listaEvento.Count, 1);
        }


        /// <summary>
        /// Método para probar que la lista obtenida de los estados de las matriculas pueden tener uno o mas estados
        /// </summary>
        [Test]
        public void PruebaObtenerEstadoMatriculasPagas()
        {
            Tuple<List<Entidad>, List<Boolean>, List<float>> tupla = matriculasPagas.Ejecutar();
            List<Boolean> listaEstadoMatricula = tupla.Item2;
            Assert.GreaterOrEqual(listaEstadoMatricula.Count, 1);
        }

        /// <summary>
        /// Método para probar que la lista obtenida de los montos pagados de las matriculas, puede tener una o mas matriculas
        /// </summary>
        [Test]
        public void PruebaObtenerListaMontoMatriculasPagas()
        {
            Tuple<List<Entidad>, List<Boolean>, List<float>> tupla = matriculasPagas.Ejecutar();
            List<float> listaMontoMatriculaPaga = tupla.Item3;
            Assert.GreaterOrEqual(listaMontoMatriculaPaga.Count, 1);
        }
        #endregion
    }
}
