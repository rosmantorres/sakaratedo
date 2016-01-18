using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using DominioSKD;
using ExcepcionesSKD.Modulo7;
using LogicaNegociosSKD.Modulo7;
using DominioSKD;
namespace PruebasUnitariasSKD.Modulo7
{
    [TestFixture]
    public class M7_PruebasLogicaEventosAsistidos
    {
        #region Atributos
        /// <summary>
        /// Atributo que representa el id de la persona o atleta
        /// </summary>
        private int idPersona;
        /// <summary>
        /// Atributo que representa la clase LogicaEventosAsistidos
        /// </summary>
        LogicaEventosAsistidos logicaEventosAsistidos;
        #endregion

        #region SetUp & TearDown
        [SetUp]
        public void Init()
        {
            logicaEventosAsistidos = new LogicaEventosAsistidos();
            idPersona = 6;
        }

        [TearDown]
        public void Clean()
        {
            logicaEventosAsistidos = null;
            idPersona = 0;
        }
        #endregion

        #region Test

        /// <summary>
        /// Método para probar que la lista obtenida puede tener cero o mas eventos
        /// </summary>
        [Test]
        public void PruebaObtenerListaEventosAsistidos()
        {
            List<Evento> listaEvento = logicaEventosAsistidos.obtenerListaDeEventos(idPersona);
            Assert.GreaterOrEqual(listaEvento.Count, 0);
        }

        /// <summary>
        /// Método para probar la excepcion de número entero invalido de listar eventos asistidos
        /// </summary>
        [Test]
        [ExpectedException(typeof(NumeroEnteroInvalidoException))]
        public void ListarEventosAsistidosNumeroEnteroException()
        {
            List<Evento> listaEvento = logicaEventosAsistidos.obtenerListaDeEventos(-1);
        }

        /// <summary>
        /// Método para probar que la lista obtenida puede tener cero o mas competencia
        /// </summary>
        [Test]
        public void PruebaObtenerListaCompetenciasAsistidas()
        {
            List<Competencia> listaCompetencia = logicaEventosAsistidos.obtenerListaDeCompetencias(idPersona);
            Assert.GreaterOrEqual(listaCompetencia.Count, 0);
        }

        /// <summary>
        /// Método para probar la excepcion de número entero invalido de listar competencias asistidos
        /// </summary>
        [Test]
        [ExpectedException(typeof(NumeroEnteroInvalidoException))]
        public void ListarCompetenciasAsistidasNumeroEnteroException()
        {
            List<Competencia> listaCompetencia = logicaEventosAsistidos.obtenerListaDeCompetencias(-1);
        }
        

        /// <summary>
        /// Método para probar que se detalla un evento
        /// </summary>
        [Test]
        public void PruebaDetallarEvento()
        {
            Evento evento = logicaEventosAsistidos.detalleEventoID(8);
            Assert.AreEqual("El Bushido", evento.Nombre);
        }

        /// <summary>
        /// Método para probar la excepcion de número entero invalido de detallar evento
        /// </summary>
        [Test]
        [ExpectedException(typeof(NumeroEnteroInvalidoException))]
        public void DetallarEventoNumeroEnteroException()
        {
            Evento listaEvento = logicaEventosAsistidos.detalleEventoID(-1);
        }

        /// <summary>
        /// Método para probar que se detalla una competencia
        /// </summary>
        [Test]
        public void PruebaObtenrDetalleCompetencia()
        {
            Competencia competencia = logicaEventosAsistidos.detalleCompetenciaID(1);
            Assert.AreEqual("Ryu Kobudo", competencia.Nombre);
        }

        /// <summary>
        /// Método para probar la excepcion de número entero invalido de detallar competencia
        /// </summary>
        [Test]
        [ExpectedException(typeof(NumeroEnteroInvalidoException))]
        public void DetalleCompetenciaNumeroEnteroException()
        {
            Competencia competencia = logicaEventosAsistidos.detalleCompetenciaID(-1);
        }

        /// <summary>
        /// Método para probar que se obtiene la fecha de obtencion de un inscripcion
        /// </summary>
        [Test]
        public void PruebaObtenerFechaInscripcion()
        {
            DateTime fechaCinta = logicaEventosAsistidos.obtenerFechaInscripcion(idPersona, 5);
            Assert.AreEqual("02/10/2015", fechaCinta.ToString("MM/dd/yyyy"));
        }        

        /// <summary>
        /// Método para probar la excepcion de número entero invalido de obtener fecha de inscripcion
        /// </summary>
        [Test]
        [ExpectedException(typeof(NumeroEnteroInvalidoException))]
        public void FechaInscripcionNumeroEnteroException()
        {
            DateTime fechaCinta = logicaEventosAsistidos.obtenerFechaInscripcion(idPersona, -5);
        }

        #endregion
    }
}
