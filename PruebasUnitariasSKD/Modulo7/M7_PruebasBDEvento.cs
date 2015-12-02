using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using DominioSKD;
using DatosSKD;
using DatosSKD.Modulo7;

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

        #endregion


    }
}
