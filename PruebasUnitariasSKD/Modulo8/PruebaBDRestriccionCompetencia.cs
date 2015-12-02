using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using DominioSKD;
using DatosSKD;
using DatosSKD.Modulo8;


namespace PruebasUnitariasSKD.Modulo8
{
   [TestFixture]
    public class PruebaBDRestriccionCompetencia
    {
       List<Competencia> laListaCompetencias;
       Competencia laCompetencia;
       List<RestriccionCompetencia> laListaRestriccionCompetencia;
       RestriccionCompetencia laRestriccionCompetencia;

       [SetUp]
       public void init()
       {
           laListaCompetencias = new List<Competencia>();
           laCompetencia = new Competencia();
           laListaRestriccionCompetencia = new List<RestriccionCompetencia>();
           laRestriccionCompetencia = new RestriccionCompetencia() ;
       }

       [Test]

       public void pruebaVacioListaRestriccionCompetencias()
       {
           laListaRestriccionCompetencia = BDRestriccionCompetencia.ListarRestriccionesCompetencia();
           Assert.IsNotNull(laListaRestriccionCompetencia);
       }

       [Test]


       [TearDown]
       public void limpiar()
       {
           laListaCompetencias = null;
           laCompetencia = null;
           laListaRestriccionCompetencia = null;
           laRestriccionCompetencia = null;
       }
    }
}
