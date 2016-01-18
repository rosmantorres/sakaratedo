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
using DominioSKD.Entidades.Modulo9;

namespace PruebasUnitariasSKD.Modulo7
{
    class M7_PruebasLogicaEventosPagos
    {
        #region Atributos
        /// <summary>
        /// Atributo que representa el id de la persona o atleta
        /// </summary>
        private int idPersona;
        /// <summary>
        /// Atributo que representa la clase LogicaEventosInscritos
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
        public void PruebaObtenerListaEventosPagos()
        {
            List<Evento> listaEvento = logicaEventosPagos.obtenerListaDeEventos(idPersona);
            Assert.GreaterOrEqual(listaEvento.Count, 0);
        }

        /// <summary>
        /// Método para probar la excepcion de número entero invalido de listar eventos pagos
        /// </summary>
        [Test]
        [ExpectedException(typeof(NumeroEnteroInvalidoException))]
        public void ListarEventosInscritosNumeroEnteroException()
        {
            List<Evento> listaEvento = logicaEventosPagos.obtenerListaDeEventos(-1);
        }

        /// <summary>
        /// Método para probar que la lista obtenida puede tener cero o mas competencia
        /// </summary>
        [Test]
        public void PruebaObtenerListaCompetenciasPagas()
        {
            List<Competencia> listaCompetencia = logicaEventosPagos.obtenerListaDeCompetencias(idPersona);
            Assert.GreaterOrEqual(listaCompetencia.Count, 0);
        }

        /// <summary>
        /// Método para probar la excepcion de número entero invalido de listar competencias pagas
        /// </summary>
        [Test]
        [ExpectedException(typeof(NumeroEnteroInvalidoException))]
        public void ListarCompetenciasInscritasNumeroEnteroException()
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
            Evento listaCinta = logicaEventosPagos.detalleEventoID(-1);
        }

        /// <summary>
        /// Método para probar que se detalla un evento
        /// </summary>
        [Test]
        public void PruebaDetallarCompetenciaPagaXId()
        {
            Competencia compe = logicaEventosPagos.detalleCompetenciaPagaID(9);
            Assert.AreEqual("Gashumi Io", compe.Nombre);
        }

        /// <summary>
        /// Método para probar la excepcion de número entero invalido de detallar competencia
        /// </summary>
        [Test]
        [ExpectedException(typeof(NumeroEnteroInvalidoException))]
        public void DetallarCompetenciaNumeroEnteroException()
        {
            Competencia listaC = logicaEventosPagos.detalleCompetenciaPagaID(-1);
        }

        /// <summary>
        /// Método para probar que devuelve la fecha de inscripción de una competencia 
        /// </summary>
        [Test]
        public void PruebaFechaInscripcion()
        {
            DateTime fechaInscripcion = logicaEventosPagos.obtenerFechaInscripcioncompetencia(idPersona, 9);
            Assert.AreEqual("06/17/2015", fechaInscripcion.ToString("MM/dd/yyyy"));
        }

        /// <summary>
        /// Método para probar que no devuelva nula la fecha de inscripción de una competencia
        /// </summary>
        [Test]
        public void PruebaFechaInscripcionNoNula()
        {
            DateTime fechaInscripcion = logicaEventosPagos.obtenerFechaInscripcioncompetencia(idPersona, 9);
            Assert.NotNull(fechaInscripcion);
        }


        /// <summary>
        /// Método para probar la exception de número entero invalido de prueba fecha inscripcion
        /// </summary>

        [Test]
        [ExpectedException(typeof(NumeroEnteroInvalidoException))]
        public void FechaInscripcionNumeroEnteroException()
        {
            DateTime fechaInscripcion = logicaEventosPagos.obtenerFechaInscripcioncompetencia(idPersona, -2);
        }


        /// <summary>
        /// Método para probar que devuelve el monto de compra de un evento 
        /// </summary>
        [Test]
        public void PruebaObtenerMontoEvento()
        {
            float monto = logicaEventosPagos.obtenerMontoEvento(idPersona, 10);
            Assert.AreEqual(0 , monto);
        }


        /// <summary>
        /// Método para probar que devuelve la fecha de pago de un evento
        /// </summary>
        [Test]
        public void PruebaFechaEventoPago()
        {
            DateTime fechaPago = logicaEventosPagos.obtenerFechaPagoEvento(idPersona, 13);
            Assert.AreEqual("03/10/2015", fechaPago.ToString("MM/dd/yyyy"));
        }

        /// <summary>
        /// Método para probar que no devuelva nula la fecha de inscripción de una competencia
        /// </summary>
        [Test]
        public void PruebaFechaPagoEventonNoNula()
        {
            DateTime fechaPago = logicaEventosPagos.obtenerFechaPagoEvento(idPersona, 9);
            Assert.NotNull(fechaPago);
        }

        /// <summary>
        /// Método para probar la exception de número entero invalido de prueba fecha inscripcion
        /// </summary>

        [Test]
        [ExpectedException(typeof(NumeroEnteroInvalidoException))]
        public void FechaPagoEventoNumeroEnteroException()
        {
            DateTime fechaPago = logicaEventosPagos.obtenerFechaPagoEvento(idPersona, -2);
        }

        /// <summary>
        /// Método para probar que se detalla un evento
        /// </summary>
        [Test]
        public void PruebaDetallarCompetenciaXId()
        {
            Competencia competencia = logicaEventosPagos.detalleCompetenciaID(8);
            Assert.AreEqual("Shoosei Kai", competencia.Nombre);
        }

        /// <summary>
        /// Método para probar la excepcion de número entero invalido de detallar evento
        /// </summary>
        [Test]
        [ExpectedException(typeof(NumeroEnteroInvalidoException))]
        public void DetallarCompetenciaXIdNumeroEnteroException()
        {
            Competencia listaC = logicaEventosPagos.detalleCompetenciaID(-1);
        }

        #endregion
    }
}
