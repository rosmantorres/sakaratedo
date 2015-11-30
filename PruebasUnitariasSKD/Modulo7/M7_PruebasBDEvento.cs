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
            idPersona = 35;
        }

        [TearDown]
        public void Clean()
        {
            idPersona = 0;
        }
        #endregion

        #region Test

        [Test]
        public void PruebaDetallarEventoXId()
        {
            BDEvento baseDeDatosEvento = new BDEvento();
            Evento evento = baseDeDatosEvento.DetallarEvento(5);
            Assert.AreEqual("La vida en el Dojo", evento.Nombre);
        }

        [Test]
        public void PruebaDetallarEventoXIdNoNulo()
        {
            BDEvento baseDeDatosEvento = new BDEvento();
            Evento evento = baseDeDatosEvento.DetallarEvento(5);
            Assert.NotNull(evento);
        }

        [Test]
        public void PruebaListarEventosAsistidos()
        {
            BDEvento baseDeDatosEvento = new BDEvento();
            List<Evento> listaEvento = baseDeDatosEvento.ListarEventosAsistidos(idPersona);
            Assert.GreaterOrEqual(listaEvento.Count, 0);
        }

        [Test]
        public void PruebaListarEventosAsistidosNoNulo()
        {
            BDEvento baseDeDatosEvento = new BDEvento();
            List<Evento> listaEvento = baseDeDatosEvento.ListarEventosAsistidos(idPersona);
            Assert.NotNull(listaEvento);
        }

        [Test]
        public void PruebaListarCompetenciasAsistidas()
        {
            BDEvento baseDeDatosEvento = new BDEvento();
            List<Competencia> listaCompetencia = baseDeDatosEvento.ListarCompetenciasAsistidas(idPersona);
            Assert.GreaterOrEqual(listaCompetencia.Count, 0);
        }

        [Test]
        public void PruebaListarCompetenciasAsistidasNoNula()
        {
            BDEvento baseDeDatosEvento = new BDEvento();
            List<Competencia> listaCompetencia = baseDeDatosEvento.ListarCompetenciasAsistidas(idPersona);
            Assert.NotNull(listaCompetencia);
        }

        [Test]
        public void PruebaFechaInscripcion()
        {
            BDEvento baseDeDatosEvento = new BDEvento();
            DateTime fechaInscripcion = baseDeDatosEvento.fechaInscripcion(idPersona, 5);
            Assert.AreEqual("02/10/2015", fechaInscripcion.ToString("MM/dd/yyyy"));
        }

        [Test]
        public void PruebaFechaInscripcionNoNula()
        {
            BDEvento baseDeDatosEvento = new BDEvento();
            DateTime fechaInscripcion = baseDeDatosEvento.fechaInscripcion(idPersona, 5);
            Assert.NotNull(fechaInscripcion);
        }

        #endregion


    }
}
