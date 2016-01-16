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
    public class M7_PruebasComandoEventosPagos
    {
        #region Atributos
        private Persona idPersona;
        private FabricaComandos fabricaComandos;
        private ComandoConsultarListaEventosPagos eventosPagos;
        private FabricaEntidades fabricaEntidades;
        #endregion

        #region SetUp & TearDown
        [SetUp]
        public void Init()
        {
            fabricaComandos = new FabricaComandos();
            eventosPagos = (ComandoConsultarListaEventosPagos)fabricaComandos.ObtenerComandoConsultarListaEventosPagos();
            fabricaEntidades = new FabricaEntidades();
            idPersona = new Persona();//cambiar por fabrica
            idPersona.ID = 6;
            eventosPagos.LaEntidad = idPersona;
        }

        [TearDown]
        public void Clean()
        {
            fabricaComandos = null;
            eventosPagos = null;
            fabricaEntidades = null;
            idPersona = null;
        }
        #endregion

        #region Test

        /// <summary>
        /// Método para probar que la tupla obtenida no es nula en eventos asistidos
        /// </summary>
        [Test]
        public void PruebaObtenerTuplaEventosPagos()
        {
            Tuple<List<Entidad>, List<Entidad>, List<DateTime>, List<float>, List<DateTime>> tupla = eventosPagos.Ejecutar();
            Assert.IsNotNull(tupla);
        }

        /// <summary>
        /// Método para probar la excepcion de número entero invalido en obtener lista eventos asistidos
        /// </summary>
     [Test]
        [ExpectedException(typeof(NumeroEnteroInvalidoException))]
        public void ListaEventosPagosNumeroEnteroException()
        {
            idPersona.ID = -1;
            Tuple<List<Entidad>, List<Entidad>, List<DateTime>, List<float>, List<DateTime>> tupla = eventosPagos.Ejecutar();
        }

        /// <summary>
        /// Método para probar que la lista obtenida de eventos puede tener uno o mas eventos
        /// </summary>
        [Test]
        public void PruebaObtenerListaEventosPagos()
        {
            Tuple<List<Entidad>, List<Entidad>, List<DateTime>, List<float>, List<DateTime>> tupla = eventosPagos.Ejecutar();
            List<Entidad> listaEvento = tupla.Item1;
            Assert.GreaterOrEqual(listaEvento.Count, 1);
        }

        /// <summary>
        /// Método para probar que la lista obtenida de competencias puede tener uno o mas competencias
        /// </summary>
        [Test]
        public void PruebaObtenerListaCompetenciasPagas()
        {
            Tuple<List<Entidad>, List<Entidad>, List<DateTime>, List<float>, List<DateTime>> tupla = eventosPagos.Ejecutar();
            List<Entidad> listaCompetencia = tupla.Item2;
            Assert.GreaterOrEqual(listaCompetencia.Count, 1);
        }

        /// <summary>
        /// Método para probar que la lista obtenida de fechas sobre eventos puede tener uno o mas fechas
        /// </summary>
        [Test]
        public void PruebaObtenerListaFechaEventosPagos()
        {

            Tuple<List<Entidad>, List<Entidad>, List<DateTime>, List<float>, List<DateTime>> tupla = eventosPagos.Ejecutar();
            List<DateTime> listaFechaEvento = tupla.Item3;
            Assert.GreaterOrEqual(listaFechaEvento.Count, 1);
        }

        /// <summary>
        /// Método para probar que la lista obtenida de fechas sobre competencias puede tener uno o mas competencias
        /// </summary>
      [Test]
        public void PruebaObtenerListaFechaCompetenciasPagas()
        {

            Tuple<List<Entidad>, List<Entidad>, List<DateTime>, List<float>, List<DateTime>> tupla = eventosPagos.Ejecutar();
            List<DateTime> listaFechaCompetencia = tupla.Item5;
            Assert.GreaterOrEqual(listaFechaCompetencia.Count, 1);
        }

      [Test]
      public void PruebaObtenerListaMontoEventoPago()
      {

          Tuple<List<Entidad>, List<Entidad>, List<DateTime>, List<float>, List<DateTime>> tupla = eventosPagos.Ejecutar();
          List<float> listaMontoPago = tupla.Item4;
          Assert.GreaterOrEqual(listaMontoPago.Count, 1);
      }

    
      
        #endregion
    }
}
