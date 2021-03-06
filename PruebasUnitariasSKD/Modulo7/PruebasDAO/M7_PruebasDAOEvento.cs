﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using DatosSKD.Fabrica;
using DatosSKD.DAO.Modulo7;
using DominioSKD.Fabrica;
using DominioSKD;
using ExcepcionesSKD.Modulo7;
using DominioSKD.Fabrica;
using DominioSKD.Entidades.Modulo7;

namespace PruebasUnitariasSKD.Modulo7.PruebasDAO
{

    /// <summary>
    /// Clase que contiene las pruebas unitarias para DaoEvento
    /// </summary>
    [TestFixture]
    public class M7_PruebasDAOEvento
    {
        #region Atributos
        private PersonaM7 idPersona;
        private FabricaEntidades fabricaEntidades;
        private DaoEvento baseDeDatosEvento;
        #endregion

        #region SetUp & TearDown
        /// <summary>
        /// Método que se ejecuta antes de cada prueba
        /// </summary>
        [SetUp]
        public void Init()
        {
            fabricaEntidades = new FabricaEntidades();
            baseDeDatosEvento = FabricaDAOSqlServer.ObtenerDaoEventoM7();
            idPersona = (PersonaM7)FabricaEntidades.ObtenerPersonaM7();
            idPersona.Id = 6;
        }

        /// <summary>
        /// Método que se ejecuta luego de cada prueba
        /// </summary>
        [TearDown]
        public void Clean()
        {
            idPersona = null;
            fabricaEntidades = null;
        }
        #endregion
        /// <summary>
        /// Método de prueba para ConSultarXId en DAO
        /// </summary>
        [Test]
        public void PruebaDetallarEventoXId()
        {
            EventoM7 idEvento = (EventoM7)FabricaEntidades.ObtenerEventoM7();
            idEvento.Id = 5;
            EventoM7 evento = (EventoM7)baseDeDatosEvento.ConsultarXId(idEvento);
            Assert.AreEqual("La vida en el Dojo", evento.Nombre);
        }
        /// <summary>
        /// Método para probar que un evento detallado no sea nulo en DAO
        /// </summary>
        [Test]
        public void PruebaDetallarEventoXIdNoNulo()
        {
            EventoM7 idEvento = (EventoM7)FabricaEntidades.ObtenerEventoM7();
            idEvento.Id = 5;
            EventoM7 evento = (EventoM7)baseDeDatosEvento.ConsultarXId(idEvento);
            Assert.NotNull(evento);
        }

        /// <summary>
        /// Método para probar la exception de número entero invalido de prueba detalle evento en DAO
        /// </summary>
        [Test]
        [ExpectedException(typeof(NumeroEnteroInvalidoException))]
        public void DetalleEventoNumeroEnteroException()
        {
            EventoM7 idEvento = (EventoM7)FabricaEntidades.ObtenerEventoM7();
            idEvento.Id = -1;
            EventoM7 evento = (EventoM7)baseDeDatosEvento.ConsultarXId(idEvento);
        }

        /// <summary>
        /// Método para probar que la lista obtenida tiene cero o mas eventos pagos en DAO
        /// </summary>
        [Test]
        public void PruebaListarEventosPagos()
        {
            List<Entidad> listaEvento = baseDeDatosEvento.ListarEventosPagos(idPersona);
            Assert.GreaterOrEqual(listaEvento.Count, 0);
        }
        /// <summary>
        /// Método para probar que la lista obtenida no sea nula en DAO
        /// </summary>
        [Test]
        public void PruebaListarEventosPagosNoNulo()
        {
            List<Entidad> listaEvento = baseDeDatosEvento.ListarEventosPagos(idPersona);
            Assert.NotNull(listaEvento);
        }

