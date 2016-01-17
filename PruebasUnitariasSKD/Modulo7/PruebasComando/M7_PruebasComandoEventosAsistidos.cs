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
    public class M7_PruebasComandoEventosAsistidos
    {
        #region Atributos
        private Persona idPersona;
        private FabricaComandos fabricaComandos;
        private ComandoConsultarListaEventosAsistidos eventosAsistidos;
        private FabricaEntidades fabricaEntidades;
        #endregion

        #region SetUp & TearDown
        [SetUp]
        public void Init()
        {
            fabricaComandos = new FabricaComandos();
            eventosAsistidos = (ComandoConsultarListaEventosAsistidos)fabricaComandos.ObtenerComandoConsultarListaEventosAsistidos();
            fabricaEntidades = new FabricaEntidades();
            idPersona = new Persona();//cambiar por fabrica
            idPersona.Id = 6;
            eventosAsistidos.LaEntidad = idPersona;
        }

        [TearDown]
        public void Clean()
        {
            fabricaComandos = null;
            eventosAsistidos = null;
            fabricaEntidades = null;
            idPersona = null;
        }
        #endregion

        #region Test

        /// <summary>
        /// Método para probar que la tupla obtenida no es nula en eventos asistidos
        /// </summary>
        [Test]
        public void PruebaObtenerTuplaEventosAsistidos()
        {
            Tuple<List<Entidad>, List<Entidad>, List<DateTime>, List<DateTime>> tupla = eventosAsistidos.Ejecutar();
            Assert.IsNotNull(tupla);
        }

        /// <summary>
        /// Método para probar la excepcion de número entero invalido en obtener lista eventos asistidos
        /// </summary>
        [Test]
        [ExpectedException(typeof(NumeroEnteroInvalidoException))]
        public void ListaEventosNumeroEnteroException()
        {
            idPersona.Id = -1;
            Tuple<List<Entidad>, List<Entidad>, List<DateTime>, List<DateTime>> tupla = eventosAsistidos.Ejecutar();
        }

        /// <summary>
        /// Método para probar que la lista obtenida de eventos puede tener uno o mas eventos
        /// </summary>
        [Test]
        public void PruebaObtenerListaEventosAsistidos()
        {
            Tuple<List<Entidad>, List<Entidad>, List<DateTime>, List<DateTime>>  tupla = eventosAsistidos.Ejecutar();
            List<Entidad> listaEvento = tupla.Item1;
            Assert.GreaterOrEqual(listaEvento.Count, 1);
        }

        /// <summary>
        /// Método para probar que la lista obtenida de competencias puede tener uno o mas competencias
        /// </summary>
        [Test]
        public void PruebaObtenerListaCompetenciasAsistidas()
        {
            Tuple<List<Entidad>, List<Entidad>, List<DateTime>, List<DateTime>> tupla = eventosAsistidos.Ejecutar();
            List<Entidad> listaCompetencia = tupla.Item2;
            Assert.GreaterOrEqual(listaCompetencia.Count, 1);
        }

        /// <summary>
        /// Método para probar que la lista obtenida de fechas sobre eventos puede tener uno o mas fechas
        /// </summary>
        [Test]
        public void PruebaObtenerListaFechaEventosAsistidos()
        {
            Tuple<List<Entidad>, List<Entidad>, List<DateTime>, List<DateTime>> tupla = eventosAsistidos.Ejecutar();
            List<DateTime> listaFechaEvento = tupla.Item3;
            Assert.GreaterOrEqual(listaFechaEvento.Count, 1);
        }

        /// <summary>
        /// Método para probar que la lista obtenida de fechas sobre competencias puede tener uno o mas competencias
        /// </summary>
        [Test]
        public void PruebaObtenerListaFechaCompetenciasAsistidos()
        {
            Tuple<List<Entidad>, List<Entidad>, List<DateTime>, List<DateTime>> tupla = eventosAsistidos.Ejecutar();
            List<DateTime> listaFechaCompetencia = tupla.Item4;
            Assert.GreaterOrEqual(listaFechaCompetencia.Count, 1);
        }
        #endregion
    }
}
