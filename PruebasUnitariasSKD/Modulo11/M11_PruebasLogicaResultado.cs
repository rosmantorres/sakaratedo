using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using LogicaNegociosSKD;
using LogicaNegociosSKD.Modulo11;
using DominioSKD;

namespace PruebasUnitariasSKD.Modulo11
{

    [TestFixture]
    public class M11_PruebasLogicaResultado
    {

        List<Evento> listaEvento;
        List<Competencia> listaCompetencia;

        [SetUp]

        public void init()
        {

            listaEvento = new List<Evento>();
            listaCompetencia = new List<Competencia>();


        }

        [TearDown]

        public void reset()
        {
            listaEvento = null;
            listaCompetencia = null;



        }


        #region Pruebas Unitarias
        [Test]

        public void ListarResultadosEventosPasados()
        {
            listaEvento = LogicaResultado.ListarResultadosEventosPasados();
            Assert.IsNotNull(listaEvento);
        }

        [Test]

        public void ListarResultadosEventosPasadosContar()
        {
            listaEvento = LogicaResultado.ListarResultadosEventosPasados();
            Assert.AreEqual(1, listaEvento.ToArray().Length);
        }


        [Test]

        public void ListarCompetenciasAsistidasContar()
        {
            listaCompetencia = LogicaResultado.ListarCompetenciasAsistidas();
            Assert.AreEqual(3, listaCompetencia.ToArray().Length);
        }

        [Test]

        public void ListarCompetenciasAsistidas()
        {
            listaCompetencia = LogicaResultado.ListarCompetenciasAsistidas();
            Assert.NotNull(listaCompetencia);
        }

        #endregion
    }


}
