using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using DominioSKD;
using DatosSKD;
using DatosSKD.Modulo10;

namespace PruebasUnitariasSKD.Modulo10
{
    /// <summary>
    /// Clase que se encarga de Realizar las pruebas unitarias de los metodos de la Clase BDAsistencia
    /// </summary>
    /// 

    [TestFixture]
    public class M10_PruebasBDAsistencia
    {
        #region Atributos
        List<Evento> laLista;
        private Evento elEvento;
        private int idEvento;
        private string idDeEvento;
        List<Inscripcion> ListaInsc;
        List<Asistencia> ListaAsistencia;
        List<Horario> listaHorario;

        List<Competencia> laListaC;
        private Competencia laCompetencia;
        List<Persona> ListaP;
        private int idPersona;
        Persona laPersona;
        private int idInscripcion;
        private Inscripcion inscripcion;
        private Asistencia asistio;
        private string idCompetencia;
        private int Competenciaid;
        BDAsistencia baseDeDatosA;
        private string asiste;
        private string fechaInicio;


        #endregion

        #region SetUp&TearDown

        [SetUp]
        public void init()
        {
            Categoria cat = new Categoria(15, 16, "verde", "amarillo", "masculino");
            laLista = new List<Evento>();
            DateTime fechaInicio = new DateTime(2009, 5, 1, 8, 30, 52);
            DateTime fechaFin = new DateTime(2009, 5, 1, 1, 1, 1);
            Horario horario = new Horario(1, fechaInicio, fechaFin, 10, 11);
            Evento elEvento = new Evento();
            elEvento.Nombre = "Prueba Unitaria";
            elEvento.Descripcion = "las pruebas";
            elEvento.Costo = 70;
            elEvento.Estado = true;
            elEvento.Categoria = cat;
            elEvento.Horario = horario;
            elEvento.Ubicacion = new Ubicacion("11.458741", "10.449942", "Caracas", "Miranda", "null");
            Persona laPersona = new Persona();
            laPersona.ID = 10;
            Competencia laCompetencia = new Competencia();
            asistio = new Asistencia();

            ListaP = new List<Persona>();
            laListaC = new List<Competencia>();
            idEvento = 1;
            Inscripcion inscripcion = new Inscripcion();
            idInscripcion = 10;
            asiste = "Si";
            idDeEvento = "3";
            idCompetencia = "8";
            baseDeDatosA = new BDAsistencia();
            Competenciaid = 8;

            laCompetencia.Id_competencia = 8;
            laCompetencia.Nombre = "Ryu Kobudo";
            laCompetencia.TipoCompetencia = "1";
            laCompetencia.OrganizacionTodas = true;
            laCompetencia.Status = "Por Iniciar";





        }


        [TearDown]

        public void clean()
        {
            laLista = null;
            laListaC = null;
            baseDeDatosA = null;
            ListaAsistencia = null;
            laPersona = null;
        }

        #endregion

        #region Pruebas Unitarias

        [Test]
        public void PruebaListarEventosA()
        {

            laLista = BDAsistencia.ListarEventosAsistidos();
            Assert.IsNotNull(laLista);
        }
        [Test]
        public void PruebaListarAsistente()
        {

            ListaP = BDAsistencia.listaAsistentes(idDeEvento);
            Assert.IsNotNull(ListaP);

        }

        [Test]
        public void PruebaListarNoAsistente()
        {

            ListaP = BDAsistencia.listaNoAsistentes(idDeEvento);
            Assert.IsNotNull(ListaP);

        }


        [Test]
        public void PruebaListarCompetenciasA()
        {
            laListaC = BDAsistencia.ListarCompetenciasAsistidas();
            Assert.IsNotNull(laListaC);

        }


        [Test]
        public void PruebaModificarAsitenteE()
        {

            bool a;
            ListaAsistencia = new List<Asistencia>();
            asistio.Asistio = "N";
            asistio.Evento.Id_evento = 3;
            asistio.Inscripcion.Id_Inscripcion = 33;
            ListaAsistencia.Add(asistio);
            a = BDAsistencia.ModificarAsistenciaE(ListaAsistencia);
            Assert.IsTrue(a);

        }



        [Test]
        public void PruebaConsultarCompetenciaXID()
        {
            laCompetencia = BDAsistencia.consultarCompetenciasXID(idCompetencia);

        }



        [Test]
        public void PruebaListarAsistenteCompetencia()
        {

            ListaP = BDAsistencia.listaAsistentesCompetencia(idDeEvento);
            Assert.IsNotNull(ListaP);
        }


        [Test]
        public void PruebaListarNoAsistenteC()
        {
            ListaP = BDAsistencia.listaNoAsistentesCompetencia(idDeEvento);
            Assert.IsNotNull(ListaP);

        }

        [Test]
        public void PruebaModificarAsistenciaC()
        {
            bool a;
            ListaAsistencia = new List<Asistencia>();
            asistio.Asistio = "N";
            asistio.Competencia.Id_competencia = 6;
            asistio.Inscripcion.Id_Inscripcion = 9;
            ListaAsistencia.Add(asistio);
            a = BDAsistencia.ModificarAsistenciaC(ListaAsistencia);
            Assert.IsTrue(a);

        }


        [Test]
        public void PruebaListaIporPlanilla()
        {
            ListaInsc = BDAsistencia.listaInasistentesPlanilla(idDeEvento);
            Assert.IsNotNull(ListaInsc);
        }


        [Test]
        public void PruebaListaAtletaIEvento()
        {
            ListaP = BDAsistencia.listaAtletasInscritosEvento(idDeEvento);
            Assert.IsNotNull(ListaP);

        }


        [Test]
        public void PruebaAgregarAsistenciaEvento()
        {

            bool a;
            ListaAsistencia = new List<Asistencia>();
            asistio.Asistio = "S";
            asistio.Evento.Id_evento = 3;
            asistio.Inscripcion.Id_Inscripcion = 50;
            ListaAsistencia.Add(asistio);
            a = BDAsistencia.agregarAsistenciaEvento(ListaAsistencia);
            Assert.IsTrue(a);


        }


        [Test]
        public void PruebaAgregarAsistenciaCompetencia()
        {
            bool a;
            ListaAsistencia = new List<Asistencia>();
            asistio.Asistio = "N";
            asistio.Competencia.Id_competencia = 3;
            asistio.Inscripcion.Id_Inscripcion = 52;
            ListaAsistencia.Add(asistio);
            a = BDAsistencia.agregarAsistenciaCompetencia(ListaAsistencia);
            Assert.IsTrue(a);


        }

        [Test]
        public void PruebaListarHorarioCompetencia()
        {
            listaHorario = BDAsistencia.ListarHorariosCompetencias();
            Assert.AreEqual(7, listaHorario.ToArray().Length);

        }

        [Test]
        public void PruebaCompetenciaPorFecha()
        {
            laListaC = BDAsistencia.competenciasPorFecha("15/10/2015");
            Assert.AreEqual(laListaC, BDAsistencia.competenciasPorFecha("15/10/2015"));

        }

        [Test]
        public void PruebaListarAtletasInscritosCompetencia()
        {
            ListaP = BDAsistencia.listaAtletasInscritosCompetencia(idCompetencia);
            Assert.IsNotNull(ListaP);
        }

        [Test]
        public void PruebaInasistentesPlanillaCompetencia()
        {
            ListaInsc = BDAsistencia.listaInasistentesPlanillaCompetencia(idCompetencia);
            Assert.IsNotNull(ListaInsc);
        }

    }



}

        #endregion
