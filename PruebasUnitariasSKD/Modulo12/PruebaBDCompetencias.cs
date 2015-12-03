using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using DominioSKD;
using DatosSKD.Modulo12;

namespace PruebasUnitariasSKD.Modulo12
{
    [TestFixture]
    public class PruebaBDCompetencias
    {
        List<Competencia> laLista;
        Competencia laCompetencia;
        [SetUp]
         public void init()
        {
            laLista         = new List<Competencia> ();
            laCompetencia   = new Competencia();
        }

        [TearDown]

        public void clean()
        {
            laLista = null;
        }

        [Test]

        public void pruebaVacioListaRestriccionCompetencias()
        {
            laLista = BDCompetencia.ListarCompetencias();
            Assert.IsNotNull(laLista);
        }

         [Test]
        public void pruebaContarListaCompetencias()
        {
            laLista = BDCompetencia.ListarCompetencias();
            Assert.AreEqual(7, laLista.ToArray().Length);
        }
        //-------------------------------------------------

        [Test]
        public void pruebaVacioDetallarCompetencia()
        {
            laCompetencia = BDCompetencia.DetallarCompetencia(1);
            Assert.IsNotNull(laCompetencia);
        }

        [Test]
        public void pruebaIdDetallarCompetencia()
        {
            laCompetencia = BDCompetencia.DetallarCompetencia(1);
            Assert.AreEqual(1,laCompetencia.Id_competencia);
        }
        //-------------------------------------------------
        [Test]
        public void pruebaTrueBuscarNombreCompetencia()
        {
            laCompetencia = new Competencia("Ryu Kobudo", "1", true, "Por Iniciar");
            Assert.IsTrue(BDCompetencia.BuscarNombreCompetencia(laCompetencia));
        }
    }
}