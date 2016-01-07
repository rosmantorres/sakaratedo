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
    class M11_PruebasBDResultado
    {
        #region Atributos

        List<Evento> listaEvento;
        List<Competencia> listaCompetencia;
        List<Categoria> listaCategoria;
        private string idEvento;
        List<ResultadoAscenso> listaResAscenso;
        private ResultadoAscenso resultadoA;

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
        

        }


        [TearDown]

        public void clean()
        {
            listaEvento = null;
            listaCompetencia = null;
            listaCategoria = null;
            listaResAscenso = null;
 
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
            Assert.AreEqual(1, listaEvento.ToArray().Length );

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

        public void PruebalistaCategoriasEvento()
        {

            listaCategoria = BDResultado.listaCategoriasEvento(idEvento);
            Assert.AreEqual(3, listaCategoria.ToArray().Length);

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

        #endregion
    }
}
