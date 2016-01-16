using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using LogicaNegociosSKD.Fabrica;
using DominioSKD;
using LogicaNegociosSKD.Comandos.Modulo7;
using DominioSKD.Fabrica;
using ExcepcionesSKD.Modulo7;

namespace PruebasUnitariasSKD.Modulo7.PruebasComando
{
    [TestFixture]
    public class M7_PruebasComandoMatriculas
    {
        #region Atributos
        private Persona idPersona;
        private FabricaComandos fabricaComandos;
        private ComandoConsultarListaMatriculasPagas matriculasPagas;
        private FabricaEntidades fabricaEntidades;
        #endregion

        #region SetUp & TearDown
        [SetUp]
        public void Init()
        {
            fabricaComandos = new FabricaComandos();
            matriculasPagas = (ComandoConsultarListaMatriculasPagas)fabricaComandos.ObtenerComandoConsultarListaMatriculasPagas();
            fabricaEntidades = new FabricaEntidades();
            idPersona = new Persona();//cambiar por fabrica
            idPersona.ID = 6;
            matriculasPagas.LaEntidad = idPersona;
        }

        [TearDown]
        public void Clean()
        {
            fabricaComandos = null;
            matriculasPagas = null;
            fabricaEntidades = null;
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
            idPersona.ID = -1;
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
