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

        #endregion

        #region SetUp&TearDown
        [SetUp]
        public void init()
        {
            listaEvento = new List<Evento>();
            listaCompetencia = new List<Competencia>();
            listaCategoria = new List<Categoria>();
            idEvento = "3";

        }


        [TearDown]

        public void clean()
        {
            listaEvento = null;
            listaCompetencia = null;
            listaCategoria = null;
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

        #endregion
    }
}
