using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using DominioSKD;
using DatosSKD;
using DatosSKD.Modulo7;
using ExcepcionesSKD.Modulo7;
using DominioSKD.Entidades.Modulo9;

namespace PruebasUnitariasSKD.Modulo7
{
    /// <summary>
    /// Clase de pruebas para la clase BDEvento
    /// </summary>
    [TestFixture]
    public class M7_PruebasBDEvento
    {

        #region Atributos
        /// <summary>
        /// Atributo que representa el id de la persona o atleta
        /// </summary>
        private int idPersona;
        #endregion

        #region SetUp & TearDown
        [SetUp]
        public void Init()
        {
            idPersona = 6;
        }

        [TearDown]
        public void Clean()
        {
            idPersona = 0;
        }
        #endregion

        #region Test

        /// <summary>
        /// Método para probar que se detalla un evento
        /// </summary>
        [Test]
        public void PruebaDetallarEventoXId()
        {
            BDEvento baseDeDatosEvento = new BDEvento();
            Evento evento = baseDeDatosEvento.DetallarEvento(5);
            Assert.AreEqual("La vida en el Dojo", evento.Nombre);
        }

        /// <summary>
        /// Método para probar que un evento detallado no sea nulo
        /// </summary>
        [Test]
        public void PruebaDetallarEventoXIdNoNulo()
        {
            BDEvento baseDeDatosEvento = new BDEvento();
            Evento evento = baseDeDatosEvento.DetallarEvento(5);
            Assert.NotNull(evento);
        }

        /// <summary>
        /// Método para probar la exception de número entero invalido de prueba detalle evento
        /// </summary>

        [Test]
        [ExpectedException(typeof(NumeroEnteroInvalidoException))]
        public void DetalleEventoNumeroEnteroException()
        {
            BDEvento baseDeDatosEvento = new BDEvento();
            baseDeDatosEvento.DetallarEvento(-1);
        }

        /// <summary>
        /// Método para probar que la lista obtenida tiene cero o mas eventos
        /// </summary>
        [Test]
        public void PruebaListarEventosAsistidos()
        {
            BDEvento baseDeDatosEvento = new BDEvento();
            List<Evento> listaEvento = baseDeDatosEvento.ListarEventosAsistidos(idPersona);
            Assert.GreaterOrEqual(listaEvento.Count, 0);
        }

        /// <summary>
        /// Método para probar que la lista obtenida no sea nula
        /// </summary>
        [Test]
        public void PruebaListarEventosAsistidosNoNulo()
        {
            BDEvento baseDeDatosEvento = new BDEvento();
            List<Evento> listaEvento = baseDeDatosEvento.ListarEventosAsistidos(idPersona);
            Assert.NotNull(listaEvento);
        }

        /// <summary>
        /// Método para probar la exception de número entero invalido de listar eventos asistidos
        /// </summary>
        [Test]
        [ExpectedException(typeof(NumeroEnteroInvalidoException))]
        public void ListarEventoAsistidoNumeroEnteroException()
        {
            BDEvento baseDeDatosEvento = new BDEvento();
            List<Evento> listaEvento = baseDeDatosEvento.ListarEventosAsistidos(-1);
        }

        /// <summary>
        /// Método para probar que la lista obtenida tiene cero o mas eventos pagos
        /// </summary>
        [Test]
        public void PruebaListarEventosPagos()
        {
            BDEvento baseDeDatosEvento = new BDEvento();
            List<Evento> listaEvento = baseDeDatosEvento.ListarEventosPagos(idPersona);
            Assert.GreaterOrEqual(listaEvento.Count, 0);
        }

        /// <summary>
        /// Método para probar que la lista obtenida no sea nula
        /// </summary>
        [Test]
        public void PruebaListarEventosPagosNoNulo()
        {
            BDEvento baseDeDatosEvento = new BDEvento();
            List<Evento> listaEvento = baseDeDatosEvento.ListarEventosPagos(idPersona);
            Assert.NotNull(listaEvento);
        }

