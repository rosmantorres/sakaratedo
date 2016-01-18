using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using LogicaNegociosSKD;
using LogicaNegociosSKD.Modulo10;
using DominioSKD;
using DatosSKD.Modulo10;



namespace PruebasUnitariasSKD.Modulo10
{
    [TestFixture]
  public  class M10_PruebasLogica
    {
        List<Evento> laLista;
        Evento elEvento;
        private string idPersona;
        List<Competencia> laListaC;
        Competencia laCompetencia;
        private LogicaAsistencia logica;
        Persona laPersona;
        private string idEvento;
        List<Persona> listaPersona;
        List<Inscripcion> listaInscripcion;
        List<Horario> listaHorario;
        private string fechaInicio;
        private string idCompetencia;
        private string fechaFin;
        private string fechaInicio1;
        List<Asistencia> ListaAsistencia;
        Asistencia asistio;

        [SetUp]

        public void Init()
        {
            fechaInicio = "25/10/2016";
            fechaInicio1 = "15/10/2015";
            fechaFin = "15/10/2016";
            laLista = new List<Evento>();
            elEvento = new Evento();
            laListaC = new List<Competencia>();
            laCompetencia = new Competencia();
            logica = new LogicaAsistencia();
            laPersona = new Persona();
            listaPersona = new List<Persona>();
            idPersona = "1";
            idEvento = "3";
            listaInscripcion = new List<Inscripcion>();
            listaHorario = new List<Horario>();
            idCompetencia = "7";
            asistio = new Asistencia();
        }

        [TearDown]

        public void Reset()
        {
            logica = null;
            laListaC = null;
            listaPersona = null;
            listaInscripcion = null;
            listaHorario = null;
            ListaAsistencia = null;
            asistio = null;
        }


        #region Pruebas
        [Test]
        public void pruebaListarEventoAsistido() // No Null
        {
            LogicaAsistencia.ListarEventosAsistidos();
            Assert.IsNotNull(logica);
        }


        [Test]
        public void pruebaListarAsistenciaComp() // No Null
        {
            listaPersona = LogicaAsistencia.listaAsistentesCompetencia(idEvento);
            Assert.IsNotNull(listaPersona);
        }


        [Test]
        public void pruebaListarAsistentes() // Contar!
        {
            listaPersona = LogicaAsistencia.listaAsistentes(idEvento);
            Assert.AreEqual(16, listaPersona.ToArray().Length);
        }


        [Test]
        public void pruebaListarNoAsistentes() // Contar!
        {
            listaPersona = LogicaAsistencia.listaNoAsistentes(idEvento);
            Assert.AreEqual(0, listaPersona.ToArray().Length);
        }


        [Test]
        public void pruebaModificarAsistentesE()
        {
            bool a;
            ListaAsistencia = new List<Asistencia>();
            asistio.Asistio = "N";
            asistio.Evento.Id_evento = 3;
            asistio.Inscripcion.Id_Inscripcion = 20;
            ListaAsistencia.Add(asistio);
            a = LogicaAsistencia.ModificarAsistenciaEvento(ListaAsistencia);
            Assert.IsTrue(a);

        }

        [Test]
        public void pruebaModificarAsistentesC()
        {
            bool a;
            ListaAsistencia = new List<Asistencia>();
            asistio.Asistio = "N";
            asistio.Competencia.Id_competencia = 3;
            asistio.Inscripcion.Id_Inscripcion = 38;
            ListaAsistencia.Add(asistio);
            a = LogicaAsistencia.ModificarAsistenciaCompetencia(ListaAsistencia);
            Assert.IsTrue(a);

        }


        [Test]
        public void pruebaConsultarCompetencia()
        {
            laCompetencia = LogicaAsistencia.consultarCompetenciasXID("8");
            Assert.AreEqual(8, laCompetencia.Id_competencia);
        }


        [Test]
        public void pruebaListarInscritosAlEventoCount() // Contar!
        {
            listaInscripcion = LogicaAsistencia.listaAtletasInasistentesPlanilla(idEvento);
            Assert.AreEqual(0, listaInscripcion.ToArray().Length);
        }



        [Test]
        public void pruebaListarInscritosEventos() // Contar!
        {
            listaPersona = LogicaAsistencia.inscritosAlEvento(idEvento);
            Assert.AreEqual(16, listaPersona.ToArray().Length);
        }


        [Test]
        public void pruebaListarNOAsistentesCompetencia() // Contar!
        {
            listaPersona = LogicaAsistencia.listaNoAsistentesCompetencia("6");
            Assert.AreEqual(4, listaPersona.ToArray().Length);
        }



        [Test]
        public void pruebaListarHorarioEventos()
        {
            listaHorario = LogicaAsistencia.ListarHorariosEventos();
            Assert.AreEqual(18, listaHorario.ToArray().Length);

        }


        [Test]
        public void pruebaListarEventoXfecha()
        {
            laLista = LogicaAsistencia.EventosPorFecha(fechaInicio1, fechaFin);
            Assert.AreEqual(7, laLista.ToArray().Length);
        }

        [Test]
        public void pruebaListarCompetenciasAsistidas() // No null!
        {
            laListaC = LogicaAsistencia.ListarCompetenciasAsistidas();
            Assert.IsNotNull(laListaC);
        }

        [Test]
        public void pruebaListarHorarioCompetenciasContar() // Contar!
        {
            listaHorario = LogicaAsistencia.ListarHorariosCompetencias();
            Assert.AreEqual(7, listaHorario.ToArray().Length);

        }


        [Test]
        public void pruebaCompetenciasXfecha() // Contar!
        {
            laListaC = LogicaAsistencia.competenciasPorFecha(fechaInicio);
            Assert.AreEqual(1, laListaC.ToArray().Length);
        }

        [Test]
        public void pruebaInscritosAlaCompetencia()
        {
            listaPersona = LogicaAsistencia.inscritosCompetencias(idCompetencia);
            Assert.AreEqual(11, listaPersona.ToArray().Length);

        }

        [Test]
        public void pruebaListaAtletasInasistentesPC()
        {
            listaInscripcion = LogicaAsistencia.listaAtletasInasistentesPlanillaCompetencia("6");
            Assert.AreEqual(4, listaInscripcion.ToArray().Length);
        }

        [Test]
        public void pruebaAgregarAsistenciaEvento()
        {
            bool e;
            ListaAsistencia = new List<Asistencia>();
            asistio.Asistio = "S";
            asistio.Evento.Id_evento = 3;
            asistio.Inscripcion.Id_Inscripcion = 50;
            ListaAsistencia.Add(asistio);
            e = LogicaAsistencia.agregarAsistenciaEvento(ListaAsistencia);
            Assert.IsTrue(e);
        }

        [Test]
        public void pruebaAgregarAsistenciaCompetencia()
        {

            bool a;
            ListaAsistencia = new List<Asistencia>();
            asistio.Asistio = "S";
            asistio.Competencia.Id_competencia = 3;
            asistio.Inscripcion.Id_Inscripcion = 53;
            ListaAsistencia.Add(asistio);
            a = BDAsistencia.agregarAsistenciaCompetencia(ListaAsistencia);
            Assert.IsTrue(a);

        }
        #endregion
    }
}