        /// <summary>
        /// Método para probar la exception de número entero invalido de listar eventos pagos en DAO
        /// </summary>
        [Test]
        [ExpectedException(typeof(NumeroEnteroInvalidoException))]
        public void ListarEventoPagoNumeroEnteroException()
        {
            idPersona.Id = -1;
            List<Entidad> listaEvento = baseDeDatosEvento.ListarEventosPagos(idPersona);
           
        }
        /// <summary>
        /// Método para probar que la lista obtenida tiene cero o mas competencias pagadas por atleta en DAO
        /// </summary>
        [Test]
        public void PruebaListarCompetenciasPagas()
        {
            List<Entidad> listaCompetencia = baseDeDatosEvento.ListarCompetenciasPaga(idPersona);
            Assert.GreaterOrEqual(listaCompetencia.Count, 0);
        }

        /// <summary>
        /// Método para probar que la lista obtenida no sea nula en DAO
        /// </summary>
        [Test]
        public void PruebaListarCompetenciasPagasNoNula()
        {
            List<Entidad> listaCompetencia = baseDeDatosEvento.ListarCompetenciasPaga(idPersona);
            Assert.NotNull(listaCompetencia);
        }

        /// <summary>
        /// Método para probar la exception de número entero invalido de listar competencias pagadas en DAO
        /// </summary>
        [Test]
        [ExpectedException(typeof(NumeroEnteroInvalidoException))]
        public void ListarCompetenciaPagaNumeroEnteroException()
        {
            idPersona.Id = -1;
            List<Entidad> listaCompetencia = baseDeDatosEvento.ListarCompetenciasPaga(idPersona);
        }

        /// <summary>
        /// Método para probar que la lista obtenida tiene cero o mas eventos en DAO
        /// </summary>
        [Test]
        public void PruebaListarEventosAsistidos()
        {
            List<Entidad> listaEvento = baseDeDatosEvento.ListarEventosAsistidos(idPersona);
            Assert.GreaterOrEqual(listaEvento.Count, 0);
        }

        /// <summary>
        /// Método para probar que la lista obtenida no sea nula en DAO
        /// </summary>
        [Test]
        public void PruebaListarEventosAsistidosNoNulo()
        {
            List<Entidad> listaEvento = baseDeDatosEvento.ListarEventosAsistidos(idPersona);
            Assert.NotNull(listaEvento);
        }

        /// <summary>
        /// Método para probar la exception de número entero invalido de listar eventos asistidos en DAO
        /// </summary>
        [Test]
        [ExpectedException(typeof(NumeroEnteroInvalidoException))]
        public void ListarEventoAsistidoNumeroEnteroException()
        {
            idPersona.Id = -1;
            List<Entidad> listaEvento = baseDeDatosEvento.ListarEventosAsistidos(idPersona);
        }

        /// <summary>
        /// Método para probar que la lista obtenida tiene cero o mas competencias en DAO
        /// </summary>
        [Test]
        public void PruebaListarCompetenciasAsistidas()
        {
            List<Entidad> listaCompetencia = baseDeDatosEvento.ListarCompetenciasAsistidas(idPersona);
            Assert.GreaterOrEqual(listaCompetencia.Count, 0);
        }

        /// <summary>
        /// Método para probar que la lista obtenida no sea nula en DAO
        /// </summary>
        [Test]
        public void PruebaListarCompetenciasAsistidasNoNula()
        {
            List<Entidad> listaCompetencia = baseDeDatosEvento.ListarCompetenciasAsistidas(idPersona);
            Assert.NotNull(listaCompetencia);
        }

        /// <summary>
        /// Método para probar la exception de número entero invalido de listar eventos asistidos en DAO
        /// </summary>
        [Test]
        [ExpectedException(typeof(NumeroEnteroInvalidoException))]
        public void ListarCompetenciaAsistidaNumeroEnteroException()
        {
            idPersona.Id = -1;
            List<Entidad> listaCompetencia = baseDeDatosEvento.ListarCompetenciasAsistidas(idPersona);
        }

        /// <summary>
        /// Método para probar que la lista obtenida tiene cero o mas eventos en DAO
        /// </summary>
        [Test]
        public void PruebaListarEventosInscritos()
        {
            List<Entidad> listaEvento = baseDeDatosEvento.ListarEventosInscritos(idPersona);
            Assert.GreaterOrEqual(listaEvento.Count, 0);
        }

