using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using DominioSKD;
using ExcepcionesSKD.Modulo7;
using LogicaNegociosSKD.Modulo7;

namespace PruebasUnitariasSKD.Modulo7
{
    [TestFixture]
    public class M7_PruebaLogicaEventosPagos
    {
        #region Atributos
        /// <summary>
        /// Atributo que representa el id de la persona o atleta
        /// </summary>
        private int idPersona;
        /// <summary>
        /// Atributo que representa la clase LogicaEventosPagos
        /// </summary>
        LogicaEventosPagos logicaEventosPagos;
        #endregion

        #region SetUp & TearDown
        [SetUp]
        public void Init()
        {
            logicaEventosPagos = new LogicaEventosPagos();
            idPersona = 6;
        }

        [TearDown]
        public void Clean()
        {
            logicaEventosPagos = null;
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
            List<Evento> listaEvento = logicaEventosPagos.obtenerListaDeEventos(idPersona);
            Assert.GreaterOrEqual(listaEvento.Count, 0);
        }

        /// <summary>
        /// Método para probar la excepcion de número entero invalido de listar eventos pagos
        /// </summary>
        [Test]
        [ExpectedException(typeof(NumeroEnteroInvalidoException))]
        public void ListarEventosAsistidosNumeroEnteroException()
        {
            List<Evento> listaEvento = logicaEventosPagos.obtenerListaDeEventos(-1);
        }

        /// <summary>
        /// Método para probar que la lista obtenida puede tener cero o mas competencia
        /// </summary>
        [Test]
        public void PruebaObtenerListaCompetenciasAsistidas()
        {
            List<Competencia> listaCompetencia = logicaEventosPagos.obtenerListaDeCompetencias(idPersona);
            Assert.GreaterOrEqual(listaCompetencia.Count, 0);
        }

        /// <summary>
        /// Método para probar la excepcion de número entero invalido de listar competencias pagas
        /// </summary>
        [Test]
        [ExpectedException(typeof(NumeroEnteroInvalidoException))]
        public void ListarCompetenciasAsistidasNumeroEnteroException()
        {
            List<Competencia> listaCompetencia = logicaEventosPagos.obtenerListaDeCompetencias(-1);
        }

        /// <summary>
        /// Método para probar que se detalla un evento
        /// </summary>
        [Test]
        public void PruebaDetallarEvento()
        {
            Evento evento = logicaEventosPagos.detalleEventoID(8);
            Assert.AreEqual("El Bushido", evento.Nombre);
        }

        /// <summary>
        /// Método para probar la excepcion de número entero invalido de detallar evento
        /// </summary>
        [Test]
        [ExpectedException(typeof(NumeroEnteroInvalidoException))]
        public void DetallarEventoNumeroEnteroException()
        {
            Evento listaEvento = logicaEventosPagos.detalleEventoID(-1);
        }

        /// <summary>
        /// Método para probar que se detalla una competencia
        /// </summary>
        [Test]
        public void PruebaObtenerDetalleCompetencia()
        {
            Competencia competencia = logicaEventosPagos.detalleCompetenciaID(1);
            Assert.AreEqual("Ryu Kobudo", competencia.Nombre);
        }

        /// <summary>
        /// Método para probar la excepcion de número entero invalido de detallar competencia
        /// </summary>
        [Test]
        [ExpectedException(typeof(NumeroEnteroInvalidoException))]
        public void DetalleCompetenciaNumeroEnteroException()
        {
            Competencia competencia = logicaEventosPagos.detalleCompetenciaID(-1);
        }

        /// <summary>
        /// Método para probar que se obtiene la fecha de obtencion de un inscripcion de competencia
        /// </summary>
        [Test]
        public void PruebaObtenerFechaInscripcionCompetencia()
        {
            DateTime fechaCompetencia = logicaEventosPagos.obtenerFechaInscripcioncompetencia(idPersona, 8);
            Assert.AreEqual("02/13/2014", fechaCompetencia.ToString("MM/dd/yyyy"));
        }

        /// <summary>
        /// Método para probar la excepcion de número entero invalido de obtener fecha de inscripcion de competencia
        /// </summary>
        [Test]
        [ExpectedException(typeof(NumeroEnteroInvalidoException))]
        public void FechaInscripcionCompetenciaNumeroEnteroException()
        {
            DateTime fechaCompetencia = logicaEventosPagos.obtenerFechaInscripcioncompetencia(idPersona, -5);
        }

        /// <summary>
        /// Método para probar que se obtiene la fecha de pago de un evento
        /// </summary>
        [Test]
        public void PruebaObtenerFechaPagoEvento()
        {
            DateTime fechaCompetencia = logicaEventosPagos.obtenerFechaPagoEvento(idPersona, 2);
            Assert.AreEqual("03/10/2015", fechaCompetencia.ToString("MM/dd/yyyy"));
        }

        /// <summary>
        /// Método para probar la excepcion de número entero invalido de obtener fecha de pago de un evento
        /// </summary>
        [Test]
        [ExpectedException(typeof(NumeroEnteroInvalidoException))]
        public void FechaPagoEventoNumeroEnteroException()
        {
            DateTime fechaCompetencia = logicaEventosPagos.obtenerFechaInscripcioncompetencia(idPersona, -5);
        }

        /// <summary>
        /// Método para probar que se detalla una competencia
        /// </summary>
        [Test]
        public void PruebaObtenerDetalleCompetenciaPaga()
        {
            Competencia competencia = logicaEventosPagos.detalleCompetenciaPagaID(1);
            Assert.AreEqual("Ryu Kobudo", competencia.Nombre);
        }

        /// <summary>
        /// Método para probar la excepcion de número entero invalido de detallar competencia
        /// </summary>
        [Test]
        [ExpectedException(typeof(NumeroEnteroInvalidoException))]
        public void DetalleCompetenciaPagaNumeroEnteroException()
        {
            Competencia competencia = logicaEventosPagos.detalleCompetenciaPagaID(-1);
        }

        /// <summary>
        /// Método para probar que se obtiene el monto del pago de un evento
        /// </summary>
        [Test]
        public void PruebaObtenerMontoPagoEvento()
        {
            float monto = logicaEventosPagos.obtenerMontoEvento(idPersona, 1);
            Assert.AreEqual(0, monto);
        }

        /// <summary>
        /// Método para probar la excepcion de número entero invalido de obtener monto de pago de evento
        /// </summary>
        [Test]
        [ExpectedException(typeof(NumeroEnteroInvalidoException))]
        public void MontoPagoEventoNumeroEnteroException()
        {
            float monto = logicaEventosPagos.obtenerMontoEvento(idPersona, -1);
        }

        #endregion
    }
}
