using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using DominioSKD;
using DatosSKD;
using DatosSKD.Modulo11;

namespace PruebasUnitariasSKD.Modulo11
{

    /// <summary>
    /// Clase que se encarga de Realizar las pruebas unitarias de los metodos de la Clase BDResultado
    /// </summary>
    /// 


    [TestFixture]
  public class M11_PruebasBDResultado
    {
        #region Atributos

        List<Evento> listaEvento;
        private Evento evento;
        List<Competencia> listaCompetencia;
        List<Categoria> listaCategoria;
        private string idEvento;
        List<ResultadoAscenso> listaResAscenso;
        private ResultadoAscenso resultadoA;
        List<ResultadoKata> listaResKata;
        private ResultadoKata resultadoKata;
        List<ResultadoKumite> listaResKumite;
        private ResultadoKumite resultadoKumite;
        List<Persona> listaPersona;
        private Persona persona;

        #endregion

        #region SetUp&TearDown
        [SetUp]
        public void init()
        {
            listaEvento = new List<Evento>();
            listaCompetencia = new List<Competencia>();
            listaCategoria = new List<Categoria>();
            idEvento = "3";
            listaResAscenso = new List<ResultadoAscenso>();
            resultadoA = new ResultadoAscenso();
            listaResKata = new List<ResultadoKata>();
            resultadoKata = new ResultadoKata();
            listaResKumite = new List<ResultadoKumite>();
            resultadoKumite = new ResultadoKumite();
            listaPersona = new List<Persona>();
            persona = new Persona();
            Evento evento = new Evento();


            persona.ID = 1;
            persona.IdInscripcion = 54;
            persona.Nombre = "Miguel Alejandro";


        }


        [TearDown]

        public void clean()
        {
            listaEvento = null;
            listaCompetencia = null;
            listaCategoria = null;
            listaResAscenso = null;
            listaResKata = null;
            listaResKumite = null;
            listaPersona = null;


        }

        #endregion

        #region Pruebas Unitarias

        [Test]

        public void PruebaListarResultadoEventoP()
        {

            listaEvento = BDResultado.ListarResultadosEventosPasados();
            Assert.IsNotNull(listaEvento);

        }

        [Test]

        public void PruebaCountResultadoEventoP()
        {

            listaEvento = BDResultado.ListarResultadosEventosPasados();
            Assert.AreEqual(1, listaEvento.ToArray().Length);

        }



        [Test]

        public void PruebaListarCompetenciasAsistidas()
        {

            listaCompetencia = BDResultado.ListarCompetenciasAsistidas();
            Assert.IsNotNull(listaCompetencia);

        }


        [Test]

        public void PruebaListarCompetenciasAsistidasCount()
        {

            listaCompetencia = BDResultado.ListarCompetenciasAsistidas();
            Assert.AreEqual(3, listaCompetencia.ToArray().Length);

        }


        [Test]

        public void PruebalistaCategoriasEventoContar()
        {

            listaCategoria = BDResultado.listaCategoriasEvento(idEvento);
            Assert.AreEqual(3, listaCategoria.ToArray().Length);


        }

        [Test]

        public void PruebalistaCategoriasEvento()
        {

            listaCategoria = BDResultado.listaCategoriasEvento(idEvento);
            Assert.NotNull(listaCategoria);

        }


        [Test]

        public void PruebaListarAtletaEnCatyAsc()
        {



        }

        [Test]

        public void PruebaListarEspecialidadesCompetencia() //idCompetencia
        {


        }


        [Test]

        public void PruebaListaCategoriasComp()
        {


        }

        [Test]

        public void PruebaListarAtletasParticipanComp()
        {


        }



        [Test]

        public void PruebaModificarAscenso()
        {

            bool a;
            listaResAscenso = new List<ResultadoAscenso>();
            resultadoA.Inscripcion.ResAscenso = listaResAscenso;
            resultadoA.Aprobado = "N";
            resultadoA.Inscripcion.Evento.Id_evento = 3;
            resultadoA.Inscripcion.Id_Inscripcion = 32;
            listaResAscenso.Add(resultadoA);
            a = BDResultado.ModificarResultadoAscenso(listaResAscenso);
            Assert.IsTrue(a);


        }



        [Test]

        public void PruebaModificarKata()
        {

            bool a;
            listaResKata = new List<ResultadoKata>();
            resultadoKata.Inscripcion.Id_Inscripcion = 1;
            resultadoKata.Inscripcion.Competencia.Id_competencia = 5;
            resultadoKata.Jurado1 = 1;
            resultadoKata.Jurado2 = 1;
            resultadoKata.Jurado3 = 1;
            listaResKata.Add(resultadoKata);
            a = BDResultado.ModificarResultadoKata(listaResKata);
            Assert.IsTrue(a);

        }


        [Test]

        public void PruebaModificarKumite()
        {

            bool a;
            listaResKumite = new List<ResultadoKumite>();
            resultadoKumite.Inscripcion1.Id_Inscripcion = 9;
            resultadoKumite.Puntaje1 = 5;
            resultadoKumite.Inscripcion2.Id_Inscripcion = 11;
            resultadoKumite.Puntaje2 = 9;
            resultadoKumite.Inscripcion1.Competencia.Id_competencia = 6;
            listaResKumite.Add(resultadoKumite);
            a = BDResultado.ModificarResultadoKumite(listaResKumite);
            Assert.IsTrue(a);


        }
        #endregion
    }
}