        /// <summary>
        /// Método para probar que la lista obtenida no sea nula en DAO
        /// </summary>
        [Test]
        public void PruebaListarEventosInscritosNoNulo()
        {
            List<Entidad> listaEvento = baseDeDatosEvento.ListarEventosInscritos(idPersona);
            Assert.NotNull(listaEvento);
        }

        /// <summary>
        /// Método para probar la exception de número entero invalido de listar eventos inscritos en DAO
        /// </summary>
        [Test]
        [ExpectedException(typeof(NumeroEnteroInvalidoException))]
        public void ListarEventosInscritosNumeroEnteroException()
        {
            idPersona.Id = -1;
            List<Entidad> listaEvento = baseDeDatosEvento.ListarEventosInscritos(idPersona);
        }

        /// <summary>
        /// Método para probar que la lista obtenida tiene cero o mas competencias en DAO
        /// </summary>
        [Test]
        public void PruebaListarCompetenciasInscritas()
        {
            List<Entidad> listaCompetencia = baseDeDatosEvento.ListarCompetenciasInscritas(idPersona);
            Assert.GreaterOrEqual(listaCompetencia.Count, 0);
        }

        /// <summary>
        /// Método para probar que la lista obtenida no sea nula en DAO
        /// </summary>
        [Test]
        public void PruebaListarCompetenciasInscritasNoNula()
        {
            List<Entidad> listaCompetencia = baseDeDatosEvento.ListarCompetenciasInscritas(idPersona);
            Assert.NotNull(listaCompetencia);
        }

        /// <summary>
        /// Método para probar la exception de número entero invalido de listar competencia inscrita en DAO
        /// </summary>
        [Test]
        [ExpectedException(typeof(NumeroEnteroInvalidoException))]
        public void ListarCompetenciaInscritaNumeroEnteroException()
        {
            idPersona.Id = -1;
            List<Entidad> listaCompetencia = baseDeDatosEvento.ListarCompetenciasInscritas(idPersona);
        }


        /// <summary>
        /// Método para probar que devuelve la fecha del pago de un evento en DAO
        /// </summary>
        [Test]
        public void PruebaFechaPagoEvento()
        {
            EventoM7 evento = (EventoM7)FabricaEntidades.ObtenerEventoM7();
            evento.Id = 14;
            DateTime fechaPago = baseDeDatosEvento.FechaPagoEvento(idPersona, evento);
            Assert.AreEqual("03/10/2015", fechaPago.ToString("MM/dd/yyyy"));
        }

        /// <summary>
        /// Método para probar que no devuelva nula la fecha de pago de un evento en DAO
        /// </summary>
        [Test]
        public void PruebaFechaPagoEventoNoNula()
        {
            EventoM7 evento = (EventoM7)FabricaEntidades.ObtenerEventoM7();
            evento.Id = 5;
            DateTime fechaPago = baseDeDatosEvento.FechaPagoEvento(idPersona, evento);
            Assert.NotNull(fechaPago);
        }

        /// <summary>
        /// Método para probar la exception de número entero invalido de fecha de pago de un evento en DAO
        /// </summary>
        [Test]
        [ExpectedException(typeof(NumeroEnteroInvalidoException))]
        public void FechaPagoEventoNumeroEnteroException()
        {
            EventoM7 evento = (EventoM7)FabricaEntidades.ObtenerEventoM7();
            evento.Id = -1;
            DateTime fechaPago = baseDeDatosEvento.FechaPagoEvento(idPersona, evento);
        }

        /// <summary>
        /// Método para probar que devuelve la fecha de inscripción de un evento en DAO
        /// </summary>
        [Test]
        public void PruebaFechaInscripcion()
        {
            EventoM7 evento = (EventoM7)FabricaEntidades.ObtenerEventoM7();
            evento.Id = 5;
            DateTime fechaInscripcion = baseDeDatosEvento.FechaInscripcionEvento(idPersona, evento);
            Assert.AreEqual("02/10/2015", fechaInscripcion.ToString("MM/dd/yyyy"));
        }

