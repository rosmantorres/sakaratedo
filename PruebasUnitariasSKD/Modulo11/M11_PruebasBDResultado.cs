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

        #endregion

        #region SetUp&TearDown
        [SetUp]
        public void init()
        {


        }


        [TearDown]

        public void clean()
        {
            listaEvento = null;
            listaCompetencia = null;
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

        #endregion
    }
}