        /// <summary>
        /// Método para probar la exception de número entero invalido de listar eventos pagos
        /// </summary>
        [Test]
        [ExpectedException(typeof(NumeroEnteroInvalidoException))]
        public void ListarEventoPagoNumeroEnteroException()
        {
            BDEvento baseDeDatosEvento = new BDEvento();
            List<Evento> listaEvento = baseDeDatosEvento.ListarEventosPagos(-1);
        }

        /// <summary>
        /// Método para probar que la lista obtenida tiene cero o mas competencias
        /// </summary>
        [Test]
        public void PruebaListarCompetenciasAsistidas()
        {
            BDEvento baseDeDatosEvento = new BDEvento();
            List<Competencia> listaCompetencia = baseDeDatosEvento.ListarCompetenciasAsistidas(idPersona);
            Assert.GreaterOrEqual(listaCompetencia.Count, 0);
        }

        /// <summary>
        /// Método para probar que la lista obtenida no sea nula
        /// </summary>
        [Test]
        public void PruebaListarCompetenciasAsistidasNoNula()
        {
            BDEvento baseDeDatosEvento = new BDEvento();
            List<Competencia> listaCompetencia = baseDeDatosEvento.ListarCompetenciasAsistidas(idPersona);
            Assert.NotNull(listaCompetencia);
        }

        /// <summary>
        /// Método para probar la exception de número entero invalido de listar eventos asistidos
        /// </summary>
        [Test]
        [ExpectedException(typeof(NumeroEnteroInvalidoException))]
        public void ListarCompetenciaAsistidaNumeroEnteroException()
        {
            BDEvento baseDeDatosEvento = new BDEvento();
            List<Competencia> listaCompetencia = baseDeDatosEvento.ListarCompetenciasAsistidas(-1);
        }
        /// <summary>
        /// Método para probar que la lista obtenida tiene cero o mas competencias pagadas por atleta
        /// </summary>
        [Test]
        public void PruebaListarCompetenciasPagas()
        {
            BDEvento baseDeDatosEvento = new BDEvento();
            List<Competencia> listaCompetencia = baseDeDatosEvento.ListarCompetenciasPagas(idPersona);
            Assert.GreaterOrEqual(listaCompetencia.Count, 0);
        }

        /// <summary>
        /// Método para probar que la lista obtenida no sea nula
        /// </summary>
        [Test]
        public void PruebaListarCompetenciasPagasNoNula()
        {
            BDEvento baseDeDatosEvento = new BDEvento();
            List<Competencia> listaCompetencia = baseDeDatosEvento.ListarCompetenciasPagas(idPersona);
            Assert.NotNull(listaCompetencia);
        }

        /// <summary>
        /// Método para probar la exception de número entero invalido de listar competencias pagadas
        /// </summary>
        [Test]
        [ExpectedException(typeof(NumeroEnteroInvalidoException))]
        public void ListarCompetenciaPagaNumeroEnteroException()
        {
            BDEvento baseDeDatosEvento = new BDEvento();
            List<Competencia> listaCompetencia = baseDeDatosEvento.ListarCompetenciasPagas(-1);
        }

        /// <summary>
        /// Método para probar que devuelve la fecha de inscripción de un evento 
        /// </summary>
        [Test]
        public void PruebaFechaInscripcion()
        {
            BDEvento baseDeDatosEvento = new BDEvento();
            DateTime fechaInscripcion = baseDeDatosEvento.fechaInscripcionEvento(idPersona, 5);
            Assert.AreEqual("02/10/2015", fechaInscripcion.ToString("MM/dd/yyyy"));
        }

        /// <summary>
        /// Método para probar que no devuelva nula la fecha de inscripción de un evento
        /// </summary>
        [Test]
        public void PruebaFechaInscripcionNoNula()
        {
            BDEvento baseDeDatosEvento = new BDEvento();
            DateTime fechaInscripcion = baseDeDatosEvento.fechaInscripcionEvento(idPersona, 5);
            Assert.NotNull(fechaInscripcion);
        }


        /// <summary>
        /// Método para probar la exception de número entero invalido de prueba ultima cinta
        /// </summary>

