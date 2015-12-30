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
    class M10_PruebasLogica
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

        [SetUp]

        public void Init()
        {
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
        }

        [TearDown]

        public void Reset()
        {
            logica = null;
            laListaC = null;
            listaPersona = null;
            listaInscripcion = null;
        }


#region Pruebas
        [Test]
        public void pruebaListarEventoAsistido()
        {
            LogicaAsistencia.ListarEventosAsistidos();
            Assert.IsNotNull(logica);
        }


        [Test]
        public void pruebaListarAsistenciaComp()
        {
            listaPersona =LogicaAsistencia.listaAsistentesCompetencia(idEvento);
            Assert.IsNotNull(listaPersona);
        }


        [Test]
        public void pruebaListarAsistentes()
        {
            listaPersona =  LogicaAsistencia.listaAsistentes(idEvento);
            Assert.AreEqual(16, listaPersona.ToArray().Length);
        }


        [Test]
        public void pruebaListarNoAsistentes()
        {
            listaPersona = LogicaAsistencia.listaNoAsistentes(idEvento);
            Assert.AreEqual(0, listaPersona.ToArray().Length);
        }


        [Test]
        public void pruebaModificarAsistentesE()
        {
            
        }

        [Test]
        public void pruebaModificarAsistentesC()
        {

        }


        [Test]
        public void pruebaConsultarCompetencia()
        {
            laCompetencia = LogicaAsistencia.consultarCompetenciasXID("8");
            Assert.AreEqual(8, laCompetencia.Id_competencia);
        }


        [Test]
        public void pruebaListarInscritosAlEventoCount()
        {
             listaInscripcion = LogicaAsistencia.listaAtletasInasistentesPlanilla(idEvento);
            Assert.AreEqual(57, listaInscripcion.ToString().Length);
        }



        [Test]
        public void pruebaListarInscritosEventos()
        {
            listaPersona = LogicaAsistencia.inscritosAlEvento(idEvento);
            Assert.AreEqual(53, listaPersona.ToString().Length);
        }


        [Test]
        public void pruebaListarAsistentesCompetencia()
        {
            listaPersona = LogicaAsistencia.listaNoAsistentesCompetencia(idEvento);
            Assert.AreEqual(53, listaPersona.ToString().Length);
        }



        [Test]
        public void pruebaListarHorarioEventos()
        {
        
        }


        [Test]
        public void pruebaListarEventoXfecha()
        {
            
        }



#endregion
    }
}