        /// <summary>
        /// Método para probar que no devuelva nula la fecha de inscripción de un evento en DAO
        /// </summary>
        [Test]
        public void PruebaFechaInscripcionNoNula()
        {
            EventoM7 evento = (EventoM7)FabricaEntidades.ObtenerEventoM7();
            evento.Id = 5;
            DateTime fechaInscripcion = baseDeDatosEvento.FechaInscripcionEvento(idPersona, evento);
            Assert.NotNull(fechaInscripcion);
        }

        /// <summary>
        /// Método para probar la exception de número entero invalido de fecha inscripción de un evento en DAO
        /// </summary>
        [Test]
        [ExpectedException(typeof(NumeroEnteroInvalidoException))]
        public void FechaInscripcionNumeroEnteroException()
        {
            EventoM7 evento = (EventoM7)FabricaEntidades.ObtenerEventoM7();
            evento.Id = -1;
            DateTime fechaInscripcion = baseDeDatosEvento.FechaInscripcionEvento(idPersona, evento);
        }

        /// <summary>
        /// Método para probar que devuelve la fecha de inscripción de una competencia en DAO
        /// </summary>
        [Test]
        public void PruebaFechaInscripcionCompetencia()
        {
            CompetenciaM7 competencia = (CompetenciaM7)FabricaEntidades.ObtenerCompetenciaM7();
            competencia.Id = 8;
            DateTime fechaInscripcion = baseDeDatosEvento.FechaInscripcionCompetencia(idPersona, competencia);
            Assert.AreEqual("02/13/2014", fechaInscripcion.ToString("MM/dd/yyyy"));
        }

        /// <summary>
        /// Método para probar que no devuelva nula la fecha de inscripción de una competencia en DAO
        /// </summary>
        [Test]
        public void PruebaFechaInscripcionCompetenciaNoNula()
        {
            CompetenciaM7 competencia = (CompetenciaM7)FabricaEntidades.ObtenerCompetenciaM7();
            competencia.Id = 8;
            DateTime fechaInscripcion = baseDeDatosEvento.FechaInscripcionCompetencia(idPersona, competencia);
            Assert.NotNull(fechaInscripcion);
        }

        /// <summary>
        /// Método para probar la exception de número entero invalido de fecha inscripción de una competencia en DAO
        /// </summary>
        [Test]
        [ExpectedException(typeof(NumeroEnteroInvalidoException))]
        public void FechaInscripcionCompetenciaNumeroEnteroException()
        {
            CompetenciaM7 competencia = (CompetenciaM7)FabricaEntidades.ObtenerCompetenciaM7();
            competencia.Id = -1;
            DateTime fechaInscripcion = baseDeDatosEvento.FechaInscripcionCompetencia(idPersona, competencia);
        }

        /// <summary>
        /// Método para probar que la lista obtenida tiene cero o mas horarios de practica en DAO
        /// </summary>
        [Test]
        public void PruebaListarHorarioPractica()
        {
            List<Entidad> listaHorario = baseDeDatosEvento.ListarHorarioPractica(idPersona);
            Assert.GreaterOrEqual(listaHorario.Count, 0);
        }

        /// <summary>
        /// Método para probar que la lista obtenida no sea nula en DAO
        /// </summary>
        [Test]
        public void PruebaListarHorarioPracticaNoNula()
        {
            List<Entidad> listaHorario = baseDeDatosEvento.ListarHorarioPractica(idPersona);
            Assert.NotNull(listaHorario);
        }

        /// <summary>
        /// Método para probar que devuelve el monto pago de un evento  en DAO
        /// </summary>
        [Test]
        public void PruebaMontoPagoEvento()
        {
            EventoM7 evento = (EventoM7)FabricaEntidades.ObtenerEventoM7();
            evento.Id = 14;
            float montoPago = baseDeDatosEvento.MontoPagoEvento(idPersona, evento);
            Assert.AreEqual(1200, montoPago);
        }

       
    }
}