        [Test]
        [ExpectedException(typeof(NumeroEnteroInvalidoException))]
        public void FechaInscripcionNumeroEnteroException()
        {
            BDEvento baseDeDatosEvento = new BDEvento();
            DateTime fechaInscripcion = baseDeDatosEvento.fechaInscripcionEvento(idPersona, -2);
        }

        /// <summary>
        /// Método para probar que la lista obtenida tiene cero o mas eventos
        /// </summary>
        [Test]
        public void PruebaListarEventosInscritos()
        {
            BDEvento baseDeDatosEvento = new BDEvento();
            List<Evento> listaEvento = baseDeDatosEvento.ListarEventosInscritos(idPersona);
            Assert.GreaterOrEqual(listaEvento.Count, 0);
        }

        /// <summary>
        /// Método para probar que la lista obtenida no sea nula
        /// </summary>
        [Test]
        public void PruebaListarEventosInscritosNoNulo()
        {
            BDEvento baseDeDatosEvento = new BDEvento();
            List<Evento> listaEvento = baseDeDatosEvento.ListarEventosInscritos(idPersona);
            Assert.NotNull(listaEvento);
        }

        /// <summary>
        /// Método para probar la exception de número entero invalido de listar eventos inscritos
        /// </summary>
        [Test]
        [ExpectedException(typeof(NumeroEnteroInvalidoException))]
        public void ListarEventoInscritoNumeroEnteroException()
        {
            BDEvento baseDeDatosEvento = new BDEvento();
            List<Evento> listaEvento = baseDeDatosEvento.ListarEventosInscritos(-1);
        }

        /// <summary>
        /// Método para probar que la lista obtenida tiene cero o mas competencias
        /// </summary>
        [Test]
        public void PruebaListarCompetenciaInscrita()
        {
            BDEvento baseDeDatosEvento = new BDEvento();
            List<Competencia> listaCompetencia = baseDeDatosEvento.ListarCompetenciasInscritas(idPersona);
            Assert.GreaterOrEqual(listaCompetencia.Count, 0);
        }

        /// <summary>
        /// Método para probar que la lista obtenida no sea nula
        /// </summary>
        [Test]
        public void PruebaListarCompetenciaInscritaNoNula()
        {
            BDEvento baseDeDatosEvento = new BDEvento();
            List<Competencia> listaCompetencia = baseDeDatosEvento.ListarCompetenciasInscritas(idPersona);
            Assert.NotNull(listaCompetencia);
        }

        /// <summary>
        /// Método para probar la exception de número entero invalido de listar competencias asistidas
        /// </summary>
        [Test]
        [ExpectedException(typeof(NumeroEnteroInvalidoException))]
        public void ListarCompetenciaInscritaNumeroEnteroException()
        {
            BDEvento baseDeDatosEvento = new BDEvento();
            List<Competencia> listaCompetencia = baseDeDatosEvento.ListarCompetenciasInscritas(-1);
        }

        /// <summary>
        /// Método para probar que la lista obtenida tiene cero o mas eventos
        /// </summary>
        [Test]
        public void PruebaListarHorarioPractica()
        {
            BDEvento baseDeDatosEvento = new BDEvento();
            List<Evento> listaEvento = baseDeDatosEvento.ListarHorarioPractica(idPersona);
            Assert.GreaterOrEqual(listaEvento.Count, 0);
        }

        /// <summary>
        /// Método para probar que la lista obtenida no sea nula
        /// </summary>
        [Test]
        public void PruebaListarHorarioPracticaNoNulo()
        {
            BDEvento baseDeDatosEvento = new BDEvento();
            List<Evento> listaEvento = baseDeDatosEvento.ListarHorarioPractica(idPersona);
            Assert.NotNull(listaEvento);
        }

        /// <summary>
        /// Método para probar la exception de número entero invalido de listar horario de practica
        /// </summary>
        [Test]
        [ExpectedException(typeof(NumeroEnteroInvalidoException))]
        public void ListarHorarioPracticaNumeroEnteroException()
        {
            BDEvento baseDeDatosEvento = new BDEvento();
            List<Evento> listaEvento = baseDeDatosEvento.ListarHorarioPractica(-1);
        }

        #endregion


    }
}
